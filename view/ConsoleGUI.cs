using System;
using System.Collections.Generic;

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
      Console.WriteLine("╔═════════════════════════════════════════════════════╗");
      Console.WriteLine("║                                                     ║");
      Console.WriteLine("║            Welcome to the Jolly pirates             ║");
      Console.WriteLine("║  _________________________________________________  ║");
      Console.WriteLine("║                                                     ║");
      Console.WriteLine("║  Choose one of the actions below by typing the      ║");
      Console.WriteLine("║  corresponding number. Press \"q\" to quit.           ║");
      Console.WriteLine("║                                                     ║");
      Console.WriteLine("║    1. Add new member                                ║");
      Console.WriteLine("║    2. Update member                                 ║");
      Console.WriteLine("║    3. Delete member                                 ║");
      Console.WriteLine("║    4. Show compact list                             ║");
      Console.WriteLine("║    5. Show verbose list                             ║");
      Console.WriteLine("║                                                     ║");
      Console.WriteLine("╚═════════════════════════════════════════════════════╝");
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

    public List<string> DisplayAddMember()
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
        ? new List<string> { name, ssn }
        : answer == CANCEL
          ? new List<string>()
          : DisplayAddMember();
    }
  }
}
