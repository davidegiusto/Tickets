using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace Assistenze
{

    //INTERFACCIA AL DB
    class Assistenza : Model.Sysgest
    {

        ///campi aggiuntivi per identificazione 
        /// 
        public string Cognome { get; set; }
        public string Nome { get; set; }


        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        /// <summary>
        /// Descrizione iniziale
        /// </summary>
        public string Problema { get; set; }

        /// <summary>
        /// Campi aggiornabili a chiusura
        /// </summary>
        public string Azione { get; set; }
        public string CodiceStato { get; set; }
        public string CodiceAttribuzione { get; set; }

        /// <summary>
        /// Campi per apertura Assistenza automatici
        /// </summary>
        public long IDRegistrazione { get; set; }


        //private Sysgest SysGestDB;


        public Assistenza()
        {
            //this.SysGestDB = new Sysgest();

        }

        public void Nuova()
        {
            if (this.OpenConnection())
            {
                IDRegistrazione = this.GetNextFreeIDRegistrazione();
            }
            else
                //TODO: segnaposto gestione mancata connessione
                throw new Exception("Connection error.");
        }

        public void Load(long IDRegistrazione)
        {
            //SysGestDB
        }

    }



}
