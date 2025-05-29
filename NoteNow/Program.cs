using System;
using System.Collections.Generic;

namespace NoteNow;

class Program
{
    /// <summary>
    /// LeetCode 3372 — 連接兩棵樹後最大化目標節點的數量 I
    /// 題目說明
    /// 有兩棵無向樹，分別包含 `n` 和 `m` 個節點，其節點標籤分別在區間 `[0, n - 1]` 和 `[0, m - 1]` 之內，且互不重複。
    /// 給定兩個長度分別為 `n - 1` 和 `m - 1` 的二維整數陣列 `edges1` 和 `edges2`，其中 `edges1[i] = [ai, bi]` 表示第一棵樹中的節點 `ai` 和 `bi` 之間有一條邊；`edges2[i] = [ui, vi]` 表示第二棵樹中的節點 `ui` 和 `vi` 之間有一條邊。你還會得到一個整數 `k`。
    /// 若從節點 `u` 到節點 `v` 的路徑邊數小於或等於 `k`，則稱節點 `u` 是節點 `v` 的**目標節點 (target)**。請注意，節點永遠是自己的目標節點。
    /// 請你回傳一個長度為 `n` 的整數陣列 `answer`，其中 `answer[i]` 表示如果你可以從第一棵樹中的某個節點與第二棵樹中的某個節點連接一條邊，則節點 `i` 最多可以擁有多少個目標節點 (來自兩棵樹的節點)，使得從這些目標節點到節點 `i` 的邊數不超過 `k`。
    /// > 每個查詢是獨立的，也就是說你在計算某個 `i` 的結果時新增了一條邊，在計算下一個節點時，必須先移除這條新增的邊。
    /// 
    /// 本程式的核心邏輯如下：
    /// 1. 先對 tree2 的每個節點，計算在距離 k-1 內可達的節點數（因為連接邊會消耗 1 距離）。
    /// 2. 取 tree2 所有節點中，這個數值的最大值。
    /// 3. 對 tree1 的每個節點，計算它在自身樹內距離 k 內可達的節點數。
    /// 4. 最終答案就是 tree1 每個節點的可達數 + tree2 的最大可達數。
    /// 這樣就能保證 tree1 的每個節點都能連到 tree2 最有利的位置，達到最大目標節點數。
    /// 此策略適用於「可以任意選擇 tree2 的連接點」的情境。
    /// 
    /// 小提醒：
    /// 這種做法是因為「可以任意選擇 tree2 的連接點」，所以只要取最大值即可。如果題目限制只能連接特定節點，邏輯就要調整。
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // 測試資料：
        // Tree1: 0-1-2
        // Tree2: 0-1
        // k = 2
        int[][] edges1 = new int[][]
        {
            new int[] { 0, 1 },
            new int[] { 1, 2 }
        };
        int[][] edges2 = new int[][]
        {
            new int[] { 0, 1 }
        };
        int k = 2;

        // 解法1
        var prog = new Program();
        int[] ans1 = prog.MaxTargetNodes(edges1, edges2, k);
        Console.WriteLine("解法1結果: [" + string.Join(", ", ans1) + "]");
    }


    /// <summary>
    /// 解法1:使用 DFS 計算每個節點在自身樹內距離 k 內可達的節點數，然後找出第二棵樹中距離 k-1 可達的最大節點數。
    ///       計算每個第一棵樹節點，連接第二棵樹任一節點後，最多可達到的目標節點數量。
    /// 
    /// 注意:計算第二顆樹距離是 k - 1，因為連接(題目有說 tree1 與 tree2 連接計算)邊長為 1，所以實際上是 k - 1。
    ///      要扣除連接的那段距離 1
    /// </summary>
    /// <param name="edges1">第一棵樹的邊資訊</param>
    /// <param name="edges2">第二棵樹的邊資訊</param>
    /// <param name="k">最大距離</param>
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
    {
        int n = edges1.Length + 1;
        int m = edges2.Length + 1;
        int[] count1 = Build(edges1, k);
        int[] count2 = Build(edges2, k - 1); // 注意這裡是 k - 1，因為連接邊消耗 1 距離
        int maxCount2 = 0;
        // 找出第二棵樹中距離 k-1 可達的最大節點數
        for (int i = 0; i < m; i++)
        {
            maxCount2 = Math.Max(maxCount2, count2[i]);
        }

        int[] result = new int[n];
        // 對第一棵樹的每個節點，計算它在自身樹內距離 k 內可達的節點數  
        for (int i = 0; i < n; i++)
        {
            result[i] = count1[i] + maxCount2; // 每個節點的可達數 + 第二棵樹的最大可達數
        }
        return result;
    }


    /// <summary>
    /// 計算每個節點在距離 k 內可達的節點數（包含自己），用於單棵樹。
    /// </summary>
    /// <param name="edges">樹的邊資訊</param>
    /// <param name="k">最大距離</param>
    /// <returns>每個節點在距離 k 內可達的節點數陣列</returns>
    private int[] Build(int[][] edges, int k)
    {
        int n = edges.Length + 1;
        List<List<int>> children = new List<List<int>>(n);
        for (int i = 0; i < n; i++)
        {
            children.Add(new List<int>());
        }

        foreach (var edge in edges)
        {
            int a = edge[0];
            int b = edge[1];
            children[a].Add(b);
            children[b].Add(a);
        }

        int[] res = new int[n];
        for (int i = 0; i < n; i++)
        {
            res[i] = Dfs(i, -1, children, k);
        }

        return res;
    }


    /// <summary>
    /// 使用 DFS 計算從 node 出發，距離不超過 k 的可達節點數（包含自己）。
    /// </summary>
    /// <param name="node">目前節點</param>
    /// <param name="parent">父節點，避免回頭</param>
    /// <param name="children">鄰接串列</param>
    /// <param name="k">剩餘可走步數</param>
    /// <returns>可達節點數</returns>
    private int Dfs(int node, int parent, List<List<int>> children, int k)
    {
        if (k < 0)
        {
            return 0;
        }

        int count = 1;
        foreach (int child in children[node])
        { 
            if (child != parent) // 避免回頭
            {
                count += Dfs(child, node, children, k - 1);
            }
        }
        return count;
    }
}
