using System;
using System.Collections.Generic;

public class Solution
{
    public int[] SumEvenAfterQueries(int[] nums, int[][] queries)
    {
        int sumEven = 0;

        // Начальное вычисление суммы четных чисел
        foreach (int num in nums)
        {
            if (num % 2 == 0)
            {
                sumEven += num;
            }
        }

        int[] result = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            int val = queries[i][0];
            int index = queries[i][1];

            // Если текущее значение на позиции index четное, то убираем его из суммы
            if (nums[index] % 2 == 0)
            {
                sumEven -= nums[index];
            }

            // Обновляем значение nums[index]
            nums[index] += val;

            // Если новое значение на позиции index четное, то добавляем его к сумме
            if (nums[index] % 2 == 0)
            {
                sumEven += nums[index];
            }

            // Сохраняем текущую сумму четных чисел в результат
            result[i] = sumEven;
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] nums1 = { 1, 2, 3, 4 };
        int[][] queries1 = {
            new int[] {1, 0},
            new int[] {-3, 1},
            new int[] {-4, 0},
            new int[] {2, 3}
        };
        int[] result1 = solution.SumEvenAfterQueries(nums1, queries1);
        Console.WriteLine(string.Join(", ", result1)); // Ожидаемый вывод: 8, 6, 2, 4

        int[] nums2 = { 1 };
        int[][] queries2 = {
            new int[] {4, 0}
        };
        int[] result2 = solution.SumEvenAfterQueries(nums2, queries2);
        Console.WriteLine(string.Join(", ", result2)); // Ожидаемый вывод: 0
    }
}
