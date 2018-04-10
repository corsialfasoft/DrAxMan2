﻿using System;
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
        IDomainModel db = new DomainModel();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult DettaglioProdotto(){
			return View();
		}

        public ActionResult Define(String id)
		{   
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
			int codice ;
			if (id !="" && int.TryParse(id,out codice)) {
				Prodotto prodotto = db.SearchProdotto(codice);
				if (prodotto == null) {
					ViewBag.Message=$"Non è stato trovato alcun prodotto con questo codice";
					return View("Cerca");
				}
				ViewBag.prodotto = prodotto;
				return View("DettaglioProdotto");
			} else {
				List<Prodotto> prodotti = db.SearchProdotti(descrizione);
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