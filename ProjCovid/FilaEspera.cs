using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCovid
{
    internal class FilaEspera
    {
   
        public Emergencia Cabeca { get; set; }
        public Emergencia Cauda{ get; set; }

        public bool Vazio()
        {
            return Cabeca == null && Cauda == null;
        }

        public void Push(Emergencia emergencia)
        {
            if (Vazio())
            {
                Cabeca = Cauda = emergencia;
            }
            else
            {
                Cauda.Proximo = emergencia;
                Cauda = emergencia;
            }
        }

        public void Print()
        {
            if (!Vazio())
            {
                Emergencia emergencia = Cabeca;
                do
                {
                    Console.WriteLine(emergencia.ToString());
                    emergencia = emergencia.Proximo;
                    Console.ReadKey();
                } while (emergencia != null);
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t============ Nenhum registro ===============");
            }
        }
    }
}
