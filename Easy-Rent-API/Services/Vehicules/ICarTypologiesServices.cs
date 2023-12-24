using Easy_Rent_API.Models.Vehicules;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Easy_Rent_API.Services.Vehicules
{
    public interface ICarTypologiesServices
    {
        public void addCarTypology (string carTypology);
        public IEnumerable getCartypologies ();
        public void updateCarTypology(carTypology model);
        public void deleteCarTypology(int id);

    }
}
