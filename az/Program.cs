// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {

        string currentDirectory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        string parentDirectory = Directory.GetParent(currentDirectory)?.FullName;

        if (parentDirectory != null)
        {
            string executableName = "python.exe";
            string executablePath = Path.Combine(parentDirectory, executableName);
            string azureCli = Path.Combine(parentDirectory, "azure.cli");
            string externalArgs = string.Join(" ", args);
            string programArgs = $"-IBm azure.cli {externalArgs}";

            if (File.Exists(executablePath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(executablePath, programArgs);
                startInfo.UseShellExecute = false;// This prevents the program from opening a new window.
                startInfo.RedirectStandardOutput = true;// This allows you to read the output of the program.
                Process program = new Process();
                program.StartInfo = startInfo;
                program.Start();
                string output = program.StandardOutput.ReadToEnd();
                program.WaitForExit();
            }
            else
            {
                // Executable file not found in the parent directory.
                Console.WriteLine("python.exe not found in the parent directory. Change working directory to az.exe directory.");
            }
        }
        else
        {
            // Current directory is the root directory; cannot search for parent directory.
            Console.WriteLine("Current directory is the root directory. Change working directory to az.exe directory");
        }
    }
}

