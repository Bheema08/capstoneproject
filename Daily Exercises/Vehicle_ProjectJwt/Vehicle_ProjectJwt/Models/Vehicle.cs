namespace Vehicle_ProjectJwt.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Make { get; set; } = default!;
        public string Model { get; set; } = default!;
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public string Status { get; set; } = "available"; // "available" | "notAvailable"
        public int PassengerCapacity { get; set; }
        public decimal EngineCapacity { get; set; }
        public string Type { get; set; } = default!; // e.g., "car","suv","bike","van"
    }

    
}
