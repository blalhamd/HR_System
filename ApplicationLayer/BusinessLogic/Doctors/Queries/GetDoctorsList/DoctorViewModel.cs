using DomainLayer.Entities;
using DomainLayer.Enums;


namespace ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsList
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialty specialty { get; set; }
        public string license { get; set; }
        public string contact { get; set; }
    }
}
