using System.Text;
using LeetCode;

var sol = new Solution();
int[] arr = { -1, 0, 2, 5, 6 };
foreach (var i in sol.GetLongestSubsequence(["a","b","c","d"], [1,0,1,1]))
{
    Console.WriteLine(i);
}
