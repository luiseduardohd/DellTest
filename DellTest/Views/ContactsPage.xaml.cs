using System;
using System.Collections.Generic;
using DellTest.ViewModels;
using Xamarin.Forms;

namespace DellTest.Views
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
            this.BindingContext = new ContactsViewModel();
        }

        protected override async void OnAppearing()
        {
            var contacts = this.BindingContext as ContactsViewModel;
            await contacts.InitializeAsync();
        }
    }
}
