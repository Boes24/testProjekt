namespace ordination_test;

using Microsoft.EntityFrameworkCore;
using static shared.Util;
using Service;
using Data;
using shared.Model;

[TestClass]
public class PnTest
{
    public PnTest()
    {

    }

    Laegemiddel? lm;
    PN? ordination;

    [TestInitialize]
    public void SetupBeforeEachTest()
    {
        lm = new Laegemiddel("Paracetamol", 1, 1.5, 2, "Ml");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void TC4()
    {
        ordination = new PN(new DateTime(2023, 6, 20), new DateTime(2023, 6, 25), 2, lm!);
        ordination.givDosis(new Dato { DatoId = 100, dato = new DateTime(2023, 6, 19) });
    }

    [TestMethod]
    public void TC6()
    {
        ordination = new PN(new DateTime(2023, 6, 20), new DateTime(2023, 6, 25), 2, lm!);
        Assert.AreEqual(true, ordination.givDosis(new Dato { DatoId = 100, dato = new DateTime(2023, 6, 23) }));
    }

    [TestMethod]
    public void TC22()
    {
        ordination = new PN(new DateTime(2023, 6, 20), new DateTime(2023, 6, 22), -1, lm!);
        ordination.givDosis(new Dato { DatoId = 100, dato = new DateTime(2023, 6, 21) });
        Assert.AreEqual(-1,ordination.doegnDosis());
    }

    [TestMethod]
    public void TC23()
    {
        ordination = new PN(new DateTime(2023, 6, 20), new DateTime(2023, 6, 22), 4, lm!);
        Assert.AreEqual(0, ordination.doegnDosis());
    }

    [TestMethod]
    public void TC24()
    {
        ordination = new PN(new DateTime(2023, 6, 20), new DateTime(2023, 6, 25), 2, lm!);
        ordination.givDosis(new Dato { DatoId = 100, dato = new DateTime(2023, 6, 21) });
        ordination.givDosis(new Dato { DatoId = 101, dato = new DateTime(2023, 6, 22) });
        ordination.givDosis(new Dato { DatoId = 104, dato = new DateTime(2023, 6, 24) });
        ordination.givDosis(new Dato { DatoId = 104, dato = new DateTime(2023, 6, 25) });
        Assert.AreEqual(1.6, ordination.doegnDosis());
    }

    






}