﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RedeSocial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tabMenu.SelectedIndex == 1)
            {
                tabMenu.Height = 533;
            }
            else
            {
                tabMenu.Height = 358;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void areaUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}