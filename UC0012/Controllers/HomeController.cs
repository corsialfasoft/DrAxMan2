using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC0012.Models;
using System.Web.Mvc;

namespace UC0012.Controllers
{
	public class HomeController : Controller
	{
        IDomainModel db;
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult DettaglioProdotto(){
			return View();
		}

        public ActionResult Define(String id)
		{   
            db = new DomainModel();
            Prodotto prod = db.SearchProdotto(int.Parse(id));
            if(prod != null){ 
                ViewBag.prodotto = prod;
            }else{ 
                ViewBag.Message = "Prodotto inesistente";    
            }
			return View("DettaglioProdotto");
		}
        
		public ActionResult ListaProdotti(){
			return View();
		}
	}
}