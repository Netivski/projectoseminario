using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EDM.PlugInUI
{
    internal partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSyncWith3D_Click(object sender, EventArgs e)
        {
            EDM.GeneratorEntryPoint.Program.SyncWith3D();

            Close();
        }
    }
}
