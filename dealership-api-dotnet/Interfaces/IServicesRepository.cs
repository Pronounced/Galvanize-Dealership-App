using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace dealership_api_dotnet.Interfaces
{
    public interface IServicesRepository<T>
    {
        IEnumerable<T> Get();
        T Post(T t);
        void Put(T t);
        void Delete(T t);
    }
}