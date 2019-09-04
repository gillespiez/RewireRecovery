using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using RewireRecovery.Models;
using RewireRecovery.Services;
using RewireRecovery.Views;
using Xamarin.Forms;

namespace RewireRecovery.ViewModels
{
    class TriggerListViewModel : BaseTriggerViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllTriggersCommand { get; private set; }

        public TriggerListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _triggerRepository = new TriggerRepository();

            AddCommand = new Command(async () => await ShowAddTrigger());
            DeleteAllTriggersCommand = new Command(async () => await DeleteAllTriggers());

            FetchTriggers();
        }

        void FetchTriggers()
        {
            TriggerList = _triggerRepository.GetAllTriggersData();
        }

        async Task ShowAddTrigger()
        {
            await _navigation.PushAsync(new AddTrigger());
        }

        async Task DeleteAllTriggers()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Trigger List", "Delete All Triggers?", "OK", "Cancel");
            if (isUserAccept)
            {
                _triggerRepository.DeleteAllTriggers();
                await _navigation.PushAsync(new AddTrigger());
            }
        }

        async void ShowTriggerDetails(int selectedTriggerID)
        {
            await _navigation.PushAsync(new DetailsPage(selectedTriggerID));
        }

        Triggers _selectedTriggerItem;
        public Triggers SelectedTriggerItem
        {
            get => _selectedTriggerItem;
            set
            {
                if (value != null)
                {
                    _selectedTriggerItem = value;
                    //NotifyPropertyChanged("SelectedTriggerItem");
                    ShowTriggerDetails(value.Id);
                }
            }
        }

        public List<Triggers> TriggerList { get; private set; }
    }
}
