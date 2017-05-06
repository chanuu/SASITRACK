using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ITrackERP.Master
{
    public class EmployeeMaster : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual string FullName { get; set; }

        public virtual string NicNo { get; set; }

        public virtual string EPFNo { get; set; }

        public virtual string ETFNo { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual string Gender { get; set; }

        public virtual string MaritalStatus { get; set; }

        public virtual string Department { get; set; }

        public virtual string Designation { get; set; }

        public virtual string JobStatus { get; set; }

        public virtual string Address { get; set; }

        public virtual string MobileNo { get; set; }

        public virtual string LandNo { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual string EmergencyContactNo { get; set; }

        public virtual string EmergencyContactPerson { get; set; }

        public virtual string ImagePath { get; set; }


        public static EmployeeMaster Create(int tenantId, string fullName, string nicNo, string epfNo, string etfNo,
            DateTime dateOfBirth, string gender, string maritalStatus, string department, string designation,
            string jobStatus, string address, string mobileNo, string landNo, string emailAddress,
            string emergencyContactNo, string emergencyContactPerson)

        {
            var @employeemaster = new EmployeeMaster()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                FullName = fullName,
                NicNo = nicNo,
                EPFNo = epfNo,
                ETFNo = etfNo,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                MaritalStatus = maritalStatus,
                Department = department,
                Designation = designation,
                JobStatus = jobStatus,
                Address = address,
                MobileNo = mobileNo,
                LandNo = landNo,
                EmailAddress = emailAddress,
                EmergencyContactNo = emergencyContactNo,
                EmergencyContactPerson = emergencyContactPerson
                
            };

            return @employeemaster;
        }

    }
}
