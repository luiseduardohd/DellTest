using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using DellTest.Models;
using DellTest.Services;
using DellTest.Views;
using Xamarin.Forms;

namespace DellTest.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        IContactsService ContactsService { get; set; }

        private Contact _selectedContact;
        ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>()
        {
            //new Contact()
            //{
            //    Name="nameTest",
            //    Company="CompanyTest",
            //},new Contact()
            //{
            //    Name="nameTest",
            //    Company="CompanyTest",
            //},new Contact()
            //{
            //    Name="nameTest",
            //    Company="CompanyTest",
            //},
        };
        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                //_contacts = value;
                SetProperty(ref _contacts, value, nameof(Contacts));
            }
        }

        public ICommand AddCommand { get; set; }

        public Command<Contact> SelectedCommand { get; }

        public ContactsViewModel()
        {
            ContactsService = new ContactServiceMock();

            AddCommand = new Command(
                async () =>
                {
                    //await UserDialogs.Instance.AlertAsync("Add command");
                    await Shell.Current.GoToAsync($"{nameof(ContactDetailPage)}?{nameof(ContactDetailViewModel.IsNew)}={true}");
                }
            );

            SelectedCommand = new Command<Contact>( async (contact)=> {
                //await UserDialogs.Instance.AlertAsync("Selected command");
                await Shell.Current.GoToAsync($"{nameof(ContactDetailPage)}?{nameof(ContactDetailViewModel.IsNew)}={false}&{nameof(ContactDetailViewModel.ContactId)}={contact.Id}");
            } );

        }

        public async Task InitializeAsync()
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                var iEnumerableContacts = await ContactsService.GetContacts();

                _contacts.Clear();
                //_contacts = new ObservableCollection<Contact>(iEnumerableContacts);
                foreach (var item in iEnumerableContacts)
                    _contacts.Add(item);
            }
        }

    }
}