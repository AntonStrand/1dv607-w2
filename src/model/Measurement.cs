namespace _1dv607_w2.model
{
  class Measurement
  {
    public enum Unit
    {
      Feet,
      Meter,
      Count,
      None
    }

    private Unit _unit;
    private int _value;

    public Measurement(int value, Unit unit)
    {
      Value = value;
      _unit = unit;
    }

    public int Value
    {
      get => _value;
      set => _value = value <= 0
        ? throw new System.ArgumentOutOfRangeException($"The value has to be more than 0")
        : value;
    }

    public Unit MeasurementUnit
    {
      get => _unit;
      set => _unit = value;
    }
  }
}