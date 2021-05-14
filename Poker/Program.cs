using System;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Cards from the players' hands:");
                string cardsLine = Console.ReadLine();


                Player black = new Player(cardsLine.Substring(0, 14));
                Player white = new Player(cardsLine.Substring(15));


                switch (CompareHands.Compare(white, black))
                {
                    case eResult.BlackWin:
                        Console.WriteLine("Black wins.");
                        break;
                    case eResult.WhiteWin:
                        Console.Write("White wins.");
                        break;
                    case eResult.Tie:
                        Console.WriteLine("Tie.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex}");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
