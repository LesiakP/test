using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    
   public class Program
    {
        static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
        public class Bob<T>
        {
            public static int Count;
        }



        public struct fullness
        {
            public int frontLeft, backLeft, backRight, frontRight;
            public int frontLeftE, backLeftE, backRightE, frontRightE;
        }

        static fullness check(string[,] raft, int N)
        {
            Console.ReadLine();
            Console.WriteLine("rwrw");
            fullness n = new fullness();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    if (i < N / 2)
                    {
                        if (j < N / 2)
                        {
                            if (raft[i, j] == "D")
                                n.frontLeft++;
                            else if (raft[i, j] == null)
                                n.frontLeftE++;
                        }

                        if (j >= N / 2)
                        {
                            if (raft[i, j] == "D")
                                n.frontRight++;
                            else if (raft[i, j] == null)
                                n.frontRightE++;
                        }
                    }
                    if (i >= N / 2)
                    {
                        if (j < N / 2)
                        {
                            if (raft[i, j] == "D")
                                n.backLeft++;
                            else if (raft[i, j] == null)
                                n.backLeftE++;
                        }

                        if (j >= N / 2)
                        {
                            if (raft[i, j] == "D")
                                n.backRight++;
                            else if (raft[i, j] == null)
                                n.backRightE++;
                        }
                    }

                  
                }
            return n;
        }

        static void blabla(string[,] raft, int iMax, int jMax,int iStart, int jStart, int howMuchAdd)
        {
            for (int i = iStart; i < iMax; i++)
            {
                for (int j = jStart; j < jMax; j++)
                {
                    if (raft[i, j] == null)
                    {
                        raft[i, j] = "D";
                        howMuchAdd--;
                    }
                    if (howMuchAdd == 0)
                        break;
                }
                if (howMuchAdd == 0)
                    break;
            }
        }
        static  int solution3(int N, string S, string T)
        {


            string[,] raft = new string[N, N];

           for(int i=0; i<S.Length-1;i=i+1)
            {
                if(S[i]!=' ')
                {
                    int a = (char)S[i + 1] - 65;
                    int b = int.Parse(S[i].ToString());
                    raft[b-1, a] = "B";
                    i++;
                }
            }
            for (int i = 0; i <T.Length - 1; i = i + 1)
            {
                if (T[i] != ' ')
                {
                    int a = (char)T[i + 1] - 65;
                    int b = int.Parse(T[i].ToString());
                    raft[b - 1, a] = "D";
                    i++;
                }
            }
          
            int rw = 150;

            fullness n = new fullness();
            n = check(raft, N);
            while (rw > 0)
            {
                if (((n.frontLeft + n.frontRight) <= (n.backLeft + n.backRight)) && (n.frontLeftE + n.frontRightE > 0))
                {
                    Console.WriteLine("1");
                    if (((n.frontLeft + n.backLeft) <= (n.frontRight + n.backRight)) && (n.frontLeftE > 0))
                    {
                        Console.WriteLine("1.1");
                        blabla(raft, N / 2, N / 2, 0, 0, 1);
                        n = check(raft, N);
                    }
                    else if (((n.frontRight + n.backRight) <= (n.frontLeft + n.backLeft)) && (n.frontRightE > 0))
                    {
                        Console.WriteLine("1.2");
                        blabla(raft, N / 2, N, 0, N / 2, 1);
                        n = check(raft, N);
                    }

                }

                else if (((n.frontLeft + n.frontRight) >= (n.backLeft + n.backRight)) && (n.backLeft + n.backRight > 0))
                {
                    Console.WriteLine("2");
                    if (((n.frontLeft + n.backLeft) <= (n.frontRight + n.backRight)) && (n.backLeftE > 0))
                    {
                        Console.WriteLine("2.1");
                        blabla(raft, N, N / 2, N / 2, 0, 1);
                        n = check(raft, N);
                    }
                    else if (((n.frontRight + n.backRight) <= (n.frontLeft + n.backLeft)) && (n.backRightE > 0))
                    {
                        Console.WriteLine("2.2");
                        blabla(raft, N, N, N / 2, N / 2, 1);
                        n = check(raft, N);
                    }

                }
                rw--;
            }






            fullness q = new fullness();
            q = check(raft, N);
            //blabla(raft, N / 2, N / 2, 0, 0, 1); //FrontLeft
            //blabla(raft, N / 2, N, 0, N / 2,1); //FrontRight
            //blabla(raft, N, N / 2, N / 2, 0, 1); // BackLeft
            //blabla(raft, N, N, N / 2, N/2, 1); // BackRight
          




            Console.ReadLine();
            return 0;

        }




        static int[] solution2(int[] A, int K)
        {
            int temp = 0;
            while (K > 0)
            {
                for (int i = A.Length - 1; i > 0; i--)
                {
                    temp = A[i];
                    A[i] = A[i - 1];
                    A[i - 1] = temp;
                }
                K--;
            }
            return A;
        }
        static int solution(int N)
        {
            int temp = 0, length = 0;
            while(N % 2 == 0)
                { N = N / 2; }
            while (N > 1)
            {
                if (N % 2 == 0)
                {

                    temp++;
                }

                N = N / 2;
                if (temp > length)
                {
                    length = temp;
                }
                if (N % 2 == 1)
                    temp = 0;

            }

            return length;

        }




        static void Main(string[] args)
        {

            int y = solution3(4, "1B 1C 4B 1D 2A", "3B 2D ");
            int[] tab = { 1,2,3,4,5};
            tab=solution2(tab, 3);
            Console.WriteLine();
            Console.ReadLine();
         
        }
    }
   
    
}
