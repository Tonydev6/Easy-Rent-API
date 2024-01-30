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
        async Task<string> IVehiculesServices.AddVehicule(InsertVehicule model)
        {
            PowerSource powerSource = await _context.powerSources.FirstOrDefaultAsync(p => p.Id == model.powerSourceId);
            if (powerSource == null)
            {
                throw new Exception("Power Source not Found");
            }

            carTypology carTypology = await _context.carTypologies.FirstOrDefaultAsync(c => c.Id == model.typologyId);
            if (carTypology == null)
            {
                throw new Exception("Typology  not Found");

            }

            Transmission transmission = await _context.transmitions.FirstOrDefaultAsync(t => ((int)t.Id) == model.transmissionId);
            if (transmission == null)
            {
                throw new Exception("Transmission not found");
            }
            Vehicule plateAlreadyExist = await _context.Vehicules.FirstOrDefaultAsync(v => v.plate == model.plate);

            if (plateAlreadyExist != null)
            {
                throw new Exception("Vehicule with that plate already exist");
            }

            Vehicule insert = new Vehicule();
            insert.brand = model.brand;
            insert.places = model.places;
            insert.plate = model.plate;
            insert.name = model.name;
            insert.transmission = transmission;
            insert.powerSource = powerSource;
            insert.typology = carTypology;

            await _context.AddAsync(insert);
            await _context.SaveChangesAsync();


        }

        async Task<IEnumerable> IVehiculesServices.GetAllVehicules()
        {
            return await _context.Vehicules.Include(v => v.powerSource).Include(v => v.typology).Include(v => v.transmission).ToListAsync();
        }

        async Task <Vehicule> IVehiculesServices.GetVehiculeById(ulong id)
        {
            Vehicule Found = await _context.Vehicules.Include(v => v.powerSource).Include(v => v.typology).Include(v => v.transmission).FirstOrDefaultAsync(v => v.id == id);
            if (Found == null) throw new Exception($"Vehicule with id:{id} not found");

            return Found;

        }

        async void IVehiculesServices.RemoveVehicule(ulong id)
        {
            Vehicule Found = await _context.Vehicules.FirstOrDefaultAsync(v => v.id == id);
            if (Found == null) throw new Exception($"Vehicule with id:{id} not found");

            _context.Remove(Found);
            _context.SaveChangesAsync();
        }

        async Task<string> IVehiculesServices.UpdateVehicule(ulong id, InsertVehicule model)
        {
            Vehicule Found = await _context.Vehicules.FirstOrDefaultAsync(v => v.id == id);
            if (Found == null) throw new Exception($"Vehicule with id:{id} not found");

            PowerSource powerSource = await _context.powerSources.FirstOrDefaultAsync(p => p.Id == model.powerSourceId);
            if (powerSource == null)
            {
                throw new Exception("Power Source not Found");
            }

            carTypology carTypology = await _context.carTypologies.FirstOrDefaultAsync(c => c.Id == model.typologyId);
            if (carTypology == null)
            {
                throw new Exception("Typology  not Found");

            }

            Transmission transmission = await _context.transmitions.FirstOrDefaultAsync(t => ((int)t.Id) == model.transmissionId);
            if (transmission == null)
            {
                throw new Exception("Transmission not found");
            }
            Vehicule plateAlreadyExist = await _context.Vehicules.FirstOrDefaultAsync(v => v.plate == model.plate && v.id != Found.id);

            if (plateAlreadyExist != null)
            {
                throw new Exception("Vehicule with that plate already exist");
            }


            Found.brand = model.brand;
            Found.places = model.places;
            Found.plate = model.plate;
            Found.name = model.name;
            Found.transmission = transmission;
            Found.powerSource = powerSource;
            Found.typology = carTypology;

            _context.Update(Found);
            await _context.SaveChangesAsync();
            return "Vehicule updated with success";
        }
    }
}
