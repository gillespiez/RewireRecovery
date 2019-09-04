using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RewireRecovery.ViewModels;

namespace RewireRecovery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(int triggerID)
        {
            InitializeComponent();
            this.BindingContext = new DetailsViewModel(Navigation, triggerID);
        }
    }
}