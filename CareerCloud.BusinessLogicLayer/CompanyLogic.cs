using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using CareerCloud.EntityFrameworkDataAccess;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLogic
    {
        private IDataRepository<CompanyDescriptionPoco> companyDescriptionRepo;
        private IDataRepository<CompanyProfilePoco> companyProfileRepo;
        private IDataRepository<CompanyJobPoco> companyJobRepo;

        public CompanyProfilePoco[] GetCompanyByName(string name)
        {
            companyDescriptionRepo = new EFGenericRepository<CompanyDescriptionPoco>();
            IEnumerable<Guid> desc = companyDescriptionRepo.GetList(d => d.CompanyName.Contains(name)).Select(c => c.Company);
            companyProfileRepo = new EFGenericRepository<CompanyProfilePoco>();
            return companyProfileRepo.GetList(c => desc.Contains(c.Id), c => c.CompanyDescriptions).ToArray();
        }

        public CompanyProfilePoco GetJobDescription(Guid ID)
        {
            companyDescriptionRepo = new EFGenericRepository<CompanyDescriptionPoco>();
            IEnumerable<Guid> desc = companyDescriptionRepo.GetList(d => d.Company.Equals(ID)).Select(c => c.Company);

            companyJobRepo = new EFGenericRepository<CompanyJobPoco>();
            IEnumerable<Guid> JobIds = companyJobRepo.GetList(j => j.Company.Equals(ID)).Select(j => j.Company);

            if (JobIds.Count() > 0)
            {
                companyProfileRepo = new EFGenericRepository<CompanyProfilePoco>();
                return companyProfileRepo.GetSingle(c => JobIds.Contains(c.Id), c => c.CompanyJobs, c => c.CompanyDescriptions);
            }
            else
            {
                companyProfileRepo = new EFGenericRepository<CompanyProfilePoco>();
                return companyProfileRepo.GetSingle(c => desc.Contains(c.Id), c => c.CompanyDescriptions);
            }
        }

        public void DeleteJobDescription(Guid ID)
        {
            companyDescriptionRepo = new EFGenericRepository<CompanyDescriptionPoco>();
           

            CompanyDescriptionPoco companyDescriptionPoco = new CompanyDescriptionPoco();
            companyDescriptionPoco = companyDescriptionRepo.GetSingle(c => c.Company.Equals(ID));
            CompanyDescriptionPoco[] CompanyDescriptionPocos = new CompanyDescriptionPoco[]
            {
                companyDescriptionPoco
            };
           
            companyDescriptionRepo.Remove(CompanyDescriptionPocos);


            companyProfileRepo = new EFGenericRepository<CompanyProfilePoco>();
            CompanyProfilePoco companyProfilePoco = new CompanyProfilePoco();
            companyProfilePoco = companyProfileRepo.GetSingle(c => c.Id.Equals(ID));
            CompanyProfilePoco[] companyProfilePocos = new CompanyProfilePoco[]
            {
                companyProfilePoco
            };            
            companyProfileRepo.Remove(companyProfilePocos);
        }

    }
}
