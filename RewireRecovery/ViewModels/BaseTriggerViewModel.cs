using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FluentValidation;
using RewireRecovery.Helpers;
using RewireRecovery.Models;
using RewireRecovery.Services;
using RewireRecovery.Views;
using Xamarin.Forms;

namespace RewireRecovery.ViewModels
{
    class BaseTriggerViewModel : INotifyPropertyChanged
    {
        public Triggers _trigger;

        public INavigation _navigation;
        public IValidator _contactValidator;
        public ITriggerRepository _triggerRepository;

        public string Trigger
        {
            get => _trigger.Trigger;
            set
            {
                _trigger.Trigger = value;
                NotifyPropertyChanged("Trigger");
            }
        }

        private void NotifyPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    //List<Triggers> _triggerList;
    //public List<Triggers> TriggerList
    //{
    //    get => _triggerList;
    //    set
    //    {
    //        _triggerList = value;
    //        NotifyPropertyChanged("TriggerList");
    //    }
    //}

    //#region INotifyPropertyChanged      
    //public event PropertyChangedEventHandler PropertyChanged;
    //protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}
    //#endregion
}

