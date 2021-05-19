using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotePass;

namespace UnitTest_NotePass
{
    [TestClass]
    public class UnitTest_Model_Safe
    {
        NotePass.Model.Safe safe;

        [TestMethod]
        public void CallNewSafe()
        {
            // arrange
            NotePass.View.FrmMain frmMain = new NotePass.View.FrmMain("Super-2021");

            // act
            safe = new NotePass.Model.Safe(frmMain);

            // assert
            //Assert.AreEqual();
        }

        [TestMethod]
        public void OnAFormLoad()
        {
            // arrange

            // act

            // assert
        }

        [TestMethod]
        public void CreateAButtonWithAnEntry()
        {
            // arrange

            // act

            // assert
        }

        [TestMethod]
        public void AddValueIn()
        {
            // arrange

            // act

            // assert
        }
    }
}
