namespace _1dv607_w2.model
{
  class BoatFormData : Boat
  {
    public BoatFormData() : base(Type.None, new Measurement(1, Measurement.Unit.None))
    {
      _type = Type.None;
    }

    public BoatFormData(Type type, Measurement length) : base(type, length)
    {
      _type = type;
      _length = length;
    }

    public bool isValid() => _type != Type.None && _length != null;
  }
}