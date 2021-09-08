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
                string path = Directory.GetCurrentDirectory() + "\\Pathes.txt";

                using (var reader = new StreamReader(path))
                {
                    MafiaPathBox.Text = reader.ReadLine();
                    OakPathBox.Text = reader.ReadLine();
                }

                string client_path = OakPathBox.Text + "\\config\\client.json";
                string launcher_path = OakPathBox.Text + "\\config\\launcher.json";

                dynamic client = JsonConvert.DeserializeObject(File.ReadAllText(client_path));
                dynamic launcher = JsonConvert.DeserializeObject(File.ReadAllText(launcher_path));

                // launcher.json settings
                MafiaPathBox.Text = launcher["gamepath"];
                WidthBox.Text = launcher["width"];
                HeightBox.Text = launcher["height"];
                IsFullScreenCheck.IsChecked = launcher["fullscreen"] == true ? true : false;
                AntiAliasingBox.Text = launcher["antialiasing"];

                // client.json settings
                NickNameBox.Text = client["temp_nickname"];
            }
            catch
            {
                MessageBox.Show("Couldn't read recent saved Mafia/Oakwood directory or JaSON-files!\nMaybe, they're doesn't exist.",
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
                string path = OakPathBox.Text + "\\config";
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
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (var writer = new StreamWriter(File.Create(path + "\\launcher.json")))
                {
                    writer.Write(launcher_settings);
                }

                // Writing client.json
                string client_path = OakPathBox.Text + "\\config";
                ClientJSON client = new ClientJSON()
                {
                    temp_nickname = NickNameBox.Text
                };

                var nickname = JsonConvert.SerializeObject(client, Formatting.Indented);
                if (!Directory.Exists(client_path))
                {
                    Directory.CreateDirectory(client_path);
                }

                using (var writer = new StreamWriter(File.Create(client_path + "\\client.json")))
                {
                    writer.Write(nickname);
                }

                using (var writer = new StreamWriter(File.Create(Directory.GetCurrentDirectory() + "\\Pathes.txt")))
                {
                    writer.WriteLine(MafiaPathBox.Text);
                    writer.WriteLine(OakPathBox.Text);
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

        /*#region Reading JaSON files and putting info from them into specified textboxes
        private void ReadJaSONButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string client_path = OakPathBox.Text + "\\config\\client.json";
                string launcher_path = OakPathBox.Text + "\\config\\launcher.json";

                dynamic client = JsonConvert.DeserializeObject(File.ReadAllText(client_path));
                dynamic launcher = JsonConvert.DeserializeObject(File.ReadAllText(launcher_path));

                // launcher.json settings
                MafiaPathBox.Text = launcher["gamepath"];
                WidthBox.Text = launcher["width"];
                HeightBox.Text = launcher["height"];
                IsFullScreenCheck.IsChecked = launcher["fullscreen"] == true ? true : false;
                AntiAliasingBox.Text = launcher["antialiasing"];

                // client.json settings
                NickNameBox.Text = client["temp_nickname"];
            }
            catch
            {
                MessageBox.Show("Couldn't read files!\nMaybe, the field with Oakwood directory is empty or 'config' folder doesn't exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion*/

        #region Choosing Mafia and Oakwood directories
        private void ChooseMafiaPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                MafiaPathBox.Text = dialog.SelectedPath;
            }
        }

        private void ChooseOakPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                OakPathBox.Text = dialog.SelectedPath;
            }
        }
        #endregion
    }
}
