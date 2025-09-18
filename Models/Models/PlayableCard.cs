using System.Text.Json.Serialization;
using Models.Interfaces;

namespace Models.Models
{
	public class PlayableCard : IModel
    {
		public PlayableCard()
		{
		}

        public PlayableCard(Card c)
        {
			Card = c;
            Health = c.Health;
            Attack = c.Attack;
        }

        public int Id { get; set; }
		public virtual Card Card { get; set; }
		public int Health { get; set; }
        public int Attack { get; set; }

        // Si la carte à jouer est dans la pioche du joueur
        public int? CardsPileOwnerId { get; set; }
        [JsonIgnore]
        public virtual MatchPlayerData? CardsPileOwner { get; set; }

        // Si la carte à jouer est dans la main du joueur
        public int? HandOwnerId { get; set; }
        [JsonIgnore]
        public virtual MatchPlayerData? HandOwner { get; set; }

        // Si la carte à jouer est sur le champ de battaille du joueur
        public int? BattleFieldOwnerId { get; set; }
        [JsonIgnore]
        public virtual MatchPlayerData? BattleFieldOwner { get; set; }

        // Si la carte à jouer est au cimetière du joueur (elle a été tuée)
        public int? GraveyardOwnerId { get; set; }
	    [JsonIgnore]
        public virtual MatchPlayerData? GraveyardOwner { get; set; }
    }
}
