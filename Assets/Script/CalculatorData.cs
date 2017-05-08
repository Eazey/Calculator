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

public static class CalculatorData
{
    public static readonly Dictionary<KeyName, char> operationDic;
    private static List<KeyName> Keys = null;
    private static List<char> Values = null;

    #region 键值常量
    private const char NUMBER_0 = '0';
    private const char NUMBER_1 = '1';
    private const char NUMBER_2 = '2';
    private const char NUMBER_3 = '3';
    private const char NUMBER_4 = '4';
    private const char NUMBER_5 = '5';
    private const char NUMBER_6 = '6';
    private const char NUMBER_7 = '7';
    private const char NUMBER_8 = '8';
    private const char NUMBER_9 = '9';

    private const char NUMBER_POINT = '.';

    private const char OPERATOR_ADDITION = '+';
    private const char OPERATOR_SUBTRACT = '-';
    private const char OPERATOR_MULTIPLY = '*';
    private const char OPERATOR_DIVISION = '/';

    private const char BACKET_LEFT = '(';
    private const char BACKET_RIGHT = ')';
    #endregion


    #region 特殊值常量
    private const string ERROR_EQUATION = "表达式错误";
    #endregion

    static CalculatorData()
    {
        operationDic = new Dictionary<KeyName, char>
        {
            {KeyName.Number_0, NUMBER_0},
            {KeyName.Number_1, NUMBER_1},
            {KeyName.Number_2, NUMBER_2},
            {KeyName.Number_3, NUMBER_3},
            {KeyName.Number_4, NUMBER_4},
            {KeyName.Number_5, NUMBER_5},
            {KeyName.Number_6, NUMBER_6},
            {KeyName.Number_7, NUMBER_7},
            {KeyName.Number_8, NUMBER_8},
            {KeyName.Number_9, NUMBER_9},
            {KeyName.Number_point, NUMBER_POINT},

            {KeyName.Operator_Addition, OPERATOR_ADDITION},
            {KeyName.Operator_Subtract, OPERATOR_SUBTRACT},
            {KeyName.Operator_Multiply, OPERATOR_MULTIPLY},
            {KeyName.Operator_Division, OPERATOR_DIVISION},

            {KeyName.Bracket_Left, BACKET_LEFT},
            {KeyName.Bracket_Right, BACKET_RIGHT},
        };

        Keys = new List<KeyName>(operationDic.Keys);
        Values = new List<char>(operationDic.Values);
    }

    public static char GetKeyValueByName(KeyName keyName)
    {
        if (!Keys.Contains(keyName))
            return '\0';

        char operation = operationDic[keyName];
        return operation;
    }

    public static KeyName GetKeyNameByValue(char value)
    {
        if (!Values.Contains(value))
            return KeyName.None;

        int index = Values.IndexOf(value);
        return Keys[index];
    }

    public static KeyType GetKeyTypeByValue(char value)
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

    public static string GetErrorInfo()
    {
        return ERROR_EQUATION;
    }
}
