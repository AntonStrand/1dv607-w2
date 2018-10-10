using System;
using _1dv607_w2.model;

namespace _1dv607_w2.view.console
{
  class BoatView : ConsoleBase
  {
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
          return GetBoatIndex(member);
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

    public Boat GetBoatInformation(string headline)
    {
      int typeCount = (int)Boat.Types.Count;
      int unitCount = (int)Measurement.Unit.Count;

      Console.CursorVisible = true;
      Console.Clear();
      Console.WriteLine(headline);
      Console.WriteLine("Please provide the required boat information.\n");
      Console.WriteLine($"Type of boat\n");

      for (int type = 0; type < typeCount; type++)
      {
        Console.WriteLine($"  {type + 1}. {(Boat.Types)type}");
      }

      Console.Write($"\nNumber (1-{typeCount}): ");
      string typeId = Console.ReadLine();
      int typeIndex;
      if (!int.TryParse(typeId, out typeIndex) || typeIndex < 1 || typeIndex > typeCount)
      {
        return GetBoatInformation(headline);
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
        return GetBoatInformation(headline);
      }

      Console.Write($"\n\nLength in {(Measurement.Unit)(unitIndex - 1)}: ");
      string lengthStr = Console.ReadLine();

      int length;
      if (!int.TryParse(lengthStr, out length) || length < 1)
      {
        return GetBoatInformation(headline);
      }

      Console.Write($"\n\nIs this information correct ({YES}/{NO}) or {CANCEL} to cancel: ");
      char answer = Console.ReadKey().KeyChar;

      Boat.Types boatType = (Boat.Types)typeIndex - 1;
      Measurement.Unit lengthUnit = (Measurement.Unit)unitIndex - 1;

      return answer == YES
        ? new Boat(boatType, new Measurement(length, lengthUnit))
        : answer == CANCEL
          ? null
          : GetBoatInformation(headline);
    }
  }
}