using DesafioCetogenica.API.Database;
using DesafioCetogenica.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DesafioCetogenica.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FormularioController : ControllerBase
{
    private readonly ApplicationDBContext _applicationDBContext;

    public FormularioController(ApplicationDBContext applicationDBContext)
    {
        this._applicationDBContext = applicationDBContext;
    }

    [HttpPost("InsereDadosFormulario")]
    public ActionResult<StatusResult> InsereDadosFormulario(ParamInsereDadosDTO param)
    {
        var ret = new StatusResult();

        try
        {
            if (param.Nome != null)
            {
                var row = new td_dados_formulario();
                row.nome = param.Nome;
                row.telefone = param.Telefone;
                row.email = param.Email;

                _applicationDBContext.td_dados_formulario.Add(row);
                _applicationDBContext.SaveChanges();
            }
            else
            {
                throw new Exception("É necessário preencher o nome!");
            }

            return Ok(ret);
        }
        catch (Exception e)
        {
            ret.Sucesso = false;
            ret.Mensagem = e.Message;
            return StatusCode(500, ret);
        }
    }

    [HttpPost("InsereDadosInstagram")]
    public ActionResult<StatusResult> InsereDadosInstagram(ParamInsereDadosInstagramDTO param)
    {
        var ret = new StatusResult();
        var row = new tb_dados_instagram();

        var baseInstagram = "@";

        try
        {
            if (param.Instagram != null)
            {
                if (param.Instagram.Contains("@"))
                {
                    row.instagram = param.Instagram;
                    row.nome = param.Nome;
                    row.email = param.Email;
                    row.telefone = param.Telefone;

                    _applicationDBContext.tb_dados_instagram.Add(row);
                    _applicationDBContext.SaveChanges();
                }
                else
                {
                    row.instagram = baseInstagram + param.Instagram;
                    row.nome = param.Nome;
                    row.email = param.Email;
                    row.telefone = param.Telefone;

                    _applicationDBContext.tb_dados_instagram.Add(row);
                    _applicationDBContext.SaveChanges();
                }
            }
            else
            {
                throw new Exception("É necessário preencher o instagram!");
            }

            return Ok(ret);
        }
        catch (Exception e)
        {
            ret.Sucesso = false;
            ret.Mensagem = e.Message;
            return StatusCode(500, ret);
        }
    }

    //PÁGINA DE FORMULÁRIO DA PSICOLOGIA DA MODA

    [HttpPost("InsereDadosFormularioPsicologiaDaModa")]
    public ActionResult<StatusResult> InsereDadosFormularioPsicologiaDaModa(ParamInsereDadosDTO param)
    {
        var ret = new StatusResult();

        try
        {
            if (param.Nome != null && param.Email != null)
            {
                var row = new tb_dados_psicologia_da_moda();
                row.nome = param.Nome;
                row.telefone = param.Telefone;
                row.email = param.Email;

                _applicationDBContext.tb_dados_psicologia_da_moda.Add(row);
                _applicationDBContext.SaveChanges();
            }
            else
            {
                throw new Exception("É necessário preencher o nome e o e-mail!");
            }

            return Ok(ret);
        }
        catch (Exception e)
        {
            ret.Sucesso = false;
            ret.Mensagem = e.Message;
            return StatusCode(500, ret);    
        }
    }

    [HttpPost("DownloadPDF")]
    public ActionResult<StatusResult> DownloadPDF()
    {
        var ret = new StatusResult();

        try
        {
            var fileName = "Teste";
            var filePath = @"wwwroot/Teste.pdf";
            var fileType = "application/pdf";

            var arquivo = System.IO.File.ReadAllBytes(filePath);

            return File(arquivo, fileType, fileName);
        }
        catch (Exception e)
        {
            ret.Sucesso = false;
            ret.Mensagem = e.Message;
            return StatusCode(500, ret);
        }
    }
}
