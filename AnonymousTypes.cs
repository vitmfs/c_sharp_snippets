using System;
					
public class AnonymousTypes
{
	public static void Main()
	{
		var myCar = new {
			Color = "Red",
			Brand = "BMW",
			Speed = 180
		};
		
		Console.WriteLine("My car is a {0} {1}.",
						  myCar.Color,
						  myCar.Brand);
		Console.WriteLine("It runs {0} Km/h", myCar.Speed);
		
		Console.WriteLine("ToString: {0}", myCar.ToString());
		Console.WriteLine("Hash code: {0}",
						 myCar.GetHashCode().ToString());
		Console.WriteLine("Equals? {0}", myCar.Equals(
			new { Color = "Red", Brand = "BMW", Speed = 180 }
		));
		Console.WriteLine("Type name: {0}", myCar.GetType().ToString());
		
		
		// ARRAYS OF ANONYMOUS TYPES
		var arr = new[] {
			new { X = 3, Y = 5 },
			new { X = 1, Y = 2 },
			new { X = 0, Y = 7 }
		};
		
		foreach( var item in arr)
		{
			Console.WriteLine(item.ToString());
		}
		
	}
	
	
}