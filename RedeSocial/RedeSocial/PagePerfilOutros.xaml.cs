using Microsoft.Win32;
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
    /// Interação lógica para PagePerfilOutros.xam
    /// </summary>
    public partial class PagePerfilOutros : Page
    {


        private UserManager userManager = new UserManager();
        private PostManager postManager = new PostManager();
        int codUsuario;
        int codPerfil;
        private PagePost pagePost;
        Frame mainFrame;


        public PagePerfilOutros(int _codUser, int _codPerfil, Frame _mainFrame)
        {
            InitializeComponent();
            codUsuario = _codUser;
            codPerfil = _codPerfil;
            mainFrame = _mainFrame;
            AtualizarFotoPerfil();
            AtualizarCapa();
            MostrarNomeUsuario();
            buscar6Amigos();
            alterarConteudoBotao();

        }

        private void AtualizarFotoPerfil()
        {
            ellipseFotoUser.Fill = new ImageBrush
            {
                //Uri é unified resource identifier, ele identifica recursos.
                ImageSource = new BitmapImage(new Uri(userManager.BuscarFoto(codPerfil))),
                //ImageSource = new BitmapImage(new Uri(userManager.BuscarFoto(codUsuario), UriKind.RelativeOrAbsolute))
                Stretch = Stretch.UniformToFill,
            };


        }

        private void AtualizarCapa()
        {
            retanguloCapa.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(userManager.BuscarCapa(codPerfil))),
                Stretch = Stretch.UniformToFill,
            };
        }

        private void MostrarNomeUsuario()
        {
            string nomeUsuario = userManager.BuscarNome(codPerfil); // Método que busca o nome do usuário
            labelNomeUsuario.Content = nomeUsuario;
        }

        //A partir daqui vai ficar as postagens do Usuario, tentar de outra forma depois

        public void atualizarPaginaPostProprio()
        {
            gridPosts.Children.Clear();

            for (int i = postManager.BuscarQuantidade() - 1; i >= 0; i--)
            {
                if (postManager.VerificarPostProprio(i, codPerfil))
                {
                    //publicarPost(i);
                }
            }
        }
        public void buscar6Amigos()
        {
            Page6Amigos page6Amigos = new Page6Amigos(codPerfil, mainFrame);
            frame6Amigos.Navigate(page6Amigos);
        }

        private void botaoAdicionar_Click(object sender, RoutedEventArgs e)
        {

            if (botaoAdicionar.Content.ToString() == "Cancelar solicitação")
            {
                botaoAdicionar.Content = "Enviar solicitação";
                userManager.RecusarSolicitacao(codPerfil, codUsuario);
            }
            else if (botaoAdicionar.Content.ToString() == "Enviar solicitação")
            {
                userManager.AdicionarSolicitacao(codUsuario, codPerfil);
                botaoAdicionar.Content = "Cancelar solicitação";
            }
            else if (botaoAdicionar.Content.ToString() == "Aceitar solicitação")
            {
                userManager.AceitarSolicitacao(codUsuario, codPerfil);
                botaoAdicionar.Content = "Adicionado";
                botaoAdicionar.IsEnabled = false;
            }


        }
        private void alterarConteudoBotao()
        {
            if (userManager.VerificarSolicitacao(codUsuario, codPerfil))
            {
                botaoAdicionar.Content = "Cancelar solicitação";

            }
            else if (userManager.VerificarCodAmigo(codUsuario, codPerfil))
            {
                botaoAdicionar.Content = "Adicionado";
                botaoAdicionar.IsEnabled = false;

            }
            else if (userManager.VerificarSolicitacao(codPerfil, codUsuario))
            {

                botaoAdicionar.Content = "Aceitar solicitação";
            }
        }
        private void verificarUsuario()
        {
            if (codUsuario == codPerfil)
            {

            }
        }
    }
}

