using System.Collections.Generic;

namespace HMGOnBaseIn.DTO
{
    public class UpdateDocumentBasedConditionRequest
    {
        public List<Condition> Conditions { get; set; }
        public string RequiredDoc { get; set; }
    }

    public class Condition
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public List<string> ExceptionValues { get; set; }
    }

    public class UpdateDocumentBasedConditionResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
    }
}


//{
//    "Conditions" : [
//        {
//        "Name": "PositionTitle",
//         "Value": "",
//         "ExceptionValues": ["Cashier", "Driver", "HR"]
//        },
//        {
//        "Name": "JobTitle",
//            "Value": "Consultant",
//            "ExceptionValues": []
//        }
//    ],
//    "RequiredDoc" :"Curriculum Vitae,Iqama Copy"
//}
