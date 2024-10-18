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
    /// Interação lógica para PageCartaoUsuario.xam
    /// </summary>
    public partial class PageCartaoUsuario : Page
    {

        UserManager userManager = new UserManager();
        int codPerfil;
        int codUser;
        Home mainWin;
        public PageCartaoUsuario(int _codUser, int _codPerfil, Home _mainWin)
        {
            InitializeComponent();
            this.codPerfil = _codPerfil;
            this.codUser = _codUser;
            buscarUsuario(_codPerfil);
            alterarConteudoBotao(_codUser, _codPerfil);
            mainWin = _mainWin;
        }
        private void buscarUsuario(int codPerfil)
        {
            foto.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codPerfil))));
            labelNome.Content = userManager.BuscarNome(codPerfil);
        }

        private void botaoAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (userManager.VerificarSolicitacao(codUser, codPerfil))
            {
                botaoAdicionar.Content = "Enviar solicitação";
                userManager.RecusarSolicitacao(codPerfil ,codUser);
            }
            else 
            {
                userManager.AdicionarSolicitacao(codUser, codPerfil);
                botaoAdicionar.Content = "Cancelar solicitação";
            }
        }
        private void alterarConteudoBotao(int codUser, int codPerfil)
        {
            if (userManager.VerificarSolicitacao(codUser, codPerfil))
            {
                botaoAdicionar.Content = "Cancelar solicitação";

            } else if (userManager.VerificarCodAmigo(codUser, codPerfil))
            {
                botaoAdicionar.Content = "Adicionado";
                botaoAdicionar.IsEnabled = false;

            }
        }

        private void foto_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //PagePerfil pagePerfil = new PagePerfil(codPerfil);
            //mainWin.MainFrame.Navigate(pagePerfil);
        }
    }
}
