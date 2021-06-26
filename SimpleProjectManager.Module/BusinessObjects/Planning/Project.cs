using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace SimpleProjectManager.Module.BusinessObjects.Planning {

    [NavigationItem("Planning")]
    public class Project : BaseObject {
        public Project(Session session) : base(session) { }
        string name;
        public string Name {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }
        Person manager;
        public Person Manager {
            get { return manager; }
            set { SetPropertyValue(nameof(Manager), ref manager, value); }
        }
        string description;
        [Size(SizeAttribute.Unlimited)]
        public string Description {
            get { return description; }
            set { SetPropertyValue(nameof(Description), ref description, value); }
        }
        [Association, Aggregated]
        public XPCollection<ProjectTask> Tasks {
            get { return GetCollection<ProjectTask>(nameof(Tasks)); }
        }
    }

    public enum ProjectTaskStatus {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        Deferred = 3
    }

}