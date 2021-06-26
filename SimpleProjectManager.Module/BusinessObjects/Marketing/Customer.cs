﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace SimpleProjectManager.Module.BusinessObjects.Marketing {
    [NavigationItem("Marketing")]
    public class Customer : INotifyPropertyChanged {
        public Customer() {
            testimonials = new List<Testimonial>();
        }
        int id;
        [Browsable(false)]
        public int Id {
            get { return id; }
            protected set { SetProperty(ref id, value); }
        }
        string firstName;
        public string FirstName {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }
        string lastName;
        public string LastName {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }
        string email;
        public string Email {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        string company;
        public string Company {
            get { return company; }
            set { SetProperty(ref company, value); }
        }
        string occupation;
        public string Occupation {
            get { return occupation; }
            set { SetProperty(ref occupation, value); }
        }
        List<Testimonial> testimonials;
        [Aggregated]
        public virtual List<Testimonial> Testimonials {
            get { return testimonials; }
            set { SetProperty(ref testimonials, value); }
        }
        [NotMapped]
        public string FullName {
            get {
                string namePart = string.Format("{0} {1}", FirstName, LastName);
                return Company != null ? string.Format("{0} ({1})", namePart, Company) : namePart;
            }
        }
        byte[] photo;
        [ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
        public byte[] Photo {
            get { return photo; }
            set { SetProperty(ref photo, value); }
        }
        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
            if (!EqualityComparer<T>.Default.Equals(field, value)) {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
        #region the INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    // ...
}