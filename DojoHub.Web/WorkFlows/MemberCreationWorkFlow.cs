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
    /// <summary>
    /// Create a member in Umbraco using the workflow attached to the form
    /// </summary>
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
            // TODO: Check password matching and other sanitation and validation

            var member = new MemberCreationModel
            {
                Username = record.GetValue<string>("username"),
                DisplayName = record.GetValue<string>("username"),
                Email = record.GetValue<string>("email"),
                Password = record.GetValue<string>("password"),
                MemberTypeAlias = "Member"
            };

            try
            {
                var memberHelper = new MemberHelper(Current.Services.MemberService);
                memberHelper.Create(member);
            }
            catch (Exception)
            {
                return WorkflowExecutionStatus.Failed;
            }

            return WorkflowExecutionStatus.Completed;
        }

        public override List<Exception> ValidateSettings()
        {
            return new List<Exception>();
        }
    }
}