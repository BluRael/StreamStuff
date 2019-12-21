namespace StreamStuff
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabSelector = new System.Windows.Forms.TabControl();
            this.CounterTemp = new System.Windows.Forms.TabPage();
            this.grp_preview = new System.Windows.Forms.GroupBox();
            this.lbl_outputPreview = new System.Windows.Forms.Label();
            this.lbl_finishKey = new System.Windows.Forms.Label();
            this.lbl_resetKey = new System.Windows.Forms.Label();
            this.lbl_finishText = new System.Windows.Forms.Label();
            this.lbl_resetText = new System.Windows.Forms.Label();
            this.btn_manualFinish = new System.Windows.Forms.Button();
            this.btn_keyRedefine = new System.Windows.Forms.Button();
            this.btn_manualReset = new System.Windows.Forms.Button();
            this.chk_enableListener = new System.Windows.Forms.CheckBox();
            this.Credits = new System.Windows.Forms.TabPage();
            this.lbl_credits = new System.Windows.Forms.Label();
            this.btn_resetCounters = new System.Windows.Forms.Button();
            this.tabSelector.SuspendLayout();
            this.CounterTemp.SuspendLayout();
            this.grp_preview.SuspendLayout();
            this.Credits.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSelector
            // 
            this.tabSelector.Controls.Add(this.CounterTemp);
            this.tabSelector.Controls.Add(this.Credits);
            this.tabSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSelector.HotTrack = true;
            this.tabSelector.Location = new System.Drawing.Point(0, 0);
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.SelectedIndex = 0;
            this.tabSelector.Size = new System.Drawing.Size(341, 146);
            this.tabSelector.TabIndex = 0;
            // 
            // CounterTemp
            // 
            this.CounterTemp.Controls.Add(this.grp_preview);
            this.CounterTemp.Controls.Add(this.lbl_finishKey);
            this.CounterTemp.Controls.Add(this.lbl_resetKey);
            this.CounterTemp.Controls.Add(this.lbl_finishText);
            this.CounterTemp.Controls.Add(this.lbl_resetText);
            this.CounterTemp.Controls.Add(this.btn_manualFinish);
            this.CounterTemp.Controls.Add(this.btn_resetCounters);
            this.CounterTemp.Controls.Add(this.btn_keyRedefine);
            this.CounterTemp.Controls.Add(this.btn_manualReset);
            this.CounterTemp.Controls.Add(this.chk_enableListener);
            this.CounterTemp.Location = new System.Drawing.Point(4, 22);
            this.CounterTemp.Name = "CounterTemp";
            this.CounterTemp.Padding = new System.Windows.Forms.Padding(3);
            this.CounterTemp.Size = new System.Drawing.Size(333, 120);
            this.CounterTemp.TabIndex = 1;
            this.CounterTemp.Text = "Counters";
            this.CounterTemp.UseVisualStyleBackColor = true;
            // 
            // grp_preview
            // 
            this.grp_preview.Controls.Add(this.lbl_outputPreview);
            this.grp_preview.Location = new System.Drawing.Point(186, 6);
            this.grp_preview.Name = "grp_preview";
            this.grp_preview.Size = new System.Drawing.Size(141, 106);
            this.grp_preview.TabIndex = 3;
            this.grp_preview.TabStop = false;
            this.grp_preview.Text = "Preview";
            // 
            // lbl_outputPreview
            // 
            this.lbl_outputPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_outputPreview.Location = new System.Drawing.Point(3, 16);
            this.lbl_outputPreview.Name = "lbl_outputPreview";
            this.lbl_outputPreview.Size = new System.Drawing.Size(135, 87);
            this.lbl_outputPreview.TabIndex = 0;
            // 
            // lbl_finishKey
            // 
            this.lbl_finishKey.AutoSize = true;
            this.lbl_finishKey.Location = new System.Drawing.Point(74, 44);
            this.lbl_finishKey.Name = "lbl_finishKey";
            this.lbl_finishKey.Size = new System.Drawing.Size(27, 13);
            this.lbl_finishKey.TabIndex = 2;
            this.lbl_finishKey.Text = "F##";
            // 
            // lbl_resetKey
            // 
            this.lbl_resetKey.AutoSize = true;
            this.lbl_resetKey.Location = new System.Drawing.Point(75, 27);
            this.lbl_resetKey.Name = "lbl_resetKey";
            this.lbl_resetKey.Size = new System.Drawing.Size(29, 13);
            this.lbl_resetKey.TabIndex = 2;
            this.lbl_resetKey.Text = "R##";
            // 
            // lbl_finishText
            // 
            this.lbl_finishText.AutoSize = true;
            this.lbl_finishText.Location = new System.Drawing.Point(10, 42);
            this.lbl_finishText.Name = "lbl_finishText";
            this.lbl_finishText.Size = new System.Drawing.Size(58, 13);
            this.lbl_finishText.TabIndex = 2;
            this.lbl_finishText.Text = "Finish Key:";
            // 
            // lbl_resetText
            // 
            this.lbl_resetText.AutoSize = true;
            this.lbl_resetText.Location = new System.Drawing.Point(10, 27);
            this.lbl_resetText.Name = "lbl_resetText";
            this.lbl_resetText.Size = new System.Drawing.Size(59, 13);
            this.lbl_resetText.TabIndex = 2;
            this.lbl_resetText.Text = "Reset Key:";
            // 
            // btn_manualFinish
            // 
            this.btn_manualFinish.Location = new System.Drawing.Point(97, 89);
            this.btn_manualFinish.Name = "btn_manualFinish";
            this.btn_manualFinish.Size = new System.Drawing.Size(83, 23);
            this.btn_manualFinish.TabIndex = 1;
            this.btn_manualFinish.Text = "Manual Finish";
            this.btn_manualFinish.UseVisualStyleBackColor = true;
            this.btn_manualFinish.Click += new System.EventHandler(this.btn_manualFinish_Click);
            // 
            // btn_keyRedefine
            // 
            this.btn_keyRedefine.Location = new System.Drawing.Point(9, 60);
            this.btn_keyRedefine.Name = "btn_keyRedefine";
            this.btn_keyRedefine.Size = new System.Drawing.Size(83, 23);
            this.btn_keyRedefine.TabIndex = 1;
            this.btn_keyRedefine.Text = "Rebind Keys";
            this.btn_keyRedefine.UseVisualStyleBackColor = true;
            this.btn_keyRedefine.Click += new System.EventHandler(this.btn_keyRedefine_Click);
            // 
            // btn_manualReset
            // 
            this.btn_manualReset.Location = new System.Drawing.Point(9, 89);
            this.btn_manualReset.Name = "btn_manualReset";
            this.btn_manualReset.Size = new System.Drawing.Size(83, 23);
            this.btn_manualReset.TabIndex = 1;
            this.btn_manualReset.Text = "Manual Reset";
            this.btn_manualReset.UseVisualStyleBackColor = true;
            this.btn_manualReset.Click += new System.EventHandler(this.btn_manualReset_Click);
            // 
            // chk_enableListener
            // 
            this.chk_enableListener.AutoSize = true;
            this.chk_enableListener.Location = new System.Drawing.Point(9, 7);
            this.chk_enableListener.Name = "chk_enableListener";
            this.chk_enableListener.Size = new System.Drawing.Size(147, 17);
            this.chk_enableListener.TabIndex = 0;
            this.chk_enableListener.Text = "Enable Keyboard Listener";
            this.chk_enableListener.UseVisualStyleBackColor = true;
            this.chk_enableListener.CheckedChanged += new System.EventHandler(this.chk_enableListener_CheckedChanged);
            // 
            // Credits
            // 
            this.Credits.Controls.Add(this.lbl_credits);
            this.Credits.Location = new System.Drawing.Point(4, 22);
            this.Credits.Name = "Credits";
            this.Credits.Padding = new System.Windows.Forms.Padding(3);
            this.Credits.Size = new System.Drawing.Size(333, 120);
            this.Credits.TabIndex = 2;
            this.Credits.Text = "Credits";
            this.Credits.UseVisualStyleBackColor = true;
            // 
            // lbl_credits
            // 
            this.lbl_credits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_credits.Location = new System.Drawing.Point(3, 3);
            this.lbl_credits.Name = "lbl_credits";
            this.lbl_credits.Size = new System.Drawing.Size(327, 114);
            this.lbl_credits.TabIndex = 0;
            this.lbl_credits.Text = "StreamStuff by BluRael 2019\r\n\r\nExternal Code:\r\nGlobalHooks by Indieteur\r\nhttps://" +
    "github.com/Indieteur/GlobalHooks";
            this.lbl_credits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_resetCounters
            // 
            this.btn_resetCounters.Location = new System.Drawing.Point(97, 60);
            this.btn_resetCounters.Name = "btn_resetCounters";
            this.btn_resetCounters.Size = new System.Drawing.Size(83, 23);
            this.btn_resetCounters.TabIndex = 1;
            this.btn_resetCounters.Text = "Reset Count";
            this.btn_resetCounters.UseVisualStyleBackColor = true;
            this.btn_resetCounters.Click += new System.EventHandler(this.btn_resetCounters_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 146);
            this.Controls.Add(this.tabSelector);
            this.Name = "MainWindow";
            this.Text = "StreamStuff";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.tabSelector.ResumeLayout(false);
            this.CounterTemp.ResumeLayout(false);
            this.CounterTemp.PerformLayout();
            this.grp_preview.ResumeLayout(false);
            this.Credits.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSelector;
        private System.Windows.Forms.TabPage CounterTemp;
        private System.Windows.Forms.Label lbl_finishText;
        private System.Windows.Forms.Label lbl_resetText;
        private System.Windows.Forms.Button btn_manualFinish;
        private System.Windows.Forms.Button btn_keyRedefine;
        private System.Windows.Forms.Button btn_manualReset;
        private System.Windows.Forms.CheckBox chk_enableListener;
        private System.Windows.Forms.TabPage Credits;
        private System.Windows.Forms.GroupBox grp_preview;
        private System.Windows.Forms.Label lbl_finishKey;
        private System.Windows.Forms.Label lbl_resetKey;
        private System.Windows.Forms.Label lbl_outputPreview;
        private System.Windows.Forms.Label lbl_credits;
        private System.Windows.Forms.Button btn_resetCounters;
    }
}

