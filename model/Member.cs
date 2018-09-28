namespace _1dv607_w2.model
{
  class Member
  {
    private string _name;
    private string _ssn;
    private int _id;

    public Member(string name, string ssn, int id)
    {
      _name = name;
      _ssn = ssn;
      _id = id;
    }

    public string Name { get => _name; }
    public string Ssn { get => _ssn; }
    public int Id { get => _id; }

    public override string ToString() => $"{Name} {Ssn} {Id}";
  }
}