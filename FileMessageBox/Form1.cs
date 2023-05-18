using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace FileMessageBox
{
    public partial class Form1 : Form
    {
        Timer t;
        int curr = 0;
        int max = 200;
        string path = Path.Combine(System.IO.Path.GetTempPath(), "h22hh.txt");
        //string path = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location , "..","h22hh.txt");
        public Form1()
        {
            InitializeComponent();
            t= new Timer();
            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object? sender, EventArgs e)
        {
            //if(File.Exists("h2hh.txt"))
            //    label1.Text = File.ReadAllLines(path).Length + " Lines";
            curr++;

            Process[] processes = Process.GetProcessesByName("effingoMoveFiles");
            //label2.Text += processes.Length + " ";
            if (processes.Length == 0 || curr == max)
            {
                t.Stop();
                //label1.Text += " END";
                if(File.Exists(path))
                MessageBox.Show(File.ReadAllLines(path).Length + " files were sent to Effingo");
                File.WriteAllText(path, "");
                Application.Exit();
            }
            //label1.Text = Process.GetProcessesByName()
            int procCount = 0;

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(0,0);
            Visible = false;
           // ShowInTaskbar = false;
           // base.OnLoad(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}