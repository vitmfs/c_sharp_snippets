using System;
using System.Collections.Generic;
using System.Text;
					
public class Program
{
	public static void Main()
	{
		string helloString = "Hello, Extension Methods!";
		int wordCount = helloString.WordCount();
		Console.WriteLine(wordCount);
		
		List<int> numbers = new List<int> {1, 2, 3, 4, 5};
		Console.WriteLine(numbers.ToString<int>());
		
		numbers.IncreaseAllBy(5);
		Console.WriteLine(numbers.ToString<int>());

	}
}

public static class StringExtensions
{
	public static int WordCount(this string str)
	{
		return str.Split(new char[] {' ', '.', ',', '?', '!'},
			StringSplitOptions.RemoveEmptyEntries).Length;
	}

}

public static class IListExtensions
{
	public static void IncreaseAllBy(
						this IList<int> list,
						int amount )
	{
		for (int i = 0; i < list.Count; i++)
		{
			list[i] += amount;
		}
	
	}

}


public static class IEnumerableExtensions
{
	public static string ToString<T>(
		this IEnumerable<T> enumeration)
	{
		StringBuilder result = new StringBuilder();

		result.Append("[");
		foreach (var item in enumeration)
		{
			result.Append(item.ToString());
			result.Append(", ");
		}

		if (result.Length > 1)
		{
			result.Remove(result.Length -2, 2);
		}
			
		result.Append("]");
		
		return result.ToString();
		
	}

}