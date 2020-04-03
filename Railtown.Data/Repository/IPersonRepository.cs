using Railtown.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railtown.Data.Repository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPersonsAsync();
    }
}