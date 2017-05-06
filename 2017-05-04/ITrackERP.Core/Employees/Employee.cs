using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Employees
{
    public class Employee : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
     
        public virtual string FullName { get; set; }

        public virtual string NicNo { get; set; }

        public virtual string EPFNo { get; set; }

        public virtual string ETFNo { get; set; }

        public virtual Nullable<DateTime> DateOfBirth { get; set; }

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

        public virtual ICollection<PastEmployeement> PastEmployeements { get; set; }

        public virtual ICollection<Promotion> Promotions { get; set; }

        public virtual ICollection<Award> Awards { get; set; }

        public static Employee Create(int tenantId, string fullName, string nicNo, string ePFNo, string eTFNo, DateTime dateOfBirth, string gender, string maritalStatus, string department, string designation, string jobStatus, string address, string mobileNo, string landNo, string emailAddress, string emergencyContactNo, string emergencyContactPerson, string imagePath)
        {
            var @employee = new Employee
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                FullName = fullName,
                NicNo = nicNo,
                EPFNo = ePFNo,
                ETFNo = eTFNo,
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
                EmergencyContactPerson = emergencyContactPerson,
                ImagePath = imagePath
            };

            @employee.Awards = new Collection<Award>();
            @employee.PastEmployeements = new Collection<PastEmployeement>();
            @employee.Promotions = new Collection<Promotion>();
            return @employee;



        } 
    }
}
