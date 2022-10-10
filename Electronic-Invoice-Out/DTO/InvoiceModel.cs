using System;
using System.Collections.Generic;
using UblLarsen.Ubl2.Cac;

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
    public class InvoiceTypeCode {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class AccountingSupplier
    {
        public long PartyIdentification { get; set; } = 454634645645654;
        public PostalAddress PostalAddress { get; set; }
        public PartyTaxScheme PartyTaxScheme { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }
    }

    public class AccountingCustomer
    {
        public int PartyIdentification { get; set; }
        public PostalAddress PostalAddress { get; set; }
        public PartyTaxScheme PartyTaxScheme { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }
    }

    public class PartyTaxScheme
    {
        public string CompanyID { get; set; }
        public string TaxScheme { get; set; }
    }

    public class PartyLegalEntity
    {
        public string RegistrationName { get; set; }
    }

    public class PostalAddress
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

    public class Delivery
    {
        public DateTime ActualDeliveryDate { get; set; }
        public DateTime? LatestDeliveryDate { get; set; }
    }

    public class PaymentMeans
    {
        public string Code { get; set; }
    }

    public class AllowanceCharge
    {
        public string ID { get; set; }
        public bool ChargeIndicator { get; set; }
        public string AllowanceChargeReason { get; set; }
        public decimal Amount { get; set; }
        public string TaxCategoryID { get; set; }
        public decimal TaxCategoryPercent { get; set; }
        public string TaxCategoryTaxSchemeID { get; set; }
    }

    public class LegalMonetaryTotal
    {
        public decimal LineExtensionAmount { get; set; }
        public decimal TaxExclusiveAmount { get; set; }
        public decimal TaxInclusiveAmount { get; set; }
        public decimal AllowanceTotalAmount { get; set; }
        public decimal PrepaidAmount { get; set; }
        public decimal PayableAmount { get; set; }
    }

    public class TaxTotal
    {
        public decimal TaxAmount { get; set; }
        public TaxSubtotal TaxSubtotal { get; set; }

    }

    public class TaxSubtotal
    {
        public decimal TaxableAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public TaxCategory TaxCategory { get; set; }
    }
    public class TaxTotals
    {
        public decimal TaxAmount { get; set; }
    }
    public class TaxCategory
    {
        public string ID { get; set; }
        public decimal Percent { get; set; }
        public string TaxSchemeID { get; set; }
    }

    public class InvoiceLine
    {
        public int ID { get; set; }
        public decimal InvoicedQuantity { get; set; }
        public decimal LineExtensionAmount { get; set; }
        public InvoiceLineTaxTotal InvoiceLineTaxTotal { get; set; }
        public ItemModel Item { get; set; }
        public PriceModel Price { get; set; }
    }
    public class ItemModel  {
        public string  Name { get; set; }
        public string SellersItemIdentification { get; set; }
        public TaxCategory ClassifiedTaxCategory { get; set; }
    }
    public class PriceModel {
        public decimal PriceAmount { get; set; }
        public AllowanceCharge AllowanceCharge { get; set; }
    }
    public class InvoiceLineTaxTotal
    {
        public decimal TaxAmount { get; set; }
        public decimal RoundingAmount { get; set; }
    }

    public class InvoiceLinePrice
    {
        public decimal PriceAmount { get; set; }
        public AllowanceChargeprice AllowanceChargeprice { get; set; }
    }
    public class AllowanceChargeprice
    {
        public bool ChargeIndicator { get; set; }
        public string AllowanceChargeReason { get; set; }
        public decimal Amount { get; set; }
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


    public class InvoiceResult {

        public string invoice { get; set; }
        public string  InvoiceHash { get; set; }
        public string QrCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
