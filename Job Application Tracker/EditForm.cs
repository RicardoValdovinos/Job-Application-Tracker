using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Job_Application_Tracker
{
    public partial class EditForm : Form
    {
        private string user;
        private string dbfileName;
        private string dbfile;
        public Job job;

        public EditForm(Job job)
        {
            this.job = job;
            InitializeComponent();
            InitializeDBFile();
            InitializeFields();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string updateTitle = $"title = '{jobTitleTextBox.Text}'";
            string updateCompanyName = $"company_name = '{companyNameTextBox.Text}'";
            string updateDate = $"date = '{jobDateTimePicker.Value}'";
            string updateStatus = $"status = '{job.Status}'";
            string condition = $"id = '{job.Id}'";
            string sql = $"UPDATE jobs SET {updateTitle}, {updateCompanyName}, {updateDate}, {updateStatus} WHERE {condition}";
            var dbConnection = new SQLiteConnection("Data Source=" + dbfile + ";Version=3;");
            dbConnection.Open();
            
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
            job.CompanyName = companyNameTextBox.Text;
            job.Title = jobTitleTextBox.Text;
            job.Date = jobDateTimePicker.Value;
            job.Status = GetStatusFromCheckBoxes();
            DialogResult = DialogResult.OK;
            Hide();
        }

        private Status GetStatusFromCheckBoxes()
        {
            Status status = Status.Applied;

            var checkboxList = new List<CheckBox>() { appliedCheckBox, interviewingCheckBox, offeredCheckBox, rejectedCheckBox, acceptedCheckBox };

            foreach (var checkbox in checkboxList)
            {
                if (checkbox.Checked)
                {
                    status = Job.GetStatusFromString(checkbox.Text);
                    break;
                }
            }

            return status;
        }

        private void InitializeDBFile()
        {
            user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            dbfileName = "Jobs.sqlite";
            dbfile = user + "\\" + dbfileName;
        }

        private void InitializeFields()
        {
            jobTitleTextBox.Text = job.Title;
            companyNameTextBox.Text = job.CompanyName;
            jobDateTimePicker.Value = job.Date;
            CheckBoxesFromStatus(job.Status);

        }

        private void CheckBoxesFromStatus(Status status)
        {
            switch (status)
            {
                case Status.Applied:
                    appliedCheckBox.Checked = true;
                    break;
                case Status.Interviewing:
                    interviewingCheckBox.Checked = true;
                    break;
                case Status.Offered:
                    offeredCheckBox.Checked = true;
                    break;
                case Status.Rejected:
                    rejectedCheckBox.Checked = true;
                    break;
                case Status.Accepted:
                    acceptedCheckBox.Checked = true;
                    break;
            }
        }

    }
}
