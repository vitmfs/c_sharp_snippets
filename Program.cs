using System;
using System.Collections.Generic;


					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("PROGRAM START");
		// SIGNED INTEGRAL
		sbyte   mySbyte = -1;
		short   myShort = -1;
		int     myInt   = -1;
		long    myLong  = -1;

		// UNSIGNED INTEGRAL
		byte    myByte      = 0; 
		ushort  myUshort    = 0; 
		uint    myUint      = 0; 
		ulong   myUlong     = 0;

			// UNICODE CHARACTERS
			char myChar = 'A';

		// FLOATING-POINT
		float   myFloat     = 0;
		double  myDouble    = 0;
		decimal myDecimal   = 0;

		// BOOLEAN
		bool myBool = true;
		
		Point p1 = new Point(0, 0);
		Point p2 = new Point(10, 20);
		
		Point a = new(10, 20);
		Point b = new Point3D(10, 20, 30);
		
		var pair = new Pair<int, string>(1, "two");
		int i = pair.First; //TFirst int
		string s = pair.Second; //TSecond string
		
		EditBox editBox = new();
		IControl control = editBox;
		IDataBound dataBound = editBox;
		
		var turnip = SomeRootVegetable.Turnip;
		var spring = Seasons.Spring;
		var startingOnEquinox = Seasons.Spring | Seasons.Autumn;
		var theYear = Seasons.All;
		
		// NULLABLE TYPES
		int? optionalInt = default;
		optionalInt = 5;
		string? optionalText = default;
		optionalText = "Hello World.";
		
		
		// TUPLES
		(double Sum, int Count) t2 = (4.5, 3);
		Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
		//Output:
		//Sum of 3 elements is 4.5.
		
		int x, y, z;
		x = 3;
		y = 4;
		z = 5;
		Console.WriteLine("x={0} y={1} z={2}", x, y, z);
		
		string str = "x={0} y={1} z={2}";
		object[] args = new object[3];
		args[0] = x;
		args[1] = y;
		args[2] = z;
		Console.WriteLine(str, args);
		
		Entity.SetNextSerialNo(1000);
		Entity e1 = new();
		Entity e2 = new();
		Console.WriteLine(e1.GetSerialNo()); // Outputs "1000"
		Console.WriteLine(e2.GetSerialNo()); // Outputs "1001"
		Console.WriteLine(Entity.GetNextSerialNo()); // Outputs "1002"
		
		Expression e = new Operation(
			new VariableReference("x"),
			'+',
			new Constant(3));
		
		Expression ee = new Operation(
		new VariableReference("x"),
		'*',
		new Operation(
		new VariableReference("y"),
		'+',
		new Constant(2)
		)
		);
		Dictionary<string, object> vars = new();
		vars["x"] = 3;
		vars["y"] = 5;
		Console.WriteLine(e.Evaluate(vars)); // "21"
		vars["x"] = 1.5;
		vars["y"] = 9;
		Console.WriteLine(e.Evaluate(vars)); // "16.5"
		
		MyList<string> list1 = new();
		MyList<string> list2 = new(10);
		
		MyList<string> names = new();
		names.Capacity = 100; // Invokes set accessor
		int namesCount = names.Count; // Invokes get accessor
		int namesCap = names.Capacity; // Invokes get accessor
		
		names.Add("Liz");
		names.Add("Martha");
		names.Add("Beth");
		for (int ii = 0; ii < names.Count; ii++)
		{
			string ss = names[ii];
			names[ii] = ss.ToUpper();
		}
		
		MyList<int> aa = new();
		aa.Add(1);
		aa.Add(2);
		MyList<int> bb = new();
		bb.Add(1);
		bb.Add(2);
		Console.WriteLine(aa == bb); // Outputs "True"
		bb.Add(3);
		Console.WriteLine(aa == bb); // Outputs "False"
		
		int aInt = 0;
		bool aBool = false;
		
		OutParametersExample( out aInt, out aBool);
		
		Console.WriteLine(aInt);
		Console.WriteLine(aBool);
		
		RefParametersExample( ref aInt, ref aBool);
		
		Console.WriteLine(aInt);
		Console.WriteLine(aBool);
		
		
		
		
		Console.WriteLine("PROGRAM END");
	}
	
	static void ConsoleDemo()
	{
		Console.WriteLine("Hello World");
	
	}
	
	static void OutParametersExample(out int myInt, out bool myBool)
	{
		myInt 	= 100;
		myBool = true;
	}
	
	static void RefParametersExample(ref int myInt, ref bool myBool)
	{
		myInt 	= 50;
		myBool = false;
	}
	
	static void Swap(ref int x, ref int y)
	{
		int temp = x;
		x = y;
		y = temp;
	} 
	public static void SwapExample()
	{
		int i = 1, j = 2;
		Swap(ref i, ref j);
		Console.WriteLine($"{i} {j}"); // "2 1"
	}
	
	static void Divide(int x, int y, out int result, out int remainder)
	{
		result = x / y;
		remainder = x % y;
	} 
	
	public static void OutUsage()
	{
		Divide(10, 3, out int res, out int rem);
		Console.WriteLine($"{res} {rem}"); // "3 1"
	}
}

public struct PointStruct
{
	public double X { get; }
	public double Y { get; }
	public PointStruct(double x, double y) => (X, Y) = (x, y);
}

public class Point
{
	public int X { get; }
	public int Y { get; }
	public Point(int x, int y) => (X, Y) = (x, y);
}

public class Point3D : Point
{
	public int Z { get; set; }
	public Point3D(int x, int y, int z) : base(x, y)
	{
		Z = z;
	}
}

public class Pair<TFirst, TSecond>
{
	public TFirst First { get; }
	public TSecond Second { get; }
	public Pair(TFirst first, TSecond second) =>
	(First, Second) = (first, second);
}

interface IControl
{
	void Paint();
} 
interface ITextBox : IControl
{
	void SetText(string text);
} 
interface IListBox : IControl
{
	void SetItems(string[] items);
} 

interface IComboBox : ITextBox,IListBox 
{ 

}

public class Binder
{

}

interface IDataBound
{
	void Bind(Binder b);
}

public class EditBox : IControl, IDataBound
{
	public void Paint() { }
	public void Bind(Binder b) { }
}

public enum SomeRootVegetable
{
	HorseRadish,
	Radish,
	Turnip
}

[Flags]
public enum Seasons
{
	None = 0,
	Summer = 1,
	Autumn = 2,
	Winter = 4,
	Spring = 8,
	All = Summer | Autumn | Winter | Spring
}

public class Color
{
	public static readonly Color Black = new(0, 0, 0);
	public static readonly Color White = new(255, 255, 255);
	public static readonly Color Red = new(255, 0, 0);
	public static readonly Color Green = new(0, 255, 0);
	public static readonly Color Blue = new(0, 0, 255);
	
	public byte R;
	public byte G;
	public byte B;
	
	public Color(byte r, byte g, byte b)
	{
		R = r;
		G = g;
		B = b;
	}
	
	public override string ToString() => "This is an object of the Color Class";
}

class Squares
{
	public static void WriteSquares()
	{
		int i = 0;
		int j;
		while (i < 10)
		{
			j = i * i;
			Console.WriteLine($"{i} x {i} = {j}");
			i++;
		}
	}
}


class Entity
{
	static int s_nextSerialNo;
	int _serialNo;
	public Entity()
	{
		_serialNo = s_nextSerialNo++;
	} 
	public int GetSerialNo()
	{
		return _serialNo;
	}
	public static int GetNextSerialNo()
	{
		return s_nextSerialNo;
	}
	public static void SetNextSerialNo(int value)
	{
		s_nextSerialNo = value;
	}
}


public abstract class Expression
{
	public abstract double Evaluate(Dictionary<string, object> vars);
}
public class Constant : Expression
{
	double _value;
	public Constant(double value)
	{
		_value = value;
	} 
	public override double Evaluate(Dictionary<string, object> vars)
	{
		return _value;
	}
}

public class VariableReference : Expression
{
	string _name;
	public VariableReference(string name)
	{
		_name = name;
	}
	
	public override double Evaluate(Dictionary<string, object> vars)
	{
		object value = vars[_name] ?? throw new Exception($"Unknown variable: {_name}");
		return Convert.ToDouble(value);
	}
}

public class Operation : Expression
{
	Expression _left;
	char _op;
	Expression _right;
	public Operation(Expression left, char op, Expression right)
	{
		_left = left;
		_op = op;
		_right = right;
	}
	
	public override double Evaluate(Dictionary<string, object> vars)
	{
		double x = _left.Evaluate(vars);
		double y = _right.Evaluate(vars);
		switch (_op)
		{
			case '+': return x + y;
			case '-': return x - y;
			case '*': return x * y;
			case '/': return x / y;
			default: throw new Exception("Unknown operator");
		}
	}
}

class OverloadingExample
{
	static void F() => Console.WriteLine("F()");
	static void F(object x) => Console.WriteLine("F(object)");
	static void F(int x) => Console.WriteLine("F(int)");
	static void F(double x) => Console.WriteLine("F(double)");
	static void F<T>(T x) => Console.WriteLine("F<T>(T)");
	static void F(double x, double y) => Console.WriteLine("F(double, double)");
	
	public static void UsageExample()
	{
		F(); // Invokes F()
		F(1); // Invokes F(int)
		F(1.0); // Invokes F(double)
		F("abc"); // Invokes F<string>(string)
		F((double)1); // Invokes F(double)
		F((object)1); // Invokes F(object)
		F<int>(1); // Invokes F<int>(int)
		F(1, 1); // Invokes F(double, double)
	}
}


public class MyList<T>
{
	const int DefaultCapacity = 4;
	T[] _items;
	int _count;
	
	public MyList(int capacity = DefaultCapacity)
	{
		_items = new T[capacity];
	}
	
	public int Count => _count;
	public int Capacity
	{
		get => _items.Length;
		set
		{
			if (value < _count) value = _count;
			if (value != _items.Length)
			{
				T[] newItems = new T[value];
				Array.Copy(_items, 0, newItems, 0, _count);
				_items = newItems;
			}
		}
	}
	
	public T this[int index]
	{
		get => _items[index];
		set
		{
			_items[index] = value;
			OnChanged();
		}
	}
	
	public void Add(T item)
	{
		if (_count == Capacity) Capacity = _count * 2;
		_items[_count] = item;
		_count++;
		OnChanged();
	}
	
	protected virtual void OnChanged() =>
		Changed?.Invoke(this, EventArgs.Empty);
	public override bool Equals(object other) =>
		Equals(this, other as MyList<T>);
		
	static bool Equals(MyList<T> a, MyList<T> b)
	{
		if (Object.ReferenceEquals(a, null)) return Object.ReferenceEquals(b, null);
		if (Object.ReferenceEquals(b, null) || a._count != b._count)
			return false;
		for (int i = 0; i < a._count; i++)
		{
			if (!object.Equals(a._items[i], b._items[i]))
			{
				return false;
			}
		}
		
		return true;
	}
	
	public event EventHandler Changed;
	public static bool operator ==(MyList<T> a, MyList<T> b) =>
		Equals(a, b);
	public static bool operator !=(MyList<T> a, MyList<T> b) =>
		!Equals(a, b);

}

class EventExample
{
	static int s_changeCount;
	static void ListChanged(object sender, EventArgs e)
	{
		s_changeCount++;
	}
	public static void Usage()
	{
		var names = new MyList<string>();
		names.Changed += new EventHandler(ListChanged);
		names.Add("Liz");
		names.Add("Martha");
		names.Add("Beth");
		Console.WriteLine(s_changeCount); // "3"
	}
}


