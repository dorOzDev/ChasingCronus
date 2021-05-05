using Assets.Scripts.Cards;

namespace Assets.Scripts.GameLogics
{
    public interface IPositioner
    {
        CardData GetCardDataAtPosition(int position);
    }
}
