using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace dumper
{
    public partial class Form1 : Form
    {
        public static bool test = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Log(string text)
        {
            logi.Invoke(new MethodInvoker(delegate () { logi.AppendText(text + "\r\n"); logi.ScrollToCaret(); }));
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            logi.Text = "";
            if (ip.Text == "IP")
            {
                Log("[!] Fill IP");
            }
            else if (port.Text == "PORT")
            {
                Log("[!] Fill PORT");
            }
            else if (port.Text == "")
            {
                Log("[!] Provide PORT");
            }
            else if (ip.Text == "")
            {
                Log("[!] Provide IP");
            }
            else if (port.Text == " ")
            {
                Log("[!] Provide PORT");
            }
            else if (ip.Text == " ")
            {
                Log("[!] Provide IP");
            }
            else
            {
                var path = new Uri(
    System.IO.Path.GetDirectoryName(
        System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
    ).LocalPath;
                Process test = new Process();
                test.StartInfo.FileName = "java";
                test.StartInfo.UseShellExecute = false;
                test.StartInfo.Arguments = "-jar dumper.jar -a " + ip.Text + " -p " + port.Text + " -o freedumper";
                test.StartInfo.RedirectStandardOutput = false;
                test.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                string jd = @"\" + ip.Text;
                try
                {
                    Log("[✔️] Dumping Started...");
                    Log("[🔽] Files saving in: " + path + jd);
                    test.Start();                    
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }               
            }
        }
    }

}
