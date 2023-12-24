using Easy_Rent_API.Entities.Vehicules;
using Easy_Rent_API.Models.Vehicules;

namespace Easy_Rent_API.DTO.Vehicules
{
    public class InsertVehicule
    {
        public string brand { get; set; }
        public string name { get; set; }
        public int places { get; set; }
        public string plate { get; set; }

        public int typologyId { get; set; }

        public int powerSourceId { get; set; }

        public int transmissionId { get; set; }
    }
}
