using System.Collections.Generic;

namespace Horn.Core.Utils.CmdLine
{
    public class CommandArgs : ICommandArgs
    {
        public virtual string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(Version))
                    return PackageName;

                return string.Format("{0}-{1}", PackageName, Version);
            }
        }

        public virtual string PackageName { get; private set; }

        public virtual bool RebuildOnly { get; private set; }

        public virtual string Version { get; private set; }

        public virtual bool Refresh { get; private set; }

        public virtual string OutputPath { get; private set; }

        public virtual string Mode { get; private set; }

        public CommandArgs(IDictionary<string, IList<string>> switches)
        {
            PackageName = switches["install"][0];

            RebuildOnly = switches.Keys.Contains("rebuildonly");

            Refresh = switches.Keys.Contains("refresh");

            if (switches.Keys.Contains("version"))
                Version = switches["version"][0];

            if (switches.Keys.Contains("output"))
                OutputPath = switches["output"][0];

            if (switches.Keys.Contains("mode"))
                Mode = switches["mode"][0];
        }
    }
}