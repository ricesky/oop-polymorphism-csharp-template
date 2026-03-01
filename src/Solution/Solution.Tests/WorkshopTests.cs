using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.Workshop;

namespace Solution.Tests.Workshop
{
    [TestClass]
    public class WorkshopTests
    {
        [TestMethod]
        public void Kendaraan_Servis_Default_ServisUmum()
        {
            var k = new Kendaraan("L 0001 XX");
            Assert.AreEqual("Servis umum", k.Servis());
        }

        [TestMethod]
        public void Mobil_Servis_GantiOliCekRem()
        {
            var m = new Mobil("L 1234 AA");
            Assert.AreEqual("Ganti oli + cek rem", m.Servis());
        }

        [TestMethod]
        public void Motor_Servis_GantiOliCekRantai()
        {
            var m = new Motor("W 9876 BB");
            Assert.AreEqual("Ganti oli + cek rantai", m.Servis());
        }

        [TestMethod]
        public void Bengkel_Tambah_MenambahKendaraanKeList()
        {
            var bengkel = new Bengkel();
            bengkel.Tambah(new Mobil("L 1234 AA"));

            Assert.AreEqual(1, bengkel.ListKendaraan.Count);
            Assert.AreEqual("L 1234 AA", bengkel.ListKendaraan[0].Plat);
        }

        [TestMethod]
        public void ProsesServis_MenghasilkanOutput_SesuaiUrutan_DanPutaran()
        {
            var bengkel = new Bengkel();
            bengkel.Tambah(new Mobil("L 1234 AA"));
            bengkel.Tambah(new Motor("W 9876 BB"));

            var result = bengkel.ProsesServis(2);

            var expected =
                "L 1234 AA servis: Ganti oli + cek rem" + Environment.NewLine +
                "W 9876 BB servis: Ganti oli + cek rantai" + Environment.NewLine +
                "L 1234 AA servis: Ganti oli + cek rem" + Environment.NewLine +
                "W 9876 BB servis: Ganti oli + cek rantai";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ProsesServis_PutaranKurangAtauSamaDengan0_Throw()
        {
            var bengkel = new Bengkel();
            bengkel.Tambah(new Kendaraan("N 1111 CC"));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bengkel.ProsesServis(0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bengkel.ProsesServis(-1));
        }

        [TestMethod]
        public void ProsesServis_ListKosong_PutaranValid_MengembalikanStringKosong()
        {
            var bengkel = new Bengkel();
            var result = bengkel.ProsesServis(1);

            Assert.AreEqual(string.Empty, result);
        }
    }
}