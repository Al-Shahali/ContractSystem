using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BLContact : IContact
    {
        private readonly IRepository<Contact> _repository;

        public BLContact(IRepository<Contact> repository) {
            _repository = repository;
        }
        public async ValueTask<IEnumerable<Contact>> GetAll()
        {
            return  await _repository.GETAsync();
        }
    }
}
