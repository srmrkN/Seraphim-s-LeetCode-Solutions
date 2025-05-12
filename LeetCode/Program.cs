using System.Text;
using LeetCode;

var sol = new Solution();
int[] arr = {6, 5, 4, 3, 2, 1 };
sol.Sort(arr, 0, arr.Length - 1);
foreach (var i in arr)
    Console.WriteLine(i);