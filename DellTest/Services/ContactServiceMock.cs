using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellTest.Models;

namespace DellTest.Services
{
    public class ContactServiceMock : IContactsService
    {
        private static List<Contact> Contacts
        {
            get;
            set;
        }

        public ContactServiceMock()
        {
            Contacts = new List<Contact>() {
                new Contact()
                {
                    Id=1,
                    Name="nameTest1",
                    Company="CompanyTest",
                }, new Contact()
                {
                    Id=2,
                    Name="nameTest2",
                    Company="CompanyTest",
                }, new Contact()
                {
                    Id=3,
                    Name="nameTest3",
                    Company="CompanyTest",
                },
            };
        }

        public async Task<Contact> AddNewContact(Contact contact)
        {
            await Task.Delay(1000);
            contact.Id = Contacts.Max((c) => c.Id) + 1;
            Contacts.Add(contact);
            return contact;
        }

        public async Task<Contact> EditContact(Contact contact)
        {
            await Task.Delay(1000);
            //contact.Id = Contacts.Max((c) => c.Id) + 1;
            var oldContact = await GetContact(contact.Id);
            Contacts.RemoveAll( (c) => c.Id == contact.Id);
            Contacts.Add(contact);
            return contact;
        }

        public async Task<Contact> GetContact(int contactId)
        {
            await Task.Delay(1000);
            var contact = Contacts.Where((c) => c.Id == contactId).FirstOrDefault();
            return contact;
        }

        public async Task<Contact> GetContact(string contactName)
        {
            await Task.Delay(1000);
            var contact = Contacts.Where((c) => c.Name == contactName).FirstOrDefault();
            return contact;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            await Task.Delay(1000);
            return Contacts.OrderBy((c)=>c.Id).AsEnumerable();
        }
    }
}
