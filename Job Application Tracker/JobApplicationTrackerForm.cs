using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Job_Application_Tracker
{
    public partial class JobApplicationTrackerForm : Form
    {
        public JobApplicationTrackerForm()
        {
            InitializeComponent();
            jobListView.Columns.Add("Company Name", 187, HorizontalAlignment.Left);
            jobListView.Columns.Add("Job Title", 187, HorizontalAlignment.Left);
            jobListView.Columns.Add("Date Applied", 187, HorizontalAlignment.Left);
            jobListView.Columns.Add("Status", 187, HorizontalAlignment.Left);
            jobListView.View = View.Details;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            JobForm jobForm = new JobForm();
            if (jobForm.ShowDialog() == DialogResult.OK)
            {
                Job job = new Job(jobForm.JobTitle, jobForm.CompanyName, jobForm.JobDate, jobForm.Status);
                var listViewItem = new ListViewItem(job.CompanyName);
                listViewItem.SubItems.Add(job.Title);
                listViewItem.SubItems.Add(job.Date.ToString());
                listViewItem.SubItems.Add(job.Status.ToString());
                jobListView.Items.Add(listViewItem);
                //jobListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                //jobListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void jobListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
