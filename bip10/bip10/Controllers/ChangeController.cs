using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using bip10.Models;

namespace bip10.Controllers
{
    public class ChangeController : Controller
    {
        ggggggggEntities context = new ggggggggEntities();
        // GET: Change
        public ActionResult Exp(FormCollection form)
        {
            if (form["id_e"] != "" && form["name_e"] != "" && form["autor_e"] != "")
            {
                int id = int.Parse(form["id_e"]);
                string ex = Convert.ToString(form["name_e"]);
                string exp = ex.Replace("                ", "");
                string au = Convert.ToString(form["autor_e"]);
                string author = au.Replace("                ", "");
                var e = context.expanate.FirstOrDefault(x => x.id_exp == id);
                e.name_exp = exp;
                e.autor_exp = author;
                context.SaveChanges();
            }
            return Redirect(Url.Action("Expanate", "Home"));
            
        }

        public ActionResult Exp_Add(FormCollection form)
        {
            //  int id = int.Parse(form["id_e"]);
            string n = Convert.ToString(form["name_add"]);

            // string name = n.Replace("                ", "");
            string a = Convert.ToString(form["autor_add"]);

            expanate ex = new expanate()
            {
                name_exp = n,
                autor_exp = a
            };
            context.expanate.Add(ex);
            context.SaveChanges();

            return Redirect(Url.Action("Expanate", "Home"));
        }

        public ActionResult Hall(FormCollection form)
        {
            if (form["id_e"] != "" && form["name_e"] != "" && form["space_e"] != "")
            {
                int id = int.Parse(form["id_e"]);
                string n = Convert.ToString(form["name_e"]);
                string name = n.Replace("                ", "");
                string space = int.Parse(form["space_e"]).ToString();
                var e = context.hall.FirstOrDefault(x => x.id_h == id);
                e.name_h = name;
                e.space_h = space;
                context.SaveChanges();
            }

            return Redirect(Url.Action("Hall", "Home"));
        }

        public ActionResult Hall_Add(FormCollection form)
        {
            //  int id = int.Parse(form["id_e"]);
                string n = Convert.ToString(form["name_add"]); 
                
               // string name = n.Replace("                ", "");
                string space = int.Parse(form["space_add"]).ToString();
               
               hall new_hall = new hall()
               {
                    name_h = n,
                    space_h = space
               };
               context.hall.Add(new_hall);
                context.SaveChanges();

                return Redirect(Url.Action("Hall", "Home"));
        }

        public ActionResult Index(FormCollection form)
        {
            
            var id = Convert.ToInt32(form["id_tr_e"]);
            var ex = Convert.ToInt32(form["id_exp_e"]);
            var h = Convert.ToInt32(form["id_h_e"]);
            var date = Convert.ToDateTime(form["date_e"]);
           // var stay = Convert.ToInt32(form["stay_e"]);

            var ch_t = context.transfers.FirstOrDefault(x => x.id_tr == id);
            ch_t.id_exp_fk = ex;
            ch_t.id_h_fk =h;
            ch_t.date = Convert.ToDateTime(date);
           // ch_t.stay = stay;
            context.SaveChanges();

            return Redirect(Url.Action("Index", "Home"));
        }


        public ActionResult Index_Add(FormCollection form)
        {

            var ex = Convert.ToInt32(form["id_exp_add"]);
            var h = Convert.ToInt32(form["id_h_add"]);
            var date = Convert.ToDateTime(form["date_add"]);

            transfers new_tr = new transfers()
            {
                id_exp_fk = ex,
                id_h_fk = h,
                date = date
            };
            context.transfers.Add(new_tr);
            context.SaveChanges();

            return Redirect(Url.Action("Index", "Home"));
        }

        public ActionResult Delete(int id)
        {
            var ch_t = context.transfers.Where(x => x.id_tr == id).FirstOrDefault();
            context.transfers.Remove(ch_t);
            context.SaveChanges();
            return Redirect(Url.Action("Index", "Home"));
        }

    }
}