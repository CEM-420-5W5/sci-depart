using Models.Models;

namespace WebApi.Combat
{
    public class DrawCardEvent : MatchEvent
    {
        public override string EventType => "DrawCard";
        public int PlayableCardId { get; set; }
        public int PlayerId { get; set; }

        public DrawCardEvent(MatchPlayerData playerData)
        {
            if(playerData.CardsPile.Count > 0) {
                int lastElementIndex = playerData.CardsPile.Count() - 1;
                PlayableCard playableCard = playerData.CardsPile[lastElementIndex];

                PlayerId = playerData.PlayerId;
                PlayableCardId = playableCard.Id;

                playerData.CardsPile.RemoveAt(lastElementIndex);
                playerData.Hand.Add(playableCard);
            }
        }
    }
}
