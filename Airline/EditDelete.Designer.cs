namespace Airline
{
    partial class EditDelete
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtSeatID = new System.Windows.Forms.TextBox();
            this.cmbColumn = new System.Windows.Forms.ComboBox();
            this.cmbRow = new System.Windows.Forms.ComboBox();
            this.chbWaiting = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassengerID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Seat ID";
            // 
            // txtSeatID
            // 
            this.txtSeatID.Location = new System.Drawing.Point(122, 79);
            this.txtSeatID.Name = "txtSeatID";
            this.txtSeatID.ReadOnly = true;
            this.txtSeatID.Size = new System.Drawing.Size(121, 20);
            this.txtSeatID.TabIndex = 40;
            // 
            // cmbColumn
            // 
            this.cmbColumn.FormattingEnabled = true;
            this.cmbColumn.Items.AddRange(new object[] {
            "None",
            "A",
            "B",
            "C",
            "D"});
            this.cmbColumn.Location = new System.Drawing.Point(122, 146);
            this.cmbColumn.Name = "cmbColumn";
            this.cmbColumn.Size = new System.Drawing.Size(121, 21);
            this.cmbColumn.TabIndex = 39;
            // 
            // cmbRow
            // 
            this.cmbRow.FormattingEnabled = true;
            this.cmbRow.Items.AddRange(new object[] {
            "None",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbRow.Location = new System.Drawing.Point(122, 113);
            this.cmbRow.Name = "cmbRow";
            this.cmbRow.Size = new System.Drawing.Size(121, 21);
            this.cmbRow.TabIndex = 38;
            // 
            // chbWaiting
            // 
            this.chbWaiting.AutoSize = true;
            this.chbWaiting.Location = new System.Drawing.Point(122, 179);
            this.chbWaiting.Name = "chbWaiting";
            this.chbWaiting.Size = new System.Drawing.Size(15, 14);
            this.chbWaiting.TabIndex = 37;
            this.chbWaiting.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 20);
            this.txtName.TabIndex = 36;
            // 
            // txtPassengerID
            // 
            this.txtPassengerID.Location = new System.Drawing.Point(122, 15);
            this.txtPassengerID.Name = "txtPassengerID";
            this.txtPassengerID.ReadOnly = true;
            this.txtPassengerID.Size = new System.Drawing.Size(121, 20);
            this.txtPassengerID.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "On Waiting List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Passenger ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Seat Column";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Seat Row";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Passenger Name";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(26, 209);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "Commit Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(120, 209);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // EditDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 257);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSeatID);
            this.Controls.Add(this.cmbColumn);
            this.Controls.Add(this.cmbRow);
            this.Controls.Add(this.chbWaiting);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPassengerID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Name = "EditDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit or Delete";
            this.Load += new System.EventHandler(this.EditDelete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSeatID;
        private System.Windows.Forms.ComboBox cmbColumn;
        private System.Windows.Forms.ComboBox cmbRow;
        private System.Windows.Forms.CheckBox chbWaiting;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassengerID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
    }
}