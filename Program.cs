// 1. Sum of Array Elements:

public static int ArraySum(int[] arr)
{
    int sum = 0;
    foreach (int num in arr)
    {
        sum += num;
    }
    return sum;
}


// 2. Find the Missing Number:

public static int FindMissNumber(int[] arr, int n)
{
    int totalSum = n * (n + 1) / 2;
    int arraySum = 0;
    foreach (int num in arr)
    {
        arraySum += num;
    }
    return totalSum - arraySum;
}


// 3. Reverse an Array in Place:

public static void ReverseArray(int[] arr)
{
    int left = 0, right = arr.Length - 1;
    while (left < right)
    {
        int temp = arr[left];
        arr[left] = arr[right];
        arr[right] = temp;
        left++;
        right--;
    }
}


// 4. Find First Non-Repeating Character in a String:

public static char FirstUniqueChar(string str)
{
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    foreach (char c in str)
    {
        if (charCount.ContainsKey(c))
        {
            charCount[c]++;
        }
        else
        {
            charCount[c] = 1;
        }
    }
    foreach (char c in str)
    {
        if (charCount[c] == 1)
        {
            return c;
        }
    }
    return '\0';
}


// 5. Find the Majority Element:

public static int MajorityElement(int[] arr)
{
    int candidate = arr[0], count = 1;
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] == candidate)
        {
            count++;
        }
        else
        {
            count--;
        }
        if (count == 0)
        {
            candidate = arr[i];
            count = 1;
        }
    }
    return candidate;
}

// 6. Rotate an Array by K Positions:

public static void RotateArray(int[] arr, int k)
{
    k = k % arr.Length;
    Array.Reverse(arr);
    Array.Reverse(arr, 0, k);
    Array.Reverse(arr, k, arr.Length - k);
}

// 7. Find the Longest Consecutive Sequence:

public static int LongestConsecutive(int[] arr)
{
    HashSet<int> numSet = new HashSet<int>(arr);
    int longestStreak = 0;
    foreach (int num in numSet)
    {
        if (!numSet.Contains(num - 1))
        {
            int currentNum = num;
            int currentStreak = 1;
            while (numSet.Contains(currentNum + 1))
            {
                currentNum++;
                currentStreak++;
            }
            longestStreak = Math.Max(longestStreak, currentStreak);
        }
    }
    return longestStreak;
}


// 8. Find K-th Smallest Element in an Unsorted Array:

public static int KthSmallestElement(int[] arr, int k)
{
    Array.Sort(arr);
    return arr[k - 1];
}


// 9. Find the Maximum Product of Three Numbers:

public static int MaxProductOfThree(int[] arr)
{
    Array.Sort(arr);
    int n = arr.Length;
    return Math.Max(arr[n - 1] * arr[n - 2] * arr[n - 3], arr[0] * arr[1] * arr[n - 1]);
}
//

// 10. Merge Two Sorted Arrays:

public static int[] MergeSortedArrays(int[] arr1, int[] arr2)
{
    int[] result = new int[arr1.Length + arr2.Length];
    int i = 0, j = 0, k = 0;
    while (i < arr1.Length && j < arr2.Length)
    {
        if (arr1[i] <= arr2[j])
        {
            result[k++] = arr1[i++];
        }
        else
        {
            result[k++] = arr2[j++];
        }
    }
    while (i < arr1.Length)
    {
        result[k++] = arr1[i++];
    }
    while (j < arr2.Length)
    {
        result[k++] = arr2[j++];
    }
    return result;
}
//

// 11. Find Pair with Given Sum in a Sorted Array:

public static int[] TwoSumSorted(int[] arr, int target)
{
    int left = 0, right = arr.Length - 1;
    while (left < right)
    {
        int sum = arr[left] + arr[right];
        if (sum == target)
        {
            return new int[] { left, right };
        }
        else if (sum < target)
        {
            left++;
        }
        else
        {
            right--;
        }
    }
    return new int[] { -1, -1 };
}


// 12. Find the Peak Element in an Array:

public static int FindPeakElement(int[] arr)
{
    for (int i = 1; i < arr.Length - 1; i++)
    {
        if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
        {
            return arr[i];
        }
    }
    return arr[0];
}


// 13. Check If an Array is a Subset of Another:

public static bool IsSubset(int[] arr1, int[] arr2)
{
    HashSet<int> set = new HashSet<int>(arr1);
    foreach (int num in arr2)
    {
        if (!set.Contains(num))
        {
            return false;
        }
    }
    return true;
}


// 14. Trapping Rain Water:

public static int TrapRainWater(int[] height)
{
    int left = 0, right = height.Length - 1;
    int leftMax = 0, rightMax = 0, water = 0;
    while (left < right)
    {
        if (height[left] < height[right])
        {
            if (height[left] >= leftMax)
            {
                leftMax = height[left];
            }
            else
            {
                water += leftMax - height[left];
            }
            left++;
        }
        else
        {
            if (height[right] >= rightMax)
            {
                rightMax = height[right];
            }
            else
            {
                water += rightMax - height[right];
            }
            right--;
        }
    }
    return water;
}


// 15. Find the Smallest Window in a String Containing All Characters of Another String:

public static string MinWindowSubstring(string s, string t)
{
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    foreach (char c in t)
    {
        if (charCount.ContainsKey(c))
        {
            charCount[c]++;
        }
        else
        {
            charCount[c] = 1;
        }
    }
    int left = 0, minLength = int.MaxValue, minStart = 0, count = t.Length;
    for (int right = 0; right < s.Length; right++)
    {
        if (charCount.ContainsKey(s[right]))
        {
            if (charCount[s[right]] > 0)
            {
                count--;
            }
            charCount[s[right]]--;
        }
        while (count == 0)
        {
            if (right - left + 1 < minLength)
            {
                minLength = right - left + 1;
                minStart = left;
            }
            if (charCount.ContainsKey(s[left]))
            {
                charCount[s[left]]++;
                if (charCount[s[left]] > 0)
                {
                    count++;
                }
            }
            left++;
        }
    }
    return minLength == int.MaxValue ? "" : s.Substring(minStart, minLength);
}


// 16. Find All Anagrams of a String in Another String:

public static List<int> FindAnagrams(string s, string t)
{
    List<int> result = new List<int>();
    if (s.Length < t.Length)
    {
        return result;
    }
    Dictionary<char, int> tCount = new Dictionary<char, int>();
    Dictionary<char, int> sCount = new Dictionary<char, int>();
    foreach (char c in t)
    {
        if (tCount.ContainsKey(c))
        {
            tCount[c]++;
        }
        else
        {
            tCount[c] = 1;
        }
    }
    for (int i = 0; i < t.Length; i++)
    {
        if (sCount.ContainsKey(s[i]))
        {
            sCount[s[i]]++;
        }
        else
        {
            sCount[s[i]] = 1;
        }
    }
    if (sCount.SequenceEqual(tCount))
    {
        result.Add(0);
    }
    for (int i = t.Length; i < s.Length; i++)
    {
        sCount[s[i - t.Length]]--;
        if (sCount[s[i - t.Length]] == 0)
        {
            sCount.Remove(s[i - t.Length]);
        }
        if (sCount.ContainsKey(s[i]))
        {
            sCount[s[i]]++;
        }
        else
        {
            sCount[s[i]] = 1;
        }
        if (sCount.SequenceEqual(tCount))
        {
            result.Add(i - t.Length + 1);
        }
    }
    return result;
}


// 17. Find the K Closest Numbers to a Target:

public static int[] KClosestNumbers(int[] arr, int k, int x)
{
    Array.Sort(arr, (a, b) => Math.Abs(a - x).CompareTo(Math.Abs(b - x)));
    return arr.Take(k).ToArray();
}


// 18. Find Duplicates in an Array:

public static List<int> FindDuplicates(int[] arr)
{
    List<int> duplicates = new List<int>();
    HashSet<int> seen = new HashSet<int>();
    foreach (int num in arr)
    {
        if (seen.Contains(num))
        {
            duplicates.Add(num);
        }
        else
        {
            seen.Add(num);
        }
    }
    return duplicates;
}


// 19. Find the Longest Palindromic Substring:

public static string LongestPalindrome(string s)
{
    if (string.IsNullOrEmpty(s)) return "";

    int start = 0, maxLength = 1;
    for (int i = 0; i < s.Length; i++)
    {
        int low = i, high = i;
        while (low >= 0 && high < s.Length && s[low] == s[high])
        {
            if (high - low + 1 > maxLength)
            {
                start = low;
                maxLength = high - low + 1;
            }
            low--;
            high++;
        }
        low = i;
        high = i + 1;
        while (low >= 0 && high < s.Length && s[low] == s[high])
        {
            if (high - low + 1 > maxLength)
            {
                start = low;
                maxLength = high - low + 1;
            }
            low--;
            high++;
        }
    }

    return s.Substring(start, maxLength);
}


// 20 Find the Median of Two Sorted Arrays

public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    if (nums1.Length > nums2.Length)
    {
        return FindMedianSortedArrays(nums2, nums1);
    }

    int x = nums1.Length;
    int y = nums2.Length;

    int low = 0, high = x;
    while (low <= high)
    {
        int partitionX = (low + high) / 2;
        int partitionY = (x + y + 1) / 2 - partitionX;

        int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
        int minX = (partitionX == x) ? int.MaxValue : nums1[partitionX];

        int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
        int minY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

        if (maxX <= minY && maxY <= minX)
        {
            if ((x + y) % 2 == 0)
            {
                return (Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2.0;
            }
            else
            {
                return Math.Max(maxX, maxY);
            }
        }
        else if (maxX > minY)
        {
            high = partitionX - 1;
        }
        else
        {
            low = partitionX + 1;
        }
    }

    throw new InvalidOperationException("Input arrays are not sorted.");
}

public static void Main()
{
    int[] nums1 = { 1, 3 };
    int[] nums2 = { 2 };
    double median = FindMedianSortedArrays(nums1, nums2);
    Console.WriteLine($"Median: {median}");
}

