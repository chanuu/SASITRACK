using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Employees
{
    public class Department : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual string Name { get; set; }
        public virtual string BarcodeNo { get; set; }
        public virtual double Length { get; set; }
        public virtual double Width { get; set; }
        public virtual string Remark { get; set; }

        public static Department Create(int tenantId, string name, string barcodeNo, double length, double width, string remark)
        {
            var @department = new Department
            {
                Id = Guid.NewGuid(),
                Name = name,
                BarcodeNo = barcodeNo,
                Length = length,
                Width = width,
                Remark = remark,
            };

            return @department;
        }
    }
}
