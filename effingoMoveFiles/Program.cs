using System;
using System.Diagnostics;



static void Main(string[] main)
{
    Console.WriteLine("SA");
    moveFiles(main);
    Process.Start("FileMessageBox.exe");
}
Main(args);

static void moveFiles(string[] main)
{
    //for (int i = 0; i < main.Length; i++)
    //{
    //    File.AppendAllText("h2hh.txt", main[i] + "\n");
    //}
    //string path = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "..", "h22hh.txt");

    string path = Path.Combine(System.IO.Path.GetTempPath(), "h22hh.txt");

    try
    {
        string targetFolder = main[0];
        for (int i = 1; i < main.Length; i++)
        {
            //MessageBox.Show(i + " " + Path.GetExtension(main[i]));
            if(File.Exists(main[i]) && Path.GetExtension(main[i]) == ".pdf")
            {
                File.Copy(main[i], Path.Combine(targetFolder, Path.GetFileName(main[i])),true);
                File.AppendAllText(path, main[i] + "\n");

            }

            else if(Directory.Exists(main[i]))
            {
                foreach (string file in Directory.EnumerateFiles(main[i], "*.*", SearchOption.AllDirectories))
                {
                    if(Path.GetExtension(file) == ".pdf")
                    {
                        File.Copy(file, Path.Combine(targetFolder, Path.GetFileName(file)),true);
                        File.AppendAllText(path, main[i] + "\n");

                    }
                }
            }
        }
        //MessageBox.Show(File.ReadAllText("defaultPath.txt"));
    }
    catch (Exception ex)
    {
        //File.AppendAllText("hhh.txt", ex.Message + "\n");
    }
}