﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Employees.DTOs
{
    [AutoMap(typeof(Employee))]
    public class EmployeeListDto: FullAuditedEntityDto<Guid>
    {
        public string FullName { get; set; }

        public string NicNo { get; set; }

        public string EPFNo { get; set; }

        public string ETFNo { get; set; }

        public Nullable<DateTime> DateOfBirth { get; set; }

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

        public string ImagePath { get; set; }
    }
}
