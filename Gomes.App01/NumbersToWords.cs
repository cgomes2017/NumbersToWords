using System;
using System.Collections.Generic;
using System.Text;

namespace Gomes.App01
{
    class NumbersToWords
    { 
        public NumbersToWords()
        {
			String temp = "";
			String result = "";
			String input;

		    Console.WriteLine("input a number");
			input = Console.ReadLine();

			if (double.Parse(input) > 999999 || double.Parse(input) < -999999)
			{
				Console.WriteLine(input + "is not valid");
				return;
			}

			if (input[0] == '-')
				result += "negative ";

			if (input[0] == '-' || input[0] == '+')
				input = input.Substring(1);

			Console.WriteLine("without decimal " + input);

			if (decimals(input))
			{
				String rounded = rounding(double.Parse(input), 3);

				if (rounded.Length > 3)
				{
					for (int a = 0; a < rounded.Length - 3; a++)
					{
						temp += rounded[a];

					}

					result += NumberToWords(temp) + " thousand ";
				}

				result += NumberToWords(rounded);

				Console.WriteLine(input + " converted to words is " + result);
			}
			else
			{
				if (input.Length> 3)
				{
					for (int a = 0; a < input.Length - 3; a++)
					{
						temp += input[a];

					}

					result += NumberToWords(temp) + " thousand ";
				}

				result += NumberToWords(input);

				Console.WriteLine(input + " convreted to words is " + result);
			}

		}

		public String NumberToWords(String theNumber)
		{
			String theResult;

			theResult = findHundreds(theNumber);

			theResult += findTens(theNumber);

			if (theNumber.Length == 1)
				theResult += findOnes(theNumber);

			if (theNumber.Length > 1 && findCharacter(theNumber, 2) != '1')
				theResult += findOnes(theNumber);

			return theResult;
		}

		public String findHundreds(String theNumber)
		{
			if (theNumber.Length > 2)
			{
				char theChar = findCharacter(theNumber, 3);

				return findOnesAndHundreds(theChar) + " hundred ";
			}

			return "";
		}

		public String findTens(String theNumber)
		{
			if (theNumber.Length > 1)
			{
				char theChar = findCharacter(theNumber, 2);

				if (theChar == '1')
				{
					return findTeensPlace(theNumber);
				}
				else
				{
					return findTensPlace(theChar, theNumber) + " ";
				}
			}

			return "";
		}

		public String findOnes(String theNumber)
		{
			char theChar = findCharacter(theNumber, 1);

			return findOnesAndHundreds(theChar);
		}

		public String findOnesAndHundreds(char theChar)
		{
			String theWord;

			switch (theChar)
			{
				case '0':
					theWord = "";
					break;
				case '1':
					theWord = "one";
					break;
				case '2':
					theWord = "two";
					break;
				case '3':
					theWord = "three";
					break;
				case '4':
					theWord = "four";
					break;
				case '5':
					theWord = "five";
					break;
				case '6':
					theWord = "six";
					break;
				case '7':
					theWord = "seven";
					break;
				case '8':
					theWord = "eight";
					break;
				case '9':
					theWord = "nine";
					break;
				default:
					theWord = "error";
					break;
			}

			return theWord;
		}

		public String findTensPlace(char theChar, String theNumber)
		{
			String theWord;

			switch (theChar)
			{
				case '0':
					theWord = "";
					break;
				case '1':
					theWord = findTeensPlace(theNumber);
					break;
				case '2':
					theWord = "twenty";
					break;
				case '3':
					theWord = "thirty";
					break;
				case '4':
					theWord = "fourty";
					break;
				case '5':
					theWord = "fifty";
					break;
				case '6':
					theWord = "sixty";
					break;
				case '7':
					theWord = "seventy";
					break;
				case '8':
					theWord = "eighty";
					break;
				case '9':
					theWord = "ninety";
					break;
				default:
					theWord = "error";
					break;
			}

			return theWord;
		}

		public String findTeensPlace(String theNumber)
		{
			String theWord;

			char theChar = findCharacter(theNumber, 1);

			switch (theChar)
			{
				case '0':
					theWord = "ten";
					break;
				case '1':
					theWord = "eleven";
					break;
				case '2':
					theWord = "twelve";
					break;
				case '3':
					theWord = "thirteen";
					break;
				case '4':
					theWord = "fourteen";
					break;
				case '5':
					theWord = "fifteen";
					break;
				case '6':
					theWord = "sixteen";
					break;
				case '7':
					theWord = "seventeen";
					break;
				case '8':
					theWord = "eighteen";
					break;
				case '9':
					theWord = "nineteen";
					break;
				default:
					theWord = "error";
					break;
			}

			return theWord;
		}

		public char findCharacter(String number, int digit)
		{
			int numberOfCharacters = number.Length;

			numberOfCharacters -= digit;

			return number[numberOfCharacters];

		}

		public bool decimals(String number)
		{
			if (number.Contains(".")) ;
			{
				if (number[number.Length - 1] == '.' || number[number.Length - 2] == '.')
					return true;
			}

			return false;
		}

		public String rounding(double number, int place)
		{
			number /= Math.Pow(10, 3);

			double tempDouble = (number * Math.Pow(10, place));
			tempDouble += .5;

			int tempInt = (int)tempDouble;

			return tempInt.ToString();

		}

	}
}
