using SaoDomingos.Business;
using SaoDomingos.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaoDomingos.App.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            DiarioServices diario = new DiarioServices();

            List<Diario> lista = diario.GetAll().ToList();


            foreach (var item in lista)
            {
                Console.WriteLine(String.Concat("Crédito: ", item.Credito.Contabil, " Débito: ", item.Debito.Contabil, "Hist: ", item.Historico, " Valor: ", item.Valor, " Usuario: ", item.Usuario.Nome, " Participante: ", item.Participante.Nome));
            }
            


            Console.ReadLine();

        }
    }
}
