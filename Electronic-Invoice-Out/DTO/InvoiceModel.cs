using System;
using System.Collections.Generic;

namespace Electronic_Invoice_Out.DTO
{
    public class InvoiceModel
    {
        public string ProfileID { get; set; } = "reporting:1.0";
        public string InvoiceID { get; set; } = "SME00062";
        public string UUID { get; set; } = "6f4d20e0-6bfe-4a80-9389-7dabe6620f12";
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime IssueTime { get; set; } = DateTime.Now;
        public InvoiceTypeCode InvoiceTypeCode { get; set; }
        public string DocumentCurrencyCode { get; set; } = "SAR";
        public string TaxCurrencyCode { get; set; } = "SAR";

        public int LineCountNumeric { get; set; } = 2;
        public string ICVUUID { get; set; } = "62";
        public string PIHValue { get; set; } = "NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ==";
        public AccountingSupplier AccountingSupplier { get; set; }
        public AccountingCustomer AccountingCustomer { get; set; }
        public Delivery Delivery { get; set; }
        public PaymentMeans PaymentMeans { get; set; }
        public AllowanceCharge AllowanceCharge { get; set; }
        public TaxTotal TaxTotal { get; set; }
        public TaxTotals TaxTotals { get; set; }
        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }
        //public InvoiceLine InvoiceLine { get; set; }

        public List<InvoiceLine> InvoiceLine { get; set; }

        //public DocumentReferenceType[] AdditionalDocumentReference { get; set; }
        //public SupplierPartyType AccountingSupplierParty { get; set; }
        //public CustomerPartyType AccountingCustomerParty { get; set; }
        //public DeliveryType Delivery { get; set; }
        //public PaymentMeansType PaymentMeans { get; set; }
        //public AllowanceChargeType AllowanceCharge { get; set; }
        //public TaxTotalType[] TaxTotal { get; set; }
        //public MonetaryTotalType LegalMonetaryTotal { get; set; }
        //public MonetaryTotalType InvoiceLineType { get; set; }
    }

    public class InvoiceStandardModel
    {
        public string ProfileID { get; set; } = "reporting:1.0";
        public string InvoiceID { get; set; } = "SME00062";
        public string UUID { get; set; } = "6f4d20e0-6bfe-4a80-9389-7dabe6620f12";
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime IssueTime { get; set; } = DateTime.Now;
        public InvoiceTypeCode InvoiceTypeCode { get; set; }
        public string DocumentCurrencyCode { get; set; } = "SAR";
        public string TaxCurrencyCode { get; set; } = "SAR";
        public string ICVUUID { get; set; } = "62";
        public string PIHValue { get; set; } = "NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ==";
        public AccountingSupplier AccountingSupplier { get; set; }
        public StandardAccountingCustomer AccountingCustomer { get; set; }
        public Delivery Delivery { get; set; }
        public PaymentMeans PaymentMeans { get; set; }
        public AllowanceCharge AllowanceCharge { get; set; }
        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }
        public TaxTotal TaxTotal { get; set; }
        public TaxTotals TaxTotals { get; set; }
        //public InvoiceLine InvoiceLine { get; set; }

        public List<InvoiceLine> InvoiceLine { get; set; }

        //public DocumentReferenceType[] AdditionalDocumentReference { get; set; }
        //public SupplierPartyType AccountingSupplierParty { get; set; }
        //public CustomerPartyType AccountingCustomerParty { get; set; }
        //public DeliveryType Delivery { get; set; }
        //public PaymentMeansType PaymentMeans { get; set; }
        //public AllowanceChargeType AllowanceCharge { get; set; }
        //public TaxTotalType[] TaxTotal { get; set; }
        //public MonetaryTotalType LegalMonetaryTotal { get; set; }
        //public MonetaryTotalType InvoiceLineType { get; set; }
    }

    public class InvoiceTypeCode
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class AccountingSupplier
    {
        public string PartyIdentification { get; set; } = "454634645645654";
        public SupplierPostalAddress PostalAddress { get; set; }
        public PartyTaxScheme PartyTaxScheme { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }
    }

    public class AccountingCustomer
    {
        public string PartyIdentification { get; set; }
        public CustomerPostalAddress PostalAddress { get; set; }
        public CustomerPartyTaxScheme PartyTaxScheme { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }
    }

    public class StandardAccountingCustomer
    {
        public int PartyIdentification { get; set; }
        public StandardCustomerPostalAddress PostalAddress { get; set; }
        public PartyTaxScheme PartyTaxScheme { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }
    }

    public class PartyTaxScheme
    {
        public string CompanyID { get; set; }
        public string TaxScheme { get; set; }
    }

    public class CustomerPartyTaxScheme
    {
        public string TaxScheme { get; set; }
    }

    public class PartyLegalEntity
    {
        public string RegistrationName { get; set; }
    }

    public class SupplierPostalAddress
    {
        public string StreetName { get; set; } = "TEST";
        public string BuildingNumber { get; set; } = "3454";
        public string PlotIdentification { get; set; } = "1234";
        public string CitySubdivisionName { get; set; } = "fgff";
        public string CityName { get; set; }
        public string PostalZone { get; set; }
        public string CountrySubentity { get; set; }
        public string CountryCode { get; set; }
    }

    public class CustomerPostalAddress
    {
        public string StreetName { get; set; } = "TEST";
        public string AdditionalStreetName { get; set; }
        public string BuildingNumber { get; set; } = "3454";
        public string PlotIdentification { get; set; } = "1234";
        public string CitySubdivisionName { get; set; } = "fgff";
        public string CityName { get; set; }
        public string PostalZone { get; set; }
        public string CountrySubentity { get; set; }
        public string CountryCode { get; set; }
    }

    public class StandardCustomerPostalAddress
    {
        public string StreetName { get; set; } = "TEST";
        public string BuildingNumber { get; set; } = "3454";
        public string PlotIdentification { get; set; } = "1234";
        public string CitySubdivisionName { get; set; } = "fgff";
        public string CityName { get; set; }
        public string PostalZone { get; set; }
        public string CountryCode { get; set; }
    }

    public class Delivery
    {
        public DateTime ActualDeliveryDate { get; set; }
        public DateTime LatestDeliveryDate { get; set; }
    }

    public class PaymentMeans
    {
        public string Code { get; set; }
        public string InstructionNote { get; set; }
    }

    public class AllowanceCharge
    {
        public string ID { get; set; }
        public bool ChargeIndicator { get; set; }
        public string AllowanceChargeReason { get; set; }

        public string Amount { get; set; }
        public string TaxCategoryID { get; set; }
        
        
        public string TaxCategoryPercent { get; set; }
        public string TaxCategoryTaxSchemeID { get; set; }
    }

    public class PriceAllowanceCharge
    {
        public bool ChargeIndicator { get; set; }
        public string AllowanceChargeReason { get; set; }

         
        public string Amount { get; set; }
    }

    public class LegalMonetaryTotal
    {
         
        public string LineExtensionAmount { get; set; }

         
        public string TaxExclusiveAmount { get; set; }

         
        public string TaxInclusiveAmount { get; set; }

         
        public string AllowanceTotalAmount { get; set; }

         
        public string PrepaidAmount { get; set; }

         
        public string PayableAmount { get; set; }
    }

    public class TaxTotal
    {
         
        public string TaxAmount { get; set; }
        public TaxSubtotal TaxSubtotal { get; set; }

    }

    public class TaxSubtotal
    {
         
        public string TaxableAmount { get; set; }

         
        public string TaxAmount { get; set; }
        public TaxCategory TaxCategory { get; set; }
    }
    public class TaxTotals
    {
         
        public string TaxAmount { get; set; }
    }
    public class TaxCategory
    {
        public string ID { get; set; }
        public string TaxExemptionReasonCode { get; set; } = "SAR";
        public string TaxExemptionReason { get; set; } = "SAR";
        public string Percent { get; set; }
        public string TaxSchemeID { get; set; }
    }

    public class InvoiceLine
    {
        public int ID { get; set; }
         
        public string InvoicedQuantity { get; set; }
         
        public string LineExtensionAmount { get; set; }
        public InvoiceLineTaxTotal InvoiceLineTaxTotal { get; set; }
        public ItemModel Item { get; set; }
        public PriceModel Price { get; set; }
    }
    public class ItemModel
    {
        public string Name { get; set; }
        //  public string SellersItemIdentification { get; set; }
        public TaxCategory ClassifiedTaxCategory { get; set; }
    }
    public class PriceModel
    {
        public decimal PriceAmount { get; set; }
        public PriceAllowanceCharge AllowanceCharge { get; set; }
    }
    public class InvoiceLineTaxTotal
    {
         
        public string TaxAmount { get; set; }
         
        public string RoundingAmount { get; set; }
    }

    public class InvoiceLinePrice
    {
         
        public string PriceAmount { get; set; }
        public AllowanceChargeprice AllowanceChargeprice { get; set; }
    }
    public class AllowanceChargeprice
    {
        public bool ChargeIndicator { get; set; }
        public string AllowanceChargeReason { get; set; }
         
        public string Amount { get; set; }
    }

    public class InvoiceLineItem
    {
        public string Name { get; set; }
        public ClassifiedTaxCategory ClassifiedTaxCategory { get; set; }
    }

    public class ClassifiedTaxCategory
    {
        public int ID { get; set; }

        public decimal Percent { get; set; }
        public int TaxSchemeID { get; set; }
    }

    public class ResultOperation
    {
        public string Operation { get; set; }

        public bool IsValid { get; set; }

        public string ErrorMessage { get; set; }

        public string ResultedValue { get; set; }

        public List<ResultOperation> lstSteps { get; set; }

        public string SingedXML { get; set; }
    }


    public class InvoiceResult
    {
        public string Invoice { get; set; }
        public string InvoiceHash { get; set; }
        public string UUID { get; set; }
        public string QrCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
