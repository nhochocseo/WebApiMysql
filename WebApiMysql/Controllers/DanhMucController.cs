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
        private List<DanhMucReponse> BuilTree(int parentId, List<DanhMuc> lstDanhMuc)
        {
            var danhMucRp = new List<DanhMucReponse>();
            List<DanhMuc> _subDanhMuc = lstDanhMuc.Where(d => d.IdDanhMucCha == parentId).ToList();
            if (_subDanhMuc.Count() < 1)
                return danhMucRp;
            foreach (var item in _subDanhMuc)
            {
                if (lstDanhMuc.Where(d => d.IdDanhMucCha == item.Id).ToList().Any())
                {
                    danhMucRp.Add(new DanhMucReponse
                    {
                        Id = item.Id,
                        Ten = item.Ten,
                        Url = item.Url,
                        IdDanhMucCha = item.IdDanhMucCha,
                        ListChild = BuilTree(item.Id, lstDanhMuc)
                    });
                }
                else
                {
                    danhMucRp.Add(new DanhMucReponse
                    {
                        Id = item.Id,
                        Ten = item.Ten,
                        Url = item.Url,
                        IdDanhMucCha = item.IdDanhMucCha,
                        ListChild = new List<DanhMucReponse>()
                    });
                }
            }
            return danhMucRp;
        }
        [HttpGet]
        [Route("getListCategory")]
        public object getListCategory()
        {
            try
            {
                var data = this._portalDanhMuc.getListCategory();

                var result = BuilTree(0, data);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("SaveDanhMuc")]
        public object SaveDanhMuc(DanhMuc json)
        {
            try
            {
                var data = this._portalDanhMuc.SaveDanhMuc(json);
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
