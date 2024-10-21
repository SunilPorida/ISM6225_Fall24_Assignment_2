using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                // Creating a list to store missing numbers
                IList<int> missings = new List<int>();

                // To get the highest possible number
                int maxNum = nums.Length;

                // To make a list for numbers from 1 to maxNum
                bool[] seen = new bool[maxNum + 1];

                foreach (int num in nums)
                {
                    if (num <= maxNum)
                    {
                        seen[num] = true;
                    }
                }

                // Check which numbers are missing and add them to our list
                for (int i = 1; i <= maxNum; i++)
                {
                    if (!seen[i])
                    {
                        missings.Add(i);
                    }
                }

                // Return the list of missing numbers
                return missings;
            }

            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                int[] result = new int[nums.Length];
                int evenIndex = 0;

                // Place the even numbers at the front
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        result[evenIndex] = nums[i];
                        evenIndex++;
                    }
                }

                // Place the odd numbers in remaining positions
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 != 0)
                    {
                        result[evenIndex] = nums[i];
                        evenIndex++;
                    }
                }

                // Return the sorted array
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                // Create a dictionary
                Dictionary<int, int> seenNumbers = new Dictionary<int, int>();

                // Go through each number from the array
                for (int i = 0; i < nums.Length; i++)
                {
                    int currentNumber = nums[i];
                    int neededNumber = target - currentNumber;

                    // Check if we have seen the number we need to reach the target
                    if (seenNumbers.ContainsKey(neededNumber))
                    {
                        // If found, return the indices of the two numbers
                        return new int[] { seenNumbers[neededNumber], i };
                    }

                    // If not found, add the current number and its index to our dictionary
                    if (!seenNumbers.ContainsKey(currentNumber))
                    {
                        seenNumbers.Add(currentNumber, i);
                    }
                }

                // If no solution is found, return an empty array
                return new int[0];

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                // Sort the array in ascending order
                Array.Sort(nums);

                // To get the length of the array
                int n = nums.Length;

                // Product of the three largest numbers
                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

                // Product of the two smallest 
                int product2 = nums[0] * nums[1] * nums[n - 1];

                // Return the larger of the two products
                return Math.Max(product1, product2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here

                if (decimalNumber == 0)
                    return "0";

                // Create a list
                List<int> bits = new List<int>();

                // Keep dividing the number by 2 until it becomes 0
                while (decimalNumber > 0)
                {
                    // Get the remainder and add it to the list
                    bits.Add(decimalNumber % 2);

                    // Divide the number by 2
                    decimalNumber /= 2;
                }

                // Reverse the list 
                bits.Reverse();

                // Join into a single string
                return string.Join("", bits);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here

                if (nums.Length == 1)
                    return nums[0];

                // Set up two pointers
                int left = 0;
                int right = nums.Length - 1;

                // If the array is not rotated, return the first element
                if (nums[left] < nums[right])
                    return nums[left];

                while (left < right)
                {
                    // Find the middle point
                    int mid = left + (right - left) / 2;

                    // If middle element is greater than its next element,
                    // then the next element is the smallest
                    if (nums[mid] > nums[mid + 1])
                        return nums[mid + 1];

                    // If middle element is less than its previous element,
                    // then middle element is the smallest
                    if (nums[mid - 1] > nums[mid])
                        return nums[mid];

                    // If the left half is sorted, the minimum is in the right half
                    if (nums[left] < nums[mid])
                        left = mid + 1;

                    else
                        right = mid - 1;
                }

                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                // If the number is negative, it's not a palindrome
                if (x < 0)
                    return false;

                // Convert the number to a string
                string numStr = x.ToString();

                // Set up two pointers
                int left = 0;
                int right = numStr.Length - 1;

                // Compare characters from both ends
                while (left < right)
                {
                    // If they are not same, it's not a palindrome
                    if (numStr[left] != numStr[right])
                        return false;

                    // Move pointers towards the center
                    left++;
                    right--;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                // If n is 0 or 1, return n
                if (n <= 1)
                    return n;

                // Initialize the first two Fibonacci numbers
                int prev = 0;
                int current = 1;

                // Calculate Fibonacci numbers up to n
                for (int i = 2; i <= n; i++)
                {
                    // Calculate the next Fibonacci number
                    int next = prev + current;
                    prev = current;
                    current = next;
                }

                // Return the nth Fibonacci number
                return current;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
