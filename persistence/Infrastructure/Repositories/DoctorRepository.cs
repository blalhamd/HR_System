

using ApplicationLayer.GenericInterface;
using ApplicationLayer.NonGenericInterface;
using DomainLayer.Entities;
using DomainLayer.Enums;
using Microsoft.EntityFrameworkCore;
using persistence.APPDBCONTEXT;

namespace persistence.Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private DbSet<Doctor> _doctors;

        public DoctorRepository(AppDbContext context) : base(context)
        {
           _doctors = context.Set<Doctor>();
        }

        public async Task<Doctor> GetDoctorBySpeciality(Specialty? specialty)
        {

            if(specialty is null)
            {
                throw new ArgumentNullException();
            }

            if(_context is null)
            {
                throw new ArgumentNullException();
            }


            var query = await _doctors.FirstOrDefaultAsync(x=>x.specialty == specialty);

            return query;
        }

    }
}
