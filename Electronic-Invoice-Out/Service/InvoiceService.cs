using Electronic_Invoice_Out.DTO;
using Electronic_Invoice_Out.Helper;
using Microsoft.AspNetCore.Hosting;
using SDKNETFrameWorkLib.BLL;
using System;
using System.Collections.Generic;
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
            var invoiceLineList = new List<InvoiceLineType>();
            if (obj.InvoiceLine != null)
            {
                foreach (var invl in obj.InvoiceLine)
                {
                    invoiceLineList.Add(new InvoiceLineType
                    {
                        ID = invl.ID.ToString(), // "1",
                        InvoicedQuantity = new QuantityType { unitCode = "PCE", Value = invl.InvoicedQuantity },
                        LineExtensionAmount = new AmountType { currencyID = "SAR", Value = invl.LineExtensionAmount },
                        TaxTotal = new TaxTotalType[]
                            {
                            new TaxTotalType { TaxAmount = new AmountType { currencyID = "SAR", Value = invl.InvoiceLineTaxTotal.TaxAmount },
                            RoundingAmount = new AmountType { currencyID = "SAR", Value = invl.InvoiceLineTaxTotal.RoundingAmount }
                        }
                            },
                        Item = new ItemType
                        {
                            Name = invl.Item.Name,
                            SellersItemIdentification = new ItemIdentificationType { ID = invl.Item.SellersItemIdentification },
                            ClassifiedTaxCategory = new TaxCategoryType[]
                                {
                                new TaxCategoryType
                                {
                                 ID = invl.Item.ClassifiedTaxCategory.ID.ToString(),
                                 Percent = invl.Item.ClassifiedTaxCategory.Percent,
                                 TaxScheme = new TaxSchemeType
                                 {
                                    ID = new IdentifierType {  Value = invl.Item.ClassifiedTaxCategory.TaxSchemeID }
                                 }
                               }
                                }
                        },
                        Price = new PriceType
                        {
                            PriceAmount = new AmountType { currencyID = "SAR", Value = invl.Price.PriceAmount },
                            AllowanceCharge = new AllowanceChargeType[] { new AllowanceChargeType{
                                ChargeIndicator =invl.Price.AllowanceCharge.ChargeIndicator,
                                AllowanceChargeReason = new TextType [] { new TextType { Value = invl.Price.AllowanceCharge.AllowanceChargeReason } },
                                Amount =  new AmountType { currencyID = "SAR", Value = invl.Price.AllowanceCharge.Amount }
                               }
                            }
                        }
                    });
                }
            }
            var invoiceArray = invoiceLineList.ToArray();
            InvoiceType doc = new InvoiceType
            {
                UBLExtensions = new UblLarsen.Ubl2.Ext.UBLExtensionType[] { new UblLarsen.Ubl2.Ext.UBLExtensionType { } },
                ProfileID = obj.ProfileID, // "reporting:1.0",
                ID = obj.InvoiceID, // "SME00062",
                UUID = obj.UUID, // "6f4d20e0-6bfe-4a80-9389-7dabe6620f12",
                IssueDate = obj.IssueDate, // new DateTime(2022, 03, 13),
                IssueTime = obj.IssueTime, // DateTime.Now,
                InvoiceTypeCode = new CodeType { name = obj.InvoiceTypeCode.Name, Value = obj.InvoiceTypeCode.Value },
                // InvoiceTypeCode = new CodeType { name =  "0211010", Value = "388" },
                DocumentCurrencyCode = obj.DocumentCurrencyCode, //"SAR",
                TaxCurrencyCode = obj.TaxCurrencyCode, //"SAR",
                LineCountNumeric =obj.LineCountNumeric, // 2,
                AdditionalDocumentReference = new DocumentReferenceType[] {
                    new DocumentReferenceType { ID = "ICV", UUID = obj.ICVUUID }, // UUID = "62"
                    new DocumentReferenceType { ID = "PIH", Attachment = new AttachmentType { EmbeddedDocumentBinaryObject = new BinaryObjectType { mimeCode = "text/plain", Value = (String.IsNullOrEmpty(obj.PIHValue)) ? Convert.FromBase64String(obj.PIHValue):null } } },
                },
                AccountingSupplierParty = new SupplierPartyType
                {
                    Party = new PartyType
                    {
                        PartyIdentification = new PartyIdentificationType[] { new PartyIdentificationType { ID = new IdentifierType { schemeID = "CRN", Value = obj.AccountingSupplier.PartyIdentification.ToString() } } },
                        PostalAddress = new AddressType
                        {
                            StreetName = obj.AccountingSupplier.PostalAddress.StreetName.ToString(), // "test",
                            BuildingNumber = obj.AccountingSupplier.PostalAddress.BuildingNumber.ToString(), // "3454",
                            PlotIdentification = obj.AccountingSupplier.PostalAddress.PlotIdentification.ToString(), // "1234",
                            CitySubdivisionName = obj.AccountingSupplier.PostalAddress.CitySubdivisionName.ToString(), // "fgff",
                            CityName = obj.AccountingSupplier.PostalAddress.CityName.ToString(), // "Riyadh",
                            PostalZone = obj.AccountingSupplier.PostalAddress.PostalZone.ToString(), // "12345",
                            CountrySubentity = obj.AccountingSupplier.PostalAddress.CountrySubentity.ToString(), // "test",
                            Country = new CountryType { IdentificationCode = obj.AccountingSupplier.PostalAddress.CountryCode.ToString() }, // "SA"
                        },
                        PartyTaxScheme = new PartyTaxSchemeType[]
                        {
                            new PartyTaxSchemeType
                            {
                                CompanyID = obj.AccountingSupplier.PartyTaxScheme.CompanyID.ToString(), // "300094611410003",
                                TaxScheme = new TaxSchemeType
                                {
                                    ID = new IdentifierType
                                    {
                                        Value = obj.AccountingSupplier.PartyTaxScheme.TaxScheme.ToString(), // "VAT"
                                    }
                                }
                            }
                        },
                        PartyLegalEntity = new PartyLegalEntityType[]
                        {
                            new PartyLegalEntityType { RegistrationName = obj.AccountingSupplier.PartyLegalEntity.RegistrationName } // "Ahmed Mohamed AL Ahmady"
                        }
                    }
                },
                AccountingCustomerParty = new CustomerPartyType
                {
                    Party = new PartyType
                    {
                        PartyIdentification = new PartyIdentificationType[] { new PartyIdentificationType { ID = new IdentifierType { schemeID = "NAT", Value = obj.AccountingCustomer.PartyIdentification.ToString() } } }, // 2345
                        PostalAddress = new AddressType
                        {
                            StreetName = obj.AccountingCustomer.PostalAddress.StreetName, // "baaoun",
                            AdditionalStreetName = obj.AccountingCustomer.PostalAddress.StreetName, // "sdsd",
                            BuildingNumber = obj.AccountingCustomer.PostalAddress.BuildingNumber, // "3353",
                            PlotIdentification = obj.AccountingCustomer.PostalAddress.PlotIdentification, // "3434",
                            CitySubdivisionName = obj.AccountingCustomer.PostalAddress.CitySubdivisionName, // "fgff",
                            CityName = obj.AccountingCustomer.PostalAddress.CityName, // "Dhurma",
                            PostalZone = obj.AccountingCustomer.PostalAddress.PostalZone, // "34534",
                            CountrySubentity = obj.AccountingCustomer.PostalAddress.CountrySubentity, // "ulhk",
                            Country = new CountryType { IdentificationCode = obj.AccountingCustomer.PostalAddress.CountryCode } // "SA"
                        },
                        PartyTaxScheme = new PartyTaxSchemeType[]
                        {
                            new PartyTaxSchemeType
                            {
                                TaxScheme = new TaxSchemeType
                                {
                                    ID = new IdentifierType { Value = obj.AccountingCustomer.PartyTaxScheme.TaxScheme.ToString() } // "VAT"
                                }
                            }
                        },
                        PartyLegalEntity = new PartyLegalEntityType[]
                        {
                            new PartyLegalEntityType { RegistrationName = obj.AccountingCustomer.PartyLegalEntity.RegistrationName.ToString() } // sdsa
                        }
                    }
                },
                Delivery = new DeliveryType[]
                {
                    new DeliveryType
                    {
                        ActualDeliveryDate = obj.Delivery.ActualDeliveryDate,
                        LatestDeliveryDate = obj.Delivery.LatestDeliveryDate,
                    }
                },
                PaymentMeans = new PaymentMeansType[]
                {
                    new PaymentMeansType
                    {
                        PaymentMeansCode = obj.PaymentMeans.Code // 10 
                    }
                },
                AllowanceCharge = new AllowanceChargeType[] {
                    new AllowanceChargeType {
                        ID =  obj.AllowanceCharge.ID,  //  "1", 
                        ChargeIndicator = obj.AllowanceCharge.ChargeIndicator,
                        AllowanceChargeReason = new TextType[] { obj.AllowanceCharge.AllowanceChargeReason.ToString() }, // discount
                        Amount = new AmountType { currencyID = "SAR", Value = obj.AllowanceCharge.Amount },
                        TaxCategory = new TaxCategoryType[] {
                            new TaxCategoryType {
                                ID = new IdentifierType { schemeAgencyID = "6", schemeID = "UN/ECE 5305", Value = obj.AllowanceCharge.TaxCategoryID }, // Value = "S"
                                Percent =  obj.AllowanceCharge.TaxCategoryPercent , // 15,
                                TaxScheme = new TaxSchemeType
                                {
                                    ID = new IdentifierType { schemeID = "UN/ECE 5153", schemeAgencyID = "6", Value = obj.AllowanceCharge.TaxCategoryTaxSchemeID } // Value = "VAT"
                                }
                            }
                        }
                    },
                },
                TaxTotal = new TaxTotalType[]
                {
                    new TaxTotalType
                    {
                        TaxAmount = new AmountType { currencyID = "SAR", Value = obj.TaxTotal.TaxAmount },
                        TaxSubtotal = new TaxSubtotalType[]
                        {
                            new TaxSubtotalType
                            {
                                TaxableAmount = new AmountType { currencyID = "SAR", Value =  obj.TaxTotal.TaxSubtotal.TaxableAmount },
                                TaxAmount = new AmountType { currencyID = "SAR", Value = obj.TaxTotal.TaxSubtotal.TaxAmount },
                                TaxCategory = new TaxCategoryType
                                {
                                    ID = new IdentifierType { schemeAgencyID = "6", schemeID = "UN/ECE 5305", Value = obj.TaxTotal.TaxSubtotal.TaxCategory.ID.ToString() },
                                    Percent = obj.TaxTotal.TaxSubtotal.TaxCategory.Percent,
                                    TaxScheme = new TaxSchemeType {
                                        ID = new IdentifierType { schemeAgencyID = "6", schemeID = "UN/ECE 5153", Value = obj.TaxTotal.TaxSubtotal.TaxCategory.TaxSchemeID } }
                                }
                            }
                        }
                    },
                    new TaxTotalType
                    {
                        TaxAmount = new AmountType { currencyID = "SAR", Value = obj.TaxTotals.TaxAmount },
                    },
                },
                LegalMonetaryTotal = new MonetaryTotalType
                {
                    LineExtensionAmount = new AmountType { currencyID = "SAR", Value = obj.LegalMonetaryTotal.LineExtensionAmount },
                    TaxExclusiveAmount = new AmountType { currencyID = "SAR", Value = obj.LegalMonetaryTotal.TaxExclusiveAmount },
                    TaxInclusiveAmount = new AmountType { currencyID = "SAR", Value = obj.LegalMonetaryTotal.TaxInclusiveAmount },
                    AllowanceTotalAmount = new AmountType { currencyID = "SAR", Value = obj.LegalMonetaryTotal.AllowanceTotalAmount },
                    PrepaidAmount = new AmountType { currencyID = "SAR", Value = obj.LegalMonetaryTotal.PrepaidAmount },
                    PayableAmount = new AmountType { currencyID = "SAR", Value = obj.LegalMonetaryTotal.PayableAmount },
                },
                InvoiceLine = invoiceArray
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
                result.Status = "SUCCESS";
                result.Message = "Invoice Generated Successfully";
            }
            else
            {
                result.Message = "Invoice not Generated Successfully";
                result.Status = "ERROR";
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


