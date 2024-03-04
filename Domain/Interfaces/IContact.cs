using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IContact
    {
        IQueryable<Contact> ENQ(Expression<System.Func<Contact, bool>> whereCondition);
        ValueTask<Contact> ADD(Contact contact);
        ValueTask<IEnumerable<Contact>> GetAll();
        ValueTask<IEnumerable<Contact>> GetAll(Expression<Func<Contact, bool>> whereCondition);
        ValueTask<bool> SaveAll();

        ValueTask<Contact?> GetContact(int concod);
        void UPDContact(Contact contact);

        void DELContact(int ConCod);
    }
}
