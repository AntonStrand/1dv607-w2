using System;
using System.Collections.Generic;
using _1dv607_w2.model;

namespace _1dv607_w2.view.console
{
  class MemberView : ConsoleBase
  {
    public Member DisplayMemberForm(string headline)
    {
      Console.CursorVisible = true;
      Console.Clear();
      Console.WriteLine(headline);
      Console.WriteLine("Please provide the required member information.\n");
      Console.Write("Name: ");
      string name = Console.ReadLine();
      Console.Write("Social Security Number: ");
      string ssn = Console.ReadLine();
      Console.Write($"Is this information correct ({YES}/{NO}) or {CANCEL} to cancel: ");
      char answer = Console.ReadKey().KeyChar;

      return answer == YES
        ? new Member(name, ssn)
        : answer == CANCEL
          ? null
          : DisplayMemberForm(headline);
    }

    public void DisplayMember(Member member)
    {
      Console.CursorVisible = false;
      Console.Clear();

      DisplayMemberData(member);

      Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
      DisplayPressToGoBack();

      Console.ReadKey();
    }

    public int DisplayChooseMember(string action, ICollection<model.Member> members)
    {
      Console.Clear();

      int number = 1;

      Console.WriteLine("╔═════════════════════════════════════════════════════════╗");

      if (members.Count > 0)
      {
        Console.WriteLine($"║  {"",5}   |  {"",-42}  ║");
        Console.WriteLine($"║  {"Number",5}  |  {"Name",-42}  ║");
        Console.WriteLine($"║  {"",5}   |  {"",-42}  ║");
        foreach (Member m in members)
        {
          Console.WriteLine("║---------------------------------------------------------║");
          Console.WriteLine($"║    {number,-4}  |  {m.Name,-42}  ║");
          number++;
        }
        Console.WriteLine("║---------------------------------------------------------║");
        Console.WriteLine("║                                                         ║");
        Console.WriteLine("║    Type in the number of the member you want to         ║");
        Console.WriteLine($"║    {$"{action} or press {CANCEL} to cancel",-49}    ║");
        Console.WriteLine("║                                                         ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
        string command = Console.ReadLine();
        int index = -1;

        if (int.TryParse(command, out index) && index > 0 && index <= members.Count)
        {
          Console.Write($"Are you sure? ({YES}/{NO}) or {CANCEL} to cancel: ");
          char answer = Console.ReadKey().KeyChar;

          return answer == YES
            ? index - 1
            : answer == CANCEL
              ? -1
              : DisplayChooseMember(action, members);
        }
        else
        {
          return command == CANCEL.ToString()
              ? -1
              : DisplayChooseMember(action, members);
        }
      }
      else
      {
        DisplayNoMembers();
        DisplayPressToGoBack();
        Console.ReadKey();
      }

      return -1;
    }

    public void DisplayCompactList(ICollection<model.Member> members)
    {
      Console.CursorVisible = false;
      Console.Clear();

      Console.WriteLine("╔═════════════════════════════════════════════════════════╗");

      if (members.Count > 0)
      {
        Console.WriteLine($"║  {"",-5}  |  {"",-24} |  {"",15}  ║");
        Console.WriteLine($"║  {"ID",-5}  |  {"Name",-24} |  {"Number of boats",15}  ║");
        Console.WriteLine($"║  {"",-5}  |  {"",-24} |  {"",15}  ║");
        Console.WriteLine("║---------------------------------------------------------║");
        foreach (Member m in members)
        {
          Console.WriteLine($"║  {m.Id,-5}  |  {m.Name,-24} |  {m.NumberOfBoats,15}  ║");
          Console.WriteLine("║---------------------------------------------------------║");
        }
      }
      else
      {
        DisplayNoMembers();
      }
      DisplayPressToGoBack();

      Console.ReadKey();
    }

    public void DisplayVerboseList(ICollection<model.Member> members)
    {
      Console.CursorVisible = false;
      Console.Clear();


      if (members.Count > 0)
      {
        foreach (Member m in members)
        {
          DisplayMemberData(m);
        }
        Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
      }
      else
      {
        Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
        DisplayNoMembers();
      }
      DisplayPressToGoBack();

      Console.ReadKey();
    }
  }
}