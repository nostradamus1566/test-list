using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_List
{
    public partial class Form1 : Form
    {

        List<int> list = new List<int>();
        int[] intArr;


        public Form1()
        {
            InitializeComponent();
        }
       private void displayMessage(Label lbl, string msg)
        {
            lbl.Text = msg;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lblResult.Text = "Result: ";
            
            int maxNums = 100000, i, rndNum, num2;
            bool different = false;
            intArr = new int[maxNums];
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            Thread thread = new Thread(() => displayMessage(label4, "Please wait...generating random numbers."));
            thread.Start();
            thread.Join();
            list.Clear();

            for (i = 1; i <=maxNums; i++)
            {
                rndNum = rnd.Next(1, maxNums);
                list.Add(rndNum);
                intArr[i - 1] = rndNum;

            }
            //Test the result of storing the numbers to see if they are the same as in the array
            i = 0;
            
           
            
            foreach(var num in list)
            {
                num2 = intArr[i++];
                if (num != num2)
                {
                    different = true;                  
                }
                string s = String.Format("{0,-12}{1}", num, num2) + Environment.NewLine;
                sb.Append(s);
                
            }
           
            lblResult.Text = (different) ? "The coming out secquence is not the same as in the array": "The coming out sequence is the same.";
            textBox1.Text = sb.ToString();
            thread = new Thread(() => displayMessage(label4, "..."));
            thread.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(list.Count == 0)
            {
                MessageBox.Show("Populate the list first before sorting it", "Nothing to sort yet!");
                return;
            }
            Thread thread = new Thread(() => displayMessage(label4, "Please wait...sorting numbers."));
            thread.Start();
            thread.Join();
            list.Sort();
            Array.Sort<int>(intArr);
            int num1, num2;
            string s;
            StringBuilder sb = new StringBuilder();
            string tag = string.Empty;
            for (int i = 0; i < intArr.Length; i++)
            {
                num1 = list[i];
                num2 = intArr[i];
                if(num1 != num2)
                {
                    tag = " different";
                }
                s = String.Format("{0,-12}{1}{2}", num1, num2, tag) + Environment.NewLine;
                sb.Append(s);

            }
            textBox1.Text = sb.ToString();
            thread = new Thread(() => displayMessage(label4, "..."));
            thread.Start();
        }
    }
}
