using System;
using System.Collections.Generic;

Solution solution = new Solution();

int[] nums1 = { 1 };
int k1 = 1;
Console.WriteLine(solution.ShortestSubarray(nums1, k1)); // Ожидаемый вывод: 1

int[] nums2 = { 1, 2 };
int k2 = 4;
Console.WriteLine(solution.ShortestSubarray(nums2, k2)); // Ожидаемый вывод: -1

int[] nums3 = { 2, -1, 2 };
int k3 = 3;
Console.WriteLine(solution.ShortestSubarray(nums3, k3)); // Ожидаемый вывод: 3

public class Solution
{
    public int ShortestSubarray(int[] nums, int k)
    {
        int n = nums.Length;
        long[] prefixSums = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        int minLength = n + 1;
        LinkedList<int> deque = [];

        for (int i = 0; i <= n; i++)
        {
            while (deque.Count > 0 && prefixSums[i] - prefixSums[deque.First.Value] >= k)
            {
                minLength = Math.Min(minLength, i - deque.First.Value);
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && prefixSums[i] <= prefixSums[deque.Last.Value])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);
        }

        return minLength <= n ? minLength : -1;
    }
}