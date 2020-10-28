using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var item in checkedListBox1.CheckedItems)
            {
                var game = (GameType)Enum.Parse(typeof(GameType), item.ToString(), true);
                switch (game)
                {
                    case GameType.XY:
                    case GameType.ORAS:
                    case GameType.SM:
                    case GameType.USUM:
                        var ds = new Core3DS(game);
                        ds.Export(@$"{txtSourceFolder.Text}\{game}_\", @$"{txtExportFolder.Text}\{game}\");//, @$"{path}\Plain\{game}\"
                        break;
                    case GameType.GPGE:
                    case GameType.SWSH:
                    case GameType.Home:
                        var ns = new CoreNS(game);
                        ns.Export(@$"{txtSourceFolder.Text}\{game}\", @$"{txtExportFolder.Text}\{game}\");
                        break;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var def = txtExportFolder.Text;
            if (def.Length == 0) def = Properties.Settings.Default.SourceFolder;
            if (def.Length > 0) folderBrowserDialog1.SelectedPath = def;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSourceFolder.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.SourceFolder = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSourceFolder.Text = Properties.Settings.Default.SourceFolder;
            txtExportFolder.Text = Properties.Settings.Default.ExportFolder;
            txtFormattedFolder.Text = Properties.Settings.Default.FormattedFolder;

            checkedListBox1.Items.Add(GameType.XY);
            checkedListBox1.Items.Add(GameType.ORAS);
            checkedListBox1.Items.Add(GameType.SM);
            checkedListBox1.Items.Add(GameType.USUM);
            checkedListBox1.Items.Add(GameType.GPGE);
            checkedListBox1.Items.Add(GameType.SWSH);
            checkedListBox1.Items.Add(GameType.Home);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnExportFolder_Click(object sender, EventArgs e)
        {

            var def = txtExportFolder.Text;
            if (def.Length == 0) def = Properties.Settings.Default.ExportFolder;
            if (def.Length > 0) folderBrowserDialog1.SelectedPath = def;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtExportFolder.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.ExportFolder = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnFormatted_Click(object sender, EventArgs e)
        {

            var def = txtFormattedFolder.Text;
            if (def.Length == 0) def = Properties.Settings.Default.FormattedFolder;
            if (def.Length > 0) folderBrowserDialog1.SelectedPath = def;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFormattedFolder.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.FormattedFolder = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
            {
                var game = (GameType)Enum.Parse(typeof(GameType), item.ToString(), true);
                switch (game)
                {
                    case GameType.XY:
                    case GameType.ORAS:
                    case GameType.SM:
                    case GameType.USUM:
                    case GameType.GPGE:
                    case GameType.SWSH:
                    case GameType.Home:
                        TextFormatter.Format(game, @$"{txtExportFolder.Text}\{game}\", @$"{txtFormattedFolder.Text}\{game}\");
                        break;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
