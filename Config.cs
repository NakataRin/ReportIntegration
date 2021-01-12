using Exiled.API.Interfaces;
using System.ComponentModel;

namespace ReportIntegration
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("What types of reports should go to your Discord: local, cheats, both")]
        public string Type { get; set; } = "both";

        [Description("Should cheater reports also be send to the devs")]
        public bool SendToNorthwood { get; set; } = false;

        [Description("Check this video if you have no idea what webhook url is: https://youtu.be/OmIOyTrb1A8")]
        public string WebHookUrl { get; set; } = "You have to put your webhook url here";
    }
}
