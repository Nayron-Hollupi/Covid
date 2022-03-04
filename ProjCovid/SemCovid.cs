﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCovid
{
    internal class SemCovid
    {
        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }
        public Triagem Triagem { get; set; }

        public bool Vazio()
        {
            return Head == null && Tail == null;
        }

        public void Push(Paciente paciente)
        {
            if (Vazio())
            {
                Head = Tail = paciente;
            }
            else
            {
                Tail.Proximo = paciente;
                Tail = paciente;
            }
        }

        public void Print()
        {
            if (!Vazio())
            {
                Paciente paciente = Head;
                do
                {
                    Console.WriteLine(paciente.ToString());
                    paciente = paciente.Proximo;
                    Console.ReadKey();
                } while (paciente != null);
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t============ Nenhum registro ===============");
            }
        }

    }
}
