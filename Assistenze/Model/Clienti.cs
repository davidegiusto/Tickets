using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistenze.Model
{
    class Cliente
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Assistenza { get; set; }
        public string Attivo { get; set; }

        public string Provincia { get; set; }
        public string ASL { get; set; }

        public string Contatto { get; set; }
        public string email { get; set; }

        public long IDCliente { get; set; }

    }


    class RicercaClienti : Sysgest
    {
        public List<Cliente> Clienti { get; set; }

        public RicercaClienti()
        {
            Clienti = new List<Cliente>();

        }

        

        public void Search(string Pattern)
        {
            string sql = @"SELECT
                            c.Cognome,c.Nome,c.Provincia,c.ASL,
                            CASE WHEN c.Assistenza = 1 OR c.Attivo=1 THEN 'SI' ELSE 'NO' END as AttAss,
                            REPLACE(RTRIM(LTRIM(RTRIM(c.Telefono) + '  ' + RTRIM(c.Cellulare) + '  ' + RTRIM(c.Fax))),'  ', ' - ') as Contatto,
                            c.Email,
                            c.IDCliente
                            FROM
                            dbo.tblClienti AS c ";

            if (Pattern.IndexOf("WHERE") > 0) { sql += Pattern; } else sql += "WHERE " + Pattern;
            this.OpenConnection();

            System.Data.DataTable dt = new System.Data.DataTable();


        }
    }
}
