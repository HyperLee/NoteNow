using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace NoteNow;

class Program
{
    /// <summary>
    /// 594. Longest Harmonious Subsequence
    /// https://leetcode.com/problems/longest-harmonious-subsequence/description/?envType=daily-question&envId=2025-06-30
    /// 594. 最長和諧子序列
    /// https://leetcode.cn/problems/longest-harmonious-subsequence/description/?envType=daily-question&envId=2025-06-30
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        var solution = new Program();

        // 測試案例 1: [1,3,2,2,5,2,3,7]
        int[] nums1 = { 1, 3, 2, 2, 5, 2, 3, 7 };
        int result1 = solution.FindLHS(nums1);
        Console.WriteLine($"測試案例 1: [{string.Join(",", nums1)}]");
        Console.WriteLine($"結果: {result1}");
        Console.WriteLine($"說明: 最長和諧子序列是 [3,2,2,2,3]，長度為 5\n");

        // 測試案例 2: [1,2,3,4]
        int[] nums2 = { 1, 2, 3, 4 };
        int result2 = solution.FindLHS(nums2);
        Console.WriteLine($"測試案例 2: [{string.Join(",", nums2)}]");
        Console.WriteLine($"結果: {result2}");
        Console.WriteLine($"說明: 有多個長度為 2 的和諧子序列，如 [1,2]、[2,3]、[3,4]\n");

        // 測試案例 3: [1,1,1,1]
        int[] nums3 = { 1, 1, 1, 1 };
        int result3 = solution.FindLHS(nums3);
        Console.WriteLine($"測試案例 3: [{string.Join(",", nums3)}]");
        Console.WriteLine($"結果: {result3}");
        Console.WriteLine($"說明: 所有元素相同，無法形成和諧子序列\n");

        // 測試案例 4: [1,3,2,2,5,2,3,7,1]
        int[] nums4 = { 1, 3, 2, 2, 5, 2, 3, 7, 1 };
        int result4 = solution.FindLHS(nums4);
        Console.WriteLine($"測試案例 4: [{string.Join(",", nums4)}]");
        Console.WriteLine($"結果: {result4}");
        Console.WriteLine($"說明: 包含重複元素的更複雜案例");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindLHS(int[] nums)
    {
        var count = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (count.ContainsKey(num))
            {
                count[num]++;
            }
            else
            {
                count[num] = 1;
            }
        }

        var maxLength = 0;
        foreach (var key in count.Keys)
        {
            if (count.ContainsKey(key + 1))
            {
                maxLength = Math.Max(maxLength, count[key] + count[key + 1]);
            }
        }

        return maxLength;
    }


}
