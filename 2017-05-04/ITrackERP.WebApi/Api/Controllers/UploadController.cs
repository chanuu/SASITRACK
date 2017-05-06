using Abp.Domain.Repositories;
using Abp.WebApi.Controllers;
using ITrackERP.TAW;
using ITrackERP.WorkCycleImages.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using ITrackERP.Employees;
using System.Reflection;
using ITrackERP.ComlianceAndSafety;
using ITrackERP.HR;
using ITrackERP.Assets;
using ITrackERP.MultiTenancy;
using ITrackERP.Asset_Ledgers;


namespace ITrackERP.Api.Controllers
{
    public class UploadController : AbpApiController
    {
        private readonly IRepository<WorkCycleImage, Guid> _workCycleImageRepository;
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<Album, Guid> _albumRepository;
        private readonly IRepository<ComlianceAndSafety.Files, Guid> _fileRepository;
        private readonly IRepository<Department, Guid> _departmentRepository;
        private readonly IRepository<Asset, Guid> _assetRepository;
        private readonly IRepository<AssetVerificationHeader, Guid> _assetVerificationHeaderRepository;
        private readonly IRepository<AssetVerificationDetail, Guid> _assetVerificationDetailRepository;   
        private readonly TenantManager _tenantManager;
        private readonly IRepository<AssetLedger, Guid> _assetLedgerRepository;
        private readonly IRepository<Element, Guid> _elementRepository;

        public UploadController(IRepository<Employee, Guid> employeeRepository, IRepository<WorkCycleImage, 
            Guid> workCycleImageRepository, IRepository<ComlianceAndSafety.Files, Guid> fileRepository, 
            IRepository<Album, Guid> albumRepository,
            IRepository<Department, Guid> departmentRepository,
            IRepository<Asset, Guid> assetRepository,TenantManager tenantManager,
            IRepository<AssetVerificationHeader, Guid> assetVerificationHeaderRepository,
            IRepository<AssetVerificationDetail, Guid> assetVerificationDetailRepository,
            IRepository<AssetLedger, Guid> assetLedgerRepository,
            IRepository<Element, Guid> elementRepository)
           
       {
           _employeeRepository = employeeRepository;
           _workCycleImageRepository = workCycleImageRepository;
           _fileRepository = fileRepository;
           _albumRepository = albumRepository;
           _departmentRepository = departmentRepository;
           _assetRepository = assetRepository;
           _tenantManager = tenantManager;
           _assetVerificationHeaderRepository = assetVerificationHeaderRepository;
           _assetVerificationDetailRepository = assetVerificationDetailRepository;
           _assetLedgerRepository = assetLedgerRepository;
           _elementRepository = elementRepository;
       }
     
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Upload()
        {
            string value = "";
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
                string requestFromPost = reader.ReadToEnd();

                foreach (string key in HttpContext.Current.Request.Form.AllKeys)
                {
                    value = HttpContext.Current.Request.Form[key];
                    
                }

                
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        {
                            var filePath = "";

                            if (value == "1") 
                            {
                                filePath = HttpContext.Current.Server.MapPath("~/App/theme/UI/images/Employees/" + postedFile.FileName);                          
                            }
                            else if(value == "2")
                            {
                                filePath = HttpContext.Current.Server.MapPath("~/App/theme/UI/images/Work_Cycle_Images/" + postedFile.FileName);
                            }
                            else if (value == "3")
                            {
                                filePath = HttpContext.Current.Server.MapPath("~/App/theme/UI/images/Events/" + postedFile.FileName);
                            }
                            else if (value == "4")
                            {
                                filePath = HttpContext.Current.Server.MapPath("~/App/theme/UI/images/Elements/" + postedFile.FileName);
                            }
                            else if(value == "f")
                            {
                                filePath = HttpContext.Current.Server.MapPath("~/App/theme/UI/files/" + postedFile.FileName);
                            }
                            else if (value == "v")
                            {
                                  string assetVerificationPath;
                                  string[] Lines;
                                  string condition = "";
                                  string departmentname = "";
                                  int tenatId = AbpSession.TenantId.Value;
                                  
                                
                                  assetVerificationPath = HttpContext.Current.Server.MapPath("~/App/theme/UI/verification/" + postedFile.FileName);
                                  postedFile.SaveAs(assetVerificationPath);
                                  Lines = System.IO.File.ReadAllLines(assetVerificationPath).ToArray();

                                 
                                  if (Lines != null)
                                  {
                                      ///////Get Tenant///////
                                      var @tenant = _tenantManager.Tenants
                                      .Where(e => e.Id == tenatId)
                                      .ToList().FirstOrDefault();
                                
                                      ///////Asset Verification No///////

                                      var @assetverificationheadercount = _assetVerificationHeaderRepository
                                        .GetAll().Count();
                                     
                                      var @assetverificationno = "V0000001";

                                      if (@assetverificationheadercount != 0)
                                      {
                                          @assetverificationno = "V" + (@assetverificationheadercount + 1).ToString().PadLeft(7, '0');
                                      }
                                      else
                                      {
                                          @assetverificationno = "V0000001";
                                      }
                                      //////// Create Asset Verification Header//////////

                                      var assetVerificationHeader = AssetVerificationHeader.Create(tenatId, @assetverificationno, System.DateTime.Today, @tenant.TenancyName, "None");
                                      await _assetVerificationHeaderRepository.InsertAsync(assetVerificationHeader);

                                      //////// Create Asset Verification Header//////////

                                      foreach (var Line in Lines)
                                      {
                                          if (Line.Length == 7)
                                          {
                                              //////Get Department/////////
                                              var @department = _departmentRepository
                                              .GetAll()
                                              .Where(e => e.BarcodeNo == Line)
                                              .ToList().FirstOrDefault();
                                              //////Get Department/////////

                                              departmentname = @department.Name;

                                              //////Set Condition/////////

                                              if (departmentname != "Machine Yard")
                                              {
                                                  condition = "Production";
                                              }
                                              else
                                              {
                                                  condition = "None Production";
                                              }
                                              //////Set Condition/////////
                                          }
                                          else if (Line.Length == 9)
                                          {
                                            /////////Get Asset Detail//////
                                             var @asset = _assetRepository
                                             .GetAll()
                                             .Where(e => e.AssetNo == Line)
                                             .ToList().FirstOrDefault();

                                             /////////Create Asset Verification Detail//////
                                              var assetVerificationDetail = AssetVerificationDetail.Create(Line, @asset.AlternetAsset, departmentname, condition, "");

                                              assetVerificationDetail.AssetVerificationHeaderId = assetVerificationHeader.Id;
                                              assetVerificationDetail.TenantId = tenatId;

                                              assetVerificationHeader.AssetVerificationDetails.Add(assetVerificationDetail);

                                              await CurrentUnitOfWork.SaveChangesAsync();

                                              /////////Get Transaction Id//////
                                              var @ledgercount = _assetLedgerRepository
                                                                 .GetAll().Count();

                                              var @transactionId = (@ledgercount + 1).ToString().PadLeft(7, '0');

                                              /////////Create Asset Ledger//////
                                              var @assetledger = AssetLedger.Create(tenatId, @transactionId, System.DateTime.Today, @asset.AlternetAsset,
                                                  "Verification", @assetverificationno, condition, @tenant.TenancyName, departmentname, "Pending");
                                              await _assetLedgerRepository.InsertAsync(@assetledger);

                                              /////////Update Asset////// 
                                              @asset.AssetUsedBy = departmentname;
                                              @asset.Location = @tenant.TenancyName; 
                                              @asset.AssetStatus = condition;  
                                              await _assetRepository.UpdateAsync(@asset);
                                              /////////Update Asset////// 
                               
                                          } 
                                      }
                                    
                                  }

                                  File.Delete(assetVerificationPath);
                                 
                            }
                            if (filePath != "")
                            {
                                postedFile.SaveAs(filePath);
                            }
                        }
                    }

                    var message1 = string.Format("File Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload a file.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id, string key)
      
        {
             
            Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);

            string directorypath = System.AppDomain.CurrentDomain.BaseDirectory;


            var filepath = "";

            if (key == "1")
            {
                var @employee = _employeeRepository
               .GetAll()
               .Where(e => e.Id == id)
               .ToList().FirstOrDefault();

                filepath = directorypath + @employee.ImagePath;
               
            }
            else if (key == "2")
            {
                var @workCycleImagedetail = _workCycleImageRepository.GetAll()

              .Where(Y => Y.Id == id)
              .ToList().FirstOrDefault();

                filepath = directorypath + @workCycleImagedetail.WorkCycleImagePath;
            }
            else if (key == "3")
            {
                var @albumdetail = _albumRepository.GetAll()

              .Where(Y => Y.Id == id)
              .ToList().FirstOrDefault();

                filepath = directorypath + @albumdetail.Url;
            }
            else if (key == "4")
            {
                var @element = _elementRepository.GetAll()

              .Where(Y => Y.Id == id)
              .ToList().FirstOrDefault();

                filepath = directorypath + @element.Path;
            }
            else if (key == "f")
            {
                var @filedetail = _fileRepository.GetAll()

              .Where(Y => Y.Id == id)
              .ToList().FirstOrDefault();

                filepath = directorypath + @filedetail.Path;
            }
                
            try
            {
                
                await Task.Factory.StartNew(() =>
                {
                    if (filepath != null)
                        File.Delete(filepath);
                });

                return Ok(new { message = "Deleted Successfully" });
            }
            catch (Exception ex)
            {               
                return BadRequest("error deleting file " + ex.GetBaseException().Message);
            }

           
        }

    

    }
}
