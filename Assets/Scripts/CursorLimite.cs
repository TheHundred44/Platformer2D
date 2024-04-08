using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CursorLimite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cursor")
        {
            Physics2D.IgnoreLayerCollision(9, 10, false);
            Debug.Log("e");
        }
        else
        {
            Physics2D.IgnoreLayerCollision(7, 10, true);
            Physics2D.IgnoreLayerCollision(8, 10, true);
            Physics2D.IgnoreLayerCollision(6, 10, true);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag == "Cursor")
    //    {
    //        Physics2D.IgnoreLayerCollision(9, 10, false);
    //        Debug.Log("e");
    //    }
    //    else
    //    {
    //        Physics2D.IgnoreLayerCollision(7, 10, true);
    //        Physics2D.IgnoreLayerCollision(8, 10, true);
    //        Physics2D.IgnoreLayerCollision(6, 10, true);
    //    }
    //}
}
