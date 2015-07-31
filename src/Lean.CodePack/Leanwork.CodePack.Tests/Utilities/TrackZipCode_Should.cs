using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leanwork.CodePack.Tests.Utilities
{
    [TestClass]
    public class TrackZipCode_Should
    {
        [TestMethod]
        public void Return_state_by_cep()
        {
            //arrange
            string cep = "86080170";

            //act
            var track = BrazilianTrackPostalCode.GetTrackByPostalCode(cep);

            //assert
            Assert.AreEqual("PR", track.UF);
        }

        [TestMethod]
        public void Return_track_by_state()
        {
            //arrange
            string uf = "PR";

            //act
            var track = BrazilianTrackPostalCode.GetTracksByState(uf);

            //assert
            Assert.AreEqual(80000000, track.FirstOrDefault().Initial);
            Assert.AreEqual(87999999, track.FirstOrDefault().Final);
        }

        [TestMethod]
        public void Treatment_cep_invalid()
        {
            //arrange
            string cep = "AAAAAA";

            //act
            var track = BrazilianTrackPostalCode.GetTrackByPostalCode(cep);

            //assert
            Assert.AreEqual(String.Empty, track.State);
        }
    }
}
