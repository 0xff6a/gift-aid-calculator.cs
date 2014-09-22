namespace GiftAidCalculatorCollaborators
{
  public class User
  {
    protected string privilege = "none";

    public bool IsAdmin()
    {
      return privilege == "admin";
    }
  }

  public class Admin : User
  {
    public Admin()
    {
      privilege = "admin";
    }
  }
}