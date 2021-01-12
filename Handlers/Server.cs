namespace ReportIntegration.Handlers
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using System.Collections.Specialized;

    internal sealed class Server
    {
        public static void sendWebHook(string URL, string msg)
        {
            Http.Post(URL, new NameValueCollection()
            {
                { "content", msg }
            });
        }
        
        public void OnReport(ReportingCheaterEventArgs ev)
        {
            string type = ReportIntegration.Instance.Config.Type;
            string url = ReportIntegration.Instance.Config.WebHookUrl;
            bool sendToDevs = ReportIntegration.Instance.Config.SendToNorthwood;

            if (type == "local") return;

            if (type != "cheats" && type != "both" && type != "local")
            {
                Log.Warn("[ReportIntegration] There's an error in your config. Solution: just delete all settings related to the plugin.");
                return;
            }

            if (!sendToDevs) ev.IsAllowed = false;
            else ev.IsAllowed = true;

            sendWebHook(url, $"{ev.Reporter.UserId} ({ev.Reporter.Nickname}) has send a report to {ev.Reported.UserId} ({ev.Reported.Nickname}): ''{ev.Reason}''");
        }

        public void OnLocalReport(LocalReportingEventArgs ev)
        {
            string type = ReportIntegration.Instance.Config.Type;
            string url = ReportIntegration.Instance.Config.WebHookUrl;

            if (type == "cheats") return;

            if (type != "cheats" && type != "both" && type != "local")
            {
                Log.Warn("[ReportIntegration] There's an error in your config. Solution: just delete all settings related to the plugin.");
                return;
            }

            sendWebHook(url, $"{ev.Issuer.UserId} ({ev.Issuer.Nickname}) has send a local report to {ev.Target.UserId} ({ev.Target.Nickname}): ''{ev.Reason}''");
        }
    }
}
