/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*	  Script Editor: Eazey丶亦泽                      
/*	  Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	  GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using UnityEngine;


public class OperatorFactory
{
    private const char ADDITION = '+';
    private const char SUBTRACK = '-';
    private const char MULTIPLY = '*';
    private const char DIVISION = '/';

    #region 优先级
    private const int LEVEL_1 = 1;
    private const int LEVEL_2 = 2;
    private const int LEVEL_XXX = 999;
    #endregion

    public static double GetResult(char op, double number1, double number2)
    {
        OperatorReguler opReguler = null;

        switch (op)
        {
            case ADDITION:
                AddOperator add = new AddOperator(number1, number2);
                opReguler = add;
                break;

            case SUBTRACK:
                SubOperator sub = new SubOperator(number2, number1);
                opReguler = sub;
                break;

            case MULTIPLY:
                MulOperator mul = new MulOperator(number1, number2);
                opReguler = mul;
                break;

            case DIVISION:
                DivOperator div = new DivOperator(number2, number1);
                opReguler = div;
                break;
        }

        return opReguler.GetResult();
    }

    public static int OperatorPriority(char op)
    {
        switch (op)
        {
            case ADDITION:
                return LEVEL_1;

            case SUBTRACK:
                return LEVEL_1;

            case MULTIPLY:
                return LEVEL_2;

            case DIVISION:
                return LEVEL_2;

            default:
                Debug.LogError("OperatorPriority Parameter is : " + op);
                return LEVEL_XXX;
        }
    }
}


public abstract class OperatorReguler
{
    public abstract double GetResult();
}


public abstract class DoubleOperator : OperatorReguler
{

    protected double numberA { get; set; }
    protected double numberB { get; set; }

    public DoubleOperator(double number1, double number2)
    {
        numberA = number1;
        numberB = number2;
    }

    public abstract override double GetResult();
}


public class AddOperator : DoubleOperator
{

    public AddOperator(double number1, double number2) : base(number1, number2) { }

    public override double GetResult()
    {
        return numberA + numberB;
    }
}


public class SubOperator : DoubleOperator
{

    public SubOperator(double number1, double number2) : base(number1, number2) { }

    public override double GetResult()
    {
        return numberA - numberB;
    }
}


public class MulOperator : DoubleOperator
{

    public MulOperator(double number1, double number2) : base(number1, number2) { }

    public override double GetResult()
    {
        return numberA * numberB;
    }
}


public class DivOperator : DoubleOperator
{

    public DivOperator(double number1, double number2) : base(number1, number2) { }

    public override double GetResult()
    {
        return numberA / numberB;
    }
}
