
//Öğrenci Adı: İclal Alagöz
//Numara: B211200051
//Bölüm: Bilişim Sistemleri Mühendisliği
//Sınıf: 1.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace b211200051
{
    class KafaTopu
    {
        int width;
        int height;
        Saha saha;
        Oyuncular Oyuncu1;
        Oyuncular Oyuncu2;
        ConsoleKeyInfo keyInfo;
        ConsoleKey ConsoleKey;
        Top top;

        public KafaTopu(int heigth,int width)
        { 
            this.height = heigth;
            this.width = width;
            saha = new Saha(height, width);
            top = new Top(height / 2, width / 2,height,width);
        }

        public void Setup()
        {
            Oyuncu1 = new Oyuncular(2, height);
            Oyuncu2 = new Oyuncular(width - 2, height);
            keyInfo = new ConsoleKeyInfo();
            ConsoleKey = new ConsoleKey();
            top.X = width / 2;
            top.Y = height / 2;
            top.Yon = 0;
        }

        void Input() 
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                ConsoleKey = keyInfo.Key;

            }
        }

        public void Run() 
        {
            while (true)
            {
                Console.Clear();
                Setup();
                saha.çiz();
                Oyuncu1.Yaz();
                Oyuncu2.Yaz();
                top.Yaz();
                while (top.X!=1 && top.X != width-1)
                {
                    Input();
                    switch(ConsoleKey)
                    {
                        case ConsoleKey.W:
                            Oyuncu1.Up();
                            break;
                        case ConsoleKey.UpArrow:
                            Oyuncu2.Up();
                            break;
                        case ConsoleKey.S:
                            Oyuncu1.Down();
                            break;
                        case ConsoleKey.DownArrow:
                            Oyuncu2.Down();
                            break;
                    }
                    ConsoleKey = ConsoleKey.A;
                    top.Logic(Oyuncu1,Oyuncu2);
                    top.Yaz();
                    Thread.Sleep(100);
                    
                }
               
           
            }
        }
    }
  

    class Top
    {
        public int X { get; set; }
        public int Y { get; set; }
        int DonusX;
        int DonusY;
        int i;
        int SahaHeight;
        int SahaWidth;


        public int Yon { set; get; }

        public Top(int x, int y,int SahaHeight,int SahaWidth)
        {
            X = x;
            Y = y;
            this.SahaHeight = SahaHeight;
            this.SahaWidth = SahaWidth;
            DonusX = -1;
            DonusY = -1;
        }
        
        public void Logic(Oyuncular oyuncu1, Oyuncular oyuncu2)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("\0");
            if(Y<=1 || Y >= SahaHeight)
            {
                DonusY *= -1;
            }
            if (((X == 3 || X == SahaWidth - 3) && (oyuncu1.Y - (oyuncu1.Lenght / 2)) <= Y && (oyuncu1.Y + (oyuncu1.Lenght / 2)) > Y))
            {
                DonusX *= -1;
                if (Y == oyuncu1.Y)
                {
                    Yon = 0;
                }
                if ((Y >= (oyuncu1.Y - (oyuncu1.Lenght / 2)) && Y < oyuncu1.Y || (Y > oyuncu1.Y && Y < (oyuncu1.Y + (oyuncu1.Lenght / 2)))))
                {
                    Yon = 1;
                }
            }
                switch(Yon)
                {
                    case 0:
                        X += DonusX;
                        break;
                    case 1:
                        X += DonusX;
                        Y += DonusY;
                        break;


                }
            
        }

        public void Yaz() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(X, Y);
            Console.Write("O");
            Console.ForegroundColor = ConsoleColor.White;
        } 
    }


        class Oyuncular
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int Lenght { set; get; }

        int SahaHeight;
        public Oyuncular(int x , int SahaHeight)
        {
            this.SahaHeight = SahaHeight;
            X = x;
            Y=SahaHeight/2;
            Lenght = SahaHeight / 3;

        }

        public void Up() 
        {
            if ((Y - 1 - (Lenght / 2)) != 0)
            {
                Console.SetCursorPosition(X, (Y + (Lenght / 2)) - 1);
                Console.Write("\0");
                Y--;
                Yaz();
            }

        }
        public void Down ()
        {
            if((Y+1+(Lenght/2))!=SahaHeight+2)
            {
                Console.SetCursorPosition(X, (Y - (Lenght / 2)));
                Console.Write("\0");
                Y++;
                Yaz();
            }
        }

        public void Yaz ()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for(int i = (Y - (Lenght / 2)); i < (Y + (Lenght / 2)); i++) 
            {
                Console.SetCursorPosition(X, i);
                Console.Write("│");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
    public class score
    {
        public int maxWidth { set; get; }
        public int minHWidth { set; get; }
        public score()
        {
            maxWidth = 60;
            minHWidth = 0;
        }
        public score(int maxwidth, int minwidth)
        {
            maxWidth = maxwidth;
            minHWidth = minwidth;
        }
        public void scoretablo()
        {
            if (maxWidth == 60)
            {
                Console.SetCursorPosition(maxWidth, 0);
                Console.Write("oyuncu 1 = 1");
            }
        }

    }
}
    public class Saha 
    {
        public int Height { set; get;}
        public int Width { set; get; }

        public Saha()
        {
            Height = 20;
            Width = 60;
        }

        public Saha(int height, int width) 
        {
            Height = height;
            Width = width;
        }
        public void çiz() 
        {
            for (int i=1; i<=Width;i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("─");
            }
            for(int i=1;i<=Width;i++)
            {
                Console.SetCursorPosition(i,(Height + 1));
                Console.Write("─");
            }
            for(int i=1;i<=Height;i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("│");
            }
            for (int i =1;i<=Height;i++)
            {
                Console.SetCursorPosition((Width+1),i);
                Console.Write("│");
            }

            Console.SetCursorPosition(0,0);
            Console.Write("┌");
            Console.SetCursorPosition(Width + 1,0);
            Console.Write("┐");
            Console.SetCursorPosition(0,Height+1);
            Console.Write("└");
            Console.SetCursorPosition(Width+1,Height+1);
            Console.Write("┘");
        
        }
    
    }
}
