using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using DellTest.Models;
using DellTest.Services;
using Xamarin.Forms;

namespace DellTest.ViewModels
{
    [QueryProperty(nameof(IsNew), nameof(IsNew))]
    [QueryProperty(nameof(ContactId), nameof(ContactId))]
    public class ContactDetailViewModel : BaseViewModel
    {
        IContactsService ContactsService { get; set; }

        public ICommand SaveCommand { get; set; }

        public ContactDetailViewModel()
        {
            ContactsService = new ContactServiceMock();
            SaveCommand = new Command(
                async () => {
                    if( IsNew )
                    {
                        using (UserDialogs.Instance.Loading("Loading"))
                        {
                            await ContactsService.AddNewContact(new Contact() { Name = this.Name, Company = this.Company });
                            await Shell.Current.GoToAsync("..");
                        }
                            
                    }
                    else
                    {
                        using (UserDialogs.Instance.Loading("Loading"))
                        {
                            await ContactsService.EditContact(new Contact() { Id = this.Id, Name = this.Name, Company = this.Company });
                            await Shell.Current.GoToAsync("..");
                        }                         
                    }
                        
                }
            );
        }

        public async Task<bool> InitializeAsync()
        {
            if ( IsNew )
            {
                ActionText = "Add";
            }
            else
            {
                using (UserDialogs.Instance.Loading("Loading"))
                {
                    var contact = await ContactsService.GetContact(ContactId);

                    _isNew = false;
                    Id = contact.Id;
                    Name = contact.Name;
                    Company = contact.Company;
                    ActionText = "Save";
                }
            }

            return true;
        }

        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _company;
        public string Company
        {
            get => _company;
            set => SetProperty(ref _company, value);
        }

        private string _actionText;
        public string ActionText
        {
            get => _actionText;
            set => SetProperty(ref _actionText, value);
        }

        private int _contactId;
        public int ContactId
        {
            get
            {
                return _contactId;
            }
            set
            {
                _contactId = value;
            }
        }

        private bool _isNew;
        public bool IsNew
        {
            get => _isNew;
            set => SetProperty(ref _isNew, value);
        }
    }
}
