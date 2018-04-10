using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC0012.Models {
	interface IDomainModel{
		Prodotto SearchProdotto(int id);
		List<Prodotto> SearchProdotti(string des);
		void AddRichiesta(List<Prodotto> prodotti);
	}

	public class Prodotto {
		public int Id{ get; set;}
		public string Descrizione { get; set; }
		public int Giacenza { get; set; }
		public int QuantitaOrdinata { get; set; }
	}

	public class DomainModel : IDomainModel {
		public void AddRichiesta(List<Prodotto> prodotti) {
			using (db = new OrdiniEntities()) {
				OrdiniSet od =new OrdiniSet{data = DateTime.Now};
				db.OrdiniSet.Add(od);
				foreach(Prodotto pro in prodotti){
					OrdiniProdotti op =new OrdiniProdotti();
					op.OrdiniSet = od;
					op.quantita = pro.QuantitaOrdinata;
					op.ProdottiSet = db.ProdottiSet.Find(pro.Id);
					db.OrdiniProdotti.Add(op);
					db.SaveChanges();
				}
			}
		}

		public List<Prodotto> SearchProdotti(string des) {
			using (db = new OrdiniEntities()) {
				List<Prodotto> prodotti = new List<Prodotto>();
				var query = from pro in db.ProdottiSet
							where pro.descrizione.Contains(des)
							select pro;
				foreach(ProdottiSet pro in query){
					prodotti.Add(new Prodotto { Id = pro.Id, Descrizione = pro.descrizione, Giacenza = pro.quantita });
				}
				return prodotti;
			}
		}
		OrdiniEntities db = null;
		public Prodotto SearchProdotto(int id) {
			using(db = new OrdiniEntities()){
				Prodotto prodotto = null;
				ProdottiSet pro = db.ProdottiSet.Find(id);
				if(pro !=null){
					prodotto = new Prodotto { Id = pro.Id, Descrizione = pro.descrizione, Giacenza = pro.quantita};
				}
				return prodotto;
			}
		}
	}

}