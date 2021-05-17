using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestWhitePlayerMethod()
        {
            
            Player black = new Player("2H 3D 5S 9C KD");
            Player white = new Player("2C 3H 4S 8C AH");

            Assert.IsTrue(CompareHands.Compare(white, black) == eResult.WhiteWin);
        }

        [TestMethod]
        public void TestBlackPlayerMethod()
        {

            Player black = new Player("2H 3D 5S 9C KD");
            Player white = new Player("2C 3H 4S 8C KH");

            Assert.IsTrue(CompareHands.Compare(white, black) == eResult.BlackWin);
        }

        [TestMethod]
        public void TestTieMethod()
        {

            Player black = new Player("2H 3D 5S 9C KD");
            Player white = new Player("2D 3H 5C 9S KH");

            Assert.IsTrue(CompareHands.Compare(white, black) == eResult.Tie);
        }
    }
}
