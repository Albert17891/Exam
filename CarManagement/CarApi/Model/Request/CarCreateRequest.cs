using System;

namespace CarApi.Model.Request
{
    public class CarCreateRequest
    {
        public string Model { get; set; }
        public DateTime Dateofmanufac { get; set; }
        public string CarInform { get; set; }
        public double CarPrice { get; set; }       
        public string Currency { get; set; }

        public bool Abs { get; set; }
        public bool PowerWindows { get; set; }
        public bool Hatch { get; set; }
        public bool Bluetooth { get; set; }
        public bool Signaling { get; set; }
        public bool ParkingControl { get; set; }
        public bool Navigation { get; set; }
        public bool OnboardComputer { get; set; }
        public bool MultiWheel { get; set; }
    }
}
