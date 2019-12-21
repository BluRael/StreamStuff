using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Indieteur.GlobalHooks;
using System.IO;

namespace StreamStuff
{
    public partial class MainWindow : Form
    {
        private delegate void LabelUpdateDelegate(ref Label lblObject, string s);
        private delegate void ButtonUpdateDelegate(ref Button btnObject, bool s);
        int rebindStep = 0; int resetCount = 0; int finishCount = 0;
        GlobalKeyHook keyListener = new GlobalKeyHook();
        VirtualKeycodes activeKey = VirtualKeycodes.None;
        VirtualKeycodes latchedKey = VirtualKeycodes.None;
        VirtualKeycodes k1 = VirtualKeycodes.None;
        VirtualKeycodes k2 = VirtualKeycodes.None;
        System.Timers.Timer t = new System.Timers.Timer(500);

        public MainWindow()
        {
            //Tested commenting
            InitializeComponent();
        }
        private void keySnooper()
        {
            while (chk_enableListener.Enabled)
            {
                //Msec wait
                Thread.Sleep(1);

                //Check for key
                if (activeKey == VirtualKeycodes.None)
                {
                    //Continue waiting...
                }
                else
                {
                    //Latch key and wait
                    latchedKey = activeKey;
                    activeKey = VirtualKeycodes.None;
                    Thread.Sleep(500);

                    //Release latched key
                    latchedKey = VirtualKeycodes.None;
                }

            }
        }
        private VirtualKeycodes keyGet()
        {
            return latchedKey;
        }
        private VirtualKeycodes keyWait()
        {
            while (latchedKey != VirtualKeycodes.None)
            {
                //Msec wait for key latch
                Thread.Sleep(1);
            }
            return latchedKey;
        }
        private void keyWait(VirtualKeycodes key)
        {
            while (latchedKey != key)
            {
                //Msec wait for requested key
                Thread.Sleep(1);
            }
        }
        private void updateListenerState(bool state)
        {
            if (state)
            {
                keyListener.OnKeyDown += Keylistener_OnKeyDown;
                keyListener.OnKeyDown += Keylistener_OnKeyUp;
                keyListener.OnKeyPressed += KeyListener_OnKeyPressed;
            }
            else
            {
                keyListener.OnKeyDown -= Keylistener_OnKeyDown;
                keyListener.OnKeyDown -= Keylistener_OnKeyUp;
                keyListener.OnKeyPressed -= KeyListener_OnKeyPressed;
            }
        }
        private void loadSettings()
        {
            //Update UI with current settings
            chk_enableListener.Checked = Properties.Settings.Default.listenerEnabled;
            lbl_finishKey.Text = Properties.Settings.Default.finishKey.ToString();
            lbl_resetKey.Text = Properties.Settings.Default.resetKey.ToString();
        }
        private void saveSettings()
        {
            //Save current settings
            Properties.Settings.Default.Save();
        }
        private static void UpdateLabel(ref Label lblObject, string s)
        {
            if (lblObject.InvokeRequired)
            {
                var d = new LabelUpdateDelegate(UpdateLabel);
                lblObject.Invoke(d, new object[] { lblObject, s });
            }
            else
            {
                lblObject.Text = s;
            }
        }
        private static void UpdateButtonState(ref Button btnObject, bool s)
        {
            if (btnObject.InvokeRequired)
            {
                var d = new ButtonUpdateDelegate(UpdateButtonState);
                btnObject.Invoke(d, new object[] { btnObject, s });
            }
            else
            {
                btnObject.Enabled = s;
            }
        }
        private void rebindLabelFlash()
        {
            //Sub to flash labels while waiting for rebind key
            bool flashOn = false;
            while (rebindStep != 0)
            {
                switch (rebindStep)
                {
                    case 1:
                        //Flash first key label
                        if (flashOn) { UpdateLabel(ref lbl_resetKey, ""); flashOn = false; }
                        else { UpdateLabel(ref lbl_resetKey, "###"); flashOn = true; }
                        break;
                    case 2:
                        //Flash second key label
                        if (flashOn) { UpdateLabel(ref lbl_finishKey, ""); flashOn = false; }
                        else { UpdateLabel(ref lbl_finishKey, "###"); flashOn = true; }
                        break;
                    default:
                        break;
                }
                //Delay before next flash state
                Thread.Sleep(500);
            }
        }
        private void updateFile()
        {
            //Construct lines
            string l1 = "Resets: " + resetCount.ToString();
            string l2 = "Finishes: " + finishCount.ToString();

            //Grab information and convert to bytes
            char[] c1 = l1.ToCharArray();
            List<byte> bl = new List<byte>();
            foreach (char c in c1) { bl.Add((byte)c); }
            byte[] b1 = bl.ToArray();

            //Write text to file
            File.WriteAllBytes("resets.txt", b1);

            //Grab information and convert to bytes
            char[] c2 = l2.ToCharArray();
            bl = new List<byte>();
            foreach (char c in c2) { bl.Add((byte)c); }
            byte[] b2 = bl.ToArray();

            //Write text to file
            File.WriteAllBytes("finishes.txt", b2);

            //Update preview
            lbl_outputPreview.Text = l1 + Environment.NewLine + l2;
        }
        private void keyRebinder()
        {
            //Key rebind sub
            rebindStep = 1;

            //Clear key labels
            UpdateLabel(ref lbl_resetKey, "");
            UpdateLabel(ref lbl_finishKey, "");

            //Setup label flash timer
            t.Elapsed += T_Elapsed; t.Start();

            //Await reset keypress (Cancel pair on escape)
            while (activeKey == VirtualKeycodes.None)
            {
                //Thread.Sleep(1);
            }

            //Grab 'reset' key
            k1 = activeKey; rebindStep++;
            UpdateLabel(ref lbl_resetKey, k1.ToString());

            //Check for cancel key
            if (k1 == VirtualKeycodes.Esc)
            {
                rebindStep = 0;
                lbl_resetKey.Text = Properties.Settings.Default.resetKey.ToString();
                lbl_finishKey.Text = Properties.Settings.Default.finishKey.ToString();
                return;
            }

            //Await reset keypress (Cancel pair on escape)
            while (activeKey == VirtualKeycodes.None)
            {
                //Thread.Sleep(1);
            }

            //Grab 'finish' key
            k2 = activeKey; rebindStep++;
            UpdateLabel(ref lbl_finishKey, k2.ToString());

            //Check for cancel key
            if (k2 == VirtualKeycodes.Esc)
            {
                rebindStep = 0;
                lbl_resetKey.Text = Properties.Settings.Default.resetKey.ToString();
                lbl_finishKey.Text = Properties.Settings.Default.finishKey.ToString();
                return;
            }

            //All keys grabbed, clear flash thread and save new keybindings
            rebindStep = 0; t.Stop();
            Properties.Settings.Default.resetKey = k1;
            Properties.Settings.Default.finishKey = k2;

            //Save updated settings
            saveSettings();
            setButtonState(true);
        }
        private void setButtonState(bool state)
        {
            UpdateButtonState(ref btn_keyRedefine, state);
            UpdateButtonState(ref btn_manualReset, state);
            UpdateButtonState(ref btn_manualFinish, state);
        }
        private void addReset()
        {
            resetCount++; updateFile();
        }
        private void addFinish()
        {
            finishCount++; updateFile();
        }
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            //Startup operations
            loadSettings();
            updateFile();
        }
        private void Keylistener_OnKeyDown(object sender, GlobalKeyEventArgs e)
        {
            activeKey = e.KeyCode;
        }
        private void Keylistener_OnKeyUp(object sender, GlobalKeyEventArgs e)
        {
            if (e.KeyCode == Properties.Settings.Default.resetKey) { addReset(); }
            else if (e.KeyCode == Properties.Settings.Default.finishKey) { addFinish(); }
            activeKey = VirtualKeycodes.None;
        }
        private void KeyListener_OnKeyPressed(object sender, GlobalKeyEventArgs e)
        {
        }
        private void btn_keyRedefine_Click(object sender, EventArgs e)
        {
            setButtonState(false);
            ThreadStart ts = new ThreadStart(keyRebinder);
            Thread t = new Thread(ts); t.Start();
        }
        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            rebindLabelFlash();
        }
        private void btn_manualReset_Click(object sender, EventArgs e)
        {
            addReset();
        }
        private void btn_manualFinish_Click(object sender, EventArgs e)
        {
            addFinish();
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close all active threads
            Environment.Exit(Environment.ExitCode);
        }
        private void chk_enableListener_CheckedChanged(object sender, EventArgs e)
        {
            updateListenerState(chk_enableListener.Checked);
            
            if (chk_enableListener.Checked)
            {
                ThreadStart ts = new ThreadStart(keySnooper);
                Thread t = new Thread(ts); t.Start();
            }
        }
        private void btn_resetCounters_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("This will reset both counters to ZERO.", "Are you sure?", MessageBoxButtons
                .YesNo); if (r == DialogResult.Yes) { resetCount = finishCount = 0; updateFile(); }
        }
    }
}
