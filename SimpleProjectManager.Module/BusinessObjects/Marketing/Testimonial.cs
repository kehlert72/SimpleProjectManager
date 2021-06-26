using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleProjectManager.Module.BusinessObjects.Marketing {
    [NavigationItem("Marketing")]
    public class Testimonial : INotifyPropertyChanged {
        public Testimonial() {
            createdOn = DateTime.Now;
        }

        int id;
        [Browsable(false)]
        public int Id {
            get { return id; }
            protected set { SetProperty(ref id, value); }
        }

        string quote;
        [FieldSize(FieldSizeAttribute.Unlimited)]
        public string Quote {
            get { return quote; }
            set { SetProperty(ref quote, value); }
        }

        string highlight;
        [FieldSize(512)]
        public string Highlight {
            get { return highlight; }
            set { SetProperty(ref highlight, value); }
        }
        
        DateTime createdOn;
        [VisibleInListView(false)]
        public DateTime CreatedOn {
            get { return createdOn; }
            internal set { SetProperty(ref createdOn, value); }
        }
        
        string tags;
        public string Tags {
            get { return tags; }
            set { SetProperty(ref tags, value); }
        }
        
        Customer customer;
        public virtual Customer Customer {
            get { return customer; }
            internal set { SetProperty(ref customer, value); }
        }
        
        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
            if (!EqualityComparer<T>.Default.Equals(field, value)) {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
        
        #region INotifyPropertyChanged members
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}