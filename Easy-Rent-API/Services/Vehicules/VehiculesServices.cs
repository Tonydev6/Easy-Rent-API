using Easy_Rent_API.Context;
using Easy_Rent_API.DTO.Vehicules;
using Easy_Rent_API.Entities.Vehicules;
using Easy_Rent_API.Models.Vehicules;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace Easy_Rent_API.Services.Vehicules
{
    public class VehiculesServices : IVehiculesServices
    {
        private readonly EasyRentContext _context;

        public VehiculesServices(EasyRentContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(InsertVehicule model)
        {
            try
            {
                PowerSource powerSource = await _context.powerSources.FindAsync(model.powerSourceId);
                if (powerSource == null)
                {
                    return false;
                }

                carTypology carTypology = await _context.carTypologies.FindAsync(model.typologyId);
                if (carTypology == null)
                {
                    return false;
                }
                Transmission transmission = await _context.transmitions.FindAsync(model.transmissionId);
                if (transmission == null)

                {
                    return false;
                }

                bool plateAlreadyExist = await _context.Vehicules.AnyAsync(v => v.plate == model.plate);

                if (plateAlreadyExist)
                {
                    return false;
                }

                Vehicule insert = new Vehicule()
                {
                    brand = model.brand,
                    places = model.places,
                    plate = model.plate,
                    name = model.name,
                    transmission = transmission,
                    powerSource = powerSource,
                    typology = carTypology,
                };

                await _context.AddAsync(insert);

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
            return await _context.Vehicules.Include(v => v.powerSource).Include(v => v.typology).Include(v => v.transmission).ToListAsync();
        }

        public async Task<Vehicule> GetByID(ulong id)
        {
            try
            {
                Vehicule Found = await _context.Vehicules.
                                                Include(v => v.powerSource).
                                                Include(v => v.typology).
                                                Include(v => v.transmission).
                                                FirstOrDefaultAsync(v => v.id == id) ?? new();
                return Found;

            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return new();
            }


        }

        public async Task<bool> Delete(ulong id)
        {
            try
            {
                var vehicule = await GetByID(id);

                if (vehicule.id != id)
                {
                    return false;
                }

                _context.Remove(vehicule);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }

        }

        public async Task<bool> Update(ulong id, InsertVehicule model)
        {
            try
            {
                Vehicule Found = await _context.Vehicules.FindAsync(id);
                if (Found == null) return false;

                PowerSource powerSource = await _context.powerSources.FindAsync(model.powerSourceId);
                if (powerSource == null)
                {
                    return false;
                }

                carTypology carTypology = await _context.carTypologies.FindAsync(model.typologyId);
                if (carTypology == null)
                {
                    return false;

                }

                Transmission transmission = await _context.transmitions.FindAsync(model.transmissionId);
                if (transmission == null)
                {
                    return false;
                }

                Vehicule plateAlreadyExist = await _context.Vehicules.FirstOrDefaultAsync(v => v.plate == model.plate && v.id != Found.id);

                if (plateAlreadyExist != null)
                {
                    return false;
                }

                Found.brand = model.brand;
                Found.places = model.places;
                Found.plate = model.plate;
                Found.name = model.name;
                Found.transmission = transmission;
                Found.powerSource = powerSource;
                Found.typology = carTypology;

                _context.Update(Found);

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
