namespace _1dv607_w2.model
{
  class MemberFormData
  {
    private string _name;
    private string _ssn;

    public MemberFormData(string name = "", string ssn = "")
    {
      _name = name;
      _ssn = ssn;
    }

    public bool IsValid() => Name.Length > 0 && Ssn.Length > 0;

    public string Name { get => _name; }
    public string Ssn { get => _ssn; }
  }

}
