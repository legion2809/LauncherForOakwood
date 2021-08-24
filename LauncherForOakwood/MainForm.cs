using System;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;

namespace LauncherForOakwood
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Writing client.json and launcher.json
        private void WriteSettings()
        {
            try
            {
                string path = OakPathBox.Text + "\\config\\launcher.json";
                JsonLauncher launcher = new JsonLauncher()
                {
                    gamepath = GamepathBox.Text,
                    width = Convert.ToInt32(WidthBox.Text),
                    height = Convert.ToInt32(HeightBox.Text),
                    fullscreen = isFullScreen.Checked ? true : false,
                    antialiasing = Convert.ToInt32(antiAlias.Text)
                };

                var settings = JsonConvert.SerializeObject(launcher, Formatting.Indented);

                using (var writer = new StreamWriter(path))
                {
                    writer.Write(settings);
                }

                string cpath = OakPathBox.Text + "\\config\\client.json";
                JsonClient client = new JsonClient()
                {
                    temp_nickname = NicknameBox.Text
                };

                var nname = JsonConvert.SerializeObject(client, Formatting.Indented);

                using (var writer = new StreamWriter(cpath))
                {
                    writer.Write(nname);
                }

                Process.Start(OakPathBox.Text + "\\Oakwood.exe");
                Application.Exit();
            } catch
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Parsing JaSON files
        private void readJSONButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openJSON.ShowDialog();
                dynamic filename = JsonConvert.DeserializeObject(File.ReadAllText(openJSON.FileName));

                if (result == DialogResult.OK)
                {
                    if (openJSON.FileName.Contains("client.json"))
                    {
                        NicknameBox.Text = filename["temp_nickname"];
                    }
                    else if (openJSON.FileName.Contains("launcher.json"))
                    {
                        WidthBox.Text = filename["width"];
                        HeightBox.Text = filename["height"];
                        GamepathBox.Text = filename["gamepath"];
                        isFullScreen.Checked = filename["fullscreen"] == false ? false : true;
                        antiAlias.Text = filename["antialiasing"];
                    }
                }
            } catch
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Choosing Mafia and Oakwood MP's gamepath
        private void GamePathButton_Click(object sender, EventArgs e)
        {
            DialogResult result = gameFolder.ShowDialog();

            if (result == DialogResult.OK)
            {
                GamepathBox.Text = gameFolder.SelectedPath;
            }
        }

        private void OakPathButton_Click(object sender, EventArgs e)
        {
            DialogResult result = OakFolder.ShowDialog();

            if (result == DialogResult.OK)
            {
                OakPathBox.Text = OakFolder.SelectedPath;
            }
        }
        #endregion

        #region Confirming the settings
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            WriteSettings();
        }
        #endregion
    }
}
