# Job Application Tracker

## Description

While applying for jobs I came to realize that having a tool to monitor the progress of my applications might be something useful to have. 
I could have just used some kind of spreadsheet software like Excel or Google Sheets but where's the fun in that?

The UI is quite simple and gives you the option to add jobs and edit them (after making a selction). To delete a job, you simply select a job, click edit, and then delete.

In order to store your jobs a SQLite database file will be created on initial run and saved to your User directory. On subsequent startups the file will be read from and
your jobs will be repopulated in the job list view.

As time goes on I will be adding more features as necessary.
