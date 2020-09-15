using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class VoMainScripts
    {
        private IOrganizationService _service;
        private const string EntityName = "new_vo_main_script";
        public VoMainScripts(IOrganizationService service)
        {
            _service = service;
        }

        private EntityCollection GetVoMainScriptRecors()
        {
            QueryExpression qe = new QueryExpression(EntityName)
            {
                ColumnSet = new ColumnSet("new_name"),

            };
            EntityCollection records = _service.RetrieveMultiple(qe);
            if (records.Entities.Count > 0)
            {
                return records;
            }
            return null;
        }

        public List<VoMainScriptChecked> GetCheckedVoMainScripts()
        {
            List<VoMainScriptChecked> recordsCheck = new List<VoMainScriptChecked>();
            foreach (var item in GetVoMainScriptRecors().Entities)
            {
                VoMainScriptChecked voMainScriptChecked = new VoMainScriptChecked
                {
                    VoMainScriptEntity = item
                };
                recordsCheck.Add(voMainScriptChecked);
            }
            return recordsCheck;
        }
    }

    public class VoMainScriptChecked
    {
        public Entity VoMainScriptEntity { get; set; }
        public bool IsChecked { get; set; }
    }
    public class VoMainScriptModel
    {
        public List<VoMainScriptChecked> voMainScriptChecked = new List<VoMainScriptChecked>();
    }
}
