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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RedeSocial
{
    /// <summary>
    /// Interação lógica para PageBuscar.xam
    /// </summary>
    public partial class PageBuscar : Page
    {
        UserManager userManager = new UserManager();
        Home mainWin;
        public PageBuscar(int codUser, Home _mainWin)
        {
            InitializeComponent();
           repetirLista(codUser);
           mainWin = _mainWin;

        }
        public void listarUsuario(int codUser, int codPerfil) 
        {
            PageCartaoUsuario pageCartao = new PageCartaoUsuario(codUser,codPerfil, mainWin);
            gridBuscar.RowDefinitions.Add(new RowDefinition());
            Frame frame = new Frame()
            {
                Height = 60,  
                Width = 600
            };
            frame.Navigate(pageCartao);
            Grid.SetRow(frame, gridBuscar.RowDefinitions.Count - 1);
            gridBuscar.Children.Add(frame);
            
        }
        public void repetirLista(int codUser)
        {

            for (int i = 0; i < userManager.BuscarQuantidade(); i++)
            {

                if (i != codUser)
                {
                    listarUsuario(codUser,i);
                }
            }
        }
    }
}
