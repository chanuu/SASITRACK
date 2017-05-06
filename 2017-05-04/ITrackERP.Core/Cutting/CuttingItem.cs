using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ITrackERP.Company
{
    public class CuttingItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("CuttingMasterId")]
        public virtual CuttingMaster CuttingMaster { get; set; }

        public virtual Guid CuttingMasterId { get; set; }

        public virtual string CutNo { get; set; }

        public virtual string PoNo { get; set; }

        public virtual  string LayerNo { get; set; }

        public virtual string FabricType { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual string Color { get; set; }

        public virtual string Size { get; set; }

        public virtual double Length { get; set; }

        public virtual string LotNo { get; set; }

        public virtual int NoOfItem { get; set; }

        public virtual int NoOfPlys { get; set; }



        public virtual string IsTagGenarated { get; set; }

        public virtual string IsIssued { get; set; }

        public virtual DateTime TagPrintedTime { get; set; }

        public virtual Guid CuttingRatioId { get; set; }



        public static CuttingItem Create(string _cutNo,string _poNo,string _layerNo,string _fabricType,DateTime _date,string _color,string _size,double _length,string _lotno,int _noOfItem,int noofplys,string _istagggenarated,string _isissued,DateTime _tagprintedtime ) {

            var @cutitem = new CuttingItem
            {
                CutNo = _cutNo,
                PoNo = _poNo,
                LayerNo = _layerNo,
                FabricType = _fabricType,
                Date = _date,
                Color = _color,
                Size = _size,
                Length = _length,
                LotNo = _lotno,
                NoOfItem = _noOfItem,
                NoOfPlys = -noofplys,
                IsTagGenarated = _istagggenarated,
                IsIssued = _isissued,
                TagPrintedTime = _tagprintedtime,
                Id =  Guid.NewGuid()

        };

            return @cutitem;
        }



    }
}
