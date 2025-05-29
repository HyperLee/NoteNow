using System;
using System.Collections.Generic;

namespace NoteNow;

class Program
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param> <summary>
    /// 
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

    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
    {
        int n = edges1.Length + 1;
        int m = edges2.Length + 1;
        int[] count1 = Build(edges1, k);
        int[] count2 = Build(edges2, k - 1);
        int maxCount2 = 0;
        foreach (var c in count2)
        {
            if (c > maxCount2)
            {
                maxCount2 = c;
            }
        }

        int[] res = new int[n];
        for (int i = 0; i < n; i++)
        {
            res[i] = count1[i] + maxCount2;
        }
        
        return res;
    }

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

    private int Dfs(int node, int parent, List<List<int>> children, int k)
    {
        if (k < 0)
        {
            return 0;
        }

        int count = 1;
        foreach (var child in children[node])
        {
            if (child != parent)
            {
                count += Dfs(child, node, children, k - 1);
            }
        }
        return count;
    }
}
