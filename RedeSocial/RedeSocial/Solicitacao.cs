using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial
{
    public class Solicitacao
    {
        public Solicitacao(int remetente, int destinatario)
        {
            Remetente = remetente;
            Destinatario = destinatario;
        }
        public int Remetente { get; set; }
        public int Destinatario { get; set; }
    }
}
