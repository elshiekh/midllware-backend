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
    /// <para>DictionaryEntryName: Unawarded Notification. Details</para>
    /// <para>Definition: A document communicating to a tenderer that the contract has been awarded to different tenderer.</para>
    /// <para>ObjectClass: Unawarded Notification</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("ublxsd", "2.1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("UnawardedNotification", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:UnawardedNotification-2")]
#if USE_UBL_XMLROOTATTRIBUTE
    [System.Xml.Serialization.XmlRootAttribute("UnawardedNotification", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:UnawardedNotification-2", IsNullable=false)]
#endif
    public partial class UnawardedNotificationType : UblBaseDocumentType
    {
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Copy_ Indicator. Indicator</para>
        /// <para>Definition: Indicates whether this document is a copy (true) or not (false).</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTermQualifier: Copy</para>
        /// <para>PropertyTerm: Indicator</para>
        /// <para>RepresentationTerm: Indicator</para>
        /// <para>DataType: Indicator. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IndicatorType CopyIndicator { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Unawarded Notification. UUID. Identifier</para>
        /// <para>Definition: A universally unique identifier for an instance of this document.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTerm: UUID</para>
        /// <para>RepresentationTerm: Identifier</para>
        /// <para>DataType: Identifier. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentifierType UUID { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Contract Folder Identifier. Identifier</para>
        /// <para>Definition: An identifier, assigned by the sender, for the process file (i.e., record) to which this document belongs.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTerm: Contract Folder Identifier</para>
        /// <para>RepresentationTerm: Identifier</para>
        /// <para>DataType: Identifier. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentifierType ContractFolderID { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Issue Date. Date</para>
        /// <para>Definition: The date, assigned by the sender, on which this document was issued.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTerm: Issue Date</para>
        /// <para>RepresentationTerm: Date</para>
        /// <para>DataType: Date. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DateType IssueDate { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Issue Time. Time</para>
        /// <para>Definition: The time, assigned by the sender, at which this document was issued.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTerm: Issue Time</para>
        /// <para>RepresentationTerm: Time</para>
        /// <para>DataType: Time. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TimeType IssueTime { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Contract Name. Text</para>
        /// <para>Definition: The name, expressed as text, of this procurement project.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTerm: Contract Name</para>
        /// <para>RepresentationTerm: Text</para>
        /// <para>DataType: Text. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ContractName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TextType[] ContractName { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Note. Text</para>
        /// <para>Definition: Free-form text pertinent to this document, conveying information that is not contained explicitly in other structures.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTerm: Note</para>
        /// <para>RepresentationTerm: Text</para>
        /// <para>DataType: Text. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TextType[] Note { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Signature</para>
        /// <para>Definition: A signature applied to this document.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTerm: Signature</para>
        /// <para>AssociatedObjectClass: Signature</para>
        /// <para>RepresentationTerm: Signature</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Signature", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public SignatureType[] Signature { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Sender_ Party. Party</para>
        /// <para>Definition: The party sending this document.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTermQualifier: Sender</para>
        /// <para>PropertyTerm: Party</para>
        /// <para>AssociatedObjectClass: Party</para>
        /// <para>RepresentationTerm: Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyType SenderParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Receiver_ Party. Party</para>
        /// <para>Definition: The party receiving this document.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTermQualifier: Receiver</para>
        /// <para>PropertyTerm: Party</para>
        /// <para>AssociatedObjectClass: Party</para>
        /// <para>RepresentationTerm: Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyType ReceiverParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Minutes_ Document Reference. Document Reference</para>
        /// <para>Definition: A reference to a set of minutes associated with this award.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTermQualifier: Minutes</para>
        /// <para>PropertyTerm: Document Reference</para>
        /// <para>AssociatedObjectClass: Document Reference</para>
        /// <para>RepresentationTerm: Document Reference</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DocumentReferenceType MinutesDocumentReference { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Additional_ Document Reference. Document Reference</para>
        /// <para>Definition: A reference to an additional document associated with this document. It can be used to include annex documents such as the minutes of the awarding process meetings.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTermQualifier: Additional</para>
        /// <para>PropertyTerm: Document Reference</para>
        /// <para>AssociatedObjectClass: Document Reference</para>
        /// <para>RepresentationTerm: Document Reference</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("AdditionalDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public DocumentReferenceType[] AdditionalDocumentReference { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Tender Result</para>
        /// <para>Definition: An association to the Tender Result being notified</para>
        /// <para>Cardinality: 1..n</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTerm: Tender Result</para>
        /// <para>AssociatedObjectClass: Tender Result</para>
        /// <para>RepresentationTerm: Tender Result</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("TenderResult", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TenderResultType[] TenderResult { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Unawarded Notification. Appeal Terms</para>
        /// <para>Definition: Terms of appeal for this tendering process.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Unawarded Notification</para>
        /// <para>PropertyTerm: Appeal Terms</para>
        /// <para>AssociatedObjectClass: Appeal Terms</para>
        /// <para>RepresentationTerm: Appeal Terms</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AppealTermsType AppealTerms { get; set; }
    }
}
