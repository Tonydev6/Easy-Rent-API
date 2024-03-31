using Easy_Rent_API.Context;
using Easy_Rent_API.Models.Vehicules;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Easy_Rent_API.Services.Vehicules
{
    public class PowerSourceServices : IPowerSourcesServices

    {
        private readonly EasyRentContext _context;
        public PowerSourceServices(EasyRentContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(string input)
        {
            try
            {
                PowerSource alreadyExist = await _context.powerSources.FirstOrDefaultAsync(p => p.description.ToLower() == input.ToLower());
                if (alreadyExist != null)
                {
                    return false;
                }
                PowerSource powerSource = new PowerSource();
                powerSource.description = input;

                _context.AddAsync(powerSource);
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
            return await _context.powerSources.ToListAsync();
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                PowerSource powerSources = await _context.powerSources.FindAsync(id);

                if (powerSources == null)
                {
                    return false;
                }
                _context.powerSources.Remove(powerSources);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }

        public async Task<bool> Update(PowerSource model)
        {
            try
            {
                PowerSource powerSources = await _context.powerSources.FirstOrDefaultAsync(p => p.Id == model.Id);

                if (powerSources == null)
                {
                    return false;
                }


                PowerSource alreadyExist = await _context.powerSources.FirstOrDefaultAsync(p => p.description.ToLower() == model.description.ToLower());
                if (alreadyExist != null)
                {
                    return false;
                }
                powerSources.description = model.description;
                _context.powerSources.Update(powerSources);
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
