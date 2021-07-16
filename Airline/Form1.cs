using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline
{
    public partial class frmReservations : Form
    {
        //passenger and seat objects
        Passenger passenger;
        Seat seat;

        //list of all seats (used to display the seats in the list box)
        public static List<Seat> seats;

        //db objects
        private OleDbCommand command;
        private OleDbDataReader reader;

        public frmReservations()
        {
            InitializeComponent();
            command = new OleDbCommand();
            seats = new List<Seat>();
        }

        //when form loads, display the list of seats and populate the drop down with seat rows
        private void frmReservations_Load(object sender, EventArgs e)
        {
            PopulateSeatRows();
            PopulateAirplane();
        }

        //add passenger
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //passenger and seat objects
            passenger = new Passenger();
            seat = new Seat();

            //see what seat column was selected (A, B, C, or D)
            var checkedButton = Controls.OfType<RadioButton>()
                                        .FirstOrDefault(r => r.Checked);

            //validate input. Valid name, seat row and selection of seat column is required
            if (!passenger.IsValidPassenger(txtName.Text) || cmbSeatRow.SelectedIndex == -1 ||
                checkedButton == null)
            {
                MessageBox.Show("Please enter valid name and seat", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            //check if plane is full. If it is, place passenger on waitig list
            if (seat.IsPlaneFull())
            {
                var msg = MessageBox.Show("The plane is full. Add passenger on waiting list?", "Plane Full",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (msg == DialogResult.No) return;

                using (var conn = new OleDbConnection(DatabaseObjects.ConnectionString))
                {
                    conn.Open();
                    command = new OleDbCommand("INSERT INTO Passengers (PassengerName, PassengerOnWaitingList) " +
                        "VALUES (@passengerName, true)", conn);
                    command.Parameters.Add(new OleDbParameter("PassengerName", txtName.Text));
                    command.ExecuteNonQuery();

                    command = new OleDbCommand("INSERT INTO PassengerSeats (PassengerID, SeatID) " +
                        "SELECT MAX(PassengerID), 0 from Passengers", conn);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Passenger " + txtName.Text + " was added to the waiting list", 
                        "Waiting List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;
            }

            //check if seat is taken. If it is, exit so the user can select a different seat
            if (seat.IsSeatAlreadyTaken(cmbSeatRow.SelectedItem.ToString(), checkedButton.Text))
            {
                MessageBox.Show("The seat is already taken. Please select different seat",
                        "Seat Taken", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //if everything is OK add passenger and seat to database along with the assigned seat
            //Insert new passenger to Passengers db. 
            //Update seat to Taken in Seats db. 
            //Insert Passenger and Seat ID in PassengerSeats db
            using (var conn = new OleDbConnection(DatabaseObjects.ConnectionString))
            {
                conn.Open();
                command = new OleDbCommand("INSERT INTO Passengers (PassengerName) " +
                        "VALUES (@passengerName)", conn);
                command.Parameters.Add(new OleDbParameter("PassengerName", txtName.Text));
                command.ExecuteNonQuery();

                command = new OleDbCommand("UPDATE Seats SET IsTaken = true WHERE " +
                    "SeatRow = @SeatRow AND SeatColumn = @SeatColumn", conn);
                command.Parameters.Add(new OleDbParameter("SeatRow", cmbSeatRow.Text));
                command.Parameters.Add(new OleDbParameter("SeatColumn", checkedButton.Text));
                command.ExecuteNonQuery();

                command = new OleDbCommand("INSERT INTO PassengerSeats (SeatID, PassengerID) " +
                    "Select Seats.SeatID, (SELECT MAX(PassengerID) FROM Passengers) " +
                    "FROM Seats WHERE Seats.SeatRow = @SeatRow AND Seats.SeatColumn = @SeatColumn", 
                    conn);
                command.Parameters.Add(new OleDbParameter("SeatRow", cmbSeatRow.Text));
                command.Parameters.Add(new OleDbParameter("SeatColumn", checkedButton.Text));
                command.ExecuteNonQuery();

                MessageBox.Show("Passenger has been added",
                        "Added Passenger", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PopulateAirplane();
            }

        }

        //Show all passengers
        private void btnShowPassengers_Click(object sender, EventArgs e)
        {
            //Get all passenger information from all 3 tables (will use Inner Join)
            //place the result into DataTable and display the result in Lookups form
            //when focus is back, repopulate the list box with updated records
            using (var conn = new OleDbConnection(DatabaseObjects.ConnectionString))
            {
                conn.Open();
                command = new OleDbCommand
                    ("Select p.PassengerID as ID, p.PassengerName as Name, s.SeatRow, s.SeatColumn, " +
                    "p.PassengerOnWaitingList as OnWaitingList " +
                    "FROM (Passengers p " +
                    "inner join PassengerSeats ps on p.PassengerID = ps.PassengerID) " +
                    "inner join Seats s on s.SeatID = ps.SeatID " +
                    "UNION " +
                    "Select p.PassengerID, p.PassengerName, null,null,p.PassengerOnWaitingList " +
                    "FROM Passengers p " +
                    "WHERE p.PassengerOnWaitingList = true " +
                    "ORDER BY s.SeatRow, s.SeatColumn", conn);

                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                PassengerLookup form = new PassengerLookup(dt);
                form.ShowDialog();
                PopulateAirplane();
            }
        }

        //search for passenger
        private void btnSearchPassenger_Click(object sender, EventArgs e)
        {
            //make sure a search string was entered in the text box
            //Get all the passengers that match the search string. Get all the information from all 3 tables.
            //Place the result in a DataTable and then display it in Lookups form
            using (var conn = new OleDbConnection(DatabaseObjects.ConnectionString))
            {
                conn.Open();
                if (!txtName.Text.Trim().Equals(""))
                {
                    command = new OleDbCommand
                    ("Select p.PassengerID as ID, p.PassengerName as Name, s.SeatRow, s.SeatColumn, " +
                    "p.PassengerOnWaitingList as OnWaitingList " +
                    "FROM (Passengers p " +
                    "inner join PassengerSeats ps on p.PassengerID = ps.PassengerID) " +
                    "inner join Seats s on s.SeatID = ps.SeatID " +
                    "WHERE p.PassengerName LIKE @PassengerName " +
                    "UNION " +
                    "Select p.PassengerID, p.PassengerName, null,null,p.PassengerOnWaitingList " +
                    "FROM Passengers p " +
                    "WHERE p.PassengerOnWaitingList = true AND p.PassengerName LIKE @PassengerName " +
                    "ORDER BY s.SeatRow, s.SeatColumn", conn);
                    command.Parameters.Add(new OleDbParameter("PassengerName", "%" + txtName.Text + "%"));
                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());
                    PassengerLookup form = new PassengerLookup(dt);
                    form.ShowDialog();
                    PopulateAirplane();
                }
                else
                {
                    MessageBox.Show("Please enter a valid name", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Display the seats in list box
        private void PopulateAirplane()
        {
            //clear previous listbox and list of Seats
            lstOutput.Items.Clear();
            seats.Clear();

            //Select * seats from Seats db. Read result and create a Seat object with 
            //ID, Row, Column and IsTaken property from the reader
            //Add the Seat object to the list
            //Loop through the list and display the content in the list box
            using (var conn = new OleDbConnection(DatabaseObjects.ConnectionString))
            {
                conn.Open();
                command = new OleDbCommand("SELECT * FROM Seats ORDER BY SeatRow, SeatColumn", conn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var seat = new Seat();
                    seat.SeatID = Convert.ToInt32(reader["SeatID"]);
                    seat.SeatRow = Convert.ToInt32(reader["SeatRow"]);
                    seat.SeatColumn = reader["SeatColumn"].ToString();
                    seat.IsSeatTaken = Convert.ToBoolean(reader["IsTaken"]);
                    seats.Add(seat);
                }

                var msg = "";
                var counter = 0;
                for (int i =0; i < seats.Count; i++)
                {
                    counter++;
                    if (seats[i].IsSeatTaken)
                        msg += "  " + "XX" + "  ";
                    else
                        msg += "  " + seats[i].SeatRow + seats[i].SeatColumn + "  ";

                    if (counter % 4 == 0)
                    {
                        lstOutput.Items.Add(msg);
                        msg = "";
                    }
                    else if (counter % 2 == 0)
                    {
                        msg += "        ";
                    }
                }
            }
        }

        //populate drop down with seat rows
        private void PopulateSeatRows()
        {
            //get row numbers            
            using (var conn = new OleDbConnection(DatabaseObjects.ConnectionString))
            {
                conn.Open();
                command = new OleDbCommand("SELECT DISTINCT SeatRow FROM Seats ORDER BY SeatRow", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cmbSeatRow.Items.Add(reader["SeatRow"]);
                }
            }
        }
    }
}
