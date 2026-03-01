using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.PaymentSystem;

namespace Solution.Tests.PaymentSystem;

[TestClass]
public class PaymentSystemTests
{
    [TestMethod]
    public void MetodePembayaran_Bayar_Default_PembayaranDiproses()
    {
        var m = new MetodePembayaran("Metode Umum");
        Assert.AreEqual("Pembayaran diproses", m.Bayar(10000m));
    }

    [TestMethod]
    public void Cash_Bayar_FormatSesuai()
    {
        var c = new Cash("Tunai");
        Assert.AreEqual("Bayar tunai sebesar 50000", c.Bayar(50000m));
    }

    [TestMethod]
    public void Qris_Bayar_FormatSesuai_And_HasMerchantId()
    {
        var q = new Qris("QRIS", "M123");
        Assert.AreEqual("M123", q.MerchantId);
        Assert.AreEqual("Bayar QRIS ke M123 sebesar 75000", q.Bayar(75000m));
    }

    [TestMethod]
    public void Kartu_Bayar_FormatSesuai_And_HasNamaBank()
    {
        var k = new Kartu("Kartu", "BCA");
        Assert.AreEqual("BCA", k.NamaBank);
        Assert.AreEqual("Bayar kartu BCA sebesar 120000", k.Bayar(120000m));
    }

    [TestMethod]
    public void Kasir_Tambah_MenambahMetodeKeList()
    {
        var kasir = new Kasir();
        kasir.Tambah(new Cash("Tunai"));

        Assert.AreEqual(1, kasir.ListMetode.Count);
        Assert.AreEqual("Tunai", kasir.ListMetode[0].Nama);
    }

    [TestMethod]
    public void Kasir_Proses_MenghasilkanOutput_SesuaiFormat_DanUrutan()
    {
        var kasir = new Kasir();
        kasir.Tambah(new Cash("Tunai"));
        kasir.Tambah(new Qris("QRIS", "M123"));
        kasir.Tambah(new Kartu("Kartu", "BCA"));

        var result = kasir.Proses(50000m);

        var expected =
            "Tunai: Bayar tunai sebesar 50000" + Environment.NewLine +
            "QRIS: Bayar QRIS ke M123 sebesar 50000" + Environment.NewLine +
            "Kartu: Bayar kartu BCA sebesar 50000";

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Kasir_RingkasanQris_HanyaMemuatMetodeQris()
    {
        var kasir = new Kasir();
        kasir.Tambah(new Cash("Tunai"));
        kasir.Tambah(new Qris("QRIS-1", "M123"));
        kasir.Tambah(new Kartu("Kartu", "BCA"));
        kasir.Tambah(new Qris("QRIS-2", "M999"));

        var result = kasir.RingkasanQris();

        var expected =
            "QRIS-1: merchant=M123" + Environment.NewLine +
            "QRIS-2: merchant=M999";

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Kasir_Proses_ListKosong_MengembalikanStringKosong()
    {
        var kasir = new Kasir();
        Assert.AreEqual(string.Empty, kasir.Proses(10000m));
    }

    [TestMethod]
    public void Kasir_RingkasanQris_TanpaQris_MengembalikanStringKosong()
    {
        var kasir = new Kasir();
        kasir.Tambah(new Cash("Tunai"));
        kasir.Tambah(new Kartu("Kartu", "BCA"));

        Assert.AreEqual(string.Empty, kasir.RingkasanQris());
    }
}