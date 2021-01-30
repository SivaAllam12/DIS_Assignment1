using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
                Console.WriteLine();
            }

            //Question 4:
            int[] arr = { 1,2,3,4,5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);
            Console.WriteLine();

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);
            Console.WriteLine();

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" }, { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }

        private static void printTriangle(int n)
        {
            try
            {
                int i = 0, j = 0, l = 1, k = 0;
                for (i = 1; i <= n; i++)
                {
                    for (j = n; j >= i; j--)
                    {
                        Console.Write(" ");
                    }
                    for (k = 1; k <= l; k++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();
                    l = l + 2;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        private static void printPellSeries(int n2)
        {
            try
            {
                var pellList = new List<int> { 0, 1 };
                for (int i = 2; i < n2; i++)
                {
                    var nextNum = 2 * pellList[i - 1] + pellList[i - 2];
                    pellList.Add(nextNum);
                }
                for (int i = 0; i < n2; i++)
                {
                    Console.Write(pellList[i]);
                    if (i != n2 - 1)
                        Console.Write(',');
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        private static bool squareSums(int n3)
        {
            try
            {
                int i, j;
                for (i = 0; i < n3; i++)
                {
                    for (j = n3; j > 0; j--)
                    {
                        if (i * i + j * j == n3)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch(Exception)
            {
                throw;
            }
               
        }
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                // write your code here.
                Array.Sort(nums);
                Array.Reverse(nums);
                int count=0;
                var tupleList = new List<(int, int)>();
                for (int i=0;i<nums.Length-1;i++)
                {
                    for(int j=i+1;j<=nums.Length-1;j++)
                    {
                        if(k==nums[i]-nums[j])
                        {
                            if (!tupleList.Contains((nums[i], nums[j])))
                            {
                                tupleList.Add((nums[i], nums[j]));
                                count++;

                            }
                        }
                    }
                }

              return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static int UniqueEmails(List<string> emails)
        {
            try
            {
     
                var strlist = new List<string>();
             
                foreach (var item in emails)
                {
                    string[] subs = item.ToLower().Split('@');
                    var firststr = subs[0].Replace(".", "");
                    var secondstr = firststr.Split('+');
                    if (strlist.Contains(secondstr[0].Trim() + '@' + subs[1]))
                    {
                        continue;
                    }
                    strlist.Add(secondstr[0].Trim() + '@' + subs[1]);
                }
                return strlist.Count;
            }
            catch(Exception)
            {
                throw;
            }
        }
        private static string DestCity(string[,] paths)
        {
            try
            {
                string dest = paths[0, 1];
                for (int i = 1; i < 3; i++)
                {
                    if (dest == paths[i, 0])
                    {
                        dest = paths[i, 1];
                        i = 0;
                    }

                }
                return dest;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


    }
}


                





        
