namespace _1dv607_w2.model
{
  class BoatFormData
  {

    private BoatTypes.Type _type;
    private Measurement _length;

    public BoatFormData() => _type = BoatTypes.Type.None;

    public BoatFormData(BoatTypes.Type type, Measurement length)
    {
      _type = type;
      _length = length;
    }

    public bool isValid() => _type != BoatTypes.Type.None && _length != null;

    public BoatTypes.Type Type { get => _type; }
    public Measurement Length { get => _length; }
  }
}