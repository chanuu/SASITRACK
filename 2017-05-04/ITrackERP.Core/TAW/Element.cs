using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAW
{
    public class Element : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual string Name { get; set; }
        public virtual double Length { get; set; }
        public virtual double Width { get; set; }
        public virtual string Category { get; set; }
        public virtual string Path { get; set; }

        public static Element Create(int tenantId, string name, double length, double width, string category, string path)
        {
            var @element = new Element
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Name = name,
                Length = length,
                Width = width,
                Category = category,
                Path = path,
            };


            return @element;



        }

    }
}