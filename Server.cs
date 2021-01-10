namespace ReportIntegration.Handlers
{
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
            ev.IsAllowed = false;

            string url = ReportIntegration.Instance.Config.WebHookUrl;

            sendWebHook(url, $"{ev.Reporter.UserId} ({ev.Reporter.Nickname}) has send a report to {ev.Reported.UserId} ({ev.Reported.Nickname}): ''{ev.Reason}''");
        }

        public void OnLocalReport(LocalReportingEventArgs ev)
        {
            string url = ReportIntegration.Instance.Config.WebHookUrl;
            
            sendWebHook(url, $"{ev.Issuer.UserId} ({ev.Issuer.Nickname}) has send a report to {ev.Target.UserId} ({ev.Target.Nickname}): ''{ev.Reason}''");
        }
    }
}
