using System;

namespace _1dv607_w2.view.console
{
  class StartMenu
  {
    public MenuSelection.Action GetAction()
    {
      switch (Console.ReadKey().KeyChar)
      {
        case '1': return MenuSelection.Action.Add;
        case '2': return MenuSelection.Action.Update;
        case '3': return MenuSelection.Action.Delete;
        case '4': return MenuSelection.Action.ViewMember;
        case '5': return MenuSelection.Action.ListCompact;
        case '6': return MenuSelection.Action.ListVerbose;
        case '7': return MenuSelection.Action.RegisterBoat;
        case '8': return MenuSelection.Action.DeleteBoat;
        case '9': return MenuSelection.Action.UpdateBoat;
        case 'q': return MenuSelection.Action.Quit;
        default: return MenuSelection.Action.None;
      }
    }

    public void DisplayMenu()
    {
      Console.Clear();
      Console.CursorVisible = false;
      Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║              Welcome to the Jolly pirates               ║");
      Console.WriteLine("║  _____________________________________________________  ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║   Choose one of the actions below by typing the         ║");
      Console.WriteLine("║   corresponding number. Press \"q\" to save and quit.     ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║      1. Add new member                                  ║");
      Console.WriteLine("║      2. Update member                                   ║");
      Console.WriteLine("║      3. Delete member                                   ║");
      Console.WriteLine("║      4. View member                                     ║");
      Console.WriteLine("║      5. Show compact list                               ║");
      Console.WriteLine("║      6. Show verbose list                               ║");
      Console.WriteLine("║      7. Register new boat                               ║");
      Console.WriteLine("║      8. Delete boat                                     ║");
      Console.WriteLine("║      9. Update boat                                     ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
    }

  }
}
