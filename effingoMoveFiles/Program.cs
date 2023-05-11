using System;

static void Main(string[] main)
{
    Console.WriteLine("SA");
    moveFiles(main);

}
Main(args);

static void moveFiles(string[] main)
{
    //for(int i = 0; i < main.Length; i++)
    //{
    //    File.AppendAllText("hhh.txt",main[i]+"\n");
    //}
    try
    {
        string targetFolder = main[0];
        for (int i = 1; i < main.Length; i++)
        {
            //MessageBox.Show(i + " " + Path.GetExtension(main[i]));
            if(File.Exists(main[i]) && Path.GetExtension(main[i])==".pdf")
                File.Copy(main[i], Path.Combine(targetFolder, Path.GetFileName(main[i])));
            else if(Directory.Exists(main[i]))
            {
                foreach (string file in Directory.EnumerateFiles(main[i], "*.*", SearchOption.AllDirectories))
                {
                    if(Path.GetExtension(file) == ".pdf")
                    {
                        File.Copy(file, Path.Combine(targetFolder, Path.GetFileName(file)));
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