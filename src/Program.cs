using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace _1dv607_w2
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        string pathToJson = "members.json";
        model.FileSystem fs = new model.FileSystem(pathToJson);
        model.Members m = new model.Members(fs);
        view.console.ConsoleUI v = new view.console.ConsoleUI();
        controller.Administrator c = new controller.Administrator(v, m);
        while (c.run()) ;
      }
      catch (System.Exception)
      {
        System.Console.Clear();
        System.Console.WriteLine("Sorry, something unexpected happened.");
        System.Console.WriteLine("Please restart the application.");
        System.Console.ReadKey();
      }
    }
  }
}
