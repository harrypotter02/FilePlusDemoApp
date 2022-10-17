using System;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;
using FilePlusLibrary;

namespace FilePlusDemo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        FilePlus flib;
        private string _example1_str;
        public string Example1Str
        {
            get
            {
                return _example1_str;
            }
            set
            {
                _example1_str = value;
                NotifyPropertyChanged("Example1Str");
            }
        }

        private string _example2_str;
        public string Example2Str
        {
            get
            {
                return _example2_str;
            }
            set
            {
                _example2_str = value;
                NotifyPropertyChanged("Example2Str");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            mymain_grid.DataContext = this;
            flib = new FilePlus();
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        //example1:
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flib.CreateLog("mytest1.txt"))
            {
                flib.addLog(Example1Str);
            }
            else
            {
                Debug.WriteLine(flib.LastError);
            }
            FinishedMsg();
        }
        //example2:
        private void create_debug_log_with_path_Click(object sender, RoutedEventArgs e)
        {
            if (flib.CreateLog("mytest2.txt", Environment.CurrentDirectory))
            {
                flib.addLog(Example2Str);
               
            }
            else
            {
                Debug.WriteLine(flib.LastError);
            }
            FinishedMsg();
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            Example1Str = "Hello write this line to log :)";
            Example2Str = "Hello write this message to log :)";
        }

        private void create_dev_log_Click(object sender, RoutedEventArgs e)
        {
            flib.CreateDebug();
            Debug.WriteLine("Hello Dev!");
            flib.CloseDebug();
            FinishedMsg();
        }


        private void FinishedMsg()
        {
            MessageBox.Show("Write message to file finished!");
        }
    }
}
