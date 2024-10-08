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
    /// Interação lógica para PageAmigos.xam
    /// </summary>
    /// 

    //TODO: dividir 2 grids (Uma para solicitação. outra para amigos existentes) e colocar no wrappane 


    public partial class PageAmigos : Page
    {
        UserManager userManager = new UserManager();
        public PageAmigos(int codUser)
        {
            InitializeComponent();
            repetirLista(codUser);
        }
        public void listarUsuario(int codUser, int codPerfil)
        {
            PageCartaoSolicitacao pageCartaoSolicitacao = new PageCartaoSolicitacao(codUser, codPerfil);
            
            Frame frame = new Frame()
            {
                Height = 300,
                Width = 250
            };
            frame.Navigate(pageCartaoSolicitacao);
           
            gridAmigos.Children.Add(frame);

        }
        public void repetirLista(int codUser)
        {

            for (int i = 0; i < userManager.BuscarQuantidade(); i++)
            {

                if (i != codUser)
                {
                    if (userManager.VerificarSolicitacao(i, codUser))
                    {
                        listarUsuario(codUser, i);
                    }
                   
                }
            }
        }
        //atualizar a pagina  com os cartoes depois de ja ter adicionado
    }
}
