using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowIMG.API.Services
{
    public class ImagemService
    {
        public static string ExtensaoArquivo(string nomeArquivo)
        {
            if(nomeArquivo != null)
            {
                var quebras = nomeArquivo.Split('.');
                var extensao = quebras[quebras.Length - 1];
                return $".{extensao}";
            }

            return "";
        } 
    }
}
