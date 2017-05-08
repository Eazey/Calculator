/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*	  Script Editor: Eazey丶亦泽                      
/*	  Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	  GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections.Generic;
using UnityEngine;

public class InputRegular
{
    private readonly char num_zero;
    private readonly char magic_value = '1';
    private readonly string errorInfo;

    private string defaultNum;
    private string bufferStr = CalculatorData.GetKeyValueByName(KeyName.Number_0).ToString();
    private KeyType bufferType = KeyType.None;

    /// <summary>
    /// 计算器第一次运行时初始化方法
    /// </summary>
    public InputRegular()
    {
        num_zero = CalculatorData.GetKeyValueByName(KeyName.Number_0);
        defaultNum = num_zero.ToString();
        errorInfo = CalculatorData.GetErrorInfo();
    }

    public string UpdateContent(string content,KeyName name)
    {
        string resultContent = "";

        KeyType type = CalculatorData.GetKeyTypeByName(name);

        switch (type)
        {
            case KeyType.NumberKey:
            case KeyType.NumberPointKey:
            case KeyType.OperatorKey:
            case KeyType.BacketLeftKey:
            case KeyType.BacketRightKey:
                resultContent = AddContent(content, name, type);
                break;

            case KeyType.BackKey:
                resultContent = SubContent(content);
                break;

            case KeyType.ClearKey:
                resultContent = ClearContent();
                break;

            case KeyType.ResultKey:
                resultContent = GetResultContent(content);
                break;
        }

        return resultContent;
    }

    private bool AddOnDefalut(char operation, KeyType type)
    {
        Debug.Log("AddOnEquation():" + " bufferStr = " + bufferStr + ", bufferType = " + bufferType.ToString());
        Debug.Log("AddOnDefalut():" + " operation = " + operation + " type = " + type.ToString());

        bool isAdd = false;

        switch (type)
        {
            case KeyType.NumberKey:
            case KeyType.BacketLeftKey:
            case KeyType.BacketRightKey:
                isAdd = false;
                break;

            case KeyType.NumberPointKey:
            case KeyType.OperatorKey:
                isAdd = true;
                break;
        }

        bufferStr = operation.ToString();
        bufferType = type;

        return isAdd;
    }

    private bool AddOnEquation(char operation, KeyType type)
    {
        Debug.Log("AddOnEquation():" + " bufferStr = " + bufferStr + ", bufferType = " + bufferType.ToString());
        Debug.Log("AddOnEquation():" + " operation = " + operation + ", type = " + type.ToString());

        if (bufferType == KeyType.NumberKey && (type == KeyType.NumberKey || type == KeyType.NumberPointKey))
        {
            if (bufferStr == num_zero.ToString())
            {
                return false;
            }
            else
            {
                char point = CalculatorData.GetKeyValueByName(KeyName.Number_point);
                if (bufferStr.Contains(point.ToString()) && type == KeyType.NumberPointKey)
                    return false;

                bufferStr += operation;
                return true;
            }
        }

        bufferStr = operation.ToString();
        bufferType = type;
        return true;
    }

    private string AddContent(string content, KeyName name, KeyType type)
    {
        if (defaultNum == errorInfo)
            return content;

        char s = CalculatorData.GetKeyValueByName(name);

        if (content == defaultNum)
        {
            if (AddOnDefalut(s, type))
                content += s;
            else
                content = s.ToString();
        }
        else
        {
            if (AddOnEquation(s, type))
                content += s;
        }
        return content;
    }

    private string SubContent(string content)
    {
        if (content.Length == 1)
        {
            bufferStr = num_zero.ToString();
            bufferType = CalculatorData.GetKeyTypeByValue(num_zero);
            return num_zero.ToString();
        }

        Stack<char> characters = new Stack<char>(content.ToCharArray());
        characters.Pop();

        char Pop_Char = characters.Peek();

        if (Pop_Char == num_zero)
            Pop_Char = magic_value;

        bufferStr = Pop_Char.ToString();
        bufferType = CalculatorData.GetKeyTypeByValue(Pop_Char);

        var outCharacters = characters.ToArray();
        Array.Reverse(outCharacters);

        return new string(outCharacters);
    }

    private string ClearContent()
    {
        defaultNum = num_zero.ToString();

        bufferStr = defaultNum;
        bufferType = KeyType.NumberKey;

        return defaultNum;
    }

    private string GetResultContent(string content)
    {
        var result = "";
        var er = new EquationReguler(content);
        result = er.GetResult();

        defaultNum = result;

        bufferStr = defaultNum;
        if (defaultNum != errorInfo)
            bufferType = KeyType.NumberKey;
        else
            bufferType = KeyType.None;

        return defaultNum;
    }
}
