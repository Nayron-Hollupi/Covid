using System;

namespace ProjCovid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sair = 1, leitos = 0, fim = 9;
            int senha = 0;
            
            
            Preferencial preferencial = new Preferencial();
            NaoPreferencial naoPreferencial = new NaoPreferencial();
            SemCovid semCovid = new SemCovid();
            Quaretena quarentena = new Quaretena();
            FilaEspera  filaEspera = new FilaEspera();


            Console.Write("\n \t\t\t\t\tDigite a quantidade de leitos :");
             leitos = int.Parse(Console.ReadLine());

            string Menu()
            {
                Console.WriteLine("\n\t\t\t\t>>>>>>>>>>>>>>>> Covid <<<<<<<<<<<<<<<<");



                Console.WriteLine("\n \t\t\t\t\t 1 - Cadastrar Paciente " +
                    "  \n \t\t\t\t\t 2 - Chamar para Triagem " +
                    " \n \t\t\t\t\t 3 - Verificar Leitos Disponiveis" +                      
                    " \n \t\t\t\t\t 4 - Adquirir senha" +
                    "\n \t\t\t\t\t 5 - Quantidade de senhas" +
                     "\n \t\t\t\t\t 6 - Verificar Filas" +
                    "\n \t\t\t\t\t 7 - Sair ");
                Console.Write("\t\t\t\t\tOpcao :");
                string opcao = Console.ReadLine();

                return opcao;

            }
            string SubMenu()
            {
                Console.WriteLine("\n\t\t\t\t>>>>>>>>>>>>>>>> Filas <<<<<<<<<<<<<<<<");



                Console.WriteLine("\n \t\t\t\t\t 1 - Fila Preferencial " +
                    "  \n \t\t\t\t\t 2 - Fila nao Preferencial " +
                    " \n \t\t\t\t\t 3 - Fila de espera" +
                     " \n \t\t\t\t\t 4 - Quarentena" +
                    " \n \t\t\t\t\t 5 - Suspeita de Covid" +
                
                    "\n \t\t\t\t\t 6 - Sair ");
                Console.Write("\t\t\t\t\tOpcao :");
                string op = Console.ReadLine();

                return op;

            }
            void Cadastrar()
            {
                Console.WriteLine("\n\t\t\t\t>>>>>>>>>>>>>>>> Cadastrar Paciente<<<<<<<<<<<<<<<<");
                Console.Write("\n \t\t\t\t\tDigite o nome do paciente :");
                string nome = Console.ReadLine();
                Console.Write("\n\t\t\t\t\t Digite a data de nascimento :");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                Console.Write("\n \t\t\t\t\tDigite o CPF :");
                string cpf = Console.ReadLine();

                int Age = (DateTime.Now - dataNascimento).Days / 365;

                if (Age >= 60)
                {
                    preferencial.Push(new Paciente(nome, dataNascimento, cpf));
                }
                else
                {
                    naoPreferencial.Push(new Paciente(nome, dataNascimento, cpf));

                }

            }


            int cont = 1;
            void RegistrarTriagem()
            {
                string todosSintomas = "";
                int sintomas;

                if (naoPreferencial.Vazio() && preferencial.Vazio())
                {
                    Console.WriteLine("\n\t\t\t\t\t===============Nenhum registro =================");
                }
                else
                {
                    do
                    {
                        Console.WriteLine("\n\t\t\t\t\t=============== Registro da Triagem =================");
                        Console.WriteLine("\n\t\t\t\t\tQual Sintomas o paciente tem: \n \t\t\t\t\t 1-Febre" +
                            "\n\t\t\t\t\t 2-Perda de paladar" +
                            "\n \t\t\t\t\t 3-Perda de olfato" +
                            "\n \t\t\t\t\t 4-Dor de cabeça" +
                            "\n \t\t\t\t\t 0-Sair");

                        Console.Write("\n\t\t\t\t\tEscolha uma opcao : ");
                        sintomas = int.Parse(Console.ReadLine());

                        if (sintomas != 0)
                        {
                            todosSintomas += " , ";
                            switch (sintomas)
                            {
                                case 1:
                                    todosSintomas += "\n Febre";
                                    break;
                                case 2:
                                    todosSintomas += "Perda de paladar";
                                    break;
                                case 3:
                                    todosSintomas += "Perda de olfato";
                                    break;
                                case 4:
                                    todosSintomas += "Dor de cabeça";
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (sintomas != 0);


                    Console.Write("\n\t\t\t\t\t Quantidade de comorbidades : ");
                    int comorbidade = int.Parse(Console.ReadLine());

                    Console.Write("\n\t\t\t\t\t Quantos dias o paciente esta com os sintomas : ");
                    int tempoSintomas = int.Parse(Console.ReadLine());

                    Console.Write("\n\t\t\t\t\t Se for emargencia digite 1 se não 2  : ");
                    int urgencia = int.Parse(Console.ReadLine());

                    

                     

                    if (preferencial.Head != null && Cont())
                    {
                        preferencial.Head.Triagem = new Triagem(todosSintomas, tempoSintomas, comorbidade, urgencia);
                      
                        if (urgencia == 1)
                        {
                            if (leitos == 0)
                            {
                                filaEspera.Push(new Emergencia(preferencial.Head.Nome, preferencial.Head.DataNascimento, preferencial.Head.Cpf, todosSintomas, tempoSintomas, comorbidade));
                            }
                            else
                            {
                                leitos--;
                            }
                        }

                        else if (tempoSintomas > 3 && comorbidade > 1 && todosSintomas != null)
                        {
                            quarentena.Push(new Suspeita(preferencial.Head.Nome, preferencial.Head.DataNascimento, preferencial.Head.Cpf, todosSintomas, tempoSintomas, comorbidade));

                        }
                        else if (tempoSintomas < 2)
                        {
                           
                        }
                        Paciente preferencia = preferencial.Pop();

                    }
                    else if(naoPreferencial.Head != null)
                    {

                        naoPreferencial.Head.Triagem = new Triagem(todosSintomas, tempoSintomas, comorbidade, urgencia);
                      
                        if (urgencia == 1)
                        {
                            if (leitos == 0)
                            {
                                filaEspera.Push(new Emergencia(naoPreferencial.Head.Nome, naoPreferencial.Head.DataNascimento, naoPreferencial.Head.Cpf, todosSintomas, tempoSintomas, comorbidade));
                            }
                            else
                            {
                                leitos--;
                            }
                        }

                        else if (tempoSintomas > 3 && comorbidade > 1 && todosSintomas != null)
                        {
                            quarentena.Push(new Suspeita(naoPreferencial.Head.Nome, naoPreferencial.Head.DataNascimento, naoPreferencial.Head.Cpf, todosSintomas, tempoSintomas, comorbidade));

                        }
                        else if (tempoSintomas < 2)
                        {

                        }
                        Paciente paciente = naoPreferencial.Pop();
                        cont++;
                    }
                  
                }

            }
            
             bool Cont()
            {
                if (cont < 2)
                {
                    cont = 0;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            do
            {
                switch (Menu())
                {
                    case "1":
                        Console.Clear();
                        Cadastrar();
                        break;
                      case "2":
                        Console.Clear();
                        RegistrarTriagem();
                        break;
                
                    case "3":
                        Console.WriteLine("\t\t\t\t\tQuantidade de leitos disponiveis : " + leitos);
                        break;
                  
                    case "4":
                        senha++;
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\tQuantidades de senhas : " + senha);
                        break;
                    case "6":
                        do
                        {
                            switch (SubMenu())
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("\n\t\t\t\t>>>>>>>>>>>>>>>> Fila Preferencial <<<<<<<<<<<<<<<<");
                                    preferencial.Print();
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("\n\t\t\t\t>>>>>>>>>>>>>>>> Fila nao Preferencial <<<<<<<<<<<<<<<<");
                                    naoPreferencial.Print();
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("\n\t\t\t\t>>>>>>>>>>>>>>>> Fila de Espera <<<<<<<<<<<<<<<<");
                                    filaEspera.Print();
                                    break;
                                case "4":
                                    Console.Clear();
                                    Console.WriteLine("\n\t\t\t\t>>>>>>>>>>>>>>>> Fila de Emergencia <<<<<<<<<<<<<<<<");
                                    quarentena.Print();
                                    break;
                                case "5":
                                    Console.Clear();
                                    Console.WriteLine("\n\t\t\t\t>>>>>>>>>>>>>>>> Fila de Quarentena <<<<<<<<<<<<<<<<");
                                    quarentena.Print();
                                    break;
                                case "6":
                                    fim = 0;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("\t\t\t\t\t>>>>Opcao invalida>>>>>>>");
                                    break;

                            }
                        } while (fim != 0);
                        break;
                                                                             
                    case "7":
                        sair = 0;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t>>>>Opcao invalida>>>>>>>");
                        break;
                }

            } while (sair != 0);
        }
    }
}
