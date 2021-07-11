
using System;
using System.IO;

namespace ModeloAutomacao_CSharp.Web.Utils
    {
    class Logger
        {

        private static string createLogFile(bool uniqueFile = true, string scenarioName = null)
            {
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/Logs/");
            string mainFolder = $"{Directory.GetCurrentDirectory()}/Logs/";
            string finalPart = $"_{DateTime.Now.ToString("dd_MM_yyyy")}.txt";
            string fileFullPath = $"{mainFolder}ModeloAutomacao{finalPart}";
            if (uniqueFile && scenarioName != null)
                {
                fileFullPath = $"{mainFolder}ModeloAutomacao_{scenarioName}{finalPart}";
                }
            if (!File.Exists(fileFullPath))
                {
                File.Create(fileFullPath).Close();
                }
            return fileFullPath;
            }

        public static void log(string info, bool uniqueFile = true, string scenarioName = null)
            {
            File.AppendAllText(createLogFile(uniqueFile, scenarioName), info + Environment.NewLine);
            }
        }
    }
