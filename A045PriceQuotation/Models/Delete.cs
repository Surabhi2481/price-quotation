using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A045PriceQuotation.Models
{
    public class Delete
    {
    }
    /*


   
    public ActionResult vendor_login_check()
    {
        //  var a = db.PriceQuotations.Where(x => x.vendorid == Session["userid"].ToString());
        string d = Session["userid"].ToString();
        var b = (from c in db.PriceQuotations where c.vendorid == d && c.quotation == null select c).FirstOrDefault();  //check if there are any new quotation request if yes 
                                                                                                                        //redirect to vendor_login_2 else vendor_login

        if (b == null)
            return RedirectToAction("vendor_login");

        else
            return RedirectToAction("vendor_login_2");

    }

    public ActionResult vendor_login_2()
    {
        string a = Session["userid"].ToString();
        real obj = db.Reals.FirstOrDefault(x => x.id2 == a);
        if (obj.status2 == "reject")
            return View("request_pending");                  // displays registration pending 
        else
        {
            string id = Session["userid"].ToString();
            var a1 = (from d in db.Products where d.userId == id select d).ToList();                //display all products of that vendor
            return View(a1);
        }                                                                      //displays new quotation request
    }


   

    
    
    


    

   

    */

}