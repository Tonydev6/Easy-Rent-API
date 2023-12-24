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
        void IVehiculesServices.AddVehicule(InsertVehicule model)
        {
            PowerSource powerSource = _context.powerSources.FirstOrDefault(p => p.Id == model.powerSourceId);
            if (powerSource == null)
            {
                throw new Exception("Power Source not Found");
            }

            carTypology carTypology = _context.carTypologies.FirstOrDefault(c => c.Id == model.typologyId);
            if (carTypology == null)
            {
                throw new Exception("Typology  not Found");

            }

            Transmission transmission = _context.transmitions.FirstOrDefault(t => ((int)t.Id) == model.transmissionId);
            if (transmission == null)
            {
                throw new Exception("Transmission not found");
            }
            Vehicule plateAlreadyExist = _context.Vehicules.FirstOrDefault(v => v.plate == model.plate);

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

            _context.Add(insert);
            _context.SaveChanges();


        }

        IEnumerable IVehiculesServices.GetAllVehicules()
        {
            return _context.Vehicules.Include(v => v.powerSource).Include(v => v.typology).Include(v => v.transmission).ToList();
        }

        Vehicule IVehiculesServices.GetVehiculeById(ulong id)
        {
            Vehicule Found = _context.Vehicules.Include(v => v.powerSource).Include(v => v.typology).Include(v => v.transmission).FirstOrDefault(v => v.id == id);
            if (Found == null) throw new Exception($"Vehicule with id:{id} not found");

            return Found;

        }

        void IVehiculesServices.RemoveVehicule(ulong id)
        {
            Vehicule Found = _context.Vehicules.FirstOrDefault(v => v.id == id);
            if (Found == null) throw new Exception($"Vehicule with id:{id} not found");

            _context.Remove(Found);
            _context.SaveChanges();
        }

        void IVehiculesServices.UpdateVehicule(ulong id, InsertVehicule model)
        {
            Vehicule Found = _context.Vehicules.FirstOrDefault(v => v.id == id);
            if (Found == null) throw new Exception($"Vehicule with id:{id} not found");

            PowerSource powerSource = _context.powerSources.FirstOrDefault(p => p.Id == model.powerSourceId);
            if (powerSource == null)
            {
                throw new Exception("Power Source not Found");
            }

            carTypology carTypology = _context.carTypologies.FirstOrDefault(c => c.Id == model.typologyId);
            if (carTypology == null)
            {
                throw new Exception("Typology  not Found");

            }

            Transmission transmission = _context.transmitions.FirstOrDefault(t => ((int)t.Id) == model.transmissionId);
            if (transmission == null)
            {
                throw new Exception("Transmission not found");
            }
            Vehicule plateAlreadyExist = _context.Vehicules.FirstOrDefault(v => v.plate == model.plate && v.id != Found.id);

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
            _context.SaveChanges();
        }
    }
}
