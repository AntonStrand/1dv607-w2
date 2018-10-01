using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace _1dv607_w2
{
  class Program
  {
    static void Main(string[] args)
    {
      // TODO: use this when exporting
      // string pathToJson = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/members.json";
      string pathToJson = "members.json";
      model.FileSystem fs = new model.FileSystem(pathToJson);
      model.Members m = new model.Members(fs);
      view.ConsoleGUI v = new view.ConsoleGUI();
      controller.Administrator c = new controller.Administrator(v, m);
      while (c.run()) ;
    }
  }
}
