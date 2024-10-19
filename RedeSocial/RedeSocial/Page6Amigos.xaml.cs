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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RedeSocial
{
    /// <summary>
    /// Interação lógica para Page6Amigos.xam
    /// </summary>
    public partial class Page6Amigos : Page
    {
        UserManager userManager = new UserManager();
        int codUsuario;
        int codAmigo;
        int posAmigo;
        Frame mainFrame;
        int amigo1;
        int amigo2;
        int amigo3;
        int amigo4;
        int amigo5;
        int amigo6;
        public Page6Amigos(int _codUsuario, Frame _mainFrame)
        {
            InitializeComponent();
            mainFrame = _mainFrame;
            codUsuario = _codUsuario;
            buscarPerfilAmigo();
        }
        public void buscarPerfilAmigo()
        {
            for (int i = 0; i < userManager.BuscarQuantidadeAmigos(codUsuario); i++)
            {
                codAmigo = userManager.BuscarCodAmigo(codUsuario, i);
               
                if (posAmigo == 0)
                {
                    foto1.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome1.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                    amigo1=codAmigo;
                }
                else if (posAmigo == 1)
                {
                    foto2.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome2.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                    amigo2 = codAmigo;

                }
                else if (posAmigo == 2)
                {
                    foto3.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome3.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                    amigo3 = codAmigo;
                }
                else if (posAmigo == 3)
                {
                    foto4.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome4.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                    amigo4 = codAmigo;

                }
                else if (posAmigo == 4)
                {
                    foto5.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome5.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                    amigo5 = codAmigo;
                }
                else if (posAmigo == 5)
                {
                    foto6.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome6.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                    amigo6 = codAmigo;
                }
            }
        }

        private void foto1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PagePerfilOutros(codUsuario, amigo1, mainFrame));
        }

        private void foto2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PagePerfilOutros(codUsuario, amigo2, mainFrame));
        }

        private void foto3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PagePerfilOutros(codUsuario, amigo3, mainFrame));
        }

        private void foto4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PagePerfilOutros(codUsuario, amigo4, mainFrame));
        }

        private void foto5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PagePerfilOutros(codUsuario,amigo5, mainFrame));
        }

        private void foto6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PagePerfilOutros(codUsuario, amigo6, mainFrame));
        }
    }
}

