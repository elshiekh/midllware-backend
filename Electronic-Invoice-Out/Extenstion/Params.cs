using java.util;
using jdk.@internal.org.objectweb.asm.tree.analysis;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Electronic_Invoice_Out.Extenstion
{
    internal class Params
    {
        public static string SELLER_NAME_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PartyLegalEntity']//*[local-name() = 'RegistrationName']";

        public static string VAT_REGISTERATION_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'AccountingSupplierParty']/*[local-name() = 'Party']/*[local-name() = 'PartyTaxScheme']/*[local-name() = 'CompanyID']";

        public static string ISSUE_DATE_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'IssueDate']";

        public static string ISSUE_TIME_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'IssueTime']";

        public static string INVOICE_TOTAL_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'LegalMonetaryTotal']/*[local-name() = 'TaxInclusiveAmount']";

        public static string VAT_TOTAL_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'TaxTotal']/*[local-name() = 'TaxAmount']";

        public static string SIGNATURE_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'UBLExtensions']/*[local-name() = 'UBLExtension']/*[local-name() = 'ExtensionContent']/*[local-name() = 'UBLDocumentSignatures']/*[local-name() = 'SignatureInformation']/*[local-name() = 'Signature']/*[local-name() = 'SignatureValue']";

        public static string CERTIFICATE_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'UBLExtensions']/*[local-name() = 'UBLExtension']/*[local-name() = 'ExtensionContent']/*[local-name() = 'UBLDocumentSignatures']/*[local-name() = 'SignatureInformation']/*[local-name() = 'Signature']/*[local-name() = 'KeyInfo']/*[local-name() = 'X509Data']/*[local-name() = 'X509Certificate']";

        public static string QR_CODE_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'AdditionalDocumentReference' and *[local-name()='ID' and .='QR']]/*[local-name() = 'Attachment']/*[local-name() = 'EmbeddedDocumentBinaryObject']";

        public static string Hash_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'UBLExtensions']/*[local-name() = 'UBLExtension']/*[local-name() = 'ExtensionContent']/*[local-name() = 'UBLDocumentSignatures']/*[local-name() = 'SignatureInformation']/*[local-name() = 'Signature']/*[local-name() = 'SignedInfo']/*[local-name() = 'Reference' and @Id='invoiceSignedData']/*[local-name() = 'DigestValue']";

        public static string Invoice_Type_XPATH = "//*[local-name()='Invoice']//*[local-name()='InvoiceTypeCode']";

        public static string PIH_XPATH = "/*[local-name() = 'Invoice']/*[local-name() = 'AdditionalDocumentReference' and *[local-name()='ID' and .='PIH']]/*[local-name() = 'Attachment']/*[local-name() = 'EmbeddedDocumentBinaryObject']";

        public static string SIGNED_PROPERTIES_XPATH = "//*[local-name()='Invoice']//*[local-name()='UBLExtensions']//*[local-name()='ExtensionContent']//*[local-name()='UBLDocumentSignatures']//*[local-name()='SignatureInformation']//*[local-name()='Signature']//*[local-name()='QualifyingProperties']//*[local-name()='SignedProperties']";

        public static string SIGNED_Properities_DIGEST_VALUE_XPATH = "//*[local-name()='Invoice']//*[local-name()='UBLExtensions']//*[local-name()='ExtensionContent']//*[local-name()='UBLDocumentSignatures']//*[local-name()='SignatureInformation']//*[local-name()='Signature']//*[local-name()='SignedInfo']//*[local-name()='Reference'][2]//*[local-name()='DigestValue']";

        public static string SIGNED_Certificate_DIGEST_VALUE_XPATH = "//*[local-name()='Invoice']//*[local-name()='UBLExtensions']//*[local-name()='UBLExtension']//*[local-name()='ExtensionContent']//*[local-name()='UBLDocumentSignatures']//*[local-name()='SignatureInformation']//*[local-name()='Signature']//*[local-name()='Object']//*[local-name()='QualifyingProperties']//*[local-name()='SignedProperties']//*[local-name()='SignedSignatureProperties']//*[local-name()='SigningCertificate']//*[local-name()='Cert']//*[local-name()='CertDigest']//*[local-name()='DigestValue']";

        public static string X509_SERIAL_NUMBER_XPATH = "//*[local-name()='Invoice']//*[local-name()='UBLExtensions']//*[local-name()='UBLExtension']//*[local-name()='ExtensionContent']//*[local-name()='UBLDocumentSignatures']//*[local-name()='SignatureInformation']//*[local-name()='Signature']//*[local-name()='Object']//*[local-name()='QualifyingProperties']//*[local-name()='SignedProperties']//*[local-name()='SignedSignatureProperties']//*[local-name()='SigningCertificate']//*[local-name()='Cert']//*[local-name()='IssuerSerial']//*[local-name()='X509SerialNumber']";

        public static string ISSUER_NAME_XPATH = "//*[local-name()='Invoice']//*[local-name()='UBLExtensions']//*[local-name()='UBLExtension']//*[local-name()='ExtensionContent']//*[local-name()='UBLDocumentSignatures']//*[local-name()='SignatureInformation']//*[local-name()='Signature']//*[local-name()='Object']//*[local-name()='QualifyingProperties']//*[local-name()='SignedProperties']//*[local-name()='SignedSignatureProperties']//*[local-name()='SigningCertificate']//*[local-name()='Cert']//*[local-name()='IssuerSerial']//*[local-name()='X509IssuerName']";

        public static string PUBLIC_KEY_HASHING_XPATH = "//*[local-name()='Invoice']//*[local-name()='UBLExtensions']//*[local-name()='ExtensionContent']//*[local-name()='UBLDocumentSignatures']//*[local-name()='SignatureInformation']//*[local-name()='Signature']//*[local-name()='QualifyingProperties']//*[local-name()='SignedProperties']//*[local-name()='SignedSignatureProperties']//*[local-name()='SigningCertificate']//*[local-name()='Cert']//*[local-name()='CertDigest']//*[local-name()='DigestValue']";

        public static string SIGNING_TIME_XPATH = "//*[local-name()='Invoice']//*[local-name()='UBLExtensions']//*[local-name()='ExtensionContent']//*[local-name()='UBLDocumentSignatures']//*[local-name()='SignatureInformation']//*[local-name()='Signature']//*[local-name()='QualifyingProperties']//*[local-name()='SignedProperties']//*[local-name()='SignedSignatureProperties']//*[local-name()='SigningTime']";

        public static string[] allDatesFormats = new string[19]
        {
            "yyyy-MM-dd", "yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy",
            "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy"
        };

        public static string Embeded_InvoiceXSLFileForFormatting = "SDKNETFrameWorkLib.Data.format.xsl";

        public static string Embeded_InvoiceXSLFileForHashing = "SDKNETFrameWorkLib.Data.invoice.xsl";

        public static string Embeded_EN_Schematrons_PATH = "SDKNETFrameWorkLib.Data.CEN-EN16931-UBL.xsl";

        public static string Embeded_KSA_Schematrons_PATH = "SDKNETFrameWorkLib.Data.ZATCA_Validation_Rules.xsl";

        public static string Embeded_Remove_Elements_PATH = "SDKNETFrameWorkLib.Data.removeElements.xsl";

        public static string Embeded_Add_QR_Element_PATH = "SDKNETFrameWorkLib.Data.addQRElement.xsl";

        public static string Embeded_Add_Signature_Element_PATH = "SDKNETFrameWorkLib.Data.addSignatureElement.xsl";

        public static string Embeded_Add_UBL_Element_PATH = "SDKNETFrameWorkLib.Data.addUBLElement.xsl";

        public static string Embeded_QR_XML_File_PATH = "SDKNETFrameWorkLib.Data.qr.xml";

        public static string Embeded_Signature_File_PATH = "SDKNETFrameWorkLib.Data.signature.xml";

        public static string Embeded_UBL_File_PATH = "SDKNETFrameWorkLib.Data.ubl.xml";

        public static string Embeded_License_Config_File_PATH = "SDKNETFrameWorkLib.Data.config.xsd";

        public static string Embeded_UBL_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.maindoc.UBL-Invoice-2.1.xsd";

        public static string Embeded_CommonAggregateComponents_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-CommonAggregateComponents-2.1.xsd";

        public static string Embeded_CommonBasicComponents_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-CommonBasicComponents-2.1.xsd";

        public static string Embeded_CommonExtensionComponents_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-CommonExtensionComponents-2.1.xsd";

        public static string Embeded_CommonSignatureComponents_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-CommonSignatureComponents-2.1.xsd";

        public static string Embeded_SignatureAggregateComponents_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-SignatureAggregateComponents-2.1.xsd";

        public static string Embeded_SignatureBasicComponents_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-SignatureBasicComponents-2.1.xsd";

        public static string Embeded_UBL_UnqualifiedDataTypes_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-UnqualifiedDataTypes-2.1.xsd";

        public static string Embeded_CoreComponentTypeSchemaModule_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-CoreComponentParameters-2.1.xsd";

        public static string Embeded_ExtensionContentDataType_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-ExtensionContentDataType-2.1.xsd";

        public static string Embeded_QualifiedDataTypes_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-QualifiedDataTypes-2.1.xsd";

        public static string Embeded_CCTS_CCT_SchemaModule_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.CCTS_CCT_SchemaModule-2.1.xsd";

        public static string Embeded_UBL_XAdESv_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-XAdESv141-2.1.xsd";

        public static string Embeded_UBL_Xmldsig_Core_XSD_PATH = "SDKNETFrameWorkLib.Data.xsd.common.UBL-xmldsig-core-schema-2.1.xsd";
    }

    public enum Company
    {
        [field: Description("HMG")]
        HMG=1,
        [field: Description("CS")]
        CS=2,
        [field: Description("FM")]
        FM=3,
        [field: Description("TASW")]
        TASW=4
    }
}
