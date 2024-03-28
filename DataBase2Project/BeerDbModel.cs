using System.Runtime.Serialization;

namespace DataBase2Project
{
	public class BeerDbModel
	{
		[IgnoreDataMember]
        public int id { get; set; }
		public Guid uid { get; set; }
		public string brand { get; set; }
		public string name { get; set; }
		public string style { get; set; }
		public string hop { get; set; }
		public string yeast { get; set; }
		public string malts { get; set; }
		public string ibu { get; set; }
		public string alcohol { get; set; }
		public string blg { get; set; }
	
		public BeerDbModel(Guid uid, string brand, string name, string style, string hop, string yeast, string malts, string ibu, string alcohol, string blg) 
		{
			this.uid = uid;
			this.brand = brand;
			this.name = name;
			this.style = style;
			this.hop = hop;
			this.yeast = yeast;
			this.malts = malts;
			this.ibu = ibu;
			this.alcohol = alcohol;
			this.blg = blg;
		}

		public BeerDbModel(int id, Guid uid, string brand, string name, string style, string hop, string yeast, string malts, string ibu, string alcohol, string blg)
		{
			this.id = id;
			this.uid = uid;
			this.brand = brand;
			this.name = name;
			this.style = style;
			this.hop = hop;
			this.yeast = yeast;
			this.malts = malts;
			this.ibu = ibu;
			this.alcohol = alcohol;
			this.blg = blg;

		}
	}
}
