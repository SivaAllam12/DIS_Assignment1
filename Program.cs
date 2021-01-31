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
            int[] arr = { 3, 1, 4, 1, 5 };
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
                //start a loop from 1 to n to print lines
                for (i = 1; i <= n; i++)
                {
                    //start a loop from n to i
                    for (j = n; j >= i; j--)
                    {
                        //print the spaces
                        Console.Write(" ");
                    }
                    for (k = 1; k <= l; k++)
                    {
                        //print the stars
                        Console.Write('*');
                    }
                    //change the cursor to next line
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
                //initialize pell list with 0 and 1
                var pellList = new List<int> { 0, 1 };
                for (int i = 2; i < n2; i++)
                {
                    //Calcualte next number in pell series
                    var nextNum = 2 * pellList[i - 1] + pellList[i - 2];
                    //Add the number to the list
                    pellList.Add(nextNum);
                }
                for (int i = 0; i < n2; i++)
                {
                    //display the numbers in pell list
                    Console.Write(pellList[i]);
                    //put comma after each number
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
                //start a loop starts from zero till the given number
                for (i = 0; i < n3; i++)
                {
                    //start a loop from given number to zero
                    for (j = n3; j > 0; j--)
                    {
                        //checked squares of both numbers if it equals to given number or not
                        if (i * i + j * j == n3)
                        {
                            //return true if it matches and come out of loop
                            return true;
                        }
                    }
                }
                //return false if the given num cant be expressed as squareSums of squares
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
                //sort the given numbers in ascending orders
                Array.Sort(nums);
                //reverse the list to get numbers in descending order
                Array.Reverse(nums);
                //initialize a counter
                int count=0;
                //initialize a tuple list to store pair of numbers
                var tupleList = new List<(int, int)>();
                //start a loop for given numbers
                for (int i=0;i<nums.Length-1;i++)
                {
                    //start another loop for given numbers
                    for(int j=i+1;j<=nums.Length-1;j++)
                    {
                        //check whether given difference matches the obtained difference
                        if(k==nums[i]-nums[j])
                        {
                            //check whether list contains the pair if not increase the count
                            if (!tupleList.Contains((nums[i], nums[j])))
                            {
                                //add the pair to the list
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
                //initialize a empty list to store the required emails 
                var strlist = new List<string>();
             
                //travesrse through given list of emails
                foreach (var item in emails)
                {
                    //split the email into two parts with @ symbol
                    string[] subs = item.ToLower().Split('@');
                    //remove the "." character in the email
                    var firststr = subs[0].Replace(".", "");
                    //split the obtained email into two parts with + symbol
                    var secondstr = firststr.Split('+');
                    //chek whether email already present or not
                    if (strlist.Contains(secondstr[0].Trim() + '@' + subs[1]))
                    {
                        continue;
                    }
                    //add the email to the list
                    strlist.Add(secondstr[0].Trim() + '@' + subs[1]);
                }
                //take the count of list and return it
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
                //assume the 1st row 1st element as destination
                string dest = paths[0, 1];
                //LoaderOptimization through the elements in the array
                for (int i = 1; i < paths.GetLength(0); i++)
                {
                    //checked whether the dest is coming in origin or not
                    if (dest == paths[i, 0])
                    {
                        //change the destination 
                        dest = paths[i, 1];
                        //make variable i as 0 to check again from the start of array
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


                





        
