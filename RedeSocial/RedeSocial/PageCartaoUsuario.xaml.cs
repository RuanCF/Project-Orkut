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
        int codPerfil_;
        int codUser_;
        public PageCartaoUsuario(int codUser, int codPerfil)
        {
            InitializeComponent();
            codPerfil_ = codPerfil;
            codUser_ = codUser;
            buscarUsuario(codPerfil);
            alterarConteudoBotao(codUser, codPerfil);

        }
        private void buscarUsuario(int codPerfil)
        {
            foto.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codPerfil))));
            labelNome.Content = userManager.BuscarNome(codPerfil);
        }

        private void botaoAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (userManager.VerificarSolicitacao(codUser_, codPerfil_))
            {
                botaoAdicionar.Content = "Enviar solicitação";
                userManager.RecusarSolicitacao(codUser_, codPerfil_);
            }
            else 
            {
                userManager.AdicionarSolicitacao(codUser_, codPerfil_);
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
       
    }
}
