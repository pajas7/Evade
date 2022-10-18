using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Evade_Gui
{


    class Hra
    {
        public delegate void delegatHracNaRade(Hrac Hrac);
        public event delegatHracNaRade HracNaRade;

        public delegate void delegatZmenaHraceText(string BarvaHrace);
        public event delegatZmenaHraceText VymenaHraceText;



        public delegate void DelegatPocitacProvedlTah(int[] startTah,int[] cilTah, Hrac hrac);
        public event DelegatPocitacProvedlTah PocitacProvedTah;

        public delegate void DelegatHraUkoncena();
        public event DelegatHraUkoncena HraUkoncena;

        public VyberObtiznosti ObtiznostHrac1;
        public VyberObtiznosti ObtiznostHrac2;
        private int PruchodyMinimax;
        public Hrac Hrajicihrac;

        public StavHry StavHry;

        //private Sachovnice sachovnice = new Sachovnice();

        Sachovnice sachovnice;
        public Hra(Sachovnice Sachovnice)
        {
            sachovnice = Sachovnice;
            HracNaRade += InicializaceHrace;
            VymenaHraceText += InicializaceText;
            PocitacProvedTah += InicializacePocitace;
            HraUkoncena += InicializaceHraUkonce;
        }
        private void InicializaceHrace(Hrac hrac)
        {

        }
        private void InicializaceText(string text)
        {

        }
        private void InicializacePocitace(int[] STah,int[] CTah, Hrac hrac)
        {

        }
        private void InicializaceHraUkonce()
        {

        }


        public void HracNaradePrepnuti()
        {

            if (Hrajicihrac == Hrac.BilyHrac)
            {
                Hrajicihrac = Hrac.CernyHrac;
                HracNaRade(Hrac.CernyHrac);
                VymenaHraceText("Hraje Černý Hráč");
            }
            else
            {
                Hrajicihrac = Hrac.BilyHrac;
                HracNaRade(Hrac.BilyHrac);
                VymenaHraceText("Hraje Bílý Hráč");
            }
            StavHry = sachovnice.OvereniKonce(Hrajicihrac); // po prepnuti zjisti jestli doslo ke konci hry(kvuli minimaxu je prohozeno overeni hrace)
            KonecHry();
        }
        public void worker_minimaxPC_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker_minimax = sender as BackgroundWorker;

        }
        public void KonecHry()
        {
            StavHry = sachovnice.OvereniKonce(Hrajicihrac);
            if (StavHry == StavHry.VyhraCernyHrac)
            {
                HraUkoncena();
                MessageBox.Show("Vyhravá Černý hráč", "Konec hry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (StavHry == StavHry.VyhraBilyHrac)
            {
                HraUkoncena();
                MessageBox.Show("Vyhravá Bilý hráč", "Konec hry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (StavHry == StavHry.Remiza)
            {
                HraUkoncena();
                MessageBox.Show("Remíza", "Konec hry", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public int[,] NejtahHrac(BackgroundWorker worker, DoWorkEventArgs e)
        {



            int[,] NejTah = NejlepsiTah(Hrajicihrac, 4,worker,e);

            int[] StartXY = new int[2], CilXY = new int[2];
           
            //    worker_minimax.ReportProgress(percentComplete);


            for (int i = 0; i < 2; i++)
            {
                StartXY[i] = NejTah[0, i];
                CilXY[i] = NejTah[1, i];
            }
            return NejTah;
        }

        public void VyberPocitace(BackgroundWorker worker, DoWorkEventArgs e)
        {
            int Hloubka;
            int[,] FigurkyXY;
                if(ObtiznostHrac1 == VyberObtiznosti.PocitacLehka||
                ObtiznostHrac2 == VyberObtiznosti.PocitacLehka)
            {
                Hloubka = 0;
            }
                else if (ObtiznostHrac1 == VyberObtiznosti.PocitacStredni||
               ObtiznostHrac2 == VyberObtiznosti.PocitacStredni)
            {
                Hloubka = 2;
            }
            else
            {
                Hloubka = 4;
            }
            if(Hrajicihrac == Hrac.BilyHrac)
            {
                FigurkyXY = sachovnice.PoziceBilychFigurekXYZ;
            }
            else
            {
                FigurkyXY = sachovnice.PoziceCernychFigurekXYZ;
            }
            int[,] NejTah = NejlepsiTah(Hrajicihrac, Hloubka, worker,e);
            int[] StartXY = new int[4], CilXY = new int[2];
            for (int i = 0; i < 2; i++)
            {
                StartXY[i] = NejTah[0, i];
                CilXY[i] = NejTah[1, i];
            }
            for(int i = 0; i<6; i++)
            {
                if (StartXY[0] == FigurkyXY[i,0] &&
                    StartXY[1] == FigurkyXY[i, 1])
                {

                    StartXY[2] = FigurkyXY[i, 2];
                    StartXY[3] = FigurkyXY[i, 3];
                    break;
                }
            }//kvuli ulozeni hry
            
            PocitacProvedTah(StartXY, CilXY, Hrajicihrac);
            sachovnice.PohybFigurkou(StartXY, CilXY, Hrajicihrac);

        }


        public int[,] NejlepsiTah(Hrac Hrac, int Hloubka, BackgroundWorker worker, DoWorkEventArgs e)
        {
            PruchodyMinimax = 0;
            int percentComplete;
            //pro uchovani aktualni pozice
            double NejlepsiOhodnoceni = double.NegativeInfinity;
            int[,] NejPoziceXY = new int[2, 2]; //odkudX=[0,0] odkudY=[0,1] kamX=[1,0] kamY=[1,1]
            int[] PotomekXY = new int[2];
            //zacatek nastaveni hrace pro generovani tahu
            int[,] PoziceFigurekXY; //ulozeni aktualnich pozic figurek
            Hrac Souper;
            double ProgressBarProcenta = 3.2;
            for(int i = 1;i<Hloubka; i++)
            {
                ProgressBarProcenta *= 25;// 25 je +- pruměr 40+- je max 16 min (moznosti tahu za pruchod podle rozmisteni figurek mini)
            }

            if (Hrac == Hrac.BilyHrac)
            { // nastaveni promenych na hodnoty barvy hrace
                PoziceFigurekXY = sachovnice.PoziceBilychFigurekXYZ;
                Souper = Hrac.CernyHrac;
            }
            else
            {
                PoziceFigurekXY = sachovnice.PoziceCernychFigurekXYZ;
                Souper = Hrac.BilyHrac;
            }
            int[] FigurkaXY = new int[4];
            double Skore = 0;
            for (int i = 0; i < 6; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {


                    for (int v = 0; v < 4; v++)
                    {
                        FigurkaXY[v] = PoziceFigurekXY[i, v];
                    }
                    sachovnice.MozneSkoky = 0;
                    int[,] SouradniceSkokuYX = sachovnice.GeneratorTahu(FigurkaXY, Hrac);
                    int MozneSkokyMinimax = sachovnice.MozneSkoky;
                    for (int j = 0; j < MozneSkokyMinimax; j++)
                    {
                        PotomekXY[0] = SouradniceSkokuYX[j, 0];
                        PotomekXY[1] = SouradniceSkokuYX[j, 1];
                        sachovnice.PohybFigurkou(FigurkaXY, PotomekXY, Hrac);
                        Skore = Minimax(Hloubka, Souper, Souper, worker,  e);
                        
                        percentComplete = (int)((float)PruchodyMinimax) / (int)((float)ProgressBarProcenta);
                        if (percentComplete > 100)
                        {
                            percentComplete = 100;
                        }
                        worker.ReportProgress(percentComplete);
                        sachovnice.PohybFigurkouZpet(FigurkaXY, PotomekXY, Hrac);
                        if (Skore >= NejlepsiOhodnoceni)//= pro pripad kdy pocita predem prohranou partii(jinak nedostane souradnice)
                        {
                            NejlepsiOhodnoceni = Skore;
                            NejPoziceXY[0, 0] = FigurkaXY[0];
                            NejPoziceXY[0, 1] = FigurkaXY[1];
                            NejPoziceXY[1, 0] = PotomekXY[0];
                            NejPoziceXY[1, 1] = PotomekXY[1];
                        }
                    }
                }
                
            }
            return NejPoziceXY;
        }

        private double Ohodnoceni(Hrac Hrac, Hrac Souper)
        {
            double SkokKrale = 25;
            double Ohodnoceni = 0;
            //prohozeni hrace kvuli ohodnoceni posledniho tahu (momentalni hrac neni posledni hrajici)
            int[,] FigurkyHrace;
            int[,] FigurkySoupere;
            Hrac ProhozeniHrace;
            if (Hrac == Hrac.BilyHrac)
            {
                ProhozeniHrace = Hrac.CernyHrac;
                FigurkyHrace = sachovnice.PoziceCernychFigurekXYZ;
                FigurkySoupere = sachovnice.PoziceBilychFigurekXYZ;
            }
            else
            {
                ProhozeniHrace = Hrac.BilyHrac;
                FigurkyHrace = sachovnice.PoziceBilychFigurekXYZ;
                FigurkySoupere = sachovnice.PoziceCernychFigurekXYZ;
            }

            for (int i = 0; i < 6; i++)
            {
                if (FigurkyHrace[i, 2] == Sachovnice.ZmrazenaFigurka &&
                    FigurkyHrace[i, 3] == Sachovnice.Kral)
                {
                    Ohodnoceni -= SkokKrale;
                }
                if (Hrac.BilyHrac == ProhozeniHrace)
                {
                    for (int y = 0; y < 6; y++)
                    {

                        if (FigurkyHrace[i, 1] == y)
                        {
                            Ohodnoceni += y;
                        }
                    }
                }
                else
                {
                    int hodnota = 0;
                    for (int y = 6; y > 0; y--)
                    {

                        if (FigurkyHrace[i, 1] == y)
                        {
                            Ohodnoceni += hodnota;
                            
                        }
                        hodnota++;
                    }
                }
                }
                
            
            for (int i = 0; i < 6; i++)
            {
                if (FigurkySoupere[i, 1] == Sachovnice.ZmrazenaFigurka &&
                    FigurkySoupere[i, 3] == Sachovnice.Kral)
                {
                    Ohodnoceni += SkokKrale;
                }
            }

                return Ohodnoceni;
            
        }




        private double Minimax(int Hloubka, Hrac Hrac, Hrac Souper, BackgroundWorker worker, DoWorkEventArgs e)//bez aktualni pozice na sachovnici automaticky se prochazi aktualni pozice
        {

            PruchodyMinimax++;
            StavHry StavHryMinimax = sachovnice.OvereniKonce(Hrac);
            if (StavHryMinimax == StavHry.VyhraBilyHrac && Hrac == Souper ||
                StavHryMinimax == StavHry.VyhraCernyHrac && Hrac == Souper)
            {

                return double.PositiveInfinity;
            }

            if (StavHryMinimax == StavHry.VyhraBilyHrac && Hrac != Souper ||
                StavHryMinimax == StavHry.VyhraCernyHrac && Hrac != Souper)
            {
                return double.NegativeInfinity;
            }

            if (StavHryMinimax == StavHry.Remiza)
            {
                return 0;
            }
            if (worker.CancellationPending)
            {
                return Ohodnoceni(Hrac, Souper);
            }
            if (Hloubka == 0)
            {
                return Ohodnoceni(Hrac, Souper);
            }
            int[] PotomekXY = new int[2];
            //zacatek nastaveni hrace pro generovani tahu
            int[,] PoziceFigurekXY;
            int[] figurkaXY = new int[4];

            if (Hrac == Hrac.BilyHrac)
            { // nastaveni promenych na hodnoty barvy hrace
                PoziceFigurekXY = sachovnice.PoziceBilychFigurekXYZ;
            }
            else
            {
                PoziceFigurekXY = sachovnice.PoziceCernychFigurekXYZ;
            }

            if (Hrac != Souper) // maximalizujici hrac na tahu
            {

                double NejlepsiOhodnoceni = double.NegativeInfinity;
                for (int i = 0; i < 6; i++)
                {
                    for (int v = 0; v < 4; v++)
                    {
                        figurkaXY[v] = PoziceFigurekXY[i, v];
                    }
                    sachovnice.MozneSkoky = 0;
                    int[,] SouradniceSkokuYX = sachovnice.GeneratorTahu(figurkaXY, Hrac);
                    int MozneSkokyMinimax = sachovnice.MozneSkoky;
                    for (int j = 0; j < MozneSkokyMinimax; j++)
                    {
                        PotomekXY[0] = SouradniceSkokuYX[j, 0];
                        PotomekXY[1] = SouradniceSkokuYX[j, 1];
                        sachovnice.PohybFigurkou(figurkaXY, PotomekXY, Hrac);
                        double Skore = Minimax(Hloubka - 1, Souper, Souper,worker,  e);
                        sachovnice.PohybFigurkouZpet(figurkaXY, PotomekXY, Hrac);
                        NejlepsiOhodnoceni = Math.Max(Skore, NejlepsiOhodnoceni);
                    }

                }
                return NejlepsiOhodnoceni;
            }
            else // minimalizujici hrac na tahu
            {
                Hrac VymenaHrace;
                if (Souper == Hrac.BilyHrac)
                {
                    VymenaHrace = Hrac.CernyHrac;
                }
                else
                {
                    VymenaHrace = Hrac.BilyHrac;
                }

                double NejlepsiOhodnoceni = double.PositiveInfinity;

                for (int i = 0; i < 6; i++)
                {
                    for (int v = 0; v < 4; v++)
                    {
                        figurkaXY[v] = PoziceFigurekXY[i, v];
                    }
                    sachovnice.MozneSkoky = 0;
                    int[,] SouradniceSkokuYX = sachovnice.GeneratorTahu(figurkaXY, Hrac);
                    int MozneSkokyMinimax = sachovnice.MozneSkoky;
                    for (int j = 0; j < MozneSkokyMinimax; j++)
                    {
                        PotomekXY[0] = SouradniceSkokuYX[j, 0];
                        PotomekXY[1] = SouradniceSkokuYX[j, 1];
                        sachovnice.PohybFigurkou(figurkaXY, PotomekXY, Hrac);
                        double Skore = Minimax(Hloubka - 1, VymenaHrace, Souper, worker, e);
                        sachovnice.PohybFigurkouZpet(figurkaXY, PotomekXY, Hrac);
                        NejlepsiOhodnoceni = Math.Min(Skore, NejlepsiOhodnoceni);
                    }
                }
                return NejlepsiOhodnoceni;
            }
        }

    }
}



