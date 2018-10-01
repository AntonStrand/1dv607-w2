using System;
using System.Collections.Generic;
using _1dv607_w2.model;

namespace _1dv607_w2.view
{
  class ConsoleUI
  {
    private const char YES = 'y';
    private const char NO = 'n';
    private const char CANCEL = 'c';

    public enum Action
    {
      Add,
      Update,
      Delete,
      ViewMember,
      ListCompact,
      ListVerbose,
      RegisterBoat,
      DeleteBoat,
      UpdateBoat,
      Quit,
      None,
    }

    public Action GetAction()
    {
      switch (Console.ReadKey().KeyChar)
      {
        case '1': return Action.Add;
        case '2': return Action.Update;
        case '3': return Action.Delete;
        case '4': return Action.ViewMember;
        case '5': return Action.ListCompact;
        case '6': return Action.ListVerbose;
        case '7': return Action.RegisterBoat;
        case '8': return Action.DeleteBoat;
        case '9': return Action.UpdateBoat;
        case 'q': return Action.Quit;
        default: return Action.None;
      }
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

    public MemberFormData DisplayAddMember() => DisplayMemberForm("Add member");
    public MemberFormData GetUpdateMemberInformation() => DisplayMemberForm("Update member");

    public BoatFormData GetNewBoatInformation() => GetBoatInformation("Add new boat");
    public BoatFormData GetUpdatedBoatInformation() => GetBoatInformation("Update boat");

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
        foreach (model.Member m in members)
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
        foreach (model.Member m in members)
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

    public void DisplayMember(Member member)
    {
      Console.CursorVisible = false;
      Console.Clear();

      DisplayMemberData(member);

      Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
      DisplayPressToGoBack();

      Console.ReadKey();
    }

    public int GetBoatIndex(Member member)
    {
      Console.CursorVisible = true;
      Console.Clear();
      if (member.hasBoats)
      {
        DisplayMemberData(member);
        Console.Write("\nEnter the number associated to the boat: ");
        string boatId = Console.ReadLine();
        int index;

        if (!int.TryParse(boatId, out index) || index < 1 || index > member.NumberOfBoats)
        {
          GetBoatIndex(member);
        }

        Console.Write($"\n\nIs this information correct ({YES}/{NO}) or {CANCEL} to cancel: ");
        char answer = Console.ReadKey().KeyChar;

        return answer == YES
          ? (index - 1)
          : answer == CANCEL
            ? -1
            : GetBoatIndex(member);

      }
      else
      {
        Console.CursorVisible = false;
        Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                         ║");
        Console.WriteLine("║         This member doesn't own any boats yet.          ║");
        Console.WriteLine("║                                                         ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
        Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
        DisplayPressToGoBack();

        Console.ReadKey();
        return -1;
      }
    }

    public int GetDeleteMemberIndex(ICollection<model.Member> members) => DisplayChooseMember("delete", members);
    public int GetUpdateMemberIndex(ICollection<model.Member> members) => DisplayChooseMember("update", members);
    public int GetViewMemberIndex(ICollection<model.Member> members) => DisplayChooseMember("view", members);
    public int GetNewBoatOwnerIndex(ICollection<model.Member> members) => DisplayChooseMember("register a boat to", members);
    public int GetDeleteBoatOwnerIndex(ICollection<model.Member> members) => DisplayChooseMember("delete a boat from", members);

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
      int typeCount = (int)BoatTypes.Type.Count;
      int unitCount = (int)Measurement.Unit.Count;

      Console.CursorVisible = true;
      Console.Clear();
      Console.WriteLine(headline);
      Console.WriteLine("Please provide the required boat information.\n");
      Console.WriteLine($"Type of boat\n");

      for (int type = 0; type < typeCount; type++)
      {
        Console.WriteLine($"  {type + 1}. {(BoatTypes.Type)type}");
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
        ? new BoatFormData((BoatTypes.Type)typeIndex, new Measurement(length, (Measurement.Unit)unitIndex))
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

    private void DisplayNoMembers()
    {
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║             You need to add members first               ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║---------------------------------------------------------║");
    }

    private void DisplayPressToGoBack()
    {
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║           Press any key to go back to menu              ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
    }

    private void DisplayMemberData(Member m)
    {
      Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine($"║  {$"Id: {m.Id}",-5}     {$"Name: {m.Name}",-22}    {$"SSN: {m.Ssn}",-17}  ║");
      Console.WriteLine("║                                                         ║");

      if (m.hasBoats)
      {
        Console.WriteLine("║---------------------------------------------------------║");
        Console.WriteLine("║  Boats  |  Type                      |  Length          ║");
        Console.WriteLine("║---------------------------------------------------------║");

        for (int i = 0; i < m.NumberOfBoats; i++)
        {
          Boat b = m.Boats[i];
          Console.WriteLine($"║  {i + 1,-5}  |  {b.Type,-24}  |  {$"{b.Length.Value} {b.Length.MeasurementUnit}",-14}  ║");
        }
      }
      Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
    }
  }
}
