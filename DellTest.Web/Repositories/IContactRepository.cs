using System;
using System.Collections.Generic;
using DellTest.Models;

namespace DellTest.Repositories
{
    public interface IContactRepository
    {
        Contact Add(Contact Contact);
        Contact Get(int id);
        Contact Get(string name);
        IEnumerable<Contact> GetAll();
    }
}
