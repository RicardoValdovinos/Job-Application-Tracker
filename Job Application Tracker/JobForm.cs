using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Job_Application_Tracker
{
    public partial class JobForm : Form
    {
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public DateTime JobDate { get; set; }
        public Status Status { get; set; }

        public JobForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            JobTitle = jobTitleTextBox.Text;
            CompanyName = companyNameTextBox.Text;
            Status = GetStatusFromRadioButtons();
            DialogResult = DialogResult.OK;
            Hide();
        }

        private Status GetStatusFromRadioButtons()
        {
            Status status = Status.Applied;

            var checkboxList = new List<CheckBox>() { appliedCheckBox, interviewingCheckBox, offeredCheckBox, rejectedCheckBox, acceptedCheckBox };

            foreach (var checkbox in checkboxList)
            {
                if (checkbox.Checked)
                {
                    if (checkbox.Text.Contains("Applied"))
                    {
                        status = Status.Applied;
                    }
                    else if (checkbox.Text.Contains("Interviewing"))
                    {
                        status = Status.Interviewing;
                    }
                    else if (checkbox.Text.Contains("Offered"))
                    {
                        status = Status.Offered;
                    }
                    else if (checkbox.Text.Contains("Rejected"))
                    {
                        status = Status.Rejected;
                    }
                    else
                    {
                        status = Status.Accepted;
                    }
                    break;
                }
            }

            return status;
        }

        private void appliedCheckBox_Clicked(object sender, EventArgs e)
        {
            appliedCheckBox.Checked = true;
            interviewingCheckBox.Checked = false;
            offeredCheckBox.Checked = false;
            rejectedCheckBox.Checked = false;
            acceptedCheckBox.Checked = false;
        }

        private void interviewingCheckBox_Clicked(object sender, EventArgs e)
        {
            appliedCheckBox.Checked = false;
            interviewingCheckBox.Checked = true;
            offeredCheckBox.Checked = false;
            rejectedCheckBox.Checked = false;
            acceptedCheckBox.Checked = false;
        }

        private void offeredCheckBox_Clicked(object sender, EventArgs e)
        {
            appliedCheckBox.Checked = false;
            interviewingCheckBox.Checked = false;
            offeredCheckBox.Checked = true;
            rejectedCheckBox.Checked = false;
            acceptedCheckBox.Checked = false;
        }

        private void rejectedCheckBox_Clicked(object sender, EventArgs e)
        {
            appliedCheckBox.Checked = false;
            interviewingCheckBox.Checked = false;
            offeredCheckBox.Checked = false;
            rejectedCheckBox.Checked = true;
            acceptedCheckBox.Checked = false;
        }

        private void acceptedCheckBox_Clicked(object sender, EventArgs e)
        {
            appliedCheckBox.Checked = false;
            interviewingCheckBox.Checked = false;
            offeredCheckBox.Checked = false;
            rejectedCheckBox.Checked = false;
            acceptedCheckBox.Checked = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            JobDate = jobDateTimePicker.Value;
        }
    }
}
