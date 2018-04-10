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
		public ActionResult Cerca()
		{
			return View();
		}
        [HttpPost]
		public ActionResult Cerca(string id,string descrizione)
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
				return View("DettaglioProdotto");
			} else {
				List<Prodotto> prodotti = dm.SearchProdotti(descrizione);
				if (prodotti == null) {
				ViewBag.Message=$"Non è stato trovato alcun prodotto con questa descrizione";
				}
				ViewBag.prodotti = prodotti;
				return View("ListaProdotti");
			}
		}
		public ActionResult AddToCarrello(int id,string descrizione,int quantita)
		{
			Prodotto aggiunto = new Prodotto{Id=id,Descrizione=descrizione,QuantitaOrdinata=quantita };
			List<Prodotto> prodotti = Session["prodotti"] as List<Prodotto>;
            if(prodotti == null){ 
                prodotti = new List<Prodotto>();
            }
			prodotti.Add(aggiunto);
			Session["prodotti"] = prodotti;
			ViewBag.Message="Elemento aggiunto al carrello";
			return View("Cerca");
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