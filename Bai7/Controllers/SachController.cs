using Bai7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai7.Controllers
{
    public class SachController : ApiController
    {
        Sach[] sachs = new Sach[]
        {
            new Sach { Id = 1, Title = "Tôi thấy hoa vàng trên cỏ xanh", AuthorName = "Nguyễn Nhật Ánh", Price = 1, Content = "Truyện kể về tuổi thơ..."},
            new Sach { Id = 2, Title = "Pro ASP.NET MVC5", AuthorName = "Adam Freeman", Content = "The ASP.NET MVC 5 Framework is the latest evolution of Microsoft's ASP.NET web platform.", Price = 3.75M},
        };
        private readonly object id;
        private object sach;

       /* public IEnumerable<Sach> GetAll()
        {
            return sachs;
        }
        /*  public IHttpActionResult GetSach(int id)
          {
              var sach = sachs.FirstOrDefault((p) => p.Id == id);
              if (sach == null)
              {
                  return NotFound();
              }
              return Ok(sach);
          }
          public IHttpActionResult DeleteSach(int id)
          {
              var sach = sachs.FirstOrDefault((p) => p.Id == id);
              if (sach == null)
              {

              }    
          }*/
        [HttpGet]
        public List<Sach> GetSachLists()
        {
            DbSachDataContext db = new DbSachDataContext();
            return sachs.ToList();
        }

        [HttpGet]
        public Sach Getsach(int id)
        {
            DbSachDataContext db = new DbSachDataContext();
            return sachs.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public bool InsertNewSach(int Id, string Title, string AuthorName, String Content, decimal Price)
        {
            try
            {
                DbSachDataContext db = new DbSachDataContext();
                Sach sach = new Sach();
                sach.Id = Id;
                sach.Title = Title;
                sach.AuthorName = AuthorName;
                sach.Content = Content;
                sach.Price = Price;
               /* db.sachs.InsertOnSubmit(sach);*/
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete]
        public bool DeleteSach(int id)
        {
            DbSachDataContext db = new DbSachDataContext();
            Sach sach = db.sachs.FirstOrDefault(x => int.Id == id);
            if (sach == null)
                return false;
           /* db.sachs.DeleteOnSubmit(sach);*/
            db.SubmitChanges();
            return true;
        }
         [HttpPut]
        public bool UpdateSach(int Id, string Title, string AuthorName, String Content, decimal Price)
        {
            try
            {
                DbSachDataContext db = new DbSachDataContext();
                Sach sach = db.sachs.FirstOrDefault(x => int.Id == id);
                if (sach == null)
                    return false;
                sach.Id = Id;
                sach.Title = Title;
                sach.AuthorName = AuthorName;
                sach.Content = Content;
                sach.Price = Price;
                /*db.sachs.InsertOnSubmit(sach);*/
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal class DbSachDataContext
        {
            internal object sachs;

            internal void SubmitChanges()
            {
                throw new NotImplementedException();
            }
        }
    }
}