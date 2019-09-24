using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace BackupMails
{
    class Program
    {
        static void Main(string[] args)
        {

            var psCommmand = @"c:\utils\TurONBackupDevice_01.ps1" ;
            var psCommandBytes = System.Text.Encoding.Unicode.GetBytes(psCommmand);
            var psCommandBase64 = Convert.ToBase64String(psCommandBytes);

            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -EncodedCommand {psCommandBase64}",
                UseShellExecute = false
            };
            Process.Start(startInfo);



            //Runspace runspace = RunspaceFactory.CreateRunspace();
            //runspace.Open();
            //RunspaceInvoke runspaceInvoker = new RunspaceInvoke(runspace);

            ////Create a pipeline to send variables 
            //Pipeline pipeline = runspace.CreatePipeline();

            ////Insert a value into exiting variables in script:
            //Command myCommand = new Command(@"c\utils\TurONBackupDevice_01.ps1", false);
            //pipeline.Commands.Add(myCommand);

            ////Return the output from the script
            ////int i = pipeline.Invoke().Count;
            //Collection<PSObject> returnObjects = pipeline.Invoke();

            //runspace.Close();



            //PowerShell ps = PowerShell.Create();
            //ps.AddScript(@"D:\PSScripts\MyScript.ps1").Invoke();

            //RunScript(@"c\utils\TurONBackupDevice_01.ps1");

            System.Threading.Thread.Sleep(45000);


            try
            {
                //Process process = new Process();
                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //startInfo.FileName = "cmd.exe";
                //startInfo.Arguments = "/c net use v: \\192.168.0.1\volume2 AdminFX9. /USER:Administrator";
                //process.StartInfo = startInfo;
                //Process.Start(startInfo);

                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe");
                //procStartInfo.UseShellExecute = true;
               // procStartInfo.CreateNoWindow = true;
                procStartInfo.Verb = "runas";
               // procStartInfo.Verb = "run";
               //procStartInfo.Arguments = @"/env /user:Administrator cmd /K net use v: \\192.168.0.1\volume2 AdminFX9. /user:Administrator";
                procStartInfo.Arguments = @"cmd /K net use v: \\192.168.0.1\volume2 AdminFX9. /user:Administrator & c:\mail\backupm2.bat";

                ///command contains the command to be executed in cmd
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit(10);
            }
            catch (Exception)
            {

                throw;
            }


            //try
            //{

            //    ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe");
            //    //procStartInfo.UseShellExecute = true;
            //    // procStartInfo.CreateNoWindow = true;
            //    procStartInfo.Verb = "runas";
            //    // procStartInfo.Verb = "run";
            //    //procStartInfo.Arguments = @"/env /user:Administrator cmd /K net use v: \\192.168.0.1\volume2 AdminFX9. /user:Administrator";
            //    procStartInfo.Arguments = @"cmd /K c:\mail\backupm2.bat";

            //    ///command contains the command to be executed in cmd
            //    System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //    proc.StartInfo = procStartInfo;
            //    proc.Start();
            //    proc.WaitForExit(10);

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }


        

    }

  
}
