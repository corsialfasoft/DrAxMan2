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
		public int Descrizione { get; set; }
		public int Giacenza { get; set; }
		public int QuantitaOrdinata { get; set; }
	}

	public class DomainModel : IDomainModel {
		public void AddRichiesta(List<Prodotto> prodotti) {
			throw new NotImplementedException();
		}

		public List<Prodotto> SearchProdotti(string des) {
			throw new NotImplementedException();
		}

		public Prodotto SearchProdotto(int id) {
			throw new NotImplementedException();
		}
	}

}