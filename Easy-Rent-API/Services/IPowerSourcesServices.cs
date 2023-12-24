using Easy_Rent_API.Models.Vehicules;
using System.Collections;

namespace Easy_Rent_API.Services
{
    public interface IPowerSourcesServices
    {
        public void AddPowerSource(string input);
        public void RemovePowerSource(int id);
        public IEnumerable GetAllPowerSources();
        public void UpdatePowerSources(PowerSource model);
    }
}
