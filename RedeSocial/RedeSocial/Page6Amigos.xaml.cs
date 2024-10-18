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
        public Page6Amigos(int _codUsuario)
        {
            InitializeComponent();
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
                }
                else if (posAmigo == 1)
                {
                    foto2.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome2.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;

                }
                else if (posAmigo == 2)
                {
                    foto3.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome3.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                }
                else if (posAmigo == 3)
                {
                    foto4.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome4.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                }
                else if (posAmigo == 4)
                {
                    foto5.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome5.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                }
                else if (posAmigo == 5)
                {
                    foto6.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codAmigo))));
                    labelNome6.Content = userManager.BuscarNome(codAmigo);
                    posAmigo++;
                }
            }
        }

    }
}

