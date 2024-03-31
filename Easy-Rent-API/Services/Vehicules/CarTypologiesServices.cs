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
        public async Task<bool> Add(string carTypology)

        {
            try
            {
                bool alreadyExist = await _context.carTypologies.AnyAsync(c => c.description.ToLower() == carTypology.ToLower());

                if (alreadyExist)
                {
                    return false;
                }
                carTypology insertTypology = new carTypology()
                {
                    description = carTypology,
                };

                await _context.AddAsync(insertTypology);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }

        }
        public async Task<IEnumerable> List()
        {
            List<carTypology> carTypologies = await _context.carTypologies.ToListAsync();

            return carTypologies;
        }


        public async Task<bool> Delete(short id)
        {
            try
            {
                carTypology carTypology = await _context.carTypologies.FindAsync(id);
                if (carTypology == null)
                {
                    return false;
                }

                _context.Remove(carTypology);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }

        }

        public async Task<bool> Update(carTypology model)
        {
            try
            {
                carTypology carTypology = await _context.carTypologies.FindAsync(model.Id);
                if (carTypology == null)
                {

                    return false;
                }
                carTypology alreadyExist = await _context.carTypologies.FirstOrDefaultAsync(c => c.description.ToLower() == model.description.ToLower());
                if (alreadyExist != null)
                {
                    return false;
                }
                carTypology.description = model.description;
                _context.Update(carTypology);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }

        }
    }
}
