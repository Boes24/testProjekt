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

    [TestInitialize]
    public void SetupBeforeEachTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrdinationContext>();
        optionsBuilder.UseInMemoryDatabase(databaseName: "test-database");
        var context = new OrdinationContext(optionsBuilder.Options);
        service = new DataService(context);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void TC15()
    {
        service!.GetAnbefaletDosisPerDøgn(1, 2);
    }

    [TestMethod]
    public void TC16()
    {
        Assert.AreEqual(20, service!.GetAnbefaletDosisPerDøgn(2, 2));
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