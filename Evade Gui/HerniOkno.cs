using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.IO;

namespace Evade_Gui
{
    enum StavHry
    {
        Probiha,
        VyhraCernyHrac, VyhraBilyHrac, Remiza
    }
 
    public enum VyberObtiznosti
    {
        Hrac,
        PocitacLehka,
        PocitacStredni,
        PocitacTezka,
    }
    public enum Hrac
    {
        BilyHrac, CernyHrac
    }
    public partial class HerniOkno : Form
    {
        NastaveniHry nastaveniHry = new NastaveniHry();
        Sachovnice sachovnice;
        Hra hra;
        public static Color BarvaBileFigurky = Color.White;
        public static Color BarvaCerneFigurky = Color.Black;
        Pen BarvaSachovnice = new Pen(Color.Black, 3);
        Pravidla pravidla = new Pravidla();
        Ovladani ovladani = new Ovladani();
        Figurka[] BileFigurky;
        Figurka[] CerneFigurky;
        VykresleniTahu VybranaFigurka;
        VykresleniTahu[] MozneTahy;
        ZmrazenePolicko[] ZmrazenaFigurka;
        int[] VybranaFigurkaXY;
        private int[,] MozneSkokyXY;
        private int MozneSkokyPocet;
        private int[] PoziceFigurekVykresleniX = new int[6];
        private int[] PoziceFigurekVykresleniY = new int[6];
        Hrac hracNaRade;
        private int[,] NejTahHrace;
        private bool VykresliNejTah;
        private int VyberUndoReduListu;
        private List<int[]> OdehranyTah;
        private List<Hrac> KdoOdehralTah;
        private bool UndoRedu;//uklada zda bylo provedeno undoredu pro vymazani vypisu
        private int intervalPosunuPocitace = 750;
        private bool PocitacOdehral; //pro prepinani pocitace aby nebyl ve smycce
        private bool KonecHryUlozeni;
        private bool VypocetPocitace;
        Timer CasovaniPocitace = new Timer();

        public HerniOkno()
        {
            InitializeComponent();
            UrceniSouradnicVykresleni(); // pro vykresleni figurek v hracim poli
            nastaveniHry.ShowDialog(); // vyvola nastaveni hry pri startu aplikace
            NovaHra(); // vytvori novou hru
            //SachovniceCanvas.Paint += VykresleniSachovnice; 
            /*
            nastaveniHry.ZmenaNastaveniHry += ZmenaHrace; // vyvola se v pripade zmeny nastaveni za chodu a nejde o novou hru
            hra.VymenaHraceText += ZmenaInfoHrac; // stara se vypis hrace v okne (vlevo dole)
            nastaveniHry.ZapnutibtnStorno(); // zapina az pri spustene hre kvuli prvotnimu nastaveni hry
            hra.HracNaRade += HrajiciHrac; // prohazovani hracu za chodu
            CasovaniPocitace.Tick += PohybPocitace;
            hra.PocitacProvedTah += UlozeniPozicePocitace;
            */
        }
        private void PrvotniNastaveniHodnot()
        {
            UndoRedu = false;
            VykresliNejTah = false;
            MozneSkokyPocet = 0;
            MozneTahy = new VykresleniTahu[8];
            ZmrazenaFigurka = new ZmrazenePolicko[6];
            CerneFigurky = new Figurka[6];
            BileFigurky = new Figurka[6];
            VybranaFigurkaXY = new int[4];
            MozneSkokyXY = new int[8, 4];
            OdehranyTah = new List<int[]>();
            KdoOdehralTah = new List<Hrac>();
            sachovnice = new Sachovnice();
            hra = new Hra(sachovnice);
            hracNaRade = Hrac.BilyHrac;
            PocitacOdehral = false;
            KonecHryUlozeni = false;
        }// prvni nastaveni hodnot / vynulovani hodnot pro novou hru
        private void NovaHra()
        {

            if (nastaveniHry.novaHra)
            {


                PrvotniNastaveniHodnot();
                ZmenaHrace(nastaveniHry.Hrac1Obtiznost, nastaveniHry.Hrac2Obtiznost); // pro prvotni nastaveni pri startu hry

                nastaveniHry.novaHra = false;
                ZmenaInfoHrac("Hraje Bílý Hráč");//opravit (prvni hraje vzdy b hrac)
                ObtiznostInfo(); // pro vypis typu hry dole uprostred
                SachovniceCanvas.Invalidate();
                VypsaniOdehranychTahu();
                SachovniceCanvas.Enabled = true;
                nastaveniHry.ZmenaNastaveniHry += ZmenaHrace;
                hra.HracNaRade += HrajiciHrac;
                hra.VymenaHraceText += ZmenaInfoHrac;
                hra.PocitacProvedTah += UlozeniPozicePocitace;
                hra.HraUkoncena += KonecHry;
                CasovaniPocitace.Tick += PohybPocitace;

            }
            if (nastaveniHry.startAplikace)
            {
                PrvotniNastaveniHodnot();
                ZmenaHrace(nastaveniHry.Hrac1Obtiznost, nastaveniHry.Hrac2Obtiznost);

                nastaveniHry.startAplikace = false;
                ZmenaInfoHrac("Hraje Bílý Hráč"); //opravit (prvni hraje vzdy b hrac)
                ObtiznostInfo(); // pro vypis typu hry dole uprostred

                SachovniceCanvas.Enabled = true;
                nastaveniHry.ZmenaNastaveniHry += ZmenaHrace; // vyvola se v pripade zmeny nastaveni za chodu a nejde o novou hru
                hra.VymenaHraceText += ZmenaInfoHrac; // stara se vypis hrace v okne (vlevo dole)

                nastaveniHry.ZapnutibtnStorno(); // zapina az pri spustene hre kvuli prvotnimu nastaveni hry
                hra.HracNaRade += HrajiciHrac; // prohazovani hracu za chodu
                CasovaniPocitace.Tick += PohybPocitace;
                hra.PocitacProvedTah += UlozeniPozicePocitace;
                hra.HraUkoncena += KonecHry;
            }


        }
        #region Tridy Figurek a tahu pro vykresleni
        public class ZmrazenePolicko
        {
            static int VFigurky = 70;
            Rectangle VnitrekFigurky = new Rectangle(0, 0, VFigurky, VFigurky);
            float[] FactorVykresleni = { .0f, .0f, 1f, 1f };
            float[] PoziceVykresleni = { .0f, .5f, .5f, 1.0f };

            Blend MixBarevZmrazeni = new Blend();


            public ZmrazenePolicko(int X, int Y)
            {
                VnitrekFigurky.X = X;
                VnitrekFigurky.Y = Y;
            }

            public void Vykresli(Graphics Grafika)
            {
                MixBarevZmrazeni.Factors = FactorVykresleni;
                MixBarevZmrazeni.Positions = PoziceVykresleni;

                LinearGradientBrush ZmrazenePolicko = new LinearGradientBrush(VnitrekFigurky, Color.White, Color.Black, LinearGradientMode.Horizontal);
                ZmrazenePolicko.Blend = MixBarevZmrazeni;

                Grafika.FillEllipse(ZmrazenePolicko, VnitrekFigurky);

            }
            public bool SouradniceKliknuti(MouseEventArgs e)
            {
                return VnitrekFigurky.Contains(e.Location);
            }
        }
        public class VykresleniTahu
        {
            static int VFigurky = 70;
            Rectangle VnitrekFigurky = new Rectangle(0, 0, VFigurky, VFigurky);
            Pen BarvaOhraniceni;
            public VykresleniTahu(int X, int Y, Color Barva)
            {
                VnitrekFigurky.X = X;
                VnitrekFigurky.Y = Y;
                BarvaOhraniceni = new Pen(Barva, 5);
            }
            public void Vykresli(Graphics Grafika)
            {
                Grafika.DrawEllipse(BarvaOhraniceni, VnitrekFigurky);
            }
            public bool SouradniceKliknuti(MouseEventArgs e)
            {
                return VnitrekFigurky.Contains(e.Location);
            }

        }
        public class Figurka
        {
            static int VFigurky = 70;
            static int VKrale = 50;
            Rectangle VnitrekFigurky = new Rectangle(0, 0, VFigurky, VFigurky);
            Rectangle OznaceniKrale = new Rectangle(0, 0, VKrale, VKrale);
            Brush BarvaFigurky;
            Pen BarvaVnitrnihoKruhu = new Pen(Color.Gray, 5);
            int figurka;
            public Figurka(int X, int Y, Color Barva, int Figurka)
            {
                VnitrekFigurky.X = X;
                VnitrekFigurky.Y = Y;
                OznaceniKrale.X = X + 10;
                OznaceniKrale.Y = Y + 10;
                BarvaFigurky = new SolidBrush(Barva);
                figurka = Figurka;
            }

            public void Vykresli(Graphics Grafika)
            {
                if (figurka == Sachovnice.Kral)
                {
                    OznaceniKrale.X = VnitrekFigurky.X + 10;
                    OznaceniKrale.Y = VnitrekFigurky.Y + 10;
                    Grafika.FillEllipse(BarvaFigurky, VnitrekFigurky);
                    Grafika.DrawEllipse(BarvaVnitrnihoKruhu, OznaceniKrale);
                }
                else
                {
                    Grafika.FillEllipse(BarvaFigurky, VnitrekFigurky);
                }
            }
            public bool SouradniceKliknuti(MouseEventArgs e)
            {
                return VnitrekFigurky.Contains(e.Location);
            }
        }
        #endregion


        private void HrajiciHrac(Hrac hrac)
        {
            hracNaRade = hrac;
        }// prepnuti hrace po provedeni tahu
        public void ZmenaHrace(VyberObtiznosti Obtiznost1, VyberObtiznosti Obtiznost2)
        {
            hra.ObtiznostHrac1 = Obtiznost1;
            hra.ObtiznostHrac2 = Obtiznost2;
            ObtiznostInfo();
        }// stara se o nastaveni hrace/pocitace pri zmene nastaveni
        private void novaHraMenu_Click(object sender, EventArgs e)
        {
            PozastavitHru();
            nastaveniHry.novaHra = true;
            nastaveniHry.ShowDialog();
            NovaHra();

        }

        #region Nastaveni pozic, barev, zmrazeni, tahu
        private void UrceniSouradnicVykresleni()
        {
            int SouradniceFigurekX = 15;
            int SouradniceFigurekY = 5;
            for (int i = 0; i < 6; i++)
            {
                PoziceFigurekVykresleniX[i] = SouradniceFigurekX;
                PoziceFigurekVykresleniY[i] = SouradniceFigurekY;
                SouradniceFigurekX += 100;
                SouradniceFigurekY += 100;
            }
        }//nastaveni souradnic pro vykreslovani vola se pouze pri startu
        private void VykresliHraciPole(Graphics Grafika)
        {
            int poziceX = 50;
            int poziceY = 15;
            int PoziceDY = 40;

            for (int y = 0; y < 6; y++)
            {
                for (int i = 0; i < 6; i++)
                {
                    Grafika.DrawLine(BarvaSachovnice, poziceX, poziceY, poziceX, poziceY + 50);
                    poziceX += 100;
                }
                Grafika.DrawLine(BarvaSachovnice, 50, PoziceDY, 550, PoziceDY);
                PoziceDY += 100;
                poziceY += 100;
                poziceX = 50;
            }
            Grafika.DrawRectangle(BarvaSachovnice, 1, 1, 597, 582);

        }
        private void VykresliBileFigurky(Graphics Grafika)
        {

            int[,] Figurky = sachovnice.PoziceBilychFigurekXYZ;
            for (int i = 0; i < 6; i++)
            {
                int X = Figurky[i, 0] - 1;
                int Y = Figurky[i, 1] - 1;
                int TypFigurky = Figurky[i, 3];
                BileFigurky[i] = new Figurka(PoziceFigurekVykresleniX[X], PoziceFigurekVykresleniY[Y], BarvaBileFigurky, TypFigurky);
                BileFigurky[i].Vykresli(Grafika);
            }
        }
        private void VykresliCerneFigurky(Graphics Grafika)
        {
            int[,] Figurky = sachovnice.PoziceCernychFigurekXYZ;
            for (int i = 0; i < 6; i++)
            {
                int X = Figurky[i, 0] - 1;
                int Y = Figurky[i, 1] - 1;
                int TypFigurky = Figurky[i, 3];
                CerneFigurky[i] = new Figurka(PoziceFigurekVykresleniX[X], PoziceFigurekVykresleniY[Y], BarvaCerneFigurky, TypFigurky);
                CerneFigurky[i].Vykresli(Grafika);
            }
        }

        private void VykresliMozneTahy(Graphics Grafika)
        {

            for (int i = 0; i < MozneSkokyPocet; i++)
            {
                int X = MozneSkokyXY[i, 0] - 1;
                int Y = MozneSkokyXY[i, 1] - 1;
                MozneTahy[i] = new VykresleniTahu(PoziceFigurekVykresleniX[X], PoziceFigurekVykresleniY[Y], Color.GreenYellow);
                MozneTahy[i].Vykresli(Grafika);
            }
        }
        private void VykresliVybranouFigurku(Graphics Grafika)
        {
            if (VybranaFigurkaXY[0] != 0 || VybranaFigurkaXY[0] != 0)
            {
                int X = VybranaFigurkaXY[0] - 1;
                int Y = VybranaFigurkaXY[1] - 1;
                VybranaFigurka = new VykresleniTahu(PoziceFigurekVykresleniX[X], PoziceFigurekVykresleniY[Y], Color.Green);
                VybranaFigurka.Vykresli(Grafika);
            }
        }
        private void VykresliZmrazenePolicko(Graphics Grafika)
        {
            int PoziceFigurky = 0;
            for (int i = 0; i < 6; i++)
            {
                if (sachovnice.PoziceBilychFigurekXYZ[i, 2] == Sachovnice.ZmrazenaFigurka)
                {
                    int X = sachovnice.PoziceBilychFigurekXYZ[i, 0] - 1;
                    int Y = sachovnice.PoziceBilychFigurekXYZ[i, 1] - 1;
                    ZmrazenaFigurka[PoziceFigurky] = new ZmrazenePolicko(PoziceFigurekVykresleniX[X], PoziceFigurekVykresleniY[Y]);
                    ZmrazenaFigurka[PoziceFigurky].Vykresli(Grafika);
                    PoziceFigurky++;

                }
            }
        }
        private void VykresliNejTahHrace(Graphics Grafika)
        {
            if (VykresliNejTah)
            {
                int[] FigurkaXY = new int[2];
                int[] TahXY = new int[2];
                FigurkaXY[0] = NejTahHrace[0, 0] - 1;
                FigurkaXY[1] = NejTahHrace[0, 1] - 1;
                TahXY[0] = NejTahHrace[1, 0] - 1;
                TahXY[1] = NejTahHrace[1, 1] - 1;
                VykresleniTahu OhraniceniFigurky = new VykresleniTahu(PoziceFigurekVykresleniX[FigurkaXY[0]], PoziceFigurekVykresleniY[FigurkaXY[1]], Color.Red);
                VykresleniTahu CilFigurkyFigurky = new VykresleniTahu(PoziceFigurekVykresleniX[TahXY[0]], PoziceFigurekVykresleniY[TahXY[1]], Color.Red);
                OhraniceniFigurky.Vykresli(Grafika);
                CilFigurkyFigurky.Vykresli(Grafika);
            }



        }
        #endregion
        public void VykresleniSachovnice(object sender, PaintEventArgs e)
        {

            Graphics s = e.Graphics;
            VykresliHraciPole(s);
            VykresliBileFigurky(s);
            VykresliCerneFigurky(s);
            VykresliMozneTahy(s);
            VykresliVybranouFigurku(s);
            VykresliZmrazenePolicko(s);
            VykresliNejTahHrace(s);
            // s.Dispose();

        }
        private void PohybPocitace(object o, EventArgs e)
        {
            ZmenaTahuUnduRedu();
            if (!PocitacOdehral)
            {
                if (!worker_minimaxPC.IsBusy)
                {
                    if (hra.ObtiznostHrac1 == VyberObtiznosti.Hrac ||
                        hra.ObtiznostHrac2 == VyberObtiznosti.Hrac)
                    {
                        PocitacOdehral = true;
                    }
                    else
                    {
                        PocitacOdehral = false;
                    }
                    KonecHryUlozeni = false;
                    labelvypocet.Visible = true;
                    btnUndo.Enabled = false;
                    btnRedu.Enabled = false;
                    btnUkonceniVypoctu.Enabled = true;
                    SachovniceCanvas.Enabled = false;
                    NejTahStripMenu.Enabled = false;
                    VypocetPocitace = true;
                    worker_minimaxPC.RunWorkerAsync();

                }

                VypsaniOdehranychTahu();
                UndoRedu = false;

            }
        }
        private void UlozeniPozicePocitace(int[] startTah, int[] CilTah, Hrac hrac)
        {
            int[] Tah = new int[6];
            for (int y = 0; y < 2; y++)
            {
                Tah[y] = startTah[y];
                Tah[y + 2] = CilTah[y];

            }
            Tah[4] = startTah[2];
            Tah[5] = startTah[3];
            OdehranyTah.Add(Tah);
            KdoOdehralTah.Add(hrac);
            
        }//pro undo/redu a ulozeni hry
        #region Nastaveni vypisu v hernim okne
        private void HrajiciHracInfo(object sender, PaintEventArgs e)
        {

            if (hracNaRade == Hrac.BilyHrac &&
                hra.ObtiznostHrac1 == VyberObtiznosti.Hrac ||
                hracNaRade == Hrac.CernyHrac &&
                hra.ObtiznostHrac2 == VyberObtiznosti.Hrac)
            {

                infoHrajiciHracHorni.Text = "Hraje Hráč";
            }
            else
            {
                infoHrajiciHracHorni.Text = "Hraje Počítač";
            }

            Graphics g = e.Graphics;
            infoHrajiciHracHorni.Show();
            VykresleniFigurkyInfo(g);


        }
        private void VykresleniFigurkyInfo(Graphics Grafika)
        {
            Brush bila = new SolidBrush(Color.White);
            Brush cerna = new SolidBrush(Color.Black);
            if (hracNaRade == Hrac.BilyHrac)
            {

                Grafika.FillEllipse(bila, 80, 25, 70, 70);
            }
            else
            {
                Grafika.FillEllipse(cerna, 80, 25, 70, 70);
            }
            Grafika.Dispose();
        }
        private void ZmenaInfoHrac(string Zprava)
        {
            infoHrajiciHrac.Text = Zprava;
            grBoxHracNaTahu.Invalidate();
        }
        private void ObtiznostInfo()
        {
            if (hra.ObtiznostHrac1 == VyberObtiznosti.Hrac &&
                hra.ObtiznostHrac2 == VyberObtiznosti.Hrac)
            {
                InfoObtiznost.Text = "Hráč proti Hráči";
                NejTahStripMenu.Enabled = true;
                CasovaniPocitace.Stop();
            }
            else if (hra.ObtiznostHrac1 == VyberObtiznosti.Hrac &&
                hra.ObtiznostHrac2 != VyberObtiznosti.Hrac)
            {
                if (hra.ObtiznostHrac2 == VyberObtiznosti.PocitacLehka)
                {
                    InfoObtiznost.Text = "Hráč proti Počítači(Lehká)";
                }
                else if (hra.ObtiznostHrac2 == VyberObtiznosti.PocitacStredni)
                {
                    InfoObtiznost.Text = "Hráč proti Počítači(Střední)";
                }
                else
                {
                    InfoObtiznost.Text = "Hráč proti Počítači(Těžká)";
                }
                NejTahStripMenu.Enabled = true;
                if (hracNaRade == Hrac.BilyHrac)
                {

                    CasovaniPocitace.Start();
                    PocitacOdehral = true;


                }
                else
                {
                    CasovaniPocitace.Start();
                    PocitacOdehral = false;
                }

            }
            else if (hra.ObtiznostHrac1 != VyberObtiznosti.Hrac &&
                hra.ObtiznostHrac2 == VyberObtiznosti.Hrac)
            {
                if (hra.ObtiznostHrac1 == VyberObtiznosti.PocitacLehka)
                {
                    InfoObtiznost.Text = "Počítač(Lehká) proti Hráči";
                }
                else if (hra.ObtiznostHrac1 == VyberObtiznosti.PocitacStredni)
                {
                    InfoObtiznost.Text = "Počítač(Střední) proti Hráči";
                }
                else
                {
                    InfoObtiznost.Text = "Počítač(Těžká) proti Hráči";
                }

                NejTahStripMenu.Enabled = false;
                if (hracNaRade == Hrac.CernyHrac)
                {
                    CasovaniPocitace.Start();
                    PocitacOdehral = true;

                }
                else
                {
                    CasovaniPocitace.Start();
                    PocitacOdehral = false;
                }
            }
            else
            {
                InfoObtiznost.Text = "Počítač proti Počítači";
                CasovaniPocitace.Interval = intervalPosunuPocitace;
                if (hra.StavHry == StavHry.Probiha)
                {
                    CasovaniPocitace.Start();

                }
                PocitacOdehral = false;
                pozastavitToolStripMenuItem.Enabled = true;
            }

        }//slouzi zaroven pro casovac pohybu pc vs pc
        #endregion
        private void Sachovnice_click(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < MozneSkokyPocet; i++)
            {
                if (MozneTahy[i].SouradniceKliknuti(e))
                {
                    int[] CILXY = new int[2];
                    int[] Tah = new int[6];
                    CILXY[0] = MozneSkokyXY[i, 0];
                    CILXY[1] = MozneSkokyXY[i, 1];

                    sachovnice.PohybFigurkou(VybranaFigurkaXY, CILXY, hracNaRade);
                    for (int y = 0; y < 2; y++)
                    {
                        Tah[y] = VybranaFigurkaXY[y];
                        Tah[y + 2] = CILXY[y];

                    }
                    Tah[4] = VybranaFigurkaXY[2];
                    Tah[5] = VybranaFigurkaXY[3];
                    ZmenaTahuUnduRedu();
                    VykresliNejTah = false;
                    OdehranyTah.Add(Tah);
                    KdoOdehralTah.Add(hracNaRade);
                    SachovniceCanvas.Invalidate();
                    grBoxHracNaTahu.Invalidate();
                    hra.HracNaradePrepnuti();
                    VypsaniOdehranychTahu();
                    KonecHryUlozeni = false;
                    UndoRedu = false;
                    PocitacOdehral = false;

                    break;

                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (BileFigurky[i].SouradniceKliknuti(e) && hra.ObtiznostHrac1 == VyberObtiznosti.Hrac && hracNaRade == Hrac.BilyHrac)
                {
                    int[,] Figurky = sachovnice.PoziceBilychFigurekXYZ;
                    int[] X = new int[4];
                    for (int y = 0; y < 4; y++)
                    {
                        X[y] = Figurky[i, y];
                        VybranaFigurkaXY[y] = X[y];
                    }

                    MozneSkokyPocet = 0;
                    MozneSkokyXY = sachovnice.GeneratorTahu(X, Hrac.BilyHrac);
                    MozneSkokyPocet = sachovnice.MozneSkoky;
                    break;
                }
                else if (CerneFigurky[i].SouradniceKliknuti(e) && hra.ObtiznostHrac2 == VyberObtiznosti.Hrac && hracNaRade == Hrac.CernyHrac)
                {
                    int[,] Figurky = sachovnice.PoziceCernychFigurekXYZ;
                    int[] X = new int[4];
                    for (int y = 0; y < 4; y++)
                    {
                        X[y] = Figurky[i, y];
                        VybranaFigurkaXY[y] = X[y];
                    }
                    MozneSkokyPocet = 0;

                    MozneSkokyXY = sachovnice.GeneratorTahu(X, Hrac.CernyHrac);
                    MozneSkokyPocet = sachovnice.MozneSkoky;
                    break;
                }
                else
                {
                    MozneSkokyPocet = 0;
                    VybranaFigurkaXY[0] = 0;
                    VybranaFigurkaXY[1] = 0;
                }

            }

            SachovniceCanvas.Invalidate();

        }//obsluhuje kliknuti do sachovnice (pohyb hrace)

        private void ukoncitHruStripMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region obsluha UndoRedu
        private void HerniKrokZpet()
        {
            Hrac HrajiciHrac;
            int[] StartXY = new int[2];
            int[] CilXY = new int[2]; ;

            for (int i = 0; i < 2; i++)
            {
                StartXY[i] = OdehranyTah[VyberUndoReduListu][i];
                CilXY[i] = OdehranyTah[VyberUndoReduListu][i + 2];
            }

            hra.HracNaradePrepnuti();
            HrajiciHrac = KdoOdehralTah[VyberUndoReduListu];
            sachovnice.PohybFigurkouZpet(StartXY, CilXY, HrajiciHrac);
            MozneSkokyPocet = 0;
            VybranaFigurkaXY[0] = 0;
            VybranaFigurkaXY[1] = 0;
            SachovniceCanvas.Invalidate();

            UndoRedu = true;
            PozastavitHru();
            SachovniceCanvas.Enabled = true;
        }
        private void HerniKrokDopredu()
        {
            Hrac HrajiciHrac;
            int[] StartXY = new int[2];
            int[] CilXY = new int[2]; ;
            for (int i = 0; i < 2; i++)
            {
                StartXY[i] = OdehranyTah[VyberUndoReduListu - 1][i];
                CilXY[i] = OdehranyTah[VyberUndoReduListu - 1][i + 2];
            }
            hra.HracNaradePrepnuti();
            HrajiciHrac = KdoOdehralTah[VyberUndoReduListu - 1];
            sachovnice.PohybFigurkou(StartXY, CilXY, HrajiciHrac);
            MozneSkokyPocet = 0;
            VybranaFigurkaXY[0] = 0;
            VybranaFigurkaXY[1] = 0;
            SachovniceCanvas.Invalidate();
            UndoRedu = true;
            PozastavitHru();
        }
        private void VypsaniOdehranychTahu()
        {

            string OdehryTahVypis;
            string Bhrac = "Bílý";
            string Chrac = "Černý";
            ListBoxUndoRedu.Items.Clear();
            ListBoxUndoRedu.Items.Add("Záčátek hry");

            /*
            ListBoxUndoRedu.Items.AddRange(OdehryTahVypis);
            ListBoxUndoRedu.Items.AddRange(OdehryTahVypis);
            */
            for (int i = 0; i < KdoOdehralTah.Count; i++) //oba listy musi byt stejne dlouhe
            {
                char[] Start = new char[2];
                char[] Cil = new char[2];
                Start[0] = (char)(OdehranyTah[i][0] + 64);
                Start[1] = (char)(OdehranyTah[i][1] + 48);

                Cil[0] = (char)(OdehranyTah[i][2] + 64);
                Cil[1] = (char)(OdehranyTah[i][3] + 48);

                if (KdoOdehralTah[i] == Hrac.BilyHrac)
                {
                    OdehryTahVypis = "" + Start[0] + Start[1] + " -> " + Cil[0] + Cil[1] + " " + Bhrac;
                }
                else
                {
                    OdehryTahVypis = "" + Start[0] + Start[1] + " -> " + Cil[0] + Cil[1] + " " + Chrac;

                }
                ListBoxUndoRedu.Items.Add(OdehryTahVypis);

            }


            VyberUndoReduListu = ListBoxUndoRedu.Items.Count - 1;
            ObsluhaUndoReduListu();

        }

        private void ZmenaTahuUnduRedu()
        {
            if (UndoRedu)
            {
                for (int i = ListBoxUndoRedu.Items.Count - 2; i >= VyberUndoReduListu; i--)
                {
                    OdehranyTah.RemoveAt(i);
                    KdoOdehralTah.RemoveAt(i);
                }
            }
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            VyberUndoReduListu -= 1;
            ObsluhaUndoReduListu();
            ListBoxUndoRedu.SelectedIndex = VyberUndoReduListu;
            HerniKrokZpet();
            UndoRedu = true;

        }

        private void btnRedu_Click(object sender, EventArgs e)
        {
            VyberUndoReduListu += 1;
            ObsluhaUndoReduListu();
            ListBoxUndoRedu.SelectedIndex = VyberUndoReduListu;
            HerniKrokDopredu();
            UndoRedu = true;
        }
        private void ObsluhaUndoReduListu()
        {
            if (VyberUndoReduListu <= 0 || VypocetPocitace)
            {
                btnUndo.Enabled = false;
            }
            else
            {
                btnUndo.Enabled = true;
            }
            if (ListBoxUndoRedu.Items.Count - 1 <= VyberUndoReduListu || VypocetPocitace)
            {
                btnRedu.Enabled = false;
            }
            else
            {
                btnRedu.Enabled = true;
            }
        }
        private void ListBoxUndoRedu_Click(object sender, EventArgs e)
        {
            if (VyberUndoReduListu != ListBoxUndoRedu.SelectedIndex &&
                ListBoxUndoRedu.SelectedIndex >= 0)
            {
                VyberUndoReduListu = ListBoxUndoRedu.SelectedIndex;
                if ((ListBoxUndoRedu.SelectedIndex + 1) < ListBoxUndoRedu.Items.Count)
                {
                    VyberUndoReduListu = ListBoxUndoRedu.SelectedIndex;
                    HerniKrokZpet();
                }

            }

            ObsluhaUndoReduListu();
        }//neni hotove (chybi cyklus pro undo/redu)
        #endregion

        #region Obsluha ukladani a nacitani souboru
        private void ulozitStripMenu_Click(object sender, EventArgs e)
        {
            try
            {
                PozastavitHru();
                Stream stream;
                SaveFileDialog Ulozeni = new SaveFileDialog();
                Ulozeni.Filter = "SAV Soubor (*.sav)|*.sav";
                Ulozeni.FileName = "Evade";
                StreamWriter StreamWriter = null;

                if (Ulozeni.ShowDialog() == DialogResult.OK)
                {
                    if ((stream = Ulozeni.OpenFile()) != null)
                    {
                        KonecHryUlozeni = true;
                        StreamWriter = new StreamWriter(stream);
                        if (hra.ObtiznostHrac1 == VyberObtiznosti.Hrac)
                        {
                            StreamWriter.Write(0);
                        }
                        else if (hra.ObtiznostHrac1 == VyberObtiznosti.PocitacLehka)
                        {
                            StreamWriter.Write(1);
                        }
                        else if (hra.ObtiznostHrac1 == VyberObtiznosti.PocitacStredni)
                        {
                            StreamWriter.Write(2);
                        }
                        else if (hra.ObtiznostHrac1 == VyberObtiznosti.PocitacTezka)
                        {
                            StreamWriter.Write(3);
                        }

                        if (hra.ObtiznostHrac2 == VyberObtiznosti.Hrac)
                        {
                            StreamWriter.Write(0);
                        }
                        else if (hra.ObtiznostHrac2 == VyberObtiznosti.PocitacLehka)
                        {
                            StreamWriter.Write(1);
                        }
                        else if (hra.ObtiznostHrac2 == VyberObtiznosti.PocitacStredni)
                        {
                            StreamWriter.Write(2);
                        }
                        else if (hra.ObtiznostHrac2 == VyberObtiznosti.PocitacTezka)
                        {
                            StreamWriter.Write(3);
                        }
                        StreamWriter.Write(";");
                        StreamWriter.WriteLine();
                        for (int i = 0; i < OdehranyTah.Count; i++)
                        {
                            foreach (int Tah in OdehranyTah[i])
                            {
                                StreamWriter.Write(Tah);

                            }
                            //prepsat na cisla bhrac 0 cerny 1
                            if (KdoOdehralTah[i] == Hrac.BilyHrac)
                            {
                                StreamWriter.Write('0');
                            }
                            else
                            {
                                StreamWriter.Write('1');
                            }



                            StreamWriter.Write(";");
                            StreamWriter.WriteLine();
                        }

                    }
                    StreamWriter.Close();
                }



            }
            catch
            {
                MessageBox.Show("Chyba při ukládání souboru", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void otevritStripMenu_Click(object sender, EventArgs e)
        {
            string Chyba = " ";
            try
            {
                PozastavitHru();
                Stream stream;
                OpenFileDialog Otevreni = new OpenFileDialog();
                Otevreni.Filter = "SAV Soubor (*.sav)|*.sav";
                StreamReader StreamReader = null;


                if (Otevreni.ShowDialog() == DialogResult.OK)
                {
                    if ((stream = Otevreni.OpenFile()) != null)
                    {
                        nastaveniHry.novaHra = true;
                        NovaHra();
                        nastaveniHry.novaHra = false;
                        StreamReader = new StreamReader(stream);
                        #region Nacteni nastaveni hry
                        string NastaveniHry = StreamReader.ReadLine();
                        if (NastaveniHry[0] - 48 == 0)
                        {
                            hra.ObtiznostHrac1 = VyberObtiznosti.Hrac;
                        }
                        else if (NastaveniHry[0] - 48 == 1)
                        {
                            hra.ObtiznostHrac1 = VyberObtiznosti.PocitacLehka;
                        }
                        else if (NastaveniHry[0] - 48 == 2)
                        {
                            hra.ObtiznostHrac1 = VyberObtiznosti.PocitacStredni;
                        }
                        else if (NastaveniHry[0] - 48 == 3)
                        {
                            hra.ObtiznostHrac1 = VyberObtiznosti.PocitacTezka;
                        }
                        else
                        {
                            Chyba = "Načtena špatná volba nastavení u hráče 1";
                            throw new NullReferenceException();
                        }
                        if (NastaveniHry[1] - 48 == 0)
                        {
                            hra.ObtiznostHrac2 = VyberObtiznosti.Hrac;
                        }
                        else if (NastaveniHry[1] - 48 == 1)
                        {
                            hra.ObtiznostHrac2 = VyberObtiznosti.PocitacLehka;
                        }
                        else if (NastaveniHry[1] - 48 == 2)
                        {
                            hra.ObtiznostHrac2 = VyberObtiznosti.PocitacStredni;
                        }
                        else if (NastaveniHry[1] - 48 == 3)
                        {
                            hra.ObtiznostHrac2 = VyberObtiznosti.PocitacTezka;
                        }
                        else
                        {
                            Chyba = "Načtena špatná volba nastavení u hráče 2";
                            throw new NullReferenceException();
                        }
                        #endregion

                        string Radek;
                        Hrac Odehral;

                        while ((Radek = StreamReader.ReadLine()) != null)
                        {
                            bool PlatnyTah = false;
                            int[] SXY = new int[4];
                            int[] CXY = new int[2];

                            SXY[0] = Radek[0] - 48;
                            SXY[1] = Radek[1] - 48;
                            CXY[0] = Radek[2] - 48;
                            CXY[1] = Radek[3] - 48;
                            SXY[2] = Radek[4] - 48;
                            SXY[3] = Radek[5] - 48;
                            if (Radek[6] - 48 == 0)
                            {
                                Odehral = Hrac.BilyHrac;
                            }
                            else
                            {
                                Odehral = Hrac.CernyHrac;
                            }
                            int[,] MozneTahy = sachovnice.GeneratorTahu(SXY, Odehral);
                            int MozneSkoky = sachovnice.MozneSkoky;
                            for (int i = 0; i < MozneSkoky; i++)
                            {
                                if (MozneTahy[i, 0] == CXY[0] && MozneTahy[i, 1] == CXY[1])
                                {
                                    sachovnice.PohybFigurkou(SXY, CXY, Odehral);
                                    int[] Tah = new int[6];
                                    for (int y = 0; y < 2; y++)
                                    {
                                        Tah[y] = SXY[y];
                                        Tah[y + 2] = CXY[y];
                                    }
                                    Tah[4] = SXY[2];
                                    Tah[5] = SXY[3];
                                    OdehranyTah.Add(Tah);
                                    KdoOdehralTah.Add(Odehral);
                                    PlatnyTah = true;
                                    hra.HracNaradePrepnuti();
                                }
                            }
                            if (KdoOdehralTah.Count > 1)
                            {
                                if (KdoOdehralTah[KdoOdehralTah.Count - 1] == KdoOdehralTah[KdoOdehralTah.Count - 2])
                                {
                                    Chyba = "Načteno že Hráč hrál 2x po sobě";
                                    throw new NullReferenceException();
                                }
                            }
                            if (!PlatnyTah)
                            {
                                Chyba = "Načteny neplatné souřadnice";
                                throw new NullReferenceException();
                            }
                            PlatnyTah = false;
                        }
                        ObtiznostInfo(); // pro vypis typu hry dole uprostred
                        SachovniceCanvas.Invalidate();
                        VypsaniOdehranychTahu();



                    }
                }
                if (StreamReader != null)
                {
                    StreamReader.Close();
                }

            }

            catch
            {
                MessageBox.Show("Chyba při otevírání souboru" + Environment.NewLine + Chyba, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nastaveniHry.novaHra = true;
                NovaHra();
                nastaveniHry.novaHra = false;
            }
        }
        #endregion
        private void KonecHry()
        {
            SachovniceCanvas.Enabled = false;
            PocitacOdehral = true;
            CasovaniPocitace.Stop();
        }// kdyz je dosazen cil hry (napr vyhra...) aby zustalo otevrene okno a neslo do nej klikat
        #region Obsluha Vlaken Minimaxu
        private void worker_minimax_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker worker_minimax = sender as BackgroundWorker;
            e.Result = NejTahHrace = hra.NejtahHrac(worker_minimax, e);
            VykresliNejTah = true;
            SachovniceCanvas.Invalidate();
        } // vypocet nej tahu hrace
        private void worker_minimaxPC_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker_minimax = sender as BackgroundWorker;
            
            hra.VyberPocitace(worker_minimax, e);
        }//vypocet nej tahu pocitace
        private void btnUkonceniVypoctu_Click(object sender, EventArgs e)
        {
            if (worker_minimax.IsBusy)
            {
                worker_minimax.CancelAsync();
            }
            else if (worker_minimaxPC.IsBusy)
            {
                worker_minimaxPC.CancelAsync();
            }

        }

        private void worker_minimax_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarMinimax.Value = e.ProgressPercentage;
        }
        private void worker_minimax_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            SachovniceCanvas.Enabled = true;
            btnUkonceniVypoctu.Enabled = false;
            if (ListBoxUndoRedu.Items.Count > 2 && VyberUndoReduListu >0)
            {
                btnUndo.Enabled = true;
            }
            if (ListBoxUndoRedu.Items.Count - 1 > VyberUndoReduListu)
            {
                btnRedu.Enabled = true;
            }
            else
            {
                btnRedu.Enabled = false;
            }

            labelvypocet.Visible = false;
            progressBarMinimax.Value = 0;
            SachovniceCanvas.Invalidate();
            grBoxHracNaTahu.Invalidate();
        }//Dokonceny vypocet nej tahu hrace
        private void worker_minimaxPC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            SachovniceCanvas.Enabled = true;
            btnUkonceniVypoctu.Enabled = false;
            if (ListBoxUndoRedu.Items.Count > 2 && VyberUndoReduListu > 0)
            {
                btnUndo.Enabled = true;
            }
            if (ListBoxUndoRedu.Items.Count - 1 > VyberUndoReduListu )
            {
                btnRedu.Enabled = true;
            }
            else
            {
                btnRedu.Enabled = false;
            }
            
            labelvypocet.Visible = false;
            
            VypsaniOdehranychTahu();
            progressBarMinimax.Value = 0;
            hra.HracNaradePrepnuti();
            VypocetPocitace = false;
            ObsluhaUndoReduListu();
            if (hra.ObtiznostHrac1 != VyberObtiznosti.Hrac &&
                hra.ObtiznostHrac2 != VyberObtiznosti.Hrac)
            {

                PocitacOdehral = false;
            }
            else
            {
                NejTahStripMenu.Enabled = true;
            }

        }//Dokonceny vypocet nej tahu pocitace
        #endregion

        private void NejTahStripMenu_Click(object sender, EventArgs e)
        {
            if (!worker_minimax.IsBusy)
            {
                btnRedu.Enabled = false;
                labelvypocet.Visible = true;
                btnUndo.Enabled = false;
                btnUkonceniVypoctu.Enabled = true;
                SachovniceCanvas.Enabled = false;
                worker_minimax.RunWorkerAsync();
            }
        }


        private void spustitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pozastavitToolStripMenuItem.Enabled = true;
            spustitToolStripMenuItem.Enabled = false;
            CasovaniPocitace.Start();
        }

        private void pozastavitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pozastavitToolStripMenuItem.Enabled = false;
            spustitToolStripMenuItem.Enabled = true;
            CasovaniPocitace.Stop();

        }

        private void nastaveniHryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PozastavitHru();
            nastaveniHry.ShowDialog();
        }


        private void HerniOkno_FormClosing(object sender, FormClosingEventArgs e)
        {
            PozastavitHru();
            if (!KonecHryUlozeni)
            {
                var odpoved = MessageBox.Show("Chcete uložit hru?", "Konec hry",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (odpoved == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (odpoved == DialogResult.Yes)
                {
                    ulozitStripMenu_Click(sender, e);
                    if (!KonecHryUlozeni)
                    {
                        e.Cancel = true;
                    }
                }

            }
        }

        private void pravidlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PozastavitHru();
            pravidla.ShowDialog();
        }

        private void ovládaníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PozastavitHru();
            ovladani.ShowDialog();
        }
        private void PozastavitHru()
        {
            CasovaniPocitace.Stop();
            if (hra.ObtiznostHrac1 != VyberObtiznosti.Hrac ||
                hra.ObtiznostHrac2 != VyberObtiznosti.Hrac)
            {
                pozastavitToolStripMenuItem.Enabled = false;
                spustitToolStripMenuItem.Enabled = true;
            }
        }
    }
}
