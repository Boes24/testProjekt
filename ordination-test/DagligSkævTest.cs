namespace ordination_test;

using Microsoft.EntityFrameworkCore;
using static shared.Util;
using Service;
using Data;
using shared.Model;

[TestClass]
public class DagligSkævTest
{

    public DagligSkævTest()
    {

    }
    private DataService? service;

    Laegemiddel? lm;
    DagligSkæv? DagligSkævOrdination;

    [TestInitialize]
    public void SetupBeforeEachTest()
    {
        lm = new Laegemiddel("Paracetamol", 1, 1.5, 2, "Ml");
        DagligSkævOrdination = new DagligSkæv(new DateTime(2021, 1, 23), new DateTime(2021, 1, 24), lm);
    }

    [TestMethod]
    public void TC9()
    {
        ((DagligSkæv)DagligSkævOrdination!).doser = new Dosis[] {
                new Dosis(CreateTimeOnly(8, 0, 0), 1),
                new Dosis(CreateTimeOnly(12, 0, 0), 3),
                new Dosis(CreateTimeOnly(16, 0, 0), -5),
            }.ToList();
        Assert.AreEqual(DagligSkævOrdination.doegnDosis(), -1);
    }

    [TestMethod]
    public void TC10()
    {
        ((DagligSkæv)DagligSkævOrdination!).doser = new Dosis[] {
                new Dosis(CreateTimeOnly(8, 0, 0), 1),
                new Dosis(CreateTimeOnly(12, 0, 0), 3),
                new Dosis(CreateTimeOnly(16, 0, 0), -4),
            }.ToList();
        Assert.AreEqual(DagligSkævOrdination.doegnDosis(), 0);
    }

    [TestMethod]
    public void TC11()
    {
        ((DagligSkæv)DagligSkævOrdination!).doser = new Dosis[] {
                new Dosis(CreateTimeOnly(8, 0, 0), 1),
                new Dosis(CreateTimeOnly(12, 0, 0), 3),
                new Dosis(CreateTimeOnly(16, 0, 0), 5),
            }.ToList();
        Assert.AreEqual(DagligSkævOrdination.doegnDosis(), 9);
    }






}