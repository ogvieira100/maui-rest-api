using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_project_rest.MVVM.Model
{
    public class ClienteRestPost
    {
        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }
    }

    public class ClienteRestPut
    {
        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }
    }
}
