using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using Microsoft.SharePoint;

namespace SPAuditApi.Controllers
{
    // CORS - Enable HTTP calls from any source URL
	//      - To allow specific caller DNS domains only use this syntax:
	//        (origins: "http://domain1, http://domain1",
    [EnableCors(origins: "*",
        headers: "*",
        methods: "*",
        SupportsCredentials = true)]
    [Authorize]
    public class AuditController : ApiController
    {
        // GET api/values
        public string Get()
        {
            return "OK";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "OK";
        }

        // POST api/values
        public SPAuditEntryCollection Post([FromBody]auditParam param)
        {
            using (SPSite site = new SPSite(param.siteUrl))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    // query
                    SPAuditQuery query = new SPAuditQuery(site);

                    // filters
                    if (param.rowLimit != 0)
                    {
                        query.RowLimit = param.rowLimit;
                    }

                    // list and item
                    if (param.listTitle != null)
                    {
                        SPList list = web.Lists[param.listTitle];
                        query.RestrictToList(list);
                        if (param.itemId != 0)
                        {
                            SPListItem item = list.GetItemById(param.itemId);
                            query.RestrictToListItem(item);
                        }
                    }

                    // single user
                    if (param.userId != 0)
                    {
                        query.RestrictToUser(param.userId);
                    }

                    // start and end times
                    if (param.RangeStart != null)
                    {
                        DateTime start = Convert.ToDateTime(param.RangeStart);
                        query.SetRangeStart(start);
                    }
                    if (param.RangeEnd != null)
                    {
                        DateTime end = Convert.ToDateTime(param.RangeEnd);
                        query.SetRangeEnd(end);
                    }

                    // filter event types
                    if (param.SPAuditEventType != null)
                    {
                        foreach (string s in param.SPAuditEventType)
                        {
                            if (s == "AuditMaskChange")
                            {
                                SPAuditEventType type = SPAuditEventType.AuditMaskChange;
                                query.AddEventRestriction(type);
                            }
                            if (s == "CheckIn")
                            {
                                SPAuditEventType type = SPAuditEventType.CheckIn;
                                query.AddEventRestriction(type);
                            }
                            if (s == "CheckOut")
                            {
                                SPAuditEventType type = SPAuditEventType.CheckOut;
                                query.AddEventRestriction(type);
                            }
                            if (s == "ChildDelete")
                            {
                                SPAuditEventType type = SPAuditEventType.ChildDelete;
                                query.AddEventRestriction(type);
                            }
                            if (s == "ChildMove")
                            {
                                SPAuditEventType type = SPAuditEventType.ChildMove;
                                query.AddEventRestriction(type);
                            }
                            if (s == "Copy")
                            {
                                SPAuditEventType type = SPAuditEventType.Copy;
                                query.AddEventRestriction(type);
                            }
                            if (s == "Custom")
                            {
                                SPAuditEventType type = SPAuditEventType.Custom;
                                query.AddEventRestriction(type);
                            }
                            if (s == "Delete")
                            {
                                SPAuditEventType type = SPAuditEventType.Delete;
                                query.AddEventRestriction(type);
                            }
                            if (s == "EventsDeleted")
                            {
                                SPAuditEventType type = SPAuditEventType.EventsDeleted;
                                query.AddEventRestriction(type);
                            }
                            if (s == "FileFragmentWrite")
                            {
                                SPAuditEventType type = SPAuditEventType.FileFragmentWrite;
                                query.AddEventRestriction(type);
                            }
                            if (s == "Move")
                            {
                                SPAuditEventType type = SPAuditEventType.Move;
                                query.AddEventRestriction(type);
                            }
                            if (s == "ProfileChange")
                            {
                                SPAuditEventType type = SPAuditEventType.ProfileChange;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SchemaChange")
                            {
                                SPAuditEventType type = SPAuditEventType.SchemaChange;
                                query.AddEventRestriction(type);
                            }
                            if (s == "Search")
                            {
                                SPAuditEventType type = SPAuditEventType.Search;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecGroupCreate")
                            {
                                SPAuditEventType type = SPAuditEventType.SecGroupCreate;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecGroupDelete")
                            {
                                SPAuditEventType type = SPAuditEventType.SecGroupDelete;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecGroupMemberAdd")
                            {
                                SPAuditEventType type = SPAuditEventType.SecGroupMemberAdd;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecGroupMemberDel")
                            {
                                SPAuditEventType type = SPAuditEventType.SecGroupMemberDel;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecRoleBindBreakInherit")
                            {
                                SPAuditEventType type = SPAuditEventType.SecRoleBindBreakInherit;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecRoleBindInherit")
                            {
                                SPAuditEventType type = SPAuditEventType.SecRoleBindInherit;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecRoleBindUpdate")
                            {
                                SPAuditEventType type = SPAuditEventType.SecRoleBindUpdate;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecRoleDefBreakInherit")
                            {
                                SPAuditEventType type = SPAuditEventType.SecRoleDefBreakInherit;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecRoleDefCreate")
                            {
                                SPAuditEventType type = SPAuditEventType.SecRoleDefCreate;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecRoleDefDelete")
                            {
                                SPAuditEventType type = SPAuditEventType.SecRoleDefDelete;
                                query.AddEventRestriction(type);
                            }
                            if (s == "SecRoleDefModify")
                            {
                                SPAuditEventType type = SPAuditEventType.SecRoleDefModify;
                                query.AddEventRestriction(type);
                            }
                            if (s == "Undelete")
                            {
                                SPAuditEventType type = SPAuditEventType.Undelete;
                                query.AddEventRestriction(type);
                            }
                            if (s == "Update")
                            {
                                SPAuditEventType type = SPAuditEventType.Update;
                                query.AddEventRestriction(type);
                            }
                            if (s == "View")
                            {
                                SPAuditEventType type = SPAuditEventType.View;
                                query.AddEventRestriction(type);
                            }
                            if (s == "Workflow")
                            {
                                SPAuditEventType type = SPAuditEventType.Workflow;
                                query.AddEventRestriction(type);
                            }
                        }
                    }

                    // download events
                    SPAuditEntryCollection coll = site.Audit.GetEntries(query);
                    return coll;
                }
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
