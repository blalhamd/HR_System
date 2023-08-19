

using DomainLayer.Enums;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialty specialty { get; set; }
        public string license { get; set; }
        public string contact { get; set; }
    }
}
