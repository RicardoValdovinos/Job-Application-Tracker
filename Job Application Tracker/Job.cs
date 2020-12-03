using System;
using System.Collections.Generic;
using System.Text;

namespace Job_Application_Tracker
{
    class Job
    {
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }


        public Job(string title, string companyName, DateTime date, Status status)
        {
            Title = title;
            CompanyName = companyName;
            Date = date;
            Status = status;
        }

        public static Status GetStatusFromString(string StatusString)
        {
            Status status = Status.Applied;
            if (StatusString.Contains("Applied"))
            {
                status = Status.Applied;
            }
            else if (StatusString.Contains("Interviewing"))
            {
                status = Status.Interviewing;
            }
            else if (StatusString.Contains("Offered"))
            {
                status = Status.Offered;
            }
            else if (StatusString.Contains("Rejected"))
            {
                status = Status.Rejected;
            }
            else
            {
                status = Status.Accepted;
            }
            return status;
        }
    }

    public enum Status
    {
        Applied, Interviewing, Offered, Rejected, Accepted 
    }
}
