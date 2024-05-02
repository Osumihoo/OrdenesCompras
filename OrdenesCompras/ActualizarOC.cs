using SAPbobsCOM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesCompras
{
    internal class ActualizarOC
    {
        static public void AutorizarEntrada(int DocEntry, string numFactura)
        {
            SAPbobsCOM.Documents oPurchaseOrders;

            try
            {
                if (ConexionSAP.Open())
                {

                    int error;

                    oPurchaseOrders = ConexionSAP.myCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
                    
                    oPurchaseOrders.GetByKey(DocEntry);

                    oPurchaseOrders.UserFields.Fields.Item("U_EntradaAut").Value="2";
                    
                    if(oPurchaseOrders.NumAtCard.Equals(""))
                    {
                        oPurchaseOrders.NumAtCard = numFactura;

                    }

                    AdminInfo.UpdateAdminInfoYes();

                    error=oPurchaseOrders.Update();

                    if(error!=0)
                    {
                        string respuesta;

                        respuesta = ConexionSAP.myCompany.GetLastErrorDescription().ToString();
                    }

                    AdminInfo.UpdateAdminInfoNo();
                    ConexionSAP.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }



    }

}

