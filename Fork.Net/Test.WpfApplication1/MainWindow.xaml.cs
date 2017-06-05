using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test.WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _BindData = string.Empty;
        public string BindData
        {
            get
            {
                if (_BindData.Length == 0)
                    _BindData = "this is BindData";
                return _BindData;
            }
            set
            {
                _BindData = value;
            }
        }
        private string _TextBoxData = string.Empty;
        public string TextBoxData
        {
            get
            {
                if (_TextBoxData.Length == 0)
                    _TextBoxData = "this is data";
                return _TextBoxData;
            }
            set
            {
                if (_TextBoxData != value)
                {
                    _TextBoxData = value;
                    OnPropertyChanged("TextBoxData");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<string> _GuidList;
        public List<string> GuidList
        {
            get { return _GuidList; }
            set
            {
                _GuidList = value;
                OnPropertyChanged("GuidList");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    List<string> gl = new List<string>() {
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString(),
                        new string('1',DateTime.Now.Second),
                        DateTime.Now.ToString("HH:mm:ss.fff"),
                        "12234567890-hgfdaWWERTYHBNBBVVCXZ"
                    };
                    GuidList = gl;


                    TextBoxData = DateTime.Now.ToString("HH:mm:ss.fff");
                    Thread.Sleep(1000);
                }
            });
        }

    }
}
