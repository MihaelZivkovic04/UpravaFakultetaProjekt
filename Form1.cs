using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpravaFakulteta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int timerStart = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timerStart++;
            progressBar1.Value = timerStart;

            if(progressBar1.Value == 100) 
            {
                progressBar1.Value = 0;
                timer1.Stop();

                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
