using Easy_Rent_API.DTO.Locations;
using Easy_Rent_API.Entities.Locations;
using System.Collections;
namespace Easy_Rent_API.Services.Locations
{
    public interface ILocationsServices
    {
        public Task<string> AddLocation(InsertLocation model);
        public Task <IEnumerable> GetAllLocations();
        public Task <Location> GetLocationById(ulong id);

        public Task<string> UpdateLocation(ulong id, InsertLocation model);
        public Task<string> RemoveLocation(ulong id);



    }
}
