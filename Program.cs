using System;
using System.Collections.Generic;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Program();
            //Console.WriteLine(p1.ques3());
            //Console.WriteLine(p1.ques5());
            ques1(5);
        }
       private static void ques1(int n)
        {
            int i = 0, j = 0, l = 1,k=0;
            for(i=1;i<=n;i++)
            {
                for(j=n;j>=i;j--)
                {
                    Console.Write(" ");
                }
                for(k=1;k<=l;k++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
                l = l + 2;
            }
        }
                    
        public void ques2()
            {
                Console.WriteLine("How many pell numbers you want to print");
                var n = Convert.ToInt32(Console.ReadLine());
                var pellList = new List<int> { 0, 1 };
                for (int i = 2; i < n; i++)
                {
                    var nextNum = 2 * pellList[i - 1] + pellList[i - 2];
                    pellList.Add(nextNum);
                }
                for (int i = 0; i < n; i++)
                {
                    Console.Write(pellList[i]);
                    if (i != n - 1)
                        Console.Write(',');
                }
            }

        public bool ques3()
        {
            int i, j;
            Console.WriteLine("enter a number");
            int num = Convert.ToInt32(Console.ReadLine());
            for(i=0;i<num;i++)
            {
                for(j=num;j>0;j--)
                {
                    if(i*i+j*j == num)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int ques5()
        {
            string condval;
            int val;
            var emailList = new List<string>();
            var strlist = new List<string>();
            do
            {
                Console.WriteLine("enter a email address");
                var email = Console.ReadLine();
                emailList.Add(email);
                Console.WriteLine("Do you want to enter other email. Please enter Y/N");
                condval = Console.ReadLine();
            } while (condval=="y" || condval=="Y");
            foreach(var item in emailList)
            {
                string[] subs=item.ToLower().Split('@');
                var firststr=subs[0].Replace(".","");
                var secondstr = firststr.Split('+');
                if (strlist.Contains(secondstr[0] + '@' + subs[1]))
                    continue;
                strlist.Add(secondstr[0] + '@' + subs[1]);
            }
            return strlist.Count;
                
        }





        
    }
}
