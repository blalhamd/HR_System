using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientList
{
    public class GetPatientListQuery : IRequest<List<PatientViewModel>>
    {
    }
}
