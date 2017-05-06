using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.JobCardHeaders.DTOs
{
    public class JobCardHeaderInputDto
    {
        public string Filter { get; set; }

        public string AssetNo { get; set; }

        public string DoneBy { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
