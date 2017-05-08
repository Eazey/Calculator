/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*	  Script Editor: Eazey丶亦泽                      
/*	  Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	  GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
 * 首先判断表达式是否正确；
 * 然后将表达式进行分解，
 * 运算数转为double格式进入栈numbersStack，
 * 运算符比较优先级后直接进入栈operatorsStack，
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EquationReguler {

    private readonly string errorInfo;
    private readonly string equation;

    private Stack<char> operatorsStack { get; set; }
    private Stack<double> numbersStack { get; set; }

    public EquationReguler(string Equation)
    {
        errorInfo = CalculatorData.GetErrorInfo();
        equation = Equation;
    }

    public string GetResult()
    {
        if (equation == null || equation == "")
        {
            Debug.LogError("表达式不存在");
            return errorInfo;
        }

        if (!IsReguler())
            return errorInfo;

        var result = Execute();
        var resultStr = Convert.ToString(result);

        return resultStr;
    }

    private bool IsReguler()
    {
        var bufferType = KeyType.None;

        var bracketLeft_Num = 0;
        var bracketRight_Num = 0;

        var charactors = equation.ToCharArray();
        foreach(var c in charactors)
        {
            var newType = CalculatorData.GetKeyTypeByValue(c);

            Debug.Log("bufferType is " + bufferType);
            Debug.Log("currentType is " + newType);

            if (newType == KeyType.BacketLeftKey)
                bracketLeft_Num++;
            if (newType == KeyType.BacketRightKey)
                bracketRight_Num++;

            switch (bufferType)
            {
                case KeyType.None:
                    if (newType != KeyType.NumberKey && newType != KeyType.BacketLeftKey)
                        return false;
                    break;

                case KeyType.NumberKey:
                    if (newType == KeyType.BacketLeftKey)
                        return false;
                    break;

                case KeyType.NumberPointKey:
                    if (newType != KeyType.NumberKey)
                        return false;
                    break;

                case KeyType.OperatorKey:
                    if (newType != KeyType.NumberKey && newType != KeyType.BacketLeftKey)
                        return false;
                    break;

                case KeyType.BacketLeftKey:
                    if (newType != KeyType.NumberKey)
                        return false;
                    break;

                case KeyType.BacketRightKey:
                    if (newType != KeyType.OperatorKey)
                        return false;
                    break;
            }

            bufferType = newType;
        }

        if (bufferType == KeyType.BacketLeftKey || bufferType == KeyType.OperatorKey)
            return false;

        if (bracketLeft_Num != bracketRight_Num)
            return false;

        return true;
    }

    private double Execute()
    {
        operatorsStack = new Stack<char>();
        numbersStack = new Stack<double>();

        var bufferNumString = "";

        var operations = equation.ToCharArray();
        foreach(var operation in operations)
        {
            var type = CalculatorData.GetKeyTypeByValue(operation);
            var name = CalculatorData.GetKeyNameByValue(operation);

            switch (type)
            {
                case KeyType.NumberKey:
                case KeyType.NumberPointKey:
                    bufferNumString += operation;
                    break;

                case KeyType.OperatorKey:
                case KeyType.BacketLeftKey:
                case KeyType.BacketRightKey:
                    if (bufferNumString != "")
                    {
                        InputNumberStack(bufferNumString);
                        bufferNumString = "";
                    }
                    InputOperatorStack(type, name);
                    break;
            }
        }

        if (bufferNumString != "")
        {
            InputNumberStack(bufferNumString);
            bufferNumString = "";
        }

        var result = OutputResult();
        return result;
    }

    private void InputOperatorStack(KeyType type, KeyName name)
    {
        switch (type)
        {
            case KeyType.OperatorKey:
                InputOperatorStack_Operator(name);
                break;

            case KeyType.BacketLeftKey:
                InputOperatorStack_BacketLeftKey(name);
                break;

            case KeyType.BacketRightKey:
                InputOperatorStack_BacketRightKey();
                break;
        }
    }

    private void InputNumberStack(string numString)
    {
        double number = Convert.ToDouble(numString);
        numbersStack.Push(number);
    }

    private void InputOperatorStack_Operator(KeyName newName)
    {
        char newOperator = CalculatorData.GetKeyValueByName(newName);
        int newLevel = OperatorFactory.OperatorPriority(newOperator);

        while (operatorsStack.Count != 0 &&
            operatorsStack.Peek() != CalculatorData.GetKeyValueByName(KeyName.Bracket_Left))
        {
            var oldOperator = operatorsStack.Peek();
            var oldLevel = OperatorFactory.OperatorPriority(oldOperator);

            if (newLevel <= oldLevel)
            {
                Calculate();
            }
            else
            {
                operatorsStack.Push(newOperator);
                return;
            }
        }
        operatorsStack.Push(newOperator);
    }

    private void InputOperatorStack_BacketLeftKey(KeyName newName)
    {
        var newOperator = CalculatorData.GetKeyValueByName(newName);
        operatorsStack.Push(newOperator);
    }

    private void InputOperatorStack_BacketRightKey()
    {
        while (operatorsStack.Peek() != CalculatorData.GetKeyValueByName(KeyName.Bracket_Left))
        {
            Calculate();
        }
        operatorsStack.Pop();
    }

    private void Calculate()
    {
        char operatorChar = operatorsStack.Pop();

        double number1 = numbersStack.Pop();
        double number2 = numbersStack.Pop();
        double result = OperatorFactory.GetResult(operatorChar, number1, number2);

        numbersStack.Push(result);
    }

    private double OutputResult()
    {
        double result = 0.0f;

        while(operatorsStack.Count!=0)
        {
            Calculate();
        }
        result = numbersStack.Pop();

        Debug.LogError("OperatorsStack is " + operatorsStack.Count);
        Debug.LogError("OperatorsStack is " + numbersStack.Count);

        return result;
    }
}

