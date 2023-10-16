using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 6.6f)
        {
          transform.Translate(Vector2.up * Time.deltaTime * 8.0f);
        }
        else
        {
            Destroy(gameObject);
        } 
        
    }
}