using System;
using System.IO;
using System.Windows;
using System.Drawing;
using Newtonsoft.Json;
using System.Diagnostics;

namespace LauncherForOakwoodWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Reading recent chosen Mafia and Oakwood directories, if the files with them does exist
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string mafia_path = File.ReadAllText(Directory.GetCurrentDirectory() + "\\MafiaPath.txt");
                string oak_path = File.ReadAllText(Directory.GetCurrentDirectory() + "\\OakPath.txt");

                MafiaPathBox.Text = mafia_path;
                OakPathBox.Text = oak_path;
            } catch
            {
                MessageBox.Show("Couldn't read recent saved Oakwood directory!\nMaybe, files doesn't exist.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region Creating and writing JaSON files 
        private void ConfirmSettings()
        {
            try
            {
                // Writing launcher.json
                string path = OakPathBox.Text + "\\config\\launcher.json";
                LauncherJSON launcher = new LauncherJSON()
                {
                    gamepath = MafiaPathBox.Text,
                    width = Convert.ToInt32(WidthBox.Text),
                    height = Convert.ToInt32(HeightBox.Text),
                    fullscreen = (bool)IsFullScreenCheck.IsChecked ? true : false,
                    antialiasing = Convert.ToInt32(AntiAliasingBox.Text)
                };

                if (Convert.ToInt32(WidthBox.Text) > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width ||
                    Convert.ToInt32(HeightBox.Text) > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
                {
                    MessageBox.Show($"{new Exception().Message}\nThe typed width or height more than your screen width/height!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new Exception();
                }

                var launcher_settings = JsonConvert.SerializeObject(launcher, Formatting.Indented);
                using (var writer = new StreamWriter(path))
                {
                    writer.Write(launcher_settings);
                }

                // Writing client.json
                string client_path = OakPathBox.Text + "\\config\\client.json";
                ClientJSON client = new ClientJSON()
                {
                    temp_nickname = NickNameBox.Text
                };

                var nickname = JsonConvert.SerializeObject(client, Formatting.Indented);
                using (var writer = new StreamWriter(client_path))
                {
                    writer.Write(nickname);
                }

                if (OakPathBox.Text.Length == 0)
                {
                    MessageBox.Show("Path to Oakwood not specified!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new Exception();
                }

                Process.Start(OakPathBox.Text + "\\Oakwood.exe");
                Application.Current.Shutdown();
            }
            catch
            {
                MessageBox.Show("Something went wrong!\nMaybe, you missed something :)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ConfirmSettings();
        }
        #endregion

        #region Reading JaSON files and putting info from them into specified textboxes
        private void ReadJaSONButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new System.Windows.Forms.OpenFileDialog();
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                dynamic filename = JsonConvert.DeserializeObject(File.ReadAllText(dialog.FileName));

                if (dialog.FileName.Contains("launcher.json"))
                {
                    MafiaPathBox.Text = filename["gamepath"];
                    WidthBox.Text = filename["width"];
                    HeightBox.Text = filename["height"];
                    IsFullScreenCheck.IsChecked = filename["fullscreen"] == true ? true : false;
                    AntiAliasingBox.Text = filename["antialiasing"];
                }
                else if (dialog.FileName.Contains("client.json"))
                {
                    NickNameBox.Text = filename["temp_nickname"];
                }
            }
            catch
            {
                MessageBox.Show(new Exception().Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Choosing Mafia and Oakwood directories
        private void ChooseMafiaPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                MafiaPathBox.Text = dialog.SelectedPath;
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\MafiaPath.txt", MafiaPathBox.Text);
            }
        }

        private void ChooseOakPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                OakPathBox.Text = dialog.SelectedPath;
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\OakPath.txt", OakPathBox.Text);
            }  
        }
        #endregion
    }
}
