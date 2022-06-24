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
        // example say sum is 23 and k is 6, 23 % 6 = 1, 1 say we need 1 to be present so that 23+1 = 24 is the multiple of 6
        int mod = sum % k;
        if (hash.ContainsKey(mod))
        {
          // so 23 we have found and we need 1 to make this multiple of 6
          // if we found 1 as well, then check the 1 found index is lesser than i(current index), because we want continuous subarray
          // 1 has to appear before 23 => (1, 23) and also we need atleast 2 element whose sum is multiple of k
          // thats why we check i - currentIndex > 1
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
