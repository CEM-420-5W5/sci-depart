using Models.Models;

namespace WebApi.Combat
{
    public class PlayerEndTurnEvent : MatchEvent
    {
        public override string EventType => "PlayerEndTurn";

        public int PlayerId { get; set; }
        // L'évènement lorsqu'un joueur termine son tour
        public PlayerEndTurnEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData opposingPlayerData, int nbManaPerTurn)
        {
            PlayerId = currentPlayerData.PlayerId;
            Events = [];

            match.IsPlayerATurn = !match.IsPlayerATurn;

            Events.Add(new PlayerStartTurnEvent(opposingPlayerData, nbManaPerTurn));
        }

    }
}
