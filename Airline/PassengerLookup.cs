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
    public partial class PassengerLookup : Form
    {
        private OleDbCommand command;
        private DataTable table;

        public PassengerLookup(DataTable table)
        {
            InitializeComponent();
            this.table = table;
        }

        private void PassengerLookup_Load(object sender, EventArgs e)
        {
            dgvOutput.DataSource = table;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the row number that was clicked
            var index = e.RowIndex;

            //get the passengerID from the clicked row and pass it to the command
            int selectedID = Convert.ToInt32(dgvOutput.Rows[index].Cells[0].Value);

            //Select all the passenger information from all three tables that matches 
            //the passengerID of the passenger that was clicked
            using (var conn = new OleDbConnection(DatabaseObjects.ConnectionString))
            {
                conn.Open();
                command = new OleDbCommand
                ("Select p.PassengerID as ID, s.SeatID, p.PassengerName as Name, s.SeatRow, s.SeatColumn, " +
                "p.PassengerOnWaitingList as OnWaitingList " +
                "FROM (Passengers p " +
                "inner join PassengerSeats ps on p.PassengerID = ps.PassengerID) " +
                "inner join Seats s on s.SeatID = ps.SeatID " +
                "WHERE p.PassengerID = @PassengerID " +
                "UNION " +
                "Select p.PassengerID, null, p.PassengerName, null,null,p.PassengerOnWaitingList " +
                "FROM Passengers p " +
                "WHERE p.PassengerOnWaitingList = true AND p.PassengerID = @PassengerID " +
                "ORDER BY s.SeatRow, s.SeatColumn", conn);
                command.Parameters.Add(new OleDbParameter("PassengerID", selectedID));
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                EditDelete form = new EditDelete(dt);
                form.ShowDialog();
                Close();
            }

            //execute command and place results to DataTable and pass it to the EditDelete form
        }
    }
}
