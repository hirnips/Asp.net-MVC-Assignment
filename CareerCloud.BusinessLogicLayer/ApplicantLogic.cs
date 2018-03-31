using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantLogic
    {
        private IDataRepository<ApplicantJobApplicationPoco> applicantJobApplicationRepo;
        private IDataRepository<ApplicantProfilePoco> applicantProfileRepo;
        private IDataRepository<SecurityLoginPoco> securityLoginRepo;
        private IDataRepository<CompanyJobDescriptionPoco> companyJobDescriptionRepo;

        public List<CompanyJobDescriptionPoco> GetApplicantJob(Guid ID)
        {
            applicantJobApplicationRepo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            IEnumerable<Guid> ApplicantJobIds = applicantJobApplicationRepo.GetList(cp => cp.Applicant.Equals(ID)).Select(ap => ap.Job);

            companyJobDescriptionRepo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            return companyJobDescriptionRepo.GetList(cjd => ApplicantJobIds.Contains(cjd.Job)).ToList();
        }

        public SecurityLoginPoco  GetApplicantName(Guid ID)
        {
            applicantJobApplicationRepo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            IEnumerable<Guid> ApplicantIds = applicantJobApplicationRepo.GetList(a => a.Id.Equals(ID)).Select(ap => ap.Applicant);

            applicantProfileRepo = new EFGenericRepository<ApplicantProfilePoco>();
            IEnumerable<Guid> AppProfileIds = applicantProfileRepo.GetList(ap => ApplicantIds.FirstOrDefault().Equals(ap.Id)).Select(a => a.Login);

            securityLoginRepo = new EFGenericRepository<SecurityLoginPoco>();
            return securityLoginRepo.GetSingle(s => AppProfileIds.FirstOrDefault().Equals(s.Id));
             /*securityLoginRepo.GetSingle(s => AppProfileIds.FirstOrDefault().Equals(s.Id));*/
        }

        public ApplicantJobApplicationPoco GetApplicantJobApplication(Guid ID)
        {
            applicantJobApplicationRepo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            return applicantJobApplicationRepo.GetSingle(ap => ap.Id.Equals(ID));
        }
    }
}
