using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RewireRecovery.ViewModels;
using RewireRecovery.Helpers;
using RewireRecovery.Models;

namespace RewireRecovery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TriggerList : ContentPage
    {
        public TriggerList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new TriggerListViewModel(Navigation);
        }
    }
}