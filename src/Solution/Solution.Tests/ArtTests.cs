using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.Arts;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Arts.Tests;

[TestClass]
public class ArtTests
{
    [TestMethod]
    public void Lukisan_DeskrpsiDanTampilkan_ReturnsCorrectValues()
    {
        var lukisan = new Lukisan("Mona Lisa");
        Assert.AreEqual("Sebuah gambar yang dilukis di atas kanvas", lukisan.Deskripsi());
        Assert.AreEqual("Digantung di dinding", lukisan.Tampilkan());
    }

    [TestMethod]
    public void Patung_DeskrpsiDanTampilkan_ReturnsCorrectValues()
    {
        var patung = new Patung("Venus de Milo");
        Assert.AreEqual("Sebuah objek tiga dimensi yang dibentuk", patung.Deskripsi());
        Assert.AreEqual("Diletakkan di atas meja atau lantai", patung.Tampilkan());
    }

    [TestMethod]
    public void StudioSeni_TambahDanTampilkanSemuaKarya_ReturnsCorrectOutput()
    {
        var studio = new StudioSeni();
        studio.TambahKaryaSeni(new Lukisan("Starry Night"));
        studio.TambahKaryaSeni(new Patung("The Thinker"));

        Assert.AreEqual(2, studio.ListKarya.Count);
    }

    [TestMethod]
    public void StudioSeni_TampilkanSemuaKarya_ReturnsCorrectOutput()
    {
        // Inisialisasi studio seni dan tambahkan beberapa karya seni.
        var studio = new StudioSeni();
        studio.TambahKaryaSeni(new Lukisan("Starry Night"));
        studio.TambahKaryaSeni(new Patung("The Thinker"));

        // Mengalihkan output konsol ke StringWriter.
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);

            // Memanggil TampilkanSemuaKarya untuk menghasilkan output ke konsol (yang sekarang diarahkan ke stringWriter).
            studio.TampilkanSemuaKarya();

            // Mengembalikan output ke konsol standar.
            var output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("Starry Night"));
            Assert.IsTrue(output.Contains("Digantung di dinding"));
            Assert.IsTrue(output.Contains("The Thinker"));
            Assert.IsTrue(output.Contains("Diletakkan di atas meja atau lantai"));
        }
    }

}
