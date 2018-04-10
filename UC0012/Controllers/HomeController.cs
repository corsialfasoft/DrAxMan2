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
        IDomainModel db = new DomainModel();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult DettaglioProdotto(Prodotto prodotto){
			List<Prodotto> prodotti = Session["prodotti"] as List<Prodotto>;
			if(prodotti != null && prodotti.Contains(prodotto)) { 
				ViewBag.prodotto = prodotti[prodotti.IndexOf(prodotto)];
			}else
				ViewBag.prodotto = prodotto;
			return View("DettaglioProdotto");
		}

        public ActionResult Define(String id)
		{   
            Prodotto prod = db.SearchProdotto(int.Parse(id));
            if(prod != null){ 
				return DettaglioProdotto(prod);
			} else{ 
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
			int codice ;
			if (id !="" && int.TryParse(id,out codice)) {
				Prodotto prodotto = db.SearchProdotto(codice);
				if (prodotto == null) {
					ViewBag.Message=$"Non è stato trovato alcun prodotto con questo codice";
					return View();
				}
				return DettaglioProdotto(prodotto);
			} else if(descrizione!="") {
				List<Prodotto> prodotti = db.SearchProdotti(descrizione);
				if (prodotti == null || prodotti.Count==0) {
					ViewBag.Message=$"Non è stato trovato alcun prodotto con questa descrizione";
					return View();
				}
				ViewBag.prodotti = prodotti;
			}else{
				ViewBag.Message = "Inserire almeno un campo per la ricerca";
				return View();
			}
			return View("ListaProdotti");
		}
		public ActionResult AddToCarrello(int id,int? quantita)
		{
			Prodotto prodotto = db.SearchProdotto(id);
			if (prodotto != null) {
				if(quantita == null || prodotto.Giacenza < quantita || quantita == 0) {
					ViewBag.Message = $"Inserire la quantita nel range da 1 a {prodotto.Giacenza}";
					ViewBag.prodotto = prodotto;
					return View("DettaglioProdotto");
				}
				List<Prodotto> prodotti = Session["prodotti"] as List<Prodotto>;
				if(prodotti == null){ 
					prodotti = new List<Prodotto>();
				}
				if (prodotti.Contains(prodotto)) {
					prodotti[prodotti.IndexOf(prodotto)].QuantitaOrdinata = (int)quantita;
				} else{ 
					Prodotto aggiunto = new Prodotto{Id=id,Descrizione=prodotto.Descrizione,QuantitaOrdinata=(int)quantita, Giacenza=prodotto.Giacenza };
					prodotti.Add(aggiunto);
				}
				Session["prodotti"] = prodotti;
				ViewBag.Message="Elemento aggiunto al carrello";
			}else
				ViewBag.Message = "Prodotto non è stato trovato ";
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
		public ActionResult Pulisci() {
			if (Session["prodotti"] !=null) {
				Session["prodotti"]= null;
				ViewBag.Message = "Carrello pulito";
			}
			return View("Cerca");
		}
		public ActionResult Ordina() {
			List<Prodotto> prodotti = Session["Prodotti"] as List<Prodotto>;
			if (prodotti != null && prodotti.Count > 0) {
				db.AddRichiesta(prodotti);
				Session["Prodotti"] = null;
				ViewBag.Message = $"Ordini esequiti";
			} else
				ViewBag.Message = $"Non ci stato ordini da confermare";
			return View("Cerca");
		}
	}
}