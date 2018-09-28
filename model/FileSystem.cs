using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace _1dv607_w2.model
{
  class FileSystem
  {
    private string _path;

    public FileSystem(string path)
    {
      _path = path;
    }

    public void Save(string txt)
    {
      File.WriteAllText(_path, txt);
    }

    public List<T> GetParsedJSON<T>()
    {
      try
      {
        string unparsedJSON = File.ReadAllText(_path);
        try
        {
          return (List<T>)JsonConvert.DeserializeObject<IEnumerable<T>>(unparsedJSON);
        }
        catch (Exception)
        {
          throw new ArgumentException($"The JSON could not be converted to {typeof(T)}.");
        }
      }
      catch (FileNotFoundException)
      {
        throw new FileNotFoundException($"The file, \"{_path}\", could not be found.");
      }
    }
  }
}