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

                string createTable = "CREATE TABLE jobs (company_name TEXT, title TEXT, date TEXT, status TEXT)";
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

        private void submitButton_Click(object sender, EventArgs e)
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

        private void AddJobToListView(Job job)
        {
            var listViewItem = new ListViewItem(job.CompanyName);
            listViewItem.SubItems.Add(job.Title);
            listViewItem.SubItems.Add(job.Date.ToString());
            listViewItem.SubItems.Add(job.Status.ToString());
            jobListView.Items.Add(listViewItem);
        }



        private void InsertJobIntoDB(Job job)
        {
            var dbConnection = new SQLiteConnection("Data Source=" + dbfile + ";Version=3;");
            dbConnection.Open();

            var insert = $"INSERT INTO jobs (company_name, title, date, status) VALUES ({job.CompanyName}, {job.Title}, {job.Date}, {job.Status.ToString()});";
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
                string title = (string)reader["title"];
                string companyName = (string)reader["company_name"];
                DateTime date = Convert.ToDateTime((string)reader["date"]);
                Status status = Job.GetStatusFromString((string)reader["status"]);
                var job = new Job(title, companyName, date, status);
                AddJobToListView(job);
            }
            dbConnection.Close();
        }

        private void jobListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
