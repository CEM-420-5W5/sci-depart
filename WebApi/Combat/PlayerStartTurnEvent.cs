using Models.Models;

namespace WebApi.Combat
{
    public class PlayerStartTurnEvent : MatchEvent
    {
        public override string EventType => "PlayerStartTurn";

        public int PlayerId { get; set; }
        // L'évènement lorsqu'un joueur débutte son tour
        public PlayerStartTurnEvent(MatchPlayerData playerData, int nbManaPerTurn)
        {
            PlayerId = playerData.PlayerId;
            Events = [];

            // TODO: Faire piger UNE carte (celle qui est pigé à chaque début de tour)
            // TODO: Faire gagner le Mana selon la configuration
        }

    }
}
