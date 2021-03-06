﻿using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Core.Model;
using Core.Service;
using Infra.Builder;
using Infra.Dto;

namespace WebUI.Controllers
{
    public class CountryController : Cruder<Country, CountryInput>
    {
        public CountryController(ICrudService<Country> s, IBuilder<Country, CountryInput> v)
            : base(s, v)
        {
        }
        public virtual ActionResult Search(string search, int page = 1, int ps = 5)
        {
            var src = s.Where(o => o.Name.StartsWith(search), User.IsInRole("admin"));
            var rows = this.RenderView("rows", src.OrderBy(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }
    }
}