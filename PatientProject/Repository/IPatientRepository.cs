using PatientProject.Models;
using PatientProject.Models.Dtos;

namespace PatientProject.Repository
{
    public interface IPatientRepository
    {
        Task<List<Patient>>GetAllAsync();
        Task<Patient?>GetByIdAsync(int id);
        Task<Patient?>AddPatientAsync(Patient patient);
        Task<Patient?>UpdatePatientAsync(int id,Patient patient);
       Task<Patient?> DeletePatientAsync(int id); 
    }
}
