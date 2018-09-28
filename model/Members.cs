using System.Collections.Generic;

namespace _1dv607_w2.model
{
  class Members
  {
    private FileSystem _fileSystem;
    private List<Member> _members;

    public Members(FileSystem fileSystem)
    {
      _fileSystem = fileSystem;
      GetMembers();
    }

    public void AddMember(string name, string ssn)
    {
      _members.Add(new Member(name, ssn, GenerateMemberId()));
      UpdateMembers();
    }

    private int GenerateMemberId() => _members.Count > 0 ? _members[_members.Count - 1].Id + 1 : 0;

    private void GetMembers() => _members = _fileSystem.GetParsedJSON<Member>();

    private void UpdateMembers()
    {
      _fileSystem.SaveAsJSON(_members);
      GetMembers();
    }
  }
}