﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Core.Model;
using Core.Repository;

namespace WebUI.Controllers
{
    public class RolesLookupController : LookupController
    {
        private readonly IReadRepo<Role> r;

        public RolesLookupController(IReadRepo<Role> r)
        {
            this.r = r;
        }

        public override ActionResult SearchForm()
        {
            return Content("");
        }

        [HttpPost]
        public ActionResult Search(IEnumerable<int> selected)
        {
            var res = r.GetAll();
            if (selected != null) res = res.Where(o => !selected.Contains(o.Id));
            return View(@"Awesome\LookupList", res);
        }

        public ActionResult Selected(IEnumerable<int> selected)
        {
            var result = selected != null ? r.GetAll().Where(o => selected.Contains(o.Id)) : null;
            return View(@"Awesome\LookupList", result);
        }

        public ActionResult GetMultiple(IEnumerable<int> selected)
        {
            return Json(r.GetAll().Where(o => selected.Contains(o.Id)).Select(o => new { Text = o.Name }));
        }


    }
}