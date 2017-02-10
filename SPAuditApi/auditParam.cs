using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPAuditApi
{
    public class auditParam
    {
        // from MS TechNet class [Microsoft.SharePoint.SPAuditQuery]
        // https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spauditquery.aspx?f=255&MSPPError=-2147217396

        public string siteUrl;
        public uint rowLimit = 0;
        public string listTitle;
        public int itemId = 0;
        public int userId = 0;
        public string RangeStart;
        public string RangeEnd;
        public string[] SPAuditEventType;
    }
}