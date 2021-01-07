using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Core.Shared.ModelViews
{
    /// <summary>
    /// Objeto utilizado para inserção de um novo cliente.
    /// </summary>
    public class NovoCliente
    {

        /// <summary>
        /// Nome do Cliente.
        /// </summary>
        /// <exemple>Carolline Santos</exemple>
       public String Nome { get; set; }

        /// <summary>
        /// Data de Nascimento do Cliente
        /// </summary>
        /// <example>1993-09-21</example>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Sexo do cliente.
        /// </summary>
        /// <exemple>M</exemple>
        public char Sexo { get; set; }

        /// <summary>
        /// Telefone do Cliente
        /// </summary>
        /// <example>DDDxxxxxxxxx</example>
        public String Telefone { get; set; }

        /// <summary>
        /// Número de documento do Cliente: CNH, CPF ou RG.
        /// </summary>
        /// <example>12DF234A</example>
        public String Documento { get; set; }
    }
}
