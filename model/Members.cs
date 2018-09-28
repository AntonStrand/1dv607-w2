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
      foreach (Member m in _members)
      {
        System.Console.WriteLine(m.ToString());
      }
    }

    private void GetMembers() => _members = _fileSystem.GetParsedJSON<Member>();
  }
}