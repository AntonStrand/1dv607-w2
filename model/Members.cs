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

    public void SaveMembers() => _fileSystem.SaveAsJSON(_members);

    public void AddMember(string name, string ssn) => _members.Add(new Member(name, ssn, GenerateMemberId()));

    public void AddBoatToMemberAt(int index, BoatTypes.Type type, Measurement length) => _members[validateIndex(index)].AddBoat(new Boat(type, length));

    public void DeleteMemberAt(int index) => _members.RemoveAt(validateIndex(index));

    public void DeleteBoatAtFromMember(int index, Member member) => member.DeleteBoatAt(index);

    public Member GetMemberAt(int index) => _members[validateIndex(index)];

    public void UpdateMemberAt(int index, string name, string ssn)
    {
      index = validateIndex(index);
      _members[index].Name = name;
      _members[index].Ssn = ssn;
    }

    public ReadOnlyCollection<Member> GetMembers() => new ReadOnlyCollection<Member>(_members);

    private int GenerateMemberId() => _members.Count > 0 ? _members[_members.Count - 1].Id + 1 : 0;

    private void LoadMembers() => _members = _fileSystem.GetParsedJSON<Member>();


    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the index is out of range otherwise it will return the index.
    private int validateIndex(int index) => (index < 0 || index >= _members.Count)
        ? throw new ArgumentOutOfRangeException($"{index} is not a valid index.")
        : index;
  }
}