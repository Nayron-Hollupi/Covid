using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCovid
{
    internal class Triagem
    {

        public string Sintomas { get; set; }
        public int SuspeitaCovid { get; set; }
        public int TempoSistomas { get; set; }
        public int Comorbidade { get; set; }
        public int Emergencia { get; set; }
        public Triagem Next { get; set; }
       

        public Triagem(string sintomas, int tempoSintomas, int comorbidade, int emergencia)
        {
            Sintomas = sintomas;
            TempoSistomas = tempoSintomas;
            Comorbidade = comorbidade;
            Emergencia = emergencia;

        }
        public override string ToString()
        {
            return   "\n\t\t\t\t\t Sintomas  :" + Sintomas + "\n\t\t\t\t\t Dias com Sintomas : " + TempoSistomas + "\n\t\t\t\t\t Quantidades de Comorbidades  : " + Comorbidade ;
        }

    }
}
