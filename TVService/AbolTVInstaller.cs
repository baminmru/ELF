using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace AbolTVService
{
    [RunInstaller(true)]
    public partial class AbolTVInstaller : Installer
    {
        public AbolTVInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}