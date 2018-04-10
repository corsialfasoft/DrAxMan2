using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC0012.Models

namespace UC0012.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

        
		public ActionResult ListaProdotti()
		{
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
	}
}