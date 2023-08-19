

using ApplicationLayer.BusinessLogic.Appointments.Commands.AddAppointment;
using ApplicationLayer.BusinessLogic.Appointments.Commands.UpdateAppointment;
using ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentById;
using ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList;
using ApplicationLayer.BusinessLogic.Bills.Commands.AddBill;
using ApplicationLayer.BusinessLogic.Bills.Commands.UpdateBill;
using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsById;
using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList;
using ApplicationLayer.BusinessLogic.Doctors.Commands.AddDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Commands.UpdateDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorByName;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorBySpeciality;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsByName;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsList;
using ApplicationLayer.BusinessLogic.Patients.Commands.AddPatient;
using ApplicationLayer.BusinessLogic.Patients.Commands.UpdatePatient;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientById;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientList;
using ApplicationLayer.BusinessLogic.Prescriptions.Commands.AddPrescription;
using ApplicationLayer.BusinessLogic.Prescriptions.Commands.UpdatePrescription;
using ApplicationLayer.BusinessLogic.Prescriptions.Queries.GetPrescriptionList;
using AutoMapper;
using DomainLayer.Entities;
using PatientDTO = ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList.PatientDTO;
//using DoctorDTO = ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList.AppointmentViewModel;

namespace ApplicationLayer.Profiles
{
    public class Mapping : Profile
    {
        
        public Mapping()
        {


            CreateMap<Patient,PatientDTO>().ReverseMap();
            CreateMap<Patient, PatientViewModel>().ReverseMap();
            CreateMap<Patient, PatientDetailViewModel>().ReverseMap();
            CreateMap<AddPatientCommand, Patient>().ReverseMap();
            CreateMap<UpdatePatientCommand, Patient>().ReverseMap();

            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentViewModel>().ReverseMap();
            CreateMap<Appointment, AppointmentDetailViewModel>().ReverseMap();
            CreateMap<AddAppointmentCommand, Appointment>().ReverseMap();
            CreateMap<UpdateAppointmentCommand, Appointment>().ReverseMap();

            CreateMap<Bill, BillViewModel>().ReverseMap();
            CreateMap<Bill, BillDetailViewModel>().ReverseMap();
            CreateMap<AddBillCommand, Bill>().ReverseMap();
            CreateMap<UpdateBillCommand, Bill>().ReverseMap();


            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Doctor, DoctorViewModelBySpeciality>().ReverseMap();
            CreateMap<Doctor, DoctorDetailViewModel>().ReverseMap();
            CreateMap<Doctor, DoctorViewModel>().ReverseMap();
            CreateMap<Prescription, PrescriptionViewModel>().ReverseMap();
            CreateMap<AddDoctorCommand,Doctor>().ReverseMap();
            CreateMap<UpdateDoctorCommand,Doctor>().ReverseMap();
            CreateMap<UpdatePrescriptionCommand, Prescription>().ReverseMap();
            CreateMap<AddPrescriptionCommand,Prescription>().ReverseMap();
            CreateMap<UpdatePrescriptionRequist,UpdatePrescriptionCommand>().ReverseMap();
            CreateMap<UpdateAppointmentRequist,UpdateAppointmentCommand>().ReverseMap();
            CreateMap<UpdateBillRequiest,UpdateBillCommand>().ReverseMap();
            CreateMap<UpdateDoctorRequiest,UpdateDoctorCommand>().ReverseMap();
            CreateMap<UpdatePatientRequiest,UpdatePatientCommand>().ReverseMap();

        }


    }
}
