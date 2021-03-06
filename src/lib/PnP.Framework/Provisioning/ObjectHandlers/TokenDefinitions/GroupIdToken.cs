using Microsoft.SharePoint.Client;
using PnP.Framework.Attributes;
using System.Text.RegularExpressions;

namespace PnP.Framework.Provisioning.ObjectHandlers.TokenDefinitions
{
    [TokenDefinitionDescription(
     Token = "{groupid:[groupname]}",
     Description = "Returns the id of a SharePoint group given its name",
     Example = "{groupid:My Site Owners}",
     Returns = "6")]
    internal class GroupIdToken : TokenDefinition
    {
        private readonly string _groupId = string.Empty;
        public GroupIdToken(Web web, string name, string groupId)
            : base(web, $"{{groupid:{Regex.Escape(name)}}}")
        {
            _groupId = groupId;
        }

        public GroupIdToken(Web web, string name, int groupId)
            : base(web, $"{{groupid:{Regex.Escape(name)}}}")
        {
            _groupId = groupId.ToString();
        }

        public override string GetReplaceValue()
        {
            if (string.IsNullOrEmpty(CacheValue))
            {
                CacheValue = _groupId;
            }
            return CacheValue;
        }
    }
}