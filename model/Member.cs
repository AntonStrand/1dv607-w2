using System.Collections.Generic;

namespace _1dv607_w2.model
{
  class Member
  {
    private string _name;
    private string _ssn;
    private int _id;

    private List<Boat> _boats;

    public Member(string name, string ssn, int id)
    {
      _name = name;
      _ssn = ssn;
      _id = id;
      _boats = new List<Boat>();
    }

    public string Name { get => _name; set => _name = value; }
    public string Ssn { get => _ssn; set => _ssn = value; }
    public int Id { get => _id; }

    public int NumberOfBoats { get => _boats.Count; }
    public bool hasBoats { get => NumberOfBoats > 0; }

    public List<Boat> Boats { get => _boats; set => _boats = value; }

    public void AddBoat(Boat boat)
    {
      _boats.Add(boat);
    }

    public void DeleteBoatAt(int index) => _boats.RemoveAt(validateIndex(index));

    public void UpdateBoatAt(int index, BoatTypes.Type type, Measurement length) =>
      _boats[validateIndex(index)].update(type, length);

    public int validateIndex(int index) => (index < 0 && index >= NumberOfBoats)
      ? throw new System.ArgumentOutOfRangeException($"{index} is not a valid index.")
      : index;
  }
}