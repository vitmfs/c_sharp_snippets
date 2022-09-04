using System;
using System.Collections.Generic;
using System.Linq;

					
public class LambdaExpressions
{
	public static void Main()
	{
		List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
		List<int> evenNumbers = list.FindAll( x => (x % 2) == 0);
		
		foreach (var num in evenNumbers)
		{
			Console.Write("{0} ", num);
		}
		
		Console.WriteLine();
		
		List<Dog> dogs = new List<Dog>() {
			new Dog { Name = "Rex", Age = 4 },
			new Dog { Name = "Sean", Age = 0 },
			new Dog { Name = "Stacy", Age = 3 }
		};
		
		var names = dogs.Select(x => x.Name);
		foreach ( var name in names)
		{
			Console.WriteLine(name);
		}
		
		// USING LAMBDA EXPRESSIONS WITH ANONYMOUS TYPES
		var newDogsList = dogs.Select(
			x => new {Age = x.Age, FirstLetter = x.Name[0] });
		
		foreach (var item in newDogsList)
		{
			Console.WriteLine(item);
		}
		
		// SORTING WITH LAMBDA EXPRESSIONS
		var sortedDogs = dogs. OrderByDescending(x => x.Age);
		foreach( var dog in sortedDogs)
		{
			Console.WriteLine(String.Format(
				"Dog {0} is {1} years old.", dog.Name, dog.Age));
		}
		
		// STATEMENTES IN LAMBDA EXPRESSIONS
		List<int> list2= new List<int>() { 20, 1, 4, 8, 9, 44 };
		
		var evenNumbers2= list2.FindAll( (i) =>
									   {
										   Console.WriteLine("Value of i is: {0}", i);
										   return (i % 2) == 0;

									   });
		
		// LAMBDA EXPRESSIONS AS DELEGATES
		Func<bool> boolFunc = () => true;
		Func<int, bool> intFunc = (x) => x < 10;
		if (boolFunc() && intFunc(5))
		{
			Console.WriteLine("5 < 10");
		}
		
		
	}
}

public class Dog
{
	public string Name { get; set; }
	public int Age { get; set; }
}