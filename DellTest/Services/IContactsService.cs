using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DellTest.Models;
using Refit;

namespace DellTest.Services
{
    public interface IContactsService
    {
        [Get("api/contacts")]
        Task<IEnumerable<Contact>> GetContacts();

        [Get("api/contacts/{contactName}")]
        Task<Contact> GetContact(string contactName);

        [Get("api/contacts/{contactId}")]
        Task<Contact> GetContact(int contactId);

        [Post("api/contacts/{contact}")]
        Task<Contact> AddNewContact(Contact contact);
        [Post("api/contacts/edit/{contact}")]
        Task<Contact> EditContact(Contact contact);
    }
}
