
namespace Job_Application_Tracker
{
    partial class EditForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.jobDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.acceptedCheckBox = new System.Windows.Forms.CheckBox();
            this.rejectedCheckBox = new System.Windows.Forms.CheckBox();
            this.offeredCheckBox = new System.Windows.Forms.CheckBox();
            this.interviewingCheckBox = new System.Windows.Forms.CheckBox();
            this.appliedCheckBox = new System.Windows.Forms.CheckBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.companyNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.jobTitleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Date Applied";
            // 
            // jobDateTimePicker
            // 
            this.jobDateTimePicker.Location = new System.Drawing.Point(98, 227);
            this.jobDateTimePicker.Name = "jobDateTimePicker";
            this.jobDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.jobDateTimePicker.TabIndex = 27;
            // 
            // acceptedCheckBox
            // 
            this.acceptedCheckBox.AutoSize = true;
            this.acceptedCheckBox.Location = new System.Drawing.Point(523, 296);
            this.acceptedCheckBox.Name = "acceptedCheckBox";
            this.acceptedCheckBox.Size = new System.Drawing.Size(76, 19);
            this.acceptedCheckBox.TabIndex = 26;
            this.acceptedCheckBox.Text = "Accepted";
            this.acceptedCheckBox.UseVisualStyleBackColor = true;
            // 
            // rejectedCheckBox
            // 
            this.rejectedCheckBox.AutoSize = true;
            this.rejectedCheckBox.Location = new System.Drawing.Point(446, 296);
            this.rejectedCheckBox.Name = "rejectedCheckBox";
            this.rejectedCheckBox.Size = new System.Drawing.Size(71, 19);
            this.rejectedCheckBox.TabIndex = 25;
            this.rejectedCheckBox.Text = "Rejected";
            this.rejectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // offeredCheckBox
            // 
            this.offeredCheckBox.AutoSize = true;
            this.offeredCheckBox.Location = new System.Drawing.Point(374, 296);
            this.offeredCheckBox.Name = "offeredCheckBox";
            this.offeredCheckBox.Size = new System.Drawing.Size(66, 19);
            this.offeredCheckBox.TabIndex = 24;
            this.offeredCheckBox.Text = "Offered";
            this.offeredCheckBox.UseVisualStyleBackColor = true;
            // 
            // interviewingCheckBox
            // 
            this.interviewingCheckBox.AutoSize = true;
            this.interviewingCheckBox.Location = new System.Drawing.Point(277, 296);
            this.interviewingCheckBox.Name = "interviewingCheckBox";
            this.interviewingCheckBox.Size = new System.Drawing.Size(91, 19);
            this.interviewingCheckBox.TabIndex = 23;
            this.interviewingCheckBox.Text = "Interviewing";
            this.interviewingCheckBox.UseVisualStyleBackColor = true;
            // 
            // appliedCheckBox
            // 
            this.appliedCheckBox.AutoSize = true;
            this.appliedCheckBox.Location = new System.Drawing.Point(204, 296);
            this.appliedCheckBox.Name = "appliedCheckBox";
            this.appliedCheckBox.Size = new System.Drawing.Size(67, 19);
            this.appliedCheckBox.TabIndex = 22;
            this.appliedCheckBox.Text = "Applied";
            this.appliedCheckBox.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(627, 396);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 21;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.Location = new System.Drawing.Point(98, 73);
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new System.Drawing.Size(604, 23);
            this.companyNameTextBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Company Name";
            // 
            // jobTitleTextBox
            // 
            this.jobTitleTextBox.Location = new System.Drawing.Point(98, 150);
            this.jobTitleTextBox.Name = "jobTitleTextBox";
            this.jobTitleTextBox.Size = new System.Drawing.Size(604, 23);
            this.jobTitleTextBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Job Title";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(98, 395);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 29;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.jobDateTimePicker);
            this.Controls.Add(this.acceptedCheckBox);
            this.Controls.Add(this.rejectedCheckBox);
            this.Controls.Add(this.offeredCheckBox);
            this.Controls.Add(this.interviewingCheckBox);
            this.Controls.Add(this.appliedCheckBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.companyNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.jobTitleTextBox);
            this.Controls.Add(this.label1);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker jobDateTimePicker;
        private System.Windows.Forms.CheckBox acceptedCheckBox;
        private System.Windows.Forms.CheckBox rejectedCheckBox;
        private System.Windows.Forms.CheckBox offeredCheckBox;
        private System.Windows.Forms.CheckBox interviewingCheckBox;
        private System.Windows.Forms.CheckBox appliedCheckBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox companyNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jobTitleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteButton;
    }
}