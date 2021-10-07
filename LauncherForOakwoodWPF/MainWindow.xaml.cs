using System;
using System.IO;
using System.Windows;
using System.Drawing;
using Newtonsoft.Json;
using System.Diagnostics;
using Discord;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace LauncherForOakwoodWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DiscordRpc.EventHandlers handlers;
        DiscordRpc.RichPresence presence;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Reading JaSON-files and recent chosen Oakwood directory, if the file with it does exist
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\OakPath.txt";

                using (var reader = new StreamReader(path))
                {
                    OakPathBox.Text = reader.ReadLine();
                }

                string client_path = OakPathBox.Text + @"\config\client.json";
                string launcher_path = OakPathBox.Text + @"\config\launcher.json";

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
                MessageBox.Show("Couldn't read JaSON-files or recent saved Oakwood directory!\nMaybe, they're doesn't exist.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            #region Injecting Discord Rich Presence
            try
            {
                handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize("886277340982820894", ref handlers, true, string.Empty);

                var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                presence.largeImageKey = "logo";
                presence.largeImageText = "Oakwood Launcher";
                presence.details = "Setting up Oakwood";
                presence.startTimestamp = time;

                DiscordRpc.UpdatePresence(ref presence);
            }
            catch
            {
                MessageBox.Show("Couldn't connect to Discord!",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            #endregion
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DiscordRpc.Shutdown();
        }

        #region Creating and writing JaSON files 
        private void ConfirmSettings()
        {
            try
            {
                // Writing launcher.json
                string path = OakPathBox.Text + @"\config";
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
                    MessageBox.Show($"{new Exception().Message}\nThe typed width or height more than your screen width/height!", "Error", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new Exception();
                }

                if (Convert.ToInt32(WidthBox.Text) < 640 || Convert.ToInt32(HeightBox.Text) < 480)
                {
                    MessageBox.Show($"{new Exception().Message}\nToo small resolution!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new Exception();
                }

                var launcher_settings = JsonConvert.SerializeObject(launcher, Formatting.Indented);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (var writer = new StreamWriter(File.Create(path + @"\launcher.json")))
                {
                    launcher_settings = launcher_settings.Replace("\\\\", "\\");
                    writer.Write(launcher_settings);
                }

                // Writing client.json
                ClientJSON client = new ClientJSON()
                {
                    temp_nickname = NickNameBox.Text
                };

                var nickname = JsonConvert.SerializeObject(client, Formatting.Indented);
                using (var writer = new StreamWriter(File.Create(path + @"\client.json")))
                {
                    writer.Write(nickname);
                }

                // Writing recent chosen Oakwood directory
                if (!File.Exists(Directory.GetCurrentDirectory() + @"\OakPath.txt"))
                {
                    using (var writer = new StreamWriter(File.Create(Directory.GetCurrentDirectory() + @"\OakPath.txt")))
                    {
                        writer.WriteLine(OakPathBox.Text);
                    }
                }

                Process.Start(OakPathBox.Text + @"\Oakwood.exe");
                DiscordRpc.Shutdown();
                Application.Current.Shutdown();
            }
            catch
            {
                MessageBox.Show("Something went wrong!\nMaybe, you missed or typed wrong something :)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MafiaPathBox.Text = dialog.FileName;
            }
        }

        private void ChooseOakPath_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                OakPathBox.Text = dialog.FileName;
            }
        }
        #endregion
    }
}