using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Core.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public String Telefone { get; set; }
        public String Documento { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

    }
}
