using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientProject.Models;
using PatientProject.Models.Dtos;
using PatientProject.Repository;

namespace PatientProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;
        private readonly IMapper mapper;

        public PatientController(IPatientRepository patientRepository,IMapper mapper)
        {
           this.patientRepository = patientRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAllPatient=await patientRepository.GetAllAsync();
            // using the automapper for mapping to dto
            var patientDto = mapper.Map <List<PatientDto>>(getAllPatient);
           /* var patientDto = new List<PatientDto>();
            foreach (var patient in getAllPatient) {
                patientDto.Add(new PatientDto
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Address = patient.Address,
                    PhoneNumber = patient.PhoneNumber,
                    DateOfBirth = patient.DateOfBirth,
                    Gender= patient.Gender,

                });
            }*/
            return Ok(patientDto);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getPatient= await patientRepository.GetByIdAsync(id);
            if (getPatient == null) {
                return NotFound();

            }
            var patientDto = mapper.Map<PatientDto>(getPatient);
           /* var patientDto = new PatientDto
            {
                Id=getPatient.Id,
                FirstName=getPatient.FirstName,
                LastName=getPatient.LastName,
                Address=getPatient.Address,
                PhoneNumber=getPatient.PhoneNumber,
                DateOfBirth=getPatient.DateOfBirth,
                Gender=getPatient.Gender,
            };*/
            return Ok(patientDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient(AddPatientDto addPatientDto)
        {
            var patientDmainModel = mapper.Map<Patient>(addPatientDto);
            /*var patientDmainModel = new Patient
            {
            FirstName = addPatientDto.FirstName,
            LastName = addPatientDto.LastName,
            Gender = addPatientDto.Gender,
            PhoneNumber = addPatientDto.PhoneNumber,
            DateOfBirth=addPatientDto.DateOfBirth,
                Address = addPatientDto.Address,
            };*/
            var addPatient = await patientRepository.AddPatientAsync(patientDmainModel);
            if (addPatient == null) {

                return NotFound();
                    }
            var patientDto = mapper.Map<PatientDto>(addPatient);
            /*  var patientDto = new PatientDto { 
              FirstName=addPatient.FirstName,
              LastName=addPatient.LastName,
              Address=addPatient.Address,
              PhoneNumber=addPatient.PhoneNumber,
              Gender =addPatient.Gender,
              DateOfBirth =addPatient.DateOfBirth,
              };*/
            return Ok(patientDto);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePatient(int id,UpdatePatientDto updatePatientDto)
        {
            // maping to Domain Model
            var updatePatientDomainModel = mapper.Map<Patient>(updatePatientDto);
            /*var updatePatientDomainModel = new Patient
            {
                FirstName = updatePatientDto.FirstName,
                LastName = updatePatientDto.LastName,
                Gender = updatePatientDto.Gender,
                PhoneNumber = updatePatientDto.PhoneNumber,
                Address = updatePatientDto.Address,
                DateOfBirth = updatePatientDto.DateOfBirth,


            };*/
            //  use domain model to dto
            updatePatientDomainModel = await patientRepository.UpdatePatientAsync(id, updatePatientDomainModel);

            // mapping to dto
            var patientDto = mapper.Map<PatientDto>(updatePatientDomainModel);
         /*   var patientDto = new PatientDto
            {
                FirstName= updatePatientDomainModel.FirstName,
                LastName= updatePatientDomainModel.LastName,
                Gender = updatePatientDomainModel.Gender,
                PhoneNumber = updatePatientDomainModel.PhoneNumber,
                Address = updatePatientDomainModel.Address,
               DateOfBirth= updatePatientDomainModel.DateOfBirth,

            };*/
            return Ok(patientDto);


        }
        [HttpDelete]
        [Route("{id=int}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var deletePatient=await patientRepository.DeletePatientAsync(id);
            if (deletePatient == null)
            {
                return NotFound();
            }
            var PatientDto=mapper.Map<PatientDto>(deletePatient);
            return Ok(PatientDto);
        }
    }
}
