using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Job_Application_Tracker
{
    public partial class JobApplicationTrackerForm : Form
    {
        private string user;
        private string dbfileName;
        private string dbfile;
        public JobApplicationTrackerForm()
        {
            InitializeComponent();
            InitializeDBFile();
            InitializeSQLiteDB();
            InitializeJobListViewColumns();
            jobListView.View = View.Details;
        }

        private void InitializeDBFile()
        {
            user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            dbfileName = "Jobs.sqlite";
            dbfile = user + "\\" + dbfileName;
        }

        private void InitializeSQLiteDB()
        {

            if (!File.Exists(dbfile))
            {
                SQLiteConnection.CreateFile(dbfile);
                var dbConnection = new SQLiteConnection("Data Source=" + dbfile + ";Version=3;");
                dbConnection.Open();

                string createTable = "CREATE TABLE jobs (id INTEGER PRIMARY KEY, company_name TEXT, title TEXT, date TEXT, status TEXT)";
                SQLiteCommand command = new SQLiteCommand(createTable, dbConnection);
                command.ExecuteNonQuery();

                dbConnection.Close();
            }
            else
            {
                LoadJobsFromDB();
            }
        }

        private void InitializeJobListViewColumns()
        {
            jobListView.Columns.Add("Company Name", 187, HorizontalAlignment.Left);
            jobListView.Columns.Add("Job Title", 187, HorizontalAlignment.Left);
            jobListView.Columns.Add("Date Applied", 187, HorizontalAlignment.Left);
            jobListView.Columns.Add("Status", 187, HorizontalAlignment.Left);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            JobForm jobForm = new JobForm();
            if (jobForm.ShowDialog() == DialogResult.OK)
            {
                Job job = new Job(jobForm.JobTitle, jobForm.CompanyName, jobForm.JobDate, jobForm.Status);
                AddJobToListView(job);
                InsertJobIntoDB(job);

                //jobListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                //jobListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void jobListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddJobToListView(Job job)
        {
            var listViewItem = new ListViewItem(job.CompanyName);
            listViewItem.SubItems.Add(job.Title);
            listViewItem.SubItems.Add(job.Date.ToString());
            listViewItem.SubItems.Add(job.Status.ToString());
            listViewItem.SubItems.Add(job.Id.ToString());
            jobListView.Items.Add(listViewItem);
        }



        private void InsertJobIntoDB(Job job)
        {
            var dbConnection = new SQLiteConnection("Data Source=" + dbfile + ";Version=3;");
            dbConnection.Open();

            var insert = $"INSERT INTO jobs (company_name, title, date, status) VALUES ('{job.CompanyName}', '{job.Title}', '{job.Date}', '{job.Status}')";
            SQLiteCommand command = new SQLiteCommand(insert, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        private void LoadJobsFromDB()
        {
            string sql = "SELECT * FROM jobs";
            var dbConnection = new SQLiteConnection("Data Source=" + dbfile + ";Version=3;");
            dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int64 rowId = Convert.ToInt64(reader["id"]);
                string companyName = (string)reader["company_name"];
                string title = (string)reader["title"];
                DateTime date = Convert.ToDateTime((string)reader["date"]);
                Status status = Job.GetStatusFromString((string)reader["status"]);
                var job = new Job(companyName, title, date, status);
                job.Id = rowId;
                AddJobToListView(job);
            }
            dbConnection.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (jobListView.SelectedItems.Count == 1)
            {
                string companyName = jobListView.SelectedItems[0].SubItems[0].Text;
                string title = jobListView.SelectedItems[0].SubItems[1].Text;
                DateTime date = Convert.ToDateTime(jobListView.SelectedItems[0].SubItems[2].Text);
                Status status = Job.GetStatusFromString(jobListView.SelectedItems[0].SubItems[3].Text);
                Int64 rowid = Convert.ToInt64(jobListView.SelectedItems[0].SubItems[4].Text);
                Job job = new Job(companyName, title, date, status);
                job.Id = rowid;
                EditForm editForm = new EditForm(job);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    if (editForm.job == null)
                    {
                        jobListView.SelectedItems[0].Remove();
                        jobListView.Refresh();
                    }
                    else
                    {
                        jobListView.SelectedItems[0].SubItems[0].Text = editForm.job.CompanyName;
                        jobListView.SelectedItems[0].SubItems[1].Text = editForm.job.Title;
                        jobListView.SelectedItems[0].SubItems[2].Text = editForm.job.Date.ToString();
                        jobListView.SelectedItems[0].SubItems[3].Text = editForm.job.Status.ToString();
                    }
                }
            }
        }
    }
}
