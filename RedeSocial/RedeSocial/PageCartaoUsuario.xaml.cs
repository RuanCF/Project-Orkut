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
        Frame mainFrame;
        public PageCartaoUsuario(int _codUser, int _codPerfil, Frame _mainFrame)
        {
            InitializeComponent();
            mainFrame = _mainFrame;
            codPerfil = _codPerfil;
            codUser = _codUser;
            buscarUsuario();
            alterarConteudoBotao();
        }
        private void buscarUsuario()
        {
            foto.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codPerfil))));
            labelNome.Content = userManager.BuscarNome(codPerfil);
        }

        private void botaoAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (botaoAdicionar.Content.ToString() == "Cancelar solicitação")
            {
                botaoAdicionar.Content = "Enviar solicitação";
                userManager.RecusarSolicitacao(codPerfil ,codUser);
            }
            else if (botaoAdicionar.Content.ToString() == "Enviar solicitação")
            {
                userManager.AdicionarSolicitacao(codUser, codPerfil);
                botaoAdicionar.Content = "Cancelar solicitação";
            }else if (botaoAdicionar.Content.ToString() == "Aceitar solicitação")
            {
                userManager.AceitarSolicitacao(codUser, codPerfil);
                botaoAdicionar.Content = "Adicionado";
                botaoAdicionar.IsEnabled = false;
            }


        }
        private void alterarConteudoBotao()
        {
            if (userManager.VerificarSolicitacao(codUser, codPerfil))
            {
                botaoAdicionar.Content = "Cancelar solicitação";

            } else if (userManager.VerificarCodAmigo(codUser, codPerfil))
            {
                botaoAdicionar.Content = "Adicionado";
                botaoAdicionar.IsEnabled = false;

            } else if (userManager.VerificarSolicitacao(codPerfil, codUser))
            {

                botaoAdicionar.Content = "Aceitar solicitação";
            }
        }

        private void foto_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PagePerfilOutros pagePerfilOutros = new PagePerfilOutros(codUser, codPerfil, mainFrame);
            mainFrame.Navigate(pagePerfilOutros);
        }
    }
}
