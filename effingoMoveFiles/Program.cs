using System;

static void Main(string[] main)
{
    Console.WriteLine("SA");
    moveFiles(main);

}
Main(args);

static void moveFiles(string[] main)
{
    try
    {
        string targetFolder = File.ReadAllText("defaultPath.txt");
        for (int i = 0; i < main.Length; i++)
        {
            //MessageBox.Show(i + " " + Path.GetExtension(main[i]));
            if(Path.GetExtension(main[i])==".pdf")
                File.Copy(main[i], Path.Combine(targetFolder, Path.GetFileName(main[i])));
        }
        //MessageBox.Show(File.ReadAllText("defaultPath.txt"));
    }
    catch (Exception ex)
    {
        //MessageBox.Show(File.ReadAllText(ex.Message));
    }
}