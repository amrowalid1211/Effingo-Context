using Microsoft.Win32;

namespace setEffingoMenu
{
    public partial class Form1 : Form
    {

        private const string MenuFolderName = "Folder\\shell\\Effingo";
        private const string MenuFileName = "Software\\Classes\\*\\shell\\Effingo";
        private const string MenuDirectoryName = "Directory\\shell\\Effingo";
        private string [] keys = { MenuFolderName, MenuDirectoryName };

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    textBox1.Text = fbd.SelectedPath;
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey rgk = Registry.CurrentUser.CreateSubKey(MenuFileName);
            rgk.SetValue("", "Copy to Effingo");
            rgk.SetValue("Icon", Directory.GetCurrentDirectory() + "\\effingo.ico");
            rgk.SetValue("MultiSelectModel", "Player");
            rgk = Registry.CurrentUser.CreateSubKey(MenuFileName + "\\command");
            string executePath = String.Format("\"{0}\" \"{1}\" \"%1\" ",
                Directory.GetCurrentDirectory() + "\\effingoMoveFiles.exe",
                textBox1.Text);
            rgk.SetValue("", executePath); 

            foreach (string key in keys)
            {
                rgk = Registry.ClassesRoot.CreateSubKey(key);
                rgk.SetValue("", "Copy to Effingo");
                rgk.SetValue("Icon", Directory.GetCurrentDirectory() + "\\effingo.ico");
                rgk.SetValue("MultiSelectModel", "Player");
                rgk = Registry.ClassesRoot.CreateSubKey(key+"\\command");
                executePath = String.Format("\"{0}\" \"{1}\" \"%1\" ",
                    Directory.GetCurrentDirectory()+ "\\effingoMoveFiles.exe",
                    textBox1.Text);
                rgk.SetValue("", executePath);
                
            }
            MessageBox.Show("Effingo Path Set Successfully");
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}