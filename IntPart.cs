using System;
using System.Collections.Generic;
using System.Linq;

public class IntPart 
{
  static List<int> prod;
  
  public static string Part(long n)
  {
    //your code
    prod = new List<int>();
    GenerateParts(Convert.ToInt32(n));
    int[] products = prod.ToArray();
    
    Array.Sort(products);

    double avg = Queryable.Average(products.AsQueryable());
    double median;
    
    if (products.Length % 2 == 0)
      median = ((double)products[products.Length/2] + (double)products[products.Length/2 - 1])/2;
    else
      median = (double) products[products.Length/2];

    return 
      "Range: " + (products[products.Length - 1] - products[0]) + 
      " Average: " + avg.ToString("0.00") + 
      " Median: " + median.ToString("0.00");
  }
  static void PartsToArray(int []p, int n)
    {
      int temp = 1;
      for (int i = 0; i < n; i++)
        {
          temp *= p[i];
        }

      if(!prod.Contains(temp))
      {
        prod.Add(temp);
      }
    }
  
  static void GenerateParts(int n)
    {
         
        // An array to store a partition
        int[] p = new int[n];
         
        // Index of last element in a
        // partition
        int k = 0;
         
        // Initialize first partition as
        // number itself
        p[k] = n;
 
        // This loop first prints current
        // partition, then generates next
        // partition. The loop stops when
        // the current partition has all 1s
        while (true)
        {
             
            // print current partition
            PartsToArray(p, k+1);
 
            // Generate next partition
 
            // Find the rightmost non-one
            // value in p[]. Also, update
            // the rem_val so that we know
            // how much value can be
            // accommodated
            int rem_val = 0;
             
            while (k >= 0 && p[k] == 1)
            {
                rem_val += p[k];
                k--;
            }
 
            // if k < 0, all the values are 1 so
            // there are no more partitions
            if (k < 0)
                return;
 
            // Decrease the p[k] found above
            // and adjust the rem_val
            p[k]--;
            rem_val++;
 
 
            // If rem_val is more, then the sorted
            // order is violated. Divide rem_val in
            // different values of size p[k] and copy
            // these values at different positions
            // after p[k]
            while (rem_val > p[k])
            {
                p[k+1] = p[k];
                rem_val = rem_val - p[k];
                k++;
            }
 
            // Copy rem_val to next position and
            // increment position
            p[k+1] = rem_val;
            k++;
        }
    }
}
