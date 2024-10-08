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
    /// Interação lógica para PageCartaoSolicitacao.xam
    /// </summary>
    public partial class PageCartaoSolicitacao : Page
    {
        UserManager userManager = new UserManager();
        int codPerfil_;
        int codUser_;

        public PageCartaoSolicitacao(int codUser, int codPerfil)
        {
            InitializeComponent();
            codPerfil_ = codPerfil;
            codUser_ = codUser;
            buscarUsuario(codPerfil);
        }
        private void buscarUsuario(int codPerfil)
        {
            foto.Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(codPerfil))));
            labelNome.Content = userManager.BuscarNome(codPerfil);
        }

        private void botaoAceitar_Click(object sender, RoutedEventArgs e)
        {
            userManager.AceitarSolicitacao(codUser_, codPerfil_);
            botaoAceitar.Visibility = Visibility.Hidden;
            botaoRecusar.Content = "Solicitação aceita";
            botaoRecusar.IsEnabled = false;
        }

        private void botaoRecusar_Click(object sender, RoutedEventArgs e)
        {
            userManager.RecusarSolicitacao(codUser_, codPerfil_);
            botaoAceitar.Visibility = Visibility.Hidden;
            botaoRecusar.Content = "Solicitação recusada";
            botaoRecusar.IsEnabled = false;

        }
    }
}
