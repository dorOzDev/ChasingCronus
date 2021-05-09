using Assets.Scripts.Cards;
using System;

namespace Assets.Scripts.GameLogics
{
    public interface IPositioner
    {
        CardData GetCardDataAtPosition(int position);
    }
}
