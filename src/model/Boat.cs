namespace _1dv607_w2.model
{
  class Boat
  {
    private BoatTypes.Type _type;
    private Measurement _length;

    public Boat(BoatTypes.Type type, Measurement length)
    {
      _type = type;
      _length = length;
    }

    public BoatTypes.Type Type { get => _type; set => _type = value; }
    public Measurement Length { get => _length; }

    public void Update(BoatTypes.Type type, Measurement length)
    {
      Type = type;
      _length = length;
    }
  }
}