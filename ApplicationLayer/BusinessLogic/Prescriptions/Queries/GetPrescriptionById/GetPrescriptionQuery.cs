

using MediatR;

namespace ApplicationLayer.BusinessLogic.Prescriptions.Queries.GetPrescriptionById
{
    public class GetPrescriptionQuery : IRequest<PrescriptionDetailViewModel>
    {
        public int id { get; set; }
    }
}
