using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightOnlineExpAsistant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double gunlukToplamExp, saatlikExpYuzde, gunlukExpYuzde, gelenExp, kesilenMob, gerekenExp;

            gerekenExp = Convert.ToDouble(tbxGerekenToplamExp.Text);
            gelenExp = Convert.ToDouble(tbxGelenExp.Text);
            kesilenMob = Convert.ToDouble(tbxDakikadaKesilenMob.Text);

            gunlukToplamExp = kesilenMob * 1440 * gelenExp;
            tbx24SaatlikTotalExp.Text=gunlukToplamExp.ToString("0,000");

            saatlikExpYuzde = (gunlukToplamExp/24)*100 / gerekenExp;
            tbxSaatlikExpYuzde.Text = saatlikExpYuzde.ToString("00.##") + " %";

            gunlukExpYuzde = gunlukToplamExp * 100 / gerekenExp;
            tbx24SaatlikExpYuzde.Text = gunlukExpYuzde.ToString("00.##") + " %";


        }
    }
}
