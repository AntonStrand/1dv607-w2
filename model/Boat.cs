namespace _1dv607_w2.model
{
  class Boat
  {
    protected BoatTypes.Type _type;
    protected Measurement _length;

    public Boat(BoatTypes.Type type, Measurement length)
    {
      _type = type;
      _length = length;
    }

    public BoatTypes.Type Type { get => _type; set => _type = value; }
    public Measurement Length { get => _length; }
  }
}