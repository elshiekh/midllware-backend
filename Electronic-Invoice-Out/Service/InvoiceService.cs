using System;
using System.Threading.Tasks;
using UblLarsen.Tools;
using UblLarsen.Ubl2;
using UblLarsen.Ubl2.Cac;
using UblLarsen.Ubl2.Udt;

namespace Electronic_Invoice_Out.Service
{
    public interface IInvoiceService
    {
        Task<InvoiceType> GenerateXML(InvoiceType obj);
    }
    public class InvoiceService : IInvoiceService
    {
        public async Task<InvoiceType> GenerateXML(InvoiceType obj)
        {
            Func<decimal, AmountType> newAmountType = v => new AmountType { Value = v, currencyID = "SAR" };
            var taxVAT = new TaxSchemeType { ID = "VAT" };
            // Create an invoice using global defaults set above
            InvoiceType doc = new InvoiceType
            {
                UBLExtensions = new UblLarsen.Ubl2.Ext.UBLExtensionType[]{ 
                    new UblLarsen.Ubl2.Ext.UBLExtensionType{
                        ExtensionAgencyURI = "urn:oasis:names:specification:ubl:dsig:enveloped:xades",
                        //ExtensionContent = SignatureType{ }
                      }
                },
                CustomizationID = "urn:oasis:names:specification:ubl:xpath:Invoice-2.0:sbs-1.0-draft",
                ProfileID = "reporting:1.0",
                ID = "SME00062",
                UUID = "6f4d20e0-6bfe-4a80-9389-7dabe6620f12",
                IssueDate = new DateTime(2022, 03, 13),
                IssueTime = DateTime.Now,
                InvoiceTypeCode = new CodeType { name = "0211010", Value = "388" },
                DocumentCurrencyCode = "SAR",
                TaxCurrencyCode = "SAR",
                AdditionalDocumentReference = new DocumentReferenceType[] {
                    new DocumentReferenceType { ID = "ICV",UUID = "62" },
                    new DocumentReferenceType { ID = "PIH" , Attachment= new AttachmentType { EmbeddedDocumentBinaryObject = new BinaryObjectType{ mimeCode = "text/plain" , Value = System.Convert.FromBase64String("NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ==") } } },
                    new DocumentReferenceType { ID = "QR" , Attachment= new AttachmentType { EmbeddedDocumentBinaryObject = new BinaryObjectType{ mimeCode = "text/plain" , Value = System.Convert.FromBase64String("ARdBaG1lZCBNb2hhbWVkIEFMIEFobWFkeQIPMzAxMTIxOTcxNTAwMDAzAxQyMDIyLTAzLTEzVDE0OjQwOjQwWgQHMTEwOC45MAUFMTQ0LjkGLFFuVkVleFc0bld2NENhRTM5YS82NkpwL09YTy9ldkhROHBEbEc3d2VxLzQ9B1gwVjAQBgcqhkjOPQIBBgUrgQQACgNCAARhgwyg5oVgCEw7+y16i19nJq+vqnXVJKXCwr1rOawtjtvVv4UuGowCuEHZ2ocpujGoo1++QoN4+GmqO6LmFyfRCCEAv8K/KgKZkw7MAqiu3yuqN12A/0a8bAs9CXWI8FollMoJIHVesAI1Q4ocf4i6DJAoXnj9kQ93F5ManRi6KnmapY1O") } } }
                },
                AccountingSupplierParty = new SupplierPartyType
                {
                    Party = new PartyType
                    {
                        PartyName = new PartyNameType[] { new PartyNameType { Name = "Leverandør" } },
                        PostalAddress = new AddressType
                        {
                            Postbox = "Postboks 123",
                            StreetName = "Oslogate",
                            BuildingNumber = "1",
                            CityName = "Oslo",
                            PostalZone = "0612",
                            Country = new CountryType { IdentificationCode = "NO" },
                        },
                        PartyTaxScheme = new PartyTaxSchemeType[]
                        {
                            new PartyTaxSchemeType
                            {
                                CompanyID = "NO999999999MVA",
                                TaxScheme = new TaxSchemeType
                                {
                                    ID = new IdentifierType
                                    {
                                        schemeID = "UN/ECE 5153",
                                        schemeAgencyID = "6",
                                        Value = "VAT"
                                    }
                                }
                            }
                        },
                        PartyLegalEntity = new PartyLegalEntityType[]
                        {
                            new PartyLegalEntityType { CompanyID = "999999999" }
                        },
                        Contact = new ContactType { ID = "O Hansen" },
                    }
                },
                AccountingCustomerParty = new CustomerPartyType
                {
                    Party = new PartyType
                    {
                        PartyIdentification = new[] { new PartyIdentificationType { ID = "456789" } },
                        PartyName = new[] { new PartyNameType { Name = "Kjøper" } },
                        PostalAddress = new AddressType
                        {
                            StreetName = "Testveien",
                            BuildingNumber = "1",
                            CityName = "Frogner",
                            PostalZone = "2012",
                            Country = new CountryType { IdentificationCode = "NO" }
                        },
                        PartyLegalEntity = new PartyLegalEntityType[]
                        {
                            new PartyLegalEntityType { CompanyID = "NO888888888MVA" }
                        },
                        Contact = new ContactType { ID = "Arne Bjarne Baluba" }
                    }
                },
                Delivery = new DeliveryType[]
                {
                    new DeliveryType
                    {
                        ActualDeliveryDate =  new DateTime(2009,11,25),
                        DeliveryLocation = new LocationType
                        {
                            Address = new AddressType
                            {
                                StreetName = "Testgata",
                                BuildingNumber = "1",
                                CityName = "Oslo",
                                PostalZone = "0112",
                                Country = new CountryType { IdentificationCode = "NO"}
                            }
                        }
                    }
                },
                PaymentMeans = new PaymentMeansType[]
                {
                    new PaymentMeansType
                    {
                        PaymentMeansCode = "31",
                        PaymentDueDate = new DateTime(2009, 11, 27),
                        PaymentID = new UblLarsen.Ubl2.Udt.IdentifierType[] { "1234561" },
                        PayeeFinancialAccount = new FinancialAccountType
                        {
                            ID = "NO9386011117947",
                            FinancialInstitutionBranch = new BranchType
                            {
                                ID = new IdentifierType { schemeID="BIC", Value="DNBANOKK"},
                            }
                        }
                    }
                },
                AllowanceCharge = new AllowanceChargeType[] {
                    new AllowanceChargeType {
                        ID = "1", ChargeIndicator = false,
                        AllowanceChargeReason = new TextType[] {"discount" } ,
                        Amount = new AmountType { currencyID ="SAR",Value = 2},
                        TaxCategory = new TaxCategoryType [] {
                           new TaxCategoryType {
                              ID = new IdentifierType { schemeAgencyID= "6", schemeID ="UN/ECE 5305",Value="S" },
                              Percent =15,
                               TaxScheme = new TaxSchemeType
                               {
                                 ID = new IdentifierType {  schemeID = "UN/ECE 5153", schemeAgencyID = "6",Value = "VAT"}
                               }
                          }
                        }
                    },
                },
                TaxTotal = new TaxTotalType[]
                {
                  new TaxTotalType
                    {
                        TaxAmount = newAmountType(962.0M),
                        TaxSubtotal = new TaxSubtotalType[]
                        {
                            new TaxSubtotalType
                            {
                                TaxableAmount = newAmountType(3400.0M),
                                TaxAmount = newAmountType(850.0M),
                                TaxCategory = new TaxCategoryType
                                {
                                    ID = "S" ,
                                    Percent = 25.0M,
                                    TaxScheme = taxVAT
                                }
                            }
                        }
                    }
                 ,new TaxTotalType
                  {
                    TaxAmount = newAmountType(144.9M)
                  }
                },
                LegalMonetaryTotal = new MonetaryTotalType
                {
                    LineExtensionAmount = newAmountType(4200.0M),
                    TaxExclusiveAmount = newAmountType(4200.0M),
                    TaxInclusiveAmount = newAmountType(5162.0M),
                    AllowanceTotalAmount = newAmountType(5162.0M),
                    PrepaidAmount = newAmountType(5162.0M),
                    PayableAmount = newAmountType(5162.0M)
                },
                InvoiceLine = new InvoiceLineType[]
                {
                    new InvoiceLineType
                    {
                        ID = "1",
                        InvoicedQuantity = new  QuantityType { unitCode="NMP", Value=2 },
                        LineExtensionAmount = newAmountType(400.0M),
                        AccountingCost = "200500600",
                        OrderLineReference = new OrderLineReferenceType[]
                        {
                            new OrderLineReferenceType { LineID = "5" }
                        },
                        TaxTotal = new TaxTotalType[]
                        {
                            new TaxTotalType { TaxAmount = newAmountType(100.0M) }
                        },
                        Item = new ItemType
                        {
                            Name = "Testprodukt 1",
                            SellersItemIdentification = new ItemIdentificationType { ID = "12345670" },
                            ClassifiedTaxCategory = new TaxCategoryType[]
                            {
                                new TaxCategoryType
                                {
                                    ID = "S" ,
                                    Percent = 25.0M,
                                    TaxScheme = taxVAT
                                }
                            }
                        },
                        Price = new PriceType { PriceAmount = newAmountType(200.0M) }
                    }
                }
            };

            string filename = "SampleImplicitInvoice" + DateTime.Now.ToString("ddMMyyyy") + ".xml";
            UblDoc<InvoiceType>.Save(filename, doc);

            return doc;
        }
    }
}

