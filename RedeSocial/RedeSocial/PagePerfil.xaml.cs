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
using Microsoft.Win32;

namespace RedeSocial
{
    /// <summary>
    /// Interação lógica para PagePerfil.xam
    /// </summary>
    public partial class PagePerfil : Page
    {
        private UserManager userManager = new UserManager();
        private PostManager postManager = new PostManager();
        int codUsuario;
        private Home mainWindow;
        private PagePost pagePost;

        public PagePerfil(int codUser, Home _mainWin)
        {
            InitializeComponent();
            codUsuario = codUser;
            mainWindow = _mainWin;
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
            mainWindow.ellipseFotoUser.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(userManager.BuscarFoto(codUsuario)))
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



        private void ellipseFotoUser_MouseEnter(object sender, MouseEventArgs e)
        {
            labelAlterarFoto.Visibility = Visibility.Visible;
        }

        private void ellipseFotoUser_MouseLeave(object sender, MouseEventArgs e)
        {
            labelAlterarFoto.Visibility = Visibility.Hidden;
        }



        private void ellipseFotoUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                userManager.AdicionarFoto(codUsuario, openFileDialog.FileName);
            }
            AtualizarFotoPerfil();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                userManager.AdicionarCapa(codUsuario, openFileDialog.FileName);
            }
            AtualizarCapa();
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
            Page6Amigos page6Amigos = new Page6Amigos(codUsuario);
            frame6Amigos.Navigate(page6Amigos);
        }


    }
}
