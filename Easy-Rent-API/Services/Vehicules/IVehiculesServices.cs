using Easy_Rent_API.Context;
using Easy_Rent_API.DTO.Vehicules;
using Easy_Rent_API.Models.Vehicules;
using System.Collections;

namespace Easy_Rent_API.Services.Vehicules
{
    public interface IVehiculesServices
    {
        public Task<string> AddVehicule(InsertVehicule vehicule);
        public Task <IEnumerable> GetAllVehicules();

        public Task<Vehicule> GetVehiculeById(ulong id);    

        public Task<string> UpdateVehicule(ulong id, InsertVehicule vehicule);
        public Task<string> RemoveVehicule(ulong id);
    }
}
