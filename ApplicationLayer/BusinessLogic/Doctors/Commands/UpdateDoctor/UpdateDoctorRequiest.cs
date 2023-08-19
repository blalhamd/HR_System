

using DomainLayer.Enums;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorRequiest
    {
        public string Name { get; set; }
        public Specialty specialty { get; set; }
        public string license { get; set; }
        public string contact { get; set; }
    }
}
