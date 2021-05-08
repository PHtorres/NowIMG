using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowIMG.API.Model
{
    public class RespostaImagemUpload
    {
        public RespostaImagemUpload()
        {
            notificacoes = new List<string>();
        }
        public List<string> notificacoes { get; set; }
        public bool sucesso { get { return !notificacoes.Any(); } }
        public string nomeImagem { get; set; }
    }
}
