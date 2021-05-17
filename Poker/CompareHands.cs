using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public static class CompareHands
    {
        public static eResult Compare(Player WhitePlayer, Player BlackPlayer)
        {
            var whitePlayerRank = WhitePlayer.Rank();
            var blackPlayerRank = BlackPlayer.Rank();

            if (whitePlayerRank > blackPlayerRank)
            {
                return eResult.WhiteWin;
            }
            if (whitePlayerRank < blackPlayerRank)
            {
                return eResult.BlackWin;
            }

            //escolha por carta mais alta
            for (int i = 0; i < 5; i++)
            {
                if (WhitePlayer.CardsValue()[i] > BlackPlayer.CardsValue()[i])
                    return eResult.WhiteWin;
                if (WhitePlayer.CardsValue()[i] < BlackPlayer.CardsValue()[i])
                    return eResult.BlackWin;
            }

            return eResult.Tie;
        }
    }
}
