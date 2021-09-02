using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models.db;
using System.Net;

namespace PhoneStore.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        PhoneStoreEntities db = new PhoneStoreEntities();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            List<brand> brands = db.brands.ToList();
            return View(brands);
        }
        public ActionResult addBrand()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addBrand([Bind(Include = "id,activeFlag,createDate,updateDate")] brand brands, string name, HttpPostedFileBase logo)
        {
            /*  string fileName = System.IO.Path.GetFileName(logo.FileName);
              string urlImage = Server.MapPath("~/Image/logo/" + fileName);
              logo.SaveAs(urlImage);
              brands.logo = "Image/logo/" + fileName;
              brands.name = name;
              brands.activeFlag = 1;
              brands.createDate = DateTime.Now;
              brands.updateDate = DateTime.Now;
              db.brands.Add(brands);
              db.SaveChanges();
              return RedirectToAction("Index");*/

            /*  string fileName = System.IO.Path.GetFileName(logo.FileName);
              string urlImage = Server.MapPath("~/Image/logo/" + fileName);
              logo.SaveAs(urlImage);
              brands.logo = "Image/logo/" + fileName;
              brands.name = name;
              brands.activeFlag = 1;
              brands.createDate = DateTime.Now;
              brands.updateDate = DateTime.Now;
              db.brands.Add(brands);
              db.SaveChanges();
              return RedirectToAction("Index");*/

            /*if (ModelState.IsValid)
            {


            }
            else
            {
                if(logo !=null && logo.ContentLength>0)
                {
                    string fileName = System.IO.Path.GetFileName(logo.FileName);
                    string urlImage = Server.MapPath("~/Image/logo/" + fileName);
                    logo.SaveAs(urlImage);
                    brands.logo = "Image/logo/" + fileName;
                    brands.name = name;
                    brands.activeFlag = 1;
                    brands.createDate = DateTime.Now;
                    brands.updateDate = DateTime.Now;
                    db.brands.Add(brands);
                    db.SaveChanges();
                    return RedirectToAction("Index");*/


            if (logo != null && logo.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(logo.FileName);



                string urlImage = Server.MapPath("~/Content/client/img/product/" + fileName);
                logo.SaveAs(urlImage);
                brands.logo = fileName;


                brands.name = name;
                brands.activeFlag = 1;
                brands.createDate = DateTime.Now;
                brands.updateDate = DateTime.Now;
                db.brands.Add(brands);
                db.SaveChanges();
                return RedirectToAction("Index");



            }

            if (ModelState.IsValid)
            {


            }
            return View(brands);

        }

        internal bool checkName(string name)
        {
            var temp = db.brands.Where(m => m.name.Equals(name)).ToList();
            if (temp.Count == 0)
                return true;
            return false;
        }
        // GET :Brand/Delete /
        public ActionResult Delete(int id)
        {
            brand modifybrand = db.brands.Find(id);
            if (modifybrand == null)
            {
                return HttpNotFound();
            }
            modifybrand.activeFlag = 0;
            /* db.Entry(modifybrand).State = EntityState.Modified;*/
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        // GET:Brand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brand brand = db.brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        // POST: Brand/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,activeFlag,createDate,updateDate")] brand brand, string editname, HttpPostedFileBase editlogo)
        {
            if (ModelState.IsValid)
            {
                brand modifybrand = db.brands.Find(brand.Id);
                if (modifybrand != null)
                {
                    if (editlogo != null && editlogo.ContentLength > 0)
                    {

                        string fileName = System.IO.Path.GetFileName(editlogo.FileName);
                        string urlImage = Server.MapPath("~/Image/" + fileName);
                        editlogo.SaveAs(urlImage);
                        modifybrand.name = editname;
                        modifybrand.updateDate = DateTime.Now;
                        modifybrand.logo = "Image/" + fileName;
                        modifybrand.updateDate = DateTime.Now;
                    }
                    else
                    {
                        modifybrand.name = editname;
                        modifybrand.updateDate = DateTime.Now;

                    }
                }
                /*db.Entry(modifybrand).State = EntityState.Modified;*/
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }
    }
}