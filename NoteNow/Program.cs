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
    /// 
    /// 解題概念與出發點：
    /// 和諧子序列的定義是最大值與最小值的差恰好為1的子序列。
    /// 由於差值恰好為1，所以和諧子序列只能由兩種相鄰的數值組成（如2和3，或5和6）。
    /// 
    /// 解題思路：
    /// 1. 使用雜湊表(Dictionary)統計每個數字的出現次數
    /// 2. 遍歷所有數字，檢查是否存在比它大1的數字
    /// 3. 如果存在，計算這兩個數字的總出現次數，更新最大長度
    /// 4. 時間複雜度：O(n)，空間複雜度：O(n)
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        var solution = new Program();

        Console.WriteLine("=== 解法一：雜湊表方法 ===");
        
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
        Console.WriteLine($"說明: 包含重複元素的更複雜案例\n");

        Console.WriteLine("=== 解法二：暴力法 ===");
        
        // 使用相同的測試案例測試解法二
        int result1_2 = solution.FindLHS2(nums1);
        Console.WriteLine($"測試案例 1: [{string.Join(",", nums1)}]");
        Console.WriteLine($"結果: {result1_2}");
        Console.WriteLine($"說明: 最長和諧子序列是 [3,2,2,2,3]，長度為 5\n");

        int result2_2 = solution.FindLHS2(nums2);
        Console.WriteLine($"測試案例 2: [{string.Join(",", nums2)}]");
        Console.WriteLine($"結果: {result2_2}");
        Console.WriteLine($"說明: 有多個長度為 2 的和諧子序列，如 [1,2]、[2,3]、[3,4]\n");

        int result3_2 = solution.FindLHS2(nums3);
        Console.WriteLine($"測試案例 3: [{string.Join(",", nums3)}]");
        Console.WriteLine($"結果: {result3_2}");
        Console.WriteLine($"說明: 所有元素相同，無法形成和諧子序列\n");

        int result4_2 = solution.FindLHS2(nums4);
        Console.WriteLine($"測試案例 4: [{string.Join(",", nums4)}]");
        Console.WriteLine($"結果: {result4_2}");
        Console.WriteLine($"說明: 包含重複元素的更複雜案例\n");

        // 驗證兩種解法的結果是否一致
        Console.WriteLine("=== 結果驗證 ===");
        Console.WriteLine($"測試案例 1: 解法一={result1}, 解法二={result1_2}, 一致={result1 == result1_2}");
        Console.WriteLine($"測試案例 2: 解法一={result2}, 解法二={result2_2}, 一致={result2 == result2_2}");
        Console.WriteLine($"測試案例 3: 解法一={result3}, 解法二={result3_2}, 一致={result3 == result3_2}");
        Console.WriteLine($"測試案例 4: 解法一={result4}, 解法二={result4_2}, 一致={result4 == result4_2}");
    }

    /// <summary>
    /// 解法一：尋找最長和諧子序列的長度 (使用雜湊表)
    /// 
    /// 解題說明：
    /// 和諧子序列定義：子序列中最大值和最小值的差恰好等於1
    /// 
    /// 演算法步驟：
    /// 1. 第一次遍歷：統計每個數字的出現頻率，存入雜湊表
    /// 2. 第二次遍歷：對每個數字key，檢查key+1是否存在
    /// 3. 如果key和key+1都存在，計算它們的頻率總和
    /// 4. 持續更新並記錄最大的頻率總和
    /// 
    /// 核心觀念：
    /// 由於差值恰好為1，和諧子序列只能由兩個相鄰整數組成
    /// 例如：[1,2,1,2,1] 中，和諧子序列就是所有的1和2，長度為5
    /// 
    /// 時間複雜度：O(n) - 兩次遍歷數組
    /// 空間複雜度：O(n) - 雜湊表儲存所有不同的數字
    /// </summary>
    /// <param name="nums">輸入的整數數組</param>
    /// <returns>最長和諧子序列的長度，如果不存在則返回0</returns>
    public int FindLHS(int[] nums)
    {
        // 第一階段：建立雜湊表統計每個數字的出現次數
        var count = new Dictionary<int, int>();
        
        // 遍歷數組，統計每個數字的頻率
        foreach (var num in nums)
        {
            if (count.ContainsKey(num))
            {
                // 數字已存在，增加計數
                count[num]++;
            }
            else
            {
                // 數字第一次出現，初始化計數為1
                count[num] = 1;
            }
        }

        // 第二階段：尋找最長和諧子序列
        var maxLength = 0;
        
        // 遍歷雜湊表中的每個數字
        foreach (var key in count.Keys)
        {
            // 檢查是否存在比當前數字大1的數字
            // 和諧子序列的條件：最大值-最小值=1，所以只需檢查相鄰數字
            if (count.ContainsKey(key + 1))
            {
                // 如果key和key+1都存在，計算它們的總頻率
                // 這就是以key和key+1組成的和諧子序列的長度
                var currentLength = count[key] + count[key + 1];
                
                // 更新最大長度
                maxLength = Math.Max(maxLength, currentLength);
            }
        }

        // 返回最長和諧子序列的長度
        return maxLength;
    }

    /// <summary>
    /// 解法二：尋找最長和諧子序列的長度 (使用暴力法)
    /// 
    /// 解題說明：
    /// 和諧子序列定義：子序列中最大值和最小值的差恰好等於1
    /// 
    /// 核心概念：
    /// 對每個數字 x，掃描整個陣列統計 x 和 x+1 的出現次數
    /// 計算所有可能的和諧子序列長度
    /// 
    /// 演算法步驟：
    /// 1. 遍歷陣列中的每個數字 x
    /// 2. 對於每個 x，再次遍歷整個陣列
    /// 3. 統計 x 和 x+1 的出現次數  
    /// 4. 如果 x+1 存在，計算和諧子序列長度
    /// 5. 回傳所有組合中的最大長度
    /// 
    /// 時間複雜度：O(n²) - 對每個元素都要掃描整個陣列
    /// 空間複雜度：O(1) - 只使用固定的額外空間
    /// </summary>
    /// <param name="nums">輸入的整數數組</param>
    /// <returns>最長和諧子序列的長度，如果不存在則返回0</returns>
    public int FindLHS2(int[] nums)
    {
        var maxLength = 0;
        var processedNumbers = new HashSet<int>();
        
        // 遍歷陣列中的每個數字
        for (int i = 0; i < nums.Length; i++)
        {
            var currentNum = nums[i];
            
            // 避免重複處理相同的數字，提高效率
            if (processedNumbers.Contains(currentNum))
            {
                continue;
            }
            processedNumbers.Add(currentNum);
            
            // 統計當前數字和比它大1的數字的出現次數
            var countCurrent = 0;
            var countNext = 0;
            
            // 掃描整個陣列統計 currentNum 和 currentNum+1 的出現次數
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] == currentNum)
                {
                    countCurrent++;
                }
                else if (nums[j] == currentNum + 1)
                {
                    countNext++;
                }
            }
            
            // 如果 currentNum+1 存在（countNext > 0），則可以形成和諧子序列
            if (countNext > 0)
            {
                var currentLength = countCurrent + countNext;
                maxLength = Math.Max(maxLength, currentLength);
            }
        }
        
        return maxLength;
    }


}
