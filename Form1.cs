using Microsoft.Win32;

namespace Effingo_Context
{
    public partial class Form1 : Form
    {
        public Form1(string[] main)
        {
            InitializeComponent();
            //var FolderPath = Directory.GetCurrentDirectory();
            this.Hide();
            moveFiles(main);
        }


        private void moveFiles(string[] main)
        {
            try
            {
                string targetFolder = File.ReadAllText("defaultPath.txt");
                for (int i = 0; i < main.Length; i++)
                {
                    MessageBox.Show(i + " " + Path.GetExtension(main[i]));
                    File.Copy(main[i], Path.Combine(targetFolder, Path.GetFileName(main[i])));
                }
                //MessageBox.Show(File.ReadAllText("defaultPath.txt"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(File.ReadAllText(ex.Message));
            }
        }

        
    }
}