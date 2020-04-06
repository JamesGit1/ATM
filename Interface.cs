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

namespace ATM_Sim
{
    public partial class Interface : Form
    {

        public Thread atm2_t;
        public Account[] ac;
        private Boolean raceCondition;
        private ATM atm1;
        int stage;
        Mutex mutex;

        //this is a referance to the account that is being used
        private Account activeAccount = null;

        /*
        * This function initilises the 3 accounts 
        * and instanciates the ATM class passing a referance to the account information
        * 
        */
        public Interface(Account[] ac, Mutex mutex, Boolean raceCondition = false)
        {
            InitializeComponent();
            stage = 0;
            this.ac = ac;
            TextBox request = txtOutput;
            TextBox output = txtOutput;
            this.mutex = mutex;
            atm1 = new ATM(ac, request, output);
            this.raceCondition = raceCondition;
        }


        public void DisplayBalance(bool showBalance)
        {
            string newLine = Environment.NewLine;

            if (showBalance)
            {
                txtOutput.Text = "Balance: " + activeAccount.getBalance() + newLine;
                txtOutput.Text += "                         Press enter to return...";
            }
            else
            {
                txtOutput.Text = "Insufficient funds, Balance: " + activeAccount.getBalance() + newLine;
                txtOutput.Text += "                         Press enter to return...";
            }

            btnEnter.Enabled = true;
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;

            //Return to main menu
            stage = 1;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (stage == 2)
            {

                string newLine = Environment.NewLine;
                txtOutput.Text = "How much would you like to widthdraw?: " + newLine;
                txtOutput.Text += "1) £10                   4) £100" + newLine;
                txtOutput.Text += "2) £20                   5) £500" + newLine;
                txtOutput.Text += "3) £40 ";

                btn3.Enabled = true;
                btn4.Enabled = true;
                btn5.Enabled = true;

                stage++;
            }
            else if (stage == 3)
            {
                performTransaction(10);
            }
            else
            {
                txtOutput.Text += "1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (stage == 2)
            {
                DisplayBalance(true);
            }
            else if (stage == 3)
            {
                performTransaction(20);
            }
            else
            {
                txtOutput.Text += "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {

            if (stage == 3)
            {
                performTransaction(40);
            }
            else
            {
                txtOutput.Text += "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {

            if (stage == 3)
            {
                performTransaction(100);
            }
            else
            {
                txtOutput.Text += "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (stage == 3)
            {
                performTransaction(500);
            }
            else
            {
                txtOutput.Text += "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "0";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            stage = 0;
            txtRequest.Text = "Please enter your account number...";
            txtOutput.Text = "";
            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btnEnter.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (btn1.Enabled == false)
            {
                string newLine = Environment.NewLine;
                txtRequest.Text = "Welcome,                         Account Num: " + activeAccount.getAccountNum();
                txtOutput.Text = "Would you like to:" + newLine;
                txtOutput.Text += "Press 1 to take money from your account " + newLine;
                txtOutput.Text += "Press 2 to check your account balance " + newLine;
                txtOutput.Text += "Press cancel to exit";

                //Enables correct buttons
                btn0.Enabled = false;
                btn1.Enabled = true;
                btn2.Enabled = true;
                btn3.Enabled = false;
                btn4.Enabled = false;
                btn5.Enabled = false;
                btn6.Enabled = false;
                btn7.Enabled = false;
                btn8.Enabled = false;
                btn9.Enabled = false;
                btnEnter.Enabled = false;
                btnClear.Enabled = false;
                stage++;
            }
            else
            {
                menu();
            }
        }

        void menu()
        {
            if (txtOutput.Text != "")
            {
                int input;
                try
                {
                    input = Convert.ToInt32(txtOutput.Text);
                    ATM activeATM = atm1;
                    if (stage == 0)
                    {
                        if (txtOutput.Text.Length == 6)
                        {
                            activeAccount = activeATM.findAccount(input);
                            //Will continue to ask for PIN 
                            txtRequest.Text = "Please enter pin...";
                            txtOutput.Text = "";
                            stage++;
                        }
                        else
                        {
                            MessageBox.Show("Please make sure account number is 6 digits", "Account Number", MessageBoxButtons.OK);
                        }

                    }
                    else if (stage == 1)
                    {
                        if (activeAccount != null)
                        {
                            if (txtOutput.Text.Length == 4)
                            {
                                if (activeAccount.checkPin(input))
                                {
                                    string newLine = Environment.NewLine;
                                    txtRequest.Text = "Welcome,                         Account Num: " + activeAccount.getAccountNum();
                                    txtOutput.Text = "Would you like to:" + newLine;
                                    txtOutput.Text += "Press 1 to take money from your account " + newLine;
                                    txtOutput.Text += "Press 2 to check your account balance " + newLine;
                                    txtOutput.Text += "Press cancel to exit";

                                    //Disable other buttons
                                    btn0.Enabled = false;
                                    btn3.Enabled = false;
                                    btn4.Enabled = false;
                                    btn5.Enabled = false;
                                    btn6.Enabled = false;
                                    btn7.Enabled = false;
                                    btn8.Enabled = false;
                                    btn9.Enabled = false;
                                    btnEnter.Enabled = false;
                                    btnClear.Enabled = false;
                                    stage++;
                                }
                                else
                                {
                                    stage = 0;
                                    txtRequest.Text = "Please enter your account number...";
                                    txtOutput.Text = "";
                                    MessageBox.Show("Account Number or PIN inncorrect", "Invaild Details", MessageBoxButtons.OK);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please make sure PIN is 4 digits", "PIN", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            stage = 0;
                            txtRequest.Text = "Please enter your account number...";
                            txtOutput.Text = "";
                            MessageBox.Show("Account Number or PIN incorrect", "Invaild Details", MessageBoxButtons.OK);
                        }
                    }
                }
                catch (System.OverflowException)
                {
                    MessageBox.Show("Error, string entered that is too long", "Invaild Input", MessageBoxButtons.OK);
                }
            }
        }
    
        
        public bool withdrawFunds(int sum, int balance)
        {
            if (balance <= sum)
            {
                return false;
            }
            else
            {
                Thread.Sleep(5000);
                balance -= sum;
                activeAccount.setBalance(balance);
                return true;
            }
        }

        public void performTransaction(int sum)
        {
            if (!raceCondition)
            {
                mutex.WaitOne();
                int balance = activeAccount.getBalance();
                bool success = withdrawFunds(sum, balance);
                DisplayBalance(success);
                mutex.ReleaseMutex();
            }
            else
            {
                int balance = activeAccount.getBalance();
                bool success = withdrawFunds(sum, balance);
                DisplayBalance(success);
            }
        }
    }
    /*
     *   The Account class encapusulates all features of a simple bank account
     */
    public class Account
    {
        //the attributes for the account
        private int balance;
        private int pin;
        private int accountNum;

        // a constructor that takes initial values for each of the attributes (balance, pin, accountNumber)
        public Account(int balance, int pin, int accountNum)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNum = accountNum;
        }

        //getter and setter functions for balance
        public int getBalance()
        {
            return balance;
        }
        public void setBalance(int newBalance)
        {
            this.balance = newBalance;
        }


        public Boolean checkBalance(int sum)
        {
            if (this.balance > sum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         *   This funciton allows us to decrement the balance of an account
         *   it perfomes a simple check to ensure the balance is greater tha
         *   the amount being debeted
         *   
         *   reurns:
         *   true if the transactions if possible
         *   false if there are insufficent funds in the account
         */


        public int decrementBalance(int amount)
        { 
            balance -= amount;
            return balance;
        }

        /*
         * This funciton check the account pin against the argument passed to it
         *
         * returns:
         * true if they match
         * false if they do not
         */
        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getAccountNum()
        {
            return accountNum;
        }

    }
    /* 
     *      This is out main ATM class that preforms the actions outlined in the assigment hand out
     *      
     *      the constutor contains the main funcitonality.
     */
    class ATM
    {
        //local referance to the array of accounts
        private Account[] ac;
        private TextBox request;
        private TextBox output;


        // the atm constructor takes an array of account objects as a referance
        public ATM(Account[] ac, TextBox request, TextBox output)
        {
            this.ac = ac;
            this.request = request;
            this.output = output;

        }
        public Account findAccount(int input)
        {

            for (int i = 0; i < this.ac.Length; i++)
            {
                if (ac[i].getAccountNum() == input)
                {
                    return ac[i];
                }
            }

            return null;
        }
    }

}


