using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.MusicStudio;

namespace Solution.Tests.MusicStudio
{
    [TestClass]
    public class MusicStudioTests
    {
        [TestMethod]
        public void Instrumen_Mainkan_Default_TidakAdaSuara()
        {
            var i = new Instrumen("Instrumen Umum");
            Assert.AreEqual("Tidak ada suara", i.Mainkan());
        }

        [TestMethod]
        public void Gitar_Mainkan_TringTring_And_HasJumlahSenar()
        {
            var g = new Gitar("Gitar Akustik", 6);
            Assert.AreEqual("tring tring", g.Mainkan());
            Assert.AreEqual(6, g.JumlahSenar);
        }

        [TestMethod]
        public void Piano_Mainkan_TinkTink_And_HasJumlahTuts()
        {
            var p = new Piano("Piano Klasik", 88);
            Assert.AreEqual("tink tink", p.Mainkan());
            Assert.AreEqual(88, p.JumlahTuts);
        }

        [TestMethod]
        public void StudioMusik_TambahInstrumen_Berfungsi()
        {
            var studio = new StudioMusik();
            studio.TambahInstrumen(new Instrumen("Instrumen Umum"));

            Assert.AreEqual(1, studio.ListInstrumen.Count);
            Assert.AreEqual("Instrumen Umum", studio.ListInstrumen[0].Nama);
        }

        [TestMethod]
        public void StudioMusik_MainkanInstrumen_MenggabungkanOutput_SesuaiFormat_DanUrutan()
        {
            var studio = new StudioMusik();
            studio.TambahInstrumen(new Gitar("Gitar Akustik", 6));
            studio.TambahInstrumen(new Piano("Piano Klasik", 88));

            var expected =
                "Gitar Akustik berbunyi: tring tring" + Environment.NewLine +
                "Piano Klasik berbunyi: tink tink";

            Assert.AreEqual(expected, studio.MainkanInstrumen());
        }

        [TestMethod]
        public void StudioMusik_MainkanInstrumen_Kosong_MengembalikanStringKosong()
        {
            var studio = new StudioMusik();
            Assert.AreEqual(string.Empty, studio.MainkanInstrumen());
        }
    }
}