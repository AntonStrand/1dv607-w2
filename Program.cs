using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace _1dv607_w2
{
  class Program
  {
    static void Main(string[] args)
    {
      // TODO: use this when running local
      //string pathToJson = "members.json";
      string pathToJson = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/members.json";
      model.FileSystem fs = new model.FileSystem(pathToJson);
      model.Members m = new model.Members(fs);
      view.ConsoleUI v = new view.ConsoleUI();
      controller.Administrator c = new controller.Administrator(v, m);
      while (c.run()) ;
    }
  }
}
