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
        public PageCartaoUsuario(int codUser)
        {
            InitializeComponent();
            buscarUsuario(codUser);
        }
        private void buscarUsuario(int codUser)
        {
            foto.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codUser))));
            labelNome.Content = userManager.BuscarNome(codUser);
        }

        private void botaoAdicionar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
