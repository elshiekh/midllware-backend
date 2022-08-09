// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//     https://github.com/Gammern/ubllarsen
//     
// </auto-generated>
//------------------------------------------------------------------------------
namespace UblLarsen.Ubl2
{
    using Cac;
    using Udt;
    
    
    /// <summary>
    /// ComponentType: ABIE
    /// <para>DictionaryEntryName: Fulfilment Cancellation. Details</para>
    /// <para>Definition: A document used to cancel an entire fulfilment document (Despatch Advice or Receipt Advice).</para>
    /// <para>ObjectClass: Fulfilment Cancellation</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("ublxsd", "2.1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("FulfilmentCancellation", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:FulfilmentCancellation-2")]
#if USE_UBL_XMLROOTATTRIBUTE
    [System.Xml.Serialization.XmlRootAttribute("FulfilmentCancellation", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:FulfilmentCancellation-2", IsNullable=false)]
#endif
    public partial class FulfilmentCancellationType : UblBaseDocumentType
    {
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Copy_ Indicator. Indicator</para>
        /// <para>Definition: Indicates whether this document is a copy (true) or not (false).</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Copy</para>
        /// <para>PropertyTerm: Indicator</para>
        /// <para>RepresentationTerm: Indicator</para>
        /// <para>DataType: Indicator. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IndicatorType CopyIndicator { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. UUID. Identifier</para>
        /// <para>Definition: A universally unique identifier for an instance of this document.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTerm: UUID</para>
        /// <para>RepresentationTerm: Identifier</para>
        /// <para>DataType: Identifier. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentifierType UUID { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Issue Date. Date</para>
        /// <para>Definition: The date, assigned by the sender, on which this document was issued.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTerm: Issue Date</para>
        /// <para>RepresentationTerm: Date</para>
        /// <para>DataType: Date. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DateType IssueDate { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Issue Time. Time</para>
        /// <para>Definition: The time, assigned by the sender, at which this document was issued.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTerm: Issue Time</para>
        /// <para>RepresentationTerm: Time</para>
        /// <para>DataType: Time. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TimeType IssueTime { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Note. Text</para>
        /// <para>Definition: Free-form text pertinent to this document, conveying information that is not contained explicitly in other structures.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTerm: Note</para>
        /// <para>RepresentationTerm: Text</para>
        /// <para>DataType: Text. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TextType[] Note { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Cancellation_ Note. Text</para>
        /// <para>Definition: The reason for cancellation of the referenced document.</para>
        /// <para>Cardinality: 1..n</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Cancellation</para>
        /// <para>PropertyTerm: Note</para>
        /// <para>RepresentationTerm: Text</para>
        /// <para>DataType: Text. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("CancellationNote", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TextType[] CancellationNote { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Despatch_ Document Reference. Document Reference</para>
        /// <para>Definition: A reference to a Despatch Advice associated with this document.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Despatch</para>
        /// <para>PropertyTerm: Document Reference</para>
        /// <para>AssociatedObjectClass: Document Reference</para>
        /// <para>RepresentationTerm: Document Reference</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("DespatchDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DocumentReferenceType[] DespatchDocumentReference { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Receipt_ Document Reference. Document Reference</para>
        /// <para>Definition: A reference to a Receipt Advice associated with this document.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Receipt</para>
        /// <para>PropertyTerm: Document Reference</para>
        /// <para>AssociatedObjectClass: Document Reference</para>
        /// <para>RepresentationTerm: Document Reference</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ReceiptDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DocumentReferenceType[] ReceiptDocumentReference { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Order Reference</para>
        /// <para>Definition: A reference to an Order document associated with the referenced Despatch or Receipt Advice(s).</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTerm: Order Reference</para>
        /// <para>AssociatedObjectClass: Order Reference</para>
        /// <para>RepresentationTerm: Order Reference</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("OrderReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public OrderReferenceType[] OrderReference { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Additional_ Document Reference. Document Reference</para>
        /// <para>Definition: A reference to an additional document associated with this document.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Additional</para>
        /// <para>PropertyTerm: Document Reference</para>
        /// <para>AssociatedObjectClass: Document Reference</para>
        /// <para>RepresentationTerm: Document Reference</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("AdditionalDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DocumentReferenceType[] AdditionalDocumentReference { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Contract</para>
        /// <para>Definition: The contracts or framework agreements with which the referenced fulfilment document is associated.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTerm: Contract</para>
        /// <para>AssociatedObjectClass: Contract</para>
        /// <para>RepresentationTerm: Contract</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Contract", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public ContractType[] Contract { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Signature</para>
        /// <para>Definition: A signature applied to this document.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTerm: Signature</para>
        /// <para>AssociatedObjectClass: Signature</para>
        /// <para>RepresentationTerm: Signature</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Signature", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public SignatureType[] Signature { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Buyer_ Customer Party. Customer Party</para>
        /// <para>Definition: The buyer.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Buyer</para>
        /// <para>PropertyTerm: Customer Party</para>
        /// <para>AssociatedObjectClass: Customer Party</para>
        /// <para>RepresentationTerm: Customer Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public CustomerPartyType BuyerCustomerParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Seller_ Supplier Party. Supplier Party</para>
        /// <para>Definition: The seller.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Seller</para>
        /// <para>PropertyTerm: Supplier Party</para>
        /// <para>AssociatedObjectClass: Supplier Party</para>
        /// <para>RepresentationTerm: Supplier Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public SupplierPartyType SellerSupplierParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Delivery_ Customer Party. Customer Party</para>
        /// <para>Definition: The delivery party.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Delivery</para>
        /// <para>PropertyTerm: Customer Party</para>
        /// <para>AssociatedObjectClass: Customer Party</para>
        /// <para>RepresentationTerm: Customer Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public CustomerPartyType DeliveryCustomerParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Despatch_ Supplier Party. Supplier Party</para>
        /// <para>Definition: The despatch party.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Despatch</para>
        /// <para>PropertyTerm: Supplier Party</para>
        /// <para>AssociatedObjectClass: Supplier Party</para>
        /// <para>RepresentationTerm: Supplier Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public SupplierPartyType DespatchSupplierParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Fulfilment Cancellation. Originator_ Customer Party. Customer Party</para>
        /// <para>Definition: The originator party</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Fulfilment Cancellation</para>
        /// <para>PropertyTermQualifier: Originator</para>
        /// <para>PropertyTerm: Customer Party</para>
        /// <para>AssociatedObjectClass: Customer Party</para>
        /// <para>RepresentationTerm: Customer Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public CustomerPartyType OriginatorCustomerParty { get; set; }
    }
}
