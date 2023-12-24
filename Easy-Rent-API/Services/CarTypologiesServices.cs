using Easy_Rent_API.Context;
using Easy_Rent_API.Models.Vehicules;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Easy_Rent_API.Services
{
    public class CarTypologiesServices : ICarTypologiesServices

    {
        private readonly EasyRentContext _context;

        public CarTypologiesServices(EasyRentContext context)
        {
            this._context = context;
        }
        void ICarTypologiesServices.addCarTypology(string carTypology)

        {
            carTypology alreadyExist = _context.carTypologies.FirstOrDefault(c => c.description == carTypology);

            if (alreadyExist != null)
            {
                throw new Exception("This car Typology already exist");
            }
            carTypology insertTypology = new carTypology();

            insertTypology.description = carTypology;
            try
            {
                _context.Add(insertTypology);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
                return;
            }



        }
        IEnumerable ICarTypologiesServices.getCartypologies()
        {
            List<carTypology> carTypologies = _context.carTypologies.ToList();

            return carTypologies;
        }


        void ICarTypologiesServices.deleteCarTypology(int id)
        {
            carTypology carTypology = _context.carTypologies.FirstOrDefault(c => c.Id == id);
            if (carTypology == null)
            {
                throw new Exception($"Typology car with id: {id} not found");
            }

            _context.Remove(carTypology);
            _context.SaveChanges();
        }

        void ICarTypologiesServices.updateCarTypology(carTypology model)
        {
            carTypology carTypology = _context.carTypologies.FirstOrDefault(c => c.Id == model.Id);
            if (carTypology == null)
            {
                throw new Exception($"Typology car with id: {model.Id} not found");
            }
            carTypology alreadyExist = _context.carTypologies.FirstOrDefault(c => c.description.ToLower() == model.description.ToLower());
            if(alreadyExist != null)
            {
                throw new Exception($"Typology car with description:{model.description} already exist");
            }
            carTypology.description = model.description;
            _context.Update(carTypology);
            _context.SaveChanges();
        }
    }
}
