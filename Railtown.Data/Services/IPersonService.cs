using Railtown.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railtown.Data.Services
{
    public interface IPersonService
    {
        Task<PersonsFurthestApart> GetPersonsFurthestApartAsync();
    }
}