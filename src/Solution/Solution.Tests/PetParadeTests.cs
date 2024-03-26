using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.PetParade;
using System;
using System.IO;

namespace Solution.PetParade.Tests
{
    [TestClass]
    public class PetParadeTests
    {
        [TestMethod]
        public void Kucing_Bersuara_ReturnsMeong()
        {
            var kucing = new Kucing("Milo");
            Assert.AreEqual("Meong", kucing.Bersuara());
        }

        [TestMethod]
        public void Anjing_Bersuara_ReturnsGuk()
        {
            var anjing = new Anjing("Rex");
            Assert.AreEqual("Guk", anjing.Bersuara());
        }

        [TestMethod]
        public void ParadeHewan_MulaiParade_DisplaysCorrectSounds()
        {
            var parade = new ParadeHewan();
            parade.TambahHewan(new Kucing("Milo"));
            parade.TambahHewan(new Anjing("Rex"));

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                parade.MulaiParade(1);

                var expected = "Milo bersuara: Meong" + Environment.NewLine + "Rex bersuara: Guk" + Environment.NewLine;
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void ParadeHewan_TambahDanHapusHewan_JumlahBenar()
        {
            // Membuat objek ParadeHewan dan menambahkan hewan
            var parade = new ParadeHewan();
            parade.TambahHewan(new Kucing("Milo"));
            parade.TambahHewan(new Anjing("Rex"));
            parade.TambahHewan(new Kucing("Luna"));

            // Memeriksa jumlah hewan setelah penambahan
            Assert.AreEqual(3, parade.ListHewan.Count, "Jumlah hewan setelah penambahan seharusnya 3.");

            // Menghapus hewan dan memeriksa jumlah hewan setelah penghapusan
            parade.HapusHewan(parade.ListHewan[0]); // Misalkan menghapus hewan pertama dalam list
            Assert.AreEqual(2, parade.ListHewan.Count, "Jumlah hewan setelah penghapusan seharusnya 2.");
        }

        [TestMethod]
        public void ParadeHewan_NamaHewanBenar_SetelahPenambahan()
        {
            // Membuat objek ParadeHewan dan menambahkan hewan
            var parade = new ParadeHewan();
            parade.TambahHewan(new Kucing("Milo"));
            parade.TambahHewan(new Anjing("Rex"));

            // Memeriksa nama hewan pertama yang ditambahkan
            Assert.AreEqual("Milo", parade.ListHewan[0].Nama, "Nama hewan pertama seharusnya Milo.");

            // Memeriksa nama hewan kedua yang ditambahkan
            Assert.AreEqual("Rex", parade.ListHewan[1].Nama, "Nama hewan kedua seharusnya Rex.");
        }


    }
}
