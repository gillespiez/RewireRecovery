using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using RewireRecovery.Helpers;
using RewireRecovery.Models;
using RewireRecovery.Services;
using RewireRecovery.Validator;
using RewireRecovery.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
// using SQLite.Net;

//referenced https://github.com/supunsarachitha/SimpleStopWatch for stopwatch
// https://code.tutsplus.com/tutorials/an-introduction-to-xamarinforms-and-sqlite--cms-23020 for storage
// http://bsubramanyamraju.blogspot.com/2018/03/xamarinforms-mvvm-sqlite-sample-for.html for storage

namespace RewireRecovery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class HomePage1 : TabbedPage
    {
        public ICommand AddTriggerCommand { get; private set; }
        public ICommand ViewAllTriggersCommand { get; private set; }

        Stopwatch stopwatch;
        public HomePage1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            stopwatch.Reset();


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("tel://0738344757"));
        }
        private void Start_Button_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    lblstopwatch.Text = stopwatch.Elapsed.ToString());
                    if (!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }
        }
        private void Stop_Button_Clicked(object sender, EventArgs e)
        {
            stopwatch.Reset();
        }
        //Triggers
        private void Trigger_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.TriggerList());
        }
    }
}