namespace _1dv607_w2
{
  class Program
  {
    static void Main(string[] args)
    {
      model.FileSystem fs = new model.FileSystem("members.json");
      model.Members m = new model.Members(fs);
      view.ConsoleGUI v = new view.ConsoleGUI();
      controller.Administrator c = new controller.Administrator();
      while (c.run(v, m)) ;
    }
  }
}
