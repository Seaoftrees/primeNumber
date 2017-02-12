using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace primeNumbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //調べるボタンをクリックしたとき
        private void button1_Click(object sender, EventArgs e)
        {
            //入力された数字を取得
            ulong subject = (ulong)numericUpDown1.Value;

            //素数かどうかの判別
            Boolean notPrimeNumber = false;

            //ある数字で割り切れるときの値
            ulong pp = 0;

            //入力された値が2で割り切れないとき
            if (subject % 2 !=0)
            {
                //素数かどうか調べる 3, 5, 7....という風に割っていく(ただし、割る数字は入力された数字の平方根より少ない)
                for (ulong p = 3; p <= Math.Sqrt(subject); p += 2)
                {
                    //(入力された数字)÷(割る数)の余りが0のとき (つまり、割り切れるとき)
                    if (subject % p == 0)
                    {
                        //notPrimeNumberにtrueを代入して、処理を中断する
                        pp = p;
                        notPrimeNumber = true;
                        break;
                    }
                }
            }
            else //2で割り切れるとき
            {
                pp = 2;
                notPrimeNumber = true;
            }

            //もし、for処理の中で割り切れる数字があったとき(=notPrimeNumberにtrueが代入されているとき)
            if (notPrimeNumber)
            {
                //つまり、素数でないとき
                label3.Text = "結果: 入力された数字は「素数ではありません！」( " + pp.ToString() + " で割り切れます)";
            }
            else if(subject == 1)   //そうでない場合に入力された数字が 1 のとき
            {
                label3.Text = "結果: 入力された数字は「素数ではありません！」(1はそもそも素数じゃないよ)";
            }
            else  //上のどれでもないとき (=素数のとき)
            {
                label3.Text = "結果: 入力された数字は「素数です！」";
            }
        }
    }
}
