/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: ExpressionParser.cs
 *  @brief This file parses the expression from a user to form at the end
 * a valid math expression
 *
 *****************************************************************************/

namespace CSharpLabs;

public class ExpressionParser
{
  private const string MathSymbols = "+*/%^";
  public static MathExpression Parse(string input)
  {
    var expr = new MathExpression();
    string token = "";
    bool leftSideInitialized = false;
    for (int i = 0; i < input.Length; i++)
    {
      var currentChar = input[i];
      if (char.IsDigit(currentChar))
      {
        token += currentChar;
        if (i == input.Length - 1 && leftSideInitialized)
        {
          expr.RightSideOperand = double.Parse(token);
          token = "";
          break;
        }
      }
      else if (MathSymbols.Contains(currentChar))
      {
        if (!leftSideInitialized)
        {
          expr.LeftSideOperand = double.Parse(token);
          token = "";
          leftSideInitialized = true;
        }
        expr.Operation = ParseMathOperation(currentChar.ToString());
        token = "";
      }
      else if (currentChar == '-' && i > 0)
      {
        if (expr.Operation == MathOperation.None)
        {
          expr.Operation = MathOperation.Subtraction;
          if (!leftSideInitialized)
          {
            expr.LeftSideOperand = double.Parse(token);
            leftSideInitialized = true;
            token = "";
          }

        }
        else
        {
          token += currentChar;
        }
      }
      else if (char.IsLetter(currentChar))
      {
        token += currentChar;
        leftSideInitialized = true;
      }
      else if (currentChar == ' ')
      {
        if (!leftSideInitialized)
        {
          expr.LeftSideOperand = double.Parse(token);
          leftSideInitialized = true;
          token = "";
        }
        else if (expr.Operation == MathOperation.None)
        {
          expr.Operation = ParseMathOperation(token);
          token = "";
        }
      }
      else
      {
        token += currentChar;
      }
    }
    return expr;
  }
  private static MathOperation ParseMathOperation(string operation)
  {
    switch (operation.ToLower())
    {
      case "+":
        return MathOperation.Addition;
      case "*":
        return MathOperation.Multiplication;
      case "/":
        return MathOperation.Division;
      case "^":
        return MathOperation.Power;
      case "%":
      case "mod":
        return MathOperation.Modulus;
      case "sin":
        return MathOperation.Sin;
      case "cos":
        return MathOperation.Cos;
      case "tan":
        return MathOperation.Tan;
      default:
        return MathOperation.None;
    }
  }
}
