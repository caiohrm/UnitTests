using System;
namespace UnitTest
{
	public class Calculator
	{
		public Calculator()
		{
		}

		

		public decimal Sum(params decimal[] valuesToAdd)
		{
			return valuesToAdd.Sum(x => x);
		}
	}
}

