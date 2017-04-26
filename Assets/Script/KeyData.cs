/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*	  Script Editor: Eazey丶亦泽                      
/*	  Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	  GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Collections.Generic;

public static class KeyData
{
    public static readonly Dictionary<KeyName, string> operationDic;
    private static List<KeyName> Keys = null;
    private static List<string> Values = null;

    #region 键值常量
    private const string NUMBER_0 = "0";
    private const string NUMBER_1 = "1";
    private const string NUMBER_2 = "2";
    private const string NUMBER_3 = "3";
    private const string NUMBER_4 = "4";
    private const string NUMBER_5 = "5";
    private const string NUMBER_6 = "6";
    private const string NUMBER_7 = "7";
    private const string NUMBER_8 = "8";
    private const string NUMBER_9 = "9";

    private const string NUM_POINT = ".";

    private const string OPERATOR_ADDITION = "+";
    private const string OPERATOR_SUBTRACT = "-";
    private const string OPERATOR_MULTIPLY = "*";
    private const string OPERATOR_DIVISION = "/";

    private const string BACKET_LEFT = "(";
    private const string BACKET_RIGHT = ")";
    #endregion

    static KeyData()
    {
        operationDic = new Dictionary<KeyName, string>
        {
            {KeyName.Number_0, "0"},
            {KeyName.Number_1, "1"},
            {KeyName.Number_2, "2"},
            {KeyName.Number_3, "3"},
            {KeyName.Number_4, "4"},
            {KeyName.Number_5, "5"},
            {KeyName.Number_6, "6"},
            {KeyName.Number_7, "7"},
            {KeyName.Number_8, "8"},
            {KeyName.Number_9, "9"},
            {KeyName.Number_point, "."},

            {KeyName.Operator_Addition, "+"},
            {KeyName.Operator_Subtract, "-"},
            {KeyName.Operator_Multiply, "*"},
            {KeyName.Operator_Division, "/"},

            {KeyName.Bracket_Left, "("},
            {KeyName.Bracket_Right, ")"},
        };

        Keys = new List<KeyName>(operationDic.Keys);
        Values = new List<string>(operationDic.Values);
    }

    public static string GetKeyValueByName(KeyName keyName)
    {
        if (!Keys.Contains(keyName))
            return null;

        string operation = operationDic[keyName];
        return operation;
    }

    public static KeyName GetKeyNameByValue(string value)
    {
        if (!Values.Contains(value))
            return KeyName.None;

        int index = Values.IndexOf(value);
        return Keys[index];
    }

    public static KeyType GetKeyTypeByValue(string value)
    {
        KeyName name = GetKeyNameByValue(value);
        KeyType type = GetKeyTypeByName(name);

        return type;
    }

    public static KeyType GetKeyTypeByName(KeyName keyName)
    {
        switch (keyName)
        {
            case KeyName.Number_0:
            case KeyName.Number_1:
            case KeyName.Number_2:
            case KeyName.Number_3:
            case KeyName.Number_4:
            case KeyName.Number_5:
            case KeyName.Number_6:
            case KeyName.Number_7:
            case KeyName.Number_8:
            case KeyName.Number_9:
                return KeyType.NumberKey;

            case KeyName.Number_point:
                return KeyType.NumberPointKey;

            case KeyName.Operator_Addition:
            case KeyName.Operator_Subtract:
            case KeyName.Operator_Multiply:
            case KeyName.Operator_Division:
                return KeyType.OperatorKey;

            case KeyName.Bracket_Left:
                return KeyType.BacketLeftKey;

            case KeyName.Bracket_Right:
                return KeyType.BacketRightKey;

            case KeyName.GetResult:
                return KeyType.ResultKey;

            case KeyName.Back:
                return KeyType.BackKey;

            case KeyName.Clear:
                return KeyType.ClearKey;
        }

        return KeyType.None;
    }
}
