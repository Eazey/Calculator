/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*	  Script Editor: Eazey丶亦泽                      
/*	  Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	  GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using UnityEngine.UI;

public class UIManager 
{

    private static UIManager _instance = null;

    /// <summary>
    /// 该实例只能有用来输出的 InputField 对象进行实例化
    /// </summary>
    /// <param name="Display"> 用于输出信息的对象 </param>
    /// <returns> 返回该类的单例 </returns>
    public static UIManager GetInstance(InputField DisplayShow = null)
    {
        if (_instance == null)
            _instance = new UIManager(DisplayShow);
        return _instance;
    }

    private InputField showContent;
    private InputRegular inputRegular;

    private UIManager(InputField DisplayShow)
    {
        showContent = DisplayShow;
        inputRegular = new InputRegular();
    }

    public void InputOperationName(KeyName name)
    {
        KeyType type = CalculatorData.GetKeyTypeByName(name);

        switch(type)
        {
            case KeyType.NumberKey:
            case KeyType.NumberPointKey:
            case KeyType.OperatorKey:
            case KeyType.BacketLeftKey:
            case KeyType.BacketRightKey:
                AddToDisplay(name, type);
                break;

            case KeyType.BackKey:
                SubFormDisplay();
                break;

            case KeyType.ClearKey:
                Clear();
                break;

            case KeyType.ResultKey:
                GetResult();
                break;
        }
    }

    /// <summary>
    /// 添加按钮字符到屏幕显示上
    /// </summary>
    /// <param name="name"> 字符定义名称 </param>
    /// <param name="type"> 字符所属类型 </param>
    private void AddToDisplay(KeyName name, KeyType type)
    {
        showContent.text = inputRegular.AddContent(showContent.text, name, type);   
    }

    /// <summary>
    /// 从屏幕显示上删减字符
    /// </summary>
    private void SubFormDisplay()
    {
        showContent.text = inputRegular.SubContent(showContent.text);
    }

    /// <summary>
    /// 获取运算结果
    /// </summary>
    private void GetResult()
    {
        EquationReguler er = new EquationReguler(showContent.text);
        var result = er.GetResult();
        showContent.text = inputRegular.GetResultContent(result);
    }

    private void Clear()
    {
        showContent.text = inputRegular.ClearContent();
    }
}


