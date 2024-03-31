using Easy_Rent_API.Models.Vehicules;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Easy_Rent_API.Services.Vehicules
{
    public interface ICarTypologiesServices
    {
        public Task<bool> Add(string carTypology);
        public Task<IEnumerable> List();
        public Task<bool> Update(carTypology model);
        public Task<bool> Delete(short id);

    }
}
