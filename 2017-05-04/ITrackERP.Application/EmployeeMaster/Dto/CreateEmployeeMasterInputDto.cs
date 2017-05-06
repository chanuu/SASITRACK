using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ITrackERP.EmployeeMaster.Dto
{
    [AutoMap(typeof(Master.EmployeeMaster))]
    public class CreateEmployeeMasterInputDto 
    {
        public string FullName { get; set; }

        public string NicNo { get; set; }

        public string EPFNo { get; set; }

        public string ETFNo { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public string JobStatus { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; }

        public string LandNo { get; set; }

        public string EmailAddress { get; set; }

        public string EmergencyContactNo { get; set; }

        public string EmergencyContactPerson { get; set; }
    }
}
