using System.IO;

namespace TestNinja.Mocking
{
    public interface IFileReader
    {
        string ReadAllText(string path);
    }

    public class FileReader : IFileReader
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}