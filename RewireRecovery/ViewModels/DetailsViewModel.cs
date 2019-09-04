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
namespace RewireRecovery.ViewModels
{
    class DetailsViewModel : BaseTriggerViewModel
    {
        public ICommand UpdateTriggerCommand { get; private set; }
        public ICommand DeleteTriggerCommand { get; private set; }

        public DetailsViewModel(INavigation navigation, int selectedTriggerID)
        {
            _navigation = navigation;
            //_contactValidator = new TriggerValidator();
            _trigger = new Triggers();
            _trigger.Id = selectedTriggerID;
            _triggerRepository = new TriggerRepository();

            UpdateTriggerCommand = new Command(async () => await UpdateTrigger());
            DeleteTriggerCommand = new Command(async () => await DeleteTrigger());

            FetchTriggerDetails();
        }

        void FetchTriggerDetails()
        {
            _trigger = _triggerRepository.GetTriggersData(_trigger.Id);
        }

        async Task UpdateTrigger()
        {
            var validationResults = _contactValidator.Validate(_trigger);

            if (validationResults.IsValid)
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Trigger Details", "Update Trigger Details", "OK", "Cancel");
                if (isUserAccept)
                {
                    _triggerRepository.UpdateTrigger(_trigger);
                    await _navigation.PopAsync();
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Add Trigger", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }

        async Task DeleteTrigger()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Trigger Details", "Delete Trigger", "OK", "Cancel");
            if (isUserAccept)
            {
                _triggerRepository.DeleteTrigger(_trigger.Id);
                await _navigation.PopAsync();
            }
        }
    }
}
