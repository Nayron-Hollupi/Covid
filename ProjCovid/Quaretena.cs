using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCovid
{
    internal class Quaretena
    {
        Suspeita Suspeita { get; set; }
        public Suspeita Cabeca { get; set; }
        public Suspeita Cauda { get; set; }

        public bool Vazio()
        {
            return Cabeca == null && Cauda == null;
        }

        public void Push(Suspeita suspeita)
        {
            if (Vazio())
            {
                Cabeca = Cauda = suspeita;
            }
            else
            {
                Cauda.Proximo = suspeita;
                Cauda = suspeita;
            }
        }

        public void Print()
        {
            if (!Vazio())
            {
                Suspeita suspeita = Cabeca;
                do
                {
                    Console.WriteLine(suspeita.ToString());
                    suspeita = suspeita.Proximo;
                    Console.ReadKey();
                } while (suspeita != null);
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t============ Nenhum registro ===============");
            }
        }

    }
}
