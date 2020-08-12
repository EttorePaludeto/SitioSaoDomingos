using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SaoDomingos.Web.Dev.Mvc.Dados
{
    public class BalanceteDAL
    {
        public int Id { get; set; }
        public string Grupo { get; set; }
        public string SubGrupo { get; set; }
        public string Financeiro { get; set; }
        public string Economico { get; set; }
        public string Contabil { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public decimal SaldoFinal { get; set; }

        private readonly ADOContext _ctx;

        public BalanceteDAL(ADOContext context)
        {
            _ctx = context;
        }

        public IEnumerable<BalanceteDAL> GetbyData(string DtIni, string DtFim, string Conta)
        {
            List<BalanceteDAL> lista = new List<BalanceteDAL>();
            using (SqlConnection con = new SqlConnection(_ctx.connString))
            {
                SqlCommand cmd = new SqlCommand(SQL(DtIni, DtFim, Conta), con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BalanceteDAL obj = new BalanceteDAL(_ctx);
                    obj.Id = Convert.ToInt32(rdr["Id"]);
                    obj.Grupo = rdr["Grupo"].ToString();
                    obj.SubGrupo = rdr["SubGrupo"].ToString();
                    obj.Financeiro = rdr["Financeiro"].ToString();
                    obj.Economico = rdr["Economico"].ToString();
                    obj.Contabil = rdr["Contabil"].ToString();
                    obj.SaldoInicial = Convert.ToDecimal(rdr["SaldoInicial"]);
                    obj.Debito = Convert.ToDecimal(rdr["Debito"]);
                    obj.Credito = Convert.ToDecimal(rdr["Credito"]);
                    obj.SaldoFinal = Convert.ToDecimal(rdr["SaldoFinal"]);
                    lista.Add(obj);
                }
                con.Close();
            }
            return lista;
        }

        private string SQL(string DtIni, string DtFim, string Conta)
        {
            return $@"DECLARE @DT_INI AS DATE
            DECLARE @DT_FIM AS DATE
            DECLARE @DT_FECHA AS DATE --DATA DE FECHAMENTO DO ÚLTIMO BALANÇO (Normalmente em 31/12/XX) => SaldoInicial = Between DtFechamento e DtInicial
            SET @DT_INI = '{DtIni}'
            SET @DT_FIM = '{DtFim}'
		    SELECT ROW_NUMBER() OVER(ORDER BY BALANCETE.CONTABIL) AS Id, BALANCETE.Grupo, BALANCETE.SubGrupo, BALANCETE.Financeiro, BALANCETE.Economico, BALANCETE.Contabil, SUM(BALANCETE.SaldoInicial) As SaldoInicial, SUM(BALANCETE.Debito) AS Debito, SUM(BALANCETE.Credito) As Credito, SUM(BALANCETE.SaldoInicial + BALANCETE.Debito - BALANCETE.Credito) As SaldoFinal FROM 
		    (
			SELECT D.Grupo, D.SubGrupo, D.Financeiro, D.Economico, D.Contabil, 0 AS SaldoInicial, Sum(D.Debito) As Debito, Sum(D.Credito) AS Credito, Sum(D.Debito-D.Credito) As SaldoMovimento FROM 
            (
            select p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor) as Debito, 0 as Credito from diario as d inner join PlanoContas as p on d.DebitoId = p.Id
            where d.Data between @DT_INI and @DT_FIM
            group by p.Grupo, p.SubGrupo,  p.Financeiro, p.Economico, p.Contabil
            union
            select p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil, 0 as Debito, SUM(d.valor) as Credito from diario as d inner join PlanoContas as p on d.CreditoId = p.Id
            where d.Data between @DT_INI and @DT_FIM
            group by p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil
            ) AS D
            GROUP BY D.Grupo, D.SubGrupo, D.Financeiro, D.Economico, D.Contabil
            UNION

			--SALDO INICIAL
			 SELECT D.Grupo, D.SubGrupo, D.Financeiro, D.Economico, D.Contabil, SUM(d.SaldoInicial) AS SaldoInicial, 0 As Debito, 0 AS Credito, 0 As SaldoFinal FROM 
            (
            select p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor) AS SaldoInicial, 0 as Debito, 0 as Credito from diario as d inner join PlanoContas as p on d.DebitoId = p.Id
            where d.Data < @DT_INI
            group by p.Grupo, p.SubGrupo,  p.Financeiro, p.Economico, p.Contabil
            union
            select p.Grupo, p.SubGrupo, p.Financeiro, p.Economico, p.Contabil, SUM(d.valor)*-1 AS SaldoInicial,  0 as Debito, 0 as Credito from diario as d inner join PlanoContas as p on d.CreditoId = p.Id
            where d.Data < @DT_INI
            group by p.Grupo, p.SubGrupo,  p.Financeiro, p.Economico, p.Contabil
            ) AS D
            GROUP BY D.Grupo, D.SubGrupo,D.Financeiro, D.Economico, D.Contabil
	         ) AS BALANCETE
	    	 GROUP BY BALANCETE.Grupo, BALANCETE.SubGrupo, BALANCETE.Financeiro, BALANCETE.Economico, BALANCETE.Contabil";

        }
    }




}
