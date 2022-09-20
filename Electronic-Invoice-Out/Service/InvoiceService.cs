using Electronic_Invoice_Out.DTO;
using Electronic_Invoice_Out.Helper;
using Microsoft.AspNetCore.Hosting;
using SDKNETFrameWorkLib.BLL;
using System;
using System.IO;
using UblLarsen.Tools;
using UblLarsen.Ubl2;
using UblLarsen.Ubl2.Cac;
using UblLarsen.Ubl2.Udt;

namespace Electronic_Invoice_Out.Service
{
    public interface IInvoiceService
    {
        InvoiceResult GenerateXML(InvoiceModel obj);
    }
    public class InvoiceService : IInvoiceService
    {
        private IHostingEnvironment _env;
        public InvoiceService(IHostingEnvironment env)
        {
            _env = env;
        }
        public InvoiceResult GenerateXML(InvoiceModel obj)
        {
            var result = new InvoiceResult();
            Func<decimal, AmountType> newAmountType = v => new AmountType { Value = v, currencyID = "SAR" };
            var taxVAT = new TaxSchemeType { ID = "VAT" };
            InvoiceType doc = new InvoiceType 
            {
                UBLExtensions = new UblLarsen.Ubl2.Ext.UBLExtensionType[] { new UblLarsen.Ubl2.Ext.UBLExtensionType { } },
                ProfileID = "reporting:1.0",
                ID = "SME00062",
                UUID = "6f4d20e0-6bfe-4a80-9389-7dabe6620f12",
                IssueDate = new DateTime(2022, 03, 13),
                IssueTime = DateTime.Now,
                InvoiceTypeCode = new CodeType { name = "0211010", Value = "388" },
                DocumentCurrencyCode = "SAR",
                TaxCurrencyCode = "SAR",
                AdditionalDocumentReference = new DocumentReferenceType[] {
                    new DocumentReferenceType { ID = "ICV", UUID = "62" },
                    new DocumentReferenceType { ID = "PIH", Attachment = new AttachmentType { EmbeddedDocumentBinaryObject = new BinaryObjectType { mimeCode = "text/plain", Value = System.Convert.FromBase64String("NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ==") } } },
                },
                AccountingSupplierParty = new SupplierPartyType
                {
                    Party = new PartyType
                    {
                        PartyIdentification = new PartyIdentificationType[] { new PartyIdentificationType { ID = new IdentifierType { schemeID = "CRN", Value = "1010384104" } } },
                        PostalAddress = new AddressType
                        {
                            StreetName = "test",
                            BuildingNumber = "3454",
                            PlotIdentification = "1234",
                            CitySubdivisionName = "fgff",
                            CityName = "Riyadh",
                            PostalZone = "12345",
                            CountrySubentity = "test",
                            Country = new CountryType { IdentificationCode = "SA" },
                        },
                        PartyTaxScheme = new PartyTaxSchemeType[]
                        {
                            new PartyTaxSchemeType
                            {
                                CompanyID = "300094611410003",
                                TaxScheme = new TaxSchemeType
                                {
                                    ID = new IdentifierType
                                    {
                                        Value = "VAT"
                                    }
                                }
                            }
                        },
                        PartyLegalEntity = new PartyLegalEntityType[]
                        {
                            new PartyLegalEntityType { RegistrationName = "Ahmed Mohamed AL Ahmady" }
                        }
                    }
                },
                AccountingCustomerParty = new CustomerPartyType
                {
                    Party = new PartyType
                    {
                        PartyIdentification =  new PartyIdentificationType[] { new PartyIdentificationType { ID = new IdentifierType { schemeID="NAT" , Value= "2345" } } } ,
                        PostalAddress = new AddressType
                        {
                            StreetName = "baaoun",
                            AdditionalStreetName = "sdsd",
                            BuildingNumber = "3353",
                            PlotIdentification = "3434",
                            CitySubdivisionName = "fgff",
                            CityName = "Dhurma",
                            PostalZone = "34534",
                            CountrySubentity = "ulhk",
                            Country = new CountryType { IdentificationCode = "SA" }
                        },
                        PartyTaxScheme = new PartyTaxSchemeType[]
                        {
                            new PartyTaxSchemeType
                            {
                                TaxScheme = new TaxSchemeType
                                {
                                    ID = new IdentifierType { Value = "VAT" }
                                }
                            }
                        },
                        PartyLegalEntity = new PartyLegalEntityType[]
                        {
                            new PartyLegalEntityType { RegistrationName = "sdsa" }
                        }
                    }
                },
                Delivery = new DeliveryType[]
                {
                    new DeliveryType
                    {
                        ActualDeliveryDate = new DateTime(2022, 03, 13),
                        LatestDeliveryDate = new DateTime(2022, 03, 15),
                    }
                },
                PaymentMeans = new PaymentMeansType[]
                {
                    new PaymentMeansType
                    {
                        PaymentMeansCode = "10",
                    }
                },
                AllowanceCharge = new AllowanceChargeType[] {
                    new AllowanceChargeType {
                        ID = "1", ChargeIndicator = false,
                        AllowanceChargeReason = new TextType[] { "discount" },
                        Amount = new AmountType { currencyID = "SAR", Value = 2 },
                        TaxCategory = new TaxCategoryType[] {
                            new TaxCategoryType {
                                ID = new IdentifierType { schemeAgencyID = "6", schemeID = "UN/ECE 5305", Value = "S" },
                                Percent = 15,
                                TaxScheme = new TaxSchemeType
                                {
                                    ID = new IdentifierType { schemeID = "UN/ECE 5153", schemeAgencyID = "6", Value = "VAT" }
                                }
                            }
                        }
                    },
                },
                TaxTotal = new TaxTotalType[]
                {
                    new TaxTotalType
                    {
                        TaxAmount = new AmountType { currencyID = "SAR", Value = 144 },
                        TaxSubtotal = new TaxSubtotalType[]
                        {
                            new TaxSubtotalType
                            {
                                TaxableAmount = new AmountType { currencyID = "SAR", Value = 966 },
                                TaxAmount = new AmountType { currencyID = "SAR", Value = 144 },
                                TaxCategory = new TaxCategoryType
                                {
                                    ID = new IdentifierType { schemeAgencyID = "6", schemeID = "UN/ECE 5305", Value = "S" },
                                    Percent = 15,
                                    TaxScheme = new TaxSchemeType {
                                        ID = new IdentifierType { schemeAgencyID = "6", schemeID = "UN/ECE 5153", Value = "VAT" } }
                                }
                            }
                        }
                    }
                },
                LegalMonetaryTotal = new MonetaryTotalType
                {
                    LineExtensionAmount = new AmountType { currencyID = "SAR", Value = 966 },
                    TaxExclusiveAmount = new AmountType { currencyID = "SAR", Value = 964 },
                    TaxInclusiveAmount = new AmountType { currencyID = "SAR", Value = 1108 },
                    AllowanceTotalAmount = new AmountType { currencyID = "SAR", Value = 2 },
                    PrepaidAmount = new AmountType { currencyID = "SAR", Value = 0 },
                    PayableAmount = new AmountType { currencyID = "SAR", Value = 1108 },
                },
                InvoiceLine = new InvoiceLineType[]
                {
                    new InvoiceLineType
                    {
                        ID = "1",
                        InvoicedQuantity = new  QuantityType { unitCode="PCE", Value=44 },
                        LineExtensionAmount = new AmountType { currencyID = "SAR", Value = 966 },
                        TaxTotal = new TaxTotalType[]
                        {
                            new TaxTotalType { TaxAmount = new AmountType { currencyID = "SAR", Value = 144 },
                            RoundingAmount = new AmountType { currencyID = "SAR", Value = 144 }
                        }
                        },
                        Item = new ItemType
                        {
                            Name = "dsd",
                            SellersItemIdentification = new ItemIdentificationType { ID = "12345670" },
                            ClassifiedTaxCategory = new TaxCategoryType[]
                            {
                                new TaxCategoryType
                                {
                                 ID = "S" ,
                                 Percent = 25.0M,
                                 TaxScheme = new TaxSchemeType
                                 {
                                    ID = new IdentifierType {  Value = "VAT" }
                                 }
                               }
                            }
                        },
                        Price = new PriceType {
                            PriceAmount = new AmountType { currencyID = "SAR", Value = 144 },
                            AllowanceCharge = new AllowanceChargeType [] { new AllowanceChargeType{
                                ChargeIndicator = false,
                                AllowanceChargeReason = new TextType [] { new TextType { Value = "discount" } },
                                Amount =  new AmountType { currencyID = "SAR", Value = 2 }
                               }
                            }
                        }
                    }
                }
            };

            string filename = "SampleImplicitInvoice" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xml";
            UblDoc<InvoiceType>.Save(filename, doc);

            var webRoot = _env.WebRootPath;
            string currentDirectory = Directory.GetCurrentDirectory();

            string xmlFilePath = Path.Combine(currentDirectory, filename);
            string signxmlFilePath = Path.Combine(currentDirectory, "NewSigned.xml");

            var certificatePath = Path.Combine(webRoot, @"XMLFile\cer2023.pem");
            var certificateContent = File.ReadAllText(certificatePath);

            var privateKeyPath = Path.Combine(webRoot, @"XMLFile\privatekey2023.pem");
            var privateKeyContent = File.ReadAllText(privateKeyPath);

            var signFunction = new EInvoiceSigningLogic();
            var signxml = signFunction.SignDocument(xmlFilePath, certificateContent, privateKeyContent);

            var hashingFunction = new HashingValidator();
            var invoicehash = hashingFunction.GenerateEInvoiceHashing(signxmlFilePath);

            var qrFunction = new QRValidator();
            var invoiceQr = qrFunction.GenerateEInvoiceQRCode(signxmlFilePath);

            var xmlInvoice = ExtensionMethods.FormatXml(signxml.ResultedValue);

            result.invoice = ExtensionMethods.EncodeTo64(xmlInvoice);
            result.InvoiceHash = invoicehash.ResultedValue;
            result.QrCode = invoiceQr.ResultedValue;

            if (!string.IsNullOrEmpty(result.invoice) && !string.IsNullOrEmpty(result.InvoiceHash) && !string.IsNullOrEmpty(result.QrCode))
            {
                if (File.Exists(xmlFilePath))
                {
                    File.Delete(xmlFilePath);
                }
                if (File.Exists(signxmlFilePath))
                {
                    File.Delete(signxmlFilePath);
                }
            }
            return result;
        }
    }
}

//InvoiceType doc = new InvoiceType
//{
//    UBLExtensions = new UblLarsen.Ubl2.Ext.UBLExtensionType[]{
//                    new UblLarsen.Ubl2.Ext.UBLExtensionType{
//                        ExtensionAgencyURI = "urn:oasis:names:specification:ubl:dsig:enveloped:xades",
//                        //ExtensionContent = SignatureType{ }
//                      }
//                },
//    CustomizationID = "urn:oasis:names:specification:ubl:xpath:Invoice-2.0:sbs-1.0-draft",
//    ProfileID = obj.ProfileID,
//    ID = "SME00062",
//    UUID = "6f4d20e0-6bfe-4a80-9389-7dabe6620f12",
//    IssueDate = new DateTime(2022, 03, 13),
//    IssueTime = DateTime.Now,
//    InvoiceTypeCode = new CodeType { name = "0211010", Value = "388" },
//    DocumentCurrencyCode = "SAR",
//    TaxCurrencyCode = "SAR",
//    AdditionalDocumentReference = new DocumentReferenceType[] {
//                    new DocumentReferenceType { ID = "ICV",UUID = "62" },
//                    new DocumentReferenceType { ID = "PIH" , Attachment= new AttachmentType { EmbeddedDocumentBinaryObject = new BinaryObjectType{ mimeCode = "text/plain" , Value = System.Convert.FromBase64String("NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ==") } } },
//                    new DocumentReferenceType { ID = "QR" , Attachment= new AttachmentType { EmbeddedDocumentBinaryObject = new BinaryObjectType{ mimeCode = "text/plain" , Value = System.Convert.FromBase64String("ARdBaG1lZCBNb2hhbWVkIEFMIEFobWFkeQIPMzAxMTIxOTcxNTAwMDAzAxQyMDIyLTAzLTEzVDE0OjQwOjQwWgQHMTEwOC45MAUFMTQ0LjkGLFFuVkVleFc0bld2NENhRTM5YS82NkpwL09YTy9ldkhROHBEbEc3d2VxLzQ9B1gwVjAQBgcqhkjOPQIBBgUrgQQACgNCAARhgwyg5oVgCEw7+y16i19nJq+vqnXVJKXCwr1rOawtjtvVv4UuGowCuEHZ2ocpujGoo1++QoN4+GmqO6LmFyfRCCEAv8K/KgKZkw7MAqiu3yuqN12A/0a8bAs9CXWI8FollMoJIHVesAI1Q4ocf4i6DJAoXnj9kQ93F5ManRi6KnmapY1O") } } }
//                },
//    AccountingSupplierParty = new SupplierPartyType
//    {
//        Party = new PartyType
//        {
//            PartyName = new PartyNameType[] { new PartyNameType { Name = "Leverandør" } },
//            PostalAddress = new AddressType
//            {
//                Postbox = "Postboks 123",
//                StreetName = "Oslogate",
//                BuildingNumber = "1",
//                CityName = "Oslo",
//                PostalZone = "0612",
//                Country = new CountryType { IdentificationCode = "NO" },
//            },
//            PartyTaxScheme = new PartyTaxSchemeType[]
//                    {
//                            new PartyTaxSchemeType
//                            {
//                                CompanyID = "NO999999999MVA",
//                                TaxScheme = new TaxSchemeType
//                                {
//                                    ID = new IdentifierType
//                                    {
//                                        schemeID = "UN/ECE 5153",
//                                        schemeAgencyID = "6",
//                                        Value = "VAT"
//                                    }
//                                }
//                            }
//                    },
//            PartyLegalEntity = new PartyLegalEntityType[]
//                    {
//                            new PartyLegalEntityType { CompanyID = "999999999" }
//                    },
//            Contact = new ContactType { ID = "O Hansen" },
//        }
//    },
//    AccountingCustomerParty = new CustomerPartyType
//    {
//        Party = new PartyType
//        {
//            PartyIdentification = new[] { new PartyIdentificationType { ID = "456789" } },
//            PartyName = new[] { new PartyNameType { Name = "Kjøper" } },
//            PostalAddress = new AddressType
//            {
//                StreetName = "Testveien",
//                BuildingNumber = "1",
//                CityName = "Frogner",
//                PostalZone = "2012",
//                Country = new CountryType { IdentificationCode = "NO" }
//            },
//            PartyLegalEntity = new PartyLegalEntityType[]
//                    {
//                            new PartyLegalEntityType { CompanyID = "NO888888888MVA" }
//                    },
//            Contact = new ContactType { ID = "Arne Bjarne Baluba" }
//        }
//    },
//    Delivery = new DeliveryType[]
//            {
//                    new DeliveryType
//                    {
//                        ActualDeliveryDate =  new DateTime(2009,11,25),
//                        DeliveryLocation = new LocationType
//                        {
//                            Address = new AddressType
//                            {
//                                StreetName = "Testgata",
//                                BuildingNumber = "1",
//                                CityName = "Oslo",
//                                PostalZone = "0112",
//                                Country = new CountryType { IdentificationCode = "NO"}
//                            }
//                        }
//                    }
//            },
//    PaymentMeans = new PaymentMeansType[]
//            {
//                    new PaymentMeansType
//                    {
//                        PaymentMeansCode = "31",
//                        PaymentDueDate = new DateTime(2009, 11, 27),
//                        PaymentID = new UblLarsen.Ubl2.Udt.IdentifierType[] { "1234561" },
//                        PayeeFinancialAccount = new FinancialAccountType
//                        {
//                            ID = "NO9386011117947",
//                            FinancialInstitutionBranch = new BranchType
//                            {
//                                ID = new IdentifierType { schemeID="BIC", Value="DNBANOKK"},
//                            }
//                        }
//                    }
//            },
//    AllowanceCharge = new AllowanceChargeType[] {
//                    new AllowanceChargeType {
//                        ID = "1", ChargeIndicator = false,
//                        AllowanceChargeReason = new TextType[] {"discount" } ,
//                        Amount = new AmountType { currencyID ="SAR",Value = 2},
//                        TaxCategory = new TaxCategoryType [] {
//                           new TaxCategoryType {
//                              ID = new IdentifierType { schemeAgencyID= "6", schemeID ="UN/ECE 5305",Value="S" },
//                              Percent =15,
//                               TaxScheme = new TaxSchemeType
//                               {
//                                 ID = new IdentifierType {  schemeID = "UN/ECE 5153", schemeAgencyID = "6",Value = "VAT"}
//                               }
//                          }
//                        }
//                    },
//                },
//    TaxTotal = new TaxTotalType[]
//            {
//                  new TaxTotalType
//                    {
//                        TaxAmount = newAmountType(962.0M),
//                        TaxSubtotal = new TaxSubtotalType[]
//                        {
//                            new TaxSubtotalType
//                            {
//                                TaxableAmount = newAmountType(3400.0M),
//                                TaxAmount = newAmountType(850.0M),
//                                TaxCategory = new TaxCategoryType
//                                {
//                                    ID = "S" ,
//                                    Percent = 25.0M,
//                                    TaxScheme = taxVAT
//                                }
//                            }
//                        }
//                    }
//                 ,new TaxTotalType
//                  {
//                    TaxAmount = newAmountType(144.9M)
//                  }
//            },
//    LegalMonetaryTotal = new MonetaryTotalType
//    {
//        LineExtensionAmount = newAmountType(4200.0M),
//        TaxExclusiveAmount = newAmountType(4200.0M),
//        TaxInclusiveAmount = newAmountType(5162.0M),
//        AllowanceTotalAmount = newAmountType(5162.0M),
//        PrepaidAmount = newAmountType(5162.0M),
//        PayableAmount = newAmountType(5162.0M)
//    },
//    InvoiceLine = new InvoiceLineType[]
//            {
//                    new InvoiceLineType
//                    {
//                        ID = "1",
//                        InvoicedQuantity = new  QuantityType { unitCode="NMP", Value=2 },
//                        LineExtensionAmount = newAmountType(400.0M),
//                        AccountingCost = "200500600",
//                        OrderLineReference = new OrderLineReferenceType[]
//                        {
//                            new OrderLineReferenceType { LineID = "5" }
//                        },
//                        TaxTotal = new TaxTotalType[]
//                        {
//                            new TaxTotalType { TaxAmount = newAmountType(100.0M) }
//                        },
//                        Item = new ItemType
//                        {
//                            Name = "Testprodukt 1",
//                            SellersItemIdentification = new ItemIdentificationType { ID = "12345670" },
//                            ClassifiedTaxCategory = new TaxCategoryType[]
//                            {
//                                new TaxCategoryType
//                                {
//                                    ID = "S" ,
//                                    Percent = 25.0M,
//                                    TaxScheme = taxVAT
//                                }
//                            }
//                        },
//                        Price = new PriceType { PriceAmount = newAmountType(200.0M) }
//                    }
//            }
//};


