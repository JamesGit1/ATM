﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Sim
{
    public partial class Interface : Form
    {

        private Account[] ac = new Account[3];
        private ATM atm;

        //this is a referance to the account that is being used
        private Account activeAccount = null;

        /*
        * This function initilises the 3 accounts 
        * and instanciates the ATM class passing a referance to the account information
        * 
        */
        public Interface()
        {
            InitializeComponent();

            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);

            TextBox request = txtOutput;
            TextBox output = txtOutput;

            atm = new ATM(ac, request, output);
        }

        public void Display(string text)
        {
            txtOutput.Text += text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "5";
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

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string accountNumber = "";
            string PIN = "";
            int input = Convert.ToInt32(txtOutput.Text);
            txtOutput.Text = "";
            

            activeAccount = atm.findAccount(input);
            if (activeAccount != null)
            {
                txtRequest.Text = "Please enter pin...";
            }
        }
    }
    /*
     *   The Account class encapusulates all features of a simple bank account
     */
    class Account
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

        /*
         *   This funciton allows us to decrement the balance of an account
         *   it perfomes a simple check to ensure the balance is greater tha
         *   the amount being debeted
         *   
         *   reurns:
         *   true if the transactions if possible
         *   false if there are insufficent funds in the account
         */
        public Boolean decrementBalance(int amount)
        {
            if (this.balance > amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
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

        /*
        public void checkAccounts(int input)
        {
            //ask for account number and store result in activeAccount (null if no match found)
            activeAccount = this.findAccount(input);

            if (activeAccount != null)
            {
                //if the account is found check the pin
                if (activeAccount.checkPin(this.promptForPin()))
                //{
                //if the pin is a match give the options to do stuff to the account (take money out, view balance, exit)
                //dispOptions();
                //}
            }
            else
            {   //if the account number entered is not found let the user know!
                //Console.WriteLine("no matching account found.");
            }

            //wipes all text from the console
            //Console.Clear();
        }

        /*
         *    this method prompts for the input of an account number
         *    the string input is then converted to an int
         *    a for loop is used to check the enterd account number
         *    against those held in the account array
         *    if a match is found a referance to the match is returned
         *    if the for loop completest with no match we return null
         * 
         *
        /*
         * 
         *  this jsut promt the use to enter a pin number
         *  
         * returns the string entered converted to an int
         * 
         *

        private int promptForPin()
        {
            request.Text = "Please your pin";
            String str = Console.ReadLine();
            int pinNumEntered = Convert.ToInt32(str);
            return pinNumEntered;
        }

        /*
         * 
         *  give the use the options to do with the accoutn
         *  
         *  prompt for input
         *  and defer to appropriate method based on input
         *  
         *

        private void dispOptions()
        {
            Console.WriteLine("1> take out cash");
            Console.WriteLine("2> balance");
            Console.WriteLine("3> exit");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                //dispWithdraw();
            }
            else if (input == 2)
            {
                //dispBalance();
            }
            else if (input == 3)
            {
                //ATM atm = new ATM(ac);
            }
            else
            {

            }

        }

        /*
         * 
         * offer withdrawable amounts
         * 
         * based on input attempt to withraw the corosponding amount of money
         * 
         *
        private void dispWithdraw()
        {
            Console.WriteLine("1> 10");
            Console.WriteLine("2> 50");
            Console.WriteLine("3> 500");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input > 0 && input < 4)
            {

                //opiton one is entered by the user
                if (input == 1)
                {

                    //attempt to decrement account by 10 punds
                    if (activeAccount.decrementBalance(10))
                    {
                        //if this is possible display new balance and await key press
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        //if this is not possible inform user and await key press
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
                else if (input == 2)
                {
                    if (activeAccount.decrementBalance(50))
                    {
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
                else if (input == 3)
                {
                    if (activeAccount.decrementBalance(500))
                    {
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
            }
        }
        /*
         *  display balance of activeAccount and await keypress
         *  
         *
        private void dispBalance()
        {
            if (this.activeAccount != null)
            {
                Console.WriteLine(" your current balance is : " + activeAccount.getBalance());
                Console.WriteLine(" (prese enter to continue)");
                Console.ReadLine();
            }
        }
        */
    }

}


