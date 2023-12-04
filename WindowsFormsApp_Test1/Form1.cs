using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Test1
{
    public partial class Form1 : Form
    {
        private bool opFlag = false;
        private bool memFlag = false;
        private double saveValue;
        private double memory;
        private char op = '\0';

        public Form1()
        {
            InitializeComponent();
            //mc랑 mr버튼 비활성화
            btn_MC.Enabled = false;
            btn_MR.Enabled = false;
           

        }
        // 3자리마다 쉼표 삽입   
        private string commaProcedure(double v, string s)
        {
            int pos = 0;
            if (s.Contains("."))
            {
                pos = s.Length - s.IndexOf(".");    // 소수점 아래 자리수 + 1

                if (pos == 1)   // 맨 뒤에 소수점이 있으면 그대로 리턴
                { return s; }

                string formatStr = "{0:N" + (pos - 1) + "}";
                s = string.Format(formatStr, v);
            }
            else
            { s = string.Format("{0:N0}", v); }

            display_main.Text = s;
            return s;
        }
        
        // 숫자 버튼(btn0~btn9)을 클릭했을 때 처리하는 메소드
        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (display_main.Text == "0" || opFlag == true || memFlag == true)
            {
                display_main.Text = btn.Text;
                opFlag = false;
                memFlag = false;
            }
            else
                display_main.Text = display_main.Text + btn.Text;

            //3자리마다 콤마삽입
            double v = Double.Parse(display_main.Text);
            commaProcedure(v, display_main.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        // 소수점 버튼
        private void button27_Click(object sender, EventArgs e)
        {

            if (display_main.Text.Contains("."))
            { return; }
            else
            { display_main.Text += "."; }
            
        }

        //+/-버튼
        private void button25_Click(object sender, EventArgs e)
        {

            double v = Double.Parse(display_main.Text);
            display_main.Text = (-v).ToString();
            
        }
        //+버튼
        private void button24_Click(object sender, EventArgs e)
        {
            saveValue = Double.Parse(display_main.Text);
            display.Text = display_main.Text + " + ";
            op = '+';
            opFlag = true;
        }

        
        //-버튼
        private void button20_Click(object sender, EventArgs e)
        {
            saveValue = Double.Parse(display_main.Text);
            display.Text = display_main.Text + " - ";
            op = '-';
            opFlag = true;
        }
        //x버튼
        private void button16_Click(object sender, EventArgs e)
        {
            saveValue = Double.Parse(display_main.Text);
            display.Text = display_main.Text + " × ";
            op = '*';
            opFlag = true;
        }
        //÷버튼
        private void button12_Click(object sender, EventArgs e)
        {
            saveValue = Double.Parse(display_main.Text);
            display.Text = display_main.Text + " ÷ ";
            op = '/';
            opFlag = true;
        }
        // =버튼
        private void button28_Click(object sender, EventArgs e)
        {
            double v = Double.Parse(display_main.Text);
            switch (op)
            {
                case '+':
                    display_main.Text = (saveValue + v).ToString();
                    break;
                case '-':
                    display_main.Text = (saveValue - v).ToString();
                    break;
                case '*':
                    display_main.Text = (saveValue * v).ToString();
                    break;
                case '/':
                    display_main.Text = (saveValue / v).ToString();
                    break;
            }

            //3자리마다 콤마삽입
            v = Double.Parse(display_main.Text);
            commaProcedure(v, display_main.Text);


            display.Text = "";
        }
        //제곱근
        private void button11_Click(object sender, EventArgs e)
        {
            display.Text = "√(" + display_main.Text + ") ";
            display_main.Text = Math.Sqrt(Double.Parse(display_main.Text)).ToString();
        }
        //제곱
        private void button10_Click(object sender, EventArgs e)
        {
            display.Text = "sqr(" + display_main.Text + ") ";
            display_main.Text = (Double.Parse(display_main.Text) * Double.Parse(display_main.Text)).ToString();
        }
        //역수연산
        private void button9_Click(object sender, EventArgs e)
        {
            display.Text = "1 / (" + display_main.Text + ") ";
            display_main.Text = (1 / Double.Parse(display_main.Text)).ToString();
        }
        //ce 지금입력하고있는값을 0으로
        private void button6_Click(object sender, EventArgs e)
        {
            display_main.Text = "0";
        }


        //c 모두 초기화
        private void button7_Click(object sender, EventArgs e)
        {
            display_main.Text = "0";
            display.Text = "";
            saveValue = 0;
            op = '\0';
            opFlag = false;
        }
        //한글자 지우기
        private void button8_Click(object sender, EventArgs e)
        {
            display_main.Text = display_main.Text.Remove(display_main.Text.Length - 1);
            if (display_main.Text.Length == 0)
            { display_main.Text = "0"; }
        }
        //mc 버튼 (Memory Clear)
        private void btn_MC_Click(object sender, EventArgs e)
        {
            display_main.Text = "0";
            memory = 0;
            btn_MR.Enabled = false;
            btn_MC.Enabled = false;
        }
        //mr버튼 (Memory Read)
        private void btn_MR_Click(object sender, EventArgs e)
        {
            display_main.Text = memory.ToString();
            memFlag = true;
        }
        //m+버튼 
        private void button3_Click(object sender, EventArgs e)
        {
            memory += Double.Parse(display_main.Text);
        }
        //m-버튼 
        private void button4_Click(object sender, EventArgs e)
        {
            memory -= Double.Parse(display_main.Text);
        }
        //ms버튼 (Memory Save)
        private void button5_Click(object sender, EventArgs e)
        {
            memory = Double.Parse(display_main.Text);
            btn_MC.Enabled = true;
            btn_MR.Enabled = true;
            memFlag = true;
        }



        //------------------숫자버튼0-9-------------

        private void button13_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            btnNumber_Click(sender, e);
        }

        //--------------숫자버튼0-9 끝------------
    }
}
