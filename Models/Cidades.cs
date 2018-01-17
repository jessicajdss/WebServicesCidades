using System.Collections.Generic;

namespace WebServicesCidades.Models
{
    public class Cidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Estado { get; set; }

        public int Habitantes { get; set; }

        public List<Cidades> Listar(){
            return new List<Cidades>(){
                new Cidades {Id=10, Nome="Sorocaba", Estado ="SP", Habitantes=12456},
                new Cidades {Id=10, Nome="Piracicaba", Estado ="SP", Habitantes=65412},
                new Cidades {Id=10, Nome="Monte Verde", Estado ="MG", Habitantes=11111},
                new Cidades {Id=10, Nome="Belo Horizonte", Estado ="MG", Habitantes=85555},
                new Cidades {Id=10, Nome="Itu", Estado ="SP", Habitantes=84666},
                new Cidades {Id=10, Nome="Campinas", Estado ="SP", Habitantes=22222}
            };
            
        }
    }
}