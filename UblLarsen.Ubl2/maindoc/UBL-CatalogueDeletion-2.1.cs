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
    /// <para>DictionaryEntryName: Catalogue Deletion. Details</para>
    /// <para>Definition: A document used to cancel an entire Catalogue.</para>
    /// <para>ObjectClass: Catalogue Deletion</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("ublxsd", "2.1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("CatalogueDeletion", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CatalogueDeletion-2")]
#if USE_UBL_XMLROOTATTRIBUTE
    [System.Xml.Serialization.XmlRootAttribute("CatalogueDeletion", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CatalogueDeletion-2", IsNullable=false)]
#endif
    public partial class CatalogueDeletionType : UblBaseDocumentType
    {
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. UUID. Identifier</para>
        /// <para>Definition: A universally unique identifier for an instance of this document.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: UUID</para>
        /// <para>RepresentationTerm: Identifier</para>
        /// <para>DataType: Identifier. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentifierType UUID { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Name</para>
        /// <para>Definition: Text, assigned by the sender, that identifies this document to business users.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: Name</para>
        /// <para>RepresentationTerm: Name</para>
        /// <para>DataType: Name. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public NameType Name { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Issue Date. Date</para>
        /// <para>Definition: The date, assigned by the sender, on which this document was issued.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: Issue Date</para>
        /// <para>RepresentationTerm: Date</para>
        /// <para>DataType: Date. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DateType IssueDate { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Issue Time. Time</para>
        /// <para>Definition: The time, assigned by the sender, at which this document was issued.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: Issue Time</para>
        /// <para>RepresentationTerm: Time</para>
        /// <para>DataType: Time. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TimeType IssueTime { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Effective Date. Date</para>
        /// <para>Definition: The effective date, assigned by the seller, on which the Catalogue expires.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: Effective Date</para>
        /// <para>RepresentationTerm: Date</para>
        /// <para>DataType: Date. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DateType EffectiveDate { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Effective Time. Time</para>
        /// <para>Definition: The effective time, assigned by the seller, at which the Catalogue expires.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: Effective Time</para>
        /// <para>RepresentationTerm: Time</para>
        /// <para>DataType: Time. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TimeType EffectiveTime { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Note. Text</para>
        /// <para>Definition: Free-form text pertinent to this document, conveying information that is not contained explicitly in other structures.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: Note</para>
        /// <para>RepresentationTerm: Text</para>
        /// <para>DataType: Text. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TextType[] Note { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Version. Identifier</para>
        /// <para>Definition: Identifies the current version of the Catalogue.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: Version</para>
        /// <para>RepresentationTerm: Identifier</para>
        /// <para>DataType: Identifier. Type</para>
        /// <para>Examples: 1.1</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentifierType VersionID { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Description. Text</para>
        /// <para>Definition: Textual description of the document instance.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: Description</para>
        /// <para>RepresentationTerm: Text</para>
        /// <para>DataType: Text. Type</para>
        /// <para>Examples: stock no longer provided</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TextType[] Description { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Validity_ Period. Period</para>
        /// <para>Definition: The period during which the Deletion of the catalogue becomes effective. This may be given as start (after date) and end dates (before date).</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTermQualifier: Validity</para>
        /// <para>PropertyTerm: Period</para>
        /// <para>AssociatedObjectClass: Period</para>
        /// <para>RepresentationTerm: Period</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ValidityPeriod", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PeriodType[] ValidityPeriod { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Deleted_ Catalogue Reference. Catalogue Reference</para>
        /// <para>Definition: A reference to the Catalogue being deleted.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTermQualifier: Deleted</para>
        /// <para>PropertyTerm: Catalogue Reference</para>
        /// <para>AssociatedObjectClass: Catalogue Reference</para>
        /// <para>RepresentationTerm: Catalogue Reference</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public CatalogueReferenceType DeletedCatalogueReference { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Referenced_ Contract. Contract</para>
        /// <para>Definition: A contract or framework agreement with which the Catalogue was associated.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTermQualifier: Referenced</para>
        /// <para>PropertyTerm: Contract</para>
        /// <para>AssociatedObjectClass: Contract</para>
        /// <para>RepresentationTerm: Contract</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ReferencedContract", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public ContractType[] ReferencedContract { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Signature</para>
        /// <para>Definition: A signature applied to this document.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTerm: Signature</para>
        /// <para>AssociatedObjectClass: Signature</para>
        /// <para>RepresentationTerm: Signature</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Signature", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public SignatureType[] Signature { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Receiver_ Party. Party</para>
        /// <para>Definition: The party receiving the Catalogue Deletion.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTermQualifier: Receiver</para>
        /// <para>PropertyTerm: Party</para>
        /// <para>AssociatedObjectClass: Party</para>
        /// <para>RepresentationTerm: Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyType ReceiverParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Provider_ Party. Party</para>
        /// <para>Definition: The party sending the Catalogue Deletion.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTermQualifier: Provider</para>
        /// <para>PropertyTerm: Party</para>
        /// <para>AssociatedObjectClass: Party</para>
        /// <para>RepresentationTerm: Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyType ProviderParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Seller_ Supplier Party. Supplier Party</para>
        /// <para>Definition: The seller.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTermQualifier: Seller</para>
        /// <para>PropertyTerm: Supplier Party</para>
        /// <para>AssociatedObjectClass: Supplier Party</para>
        /// <para>RepresentationTerm: Supplier Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public SupplierPartyType SellerSupplierParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Catalogue Deletion. Contractor_ Customer Party. Customer Party</para>
        /// <para>Definition: The customer party responsible for the contracts with which the Catalogue was associated.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Catalogue Deletion</para>
        /// <para>PropertyTermQualifier: Contractor</para>
        /// <para>PropertyTerm: Customer Party</para>
        /// <para>AssociatedObjectClass: Customer Party</para>
        /// <para>RepresentationTerm: Customer Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public CustomerPartyType ContractorCustomerParty { get; set; }
    }
}
