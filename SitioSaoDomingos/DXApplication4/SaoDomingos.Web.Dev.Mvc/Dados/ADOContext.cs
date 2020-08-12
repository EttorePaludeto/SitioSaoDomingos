using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SaoDomingos.Web.Dev.Mvc.Dados
{
    public class ADOContext
    {
        private IConfiguration _configuration;
        public string connString { get; set; }

        public ADOContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connString = _configuration.GetConnectionString("DefaultConnectionProd");
        }


        //Nâo funcionada ainda

        public IEnumerable<T> Getby<T>(string SQL) where T: class
        {
            List<T> lista = new List<T>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionProd")))
            {
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                  //Mapeamento da Classe no objeto datareader
                }
                con.Close();
            }
            return lista;
        }


    }
}
