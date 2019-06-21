using System;
using System.Collections.Generic;
using DojoHub.Web.Helpers;
using DojoHub.Web.Models;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;
using Umbraco.Forms.Core.Persistence.Dtos;
using Umbraco.Web.Composing;

namespace DojoHub.Web.WorkFlows
{
    // https://our.umbraco.com/documentation/Add-ons/UmbracoForms/Developer/Extending/Adding-a-Workflowtype
    public class MemberCreationWorkFlow : WorkflowType
    {
        public MemberCreationWorkFlow()
        {
            Id = new Guid("a713f108-d864-4397-abcc-b6f55a7a7106");
            Name = "Member Creation WorkFlow";
            Description = "This workflow is for creating members with the data passed via the form";
            Group = "Services";
        }

        public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
        {
            var member = new MemberCreationModel
            {
                Username = "Test2",
                DisplayName = "DisplayName2",
                Email = "a@a.no",
                MemberTypeAlias = "Member"
            };
            // DO STUFF
            var memberHelper = new MemberHelper(Current.Services.MemberService);
            memberHelper.Create(member);
            // record values = record.RecordFields.Values
            throw new NotImplementedException();
        }

        public override List<Exception> ValidateSettings()
        {
            return new List<Exception>();
        }
    }
}