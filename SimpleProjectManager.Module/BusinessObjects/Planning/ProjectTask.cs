using System;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Validation;
using System.Drawing;

namespace SimpleProjectManager.Module.BusinessObjects.Planning {
    [Appearance("Completed1", TargetItems = "Subject",
    Criteria = "Status = 'Completed'", FontStyle = FontStyle.Strikeout, FontColor = "ForestGreen")]
    [Appearance("Completed2", TargetItems = "*;Status;AssignedTo",
    Criteria = "Status = 'Completed'", Enabled = false)]
    [Appearance("InProgress", TargetItems = "Subject;AssignedTo",
    Criteria = "Status = 'InProgress'", BackColor = "LemonChiffon")]
    [Appearance("Deferred", TargetItems = "Subject",
    Criteria = "Status = 'Deferred'", BackColor = "MistyRose")]
    [RuleCriteria("EndDate >= StartDate")]

    [NavigationItem("Planning")]
    public class ProjectTask : BaseObject {
        public ProjectTask(Session session) : base(session) { }
        string subject;
        [Size(255)]
        public string Subject {
            get { return subject; }
            set { SetPropertyValue(nameof(Subject), ref subject, value); }
        }
        ProjectTaskStatus status;
        public ProjectTaskStatus Status {
            get { return status; }
            set { SetPropertyValue(nameof(Status), ref status, value); }
        }
        Person assignedTo;
        public Person AssignedTo {
            get { return assignedTo; }
            set { SetPropertyValue(nameof(AssignedTo), ref assignedTo, value); }
        }
        DateTime startDate;
        public DateTime StartDate {
            get { return startDate; }
            set { SetPropertyValue(nameof(startDate), ref startDate, value); }
        }
        DateTime endDate;
        public DateTime EndDate {
            get { return endDate; }
            set { SetPropertyValue(nameof(endDate), ref endDate, value); }
        }
        string notes;
        [Size(SizeAttribute.Unlimited)]
        public string Notes {
            get { return notes; }
            set { SetPropertyValue(nameof(Notes), ref notes, value); }
        }
        Project project;
        [Association]
        public Project Project {
            get { return project; }
            set { SetPropertyValue(nameof(Project), ref project, value); }
        }
    }

}