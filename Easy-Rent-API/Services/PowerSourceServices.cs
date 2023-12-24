using Easy_Rent_API.Context;
using Easy_Rent_API.Models.Vehicules;
using System.Collections;

namespace Easy_Rent_API.Services
{
    public class PowerSourceServices : IPowerSourcesServices

    {
        private readonly EasyRentContext _context;
        public PowerSourceServices(EasyRentContext context)
        {
            _context = context;
        }
        void IPowerSourcesServices.AddPowerSource(string input)
        {
            PowerSource alreadyExist = _context.powerSources.FirstOrDefault(p => p.description.ToLower() == input.ToLower());
            if(alreadyExist != null)
            {
                throw new Exception("This Power Source already exist");
            }
            PowerSource powerSource = new PowerSource();
            powerSource.description = input;

            _context.Add(powerSource);
            _context.SaveChanges();

        }

        IEnumerable IPowerSourcesServices.GetAllPowerSources()
        {
            return _context.powerSources.ToList();
        }

        void IPowerSourcesServices.RemovePowerSource(int id)
        {
            PowerSource powerSources = _context.powerSources.FirstOrDefault(p => p.Id == id);

            if (powerSources == null)
            {
                throw new Exception($"Power Source with id:{id} not found");
            }
            _context.powerSources.Remove(powerSources);
            _context.SaveChanges();
        }

        void IPowerSourcesServices.UpdatePowerSources(PowerSource model)
        {
            PowerSource powerSources = _context.powerSources.FirstOrDefault(p => p.Id == model.Id);

            if (powerSources == null)
            {
                throw new Exception($"Power Source with id:{model.Id} not found");
            } 


            PowerSource alreadyExist = _context.powerSources.FirstOrDefault(p => p.description.ToLower() == model.description.ToLower());
            if (alreadyExist != null)
            {
                throw new Exception($"Power Source with description:{model.description} already exist");

            }
            powerSources.description = model.description;
            _context.powerSources.Update(powerSources);
            _context.SaveChanges();
        }
    }
}
