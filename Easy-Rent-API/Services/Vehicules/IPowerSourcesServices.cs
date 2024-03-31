using Easy_Rent_API.Models.Vehicules;
using System.Collections;

namespace Easy_Rent_API.Services.Vehicules
{
    public interface IPowerSourcesServices
    {
        public Task<bool> Add(string input);
        public Task<bool> Remove(int id);
        public Task<IEnumerable> List();
        public Task<bool> Update(PowerSource model);
    }
}
