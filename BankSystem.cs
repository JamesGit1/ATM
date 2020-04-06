using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using ATM_Sim;

namespace ATM_Sim
{
    public partial class BankSystem : Form
    {
        public Account[] ac = new Account[3];
        private int noOfThreads;
        public Thread atm_t;
        private Boolean raceCondition;
        public BankSystem()
        {
            InitializeComponent();
            // Adding 3 accounts to the ac array
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);
            // number of ATMs the user has created
            noOfThreads = 0;
        }

        private void newATM_Click(object sender, EventArgs e)
        {
            // disable the radio buttons so that the user cannot have a mix of race and 
            // non-race-condition buttons
            raceComboBox.Enabled = false;
            // if the race condition button is checked, set race-condition to true. Otherwise,
            // keep it false 
            if (raceConditionOn.Checked == true)
            {
                raceCondition = true;
            }
            else
            {
                raceCondition = false;
            }
            // make a new thread with an interface inside it, passing in the account array
            // and the user's choice of race condition radio buttons
            atm_t = new Thread(makeNewInterface);
            atm_t.Name = String.Format("Thread{0}", noOfThreads);
            noOfThreads++;
            atm_t.Start();
        }
        public void makeNewInterface()
        {
            Interface i = new Interface(ac, this, raceCondition);
            Application.Run(i);
        }

        private void BankSystem_Load(object sender, EventArgs e)
        {
            raceConditionOn.Checked = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void logText(string message){
            string newLine = Environment.NewLine;
            logBox.Invoke((MethodInvoker) delegate { logBox.Text += message + newLine; });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
