using System;
using System.Collections.Generic;
using _1dv607_w2.model;

namespace _1dv607_w2.view
{
  class ConsoleGUI
  {
    private const char YES = 'y';
    private const char NO = 'n';
    private const char CANCEL = 'c';

    public enum Action
    {
      Add,
      Update,
      Delete,
      ListCompact,
      ListVerbose,
      Quit,
      None,
    }
    public void DisplayActionMenu()
    {
      Console.Clear();
      Console.CursorVisible = false;
      Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║              Welcome to the Jolly pirates               ║");
      Console.WriteLine("║  _____________________________________________________  ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║   Choose one of the actions below by typing the         ║");
      Console.WriteLine("║   corresponding number. Press \"q\" to quit.              ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║      1. Add new member                                  ║");
      Console.WriteLine("║      2. Update member                                   ║");
      Console.WriteLine("║      3. Delete member                                   ║");
      Console.WriteLine("║      4. Show compact list                               ║");
      Console.WriteLine("║      5. Show verbose list                               ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
    }

    public Action GetAction()
    {
      switch (Console.ReadKey().KeyChar)
      {
        case '1': return Action.Add;
        case '2': return Action.Update;
        case '3': return Action.Delete;
        case '4': return Action.ListCompact;
        case '5': return Action.ListVerbose;
        case 'q': return Action.Quit;
        default: return Action.None;
      }
    }

    public MemberFormData DisplayAddMember()
    {
      Console.CursorVisible = true;
      Console.Clear();
      Console.WriteLine("Add member");
      Console.WriteLine("Please provide the required member information.\n");
      Console.Write("Name: ");
      string name = Console.ReadLine();
      Console.Write("Social Security Number: ");
      string ssn = Console.ReadLine();
      Console.Write($"Is this information correct ({YES}/{NO}) or {CANCEL} to cancel: ");
      char answer = Console.ReadKey().KeyChar;

      return answer == YES
        ? new MemberFormData(name, ssn)
        : answer == CANCEL
          ? new MemberFormData()
          : DisplayAddMember();
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
        foreach (model.Member m in members)
        {
          Console.WriteLine("║---------------------------------------------------------║");
          Console.WriteLine($"║  {m.Id,-5}  |  {m.Name,-24} |  {"0",15}  ║");
        }
      }
      else
      {
        DisplayNoMembers();
      }
      DisplayPressToGoBack();

      Console.ReadKey();
    }

    public int DisplayDeleteMember(ICollection<model.Member> members) => DisplayChooseMember("delete", members);
    public int DisplayUpdateMember(ICollection<model.Member> members) => DisplayChooseMember("update", members);

    private int DisplayChooseMember(string action, ICollection<model.Member> members)
    {
      Console.Clear();

      int number = 1;

      Console.WriteLine("╔═════════════════════════════════════════════════════════╗");

      if (members.Count > 0)
      {
        Console.WriteLine($"║  {"",5}   |  {"",-42}  ║");
        Console.WriteLine($"║  {"Number",5}  |  {"Name",-42}  ║");
        Console.WriteLine($"║  {"",5}   |  {"",-42}  ║");
        foreach (model.Member m in members)
        {
          Console.WriteLine("║---------------------------------------------------------║");
          Console.WriteLine($"║    {number,-4}  |  {m.Name,-42}  ║");
          number++;
        }
        Console.WriteLine("║---------------------------------------------------------║");
        Console.WriteLine("║                                                         ║");
        Console.WriteLine("║    Type in the number of the member you want to         ║");
        Console.WriteLine($"║    {action} or Press {CANCEL} to cancel.                         ║");
        Console.WriteLine("║                                                         ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
        string command = Console.ReadLine();
        int index = -1;

        if (int.TryParse(command, out index) && index > 0 && index <= members.Count + 1)
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

    private void DisplayNoMembers()
    {
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║             You need to add members first               ║");
      Console.WriteLine("║                                                         ║");
    }

    private void DisplayPressToGoBack()
    {
      Console.WriteLine("║---------------------------------------------------------║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║           Press any key to go back to menu              ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
    }
  }
}
