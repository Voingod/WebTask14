using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class VoMainScripts
    {
        private IOrganizationService _service;
        private string entityName = ConfigurationManager.AppSettings.Get("EntitylName");
        private string recordName = ConfigurationManager.AppSettings.Get("RecordName");
        public VoMainScripts(IOrganizationService service)
        {
            _service = service;
        }

        private EntityCollection GetVoMainScriptRecors()
        {
            QueryExpression qe = new QueryExpression(entityName)
            {
                ColumnSet = new ColumnSet(recordName),

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
        public List<VoMainScriptChecked> voMainScriptChecked { get; set; }
    }
}
