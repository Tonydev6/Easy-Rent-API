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
        async Task<string> ICarTypologiesServices.addCarTypology(string carTypology)

        {
            carTypology alreadyExist = await _context.carTypologies.FirstOrDefaultAsync(c => c.description == carTypology);

            if (alreadyExist != null)
            {
                throw new Exception("This car Typology already exist");
            }
            carTypology insertTypology = new carTypology();

            insertTypology.description = carTypology;
            try
            {
                await _context.AddAsync(insertTypology);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
                return "errore";
            }

            return "Car typology created with success";



        }
        async Task <IEnumerable> ICarTypologiesServices.getCartypologies()
        {
            List<carTypology> carTypologies = await _context.carTypologies.ToListAsync();

            return carTypologies;
        }


        async Task<string> ICarTypologiesServices.deleteCarTypology(int id)
        {
            carTypology carTypology = await _context.carTypologies.FirstOrDefaultAsync(c => c.Id == id);
            if (carTypology == null)
            {
                throw new Exception($"Typology car with id: {id} not found");
            }

            _context.Remove(carTypology);
           await _context.SaveChangesAsync();
            return "Car typology deleted with success";
        }

        async Task<string> ICarTypologiesServices.updateCarTypology(carTypology model)
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
            await _context.SaveChangesAsync();

            return "Typology Car updated with success";
        }
    }
}
