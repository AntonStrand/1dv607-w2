using System;
using _1dv607_w2.model;


namespace _1dv607_w2.view.console
{
  class ConsoleBase
  {
    protected const char YES = 'y';
    protected const char NO = 'n';
    protected const char CANCEL = 'c';

    protected void DisplayNoMembers()
    {
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║             You need to add members first               ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║---------------------------------------------------------║");
    }

    protected void DisplayPressToGoBack()
    {
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("║           Press any key to go back to menu              ║");
      Console.WriteLine("║                                                         ║");
      Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
    }

    protected void DisplayMemberData(Member m)
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
