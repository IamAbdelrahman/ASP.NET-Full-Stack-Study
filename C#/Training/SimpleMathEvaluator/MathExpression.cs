/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: MathExpression.cs
 *  @brief This file includes the expression's elements
 * as it includes operands and the type of operation
 *
 *****************************************************************************/

namespace CSharpLabs;

public class MathExpression
{
  public double LeftSideOperand { get; set; }
  public double RightSideOperand { get; set; }
  public MathOperation Operation { get; set; }

}
