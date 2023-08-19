

namespace ApplicationLayer.BusinessLogic.Prescriptions.Commands.UpdatePrescription
{
    public class UpdatePrescriptionRequist
    {
        public string medication { get; set; }
        public string? dosage { get; set; }
        public int frequency { get; set; }
        public string duration { get; set; }
        public int AppointmentId { get; set; }
    }
}
