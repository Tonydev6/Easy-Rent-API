using Easy_Rent_API.Context;
using Easy_Rent_API.DTO.Vehicules;
using Easy_Rent_API.Models.Vehicules;
using System.Collections;

namespace Easy_Rent_API.Services.Vehicules
{
    public interface IVehiculesServices
    {
        public Task<bool> Add(InsertVehicule vehicule);
        public Task <IEnumerable> List();

        public Task<Vehicule> GetByID(ulong id);    

        public Task<bool> Update(ulong id, InsertVehicule vehicule);
        public Task<bool> Delete(ulong id);
    }
}
