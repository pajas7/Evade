using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evade_Gui
{
    public partial class NastaveniHry : Form
    {

        public VyberObtiznosti Hrac1Obtiznost;
        public VyberObtiznosti Hrac2Obtiznost;
        public bool novaHra = false;
        public bool startAplikace = true;
        public NastaveniHry()
        {
            InitializeComponent();
            Invalidate();
            ZmenaNastaveniHry+= InicializaceDelegata;
    }
        public delegate void DelegatHraNastavena(VyberObtiznosti Hrac1, VyberObtiznosti Hrac2);
        public event DelegatHraNastavena ZmenaNastaveniHry;


        private void radioBtnCernaPocitac_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCernaPocitac.Checked)
            {
                radioBtnCernyLehka.Enabled = true;
                radioBtnCernyStredni.Enabled = true;
                radioBtnCernyTezka.Enabled = true;
            }
            else
            {
                radioBtnCernyLehka.Enabled = false;
                radioBtnCernyStredni.Enabled = false;
                radioBtnCernyTezka.Enabled = false;
                
            }
            //ZmenaNastaveniHry(Hrac1Obtiznost, Hrac2Obtiznost);
        }
        private void InicializaceDelegata(VyberObtiznosti Hrac,VyberObtiznosti Hrac2)
        {
        }
        private void radioBtnPocitacBila_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnPocitacBila.Checked)
            {
                radioBtnBilaLehka.Enabled = true;
                radioBtnBilaStredni.Enabled = true;
                radioBtnBilaTezka.Enabled = true;
            }
            else
            {
                radioBtnBilaLehka.Enabled = false;
                radioBtnBilaStredni.Enabled = false;
                radioBtnBilaTezka.Enabled = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (radioBtnBilaHrac.Checked)
            {
                Hrac1Obtiznost = VyberObtiznosti.Hrac;
               
            }
            else if (radioBtnPocitacBila.Checked)
            {
                if (radioBtnBilaLehka.Checked)
                {
                    Hrac1Obtiznost = VyberObtiznosti.PocitacLehka;
                  
                }
                else if (radioBtnBilaStredni.Checked)
                {
                    Hrac1Obtiznost =  VyberObtiznosti.PocitacStredni;
                }
                else
                {
                    Hrac1Obtiznost = VyberObtiznosti.PocitacTezka;
                }
            }
            if (radioBtnCernaHrac.Checked)
            {
                Hrac2Obtiznost = VyberObtiznosti.Hrac;

            }
            else if (radioBtnCernaPocitac.Checked)
            {
                if (radioBtnCernyLehka.Checked)
                {
                    Hrac2Obtiznost = VyberObtiznosti.PocitacLehka;
                }
                else if (radioBtnCernyStredni.Checked)
                {
                    Hrac2Obtiznost = VyberObtiznosti.PocitacStredni;
                }
                else
                {
                    Hrac2Obtiznost = VyberObtiznosti.PocitacTezka;
                }
            }

                ZmenaNastaveniHry(Hrac1Obtiznost, Hrac2Obtiznost);
            this.Close();
        }
        public void ZapnutibtnStorno()
        {
            btnStorno.Enabled = true;
        }
        private void btnStorno_Click(object sender, EventArgs e)
        {
            this.novaHra = false;
            this.Close();
        }

    }
}
