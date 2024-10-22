using RedeSocial;
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
    /// Interação lógica para PageCartaoAmigo.xam
    /// </summary>
    public partial class PageCartaoAmigo : Page
    {
        UserManager userManager = new UserManager();
        int codPerfil;
        int codUser;
        Frame mainFrame;
        public PageCartaoAmigo(int _codUser, int _codPerfil, Frame _mainFrame)
        {
            InitializeComponent();
            mainFrame = _mainFrame;
            codPerfil = _codPerfil;
            codUser = _codUser;
            buscarUsuario(codPerfil);
            
        }
        private void buscarUsuario(int codPerfil )
        {
            foto.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(userManager.BuscarFoto(codPerfil))),
                Stretch = Stretch.UniformToFill,
            };
            labelNome.Content = userManager.BuscarNome(codPerfil);
        }

    
        private void botaoDesfazerAmizade_Click(object sender, RoutedEventArgs e)
        {
            userManager.DesfazerAmizade(codUser, codPerfil);
            botaoDesfazerAmizade.Content = "excluido da lista de amigo ";
        }

        private void foto_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PagePerfilOutros pagePerfilOutros = new PagePerfilOutros(codUser, codPerfil, mainFrame);
            mainFrame.Navigate(pagePerfilOutros);
        }
    }
}

    

   
