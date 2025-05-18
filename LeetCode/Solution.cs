using System.Formats.Asn1;
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
    
    // LeetCode Daily 2094. Finding 3-Digit Even Numbers
    public int[] FindEvenNumbers(int[] digits) { // Not best but working and easy to understand method

        var hs = new HashSet<int>();
        int n = digits.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    if(i == j || i == k || j == k) continue;
                    int num = digits[i] * 100 + digits[j] * 10 + digits[k];
                    if (num >= 100 && num % 2 == 0)
                    {
                        hs.Add(num);
                    }
                }
            }
        }
        var nums = hs.ToList();
        nums.Sort();
        return nums.ToArray();

    }
    
    // LeetCode Daily 3335. Total Characters in String After Transformations I
    public int LengthAfterTransformations(string s, int t) { // zxyz, 3
        int[] cnt = new int[26];
        foreach (var ch in s)
        {
            cnt[ch - 'a']++;
        }

        int zIndex = 25;
        for (int i = 0; i < t; i++)
        {
            int next = (1 + zIndex) % 26; // 0: next = 0, 1: next = 25, 2: next = 24
            cnt[next] = (cnt[next] + cnt[zIndex]) % MOD; // 0: cnt[0] = (cnt[0]=(0) + cnt[25] = 2) = 2 , 1: cnt[25] = (cnt[25]=2 + cnt[24]=1) = 3, 2: cnt[24] = (cnt[24]=1 + cnt[23] = 1), cnt[23]=1, sum = 8
            zIndex = ((zIndex - 1) + 26) % 26; // 0: zindex = 24, 1: zindex = 23...
        }
        
        int ans = 0;
        foreach (var c in cnt)
        {
            ans = (ans + c) % MOD; 
        }
        return ans;
    }

    // LeetCode Daily 3337. Total Characters in String After Transformations II
    
    private const int MOD = (int)1e9 + 7;
    private const int L = 26;

    private class Matrix
    {
        public int[,] a = new int[L, L];

        public Matrix() { }

        public Matrix(Matrix m)
        {
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < L; j++)
                {
                    this.a[i, j] = m.a[i, j];
                }
            }
        }

        public Matrix Multiply(Matrix m)
        {
            Matrix result = new Matrix();
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < L; j++)
                {
                    for (int k = 0; k < L; k++)
                    {
                        result.a[i, j] = (int)((result.a[i,j] + (long)this.a[i, k] * m.a[k, j]) % MOD);
                    }
                }
            }
            return result;
        }
    }

    private Matrix I()
    {
        Matrix m = new Matrix();
        for (int i = 0; i < L; i++)
        {
            m.a[i, i] = 1;
        }
        return m;
    }

    private Matrix QuickMultiply(Matrix x, int y)
    {
        // iterative exp squaring
        Matrix answer = I();
        Matrix current = new Matrix(x);
        while (y > 0)
        {
            if ((y & 1) == 1)
            {
                answer = answer.Multiply(current);
            }
            current = current.Multiply(current);
            y >>= 1;
        }
        return answer;
    }
    public int LengthAfterTransformations(string s, int t, IList<int> nums) {
        Matrix T = new Matrix();
        int[] freq = new int[L];
        int ans = 0;
        
        for (int i = 0; i < L; i++)
        {
            for (int j = 1; j <= nums[i]; j++)
            {
                T.a[(i + j) % L, i] = 1;
            }
        }
        
        Matrix subRes = QuickMultiply(T, t);

        foreach (var ch in s)
        {
            freq[ch - 'a']++;
        }


        for (int i = 0; i < L; i++)
        {
            for (int j = 0; j < L; j++)
            {
                ans = (int)((ans + (long)subRes.a[i, j] * freq[j]) % MOD);
            }
        }

        return ans;
    }
    
    // 217. Contains Duplicate
    public bool ContainsDuplicate(int[] nums) {
        return new HashSet<int>(nums).Count != nums.Length;;
    }
    
    // 219. Contains Duplicate II
    
    public bool ContainsNearbyDuplicate(int[] nums, int k) // [1, 0, 1, 1], k = 1
    {
        Dictionary<int, int> dict = new(nums.Length);

        for (int i = 0; i < nums.Length; i++)
        {
            if (!dict.TryAdd(nums[i], i))
            {
                if ( Math.Abs(dict[nums[i]] - i) <= k )
                {
                    return true;
                }
                else
                {
                    dict[nums[i]] = i;
                }
            }
        }
        return false;
    }
    
    // 242. Valid Anagram
    
    public bool IsAnagram(string s, string t) {
        var firstDict = new Dictionary<char, int>();
        var secondDict = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if(!firstDict.TryAdd(c, 1))
                firstDict[c]++;
        }

        foreach (var c in t)
        {
            if(!secondDict.TryAdd(c, 1))
                secondDict[c]++;
        }
        if (firstDict.Count != secondDict.Count) return false;
        var keys1 = firstDict.Keys;

        foreach (var key in keys1)
        {
            if(!secondDict.TryGetValue(key, out var value)) return false;
            if(firstDict[key] != value) return false;
        }
        return true;
    }
    
    // LeetCode 1. Two Sum
    
    public int[] TwoSum(int[] nums, int target) { // [3,2,4], 6
        var cache = new Dictionary<int, int>();
        int[] ans = new int[2];
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            int needNum = target - nums[i];

            if (cache.TryGetValue(needNum, out var value))
            {
                ans[0] = value;
                ans[1] = i;
                break;
            }
            if(!cache.ContainsKey(nums[i])) cache.Add(nums[i], i);
        }
        return ans;
    }
    
    // LeetCode Daily 2900. Longest Unequal Adjacent Groups Subsequence I
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) { // ["a","b","c","d"] [1,0,1,1]
        var ans = new List<string>();
        int j = 0;
        ans.Add(words[j]);
        int n = groups.Length;

        for (int i = 1; i < n; i++)
        {
            if (groups[i] != groups[j])
            {
                ans.Add(words[i]);
                j = i;
            }
        }
        return ans;
    }
    
    // LeetCode 849. Maximize Distance to Closest Person
    public int MaxDistToClosest(int[] seats) {
        var maxDistance = 0;
        var countZeros = 0;
        for(var i = 0; i < seats.Length; i ++)
        {
            int currentDistance;
            if(seats[i] == 0)
                countZeros++; 
        
            if(seats[i] == 1 || i == seats.Length - 1)
            {
                if(i != 0 && i == countZeros || seats[i] == 0 && i == seats.Length - 1)
                    currentDistance = countZeros;
                else
                    currentDistance = (countZeros + 1)/2;

                if(currentDistance > maxDistance)
                    maxDistance = currentDistance;

                countZeros = 0;    
            }
        }
        
        return maxDistance;
    }
    
    // LeetCode 167. Two Sum II - Input Array Is Sorted
    
    public int[] TwoSum_2(int[] numbers, int target) {
        int n = numbers.Length;
        int left = 0;
        int right = n - 1;
        int[] ans = new int[2];
        while(left < right){
            if(numbers[left] + numbers[right] == target){
                ans[0] = ++left;
                ans[1] = ++right;
                break;
            }
            if(numbers[left] + numbers[right] > target) right--;
            if(numbers[left] + numbers[right] < target) left++;
        }

        return ans;
    }
    
    // 2. Add Two Numbers
    
   //Definition for singly-linked list.
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int carry = 0;
        ListNode ans = new ListNode();
        ListNode curr = ans;

        while(l1 != null || l2 != null || carry != 0){
            int l1Val = (l1 != null) ? l1.val : 0;
            int l2Val = (l2 != null) ? l2.val : 0;
            int sum = l1Val + l2Val + carry;
            carry = sum / 10;
            curr.next = new ListNode(sum % 10);
            curr = curr.next;
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        return ans.next;
    }
    
    // LeetCode 415. Add Strings
    
    public string AddStrings(string num1, string num2) {
        int n1 = num1.Length - 1;
        int n2 = num2.Length - 1;
        int carry = 0;
        var ans = new StringBuilder();
        while(n1 >= 0 || n2 >= 0 || carry > 0){
            int x = (n1 >= 0) ? num1[n1] - '0' : 0;
            int y = (n2 >= 0) ? num2[n2] - '0' : 0;
            int sum = x + y + carry;
            carry = sum / 10;
            ans.Append((sum%10).ToString());
            n1--;
            n2--;
        }

        char[] chrarr = ans.ToString().ToCharArray();
        Array.Reverse(chrarr);
        return new string(chrarr);
    }
    
    // LeetCode Fucking Paywall 1213. Intersection of Three Sorted Arrays

    public int[] ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
    {
        var res = new List<int>();

        int i = 0, j = 0, k = 0;

        while (i < arr1.Length && j < arr2.Length && k < arr3.Length)
        {
            if (arr1[i] == arr2[j] && arr2[j] == arr3[k])
            {
                res.Add(arr1[i]);
                i++;
                j++;
                k++;
            }
            else
            {
                int minVal = Math.Min(arr1[i], Math.Min(arr2[j], arr3[k]));
                if (arr1[i] == minVal) i++;
                if (arr2[j] == minVal) j++;
                if (arr3[k] == minVal) k++;
            }
        }
        return res.ToArray();
    }
    
    // LeetCode Daily 2901. Longest Unequal Adjacent Groups Subsequence II
    
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups) {
        var n = groups.Length;
        int[] dp = new int[n];
        int[] prev = new int[n];
        Array.Fill(dp, 1);
        Array.Fill(prev, -1);
        int maxIndex = 0;

        for(var i = 1; i < n; i++){
            for(var j = 0; j < i; j++){
                if (Check(words[i], words[j]) && dp[j]+1 > dp[i] && groups[i] != groups[j]){
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }
            if(dp[i] > dp[maxIndex]){
                maxIndex = i;
            }
        }

        var ans = new List<string>();
        for(var i = maxIndex; i >= 0; i = prev[i]){
            ans.Add(words[i]);
        }
        ans.Reverse();
        return ans;
    }

    private bool Check(string s1, string s2){
        if(s1.Length != s2.Length){
            return false;
        }
        int diff = 0;
        for(var i = 0; i < s1.Length; i++){
            if(s1[i] != s2[i]){
                if(++diff > 1){
                    return false;
                }
            }
        }
        return diff == 1;
    }
    
    // LeetCode Daily 75. Sort Colors
    
    public void SortColors(int[] nums) {
        int n = nums.Length;
        int reds = 0;
        int whites = 0;
        int blues = 0;
        for(int j = 0; j < n; j++){
            switch(nums[j]){
                case 0:
                    reds++;
                    break;
                case 1:
                    whites++;
                    break;
                case 2:
                    blues++;
                    break;
            }
        }
        int i = 0;
        while(reds > 0 || whites > 0 || blues > 0){
            if(reds > 0) {
                nums[i] = 0;
                i++;
                reds--;
                continue;
            }
            if(whites > 0) {
                nums[i] = 1;
                i++;
                whites--;
                continue;
            }
            if(blues > 0) {
                nums[i] = 2;
                i++;
                blues--;
                continue;
            }
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // Yandex Top-100 Section
    
    
    // 1. Line Reflection
    public bool IsReflected(int[][] points)
    {
        HashSet<string> pointSet = new HashSet<string>();
        
        int? minX = null, maxX = null;

        foreach (var point in points)
        {
            int x = point[0];
            int y = point[1];

            string key = x + "," + y;
            pointSet.Add(key);
            
            if(minX == null || x < minX) minX = x;
            if(maxX == null || x > maxX) maxX = x;
        }
        
        if(pointSet.Count == 0) return true;
        
        
        double sum = (double)minX! + (double)maxX!;

        foreach (var po in points)
        {
            int x = po[0];
            int y = po[1];

            double refX = sum - x;
            string refKey = refX + "," + y;

            if (!pointSet.Contains(refKey)) return false;
        }
        return true;
    }
    
    
    
    
    
}