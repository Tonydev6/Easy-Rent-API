namespace Easy_Rent_API.Entities.Vehicules
{

    public enum TransmitionEnum
    {
        manual =1,
        automatic =2,
        semiAutomatic =3,
        continuoslyVariableTransmission =4,

    }
    public class Transmission
    {
        public TransmitionEnum Id { get; set; }
        public string description { get; set; }
    }
}
