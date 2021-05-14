using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using DellTest.Models;
using System.Linq;

namespace DellTest.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> Contacts = new List<Contact>();

        public ContactRepository()
        {
            Add(new Contact { Id = 1, Name = "Name 1", Company = "Company 1" });
            Add(new Contact { Id = 2, Name = "Name 2", Company = "Company 2" });
            Add(new Contact { Id = 3, Name = "Name 3", Company = "Company 3" });
        }

        public IEnumerable<Contact> GetAll()
        {
            return Contacts;
        }

        public Contact Add(Contact Contact)
        {
            Contact.Id = Contacts.Max( (contact)=> contact.Id ) + 1;
            Contacts.Add(Contact);
            return Contact;
        }

        public Contact Get(int id)
        {
            var contact = Contacts.Where( (contact)=> contact.Id == id ).FirstOrDefault();
            return contact;
        }

        public Contact Get(string name)
        {
            var contact = Contacts.Where((contact) => contact.Name == name).FirstOrDefault();
            return contact;
        }

        public void Update(Contact Contact)
        {
            Contacts[Contact.Id] = Contact;
        }

    }
}
