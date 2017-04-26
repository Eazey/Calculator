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
    private readonly string num_zero;
    private string defaultNum;
    private string bufferStr = KeyData.GetKeyValueByName(KeyName.Number_0);
    private KeyType bufferType = KeyType.None;

    /// <summary>
    /// 计算器第一次运行时初始化方法
    /// </summary>
    public InputRegular()
    {
        num_zero = KeyData.GetKeyValueByName(KeyName.Number_0);
        defaultNum = KeyData.GetKeyValueByName(KeyName.Number_0);
    }

    public string GetResultContent(double result)
    {
        defaultNum = result.ToString();

        bufferStr = defaultNum;
        bufferType = KeyType.NumberKey;

        return defaultNum;
    }

    public string ClearContent()
    {
        defaultNum = num_zero;

        bufferStr = defaultNum;
        bufferType = KeyType.NumberKey;

        return defaultNum;
    }

    public string SubContent(string content)
    {
        if (content.Length == 1)
        {
            bufferStr = num_zero;
            bufferType = KeyData.GetKeyTypeByValue(num_zero);
            return num_zero;
        }

        Stack<char> characters = new Stack<char>(content.ToCharArray());
        characters.Pop();

        char Pop_Char = characters.Peek();
        string Pop_String = new string(Pop_Char, 1);

        if (Pop_String == num_zero)
            Pop_String = "1";

        bufferStr = Pop_String;
        bufferType = KeyData.GetKeyTypeByValue(Pop_String);

        var outCharacters = characters.ToArray();
        Array.Reverse(outCharacters);
        return new string(outCharacters);
    }

    public string AddContent(string content, KeyName name, KeyType type)
    {
        string s = KeyData.GetKeyValueByName(name);

        if (content == defaultNum)
        {
            if (AddOnDefalut(s, type))
                content += s;
            else
                content = s;
        }
        else
        {
            if (AddOnEquation(s, type))
                content += s;
        }
        return content;
    }

    private bool AddOnDefalut(string operation, KeyType type)
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

        bufferStr = operation;
        bufferType = type;

        return isAdd;
    }

    private bool AddOnEquation(string operation, KeyType type)
    {
        Debug.Log("AddOnEquation():" + " bufferStr = " + bufferStr + ", bufferType = " + bufferType.ToString());
        Debug.Log("AddOnEquation():" + " operation = " + operation + ", type = " + type.ToString());

        if (bufferType == KeyType.NumberKey && type == KeyType.NumberKey)
        {
            if (bufferStr == num_zero)
            {
                return false;
            }
            else
            {
                bufferStr += operation;
                return true;
            }
        }

        bufferStr = operation;
        bufferType = type;
        return true;
    }
}
