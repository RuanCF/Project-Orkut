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
        private PagePost pagePost;
        Frame mainFrame;


        public PagePerfilOutros(int codUser,Frame _mainFrame )
        {
            InitializeComponent();
            codUsuario = codUser;
            mainFrame = _mainFrame;
            AtualizarFotoPerfil();
            AtualizarCapa();
            MostrarNomeUsuario();
            buscar6Amigos();
           
        }

        private void AtualizarFotoPerfil()
        {
            ellipseFotoUser.Fill = new ImageBrush
            {
                //Uri é unified resource identifier, ele identifica recursos.
                ImageSource = new BitmapImage(new Uri(userManager.BuscarFoto(codUsuario))),
                //ImageSource = new BitmapImage(new Uri(userManager.BuscarFoto(codUsuario), UriKind.RelativeOrAbsolute))
                Stretch = Stretch.UniformToFill,
            };
           

        }

        private void AtualizarCapa()
        {
            retanguloCapa.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(userManager.BuscarCapa(codUsuario))),
                Stretch = Stretch.UniformToFill,
            };
        }

        private void MostrarNomeUsuario()
        {
            string nomeUsuario = userManager.BuscarNome(codUsuario); // Método que busca o nome do usuário
            labelNomeUsuario.Content = nomeUsuario;
        }

        //A partir daqui vai ficar as postagens do Usuario, tentar de outra forma depois

        public void atualizarPaginaPostProprio()
        {
            gridPosts.Children.Clear();

            for (int i = postManager.BuscarQuantidade() - 1; i >= 0; i--)
            {
                if (postManager.VerificarPostProprio(i, codUsuario))
                {
                    //publicarPost(i);
                }
            }
        }
        public void buscar6Amigos()
        {
            Page6Amigos page6Amigos = new Page6Amigos(codUsuario, mainFrame);
            frame6Amigos.Navigate(page6Amigos);
        }

       
    }
}

