using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BLContact : IContact
    {
        private readonly IRepository<Contact> _repository;

        public BLContact(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async ValueTask<Contact> ADD(Contact contact)
        {

            return await _repository.ADDAsync(contact);
        }

        public void DELContact(int ConCod)
        {
            var contact = GetContact(ConCod).Result;
           _repository.DEL(contact!);
        }

        public  IQueryable<Contact> ENQ(Expression<Func<Contact, bool>> whereCondition)
        {
            return  _repository.ENQ(whereCondition);

        }

      

        public async ValueTask<IEnumerable<Contact>> GetAll()
        {
            return await _repository.GETAsync();
        }

        public async ValueTask<IEnumerable<Contact>> GetAll(Expression<Func<Contact, bool>> whereCondition)
        {
            return await _repository.GETAsync(whereCondition);

        }

        public async ValueTask<Contact?> GetContact(int concod)
        {
            return await _repository.SingleOrDefaultAsync(e => e.Concod == concod);
        }

        public async ValueTask<bool> SaveAll()
        {
            return await _repository.SaveAllAsync();
        }

        public void UPDContact(Contact contact)
        {
             _repository.UPD(contact);
        }
    }
}
