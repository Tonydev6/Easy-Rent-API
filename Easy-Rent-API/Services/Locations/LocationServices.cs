using Easy_Rent_API.Context;
using Easy_Rent_API.DTO.Locations;
using Easy_Rent_API.Entities.Locations;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Easy_Rent_API.Services.Locations
{
    public class LocationServices : ILocationsServices

    {
        private readonly EasyRentContext _context;

        public LocationServices(EasyRentContext context)
        {
            _context = context;
        }
        async Task<string> ILocationsServices.AddLocation(InsertLocation model)
        {
            Location location = new Location();
            location.region = model.region;
            location.country = model.country;
            location.postalCode = model.postalCode;
            location.city = model.city; 
            location.streetName = model.streetName;

            _context.Add(location);
            await _context.SaveChangesAsync();

            return "Location addesd with success";
           
        }

        async Task<IEnumerable> ILocationsServices.GetAllLocations()
        {
            return  (IEnumerable) await _context.locations.ToListAsync();
        }

        async Task<Location> ILocationsServices.GetLocationById(ulong id)
        {
            Location found = await _context.locations.FirstOrDefaultAsync(l => l.Id == id);
            if (found == null) throw new Exception($"Location with id{id} not found");

            return found;
        }

        async Task<string> ILocationsServices.RemoveLocation(ulong id)
        {
            Location found = await _context.locations.FirstOrDefaultAsync(l => l.Id == id);
            if (found == null) throw new Exception($"Location with id{id} not found");

            _context.locations.Remove(found);
            await _context.SaveChangesAsync();
            return "Location deleted with success";
        }

        async Task<string> ILocationsServices.UpdateLocation(ulong id, InsertLocation model)
        {
            Location found = await _context.locations.FirstOrDefaultAsync(l => l.Id == id);
            if (found == null) throw new Exception($"Location with id{id} not found");

            found.city = model.city;
            found.streetName = model.streetName;
            found.country = model.country;
            found.region = model.region;
            found.postalCode = model.postalCode;

            _context.Update(found);
            await _context.SaveChangesAsync();
            return "Location updated with success";

        }
    }
}
