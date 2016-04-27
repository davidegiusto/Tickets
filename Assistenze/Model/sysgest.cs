using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Assistenze.Model
{

    public class Sysgest
    {
        public string connectionString { get; set; }
        private SqlConnection conn { get; set; }
        public System.Data.ConnectionState Status
        {
            get; private set;
        }

        public string StandardFilter { get; set; }



        public long GetNextFreeIDRegistrazione()
        {
            try
            {

                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("SELECT MAX(IDRegistrazione) FROM dbo.tblAssistenze", conn);
                    return (long)cmd.ExecuteScalar();
                }
                else throw new Exception("Connection or ConnectionString error");


            }
            catch (Exception)
            {

                throw;
            }

        }
        public Sysgest()
        {
            ///Internal not distributed program. Not secure string.
            this.connectionString = @"Server=HP-WIN2008-EE\SQLIATROS;Database=SysGest;User Id=iatros;Password = iatros3000; ";
            this.StandardFilter = "a.CodiceStato='A' AND (a.Operatore = 1 OR a.Operatore = 10)";

            conn = new SqlConnection(this.connectionString);
        }
        public bool OpenConnection()
        {
            try
            {

                if (conn == null) throw new Exception("Invalid connection. Null value not allowed.");

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    if (connectionString != null && connectionString != "")
                    {
                        conn.ConnectionString = this.connectionString;
                        conn.Open();
                    }
                }
                this.Status = conn.State;

                return (this.Status == System.Data.ConnectionState.Open);
            }
            catch (Exception)
            {

                throw;
            }
        }



        public DataTable GetDataTableAssistenze(string filter = "a.CodiceStato='A' AND (a.Operatore = 1 OR a.Operatore = 10)")
        {
            DataTable dt = new DataTable();
            if (OpenConnection())
            {

                string sql = string.Format(@"SELECT a.IDRegistrazione, c.Cognome , c.nome,
                        CASE WHEN OraInizio <> '' THEN 
                                CONVERT(DateTime, a.DataInizio + ' ' + Replace(OraInizio, '.', ':') + ':00.000') 
                        ELSE  
                                CONVERT(DateTime, a.DataInizio + ' 00:00:00.000')  END
                            as DataInizio, 
                        a.Problema, a.Azione, a.CodiceAttribuzione, a.CodiceStato
                        ,CONVERT(DateTime, a.DataFine, 104) as DataFine
                    FROM dbo.tblAssistenze a 
                    INNER JOIN dbo.tblClienti c ON a.IDCliente = c.IDCliente 
                    WHERE {0} ORDER BY a.DataInizio", filter);

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(dt);
            

            }
            return dt;

            }
    }

}
