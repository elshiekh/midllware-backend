using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mowadhafi_In.DTO;

namespace Mowadhafi_In.Mapper
{
    public static class ObjectToXML
    {

        public static string ToXMLTransactionStatuses(this GetTransactionStatusesRequest TransactionReferences)
        {
            //XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            //    new XElement("IQAMA_STATUS",
            //        from Itemm in TransactionReferences
            //        select new XElement("IQAMA_REC",
            //               new XElement("ESERVICE_ID", Itemm.EserviceID),
            //               new XElement("TRANSACTION_TYPE", Itemm.TransactionType)
            //    ))
            //);

            //return P_INV_TRX_SER_TBL.ToString();


            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("IQAMA_STATUS",
                    from Item in TransactionReferences.TransactionReferences
                    select new XElement("IQAMA_REC",
                            new XElement("ESERVICE_ID", Item.EserviceID),
                            new XElement("TRANSACTION_TYPE", Item.TransactionType)
                ))
            );

            return P_INV_TRX_SER_TBL.ToString();
        }


        public static string ToXMLTransactionDetails(this InsertTransactionDetailsRequest TransactionDetails)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("IQAMA_DETAILS",
                    from Item in TransactionDetails.TransactionDetails
                    select new XElement("IQAMA_REC",
                           new XElement("ESERVICE_ID", Item.EserviceID),
                           new XElement("TRANSACTION_TYPE", Item.TransactionType),
                           new XElement("EMPLOYEE_NUMBER", Item.EmployeeNumber),
                           new XElement("EMPLOYEE_NAME", Item.EmployeeName),
                           new XElement("IQAMA_NUMBER", Item.IqamaNumber),
                           new XElement("MONTH", Item.Month),
                           new XElement("REASON_CODE", Item.ReasonCode),
                           new XElement("PROFESSION_ID", Item.ProfessionID),
                           new XElement("PROFESSION", Item.Profession),
                           //new XElement("ISSUE_DATE", Item.IssueDate.ToString("MM/dd/yyyy hh:mm tt")),
                           //new XElement("EXPIRY_DATE", Item.ExpiryDate.ToString("MM/dd/yyyy hh:mm tt")),
                           new XElement("ISSUE_DATE", Item.IssueDate.ToString("yyyy-MM-dd HH:mm:ss")),
                           new XElement("EXPIRY_DATE", Item.ExpiryDate.ToString("yyyy-MM-dd HH:mm:ss")),
                           new XElement("CARD_NUMBER", Item.CardNumber),
                           new XElement("CARD_FEES", Item.CardFees),
                           new XElement("PENALTY_AMOUNT", Item.PenaltyAmount),
                           new XElement("COMPANY_CHARGES", Item.CompanyCharges),
                           new XElement("EMPLOYEE_CHARGES", Item.EmployeeCharges),
                           new XElement("NO_OF_INSTALLMENTS", Item.NoOfInstallments),
                           new XElement("INSTALLMENT_PERIOD", Item.InstallmentPeriod),
                           new XElement("SADAD_NUMBER", Item.SadadNumber)
                ))
            );

            return P_INV_TRX_SER_TBL.ToString();
        }


    }
}
