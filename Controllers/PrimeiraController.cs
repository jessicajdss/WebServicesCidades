using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{
    //Vamos definir a rota para a requisição do serviço
    [Route("api/[controller]")]
    public class PrimeiraController:Controller //tem que herdar do método pai Controller
    {

        DAOCidades dao = new DAOCidades();
        [HttpGet] 
        public IEnumerable<Cidades> Get(){

            return dao.Listar() ;
        }

        [HttpGet("{id}",Name ="CidadeAtual")]

        public Cidades Get(int id){
            return dao.Listar().Where(x => x.Id==id).FirstOrDefault() ;
        }

        [HttpPost]
        //[Route("api/cadcidade")]
        public IActionResult Post([FromBody]Cidades cidades){
            dao.Cadastro(cidades);
            return CreatedAtRoute("CidadeAtual", new{id = cidades.Id},cidades);
        }

        public IActionResult Delete([FromBody]int id){
            dao.Apagar(id);
            return CreatedAtRoute("CidadeAtual", id);
        }

        //[HttpGet("{id}")] //Busca dado por cliente e passando um parâmetro
        // public string Get(int id){
        //     return new string []{
        //         "Curitiba", 
        //         "Porto Alegre", 
        //         "Salvador", 
        //         "Belo Horizonte",
        //         "São Paulo",
        //         "Piracicaba",
        //         "Monte Verde"
        //     }[id];
        // }
    }
}