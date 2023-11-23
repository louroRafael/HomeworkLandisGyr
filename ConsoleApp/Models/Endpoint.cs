using ProjetoLandisGyr.Enums;
using System.ComponentModel;

namespace ProjetoLandisGyr.Models
{
    public class Endpoint
    {
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        [DisplayName("Model ID")]
        public ModelId MeterModelId { get; set; }
        [DisplayName("Number")]
        public int MeterNumber { get; set; }
        [DisplayName("Firmware Version")]
        public string MeterFirmwareVersion { get; set; }
        [DisplayName("Switch State")]
        public SwitchState SwitchState { get; set; }
    }
}
