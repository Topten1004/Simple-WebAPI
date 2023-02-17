using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithDapperandSwagger.Models;
namespace WebAPIWithDapperandSwagger.Repository
{
    public interface IContactMasterRepository
    {
        Task<ContactMaster> GetByID(int id);
        Task<List<ContactMaster>> GetAll();
        Task<ContactMaster> Edit(ContactMaster contactMaster);
        Task<ContactMaster> Delete(int id);
    }
}
