using Easy_Rent_API.DTO.Locations;
using Easy_Rent_API.Entities.Locations;
using System.Collections;
namespace Easy_Rent_API.Services.Locations
{
    public interface ILocationsServices
    {
        public Task<bool> Add(InsertLocation model);
        public Task <IEnumerable> List();
        public Task <Location> Get(ulong id);

        public Task<bool> Update(ulong id, InsertLocation model);
        public Task<bool> Remove(ulong id);



    }
}
