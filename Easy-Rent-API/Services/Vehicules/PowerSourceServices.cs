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
        async void IPowerSourcesServices.AddPowerSource(string input)
        {
            PowerSource alreadyExist =  await _context.powerSources.FirstOrDefaultAsync(p => p.description.ToLower() == input.ToLower());
            if (alreadyExist != null)
            {
                throw new Exception("This Power Source already exist");
            }
            PowerSource powerSource = new PowerSource();
            powerSource.description = input;

            _context.AddAsync(powerSource);
            _context.SaveChangesAsync();

        }

        async Task<IEnumerable> IPowerSourcesServices.GetAllPowerSources()
        {
            return await _context.powerSources.ToListAsync();
        }

        async void IPowerSourcesServices.RemovePowerSource(int id)
        {
            PowerSource powerSources = await _context.powerSources.FirstOrDefaultAsync(p => p.Id == id);

            if (powerSources == null)
            {
                throw new Exception($"Power Source with id:{id} not found");
            }
            _context.powerSources.Remove(powerSources);
            _context.SaveChangesAsync();
        }

        async void IPowerSourcesServices.UpdatePowerSources(PowerSource model)
        {
            PowerSource powerSources = await _context.powerSources.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (powerSources == null)
            {
                throw new Exception($"Power Source with id:{model.Id} not found");
            }


            PowerSource alreadyExist = await _context.powerSources.FirstOrDefaultAsync(p => p.description.ToLower() == model.description.ToLower());
            if (alreadyExist != null)
            {
                throw new Exception($"Power Source with description:{model.description} already exist");

            }
            powerSources.description = model.description;
            _context.powerSources.Update(powerSources);
            _context.SaveChangesAsync();
        }
    }
}
