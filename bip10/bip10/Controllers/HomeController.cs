using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bip10.Models;

namespace bip10.Controllers
{
    public class HomeController : Controller
    {
        ggggggggEntities context = new ggggggggEntities();
        public ActionResult Expanate()
        {
            return View(context.expanate.ToList());
        }

        public ActionResult Hall()
        {
            return View(context.hall.ToList());
        }

        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
        public ActionResult Index()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("id_exp");
            dt.Columns.Add("name_exp");
            //creating rows
            foreach (var entity in context.expanate)
            {
               // var values = GetObjectValues(entity);
                dt.Rows.Add(entity.id_exp,entity.name_exp);
            }


            ViewBag.Exps = ToSelectList(dt, "id_exp", "name_exp");
           
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id_h");
            dt1.Columns.Add("name_h");
            //creating rows
            foreach (var entity1 in context.hall)
            {
                // var values = GetObjectValues(entity);
                dt1.Rows.Add(entity1.id_h, entity1.name_h);
            }
             ViewBag.H = ToSelectList(dt1, "id_h", "name_h");
           
             
             ViewData["Transfers"] = context.transfers;
           // ViewData["Expanate"] = context.expanate;
           // ViewData["Hall"] = context.hall;


            return View();
        }


    }
}