using Microsoft.EntityFrameworkCore;
using PatientProject.Data;
using PatientProject.Models;

namespace PatientProject.Repository
{
    public class SQLPatientRepository:IPatientRepository
    {
        private readonly AppDbContext context;

        public SQLPatientRepository(AppDbContext _context)
        {
            context = _context;
        }

       public async Task<List<Patient>> GetAllAsync()
        {
            var allPatient = await context.patients.ToListAsync();
            return allPatient;
        }
       public async Task<Patient?> GetByIdAsync(int id)
        {
            var patient = await context.patients.FindAsync(id);
            if (patient == null) {
                return null;
            }
            return patient;
        }
      public async  Task<Patient?> AddPatientAsync(Patient patient){
            await context.patients.AddAsync(patient);
            await context.SaveChangesAsync();

            return patient;
        }
      public  async Task<Patient?> UpdatePatientAsync(int id, Patient patient)
        {
           var result= await context.patients.FindAsync(id);
            if (result == null) {
                return null;
            }
            result.FirstName=patient.FirstName;
            result.LastName=patient.LastName;
            result.Address=patient.Address;
            result.PhoneNumber=patient.PhoneNumber;
            result.DateOfBirth=patient.DateOfBirth;
            result.Gender=patient.Gender;
            await context.SaveChangesAsync();
            return result;
        }

      public async  Task<Patient?> DeletePatientAsync(int id)
        {
           var result= await context.patients.FindAsync(id);
            if (result == null) {
                return null;
            }
            context.patients.Remove(result);
            await context.SaveChangesAsync();
            return result;        }




    }
}
