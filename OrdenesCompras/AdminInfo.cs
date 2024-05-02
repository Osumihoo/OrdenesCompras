using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesCompras
{
    internal class AdminInfo
    {
        static public void UpdateAdminInfoYes()
        {
            //ACTIVAR PARAMETRIZACIONES DEL SISTEMA
            SAPbobsCOM.CompanyService oCompanyService;
            SAPbobsCOM.AdminInfo oAdminInfo;

            try
            {
                oCompanyService = ConexionSAP.myCompany.GetCompanyService();
                oAdminInfo = ConexionSAP.myCompany.GetCompanyService().GetAdminInfo();

                //oCompanyService
                //oAdminInfo.CloseCountedRowsWithoutConfirmation
                //oAdminInfo.PurchaseOrderConfirmed
                //oAdminInfo.RestrictOrders
                oAdminInfo.EnableUpdateDocAfterApproval = SAPbobsCOM.BoYesNoEnum.tYES;
                oAdminInfo.EnableUpdateDraftDuringApproval = SAPbobsCOM.BoYesNoEnum.tYES;
                oAdminInfo.EnableAuthorizerUpdatePendingDraft = SAPbobsCOM.BoYesNoEnum.tYES;

                
                oCompanyService.UpdateAdminInfo(oAdminInfo);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
        static public void UpdateAdminInfoNo()
        {
            //DESACTIVAR PARAMETRIZACIONES DEL SISTEMA
            SAPbobsCOM.CompanyService oCompanyService;
            SAPbobsCOM.AdminInfo oAdminInfo;

            try
            {
                oCompanyService = ConexionSAP.myCompany.GetCompanyService();
                oAdminInfo = ConexionSAP.myCompany.GetCompanyService().GetAdminInfo();

                //oCompanyService
                //oAdminInfo.CloseCountedRowsWithoutConfirmation
                //oAdminInfo.PurchaseOrderConfirmed
                //oAdminInfo.RestrictOrders
                oAdminInfo.EnableUpdateDocAfterApproval = SAPbobsCOM.BoYesNoEnum.tNO;
                oAdminInfo.EnableUpdateDraftDuringApproval = SAPbobsCOM.BoYesNoEnum.tNO;
                oAdminInfo.EnableAuthorizerUpdatePendingDraft = SAPbobsCOM.BoYesNoEnum.tNO;

                oCompanyService.UpdateAdminInfo(oAdminInfo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }
    }
}
