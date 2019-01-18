using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ConsoleHandle : MonoBehaviour {

    // Update is called once per frame
    public InputField CommandLineFeild;
	public void CommandSend() {
        string CMDBuffer = null;
        CMDBuffer = CommandLineFeild.text;
        CommandLineFeild.text = "";
        if (CMDBuffer.Length >= 9)
        {
            if (CMDBuffer.Substring(0, 9) == "LoadScene")
            {
                if (CMDBuffer.Length >= 11)
                {
                    try
                    {
                        SceneManager.LoadScene(int.Parse(CMDBuffer.Substring(10)));
                    }
                    catch
                    {
                        SceneManager.LoadScene(CMDBuffer.Substring(10));
                    }
                }
                else
                {
                    //invalidSyntaxErr;
                }
            }
            
        }
        else
        {
            //UnknownCMDErr;
        }
	}
}
