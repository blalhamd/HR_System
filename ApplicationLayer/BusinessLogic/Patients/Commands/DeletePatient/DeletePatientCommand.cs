

using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.DeletePatient
{
    public class DeletePatientCommand : IRequest<Unit>
    {
        public int id { get; set; }
    }
}
