

using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest<Unit>
    {
        public int id { get; set; }
    }
}
