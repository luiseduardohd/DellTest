using System;
using System.Collections.Generic;
using DellTest.ViewModels;
using DellTest.Views;
using Xamarin.Forms;

namespace DellTest
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ContactDetailPage), typeof(ContactDetailPage));
        }

    }
}
