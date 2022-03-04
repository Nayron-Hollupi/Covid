using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCovid
{
    internal class Paciente
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public Paciente Proximo { get; set; }
        public Preferencial Preferencial { get; set; }
        public NaoPreferencial NaoPreferencial { get; set; }
        public Triagem Triagem { get; set; }


        
        public Paciente(string nome, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Triagem = null;
        }

        public override string ToString()
        {
            return "\n\t\t\t\t\t Name :" + Nome + "\n\t\t\t\t\t Birth Year : " + DataNascimento.ToString("dd/MM/yyyy") + "\n\t\t\t\t\t CPF : " + Cpf ;
        }

    
       



    }




    }

