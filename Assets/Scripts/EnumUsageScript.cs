using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumUsageScript : MonoBehaviour
{
// Variable of the first script's type
    public EnumSetupScript enumSetupScript;

    void Start()
    {
        // Access and change the public enum instance
        enumSetupScript.currentEnumState = EnumSetupScript.MyEnumState.State1;

        // Check the enum state and perform actions accordingly
        if (enumSetupScript.currentEnumState == EnumSetupScript.MyEnumState.State1)
        {
            Debug.Log("Enum state is State1");
        }
        else if (enumSetupScript.currentEnumState == EnumSetupScript.MyEnumState.State2)
        {
            Debug.Log("Enum state is State2");
        }
        else if (enumSetupScript.currentEnumState == EnumSetupScript.MyEnumState.State3)
        {
            Debug.Log("Enum state is State3");
        }
        else
        {
            Debug.Log("Enum state is unknown");
        }
    }
}

