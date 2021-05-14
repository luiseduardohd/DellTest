using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DellTest.Models;
using DellTest.Repositories;

namespace DellTest.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository ContactRepository;

        public ContactController(IContactRepository ContactRepository)
        {
            this.ContactRepository = ContactRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Contact>> List()
        {
            return ContactRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Contact> GetContact(int id)
        {
            Contact Contact = ContactRepository.Get(id);

            if (Contact == null)
                return NotFound();

            return Contact;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Contact> GetContact(string name)
        {
            Contact Contact = ContactRepository.Get(name);

            if (Contact == null)
                return NotFound();

            return Contact;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Contact> Create([FromBody] Contact Contact)
        {
            ContactRepository.Add(Contact);
            return CreatedAtAction(nameof(GetContact), new { Contact.Id }, Contact);
        }
    }
}
