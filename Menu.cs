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
        private static Mutex mutex = new Mutex();
        public Account[] ac = new Account[3];
        private int noOfThreads;
        public Thread atm_t;

        public BankSystem()
        {
            InitializeComponent();
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);
            noOfThreads = 0;
        }

        private void newATM_Click(object sender, EventArgs e)
        {
            atm_t = new Thread(makeNewInterface);
            atm_t.Name = String.Format("Thread{0}", noOfThreads);
            noOfThreads++;
            atm_t.Start();
        }
        public void makeNewInterface()
        {
            Application.Run(new Interface(ac, mutex));
        }
    }
}
