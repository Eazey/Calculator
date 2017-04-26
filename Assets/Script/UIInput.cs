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
using UnityEngine.UI;
using System.Collections;

public class UIInput : MonoBehaviour {

    private Button operatorBtn;
    private UIManager manager;

    [SerializeField] private KeyName key;

    /// <summary>
    /// 需要在输出端初始化结束后再初始化输入端
    /// </summary>
	void Start () 
	{
        manager = UIManager.GetInstance();

        operatorBtn = GetComponent<Button>();
        operatorBtn.onClick.AddListener(() => manager.InputOperationName(key));
	}
}
