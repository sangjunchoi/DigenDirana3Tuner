using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;


namespace Dirana3Tuner
{
    public partial class Dirana3TunerMainForm : MetroFramework.Forms.MetroForm
    {
        private const int HOLD_BUTTON_DURATION = 1000;
        private bool m_buttonUp = false;
        private int m_primary_radio_index = 0;

        

        public Dirana3TunerMainForm()
        {
            InitializeComponent();

        }

        private void macTrackBar1_ValueChanged(object sender, decimal value)
        {
            label1.Text = ((float)macTrackBar1.Value / 100.0).ToString("N2");
        }

        
        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            Button r_button = (Button)sender;
            if (e.Button == MouseButtons.Right)
            {
                initFrequency(r_button);
            }
            else
            {
                m_buttonUp = false;
                DateTime m_DateTime = DateTime.Now;
                while (e.Button == MouseButtons.Left && e.Clicks == 1 && (m_buttonUp == false && (DateTime.Now - m_DateTime).TotalMilliseconds < HOLD_BUTTON_DURATION))
                    Application.DoEvents();
                if ((DateTime.Now - m_DateTime).TotalMilliseconds < HOLD_BUTTON_DURATION)
                    Console.WriteLine("ShotClick");
                else
                    displayFrequency(r_button);
            }
        }
        private void MouseReleseEvent(object sender, MouseEventArgs e)
        {
            m_buttonUp = true;
        }

        private void displayFrequency(Button o)
        {
            
            this.Invoke(new MethodInvoker(delegate()
            {
                switch (o.Name)
                {
                    case "button19":
                        o.Text = label1.Text;
                        break;
                }
            }));
        }
        private void initFrequency(Button o) 
        {
            switch (o.Name)
            {
                case "button19":
                    o.Text = "0";
                    break;
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            m_primary_radio_index++;
            if (m_primary_radio_index > 7)
                m_primary_radio_index = 0;
            materialTabControl1.SelectedIndex = m_primary_radio_index;


        }

        private void button8_Click(object sender, EventArgs e)
        {
            AudioControlForm r_AudioControlForm = new AudioControlForm();
            //r_AudioControlForm.FormClosed += new FormClosedEventHandler(New_Version_FormClosed);
            //this.Hide();
            r_AudioControlForm.ShowDialog(); 
        }
    }
}
