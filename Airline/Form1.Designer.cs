namespace Airline
{
    partial class frmReservations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearchPassenger = new System.Windows.Forms.Button();
            this.cmbSeatRow = new System.Windows.Forms.ComboBox();
            this.radD = new System.Windows.Forms.RadioButton();
            this.radC = new System.Windows.Forms.RadioButton();
            this.radB = new System.Windows.Forms.RadioButton();
            this.radA = new System.Windows.Forms.RadioButton();
            this.btnShowPassengers = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.grpSeatColumn = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnSearchPassenger
            // 
            this.btnSearchPassenger.Location = new System.Drawing.Point(57, 246);
            this.btnSearchPassenger.Name = "btnSearchPassenger";
            this.btnSearchPassenger.Size = new System.Drawing.Size(105, 23);
            this.btnSearchPassenger.TabIndex = 67;
            this.btnSearchPassenger.Text = "Search Passenger";
            this.btnSearchPassenger.UseVisualStyleBackColor = true;
            this.btnSearchPassenger.Click += new System.EventHandler(this.btnSearchPassenger_Click);
            // 
            // cmbSeatRow
            // 
            this.cmbSeatRow.FormattingEnabled = true;
            this.cmbSeatRow.Location = new System.Drawing.Point(57, 49);
            this.cmbSeatRow.Name = "cmbSeatRow";
            this.cmbSeatRow.Size = new System.Drawing.Size(78, 21);
            this.cmbSeatRow.TabIndex = 66;
            // 
            // radD
            // 
            this.radD.AutoSize = true;
            this.radD.Location = new System.Drawing.Point(100, 112);
            this.radD.Name = "radD";
            this.radD.Size = new System.Drawing.Size(33, 17);
            this.radD.TabIndex = 65;
            this.radD.TabStop = true;
            this.radD.Tag = "D";
            this.radD.Text = "D";
            this.radD.UseVisualStyleBackColor = true;
            // 
            // radC
            // 
            this.radC.AutoSize = true;
            this.radC.Location = new System.Drawing.Point(67, 111);
            this.radC.Name = "radC";
            this.radC.Size = new System.Drawing.Size(32, 17);
            this.radC.TabIndex = 64;
            this.radC.TabStop = true;
            this.radC.Tag = "C";
            this.radC.Text = "C";
            this.radC.UseVisualStyleBackColor = true;
            // 
            // radB
            // 
            this.radB.AutoSize = true;
            this.radB.Location = new System.Drawing.Point(101, 89);
            this.radB.Name = "radB";
            this.radB.Size = new System.Drawing.Size(32, 17);
            this.radB.TabIndex = 63;
            this.radB.TabStop = true;
            this.radB.Tag = "B";
            this.radB.Text = "B";
            this.radB.UseVisualStyleBackColor = true;
            // 
            // radA
            // 
            this.radA.AutoSize = true;
            this.radA.Location = new System.Drawing.Point(67, 88);
            this.radA.Name = "radA";
            this.radA.Size = new System.Drawing.Size(32, 17);
            this.radA.TabIndex = 62;
            this.radA.TabStop = true;
            this.radA.Tag = "A";
            this.radA.Text = "A";
            this.radA.UseVisualStyleBackColor = true;
            // 
            // btnShowPassengers
            // 
            this.btnShowPassengers.Location = new System.Drawing.Point(57, 205);
            this.btnShowPassengers.Name = "btnShowPassengers";
            this.btnShowPassengers.Size = new System.Drawing.Size(105, 23);
            this.btnShowPassengers.TabIndex = 61;
            this.btnShowPassengers.Text = "Show Passengers";
            this.btnShowPassengers.UseVisualStyleBackColor = true;
            this.btnShowPassengers.Click += new System.EventHandler(this.btnShowPassengers_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.Location = new System.Drawing.Point(191, 33);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(137, 277);
            this.lstOutput.TabIndex = 60;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(199, 16);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(119, 13);
            this.Label4.TabIndex = 59;
            this.Label4.Text = "(1A, 1B, 1C, 1D, ...10D)";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(57, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 54;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(57, 287);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(105, 23);
            this.btnQuit.TabIndex = 58;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(57, 163);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 23);
            this.btnAdd.TabIndex = 57;
            this.btnAdd.Text = "Add Passenger";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(18, 53);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(32, 13);
            this.Label2.TabIndex = 56;
            this.Label2.Text = "Seat:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(38, 13);
            this.Label1.TabIndex = 55;
            this.Label1.Text = "Name:";
            // 
            // grpSeatColumn
            // 
            this.grpSeatColumn.Location = new System.Drawing.Point(57, 76);
            this.grpSeatColumn.Name = "grpSeatColumn";
            this.grpSeatColumn.Size = new System.Drawing.Size(78, 66);
            this.grpSeatColumn.TabIndex = 68;
            this.grpSeatColumn.TabStop = false;
            // 
            // frmReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 338);
            this.Controls.Add(this.btnSearchPassenger);
            this.Controls.Add(this.cmbSeatRow);
            this.Controls.Add(this.radD);
            this.Controls.Add(this.radC);
            this.Controls.Add(this.radB);
            this.Controls.Add(this.radA);
            this.Controls.Add(this.btnShowPassengers);
            this.Controls.Add(this.lstOutput);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.grpSeatColumn);
            this.Name = "frmReservations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Airline";
            this.Load += new System.EventHandler(this.frmReservations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchPassenger;
        private System.Windows.Forms.ComboBox cmbSeatRow;
        private System.Windows.Forms.RadioButton radD;
        private System.Windows.Forms.RadioButton radC;
        private System.Windows.Forms.RadioButton radB;
        private System.Windows.Forms.RadioButton radA;
        internal System.Windows.Forms.Button btnShowPassengers;
        internal System.Windows.Forms.ListBox lstOutput;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Button btnQuit;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox grpSeatColumn;
    }
}

