﻿using System;
using System.IO;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace SS.Ynote.Classic.UI
{
    public partial class MacroExecDialog : Form
    {
        private FastColoredTextBox fctb;
        public MacroExecDialog(FastColoredTextBox tb)
        {
            InitializeComponent();
            foreach (var item in Directory.GetFiles(SettingsBase.SettingsDir + @"\Macros", "*.ymc"))
                cmbMacros.Items.Add(Path.GetFileNameWithoutExtension(item));
            cmbMacros.SelectedIndex = 0;
            this.fctb = tb;
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            var macro = Path.Combine(SettingsBase.SettingsDir + @"\Macros", cmbMacros.Text + ".ymc");
            int i = 0;
            while (i < times.Value)
            {
                fctb.MacrosManager.ExecuteMacros(macro);
                i++;
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}