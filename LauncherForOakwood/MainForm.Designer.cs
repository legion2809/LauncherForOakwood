
namespace LauncherForOakwood
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AcceptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NicknameBox = new System.Windows.Forms.TextBox();
            this.GamepathBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.isFullScreen = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.antiAlias = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GamePathButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.OakPathBox = new System.Windows.Forms.TextBox();
            this.OakPathButton = new System.Windows.Forms.Button();
            this.gameFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.OakFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.WidthBox = new System.Windows.Forms.ComboBox();
            this.HeightBox = new System.Windows.Forms.ComboBox();
            this.readJSONButton = new System.Windows.Forms.Button();
            this.openJSON = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // AcceptButton
            // 
            this.AcceptButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AcceptButton.Location = new System.Drawing.Point(126, 332);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(306, 42);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "Accept the settings and launch the game";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(122, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resolution settings:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(62, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(62, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Height:";
            // 
            // NicknameBox
            // 
            this.NicknameBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.NicknameBox.Location = new System.Drawing.Point(395, 206);
            this.NicknameBox.Name = "NicknameBox";
            this.NicknameBox.Size = new System.Drawing.Size(262, 25);
            this.NicknameBox.TabIndex = 6;
            // 
            // GamepathBox
            // 
            this.GamepathBox.Enabled = false;
            this.GamepathBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GamepathBox.Location = new System.Drawing.Point(393, 83);
            this.GamepathBox.Name = "GamepathBox";
            this.GamepathBox.Size = new System.Drawing.Size(262, 25);
            this.GamepathBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(391, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nickname:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(389, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Gamepath:";
            // 
            // isFullScreen
            // 
            this.isFullScreen.AutoSize = true;
            this.isFullScreen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isFullScreen.Location = new System.Drawing.Point(135, 184);
            this.isFullScreen.Name = "isFullScreen";
            this.isFullScreen.Size = new System.Drawing.Size(123, 21);
            this.isFullScreen.TabIndex = 10;
            this.isFullScreen.Text = "Fullscreen Mode";
            this.isFullScreen.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(391, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Antialiasing:";
            // 
            // antiAlias
            // 
            this.antiAlias.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.antiAlias.FormattingEnabled = true;
            this.antiAlias.Items.AddRange(new object[] {
            "0",
            "2",
            "4"});
            this.antiAlias.Location = new System.Drawing.Point(395, 268);
            this.antiAlias.Name = "antiAlias";
            this.antiAlias.Size = new System.Drawing.Size(260, 25);
            this.antiAlias.TabIndex = 12;
            this.antiAlias.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(555, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Other settings:";
            // 
            // GamePathButton
            // 
            this.GamePathButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GamePathButton.Location = new System.Drawing.Point(661, 82);
            this.GamePathButton.Name = "GamePathButton";
            this.GamePathButton.Size = new System.Drawing.Size(135, 25);
            this.GamePathButton.TabIndex = 14;
            this.GamePathButton.Text = "Choose gamepath";
            this.GamePathButton.UseVisualStyleBackColor = true;
            this.GamePathButton.Click += new System.EventHandler(this.GamePathButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(389, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Path of Oakwood:";
            // 
            // OakPathBox
            // 
            this.OakPathBox.Enabled = false;
            this.OakPathBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.OakPathBox.Location = new System.Drawing.Point(393, 143);
            this.OakPathBox.Name = "OakPathBox";
            this.OakPathBox.Size = new System.Drawing.Size(262, 25);
            this.OakPathBox.TabIndex = 16;
            // 
            // OakPathButton
            // 
            this.OakPathButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OakPathButton.Location = new System.Drawing.Point(661, 143);
            this.OakPathButton.Name = "OakPathButton";
            this.OakPathButton.Size = new System.Drawing.Size(158, 25);
            this.OakPathButton.TabIndex = 17;
            this.OakPathButton.Text = "Choose Oakwood path";
            this.OakPathButton.UseVisualStyleBackColor = true;
            this.OakPathButton.Click += new System.EventHandler(this.OakPathButton_Click);
            // 
            // WidthBox
            // 
            this.WidthBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WidthBox.FormattingEnabled = true;
            this.WidthBox.Items.AddRange(new object[] {
            "640",
            "720",
            "800",
            "1024",
            "1152",
            "1280",
            "1366",
            "1600",
            "1680",
            "1920",
            "2560"});
            this.WidthBox.Location = new System.Drawing.Point(66, 83);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(264, 25);
            this.WidthBox.TabIndex = 18;
            // 
            // HeightBox
            // 
            this.HeightBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeightBox.FormattingEnabled = true;
            this.HeightBox.Items.AddRange(new object[] {
            "480",
            "576",
            "600",
            "720",
            "768",
            "864",
            "900",
            "1024",
            "1050",
            "1080"});
            this.HeightBox.Location = new System.Drawing.Point(66, 143);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(264, 25);
            this.HeightBox.TabIndex = 19;
            // 
            // readJSONButton
            // 
            this.readJSONButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readJSONButton.Location = new System.Drawing.Point(463, 332);
            this.readJSONButton.Name = "readJSONButton";
            this.readJSONButton.Size = new System.Drawing.Size(306, 42);
            this.readJSONButton.TabIndex = 20;
            this.readJSONButton.Text = "Tap here to read JaSON-files";
            this.readJSONButton.UseVisualStyleBackColor = true;
            this.readJSONButton.Click += new System.EventHandler(this.readJSONButton_Click);
            // 
            // openJSON
            // 
            this.openJSON.Filter = "JSON-files|*.json";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 411);
            this.Controls.Add(this.readJSONButton);
            this.Controls.Add(this.HeightBox);
            this.Controls.Add(this.WidthBox);
            this.Controls.Add(this.OakPathButton);
            this.Controls.Add(this.OakPathBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GamePathButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.antiAlias);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.isFullScreen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GamepathBox);
            this.Controls.Add(this.NicknameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AcceptButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(969, 450);
            this.MinimumSize = new System.Drawing.Size(969, 450);
            this.Name = "MainForm";
            this.Text = "Launcher for Mafia: Oakwood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NicknameBox;
        private System.Windows.Forms.TextBox GamepathBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox isFullScreen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox antiAlias;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button GamePathButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox OakPathBox;
        private System.Windows.Forms.Button OakPathButton;
        private System.Windows.Forms.FolderBrowserDialog gameFolder;
        private System.Windows.Forms.FolderBrowserDialog OakFolder;
        private System.Windows.Forms.ComboBox WidthBox;
        private System.Windows.Forms.ComboBox HeightBox;
        private System.Windows.Forms.Button readJSONButton;
        private System.Windows.Forms.OpenFileDialog openJSON;
    }
}

