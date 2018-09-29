namespace _1dv607_w2.model
{
  class Boat
  {
    public enum Type
    {
      Sailboat,
      Motorsailer,
      Canoe,
      Other,
      Count,
      None
    }

    protected Type _type;
    protected Measurement _length;

    public Boat(Type type, Measurement length)
    {
      _type = type;
      _length = length;
    }

    public Type BoatType { get => _type; }
    public Measurement Length { get => _length; }
  }
}