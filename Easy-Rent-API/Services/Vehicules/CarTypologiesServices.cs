using Easy_Rent_API.Context;
using Easy_Rent_API.Models.Vehicules;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Easy_Rent_API.Services.Vehicules
{
    public class CarTypologiesServices : ICarTypologiesServices

    {
        private readonly EasyRentContext _context;

        public CarTypologiesServices(EasyRentContext context)
        {
            _context = context;
        }
        async void ICarTypologiesServices.addCarTypology(string carTypology)

        {
            carTypology alreadyExist =await _context.carTypologies.FirstOrDefaultAsync(c => c.description == carTypology);

            if (alreadyExist != null)
            {
                throw new Exception("This car Typology already exist");
            }
            carTypology insertTypology = new carTypology();

            insertTypology.description = carTypology;
            try
            {
                _context.AddAsync(insertTypology);
                _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
                return;
            }



        }
        async Task <IEnumerable> ICarTypologiesServices.getCartypologies()
        {
            List<carTypology> carTypologies = await _context.carTypologies.ToListAsync();

            return carTypologies;
        }


        async void ICarTypologiesServices.deleteCarTypology(int id)
        {
            carTypology carTypology = await _context.carTypologies.FirstOrDefaultAsync(c => c.Id == id);
            if (carTypology == null)
            {
                throw new Exception($"Typology car with id: {id} not found");
            }

            _context.Remove(carTypology);
            _context.SaveChangesAsync();
        }

        async void ICarTypologiesServices.updateCarTypology(carTypology model)
        {
            carTypology carTypology = await _context.carTypologies.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (carTypology == null)
            {
                throw new Exception($"Typology car with id: {model.Id} not found");
            }
            carTypology alreadyExist = await _context.carTypologies.FirstOrDefaultAsync(c => c.description.ToLower() == model.description.ToLower());
            if (alreadyExist != null)
            {
                throw new Exception($"Typology car with description:{model.description} already exist");
            }
            carTypology.description = model.description;
            _context.Update(carTypology);
            _context.SaveChangesAsync();
        }
    }
}
