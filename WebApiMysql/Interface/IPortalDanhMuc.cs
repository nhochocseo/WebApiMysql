﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMysql.Models;

namespace WebApiMysql.Interface
{
    public interface IPortalDanhMuc
    {
        List<DanhMuc> getListCategory();
        int SaveDanhMuc(DanhMuc json);
    }
}