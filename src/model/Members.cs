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

    public void AddMember(Member member)
    {
      NullCheck<Member>(member);
      member.Id = GenerateMemberId();
      _members.Add(member);
    }

    public void DeleteMemberAt(int index) => _members.RemoveAt(ValidateIndex(index));

    public Member GetMemberAt(int index) => _members[ValidateIndex(index)];

    public void UpdateMemberAt(int index, Member memberData)
    {
      NullCheck<Member>(memberData);
      _members[ValidateIndex(index)].Update(memberData.Name, memberData.Ssn);
    }

    public void AddBoatToMemberAt(int index, Boat boat) =>
      _members[ValidateIndex(index)].AddBoat(NullCheck<Boat>(boat));

    public void DeleteMemberBoatAt(int index, Member member) =>
      member.DeleteBoatAt(index);

    public void UpdateMemberBoatAt(int index, Member member, Boat boatData) =>
      member.UpdateBoatAt(index, boatData);

    public ReadOnlyCollection<Member> GetMembers() => new ReadOnlyCollection<Member>(_members);

    private int GenerateMemberId() => _members.Count > 0 ? _members[_members.Count - 1].Id + 1 : 0;

    private void LoadMembers() => _members = _fileSystem.GetParsedJSON<Member>();


    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the index is out of range otherwise it will return the index.
    private int ValidateIndex(int index) => (index < 0 || index >= _members.Count)
      ? throw new ArgumentOutOfRangeException($"{index} is not a valid index.")
      : index;

    /// Throws an <see cref="NullReferenceException"/> if the test object is null otherwise it will return the test object.
    private T NullCheck<T>(T tester) => tester == null
      ? throw new System.NullReferenceException("This argument can't be null")
      : tester;
  }
}