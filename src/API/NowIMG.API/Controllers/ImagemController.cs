using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowIMG.API.Model;
using NowIMG.API.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NowIMG.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImagemController : ControllerBase
    {

        public static IWebHostEnvironment _environment;
        public RespostaImagemUpload resposta;
        public ImagemController(IWebHostEnvironment environment)
        {
            _environment = environment;
            resposta = new RespostaImagemUpload();
        }

        [HttpPost("upload")]
        public ActionResult<RespostaImagemUpload> Post([FromForm] IFormFile imagem)
        {
            if (imagem == null)
            {
                resposta.notificacoes.Add("Arquivo nulo");
                return Ok(resposta);
            }

            if (imagem.Length == 0)
            {
                resposta.notificacoes.Add("Arquivo vazio");
                return Ok(resposta);
            }

            var idImagem = Guid.NewGuid().ToString();
            var extensao = ImagemService.ExtensaoArquivo(imagem.FileName);

            try
            {
                if (!Directory.Exists(_environment.WebRootPath + "\\imagens\\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\imagens\\");
                }

                using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\imagens\\" + idImagem + extensao))
                {
                    imagem.CopyTo(filestream);
                    filestream.Flush();
                }

                resposta.nomeImagem = idImagem + extensao;
            }
            catch (Exception ex)
            {
                resposta.notificacoes.Add($"Erro no envio: {ex.Message}");
            }

            return Ok(resposta);
        }
    }
}
