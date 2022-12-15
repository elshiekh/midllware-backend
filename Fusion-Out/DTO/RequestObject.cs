using System.Collections.Generic;

namespace Fusion_Out.DTO
{
    public class Request
    {
        public IDictionary<string, object> GenericObject { get; set; }
    }

    public class BodyBase64Request
    {
        public string Base64Request { get; set; }
    }
}
