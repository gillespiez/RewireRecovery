using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using RewireRecovery.Helpers;
using RewireRecovery.Models;
using RewireRecovery.Services;
using RewireRecovery.Validator;

using Xamarin.Forms;
using RewireRecovery.Views;

namespace RewireRecovery.ViewModels
{
    class AddTrigerViewModel :BaseTriggerViewModel
    {
        public ICommand AddTriggerCommand { get; private set; }
        public ICommand ViewAllTriggersCommand { get; private set; }
        public AddTrigerViewModel(INavigation navigation)
        {
            _navigation = navigation;
            //_contactValidator = new TriggerValidator();
            _trigger = new Triggers(); 
            _triggerRepository = new TriggerRepository();

            AddTriggerCommand = new Command(async () => await AddTrigger());
            ViewAllTriggersCommand = new Command(async () => await ShowTriggerList());
        }

        async Task AddTrigger()
        {
            var validationResults = _contactValidator.Validate(_trigger);

            if (validationResults.IsValid)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Add Trigger", "Do you want to save the Trigger?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _triggerRepository.InsertTrigger(_trigger);
                    await _navigation.PushAsync(new TriggerList());
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Add Trigger", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }

        async Task ShowTriggerList()
        {
            await _navigation.PushAsync(new TriggerList());
        }

        public bool IsViewAll => _triggerRepository.GetAllTriggersData().Count > 0 ? true : false;
    }
}

