

using DomainLayer.Enums;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.AddPatient
{
    public class AddPatientCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public Gender gender { get; set; }
        public string? address { get; set; }
        public string phone { get; set; }
        public bool? HasInsurance { get; set; }
    }
}
