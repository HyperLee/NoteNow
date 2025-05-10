using System;
using System.Collections.Generic;

namespace NoteNow;

class Program
{
    /// <summary>
    /// 解題 1. Two Sum
    /// 題目連結：https://leetcode.com/problems/two-sum/
    /// 
    /// 題目描述：
    /// 給定一個整數陣列 nums 和一個目標值 target，請找出陣列中和為目標值的兩個數字，並回傳它們的索引。
    /// 假設每個輸入只會對應一組答案，但同一個元素不能重複使用。
    /// </summary>
    /// <param name="nums">輸入整數陣列</param>
    /// <param name="target">目標值</param>
    /// <returns>和為目標值的兩個數字的索引陣列</returns>
    public static int[] TwoSum(int[] nums, int target)
    {
        // 建立一個字典（Dictionary）來儲存數字及其對應的索引
        Dictionary<int, int> numDict = new Dictionary<int, int>();
        // 逐一遍歷陣列中的每個元素
        for (int i = 0; i < nums.Length; i++)
        {
            // 計算目前元素的補數（目標值減去目前數字）
            int complement = target - nums[i];
            // 檢查補數是否已經存在於字典中
            if (numDict.ContainsKey(complement))
            {
                // 若存在，代表找到一組解，回傳補數的索引與目前索引
                return new int[] { numDict[complement], i };
            }
            // 若補數不存在，將目前數字與索引加入字典
            if (!numDict.ContainsKey(nums[i]))
            {
                numDict[nums[i]] = i;
            }
        }
        // 若遍歷完畢仍無解，回傳空陣列
        return Array.Empty<int>();
    }

    static void Main(string[] args)
    {
        // 測試資料組 1
        int[] nums1 = { 2, 7, 11, 15 };
        int target1 = 9;
        int[] result1 = TwoSum(nums1, target1);
        Console.WriteLine("測試資料組 1 TwoSum 結果: [" + string.Join(", ", result1) + "]");

        // 測試資料組 2
        int[] nums2 = { 3, 2, 4 };
        int target2 = 6;
        int[] result2 = TwoSum(nums2, target2);
        Console.WriteLine("測試資料組 2 TwoSum 結果: [" + string.Join(", ", result2) + "]");

        // 測試資料組 3
        int[] nums3 = { 3, 3 };
        int target3 = 6;
        int[] result3 = TwoSum(nums3, target3);
        Console.WriteLine("測試資料組 3 TwoSum 結果: [" + string.Join(", ", result3) + "]");
    }
}
