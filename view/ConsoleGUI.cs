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
      RegisterBoat,
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
      Console.WriteLine("║      6. Register new boat                               ║");
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
        case '6': return Action.RegisterBoat;
        case 'q': return Action.Quit;
        default: return Action.None;
      }
    }

    public MemberFormData DisplayAddMember() => DisplayMemberForm("Add member");
    public MemberFormData GetUpdateMemberIndex() => DisplayMemberForm("Update member");

    public BoatFormData GetNewBoatInformation() => GetBoatInformation("Add new boat");

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
          Console.WriteLine($"║  {m.Id,-5}  |  {m.Name,-24} |  {m.NumberOfBoats,15}  ║");
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

      Console.WriteLine("╔═════════════════════════════════════════════════════════╗");

      if (members.Count > 0)
      {
        Console.WriteLine($"║  {"",-5}  |  {"",-24} |  {"",15}  ║");
        Console.WriteLine($"║  {"ID",-5}  |  {"Name",-24} |  {"Personal number",15}  ║");
        Console.WriteLine($"║  {"",-5}  |  {"",-24} |  {"",15}  ║");
        foreach (model.Member m in members)
        {
          Console.WriteLine("║---------------------------------------------------------║");
          // Console.WriteLine("║_________________________________________________________║");
          Console.WriteLine($"║  {"",-5}  |  {"",-24} |  {"",15}  ║");
          Console.WriteLine($"║  {m.Id,-5}  |  {m.Name,-24} |  {m.Ssn,-15}  ║");

          if (m.hasBoats)
          {
            Console.WriteLine("║---------------------------------------------------------║");
            Console.WriteLine("║         |  Boats  |  Length         |  Type             ║");
            Console.WriteLine("║---------------------------------------------------------║");

            for (int i = 0; i < m.NumberOfBoats; i++)
            {
              Boat b = m.Boats[i];
              Console.WriteLine($"║         |  {i + 1,-5}  |  {$"{b.Length.Value} {b.Length.MeasurementUnit}",-13}  |  {b.BoatType,-15}  ║");
            }
          }

        }
      }
      else
      {
        DisplayNoMembers();
      }
      DisplayPressToGoBack();

      Console.ReadKey();
    }

    public int GetDeleteMemberIndex(ICollection<model.Member> members) => DisplayChooseMember("delete", members);
    public int GetUpdateMemberIndex(ICollection<model.Member> members) => DisplayChooseMember("update", members);
    public int GetBoatOwnerIndex(ICollection<model.Member> members) => DisplayChooseMember("register a boat to", members);

    private MemberFormData DisplayMemberForm(string headline)
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
        ? new MemberFormData(name, ssn)
        : answer == CANCEL
          ? new MemberFormData()
          : DisplayMemberForm(headline);
    }

    private BoatFormData GetBoatInformation(string headline)
    {
      int typeCount = (int)Boat.Type.Count;
      int unitCount = (int)Measurement.Unit.Count;

      Console.CursorVisible = true;
      Console.Clear();
      Console.WriteLine(headline);
      Console.WriteLine("Please provide the required boat information.\n");
      Console.WriteLine($"Type of boat\n");

      for (int type = 0; type < typeCount; type++)
      {
        Console.WriteLine($"  {type + 1}. {(Boat.Type)type}");
      }

      Console.Write($"\nNumber (1-{typeCount}): ");
      string typeId = Console.ReadLine();
      int typeIndex;
      if (!int.TryParse(typeId, out typeIndex) || typeIndex < 1 || typeIndex > typeCount)
      {
        GetBoatInformation(headline);
      }

      Console.WriteLine($"\n\nSelect measurement unit\n");

      for (int unit = 0; unit < unitCount; unit++)
      {
        Console.WriteLine($"  {unit + 1}. {(Measurement.Unit)unit}");
      }

      Console.Write($"\nNumber (1-{unitCount}): ");
      string unitId = Console.ReadLine();

      int unitIndex;
      if (!int.TryParse(unitId, out unitIndex) || unitIndex < 1 || unitIndex > unitCount)
      {
        GetBoatInformation(headline);
      }

      Console.Write($"\n\nLength in {(Measurement.Unit)(unitIndex - 1)}: ");
      string lengthStr = Console.ReadLine();

      int length;
      if (!int.TryParse(lengthStr, out length) || length < 1)
      {
        GetBoatInformation(headline);
      }

      Console.Write($"\n\nIs this information correct ({YES}/{NO}) or {CANCEL} to cancel: ");
      char answer = Console.ReadKey().KeyChar;

      typeIndex -= 1;
      unitIndex -= 1;

      return answer == YES
        ? new BoatFormData((Boat.Type)typeIndex, new Measurement(length, (Measurement.Unit)unitIndex))
        : answer == CANCEL
          ? new BoatFormData()
          : GetBoatInformation(headline);
    }

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
        Console.WriteLine($"║    {$"{action} or Press {CANCEL} to cancel",-49}    ║");
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
