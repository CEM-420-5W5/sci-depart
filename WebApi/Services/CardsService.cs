using Models.Data;
using Models.Models;

namespace WebApi.Services
{
	public class CardsService
    {
        private ApplicationDbContext _dbContext;

        public CardsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OwnedCard> GetPlayersCards(string userId)
        {
            // Stub: Pour l'intant, le stub retourne simplement 2 copies des 10 premières cartes
            // L'implémentation réelle devra utiliser un service et retourner les cartes qu'un joueur possède
            // L'implémentation est la responsabilité de la personne en charge des [cartes]
            var cards = _dbContext.Cards.Take(10).ToList();
            var playersCards = cards.Concat(cards);

            // Pour l'instant on utilise l'index comme Id pour que chaque OwnedCard est un Id différent
            // Le champ player n'est pas utile pour l'instant, mais il devra être bien utilisé dans la vrai implémentation
            var ownedCards = playersCards.Select((card, index) => new OwnedCard() { Card = card, Id = index + 1 }).ToList();
            
            return ownedCards;
        }

        public IEnumerable<OwnedCard> GetPlayersCardsForMatch(string userId)
        {
            // Stub: Pour l'intant, le stub retourne simplement les cartes du joueur. Mais ça va être utile pour créer un Match avec les bonnes cartes.
            // L'implémentation réelle devra retourner les cartes du deck courrant
            // L'implémentation est la responsabilité de la personne en charge des [decks]
            return GetPlayersCards(userId);
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _dbContext.Cards;
        }
    }
}

