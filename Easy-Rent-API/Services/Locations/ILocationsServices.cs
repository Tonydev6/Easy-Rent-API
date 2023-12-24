using Easy_Rent_API.DTO.Locations;
using Easy_Rent_API.Entities.Locations;
using System.Collections;
namespace Easy_Rent_API.Services.Locations
{
    public interface ILocationsServices
    {
        public void AddLocation(InsertLocation model);
        public IEnumerable GetAllLocations();
        public Location GetLocationById(ulong id);

        public void UpdateLocation(ulong id, InsertLocation model);
        public void RemoveLocation(ulong id);



    }
}
