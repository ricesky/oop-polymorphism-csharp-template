using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.NotificationCenter;

namespace Solution.Tests.NotificationCenter
{
    [TestClass]
    public class NotificationCenterTests
    {
        [TestMethod]
        public void Notifikasi_Kirim_Default_NotifikasiTerkirim()
        {
            var n = new Notifikasi("TujuanA");
            Assert.AreEqual("Notifikasi terkirim", n.Kirim());
        }

        [TestMethod]
        public void EmailNotifikasi_Kirim_EmailTerkirim_And_HasSubjek()
        {
            var e = new EmailNotifikasi("user@example.com", "Hello");
            Assert.AreEqual("Email terkirim", e.Kirim());
            Assert.AreEqual("Hello", e.Subjek);
            Assert.AreEqual("user@example.com", e.Tujuan);
        }

        [TestMethod]
        public void SmsNotifikasi_Kirim_SMSTerkirim_And_HasProvider()
        {
            var s = new SmsNotifikasi("0812", "Telkomsel");
            Assert.AreEqual("SMS terkirim", s.Kirim());
            Assert.AreEqual("Telkomsel", s.Provider);
            Assert.AreEqual("0812", s.Tujuan);
        }

        [TestMethod]
        public void PusatNotifikasi_Tambah_MenambahKeList()
        {
            var pusat = new PusatNotifikasi();
            pusat.Tambah(new Notifikasi("A"));
            pusat.Tambah(new EmailNotifikasi("B", "Subjek"));

            Assert.AreEqual(2, pusat.ListNotifikasi.Count);
            Assert.AreEqual("A", pusat.ListNotifikasi[0].Tujuan);
            Assert.AreEqual("B", pusat.ListNotifikasi[1].Tujuan);
        }

        [TestMethod]
        public void KirimSemua_MenghasilkanOutput_SesuaiFormat_DanUrutan()
        {
            var pusat = new PusatNotifikasi();
            pusat.Tambah(new EmailNotifikasi("user@example.com", "Promo"));
            pusat.Tambah(new SmsNotifikasi("081234", "Telkomsel"));
            pusat.Tambah(new Notifikasi("internal"));

            var result = pusat.KirimSemua();

            var expected =
                "user@example.com: Email terkirim" + Environment.NewLine +
                "081234: SMS terkirim" + Environment.NewLine +
                "internal: Notifikasi terkirim";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DetailSemua_MenghasilkanDetailKhusus_DenganPatternMatching()
        {
            var pusat = new PusatNotifikasi();
            pusat.Tambah(new EmailNotifikasi("user@example.com", "Promo"));
            pusat.Tambah(new SmsNotifikasi("081234", "Telkomsel"));
            pusat.Tambah(new Notifikasi("internal"));

            var result = pusat.DetailSemua();

            var expected =
                "user@example.com: subjek=Promo" + Environment.NewLine +
                "081234: provider=Telkomsel" + Environment.NewLine +
                "internal: (tanpa detail)";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void KirimSemua_ListKosong_MengembalikanStringKosong()
        {
            var pusat = new PusatNotifikasi();
            Assert.AreEqual(string.Empty, pusat.KirimSemua());
        }

        [TestMethod]
        public void DetailSemua_ListKosong_MengembalikanStringKosong()
        {
            var pusat = new PusatNotifikasi();
            Assert.AreEqual(string.Empty, pusat.DetailSemua());
        }
    }
}