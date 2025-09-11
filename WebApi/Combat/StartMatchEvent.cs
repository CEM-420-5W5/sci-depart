using Models.Models;

namespace WebApi.Combat
{
    public class StartMatchEvent : MatchEvent
    {
        public override string EventType => "StartMatch";

        public StartMatchEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int nbCardsToDraw, int nbManaPerTurn)
        {
            Events =
            [
                new PlayerStartTurnEvent(currentPlayerData, nbManaPerTurn)
            ];

            // TODO: Faire piger le nombre de cartes de la configuration (nbCardsToDraw) au DEUX joueurs
        }
    }
}
