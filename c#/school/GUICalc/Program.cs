using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace GUICalc
{

    public class MyForm : Form
    {
       
        TextBox output;
        TextBox input;

        //Buttons
        Button[] numPad = new Button[10];
        Button[] opps = new Button[12];

        Calculator calculator = new Calculator();
        string[] tests = new string[] {"12+10", "12+++--++10", ")()()()()()()()()()(", "(@)#$*)(@#*$)@(&#$*)@(#&$*)(@*$#","23+(3)^2(34-23)" };
        List<string> testResult = new List<string>{ };

        public MyForm()
        {
          InitComponents();                      
        }

        private void InitComponents()
        {
            this.Width = 300;
            this.Height = 400;
                     
            //Output            
            output = new TextBox();
            output.TabIndex = 2;
            output.ReadOnly = true;     
            output.Size = new Size(196, 50);
            output.Location = new Point(4, 4);
            output.Multiline = true;
            output.ScrollBars = ScrollBars.Vertical;
            
            //Input            
            input = new TextBox();
            input.TabIndex = 1;
            input.Size = new Size(196, 30);            
            input.Location = new Point(4, 60 );
            input.KeyDown += Entersend;
                     
            Controls.Add(output);
            Controls.Add(input);
            NumPadCreation();
            OppsCreation();
            
            this.Load += LoadForm;           
        }

        private void LoadForm(object sender, EventArgs e)
        {
            this.input.Focus();
        }

        private void OppsCreation()
        {

            for(int i = 0; i < opps.Length; i++)
            {
                opps[i] = new Button();
                opps[i].Font = new Font("Times", 10);
                opps[i].Size = new Size(50, 25);
                opps[i].TextAlign = ContentAlignment.MiddleCenter;
                opps[i].Click += NumPadSend;
                Controls.Add(opps[i]);
            }
            
            opps[0].Text = ".";
            opps[0].Location = new Point(52 + 4, 190+30);
            
            opps[1].Text = "=";            
            opps[1].Location = new Point(52*2 + 4, 190+30);      
           
            opps[2].Text = "+";           
            opps[2].Location = new Point(52*3 + 4, 190+30); 
            
            opps[3].Text = "-";
            opps[3].Location = new Point(52 * 3 + 4, 160+30);

            opps[4].Text = "×";
            opps[4].Location = new Point(52 * 3 + 4, 130+30);

            opps[5].Text = "÷";
            opps[5].Location = new Point(52 * 3 + 4, 100+30);

            opps[6].Text = "Ans";
            opps[6].Location = new Point(4, 220+30);

            opps[7].Text = "Calc";
            opps[7].Location = new Point(52 + 4, 250);
            opps[7].Click -= NumPadSend;
            opps[7].Click += CalcSend;

            opps[8].Text = "^";
            opps[8].Location = new Point(52 * 4 + 4, 100+30);

            opps[9].Text = "(";
            opps[9].Location = new Point(4, 100);

            opps[10].Text = ")";
            opps[10].Location = new Point(56, 100);
           
            opps[10].Text = ")";
            opps[10].Location = new Point(56, 100);

            opps[11].Text = "\u03C0";
            opps[11].Location = new Point(52*2+4, 250);

        }
        private void NumPadCreation()
        {
            for(int i = 0; i < 9; i++)
            {
                float y = 30 * i;
                y = y % 29;
                y = MathF.Floor(y / 3);
                y = 190-y * 30;
                int x = i % 3;
                x = x * 52+4;
                numPad[i] = new Button();
                numPad[i].Text = (i+1).ToString();
                numPad[i].Font = new Font("Times", 10);
                numPad[i].Size = new Size(50, 25);
                numPad[i].Location = new Point(x, (int)y);
                numPad[i].TextAlign = ContentAlignment.MiddleCenter;
                numPad[i].Click += NumPadSend;
                numPad[i].TabIndex = i+5;
                Controls.Add(numPad[i]);
                

            }

            numPad[9] = new Button();
            numPad[9].Text = "0";
            numPad[9].Font = new Font("Times", 10);
            numPad[9].Size = new Size(50, 25);
            numPad[9].Location = new Point(4, 160+30+30);
            numPad[9].TextAlign = ContentAlignment.MiddleCenter;
            numPad[9].Click += NumPadSend;
            Controls.Add(numPad[9]);         
        }

        

        private void NumPadSend(object sender, EventArgs e)
        {
            input.Focus();
            Button button = (Button)sender;
            var cursorPos = input.SelectionStart;
            input.Text = input.Text.Insert(input.SelectionStart,button.Text);
            input.SelectionStart = cursorPos+1;
        }

        void Entersend(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RecieveInput();
            }
        }
        void CalcSend(object sender, EventArgs e)
        {
            input.Focus();
            RecieveInput();
        }

        void RecieveInput()
        {
                string result = calculator.Calculate(input.Text);

                if (input.Text == "")
                {
                    return;
                }
                output.AppendText("\r\n"+input.Text+"\r\n= "+result);
                input.Text = "";
        }

    }


    public static class Program
    {
        // Switches us to a single-threaded apartment model
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
            
        }
    }
}