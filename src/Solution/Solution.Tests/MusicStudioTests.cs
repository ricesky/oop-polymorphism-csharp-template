using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.MusicStudio;
using System.Collections.Generic;
using System.Linq;

namespace Solution.MusicStudio.Tests;

[TestClass]
public class MusicStudioTests
{
    [TestMethod]
    public void Gitar_Mainkan_ReturnsCorrectSound()
    {
        var gitar = new Gitar("Gitar Elektrik");
        Assert.AreEqual("tring tring", gitar.Mainkan());
    }

    [TestMethod]
    public void Piano_Mainkan_ReturnsCorrectSound()
    {
        var piano = new Piano("Upright Piano");
        Assert.AreEqual("tink tink", piano.Mainkan());
    }

    [TestMethod]
    public void StudioMusik_MainkanInstrumen_ReturnsCombinedSounds()
    {
        var studioMusik = new StudioMusik();
        studioMusik.TambahInstrumen(new Gitar("Gitar Akustik"));
        studioMusik.TambahInstrumen(new Piano("Grand Piano"));

        string expected = "Gitar Akustik berbunyi: tring tring" + Environment.NewLine + "Grand Piano berbunyi: tink tink" + Environment.NewLine;
        Assert.AreEqual(expected, studioMusik.MainkanInstrumen());
    }

    [TestMethod]
    public void StudioMusik_TambahDanHapusInstrumen_ManagesListCorrectly()
    {
        var studioMusik = new StudioMusik();
        var gitar = new Gitar("Gitar Akustik");
        var piano = new Piano("Grand Piano");

        studioMusik.TambahInstrumen(gitar);
        studioMusik.TambahInstrumen(piano);
        Assert.AreEqual(2, studioMusik.ListInstrumen.Count);

        studioMusik.ListInstrumen.Remove(gitar);
        Assert.IsFalse(studioMusik.ListInstrumen.Contains(gitar));
        Assert.AreEqual(1, studioMusik.ListInstrumen.Count);
    }
}
