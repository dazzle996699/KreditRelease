using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class FristUserControl : UserControl
    {
        float MonthPercent=0;
        float Ostatok = 0;
        float MonthPay=0;
        float PogashProcent=0;
        float TeloKredita=0;

        public FristUserControl()
        {
            InitializeComponent();
        }

        string testc;

        private void MonthPay_Click(object sender, EventArgs e)
        {
            MonthPercent = Convert.ToSingle(tB_Proc.Text)/100/12;
           // MessageBox.Show((MonthPercent).ToString());
            testc = "Ежемесячная процентная ставка: " + MonthPercent + "\n";
            MonthPayPercent_click(MonthPercent);

        }

        private void MonthPayPercent_click(float MonthPercent)
        {
            MonthPay = Convert.ToSingle(tB_SummCred.Text) * (MonthPercent + (MonthPercent / Convert.ToSingle((Math.Pow(1 + MonthPercent, Convert.ToSingle(tB_Mouth.Text)) - 1))));
            testc += "Ежемесячная аннуитетный платеж:" + Math.Round(MonthPay,2) + "\n";
            testc += "Номер месяца | " + "Размер платежа | " + "Сумма процентов | " + "Сумма погашения основного долга | " + "Остаток долга " + "\n";

            Ostatok = Convert.ToSingle(tB_SummCred.Text);

            for (float MonthNumber = 1; MonthNumber <= Convert.ToSingle(tB_Mouth.Text); MonthNumber++)
            {
                PogashProcent = Ostatok * MonthPercent;
                TeloKredita = (((MonthPay * MonthNumber) - PogashProcent) - (MonthPay * (MonthNumber - 1)));
                Ostatok = Ostatok - TeloKredita;

                testc += MonthNumber + " | "+ MonthPay + " | " + PogashProcent + " | " + TeloKredita + " | " + Ostatok + "\n";
            }

            Lb_Result.Text = testc;
        }

        private void Lb_sum_Click(object sender, EventArgs e)
        {

        }

        private void tB_SummCred_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lb_Proc_Click(object sender, EventArgs e)
        {

        }

        private void tB_Proc_TextChanged(object sender, EventArgs e)
        {

        }

        private void FristUserControl_Load(object sender, EventArgs e)
        {

        }

        private void Lb_mouth_Click(object sender, EventArgs e)
        {

        }

        private void tB_Mouth_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
