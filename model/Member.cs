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

    public override string ToString()
    {
      return $"{_name} {_ssn} {_id}";
    }
  }
}