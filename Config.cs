using Exiled.API.Interfaces;
using System.ComponentModel;

namespace ReportIntegration
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Check this video if you have no idea what webhook url is: https://youtu.be/OmIOyTrb1A8")]
        public string WebHookUrl { get; set; } = "You have to put your Webhook url here";
    }
}
