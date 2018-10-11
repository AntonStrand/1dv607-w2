namespace _1dv607_w2.model
{
  class Boat
  {
    public enum BoatType
    {
      Sailboat,
      Motorsailer,
      Canoe,
      Other,
      Count
    }
    private BoatType _type;
    private Measurement _length;

    public Boat(BoatType type, Measurement length)
    {
      _type = type;
      _length = length;
    }

    public BoatType Type { get => _type; set => _type = value; }
    public Measurement Length { get => _length; }

    public void Update(BoatType type, Measurement length)
    {
      Type = type;
      _length = length;
    }
  }
}