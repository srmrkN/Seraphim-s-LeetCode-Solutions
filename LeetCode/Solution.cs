using System.Numerics;
using System.Text;

namespace LeetCode;

public class Solution
{
    // LeetCode Daily 2176. Count Equal and Divisible Pairs in an Array
    public int CountPairs(int[] nums, int k)
    {

        int counter = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j] && i * j % k == 0)
                {
                    counter++;
                }
            }
        }
        return counter;
    }
    
    // LeetCode 20. Valid Parentheses
    public bool IsValid(string s) // ({)}
    {
        Stack<char> stack = new Stack<char>();

        foreach (var c in s)
        {
            if(c == '(' || c == '{' || c == '[') stack.Push(c);
            else
            {
                if (stack.Count == 0) return false;
                if (c == ')' && stack.Pop() != '(') return false;
                if (c == '}' && stack.Pop() != '{') return false;
                if (c == ']' && stack.Pop() != '[') return false;
            }
        }
        return stack.Count == 0;
    }
    
    // LeetCode 26 Remove Duplicates

    public int RemoveDuplicates(int[] nums) // 0,0,1,1,1,2,2,3,3,4
    {
        if (nums.Length == 0) return 0;

        int j = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != nums[j]) nums[++j] = nums[i];
        }
        return j + 1;
    }
    
    // LeetCode 27 Remove Element

    public int RemoveElement(int[] nums, int val) // 0,1,2,2,3,0,4,2 val = 2 
    {



        int j = 0; 
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[j++] = nums[i];
            }
        }
        return j;
    }
    
    
    
    // LeetCode 28 Find the Index of the First Occurrence in a String
    
    public int StrStr(string haystack, string needle) {
        var heystackLen = haystack.Length;      // 
        var needleLen = needle.Length;          // 

        int j = 0;
        for (int i = 0; i < heystackLen; i++)
        {
            if (haystack[i] != needle[j])
            {
                if (j > 0) i -= j;
                j = 0;
            }
            else
            {
                j++;
                if (j == needleLen) return i + 1 - needleLen;
            }
        }

        return -1;
    }
    
    // LeetCode Daily 2563. Count the Number of Fair Pairs
    
    public long CountFairPairs(int[] nums, int lower, int upper) { // 0,1,7,4,4,5 , lower = 3, upper = 6
        Array.Sort(nums); // 0 1 4 4 5 7
        
        return LowerBound(nums, upper + 1) - LowerBound(nums, lower);
    }

    private long LowerBound(int[] nums, int value)
    {
        int left = 0;
        int right = nums.Length - 1;
        
        long result = 0;
        
        while(left < right)
        {
            int sum = nums[left] + nums[right];

            if (sum < value)
            {
                result += (right - left);
                left++;
            }
            else right--;
        }
        return result;
    }

    // LeetCode 2824. Count Pairs Whose Sum is Less than Target

    public int CountPairs2(IList<int> nums, int target) // [-1,1,2,3,1], target = 2
    {
        var arr = nums.ToArray();
        Array.Sort(arr);
        var count = 0;
        int i = 0;
        int j = arr.Length - 1;

        while (i < j)
        {
            if (arr[i] + arr[j] < target)
            {
                count = count + (j - i);
                i++;
            }

            else j--;
        }
        
        return count;
    }
    
    // LeetCode 35. Search Insert Position
    
    public int SearchInsert(int[] nums, int target) { // 1 3 5 6 8  7 mid = 2
        
        int left = 0;
        var mid = 0;
        int right = nums.Length - 1; // 4

        while (left <= right)
        {
            mid = left + (right - left) / 2;
            if(nums[mid] == target) return mid;
            else if(nums[mid] > target) right = mid - 1;
            else left = mid + 1;
        }

        if (target < nums[mid]) return mid;
        else return mid + 1;
    }

    // LeetCode 50. Pow(x, n)

    public double MyPow(double x, int n)
    {
        if (n == 0) return 1;

        long exp = n;
        if (exp < 0)
        {
            x = 1 / x;
            exp = -exp;
        }

        var val = 1.0;
        var bas = x;

        while (exp > 0)
        {
            if (exp % 2 == 1)
            {
                val *= bas;
            }

            bas *= bas;
            exp /= 2;
        }
        return val;
    }
    
    // LeetCode 58. Length of Last Word
    public int LengthOfLastWord(string s)
    {
        int count = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if(s[i] == ' ' && count != 0) return count;
            if (s[i] != ' ')
            {
                count++;
            }
        }
        return count;
    }
    
    // LeetCode 66. Plus One
    
    public int[] PlusOne(int[] digits) { // 19 -> 20, 9 -> 10, 99->100  65 -> 66

        if (digits[^1] == 9)
        {
            int carry = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int sum = digits[i] + carry;
                digits[i] = sum % 10;
                carry = sum / 10;
            }

            if (carry == 1)
            {
                var result = new int[digits.Length + 1];
                result[0] = 1;
                return result;
            }
            else return digits;
        }

        else
        {
            digits[^1]++;
            return digits;
        }
    }
    
    // LeetCode 67. Add Binary

    public string AddBinary(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        var res = new List<char>();

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int digitA = i >= 0 ? a[i] - '0' : 0;
            int digitB = j >= 0 ? b[j] - '0' : 0;
            int sum = digitA + digitB + carry;
            
            res.Add((char)('0' + (sum % 2)));
            carry = sum / 2;
            i--;
            j--;
        }
        char[] resArray = res.ToArray();
        Array.Reverse(resArray);
        return new string(resArray);
    }
    
    // LeetCode 70. Climbing Stairs
    
    public int ClimbStairs(int n) {
        if(n <= 3) return n;

        int prev1 = 3;
        int prev2 = 2;
        int current = 0;
        for (int i = 3; i < n; i++)
        {
            current = prev1 + prev2;
            prev1 = prev2;
            prev2 = current;
        }
        return current;
    }
    
    // LeetCode 69. Sqrt(x)
    
    public int MySqrt(int x) // 2147483647
    {
        if (x == 1 || x == 0) return x;


        long start = 1;
        long end = x;
        long mid = -1;
        int ans = -1;
        while (start <= end)
        {
            mid = start + (end - start) / 2;

            if ((long)mid * mid > x) end = mid - 1;
            if(mid * mid < x) start = mid + 1;
            if (mid * mid <= x && ((mid+1)*(mid+1)) > x) 
            {
                ans = (int)mid;
                break;
            }
        }

        return ans;
    }

    // LeetCode 509. Fibonacci Number
    public BigInteger Fibonacci(int n)
    {

        if (n == 0) return 0;

        BigInteger a = 0;
        BigInteger b = 1;
        BigInteger c = a + b;

        for (int i = 2; i < n - 1; i++)
        {
            a = b;
            b = c;
            c = a + b;
        }

        return c;
    }
    
    // LeetCode 1137. N-th Tribonacci Number
    
    public int Tribonacci(int n) {
        if (n == 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 1;
        int a = 0;
        int b = 1;
        int c = 1;
        int d = a + b + c;

        for (int i = 3; i < n; i++)
        {
            a = b;
            b = c;
            c = d;
            d = a + b + c;
        }

        return d;
    }
    
    // Stepik Fibonacci Last Digit
    public int FibonacciLastDigit(int n)
    {
        if (n == 0) return 0;
        int a = 0;
        int b = 1;
        int c = (a + b)%10;
        for (int i = 2; i < n; i++)
        {
            a = b;
            b = c;
            c = (a + b)%10;
        }
        
        return c;
    }
    // Stepik Fibonacci % m

    public int FibonacciM(long n, int m)
    {
        int a = 0;
        int b = 1;
        var list = new List<int>();
        list.Add(a);
        list.Add(b);

        for (int i = 1; i < n; i++)
        {
            int c = b;
            b = (b + a) % m;
            a = c;

            if (a == 0 && b == 1)
            {
                list.RemoveAt(list.Count - 1);
                break;
            }
            list.Add(b);
        }
        

        var k = n % list.Count;
        return list[(int)k];
        
    }
    
    // Leetcode 409. Longest Palindrome

    public int LongestPalindrome(string s)
    {
        var freqDict = new Dictionary<char, int>();
        foreach (var c in s)
        {
            if(!freqDict.ContainsKey(c)) freqDict.Add(c, 1);
            else freqDict[c]++;
        }

        int res = 0;
        bool hadOddFreq = false;

        foreach (var val in freqDict.Values)
        {
            if (val % 2 == 0)
            {
                res += val;
            }
            else
            {
                res += val - 1;
                hadOddFreq = true;
            }
        }
        
        return hadOddFreq ? res+1 : res;
    }
    
    // QuickSort
    public void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            Sort(arr, low, pi - 1);
            Sort(arr, pi + 1, high);
        }
    }

    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Console.WriteLine($"swapping {arr[i]} -> {arr[j]}");
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }

        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        Console.WriteLine($"returning {i+1}");
        return i + 1;
    }
}