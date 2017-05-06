using Abp.AutoMapper;
using ITRACK.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Styles.Dto
{
    [AutoMap(typeof(Style))]
    public class EditStyleInputDto
    {
        [Required]
        public string StyleNo { get; set; }

        public string ArticleNo { get; set; }


        public string Season { get; set; }

        public string Remark { get; set; }

        [Required]
        public string OrderType { get; set; }

        public string Department { get; set; }


        public string BocNo { get; set; }

        public string ItemType { get; set; }

        [Required]
        public string BuyerName { get; set; }

        public Guid Id { get; set; }
    }
}
