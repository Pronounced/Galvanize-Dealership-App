using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dealership_api_dotnet.Interfaces
{
    public interface IServicesRepository<T>
    {
        IEnumerable<T> Get();
        Task Post(T t);
        Task Put(T t);
        Task Delete(T t);
    }
}