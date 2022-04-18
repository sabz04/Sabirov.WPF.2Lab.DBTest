﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sabirov.WPF._2Lab.DBTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void LoginPageBTN_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Login());
            (sender as Button).Opacity = 0.5;
            RegPageBTN.Opacity = 1;
        }

        private void RegPageBTN_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Register());
            (sender as Button).Opacity = 0.5;
            LoginPageBTN.Opacity = 1;
        }

        private void VKBTN_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/sabirovvvv");
        }
    }
}
