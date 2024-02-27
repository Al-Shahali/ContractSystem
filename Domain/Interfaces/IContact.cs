using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IContact
    {
        ValueTask<Contact> ADD(Contact contact);
        ValueTask<IEnumerable<Contact>> GetAll();
        ValueTask<bool> SaveAll();

    }
}
