

using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientById
{
    public class GetPatientQuery : IRequest<PatientDetailViewModel>
    {
        public int id { get; set; }
    }
}
