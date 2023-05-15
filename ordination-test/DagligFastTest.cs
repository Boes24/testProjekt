namespace ordination_test;

using Microsoft.EntityFrameworkCore;
using static shared.Util;
using Service;
using Data;
using shared.Model;

[TestClass]
public class DagligFastTest
{
    public DagligFastTest()
    {

    }
    private DataService? service;

    Laegemiddel? lm;
    DagligFast? ordination;

    [TestInitialize]
    public void SetupBeforeEachTest()
    {
        lm = new Laegemiddel("Paracetamol", 1, 1.5, 2, "Ml");
        

    }

    [TestMethod]
    public void TC12()
    {
        ordination = new DagligFast(new DateTime(2023, 6, 21), new DateTime(2023, 6, 23), lm!, 2, 0, 1, -4);
        Assert.AreEqual(-1, ordination.doegnDosis());
    }

    [TestMethod]
    public void TC13()
    {
        ordination = new DagligFast(new DateTime(2023, 6, 21), new DateTime(2023, 6, 23), lm!, 0, 0, 0, 0);
        Assert.AreEqual(0, ordination.doegnDosis());
    }

    [TestMethod]
    public void TC14()
    {
        ordination = new DagligFast(new DateTime(2023, 6, 21), new DateTime(2023, 6, 23), lm!, 2, 0, 1, 0);
        Assert.AreEqual(3, ordination.doegnDosis());
    }






}