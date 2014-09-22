using System.Collections;

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

  public class Event
  {
    private string type;
    private static Hashtable promotedTypes = PromotedTypesTable();

    private static Hashtable PromotedTypesTable()
    {
      Hashtable tbl = new Hashtable();

      tbl.Add("running", 5);
      tbl.Add("swimming", 3);

      return tbl;
    }
    
    public Event(string eventType)
    {
      setType(eventType);
    }

    public string Type 
    {
      get { return type; }
    }

    public bool IsPromoted()
    {
      return IsPromotedType(type);
    }

    private void setType(string eventType)
    {
      if(IsPromotedType(eventType))
        type = eventType;
      else
        type = "default";
    }

    private bool IsPromotedType(string eventType)
    {
      return promotedTypes.ContainsKey(eventType);
    }
  }
}