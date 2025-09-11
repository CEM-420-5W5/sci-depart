using Models.Models;

namespace WebApi.Combat
{
    public class GainManaEvent : MatchEvent
    {
        public override string EventType => "GainMana";
        public int Mana { get; set; }
        public int PlayerId { get; set; }

        public GainManaEvent(MatchPlayerData playerData, int mana)
        {
            Mana = mana;
            PlayerId = playerData.PlayerId;
            playerData.Mana += mana;
        }
    }
}
