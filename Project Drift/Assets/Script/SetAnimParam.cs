using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimParam : MonoBehaviour
{
    public Animator animator;

    public void SetBool(string Params)
    {
        int count = 0;
        string buffer = "null";
        string Name = "null";
        bool State = false;
        while (buffer != "~")
        {
            buffer = Params.Substring(count, 1);
            count++;
        }
        Name = Params.Substring(0, count-1);
        State = bool.Parse(Params.Substring(count));
        animator.SetBool(Name, State);
    }
    
}
