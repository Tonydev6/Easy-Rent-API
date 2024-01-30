using Easy_Rent_API.Models.Vehicules;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Easy_Rent_API.Services.Vehicules
{
    public interface ICarTypologiesServices
    {
        public Task<string> addCarTypology (string carTypology);
        public Task <IEnumerable> getCartypologies ();
        public Task<string> updateCarTypology(carTypology model);
        public Task<string> deleteCarTypology(int id);

    }
}
