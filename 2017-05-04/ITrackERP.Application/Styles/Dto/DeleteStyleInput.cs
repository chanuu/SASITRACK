using Abp.AutoMapper;
using ITRACK.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Styles.Dto
{
    [AutoMap(typeof(Style))]
    public class DeleteStyleInputDto
    {
        public Guid Id { get; set; }
    }
}
