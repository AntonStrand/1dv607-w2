namespace _1dv607_w2.model
{
  class Boat
  {
    public enum Types
    {
      Sailboat,
      Motorsailer,
      Canoe,
      Other,
      Count
    }
    private Types _type;
    private Measurement _length;

    public Boat(Types type, Measurement length)
    {
      _type = type;
      _length = length;
    }

    public Types Type { get => _type; set => _type = value; }
    public Measurement Length { get => _length; }

    public void Update(Types type, Measurement length)
    {
      Type = type;
      _length = length;
    }
  }
}