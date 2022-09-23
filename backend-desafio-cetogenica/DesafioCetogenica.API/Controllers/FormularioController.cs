using DesafioCetogenica.API.Database;
using DesafioCetogenica.API.DTOs;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<StatusResult> InsereDadosFormulario(ParamInsereDadosDTO param) {
        var ret = new StatusResult();

        try {
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
        catch (Exception e) {
            ret.Sucesso = false;
            ret.Mensagem = e.Message;
            return StatusCode(500, ret);
        }
    }
}
