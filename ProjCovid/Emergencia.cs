using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCovid
{
    internal class Emergencia
    {
        public Emergencia Cabeca { get; set; }
        public Emergencia Cauda { get; set; }
        public Emergencia Proximo { get; set; }     
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }  
        public string Sintomas { get; set; }
        public int SuspeitaCovid { get; set; }
        public int TempoSistomas { get; set; }
        public int Comorbidade { get; set; }
     


        public Emergencia(string nome, DateTime dataNascimento, string cpf, string sintomas, int tempoSintomas, int comorbidade)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Sintomas = sintomas;
            TempoSistomas = tempoSintomas;
            Comorbidade = comorbidade;
           

        }
        public override string ToString()
        {
            return "\n\t\t\t\t\t Name :" + Nome + "\n\t\t\t\t\t Birth Year : " + DataNascimento.ToString("dd/MM/yyyy") + "\n\t\t\t\t\t CPF : " + Cpf + "\n\t\t\t\t\t  Sintomas: " + Sintomas + "\n\t\t\t\t\t Quantidade de dias que o paciente teve sintomas : " + TempoSistomas + "\n\t\t\t\t\t  Quantidade de Comorbidade : " + Comorbidade;
        }


    }
}
