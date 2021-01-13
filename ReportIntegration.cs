using System;
using Exiled.API.Enums;
using Exiled.API.Features;

using Server = Exiled.Events.Handlers.Server;

namespace ReportIntegration
{
    public class ReportIntegration : Plugin<Config>
    {
        private static readonly Lazy<ReportIntegration> LazyInstance = new Lazy<ReportIntegration>(() => new ReportIntegration());
        public static ReportIntegration Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Server server;

        private ReportIntegration()
        {

        }

        public override void OnEnabled()
        {
            base.OnEnabled();

            if (!Config.IsEnabled) return;

            RegisterEvents();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            server = new Handlers.Server();

            Server.ReportingCheater += server.OnReport;
            Server.LocalReporting += server.OnLocalReport;
        }

        public void UnregisterEvents()
        {
            Server.ReportingCheater -= server.OnReport;
            Server.LocalReporting -= server.OnLocalReport;

            server = null;
        }
    }
}
