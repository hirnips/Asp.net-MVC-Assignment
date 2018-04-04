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
        private IDataRepository<CompanyJobDescriptionPoco> companyJobDescriptionRepo;
        private List<CompanyJobSkillPoco> skills = new List<CompanyJobSkillPoco>();

        public CompanyProfilePoco[] GetCompanyByName(string name)
        {
            companyDescriptionRepo = new EFGenericRepository<CompanyDescriptionPoco>();
            IEnumerable<Guid> desc = companyDescriptionRepo.GetList(d => d.CompanyName.Contains(name)).Select(c => c.Company);
            companyProfileRepo = new EFGenericRepository<CompanyProfilePoco>();
            return companyProfileRepo.GetList(c => desc.Contains(c.Id), c => c.CompanyDescriptions).ToArray();
        }

        public CompanyJobPoco[] GetCompanySearch(String search)
        {
            companyJobRepo = new EFGenericRepository<CompanyJobPoco>();
            companyJobDescriptionRepo = new EFGenericRepository<CompanyJobDescriptionPoco>();

            IEnumerable<Guid> JobDescID = companyJobDescriptionRepo.GetList(d => d.JobName.Contains(search)).Select(c => c.Job);
            return companyJobRepo.GetList(c => JobDescID.Contains(c.Id), c => c.CompanyJobDescriptions).ToArray();
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

        public List<SystemLanguageCodePoco> GetLanguage()
        {
            EFGenericRepository<SystemLanguageCodePoco> systemLanguageCodeLogic = new EFGenericRepository<SystemLanguageCodePoco>();
            return systemLanguageCodeLogic.GetAll().ToList();
        }

        //public void AddSkills(CompanyJobSkillPoco companyJobSkill)
        //{           
        //    skills.Add(companyJobSkill);
        //}
        //public List<CompanyJobSkillPoco> GetSkills()
        //{
        //    return skills;
        //}

        public CompanyJobPoco[] GetCompanybyCompanyID(Guid CId)
        {
            companyJobRepo = new EFGenericRepository<CompanyJobPoco>();
            return companyJobRepo.GetList(a => a.Company == CId).OrderByDescending(p => p.ProfileCreated).Take(1).ToArray();
        }

        public CompanyJobPoco[] GetCompanybyIds(Guid CId, Guid JId)
        {
            companyJobRepo = new EFGenericRepository<CompanyJobPoco>();
            return companyJobRepo.GetList(a => a.Company == CId).Where(a => a.Id == JId).OrderByDescending(p => p.ProfileCreated).Take(1).ToArray();
        }
    }
}

