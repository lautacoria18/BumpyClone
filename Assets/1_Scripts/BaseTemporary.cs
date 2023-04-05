using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTemporary : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball") {

            Debug.Log("Rebota");
            if (transform.localScale.x - 0.3f < 0) { 
                Destroy(gameObject);
            }
            transform.localScale = new Vector3(transform.localScale.x - 0.3f, transform.localScale.y, transform.localScale.z);
            //transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 2, Time.deltaTime * 2);
        }
    }
}
