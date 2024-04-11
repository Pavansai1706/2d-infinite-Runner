using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //coins
        if(other.gameObject.tag == "Coin")
        {
            GameManager.Instance.AddScore();
            Destroy(other.gameObject, 0.02f);
        }

        //walls
        if(other.gameObject.tag == "Wall")
        {

            GameManager.Instance.GameOver();
        }
    
    }
}
