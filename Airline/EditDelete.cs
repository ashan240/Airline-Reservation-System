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
    public partial class EditDelete : Form
    {
        //create DB objects
        private DataTable table;
        private OleDbCommand command;
        OleDbDataReader reader;

        public EditDelete(DataTable table)
        {
            InitializeComponent();
            command = new OleDbCommand();
            this.table = table;
        }

        //Bind the form objects to the data from the DataTable
        private void EditDelete_Load(object sender, EventArgs e)
        {
            //bind text boxes
            txtPassengerID.DataBindings.Add("Text", table, "ID");
            txtName.DataBindings.Add("Text", table, "Name");
            txtSeatID.DataBindings.Add("Text", table, "SeatID");

            //bind drop downs
            //If seats are empty (passenger is on waiting list), 
            //make the first index in drop down selected ("None" for seat row and column)
            var r = table.Rows[0]["SeatRow"].ToString();
            var row = r.Equals("") ? 0 : Convert.ToInt32(r);
            var c = table.Rows[0]["SeatColumn"].ToString();
            var column = c.Equals("") ? "None" : c;
            cmbRow.SelectedIndex = row;
            cmbColumn.SelectedItem = column;

            chbWaiting.Checked = Convert.ToBoolean(table.Rows[0]["OnWaitingList"]);
        }

        //edit record
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //validate input
            //make sure passenger name has been entered
            if (txtName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Passenger Name is required.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //passenger cannot be on waiting list and have seat assigned
            if (chbWaiting.Checked && (cmbRow.SelectedIndex > 0 || cmbColumn.SelectedIndex > 0))
            {
                MessageBox.Show("Passenger Cannot be on waiting list and have a seat assigned",
                    "Bad Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //passenger must be either on waiting list or have seat assigned
            if (!chbWaiting.Checked && (cmbRow.SelectedIndex <= 0 || cmbColumn.SelectedIndex <= 0))
            {
                MessageBox.Show("Passenger Seat has to have row and column assigned",
                    "Bad Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //update record.
            //1. Get the id of the new seat
            //2. check if the new seat is already taken
            //3. check if the user is only updating the passenger name. 
            //      If so, then ignore that the seat is taken (it is taken by the same passenger)
            //4. update all tables
            //      - update passenger name in Passengers table
            //      - update seats table. The old seat needs to be updated to not taken, and new seat to taken.
            //      - assign new seatID to the passengerID in PassengerSeats table
            using (var conn = new OleDbConnection(DatabaseObjects.ConnectionString))
            {
                conn.Open();
                command = new OleDbCommand("SELECT SeatID, IsTaken FROM Seats WHERE " +
                    "SeatRow = @SeatRow AND SeatColumn = @SeatColumn", conn);
                command.Parameters.Add(new OleDbParameter("SeatRow", cmbRow.SelectedItem));
                command.Parameters.Add(new OleDbParameter("SeatColumn", cmbColumn.SelectedItem));
                reader = command.ExecuteReader();

                var newSeatID = 0;
                bool newIsTaken = false;
                while (reader.Read())
                {
                    newSeatID = Convert.ToInt32(reader["SeatID"]);
                    newIsTaken = Convert.ToBoolean(reader["IsTaken"]);
                }

                //check if only the name is being updated. 
                //If not, exit because the user needs to pick a different seat
                int oldID = 0;
                if (txtSeatID.Text.Equals(""))
                    oldID = 0;
                else
                    oldID = Convert.ToInt32(txtSeatID.Text);

                if (!txtSeatID.Equals(""))
                {
                    if (newSeatID != oldID && newIsTaken)
                    {
                        MessageBox.Show("Seat is already taken", "Seat Taken", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                    newSeatID = 0;

                //update passenger's name
                command = new OleDbCommand("UPDATE Passengers SET PassengerName = @PassengerName, " +
                    "PassengerOnWaitingList = @OnWaitingList WHERE PassengerID = @PassengerID", conn);
                command.Parameters.Add(new OleDbParameter("PassengerName", txtName.Text));
                command.Parameters.Add(new OleDbParameter("OnWaitingList", chbWaiting.Checked));
                command.Parameters.Add(new OleDbParameter("PassengerID", txtPassengerID.Text));
                command.ExecuteNonQuery();

                //make original seat available
                command = new OleDbCommand("UPDATE Seats SET IsTaken = false WHERE " +
                    "seatID = @seatID", conn);
                command.Parameters.Add(new OleDbParameter("seatID", txtSeatID.Text));
                command.ExecuteNonQuery();

                //make new seat taken
                command = new OleDbCommand("UPDATE Seats SET IsTaken = true WHERE " +
                    "seatID = @seatID", conn);
                command.Parameters.Add(new OleDbParameter("seatID", newSeatID));
                command.ExecuteNonQuery();

                //update old seatID with the new one
                command = new OleDbCommand("UPDATE PassengerSeats SET SeatID = @SeatID WHERE " +
                    "PassengerID = @PassengerID", conn);
                command.Parameters.Add(new OleDbParameter("SeatID", newSeatID));
                command.Parameters.Add(new OleDbParameter("PassengerID", txtPassengerID.Text));
                command.ExecuteNonQuery();

                MessageBox.Show("Record has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //ask user if he wants to delete passenger

            //if not to delete, then exit and do nothing

            //if to delete, then delete passenger from Passengers and PassengersSeats table

            //The seat still exists, but we need to update the Seats table and mark the seat as not taken

            using (var conn = new OleDbConnection(DatabaseObjects.ConnectionString))
            {
                conn.Open();

                var msg = MessageBox.Show("Are you sure you want to delete " + txtName.Text + " from the database?",
                    "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (msg == DialogResult.No) return;

                command = new OleDbCommand("DELETE FROM Passengers WHERE PassengerID = @PassengerID", conn);
                command.Parameters.Add(new OleDbParameter("PassengerID", txtPassengerID.Text));
                command.ExecuteNonQuery();

                command = new OleDbCommand("DELETE FROM PassengerSeats WHERE PassengerID = @PassengerID", conn);
                command.Parameters.Add(new OleDbParameter("PassengerID", txtPassengerID.Text));
                command.ExecuteNonQuery();

                if (!txtSeatID.Text.Equals(""))
                {
                    command = new OleDbCommand("UPDATE Seats SET IsTaken = false WHERE seatID = @seatID", conn);
                    command.Parameters.Add(new OleDbParameter("SeatID", txtSeatID.Text));
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Record has been deleted", "Deleted", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
