using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineRequirements.DTOs
{
    [AutoMap(typeof(MachineRequirement))]
   public class MachineRequrementItemByStyleDto
    {


       

        public virtual string StyleNo { get; set; }

        public virtual string LineNo { get; set; }
        public virtual Nullable<DateTime> FromDate { get; set; }

        public virtual Nullable<DateTime> ToDate { get; set; }

   


        public ICollection<MachineRequirementItemDto> MachineRequirementItems { get; set; }
    }


    public class filterInput
    {
        public string Filter { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }

}
