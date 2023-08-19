

using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;
using DomainLayer.Enums;

namespace ApplicationLayer.NonGenericInterface
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<Doctor> GetDoctorBySpeciality(Specialty? specialty);
    }
}
