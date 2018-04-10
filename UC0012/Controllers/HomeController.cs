using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC0012.Models;
using System.Web.Mvc;
using UC0012.Models;

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
		public ActionResult Cerca()
		{
			return View();
		}
		public ActionResult Ricerca(string id,string descrizione)
		{
			DomainModel dm = new DomainModel();
			int codice ;
			if (id !="" && int.TryParse(id,out codice)) {
				Prodotto prodotto = dm.SearchProdotto(codice);
				if (prodotto == null) {
					ViewBag.Message=$"Non è stato trovato alcun prodotto con questo codice";
					return View("Cerca");
				}
				ViewBag.prodotto = prodotto;
				return View("DettagliProdotto");
			} else {
				List<Prodotto> prodotti = dm.SearchProdotti(descrizione);
				if (prodotti == null) {
				ViewBag.Message=$"Non è stato trovato alcun prodotto con questa descrizione";
				}
				ViewBag.prodotti = prodotti;
				return View("ListaProdotti");
			}
		}

		public ActionResult Carrello(){
			List<Prodotto> list = Session["prodotti"] as List<Prodotto>;
			if(list !=null && list.Count>0){
				ViewBag.Prodotti = list;
			}else
				ViewBag.Message= "Non ci sono ordini";
			return View();
		}
	}
}