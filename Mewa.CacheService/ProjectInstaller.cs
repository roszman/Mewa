using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace Mewa.CacheService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            string parameter = "MewaCacheSource\" \"MewaCacheLog"; 
            Context.Parameters["assemblypath"] = "\"" 
                + Context.Parameters["assemblypath"] 
                + "\" \"" 
                + parameter 
                + "\""; 
            base.OnBeforeInstall(savedState);
        }

    }
}
