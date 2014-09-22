using NUnit.Framework;
using GiftAidCalculatorCollaborators;

namespace GiftAidCalculator.TestConsole
{
  [TestFixture]
  public class GiftAidCalculatorUsersTest
  {
    Admin admin = new Admin();
    User user = new User();

    [Test]
    public void BeingAnAdmin()
    {
      Assert.IsTrue(admin.IsAdmin());
    }

    [Test]
    public void NotAnAdmin()
    {
      Assert.IsFalse(user.IsAdmin());
    }
  }

  [TestFixture]
  public class GiftAidCalculatorEventTest
  {
    Event myEvent;
    Event runEvent;

    [SetUp]
    public void Init()
    {
      myEvent = new Event("sailing");
      runEvent = new Event("running");
    }

    [Test]
    public void EventType()
    { 
      Assert.AreEqual("running", runEvent.Type);
    }

    [Test]
    public void EventTypeNotPromoted()
    {
      Assert.AreEqual("default", myEvent.Type);
    }

    [Test]
    public void EventPromoted()
    { 
      Assert.IsTrue(runEvent.IsPromoted());
    }

    [Test]
    public void EventNotPromoted()
    {
      Assert.IsFalse(myEvent.IsPromoted());
    }

    [Test]
    public void GiftAidSupplementAdded()
    {
      Assert.AreEqual(5.0m, runEvent.GiftAidSupplement());
    }

    [Test]
    public void GiftAidSupplementNotAdded()
    {
      Assert.AreEqual(0.0m, myEvent.GiftAidSupplement());
    }
  }
}