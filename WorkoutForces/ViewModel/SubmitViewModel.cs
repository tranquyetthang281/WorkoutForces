using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WorkoutForces.ViewModel
{
    class SubmitViewModel:BaseViewModel
    {
        //edit Path
        string path = @"C:\Users\ASUS\source\repos\WorkoutForces8\fileVideo.txt";
        public RelayCommand<object> submitVideoCommand { get; set; }
        public SubmitViewModel()
        {
            submitVideoCommand = new RelayCommand<object>(canExecuteSubmit, SubmitExecute);
        }
        public bool canExecuteSubmit(object x)
        {
            return true;
        }
        //Button : Binding submitVideoCommand
        public void SubmitExecute(object parameter)
        {
            //debug
            //MessageBox.Show("SubmitExecute");
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string video = "";
            if(openFileDialog1.ShowDialog() == true)
            {
                video = openFileDialog1.FileName;
            }
            File.AppendAllText(path, video + ",");

            //debug
            //MessageBox.Show(File.ReadAllText(path));
        }
    }
}
