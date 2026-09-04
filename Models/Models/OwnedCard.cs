using System.Text.Json.Serialization;
using Models.Interfaces;

namespace Models.Models
{
    public class OwnedCard:IModel
	{
		public OwnedCard() { }

        public int Id { get; set; }
        public virtual Card Card { get; set; }
        [JsonIgnore]
        public virtual Player Player { get; set; }
    }
}

