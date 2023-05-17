namespace ordination_test;

using Microsoft.EntityFrameworkCore;
using static shared.Util;
using Service;
using Data;
using shared.Model;

[TestClass]
public class AnbefaletDosisTest
{
    public AnbefaletDosisTest()
    {

    }
    private DataService? service;

    Laegemiddel? lm;
    Patient? patient;
    Patient? patientKG0;

    [TestInitialize]
    public void SetupBeforeEachTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrdinationContext>();
        optionsBuilder.UseInMemoryDatabase(databaseName: "test-database");
        var context = new OrdinationContext(optionsBuilder.Options);
        service = new DataService(context);

        lm = new Laegemiddel("Paracetamol", 1, 1.5, 2, "Ml");
        patient = new Patient("121256-0315", "Lars Hansen", 20);
        patientKG0 = new Patient("121257-0316", "Ulla Hansen", 0);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void TC15()
    {
        service!.GetAnbefaletDosisPerDøgn(patientKG0!, lm!);
    }

    [TestMethod]
    public void TC16()
    {
        Assert.AreEqual(patient!.vaegt*lm!.enhedPrKgPrDoegnLet, service!.GetAnbefaletDosisPerDøgn(patient!, lm!));
    }

    [TestMethod]
    public void TC17()
    {

    }
    [TestMethod]
    public void TC18()
    {

    }

    [TestMethod]
    public void TC19()
    {

    }

    [TestMethod]
    public void TC20()
    {

    }

    [TestMethod]
    public void TC21()
    {

    }






}