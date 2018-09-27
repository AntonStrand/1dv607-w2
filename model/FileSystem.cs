namespace _1dv607_w2.model
{
  class FileSystem
  {
    private string _path;

    public FileSystem(string path)
    {
      _path = path;
    }

    public void save(string txt)
    {
      System.IO.File.WriteAllText(_path, txt);
    }
  }
}