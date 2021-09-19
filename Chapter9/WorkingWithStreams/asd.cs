
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace CNFchanger
{
    public partial class Form1 : Form
    {
        private string CnfPath;
        private Dictionary<string, string> CnfButtons;
        private int LastUsed;

        public Form1()
        {
            InitializeComponent();
            CnfButtons = new Dictionary<string, string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    CheckAllCnf(fbd.SelectedPath);
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    button1.Enabled = false;
                }
            }
        }

        private void CurrentCnf(string item)
        {
            if (item.Substring(CnfPath.Length + 1).Contains("cnfserver.ini"))
            {
                //    System.Windows.Forms.MessageBox.Show("FUCK");
                richTextBox1.AppendText("\r\nkekekekke" + item);
                string[] ipLine = File.ReadAllLines(item);
                foreach (string line in ipLine)
                {
                    if (line.Length > 7)
                    {
                        if (line.Substring(0, 6).Contains("SERVER"))
                        {
                            textCurrent.Text = line.Substring(7);
                            break;
                        }
                    }
                }

            }
        }

        private void CheckAllCnf(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            CnfPath = directoryPath;
            int k=0,o=0;
            foreach(string item in files)
            {
                if (item.Substring(directoryPath.Length+1).Contains("cnfserver"))
                {
                    CurrentCnf(item);
                    //CnfPaths[o] += item;
                    k += 29;
                    richTextBox1.AppendText("\r\n" + item);
                    richTextBox1.ScrollToCaret();

                    var cnfButton = new Button();
                    cnfButton.Location = new Point(190, 70 + k);
                    cnfButton.Text = "Pouzi";
                    cnfButton.Name = "cnfBtn" + o.ToString();
                    cnfButton.Click += btnX_Click;
                    this.Controls.Add(cnfButton);

                    var cnfText = new TextBox();
                    cnfText.Location = new Point(55,70 + k);
                    cnfText.Size = new Size(130, 23);
                    cnfText.ReadOnly = true;
                    cnfText.Name = "cnfText" + o.ToString();
                    o++;
                    this.Controls.Add(cnfText);
                    CnfButtons.Add(cnfButton.Name, item);
                    //File.Move(item, directoryPath + "\\cnferser" + k.ToString()+".ini");
                    string[] lines = File.ReadAllLines(item);
                    foreach(string line in lines)
                    {
                        if (line.Length > 7)
                        {
                            if (line.Substring(0, 6).Contains("SERVER"))
                            {
                                cnfText.Text = line.Substring(7);
                                break;
                            }
                        }
                    }
                    //richTextBox1.AppendText("\r\n" + item.Substring(directoryPath.Length + 1));
                    richTextBox1.AppendText(" "+cnfText.Name+" ");
                    richTextBox1.AppendText(cnfButton.Name);
                    richTextBox1.AppendText("\r\n");
                }
            }
            richTextBox1.AppendText("\r\n"+directoryPath);
            
        }

        private void CnfButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name.Contains("cnfBtn")){
                System.Windows.Forms.MessageBox.Show("CLICKEEED");
                foreach (KeyValuePair<string, string> entry in CnfButtons)
                {
                    richTextBox1.AppendText("\r\n" + entry.Value);
                }
                    foreach (KeyValuePair<string,string> entry in CnfButtons)
                    {
                    if (entry.Value.Substring(CnfPath.Length+1) == "cnfserver.ini")
                        {
                        richTextBox1.AppendText("\r\n wannabe cnf: " + CnfPath + "\\cnfserver" + entry.Key.Substring(6) + ".ini");

                        File.Move(CnfPath+"\\cnfserver.ini",CnfPath+"\\cnfserver"+entry.Key.Substring(6)+".ini");
                        CnfButtons[entry.Key] = CnfPath + "\\cnfserver" + entry.Key.Substring(6) + ".ini";

                        string newCnf;
                        CnfButtons.TryGetValue(btn.Name,out newCnf);
                        File.Move(newCnf, CnfPath + "\\cnfserver.ini");

                        //richTextBox1.AppendText("\r\n NEW CONFIG: " + newCnf);
                        
                        }
                    }
            }
            CurrentCnf(CnfPath + "\\cnfserver.ini");
        }
    }
}
