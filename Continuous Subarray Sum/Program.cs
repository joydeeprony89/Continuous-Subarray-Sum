using System;
using System.Collections.Generic;

namespace Continuous_Subarray_Sum
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums = new int[] { 2, 24, 6, 6, 7 };
      int k = 6;
      Solution s = new Solution();
      var answer = s.CheckSubarraySum(nums, k);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public bool CheckSubarraySum(int[] nums, int k)
    {
      if (nums.Length < 2 || k == 0) return false;
      Dictionary<int, int> hash = new Dictionary<int, int>();
      hash.Add(0, -1);
      int sum = 0;
      for (int i = 0; i < nums.Length; i++)
      {
        sum += nums[i];
        int mod = sum % k;
        if (hash.ContainsKey(mod))
        {
          int previousIndex = hash[mod];
          if (i - previousIndex > 1) return true;
        }
        else
        {
          hash.Add(mod, i);
        }
      }
      return false;
    }
  }
}
