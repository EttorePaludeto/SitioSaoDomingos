using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SaoDomingos.Web.Dev.Mvc.Dados
{
    public class DreDAL
    {
        public string DRE { get; set; }
        public string Financeiro { get; set; }
        public string Economico { get; set; }
        public string Contabil { get; set; }
        public decimal Valor { get; set; }

        private string connectionString { get; }

        public DreDAL()
        {
            connectionString = "Data Source =.\\SQLEXPRESS; Initial Catalog = Base_SaoDomingos; User ID = sa; Password = 123456;";
        }


        public IEnumerable<DreDAL> GetbyData(string DtIni, string DtFim)
        {
            List<DreDAL> lista = new List<DreDAL>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQL(DtIni, DtFim), con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DreDAL obj = new DreDAL();
                    obj.DRE = rdr["DRE"].ToString();
                    obj.Financeiro = rdr["Financeiro"].ToString();
                    obj.Economico = rdr["Economico"].ToString();
                    obj.Contabil = rdr["Contabil"].ToString();
                    obj.Valor = Convert.ToDecimal(rdr["Valor"]);
                    lista.Add(obj);
                }
                con.Close();
            }
            return lista;
        }

        private string SQL(string DtIni, string DtFim)
        {


            return $@"DECLARE @DT_INI AS DATE
            DECLARE @DT_FIM AS DATE
            SET @DT_INI = '{DtIni}'
            SET @DT_FIM = '{DtFim}'
            SELECT D.DRE, D.Financeiro, D.Economico, D.Contabil, SUM(VALOR) AS Valor  FROM 
            (
            select p.DRE, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor)* -1 as Valor from diario as d inner join PlanoContas as p on d.DebitoId = p.Id
            where d.Data between @DT_INI and @DT_FIM
            group by p.DRE, p.Financeiro, p.Economico, p.Contabil
            union
            select p.DRE, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor) as Valor from diario as d inner join PlanoContas as p on d.CreditoId = p.Id
            where d.Data between @DT_INI and @DT_FIM
            group by p.DRE, p.Financeiro, p.Economico, p.Contabil
            ) AS D
            GROUP BY D.DRE, D.Financeiro, D.Economico, D.Contabil
            HAVING D.DRE <> 'RESULTADO'";
        }
    }
}
