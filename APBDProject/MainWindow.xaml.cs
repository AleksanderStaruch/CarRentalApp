﻿using APBDProject.DAL;
using APBDProject.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace APBDProject
{
    /// <summary>
    /// Interaction logic for Data.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string login;
        public MainWindow(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        //private void AddUser_Click(object sender, RoutedEventArgs e)
        //{
        //    var window = new UserWindow("Register user");
        //}


    }
}
