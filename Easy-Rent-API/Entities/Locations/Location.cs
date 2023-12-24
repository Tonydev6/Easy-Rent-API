namespace Easy_Rent_API.Entities.Locations
{
    public class Location
    {

        public ulong Id { get; set; }
        public string streetName { get; set; } 
        public string city { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; } 
        public string country { get; set; }

    }
}
