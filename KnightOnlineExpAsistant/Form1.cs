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
            if (string.IsNullOrEmpty(tbxGerekenToplamExp.Text) && string.IsNullOrEmpty(tbxGelenExp.Text) && string.IsNullOrEmpty(tbxDakikadaKesilenMob.Text))
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxGerekenToplamExp.Focus();
            }
            else if (string.IsNullOrEmpty(tbxGerekenToplamExp.Text))
            {
                MessageBox.Show("Lütfen Gereken Toplam Exp Alanını Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxGerekenToplamExp.Focus();
            }
            else if (tbxGelenExp.Text == "")
            {
                MessageBox.Show("Lütfen Gelen Exp Alanını Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxGelenExp.Focus();
            }
            else if (tbxDakikadaKesilenMob.Text == "")
            {
                MessageBox.Show("Lütfen Dakikada Kesilen Mob Alanını Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxDakikadaKesilenMob.Focus();
            }
            else if (!Int64.TryParse(tbxGerekenToplamExp.Text, out long result))
            {

                if (tbxGerekenToplamExp.Text.Length>18)
                {
                    MessageBox.Show("Çok fazla rakam yazıldı!", "Hata", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Lütfen giriniz!", "Hata", MessageBoxButtons.OK);
                 
                }
                tbxGerekenToplamExp.Focus();
            }
            else if (!Int32.TryParse(tbxGelenExp.Text, out int result2))
            {
               
                MessageBox.Show("Lütfen sadece sayı giriniz!", "Hata", MessageBoxButtons.OK);
                tbxGelenExp.Focus();
            }
            else if (!double.TryParse(tbxDakikadaKesilenMob.Text, out double result3))
            {

                MessageBox.Show("Lütfen sadece ondalıklı sayı giriniz!", "Hata", MessageBoxButtons.OK);
                tbxDakikadaKesilenMob.Focus();
            }
            else
            {
                ExpCalc();
            }


        }

        private void ExpCalc()
        {
            double gunlukToplamExp, saatlikExpYuzde, gunlukExpYuzde, gelenExp, kesilenMob, gerekenExp;

            gerekenExp = Convert.ToDouble(tbxGerekenToplamExp.Text);
            gelenExp = Convert.ToDouble(tbxGelenExp.Text);
            kesilenMob = Convert.ToDouble(tbxDakikadaKesilenMob.Text);

            gunlukToplamExp = kesilenMob * 1440 * gelenExp;
            tbx24SaatlikTotalExp.Text = gunlukToplamExp.ToString("0,000");

            saatlikExpYuzde = (gunlukToplamExp / 24) * 100 / gerekenExp;
            tbxSaatlikExpYuzde.Text = saatlikExpYuzde.ToString("00.##") + " %";

            gunlukExpYuzde = gunlukToplamExp * 100 / gerekenExp;
            tbx24SaatlikExpYuzde.Text = gunlukExpYuzde.ToString("00.##") + " %";
        }

        private void tbxGerekenToplamExp_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbxGelenExp_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbxDakikadaKesilenMob_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sadece harf ve virgül girebilir
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
    }
}
