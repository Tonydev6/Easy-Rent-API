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
        public async Task<bool> Add(InsertLocation model)
        {
            try
            {
                Location location = new Location()
                {
                    region = model.region,
                    country = model.country,
                    postalCode = model.postalCode,
                    city = model.city,
                    streetName = model.streetName,

                };

                _context.Add(location);
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
            return await _context.locations.ToListAsync();
        }

        public async Task<Location> Get(ulong id)
        {
            Location found = await _context.locations.FindAsync(id);
            if (found == null) return new Location();

            return found;
        }

        public async Task<bool> Remove(ulong id)
        {
            try
            {
                Location found = await Get(id);

                if (found.Id != id) return false;

                _context.locations.Remove(found);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }

        public async Task<bool> Update(ulong id, InsertLocation model)
        {
            try
            {
                Location found = await _context.locations.FirstOrDefaultAsync(l => l.Id == id);
                if (found == null)
                {
                    return false;
                }

                found.city = model.city;
                found.streetName = model.streetName;
                found.country = model.country;
                found.region = model.region;
                found.postalCode = model.postalCode;

                _context.Update(found);
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
