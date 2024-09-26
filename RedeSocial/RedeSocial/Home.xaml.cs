﻿using System;
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
using Microsoft.Win32;

namespace RedeSocial
{
    /// <summary>
    /// Lógica interna para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private UserManager userManager = new UserManager();
        PagePost pagePost;
        int codUsuario;
        public Home(int codUser)
        {
            InitializeComponent();
            codUsuario = codUser;
            pagePost = new PagePost(codUsuario);
            MainFrame.Navigate(pagePost);
            AtualizarFotoPerfil();
        }
        private void botaoMenu_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Opacity = 0.3;
        }

        private void botaoMenu_Unchecked(object sender, RoutedEventArgs e)
        {
            MainFrame.Opacity = 1.0;
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            this.Close();
        }

        private void carlos(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            this.Close();
        }

        private void botaoSair_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow1 = new MainWindow();
            mainWindow1.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                userManager.AdicionarFoto(codUsuario, openFileDialog.FileName);
                pagePost = new PagePost(codUsuario);
                MainFrame.Navigate(pagePost);
            }
            AtualizarFotoPerfil();
        }

        private void AtualizarFotoPerfil()
        {
            ellipseFotoUser.Fill = new ImageBrush
            {
                //Uri é unified resource identifier, ele identifica recursos.
                ImageSource = new BitmapImage(new Uri(userManager.BuscarFoto(codUsuario)))
                //ImageSource = new BitmapImage(new Uri(userManager.BuscarFoto(codUsuario), UriKind.RelativeOrAbsolute))
            };
        }
    }
}