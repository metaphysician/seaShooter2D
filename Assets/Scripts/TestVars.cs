using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVars : MonoBehaviour
{
    public int number = 123;
    private float fnumber = 12.3f;
    public bool correct = true;
    [SerializeField]
    private string name;

    void Start()
    {
        name = "Cedric";
    }

}
