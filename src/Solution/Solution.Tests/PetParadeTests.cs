using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.PetParade;

namespace Solution.Tests.PetParade
{
    [TestClass]
    public class PetParadeTests
    {
        [TestMethod]
        public void Hewan_Bersuara_Default_TidakDiketahui()
        {
            var h = new Hewan("HewanUmum");
            Assert.AreEqual("Tidak diketahui", h.Bersuara());
        }

        [TestMethod]
        public void Kucing_Bersuara_Meong_And_HasWarnaBulu()
        {
            var k = new Kucing("Milo", "Putih");
            Assert.AreEqual("Meong", k.Bersuara());
            Assert.AreEqual("Putih", k.WarnaBulu);
        }

        [TestMethod]
        public void Anjing_Bersuara_Guk_And_HasLevelPatuh()
        {
            var a = new Anjing("Bobi", 5);
            Assert.AreEqual("Guk", a.Bersuara());
            Assert.AreEqual(5, a.LevelPatuh);
        }

        [TestMethod]
        public void ParadeHewan_TambahDanHapus_Berfungsi()
        {
            var parade = new ParadeHewan();
            var k = new Kucing("Milo", "Putih");

            parade.TambahHewan(k);
            Assert.AreEqual(1, parade.ListHewan.Count);

            parade.HapusHewan(k);
            Assert.AreEqual(0, parade.ListHewan.Count);
        }

        [TestMethod]
        public void MulaiParade_MencetakSesuaiUrutan_DanDiulangSesuaiPutaran()
        {
            var parade = new ParadeHewan();
            parade.TambahHewan(new Kucing("Milo", "Putih"));
            parade.TambahHewan(new Anjing("Bobi", 3));

            var sw = new StringWriter();
            TextWriter originalOut = Console.Out;

            try
            {
                Console.SetOut(sw);

                parade.MulaiParade(2);

                var expected =
                    "Milo bersuara: Meong" + Environment.NewLine +
                    "Bobi bersuara: Guk" + Environment.NewLine +
                    "Milo bersuara: Meong" + Environment.NewLine +
                    "Bobi bersuara: Guk" + Environment.NewLine;

                Assert.AreEqual(expected, sw.ToString());
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }

        [TestMethod]
        public void MulaiParade_PutaranKurangAtauSamaDengan0_Throw()
        {
            var parade = new ParadeHewan();
            parade.TambahHewan(new Hewan("HewanUmum"));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => parade.MulaiParade(0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => parade.MulaiParade(-1));
        }
    }
}