

using DomainLayer.Enums;

namespace ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorBySpeciality
{
    public class DoctorViewModelBySpeciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialty? specialty { get; set; }
        public string license { get; set; }
        public string contact { get; set; }
    }
}
