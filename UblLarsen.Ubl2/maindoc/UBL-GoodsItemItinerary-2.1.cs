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
    /// <para>DictionaryEntryName: Goods Item Itinerary. Details</para>
    /// <para>Definition: A document providing details relating to a transport service, such as transport movement, identification of equipment and goods, subcontracted service providers, etc.</para>
    /// <para>ObjectClass: Goods Item Itinerary</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("ublxsd", "2.1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("GoodsItemItinerary", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:GoodsItemItinerary-2")]
#if USE_UBL_XMLROOTATTRIBUTE
    [System.Xml.Serialization.XmlRootAttribute("GoodsItemItinerary", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:GoodsItemItinerary-2", IsNullable=false)]
#endif
    public partial class GoodsItemItineraryType : UblBaseDocumentType
    {
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Copy_ Indicator. Indicator</para>
        /// <para>Definition: Indicates whether this document is a copy (true) or not (false).</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTermQualifier: Copy</para>
        /// <para>PropertyTerm: Indicator</para>
        /// <para>RepresentationTerm: Indicator</para>
        /// <para>DataType: Indicator. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IndicatorType CopyIndicator { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. UUID. Identifier</para>
        /// <para>Definition: A universally unique identifier for an instance of this document.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTerm: UUID</para>
        /// <para>RepresentationTerm: Identifier</para>
        /// <para>DataType: Identifier. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentifierType UUID { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Issue Date. Date</para>
        /// <para>Definition: The date, assigned by the sender, on which this document was issued.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTerm: Issue Date</para>
        /// <para>RepresentationTerm: Date</para>
        /// <para>DataType: Date. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public DateType IssueDate { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Issue Time. Time</para>
        /// <para>Definition: The time, assigned by the sender, at which this document was issued.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTerm: Issue Time</para>
        /// <para>RepresentationTerm: Time</para>
        /// <para>DataType: Time. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TimeType IssueTime { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Note. Text</para>
        /// <para>Definition: Free-form text pertinent to this document, conveying information that is not contained explicitly in other structures.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTerm: Note</para>
        /// <para>RepresentationTerm: Text</para>
        /// <para>DataType: Text. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TextType[] Note { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Version. Identifier</para>
        /// <para>Definition: Identifies a version of a Goods Item Itinerary in order to distinguish updates.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTerm: Version</para>
        /// <para>RepresentationTerm: Identifier</para>
        /// <para>DataType: Identifier. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentifierType VersionID { get; set; }
        
        /// <summary>
        /// ComponentType: BBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Transport Execution Plan Reference. Identifier</para>
        /// <para>Definition: The Transport Execution Plan associated with this Goods Item Itinerary.</para>
        /// <para>Cardinality: 1</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTerm: Transport Execution Plan Reference</para>
        /// <para>RepresentationTerm: Identifier</para>
        /// <para>DataType: Identifier. Type</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IdentifierType TransportExecutionPlanReferenceID { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Signature</para>
        /// <para>Definition: A signature applied to this document.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTerm: Signature</para>
        /// <para>AssociatedObjectClass: Signature</para>
        /// <para>RepresentationTerm: Signature</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Signature", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public SignatureType[] Signature { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Sender_ Party. Party</para>
        /// <para>Definition: The sender of this Goods Item Itinerary.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTermQualifier: Sender</para>
        /// <para>PropertyTerm: Party</para>
        /// <para>AssociatedObjectClass: Party</para>
        /// <para>RepresentationTerm: Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyType SenderParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Receiver_ Party. Party</para>
        /// <para>Definition: The receiver of this Goods Item Itinerary.</para>
        /// <para>Cardinality: 0..1</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTermQualifier: Receiver</para>
        /// <para>PropertyTerm: Party</para>
        /// <para>AssociatedObjectClass: Party</para>
        /// <para>RepresentationTerm: Party</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyType ReceiverParty { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Referenced_ Consignment. Consignment</para>
        /// <para>Definition: A consignment being transported in the transport service associated with this Goods Item Itinerary.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTermQualifier: Referenced</para>
        /// <para>PropertyTerm: Consignment</para>
        /// <para>AssociatedObjectClass: Consignment</para>
        /// <para>RepresentationTerm: Consignment</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ReferencedConsignment", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public ConsignmentType[] ReferencedConsignment { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Referenced_ Transport Equipment. Transport Equipment</para>
        /// <para>Definition: Transport equipment being transported in the transport service associated with this Goods Item Itinerary.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTermQualifier: Referenced</para>
        /// <para>PropertyTerm: Transport Equipment</para>
        /// <para>AssociatedObjectClass: Transport Equipment</para>
        /// <para>RepresentationTerm: Transport Equipment</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ReferencedTransportEquipment", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TransportEquipmentType[] ReferencedTransportEquipment { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Referenced_ Package. Package</para>
        /// <para>Definition: A package being transported in the transport service associated with this Goods Item Itinerary.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTermQualifier: Referenced</para>
        /// <para>PropertyTerm: Package</para>
        /// <para>AssociatedObjectClass: Package</para>
        /// <para>RepresentationTerm: Package</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ReferencedPackage", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PackageType[] ReferencedPackage { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Referenced_ Goods Item. Goods Item</para>
        /// <para>Definition: An item of goods being transported in the transport service associated with this Goods Item Itinerary.</para>
        /// <para>Cardinality: 0..n</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTermQualifier: Referenced</para>
        /// <para>PropertyTerm: Goods Item</para>
        /// <para>AssociatedObjectClass: Goods Item</para>
        /// <para>RepresentationTerm: Goods Item</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ReferencedGoodsItem", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public GoodsItemType[] ReferencedGoodsItem { get; set; }
        
        /// <summary>
        /// ComponentType: ASBIE
        /// <para>DictionaryEntryName: Goods Item Itinerary. Transportation Segment</para>
        /// <para>Definition: A part of a transport service that has its own Transport Execution Plan. A Transportation Segment may cover services other than transport, such as terminal handling, document management, customs procedures, etc.</para>
        /// <para>Cardinality: 1..n</para>
        /// <para>ObjectClass: Goods Item Itinerary</para>
        /// <para>PropertyTerm: Transportation Segment</para>
        /// <para>AssociatedObjectClass: Transportation Segment</para>
        /// <para>RepresentationTerm: Transportation Segment</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("TransportationSegment", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TransportationSegmentType[] TransportationSegment { get; set; }
    }
}
