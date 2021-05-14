using System;
using System.Collections.Generic;
using DellTest.ViewModels;
using Xamarin.Forms;

namespace DellTest.Views
{
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage()
        {
            InitializeComponent();
            this.BindingContext = new ContactDetailViewModel();
        }

        protected override async void OnAppearing()
        {
            var contacts = this.BindingContext as ContactDetailViewModel;
            await contacts.InitializeAsync();
        }
    }
}
