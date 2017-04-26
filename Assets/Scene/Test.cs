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
using System.Collections.Generic;

public class Test : MonoBehaviour {

    private LinkedList<string> OperationBuffers;
    private string digital = "123";

    void Awake()
    {

        OperationBuffers = new LinkedList<string>();
        var inf = GetComponent<InputField>();
        inf.onEndEdit.AddListener(myPrint);

    }

    void myPrint(string s)
    {

        OperationBuffers.AddLast(digital);

        var a = OperationBuffers.First;

        print(a.Value);
    } 

	void Start () 
	{
		
	}

	void Update () 
	{
		
	}
}
