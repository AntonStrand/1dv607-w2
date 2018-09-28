using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _1dv607_w2.model
{
  class Members
  {
    private FileSystem _fileSystem;
    private List<Member> _members;

    public Members(FileSystem fileSystem)
    {
      _fileSystem = fileSystem;
      LoadMembers();
    }

    public void AddMember(string name, string ssn)
    {
      _members.Add(new Member(name, ssn, GenerateMemberId()));
      UpdateMembers();
    }

    public ReadOnlyCollection<Member> GetMembers()
    {
      return new ReadOnlyCollection<Member>(_members);
    }

    private int GenerateMemberId() => _members.Count > 0 ? _members[_members.Count - 1].Id + 1 : 0;

    private void LoadMembers() => _members = _fileSystem.GetParsedJSON<Member>();

    private void UpdateMembers()
    {
      _fileSystem.SaveAsJSON(_members);
      LoadMembers();
    }
  }
}