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
        showContent.text = inputRegular.UpdateContent(showContent.text, name);
    }
}


