using A045PriceQuotation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A045PriceQuotation.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.mainClasss.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(mainClass usr)
        {
            if(ModelState.IsValid)
            {
                db.mainClasss.Add(usr);
                db.SaveChanges();
                return RedirectToAction("submitted");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured!");
            }
            return View(usr);
          
            
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(mainClass real1)
        {

            using (DataContext db = new DataContext())                      
            {
                mainClass obj = db.mainClasss.FirstOrDefault(user => user.userId == real1.userId && user.password == real1.password);
                if (obj == null)
                    return View("vendorRejected");
                

                if (obj != null)
                {
                    Session["userid"] = obj.userId;
                    if (obj.categoryId == categ.user)
                        return RedirectToAction("userProductList");
                    else if (obj.categoryId == categ.vendor)
                        return RedirectToAction("vendorLoginCheck");
                    else
                        return RedirectToAction("admin");
                }
            }
            return View(real1);
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Home");
        }

        public ActionResult userLoggedin()
        {
            return View();
        }

        public ActionResult vendorLogin(mainClass obj) 
        {

            if (obj.status == "reject")
                return View("reqPending");                   
            else
                return RedirectToAction("productList");                       
        }

        public ActionResult submitted()
        {
            return View("submitted");                                                             
        }

        public ActionResult approval(string id)
        {
            var a = db.mainClasss.First(x => x.userId == id);
            a.status = "accept";              
            db.SaveChanges();
            return View();                                                                                    

        }

        public ActionResult rejection(string id)
        {
            db.mainClasss.Remove(db.mainClasss.Where(p => p.userId == id).AsQueryable().ToList()[0]);                    
            return View();
        }

        public ActionResult admin()
        {
            List<mainClass> obj = new List<mainClass>();
            var obj1 = from a in db.mainClasss
                       where a.status != "accept"                                                 
                       select a;

            return View(obj1);

        }

        public JsonResult IsUserExists(string UserName)
        {
             
            return Json(!db.mainClasss.Any(x => x.userId == UserName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult addProduct()
        {
            return View();                                                       
        }

        [HttpPost]
        public ActionResult addProduct(product p)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(p);                                          
                db.SaveChanges();
                return RedirectToAction("productAdded");
            }
            return View();
        }

        public ActionResult productAdded()
        {
            return View();                                                       
        }

        public ActionResult productList()
        {
            string id = Session["userid"].ToString();
            var a1 = (from d in db.products                                          
                      where d.userId == id
                      select d).ToList();
            return View(a1);

        }

        public ActionResult editProduct(int id)
        {
            return View(db.products.Where(x => x.productId == id).FirstOrDefault());   
        }
        [HttpPost]
        public ActionResult editProduct(int id, product p)
        {
            db.Entry(p).State = EntityState.Modified;                                        
            db.SaveChanges();
            return RedirectToAction("productList");
        }


        public ActionResult productDetails(int id)
        {
            return View(db.products.Where(x => x.productId == id).FirstOrDefault());         
        }

        public ActionResult deleteProduct(int id)
        {
            return View(db.products.Where(x => x.productId == id).FirstOrDefault());     
        }

        [HttpPost]
        public ActionResult deleteProduct(int id, product p)
        {
            product p1 = db.products.Where(x => x.productId == id).FirstOrDefault();               
            db.products.Remove(p1);
            db.SaveChanges();
            return RedirectToAction("productList");
        }


        public ActionResult vendorProductDisplay(product p)
        {
            var a = db.products.Where(x => x.category == p.category).ToList();
            return View(a);
        }

        

        public ActionResult vendorSearchProduct()
        {
            return View("vendorSearchProduct");
        }


        [HttpPost]
        public ActionResult vendorSearchProduct(product p)
        {
            var a = (from d in db.products where d.category == p.category select d).ToList();
            return View("productList", a);
        }

        public ActionResult userProductList()
        {
            var a = (from d in db.products select d).ToList();
            return View(a);
        }

        

        public ActionResult userSearchProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult userSearchProduct(product p)
        {

            if (p.color == null)
            {

                var a = (from d in db.products where d.availability == p.availability && d.category == p.category select d).ToList();
                
                return View("userProductList", a);
            }
            else
            {
                var a = (from d in db.products where d.availability == p.availability && d.category == p.category && d.color == p.color select d).ToList();
                return View("userProductList", a);
            }
        }

       

        public ActionResult userProductDetails(int id)
        {
            return View(db.products.Where(x => x.productId == id).FirstOrDefault());
        }

        public ActionResult generateQuotation(int id)
        {
            pquotation a = new pquotation();
            a.productId = id;
            var p = db.products.Where(x => x.productId == id).FirstOrDefault();
            a.description = p.description;
            a.name = p.name;
            a.category = p.category;
            a.color = p.color;
            a.productId = id;
            a.availability = p.availability;            
            a.vendorId = p.userId;
            a.quantity = 1;
            a.userId = Session["userid"].ToString();
            a.status = "pending";
            a.vendorStatus = "pending";
            db.pquotations.Add(a);
            db.SaveChanges();

            return View(a);
        }
       

        
        [HttpPost]
        public ActionResult generateQuotation(pquotation c)
        {
            pquotation p = db.pquotations.Where(x => x.quotationId == c.quotationId).FirstOrDefault();
            pquotation a = new pquotation();
            a.productId = c.productId;

            a.availability = c.availability;
            a.category = c.category;
            a.color = c.color;
            a.description = c.description;
            a.name = c.name;
            product d = db.products.Where(x => x.productId == c.productId).FirstOrDefault();
            a.vendorId = d.userId;
            a.quantity = c.quantity;
            a.userId = Session["userid"].ToString();
            a.status = "pending";
            a.vendorStatus = "pending";

            db.pquotations.Remove(db.pquotations.Where(x => x.productId == d.productId).FirstOrDefault());
            db.pquotations.Add(a);

            db.SaveChanges();
            return View("quotationRequested");
        }

        
        public ActionResult vendorLoginCheck(mainClass obj)
        {
            
            string d = Session["userId"].ToString();
            var b = (from c in db.pquotations where c.vendorId == d select c).FirstOrDefault();
            if (b == null || b.status == "reject")
                return RedirectToAction("vendorLogin", obj);

            else
                return RedirectToAction("vendorLogin1", obj);

        }

        

        public ActionResult vendorLogin1(mainClass obj)
        {
            
            if (obj.status == "reject")
                return View("reqPending");                  
            else
            {
                string id = Session["userId"].ToString();
                var a1 = (from d in db.products where d.userId == id select d).ToList();                
                return View(a1);
            }                                                                    
        }
      
        public ActionResult vendorQuotation(int id)
        {

            
            return View(db.pquotations.Where(x => x.quotationId == id).FirstOrDefault());

        }
       

        [HttpPost]
        public ActionResult vendorQuotation(pquotation c)
        {
            pquotation p = db.pquotations.Where(x => x.quotationId == c.quotationId).FirstOrDefault();
            pquotation a = new pquotation();


            var p1 = db.products.Where(x => x.productId == c.productId).FirstOrDefault();
            a.availability = p.availability;
            a.productId = p.productId;
            a.category = p.category;
            a.color = p.color;
            a.description = p.description;
            a.name = p.name;
            var d = db.products.Where(x => x.productId == a.productId).FirstOrDefault();
            a.userId = p.userId;
            a.quantity = 2;
            a.vendorId = Session["userid"].ToString();
            a.status = "pending";
            a.quotation = c.quotation;
            a.vendorStatus = "accept";
            db.pquotations.Remove(db.pquotations.Where(x => x.productId == p.productId).FirstOrDefault());
            db.pquotations.Add(a);
            db.SaveChanges();
            return View("quotationSubmitted");

        }

        public ActionResult userQuotation()
        {
            string userid = Session["userid"].ToString();
            var a = (from d in db.pquotations where d.userId == userid select d).ToList();
            return View(a);
        }



        public ActionResult approveQuotation(int id)
        {
            pquotation c = db.pquotations.Where(a => a.quotationId == id).FirstOrDefault();
            if (c.vendorStatus == "pending")
            {
                return View("quotationStatusPending");
            }
            else
            {
                return RedirectToAction("Agreement", c);
            }
        }

        

        public ActionResult Agreement(pquotation p)
        {

            
            return View(p);

        }

        public ActionResult rejectQuotation(int id)
        {
            var a = db.pquotations.Where(c => c.quotationId == id).FirstOrDefault();
            if (a != null)
            {
                db.pquotations.Remove(a);
                db.SaveChanges();
            }
            
            return View();

        }

        public ActionResult vendorQuotationList()
        {
            string vendor = Session["userid"].ToString();
            var a = (from d in db.pquotations where d.vendorId == vendor && d.vendorStatus == "pending" select d).ToList();

            return View(a);

        }

        public ActionResult rejectQuotationVendor(int id)
        {
            var a = db.pquotations.Where(c => c.quotationId == id).FirstOrDefault();
            if (a != null)
            {
                db.pquotations.Remove(a);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult addCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addCategory(categoryProduct c)
        {
            db.categoryProducts.Add(c);
            db.SaveChanges();
            return RedirectToAction("vendorLoginCheck");
        }
        
        public ActionResult debitcard()
        {
            return View();
        }


        

        public ActionResult paymentDetail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult paymentDetail(account a)
        {

            if (ModelState.IsValid)
            {
                db.accounts.Add(a);                                            
                db.SaveChanges();
                return RedirectToAction("paymentSuccessfull");
            }
            return View();
        }

        public ActionResult paymentSuccessfull()
        {
            return View();
        }

        public ActionResult paymentMethod()
        {
            return View();
        }

        public ActionResult payment()
        {
            return View();
        }



    }




}
