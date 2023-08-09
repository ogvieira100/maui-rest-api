using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Clientes
    {

        public string CPF { get; set; } 

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public decimal? Valor { get; set; }

        public Clientes()
        {
                Id = Guid.NewGuid();    
        }

    }
}
