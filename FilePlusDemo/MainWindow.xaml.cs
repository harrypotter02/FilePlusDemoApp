using System;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;
using FilePlusLibrary;
using FilePlusDemo.SnackBarExample;

using System.Collections.Generic;
using MaterialDesignThemes.Wpf;
using System.Linq;
using static FilePlusDemo.SnackBarExample.MySnack;
using FilePlusLibrary.OutputListboxExample;

namespace FilePlusDemo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        FilePlus flib;
        CodeTime ctime;
        private MySnack mysnack;
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
            ctime = new CodeTime();

            
            
            #region example6_MySnackBar
            mysnack = new MySnack();
            snap_example_grid.DataContext = mysnack;
            snap_panel.DataContext = this;
            MessageType = "MY_WARNING";
            MyTalk = "Hello SnackBar With NORMAL/WARNING/ERROR level";
            #endregion

            #region example7_OutputListbox
            MyInfoBox.SetRefWindowAndListBox(this,this.OutputListBox);
            MyInfoBox.AddInfo("Easily show your text on listbox!");
            MyInfoBox.AddInfo("this is next message");
            #endregion
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            flib.CloseDebug();//example0
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

        private void create_dev_log_Click(object sender, RoutedEventArgs e)//example0
        {
            flib.CreateDebug(); 
            Debug.WriteLine("Hello Dev!");
            
            FinishedMsg();
        }


        private void FinishedMsg()
        {
            MessageBox.Show("Write message to file finished!");
        }

        private void open_save_filedialog_Click(object sender, RoutedEventArgs e)
        {
            //flib.OpenSaveDialog("mysave.txt");
            if(flib.OpenSaveDialog("", "ini (*.ini)|*.ini"))
            {
                int a = 99;
            }
            else
            {
                int b = 98;

            }
        }

        private void open_file_filedialog_Click(object sender, RoutedEventArgs e)
        {
            flib.OpenFileDialog();
        }

        private void get_timestamp_Click(object sender, RoutedEventArgs e)
        {

            string time = ctime.GetTickMs().ToString();
            MessageBox.Show("From Unix time 1970.. timestamp:"+time);
        }

        #region example6
        private string _message_type;
        public string MessageType
        {
            get
            {
                return _message_type;
            }
            set
            {
                _message_type = value;
                NotifyPropertyChanged("MessageType");
            }
        }
        private string _mytalk;
        public string MyTalk
        {
            get
            {
                return _mytalk;
            }
            set
            {
                _mytalk = value;
                NotifyPropertyChanged("MyTalk");
            }
        }
        private void PopSnackBarButton_Click(object sender, RoutedEventArgs e)
        {
            MessageToSnackLevel level = MessageToSnackLevel.NoLevel;
            if (MessageType == "MY_ERROR")
                level = MessageToSnackLevel.Error;
            else if (MessageType == "MY_WARNING")
                level = MessageToSnackLevel.Warning;

            mysnack.AddMessage(MyTalk,level,1);
        }
        #endregion
        

        #region example7
        private bool _box_auto_scroll;
        public bool BoxAutoScroll
        {
            set
            {
                _box_auto_scroll = value;
                NotifyPropertyChanged("BoxAutoScroll");
            }
            get
            {
                return _box_auto_scroll;
            }
        }
        private void CleanOutputButton_Click(object sender, RoutedEventArgs e)
        {
            MyInfoBox.Clean();
        }

        #endregion

        
    }
}
