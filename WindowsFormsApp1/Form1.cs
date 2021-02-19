using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Windows.Gaming.Input;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Gamepad Controller;
        Timer t = new Timer();

        public Form1()
        {
            this.InitializeComponent();
            this.Load += Form1_Load;
            Gamepad.GamepadAdded += Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved += Gamepad_GamepadRemoved;

            t.Tick += T_Tick;
            t.Interval = 500;
            t.Start();
        }

        private async void T_Tick(object sender, EventArgs e)
        {
            if(Gamepad.Gamepads.Count > 0)
            {
                Controller = Gamepad.Gamepads.First();
                var Reading = Controller.GetCurrentReading();
                switch (Reading.Buttons)
                {
                    case GamepadButtons.A:
                        await Log("A pressed");
                        break;
                }
            }
        }

        private async void Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
            await Log("Controller Removed");
        }

        private async void Gamepad_GamepadAdded(object sender, Gamepad e)
        {
            await Log("Controller Added");
        }
        private async Task Log(string txt)
        {
            Task t = Task.Run(() =>
            {
                Debug.WriteLine(DateTime.Now.ToShortTimeString() + ": " + txt);
            });
            await t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\Steam\steamapps\common\Grand Theft Auto 3\gta3.exe");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //Left = Top = 0;
            TopMost = true;
            //Width = Screen.PrimaryScreen.WorkingArea.Width;
            //Height = Screen.PrimaryScreen.WorkingArea.Height;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
