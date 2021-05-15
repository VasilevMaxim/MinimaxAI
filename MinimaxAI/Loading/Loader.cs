using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MinimaxAI.Loading
{
    internal class LoaderDefault : ILoadable
    {
        public string Load(string path)
        {
            using var stream = new StreamReader(path);
            return stream.ReadToEnd();
        }
    }
}
