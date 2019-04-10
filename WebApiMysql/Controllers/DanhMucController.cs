using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiMysql.Common.Response;
using WebApiMysql.Interface;
using WebApiMysql.Models;

namespace WebApiMysql.Controllers
{
    [RoutePrefix("api/danhmuc")]
    public class DanhMucController : ApiController
    {
        private IPortalDanhMuc _portalDanhMuc;

        public DanhMucController(IPortalDanhMuc portalDanhMuc)
        {
            this._portalDanhMuc = portalDanhMuc;
        }
        [HttpGet]
        [Route("getListCategory")]
        public object getListCategory()
        {
            try
            {
                var data = this._portalDanhMuc.getListCategory();
                var result = new List<DanhMucReponse>();
                var listChild = new List<DanhMuc>();
                foreach (var item in data)
                {
                    if (item.IdDanhMucCha == 0)
                    {
                        result.Add(new DanhMucReponse
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            IdDanhMucCha = item.IdDanhMucCha,
                        });
                    }
                    else
                    {
                        listChild.Add(new DanhMuc {
                            Id = item.Id,
                            Ten = item.Ten,
                            IdDanhMucCha = item.IdDanhMucCha,
                        });
                    }
                }
                if(listChild.Count() > 0)
                {
                    foreach (var item in result)
                    {
                        item.ListChild = new List<DanhMuc>();
                        foreach (var itemChild in listChild)
                        {
                            if(item.Id == itemChild.IdDanhMucCha)
                            {
                                item.ListChild.Add(new DanhMuc {
                                    Id = itemChild.Id,
                                    Ten = itemChild.Ten,
                                    IdDanhMucCha = itemChild.IdDanhMucCha,
                                });
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
