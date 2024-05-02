using Sap.Data.Hana;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesCompras
{
    public class ConexionHana
    {
        public DataTable Abierta()
        {
            HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");

            conn.Open();

            //string query = "SELECT \"DocEntry\", \"DocNum\", \"CardCode\", \"CardName\",\"DocDate\", \"DocTotal\" from SB1PRUEBA.OPOR WHERE  \"DocStatus\" = 'O' AND \"U_EntradaAut\" = '1'";
            //Puebla
            //string query = "SELECT \"DocEntry\", \"DocNum\", \"CardCode\", \"CardName\", \"DocTotal\", \"DocDate\" AS \"Fecha\", \"NumAtCard\" AS \"Numero de Factura\", \r\nCASE \"U_EntradaAut\" WHEN 1 THEN 'No Autorizado' ELSE 'Autorizado' END AS \"Autorización\" \r\nFROM SB1CSL.OPOR \r\nWHERE \"DocStatus\" = 'O' AND \"U_Sucursal\" = '04' AND \"U_EntradaAut\" = 1"; 
            //Monterrey
            string query = "SELECT \"DocEntry\", \"DocNum\", \"CardCode\", \"CardName\", \"DocTotal\", \"DocDate\" AS \"Fecha\", \"NumAtCard\" AS \"Numero de Factura\", \r\nCASE \"U_EntradaAut\" WHEN 1 THEN 'No Autorizado' ELSE 'Autorizado' END AS \"Autorización\" \r\nFROM SB1CSL.OPOR \r\nWHERE \"DocStatus\" = 'O' AND \"U_Sucursal\" = '03' AND \"U_EntradaAut\" = 1"; 
            //CDMX
            //string query = "SELECT \"DocEntry\", \"DocNum\", \"CardCode\", \"CardName\", \"DocTotal\", \"DocDate\" AS \"Fecha\", \"NumAtCard\" AS \"Numero de Factura\", \r\nCASE \"U_EntradaAut\" WHEN 1 THEN 'No Autorizado' ELSE 'Autorizado' END AS \"Autorización\" \r\nFROM SB1CSL.OPOR \r\nWHERE \"DocStatus\" = 'O' AND \"U_Sucursal\" = '02' AND \"U_EntradaAut\" = 1";
            HanaCommand cmd = new HanaCommand(query, conn);
            HanaDataAdapter data = new HanaDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            //conn.Close();
            return tabla;
            
        }

        public static void Cerrada()
        {
            HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");

            conn.Close();
        }

    }
}
