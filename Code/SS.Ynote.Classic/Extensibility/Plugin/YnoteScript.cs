using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CSScriptLibrary;

namespace SS.Ynote.Classic.Core.Extensibility
{
    /// <summary>
    ///     Ynote Script Helper Class
    /// </summary>
    public static class YnoteScript
    {
        /// <summary>
        ///     Gets the required assembly references for ynote
        /// </summary>
        /// <returns></returns>
        private static string[] GetReferences()
        {
            return new[]
            {
                Assembly.GetExecutingAssembly().FullName,
                Application.StartupPath + @"\FastColoredTextBox.dll",
                Application.StartupPath + @"\WeifenLuo.WinFormsUI.Docking"
            };
        }

        public static void RunScript(IYnote ynote, string ysfile)
        {
            var assemblyFileName = ysfile + "c";
            CSScript.GlobalSettings.TargetFramework = "v3.5";
            //try
            //{
            // var helper =
            //     new AsmHelper(CSScript.LoadMethod(File.ReadAllText(ysfile), GetReferences()));
            // helper.Invoke("*.Run", ynote);
            var assembly = !File.Exists(assemblyFileName)
                ? CSScript.LoadMethod(File.ReadAllText(ysfile), assemblyFileName, false, GetReferences())
                : Assembly.LoadFrom(assemblyFileName);
            using (var execManager = new AsmHelper(assembly))
            {
                execManager.Invoke("*.Main", ynote);
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("There was an Error running the script : \r\n" + ex.Message, "YnoteScript Host",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        public static void InvokeScript(string ys, string method,params object[] references)
        {
            var assemblyFileName = ys + "c";
            CSScript.GlobalSettings.TargetFramework = "v3.5";
            //try
            //{
            // var helper =
            //     new AsmHelper(CSScript.LoadMethod(File.ReadAllText(ysfile), GetReferences()));
            // helper.Invoke("*.Run", ynote);
            Assembly assembly;
            if (!File.Exists(assemblyFileName))
                assembly = CSScript.LoadMethod(File.ReadAllText(ys), assemblyFileName, false, GetReferences());
            else
                assembly = Assembly.LoadFrom(assemblyFileName);
            using (var execManager = new AsmHelper(assembly))
            {
                execManager.Invoke(method, references);
            }
        }

        public static void RunCode(string code)
        {
            try
            {
                CSScript.GlobalSettings.TargetFramework = "v3.5";
                //try
                //{
                // var helper =
                //     new AsmHelper(CSScript.LoadMethod(File.ReadAllText(ysfile), GetReferences()));
                // helper.Invoke("*.Run", ynote);
                var assembly = CSScript.LoadMethod(code, GetReferences());
                using (var execManager = new AsmHelper(assembly))
                {
                    execManager.Invoke("*.Main", Globals.Ynote);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        ///     Gets a interface/class/value from a script's main method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reference"></param>
        /// <param name="ysfile"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static T Get<T>(object reference, string ysfile, string method)
        {
            T val;
            var assemblyFileName = ysfile + "c";
            CSScript.GlobalSettings.TargetFramework = "v3.5";
            //try
            //{
            // var helper =
            //     new AsmHelper(CSScript.LoadMethod(File.ReadAllText(ysfile), GetReferences()));
            // helper.Invoke("*.Run", ynote);
            var assembly = !File.Exists(assemblyFileName)
                ? CSScript.LoadMethod(File.ReadAllText(ysfile), assemblyFileName, true, GetReferences())
                : Assembly.LoadFrom(assemblyFileName);
            using (var execManager = new AsmHelper(assembly))
            {
                val = (T) (execManager.Invoke(method, reference));
            }
            return val;
        }
    }
}