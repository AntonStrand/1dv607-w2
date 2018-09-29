using System;
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

    public void DeleteMemberAt(int index) => _members.RemoveAt(index);
    public void UpdateMemberAt(int index, string name, string ssn) {
      if(index < 0 || index >= _members.Count)
        throw new ArgumentOutOfRangeException($"{index} is not a valid index.");

      _members[index].Name = name;
      _members[index].Ssn = ssn;
    } 

    public ReadOnlyCollection<Member> GetMembers() => new ReadOnlyCollection<Member>(_members);

    private int GenerateMemberId() => _members.Count > 0 ? _members[_members.Count - 1].Id + 1 : 0;

    private void LoadMembers() => _members = _fileSystem.GetParsedJSON<Member>();

    private void UpdateMembers()
    {
      _fileSystem.SaveAsJSON(_members);
      LoadMembers();
    }
  }
}