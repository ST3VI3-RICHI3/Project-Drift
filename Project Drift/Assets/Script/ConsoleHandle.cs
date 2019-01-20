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
#pragma warning disable CS0164 // This label has not been referenced
        CMDInterp:
#pragma warning restore CS0164 // This label has not been referenced
        if (CMDBuffer.Length >= 9)
        {
            if (CMDBuffer.Length >= 4)
            {
                if (CMDBuffer == "exit")
                {
                    Application.Quit();
                }
                if (CMDBuffer.Length >= 11)
                {
                    if (CMDBuffer.Substring(0, 11) == "CreateScene")
                    {
                        if (CMDBuffer.Length >= 13)
                        {
                            SceneManager.CreateScene(CMDBuffer.Substring(12));
                        }
                        else
                        {
                            //invalidSyntaxErr;
                        }
                    }
                }
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

            } }
        else
        {
            //UnknownCMDErr;
        }
	}
}
