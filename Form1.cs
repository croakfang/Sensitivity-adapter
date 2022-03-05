using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Sensitivity_adapter
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public IKeyboardMouseEvents mouseEvents;
        public int RecX = 1400;
        public Form1()
        {
            InitializeComponent();
            mouseEvents = Hook.GlobalEvents();
            mouseEvents.MouseWheel += OnMouseWeel;
            textBox.Text = RecX.ToString();
        }
        public void OnMouseWeel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                mouse_event(0x0001, RecX, 0, 0, 0);
            };
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RecX = int.Parse(textBox.Text.ToString());
            }
            catch (Exception)
            {
                textBox.Text = "";
            };
            
        }
    }
}
