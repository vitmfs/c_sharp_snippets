using System;
using System.IO;
					
public class ExceptionHandling
{
	public static void Main()
	{
		Console.WriteLine("##### START OF PROGRAM #####\n");
		
		// CODE THAT "CAN'T" FAIL
		// VARIABLE DEFINITION AND INITIALIZATION, ETC...
		
		
		try 
		{
			// THE CODE THAT CAN CAUSE THE EXCEPTION
			// FROM INSIDE A TRY BLOCK, INITIALIZE ONLY VARIABLES THAT ARE DECLARED IN THE TRY BLOCK
		} 
		catch( InvalidCastException ex ) // SEVERAL OPTIONAL CATCH BLOCKS FROM MORE SPECIFIC EXCEPTIONS TO LESS SPECIFIC EXCEPTIONS
		{
			// IN GENERAL, YOU SHOULD ONLY CATCH THE EXCEPTIONS THAT YOU KNOW HOW TO RECOVER FROM
			
		}
		catch( Exception ex ) //when (ex.ParamNameOfExceptionObject == "…") // OPTIONAL CATCH BLOCK FOR THE LESS SPECIFIC EXCEPTION WITH OPTIONAL EXCEPTION FILTER
		{
			// IN GENERAL, YOU SHOULD ONLY CATCH THE EXCEPTIONS THAT YOU KNOW HOW TO RECOVER FROM
			
			// EXCEPTION FILTERS ARE PREFERABLE TO CATCHING AND RETHROWING BECAUSE FILTER LEAVE THE STACK UNHARMED
			if (ex.Source != null)
			{
				Console.WriteLine("IOException source: {0}", ex.Source);
			}
			//throw; // THIS MIGHT BE CATCHED exception HIGHER UP IN THE CALL STACK
			
			Helper.WriteErrorToLogFile( "Error in Method Name (in the identifier of the try catch block?):\n" + ex.ToString() );
	
		}
		finally // OPTIONAL
		{
			// GUARANTEED TO RUN IF THERE IS A CATCH BLOCK
			// RELEASE THE RESOURCES, CLOSE CONNECTIONS, ETC...
			
		}
		
		
		// USING

		// SIMILAR TO THE try-finnaly
		// PROVIDES A CONVENIENT SYNTAX THAT ENSURES THE CORRECT USE OF IDisposable OBJECTS
		// BEGINNING IN C#8.0, THE USING STATEMENT ENSURES THE CORRECT USE OF IAsyncDisposable OBJECTS
		// CHECK IDisposabe OBJECTS:
		// https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=netcore-3.1
		
		
		// EXAMPLE OF USING
		
		// CODE THAT "CAN'T" FAIL
		// VARIABLE DEFINITION AND INITIALIZATION, ETC...
		string manyLines=@"This is line one
		This is line two
		Here is line three
		The penultimate line is line four
		This is the final, fifth line.";

		// IT IS BETTER TO INSTANTIATE THE OBJECT IN THE USING STATEMENT AND LIMIT ITS SCOPE TO THE USING BLOCK
		using (var reader = new StringReader(manyLines) )
		{
			string item;
			do {
				item = reader.ReadLine();
				Console.WriteLine(item);
			} while(item != null);
		}

		Console.WriteLine("##### END OF PROGRAM #######");
		
	}
}

public class Helper
{
	public static string WriteErrorToLogFile( string errorMessageFromMethod )
	{
		string errorMessage = errorMessageFromMethod + "at time " + DateTime.Now.ToString();
		
		// PATH TO ERROR FILE CAN BE HARDCODED
		string pathToErrorFile = @"C:\myfile.txt";
		
		
		if ( File.Exists( pathToErrorFile ) )
		{
			// WRITE MESSAGE TO FILE
			File.AppendAllText( pathToErrorFile, errorMessageFromMethod + Environment.NewLine);
		}
		else
		{
			// CREATE FILE AND WRITE THE MESSAGE
			System.IO.File.WriteAllText( pathToErrorFile, errorMessageFromMethod);
		}
	
		return "";
	}
	
	public static bool ObjectAndPropertiesAreInitialized(Object obj)
	{
		return ObjectIsInitialized( obj ) && AllPropertiesOfObjectAreInitialized( obj );
	
	}
	
	public static bool ObjectIsInitialized( Object obj )
	{
		bool objectIsNull = (obj == null);
		
		if ( objectIsNull )
		{
			return false;
		}
		else
		{
			return true;
		}

	}
	
	public static bool AllPropertiesOfObjectAreInitialized( Object obj )
	{
		foreach (var property in obj.GetType().GetProperties() )
		{
			if (property == null)
			{
				return false;
			}
		}
	
		return true;
	}
	
	



}

// REFERENCES
// https://docs.microsoft.com/en-us/dotnet/standard/exceptions/
// https://stackoverflow.com/questions/9893028/c-sharp-foreach-property-in-object-is-there-a-simple-way-of-doing-this