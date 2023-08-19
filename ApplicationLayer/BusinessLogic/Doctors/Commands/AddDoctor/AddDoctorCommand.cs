

using DomainLayer.Enums;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.AddDoctor
{
    public class AddDoctorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public Specialty specialty { get; set; }
        public string license { get; set; }
        public string contact { get; set; }
    }
}
