using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumSetupScript : MonoBehaviour
{
// Define public enum with three states
    public enum MyEnumState
    {
        State1,
        State2,
        State3
    }

    // Public instance of the enum
    public MyEnumState currentEnumState;
}
