using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Core.Shared.ModelViews
{
    public class NovoCliente
    {
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public String Telefone { get; set; }
        public String Documento { get; set; }
    }
}
