using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evade_Gui
{
    class Sachovnice
    {
        private int[,] _souradniceSachovnice = new int[8, 8]; // prepsat prepisuje se spatne pri volani instalce vlozi blbou hodnotu napsat metodu
        //pro ulozeni sachovnice
        //nastaveni hodnot pro figurky
        public const int BilaFigurka = 1, CernaFigurka = -1, ZmrazenePolicko = -100;
        public const int zed = -50;
        public const int PrazdneBilePolicko = 100;
        public const int BilyKral = 10, CernyKral = -10;
        public const int Kral = 1, Pesec = 0;
        // moznost zmenit zobrazeni figurky
        public const int NezmrazenaFigurka = 1, ZmrazenaFigurka = 0;
        private int _mozneSkoky = 0;
        private int MozneZmrazeni = 0;
        


        private int[,] _poziceBilychFigurekXYZF = new int[6, 4]; //6 figurek, X = xsouradnice, Y = Ysouradnice, Z = Zramzena, F kral = 1 pesec 0
        private int[,] _poziceCernychFigurekXYZF = new int[6, 4]; //6 figurek, X = xsouradnice, Y = Ysouradnice, Z = Zramzena, F kral = 1 pesec 0

        // pro zobrazeni souradnic na kraji sachovnice
        private int[,] _zmrazenaFigurkaFXY = new int[12, 3]; //[12] prvni = figurka co zmrazila, druha figurka ktera byla zmrazena [3]F = Figurka ktera je zmrazena XY = souradnice, 
        private int _zmrazenychFigurek = 0;
        /*
        public int MozneSkoky {
            get { return _mozneSkoky; }
            set { _mozneSkoky = value; }
        }*/
        public int[,] PoziceBilychFigurekXYZ
        {
            get { return _poziceBilychFigurekXYZF; }
            set { _poziceCernychFigurekXYZF = value; }
        }
        public int[,] PoziceCernychFigurekXYZ
        {
            get { return _poziceCernychFigurekXYZF; }
            set { _poziceCernychFigurekXYZF = value; }
        }
        public int[,] SouradniceSachovnice
        {
            get { return _souradniceSachovnice; }
            set { _souradniceSachovnice = value; }
        }
        public int[,] ZmrazenaFigurkaFXY
        {
            get { return _zmrazenaFigurkaFXY; }
        }
        public int ZmrazenychFigurek
        {
            get { return _zmrazenychFigurek; }
        }
        public int MozneSkoky
        {
            get { return _mozneSkoky; }
            set { _mozneSkoky = value; }
        }
        /*
        public int MozneZmrazeni { get => _mozneZmrazeni; set => _mozneZmrazeni = value; }
        */

        public Sachovnice()
        {
            PocatecniStavSachovnice();
            
        }

        private void PocatecniStavSachovnice()
        {
            for (int i = 1; i < 7; i++)
            {
                for (int y = 1; y < 7; y++)
                {
                    if (i == 1)
                    {
                        if (y == 3 || y == 4)
                        {
                            SouradniceSachovnice[y, i] = BilyKral;
                            continue;
                        }
                        else
                        {
                            SouradniceSachovnice[y, i] = BilaFigurka;
                            continue;
                        }
                    }
                    if (i == 6)
                    {
                        if (y == 3 || y == 4)
                        {
                            SouradniceSachovnice[y, i] = CernyKral;
                            continue;
                        }
                        else
                        {
                            SouradniceSachovnice[y, i] = CernaFigurka;
                            continue;
                        }
                    }
                    else
                        SouradniceSachovnice[y, i] = PrazdneBilePolicko;
                    continue;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                SouradniceSachovnice[0, i] = zed;
                SouradniceSachovnice[i, 0] = zed;
                SouradniceSachovnice[i, 7] = zed;
                SouradniceSachovnice[7, i] = zed;
            }

            PocatecniUlozeniPozicFigurek();
        }//pocatecni rozmisteni figurek a prazdnych policek

        private void PocatecniUlozeniPozicFigurek()


        {

            int UmisteniBfigurek = 0;
            int UmisteniBKralu = 4;
            int UmisteniCfigurek = 0;
            int UmisteniCKralu = 4;
            for (int y = 1; y < 7; y++)
            {
                for (int x = 1; x < 7; x++)
                {
                    if (SouradniceSachovnice[x, y] == BilaFigurka)
                    {
                        _poziceBilychFigurekXYZF[UmisteniBfigurek, 0] = x;
                        _poziceBilychFigurekXYZF[UmisteniBfigurek, 1] = y;
                        _poziceBilychFigurekXYZF[UmisteniBfigurek, 2] = NezmrazenaFigurka;
                        _poziceBilychFigurekXYZF[UmisteniBfigurek, 3] = Pesec;
                        UmisteniBfigurek++;
                        continue;
                    }
                    else if (SouradniceSachovnice[x, y] == CernaFigurka)
                    {
                        _poziceCernychFigurekXYZF[UmisteniCfigurek, 0] = x;
                        _poziceCernychFigurekXYZF[UmisteniCfigurek, 1] = y;
                        _poziceCernychFigurekXYZF[UmisteniCfigurek, 2] = NezmrazenaFigurka;
                        _poziceCernychFigurekXYZF[UmisteniCfigurek, 3] = Pesec;
                        UmisteniCfigurek++;
                        continue;
                    }
                    else if (SouradniceSachovnice[x, y] == BilyKral)
                    {
                        _poziceBilychFigurekXYZF[UmisteniBKralu, 0] = x;
                        _poziceBilychFigurekXYZF[UmisteniBKralu, 1] = y;
                        _poziceBilychFigurekXYZF[UmisteniBKralu, 2] = NezmrazenaFigurka;
                        _poziceBilychFigurekXYZF[UmisteniBKralu, 3] = Kral;
                        UmisteniBKralu++;
                        continue;
                    }
                    else if (SouradniceSachovnice[x, y] == CernyKral)
                    {
                        _poziceCernychFigurekXYZF[UmisteniCKralu, 0] = x;
                        _poziceCernychFigurekXYZF[UmisteniCKralu, 1] = y;
                        _poziceCernychFigurekXYZF[UmisteniCKralu, 2] = NezmrazenaFigurka;
                        _poziceCernychFigurekXYZF[UmisteniCKralu, 3] = Kral;
                        UmisteniCKralu++;
                        continue;
                    }
                }
            }
        }

        public StavHry OvereniKonce(Hrac Hrac)
        {
            int PocetKralu = 0;
            int[] Figurka = new int[4];
            int Pohyb = 0;
            //Secteni nezamrazenych kralu pro remizu
            PocetKralu += _poziceBilychFigurekXYZF[4, 2];
            PocetKralu += _poziceBilychFigurekXYZF[5, 2];
            PocetKralu += _poziceCernychFigurekXYZF[4, 2];
            PocetKralu += _poziceCernychFigurekXYZF[5, 2];
            // zjisteni kolik je kralu pro remizu
            if (PocetKralu == 0)
            {
                return StavHry.Remiza;
            }
            //zjisteni jestli je kral na vitezne pozici (zjistuje u posledniho tahu)
            if (Hrac == Hrac.BilyHrac)
            {
                for (int i = 1; i < 7; i++)
                {
                    if (SouradniceSachovnice[i, 1] == CernyKral)
                    {
                        return StavHry.VyhraCernyHrac;
                    }
                }
            }
            if (Hrac == Hrac.CernyHrac)
            {
                for (int i = 1; i < 7; i++)
                {
                    if (SouradniceSachovnice[i, 6] == BilyKral)
                    {
                        return StavHry.VyhraBilyHrac;
                    }
                }
            }
            //zjisteni jestli se muze protihrac pohnout (zjistuje u posledniho tahu)
            if (Hrac == Hrac.BilyHrac)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Figurka[j] = PoziceBilychFigurekXYZ[i, j];
                    }
                    MozneSkoky = 0;
                    GeneratorTahu(Figurka, Hrac);
                    Pohyb += MozneSkoky;
                    if (Pohyb > 0)
                    {
                        break;
                    }
                }
                if (Pohyb == 0)
                {
                    return StavHry.VyhraCernyHrac;
                }

            }
            else if (Hrac == Hrac.CernyHrac)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Figurka[j] = PoziceCernychFigurekXYZ[i, j];
                    }
                    MozneSkoky = 0;
                    GeneratorTahu(Figurka, Hrac);
                    Pohyb += MozneSkoky;
                    if (Pohyb > 0)
                    {
                        break;
                    }
                }
                if (Pohyb == 0)
                {
                    return StavHry.VyhraBilyHrac;
                }

            }
            //pokud nebyla splnena nejaka podminka hra probiha dal
            return StavHry.Probiha;

        }
        public bool PohybFigurkou(int[] PocatekXY, int[] CilXY, Hrac Hrac)
        {
            int Figurka;
            Figurka = SouradniceSachovnice[PocatekXY[0], PocatekXY[1]];
            if (SouradniceSachovnice[CilXY[0], CilXY[1]] == PrazdneBilePolicko)
            {
                SouradniceSachovnice[PocatekXY[0], PocatekXY[1]] = PrazdneBilePolicko;
                SouradniceSachovnice[CilXY[0], CilXY[1]] = Figurka;
                if (Hrac == Hrac.BilyHrac)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PoziceBilychFigurekXYZ[i, 0] == PocatekXY[0] &&
                            PoziceBilychFigurekXYZ[i, 1] == PocatekXY[1])
                        {
                            PoziceBilychFigurekXYZ[i, 0] = CilXY[0];
                            PoziceBilychFigurekXYZ[i, 1] = CilXY[1];
                            continue;
                        }


                    }
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PoziceCernychFigurekXYZ[i, 0] == PocatekXY[0] &&
                            PoziceCernychFigurekXYZ[i, 1] == PocatekXY[1])
                        {
                            PoziceCernychFigurekXYZ[i, 0] = CilXY[0];
                            PoziceCernychFigurekXYZ[i, 1] = CilXY[1];

                        }
                    }
                }
                int[] Tah = new int[4];
                Tah[0] = PocatekXY[0];
                Tah[1] = PocatekXY[1];
                Tah[2] = CilXY[0];
                Tah[3] = CilXY[1];

                return true;
            }
            else if (Figurka == BilaFigurka || Figurka == CernaFigurka)
            {
                int CilovaFigurka = SouradniceSachovnice[CilXY[0], CilXY[1]];
                _zmrazenaFigurkaFXY[_zmrazenychFigurek, 0] = Figurka;
                _zmrazenaFigurkaFXY[_zmrazenychFigurek, 1] = PocatekXY[0];
                _zmrazenaFigurkaFXY[_zmrazenychFigurek, 2] = PocatekXY[1];
                _zmrazenaFigurkaFXY[_zmrazenychFigurek + 1, 0] = CilovaFigurka;
                _zmrazenaFigurkaFXY[_zmrazenychFigurek + 1, 1] = CilXY[0];
                _zmrazenaFigurkaFXY[_zmrazenychFigurek + 1, 2] = CilXY[1];
                if (Hrac == Hrac.BilyHrac)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PoziceBilychFigurekXYZ[i, 0] == PocatekXY[0] &&
                            PoziceBilychFigurekXYZ[i, 1] == PocatekXY[1])
                        {
                            PoziceBilychFigurekXYZ[i, 0] = CilXY[0];
                            PoziceBilychFigurekXYZ[i, 1] = CilXY[1];
                            PoziceBilychFigurekXYZ[i, 2] = ZmrazenaFigurka;
                        }
                        if (PoziceCernychFigurekXYZ[i, 0] == CilXY[0] &&
                        PoziceCernychFigurekXYZ[i, 1] == CilXY[1])
                        {
                            PoziceCernychFigurekXYZ[i, 2] = ZmrazenaFigurka;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PoziceCernychFigurekXYZ[i, 0] == PocatekXY[0] &&
                            PoziceCernychFigurekXYZ[i, 1] == PocatekXY[1])
                        {
                            PoziceCernychFigurekXYZ[i, 0] = CilXY[0];
                            PoziceCernychFigurekXYZ[i, 1] = CilXY[1];
                            PoziceCernychFigurekXYZ[i, 2] = ZmrazenaFigurka;
                        }
                        if (PoziceBilychFigurekXYZ[i, 0] == CilXY[0] &&
                        PoziceBilychFigurekXYZ[i, 1] == CilXY[1])
                        {
                            PoziceBilychFigurekXYZ[i, 2] = ZmrazenaFigurka;
                        }

                    }
                }
                SouradniceSachovnice[PocatekXY[0], PocatekXY[1]] = PrazdneBilePolicko;
                SouradniceSachovnice[CilXY[0], CilXY[1]] = ZmrazenePolicko;
                _zmrazenychFigurek += 2;
                int[] Tah = new int[4];
                Tah[0] = PocatekXY[0];
                Tah[1] = PocatekXY[1];
                Tah[2] = CilXY[0];
                Tah[3] = CilXY[1];

                return true;

            }
            else
            {
                return false;
            }
        }

        public bool PohybFigurkouZpet(int[] PocatekXY, int[] CilXY, Hrac Hrac)
        {


            if (SouradniceSachovnice[PocatekXY[0], PocatekXY[1]] == PrazdneBilePolicko &&
                SouradniceSachovnice[CilXY[0], CilXY[1]] != ZmrazenePolicko)
            {
                if (Hrac == Hrac.BilyHrac)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PoziceBilychFigurekXYZ[i, 0] == CilXY[0] &&
                            PoziceBilychFigurekXYZ[i, 1] == CilXY[1])
                        {
                            PoziceBilychFigurekXYZ[i, 0] = PocatekXY[0];
                            PoziceBilychFigurekXYZ[i, 1] = PocatekXY[1];
                        }


                    }
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PoziceCernychFigurekXYZ[i, 0] == CilXY[0] &&
                            PoziceCernychFigurekXYZ[i, 1] == CilXY[1])
                        {
                            PoziceCernychFigurekXYZ[i, 0] = PocatekXY[0];
                            PoziceCernychFigurekXYZ[i, 1] = PocatekXY[1];
                        }
                    }
                }
                int Figurka = SouradniceSachovnice[CilXY[0], CilXY[1]];
                SouradniceSachovnice[CilXY[0], CilXY[1]] = PrazdneBilePolicko;
                SouradniceSachovnice[PocatekXY[0], PocatekXY[1]] = Figurka;
                //PocatecniUlozeniPozicFigurek();
                return true;
            }
            else if (SouradniceSachovnice[CilXY[0], CilXY[1]] == ZmrazenePolicko)
            {
                if (Hrac == Hrac.BilyHrac)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PoziceBilychFigurekXYZ[i, 0] == CilXY[0] &&
                            PoziceBilychFigurekXYZ[i, 1] == CilXY[1])
                        {
                            PoziceBilychFigurekXYZ[i, 0] = PocatekXY[0];
                            PoziceBilychFigurekXYZ[i, 1] = PocatekXY[1];
                            PoziceBilychFigurekXYZ[i, 2] = NezmrazenaFigurka;
                        }
                        if (PoziceCernychFigurekXYZ[i, 0] == CilXY[0] &&
                        PoziceCernychFigurekXYZ[i, 1] == CilXY[1])
                        {
                            PoziceCernychFigurekXYZ[i, 2] = NezmrazenaFigurka;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PoziceCernychFigurekXYZ[i, 0] == CilXY[0] &&
                            PoziceCernychFigurekXYZ[i, 1] == CilXY[1])
                        {
                            PoziceCernychFigurekXYZ[i, 0] = PocatekXY[0];
                            PoziceCernychFigurekXYZ[i, 1] = PocatekXY[1];
                            PoziceCernychFigurekXYZ[i, 2] = NezmrazenaFigurka;
                        }
                        if (PoziceBilychFigurekXYZ[i, 0] == CilXY[0] &&
                        PoziceBilychFigurekXYZ[i, 1] == CilXY[1])
                        {
                            PoziceBilychFigurekXYZ[i, 2] = NezmrazenaFigurka;
                        }

                    }
                }
                SouradniceSachovnice[PocatekXY[0], PocatekXY[1]] = _zmrazenaFigurkaFXY[_zmrazenychFigurek - 2, 0];
                SouradniceSachovnice[CilXY[0], CilXY[1]] = _zmrazenaFigurkaFXY[_zmrazenychFigurek - 1, 0];
                _zmrazenychFigurek -= 2;
                // PocatecniUlozeniPozicFigurek();
                return true;
            }
            else
            {

                return false;
            }
        }

        private int[,] MozneTahy(int[] SouradniceXY, Hrac Hrac)
        {
            int[,] MozneTahyXY = new int[6, 2];
            int Posun = 0; // pro posunuti pole souradnic
            int SX;// nastaveni prvni souradnice X
            int SY = (SouradniceXY[1] - 1); // nastaveni prvni souradnice Y
            MozneZmrazeni = 0;
            for (int i = 0; i < 3; i++)
            {

                SX = (SouradniceXY[0] - 1);
                for (int y = 0; y < 3; y++)
                {
                    if (Hrac == Hrac.BilyHrac)
                    {
                        if (SouradniceSachovnice[SX, SY] == CernaFigurka ||
                        SouradniceSachovnice[SX, SY] == CernyKral)
                        {
                            MozneTahyXY[Posun, 0] = SX;
                            MozneTahyXY[Posun, 1] = SY;
                            Posun++;
                            MozneZmrazeni++;
                        }
                    }
                    else if (Hrac == Hrac.CernyHrac)
                    {
                        if (SouradniceSachovnice[SX, SY] == BilaFigurka ||
                        SouradniceSachovnice[SX, SY] == BilyKral)
                        {
                            MozneTahyXY[Posun, 0] = SX;
                            MozneTahyXY[Posun, 1] = SY;
                            Posun++;
                            MozneZmrazeni++;
                        }
                    }
                    SX++;
                }
                SY++;
            }
            return MozneTahyXY;
        } // zapsani moznych tahu se zamrazenim souperovy figurky
        private int[,] MozneTahy(int[] SouradniceXY)
        {
            int[,] MozneTahyXY = new int[8, 2];


            int Posun = 0; // pro posunuti pole souradnic
            int SX;// nastaveni prvni souradnice X
            int SY = (SouradniceXY[1] - 1); // nastaveni prvni souradnice Y
            MozneSkoky = 0;
            for (int i = 0; i < 3; i++)
            {
                SX = (SouradniceXY[0] - 1);
                for (int y = 0; y < 3; y++)
                {
                    if (SouradniceSachovnice[SX, SY] == PrazdneBilePolicko)
                    {
                        MozneTahyXY[Posun, 0] = SX;
                        MozneTahyXY[Posun, 1] = SY;
                        MozneSkoky++;
                        Posun++;
                    }
                    SX++;
                }
                SY++;
            }
            return MozneTahyXY;
        }
        public int[,] GeneratorTahu(int[] FigurkaXYZF, Hrac Hrac)
        {
            MozneSkoky = 0;
            MozneZmrazeni = 0;
            if (FigurkaXYZF[3] == Pesec && FigurkaXYZF[2] == NezmrazenaFigurka)
            {
                int[,] SouradniceSkokuYX = MozneTahy(FigurkaXYZF);//ulozeni mozneho pohybu figurky 
                int[,] SouradniceZamrazeniXY = MozneTahy(FigurkaXYZF, Hrac);// overeni zda je moznost zmrazit souperovu figurku
                if (MozneZmrazeni != 0)
                {
                    for (int j = 0; j < MozneZmrazeni; j++)
                    {
                        SouradniceSkokuYX[MozneSkoky, 0] = SouradniceZamrazeniXY[j, 0];
                        SouradniceSkokuYX[MozneSkoky, 1] = SouradniceZamrazeniXY[j, 1];
                        MozneSkoky++;
                    }
                }
                return SouradniceSkokuYX;
            }
            else if (FigurkaXYZF[3] == Kral && FigurkaXYZF[2] == NezmrazenaFigurka)
            {
                int[,] SouradniceSkokuYX = MozneTahy(FigurkaXYZF);//ulozeni mozneho pohybu figurky
                return SouradniceSkokuYX;
            }
            else
            {
                MozneSkoky = 0;
                int[,] SouradniceSkokuYX = new int[2, 2];
                return SouradniceSkokuYX;
            }
        }

    }
}
