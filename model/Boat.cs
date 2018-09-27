namespace _1dv607_w2.model
{
  class Boat
  {
    public enum Type
    {
      Sailboat,
      Motorsailer,
      Canoe,
      Other
    }

    private Type _type;
    private int _length;

    public Boat(Type type, int length)
    {
      _type = type;
      _length = length;
    }
  }
}