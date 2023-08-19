

using MediatR;

namespace ApplicationLayer.BusinessLogic.Prescriptions.Commands.AddPrescription
{
    public class AddPrescriptionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string medication { get; set; }
        public string? dosage { get; set; }
        public int frequency { get; set; }   
        public string duration { get; set; } 
        public int AppointmentId { get; set; }
    }
}
