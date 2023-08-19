using DomainLayer.Entities;

namespace ApplicationLayer.BusinessLogic.Prescriptions.Queries.GetPrescriptionList
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }
        public string medication { get; set; }
        public string? dosage { get; set; }
        public int frequency { get; set; }
        public string duration { get; set; }
        public int AppointmentId { get; set; }
        public AppointmentDTO appointment { get; set; }
    }
}
