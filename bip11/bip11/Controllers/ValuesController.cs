using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bip11.Models;
using Nest;
using DocumentFormat.OpenXml.Wordprocessing;

namespace bip11.Controllers
{
    [Route("api/[ValuesController]")]
    public class ValuesController : ApiController
    {

        ggggggggEntities context = new ggggggggEntities();
        ValuesController()
        {
            context.Configuration.ProxyCreationEnabled = false;
        }

        [Route("~/api/GetTransfers")]
        [HttpGet]
        public IEnumerable<transfers> GetTransfers()
        {
            return context.transfers;
        }

        [Route("~/api/GetHalls")]
        [HttpGet]
        public IEnumerable<hall> GetHalls()
        {
            return context.hall;
        }

        [Route("~/api/GetExps")]
        [HttpGet]
        public IEnumerable<expanate> GetExps()
        {
            return context.expanate;
        }

        [Route("~/api/Hall/{id?}")]
        [HttpGet]
        public string Hall(int id)
        {
            hall h = context.hall.Find(id);
            return h.name_h;
        }

        [Route("~/api/Exp/{id?}")]
        [HttpGet]
        public string Exp(int id)
        {
            expanate e = context.expanate.Find(id);
            return e.name_exp;
        }

        [Route("~/api/AddExp")]
        [HttpPost]
        public void AddExp([FromBody] expanate e)
        {
            context.expanate.Add(e);
            context.SaveChanges();
        }

        [Route("~/api/AddHall")]
        [HttpPost]
        public void AddHall([FromBody] hall h)
        {
            context.hall.Add(h);
            context.SaveChanges();
        }

        [Route("~/api/AddTr")]
        [HttpPost]
        public void AddTr([FromBody] transfers t)
        {
            context.transfers.Add(t);
            context.SaveChanges();
        }


        [Route("~/api/DeleteHall/{id?}")]
        [HttpDelete]
        public void DeleteHall(int id)
        {
            hall halls = context.hall.Find(id);
            context.hall.Remove(halls);
            context.SaveChanges();
        }

        [Route("~/api/DeleteExp/{id?}")]
        [HttpDelete]
        public void DeleteExp(int id)
        {
            expanate e = context.expanate.Find(id);
            context.expanate.Remove(e);
            context.SaveChanges();
        }

        [Route("~/api/DeleteTr/{id?}")]
        [HttpDelete]
        public void DeleteTr(int id)
        {
            transfers halls = context.transfers.Find(id);
            context.transfers.Remove(halls);
            context.SaveChanges();
        }
    }
}
