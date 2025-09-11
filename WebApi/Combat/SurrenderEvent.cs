using Models.Models;

namespace WebApi.Combat
{
    public class SurrenderEvent : MatchEvent
    {
        public override string EventType => "Surrender";
        public int SurrenderingPlayerId { get; set; }

        // L'évènement lorsqu'un joueur joue une carte
        public SurrenderEvent(Match match, MatchPlayerData surrenderingPlayerData, MatchPlayerData opposingPlayerData)
        {
            SurrenderingPlayerId = surrenderingPlayerData.Player.Id;
            Events = [new EndMatchEvent(match, opposingPlayerData, surrenderingPlayerData)];
        }
    }
}
