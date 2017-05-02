using System.IO;
using System.Windows.Forms;
using Waka.Lego.FileTool.Views;
using Waka.Lego.Model;

namespace Waka.Lego.FileTool.Controllers
{
    public class FileController
    {
        public int Id { get; set; }
        public FileController(int id)
        {
            Id = id;
        }
        public Form FileList(string path)
        {
            LegoPlugin p = new LegoPlugin();
            return new FileList(Y.Utils.FileUtils.FileTool.GetFile(path));
        }
        public Form SearchFile(string file)
        {
            return new SearchFile(File.Exists(file));
        }
        public string Test()
        {
            return "yooooooo  Test";
        }
        public string Test2(string name)
        {
            return "yooooooo  Test2  " + name;
        }
        public string Test3(string name, ref int index, out int flag)
        {
            flag = 10;
            return "yooooooo  Test2  " + name + " flag " + index;
        }
    }
}
