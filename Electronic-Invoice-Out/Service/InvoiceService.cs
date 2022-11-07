using Electronic_Invoice_Out.DTO;
using Electronic_Invoice_Out.Extenstion;
using Electronic_Invoice_Out.Helper;
using Microsoft.AspNetCore.Hosting;
using net.sf.saxon.expr;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Macs;
using SDKNETFrameWorkLib.BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using UblLarsen.Tools;
using UblLarsen.Ubl2;
using UblLarsen.Ubl2.Cac;
using UblLarsen.Ubl2.Udt;

namespace Electronic_Invoice_Out.Service
{
    public interface IInvoiceService
    {
        InvoiceResult GenerateXML(InvoiceModel obj);
        //InvoiceResult GenerateStandardXML(InvoiceStandardModel obj);
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

            var cc = Convert.ToDecimal(obj.AllowanceCharge.Amount);
            var result = new InvoiceResult();
            var invoiceLineList = new List<InvoiceLineType>();
            if (obj.InvoiceLine != null)
            {
                foreach (var invl in obj.InvoiceLine)
                {
                    invoiceLineList.Add(new InvoiceLineType
                    {
                        ID = invl.ID.ToString(), // "1",
                        InvoicedQuantity = new QuantityType { unitCode = "PCE", Value = Convert.ToDecimal(invl.InvoicedQuantity) },
                        LineExtensionAmount = new AmountType { currencyID = "SAR", Value = Convert.ToDecimal(invl.LineExtensionAmount) },
                        TaxTotal = new TaxTotalType[]
                            {
                            new TaxTotalType { TaxAmount = new AmountType { currencyID = "SAR", Value = Convert.ToDecimal(invl.InvoiceLineTaxTotal.TaxAmount) },
                            RoundingAmount = new AmountType { currencyID = "SAR", Value = Convert.ToDecimal(invl.InvoiceLineTaxTotal.RoundingAmount) }
                        }
                            },
                        Item = new ItemType
                        {
                            Name = invl.Item.Name,
                            // SellersItemIdentification = new ItemIdentificationType { ID = invl.Item.SellersItemIdentification },
                            ClassifiedTaxCategory = new TaxCategoryType[]
                                {
                                new TaxCategoryType
                                {
                                 ID = invl.Item.ClassifiedTaxCategory.ID.ToString(),
                                 Percent = Convert.ToDecimal(invl.Item.ClassifiedTaxCategory.Percent),
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
                                Amount =  new AmountType { currencyID = "SAR", Value = Convert.ToDecimal(invl.Price.AllowanceCharge.Amount) }
                               }
                            }
                        }
                    });
                }
            }
            var invoiceArray = invoiceLineList.ToArray();
            var billingrefrence = "Invoice Number: "+ obj.InvoiceID + " Invoice Issue Date: " + obj.IssueDate;
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

                // LineCountNumeric = obj.LineCountNumeric, // 2,
                AdditionalDocumentReference = new DocumentReferenceType[] {
                    new DocumentReferenceType { ID = "ICV", UUID = obj.ICVUUID }, // UUID = "62"
                    new DocumentReferenceType { ID = "PIH", Attachment = new AttachmentType { EmbeddedDocumentBinaryObject = new BinaryObjectType { mimeCode = "text/plain", Value = (!String.IsNullOrEmpty(obj.PIHValue)) ? Convert.FromBase64String(obj.PIHValue) : null } } },
                },
                AccountingSupplierParty = new SupplierPartyType
                {
                    Party = new PartyType
                    {
                        PartyIdentification = new PartyIdentificationType[] { new PartyIdentificationType { ID = new IdentifierType { schemeID = "CRN", Value = obj.AccountingSupplier.PartyIdentification } } },
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
                        PartyIdentification = new PartyIdentificationType[] { new PartyIdentificationType { ID = new IdentifierType { schemeID = "NAT", Value = obj.AccountingCustomer.PartyIdentification } } }, // 2345
                        PostalAddress = new AddressType
                        {
                            StreetName = obj.AccountingCustomer.PostalAddress.StreetName, // "baaoun",
                            AdditionalStreetName = obj.AccountingCustomer.PostalAddress.AdditionalStreetName, // "sdsd",
                            BuildingNumber = obj.AccountingCustomer.PostalAddress.BuildingNumber, // "3353",
                            PlotIdentification = obj.AccountingCustomer.PostalAddress.PlotIdentification, // "3434",
                            CitySubdivisionName = obj.AccountingCustomer.PostalAddress.CitySubdivisionName, // "fgff",
                            CityName = obj.AccountingCustomer.PostalAddress.CityName, // "Dhurma",
                            PostalZone = obj.AccountingCustomer.PostalAddress.PostalZone, // "34534",
                            CountrySubentity = obj.AccountingCustomer.PostalAddress.CountrySubentity, // "ulhk",
                            Country = new CountryType { IdentificationCode = obj.AccountingCustomer.PostalAddress.CountryCode }, // "SA"
                        },
                        PartyTaxScheme = new PartyTaxSchemeType[]
                        {
                            new PartyTaxSchemeType
                            {
                                TaxScheme = new TaxSchemeType
                                {
                                    ID = new IdentifierType { Value = (!string.IsNullOrEmpty(obj.AccountingCustomer.PartyTaxScheme.TaxScheme) ? obj.AccountingCustomer.PartyTaxScheme.TaxScheme : null) } // "VAT"
                                }
                            }
                        },
                        PartyLegalEntity = new PartyLegalEntityType[]
                        {
                            new PartyLegalEntityType { RegistrationName = (!string.IsNullOrEmpty(obj.AccountingCustomer.PartyLegalEntity.RegistrationName) ? obj.AccountingCustomer.PartyLegalEntity.RegistrationName : null) } // sdsa
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
                        PaymentMeansCode = obj.PaymentMeans.Code, // 10 
                        InstructionNote = new TextType[]  { new TextType { Value = obj.PaymentMeans.InstructionNote } }
                    }                    
                },
                AllowanceCharge = new AllowanceChargeType[] {
                    new AllowanceChargeType {
                        ID =  obj.AllowanceCharge.ID,  //  "1", 
                        ChargeIndicator = obj.AllowanceCharge.ChargeIndicator,
                        AllowanceChargeReason = new TextType[] { obj.AllowanceCharge.AllowanceChargeReason.ToString() }, // discount
                        Amount = new AmountType { currencyID = "SAR", Value = Convert.ToDecimal(obj.AllowanceCharge.Amount) },
                        TaxCategory = new TaxCategoryType[] {
                            new TaxCategoryType {
                                ID = new IdentifierType { schemeID = "UN/ECE 5305", schemeAgencyID = "6", Value = obj.AllowanceCharge.TaxCategoryID }, // Value = "S"
                                Percent =  Convert.ToDecimal(obj.AllowanceCharge.TaxCategoryPercent) , // 15,
                                TaxScheme = new TaxSchemeType
                                {
                                    ID = new IdentifierType {  schemeAgencyID = "6", schemeID = "UN/ECE 5153", Value = obj.AllowanceCharge.TaxCategoryTaxSchemeID } // Value = "VAT"
                                }
                            }
                        }
                    },
                },
                TaxTotal = new TaxTotalType[]
                {
                    new TaxTotalType
                    {
                        TaxAmount = new AmountType { currencyID = "SAR", Value = Convert.ToDecimal(obj.TaxTotal.TaxAmount) },
                        TaxSubtotal = new TaxSubtotalType[]
                        {
                            new TaxSubtotalType
                            {
                                TaxableAmount = new AmountType { currencyID = "SAR", Value = Convert.ToDecimal( obj.TaxTotal.TaxSubtotal.TaxableAmount) },
                                TaxAmount = new AmountType { currencyID = "SAR", Value = Convert.ToDecimal(obj.TaxTotal.TaxSubtotal.TaxAmount) },
                                TaxCategory = new TaxCategoryType
                                {
                                    ID = new IdentifierType {  schemeID = "UN/ECE 5305", schemeAgencyID = "6", Value = obj.TaxTotal.TaxSubtotal.TaxCategory.ID.ToString() },
                                    Percent =Convert.ToDecimal( obj.TaxTotal.TaxSubtotal.TaxCategory.Percent),
                                   // TaxExemptionReasonCode = (obj.InvoiceTypeCode.Value == "381" ||obj.InvoiceTypeCode.Value == "383") ? obj.TaxTotal.TaxSubtotal.TaxCategory.TaxExemptionReasonCode : null,
                                   // TaxExemptionReason = new TextType[] { new TextType {Value = (obj.InvoiceTypeCode.Value == "381" || obj.InvoiceTypeCode.Value == "383") ? obj.TaxTotal.TaxSubtotal.TaxCategory.TaxExemptionReason : null } } ,
                                    TaxScheme = new TaxSchemeType {
                                    ID = new IdentifierType { schemeID = "UN/ECE 5153" , schemeAgencyID = "6", Value = obj.TaxTotal.TaxSubtotal.TaxCategory.TaxSchemeID } }
                                }
                            }
                        }
                    },
                    new TaxTotalType
                    {
                        TaxAmount = new AmountType { currencyID = "SAR", Value = Convert.ToDecimal(obj.TaxTotals.TaxAmount) },
                    }
                },
                LegalMonetaryTotal = new MonetaryTotalType
                {
                    LineExtensionAmount = new AmountType { currencyID = "SAR", Value = Math.Round(Convert.ToDecimal(obj.LegalMonetaryTotal.LineExtensionAmount), 2) },
                    TaxExclusiveAmount = new AmountType { currencyID = "SAR", Value = Math.Round(Convert.ToDecimal(obj.LegalMonetaryTotal.TaxExclusiveAmount), 2) },
                    TaxInclusiveAmount = new AmountType { currencyID = "SAR", Value = Math.Round(Convert.ToDecimal(obj.LegalMonetaryTotal.TaxInclusiveAmount), 2) },
                    AllowanceTotalAmount = new AmountType { currencyID = "SAR", Value = Math.Round(Convert.ToDecimal(obj.LegalMonetaryTotal.AllowanceTotalAmount), 2) },
                    PrepaidAmount = new AmountType { currencyID = "SAR", Value = Math.Round(Convert.ToDecimal(obj.LegalMonetaryTotal.PrepaidAmount), 2) },
                    PayableAmount = new AmountType { currencyID = "SAR", Value = Math.Round(Convert.ToDecimal(obj.LegalMonetaryTotal.PayableAmount), 2) },
                },
                InvoiceLine = invoiceArray
            };
            if (doc.InvoiceTypeCode == "381" || doc.InvoiceTypeCode == "383")
            {
                doc.BillingReference = new BillingReferenceType[]
                {
                   new BillingReferenceType{ InvoiceDocumentReference = new DocumentReferenceType { ID = billingrefrence } }
                };
             }
            string path = @"C:\companies\hmg\zatca-einvoicing-sdk-230-R3.1.6\Apps\";
            string filename = "Invoice-"+ doc.InvoiceTypeCode.name +"-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xml";
            var generatedXml  = path + filename;
            UblDoc<InvoiceType>.Save(generatedXml, doc);
            var proc1 = new ProcessStartInfo();
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = path;
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + "fatoora -sign -invoice " +filename+"  "+ "-signedInvoice" + "   sign-" + filename;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(proc1);
            //Set a time-out value.
            //Wait for the process to exit or time out.
            p.WaitForExit(90000);
            //Check to see if the process is still running.
            if (p.HasExited == false)
                //Process is still running.
                //Test to see if the process is hung up.
                if (p.Responding)
                    //Process was responding; close the main window.
                    p.CloseMainWindow();
                else
                    //Process was not responding; force the process to close.
                    p.Kill();

            var pathSignInvoice = path + "sign-" + filename;
            var signInvoice = File.ReadAllText(pathSignInvoice);

            //var webRoot = _env.WebRootPath;
            //string currentDirectory = Directory.GetCurrentDirectory();

            //string xmlFilePath = Path.Combine(currentDirectory, filename);
            //string signxmlFilePath = Path.Combine(currentDirectory, "NewSigned.xml");

            //var certificatePath = Path.Combine(webRoot, @"XMLFile\cer-cs.pem");
            //var certificateContent = File.ReadAllText(certificatePath);

            //var pIHPath = Path.Combine(webRoot, @"XMLFile\pih.txt");
            //var pIHContent = File.ReadAllText(pIHPath);

            //var privateKeyPath = Path.Combine(webRoot, @"XMLFile\privatekey-cs.pem");
            //var privateKeyContent = File.ReadAllText(privateKeyPath);


            // ----------------------
            //var signFunction = new EInvoiceSigningLogic();
            //var signxml = signFunction.SignDocument(xmlFilePath, certificateContent, privateKeyContent);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(pathSignInvoice);

            //-------------------------------------
            var invoicehash= GetNodeInnerText(xmlDocument, Params.Hash_XPATH);
            var invoiceQr= GetNodeInnerText(xmlDocument, Params.QR_CODE_XPATH);
            //var hashingFunction = new HashingValidator();
            //var invoicehash = hashingFunction.GenerateEInvoiceHashing(signxmlFilePath).ResultedValue;
            //var qrFunction = new QRValidator();
            //var invoiceQr = qrFunction.GenerateEInvoiceQRCode(signxmlFilePath).ResultedValue;
            //----------------------------------------

            //var hashingFunction = new HashingValidator();
            //var invoicehash = hashingFunction.GenerateEInvoiceHashing(signxmlFilePath).ResultedValue;
            //SetNodeValue(xmlDocument, Params.Hash_XPATH, invoicehash);
            //SetNodeValue(xmlDocument, Params.QR_CODE_XPATH, invoiceQr);
            //------------------------------------------------

            //var invoiceValidator = new EInvoiceValidator();
            //var isvalid = invoiceValidator.ValidateEInvoice(signxmlFilePath, certificateContent, pIHContent);

          //  var xmlInvoice = ExtensionMethods.FormatXml(signxml.ResultedValue);

            result.Invoice = ExtensionMethods.EncodeTo64(signInvoice);
            result.InvoiceHash = invoicehash;
            result.UUID = obj.UUID;
            result.QrCode = invoiceQr;

            if (!string.IsNullOrEmpty(result.Invoice) && !string.IsNullOrEmpty(result.InvoiceHash) && !string.IsNullOrEmpty(result.QrCode))
            {
                if (File.Exists(generatedXml))
                {
                    File.Delete(generatedXml);
                }
                if (File.Exists(pathSignInvoice))
                {
                    File.Delete(pathSignInvoice);
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

        public static string GetNodeInnerText(XmlDocument doc, string xPath)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(doc.NameTable);
            xmlNamespaceManager.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xmlNamespaceManager.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xmlNamespaceManager.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            XmlNode xmlNode = doc.SelectSingleNode(xPath, xmlNamespaceManager);
            if (xmlNode != null)
            {
                return xmlNode.InnerText;
            }

            return "";
        }
        public static void SetNodeValue(XmlDocument doc, string xPath, string value)
        {
            XmlNode xmlNode = doc.SelectSingleNode(xPath);
            if (xmlNode != null)
            {
                xmlNode.InnerText = value;
            }
        }

    }
}




