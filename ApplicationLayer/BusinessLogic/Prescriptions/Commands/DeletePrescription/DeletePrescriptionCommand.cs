

using MediatR;

namespace ApplicationLayer.BusinessLogic.Prescriptions.Commands.DeletePrescription
{
    public class DeletePrescriptionCommand : IRequest<Unit>
    {
        public int id { get; set; }
    }
}
