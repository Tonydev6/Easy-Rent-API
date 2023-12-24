using Easy_Rent_API.Entities.Vehicules;

namespace Easy_Rent_API.Models.Vehicules
{
    public class Vehicule
    {
        public ulong id {  get; set; }
        public string brand { get; set; }
        public string name { get; set; }
        public int places { get; set; } 
        public string plate { get; set; }

        public carTypology typology { get; set; }

        public PowerSource powerSource { get; set; }    

        public Transmission transmission { get; set; }

    }
}
