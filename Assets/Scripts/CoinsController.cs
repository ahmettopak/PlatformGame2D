using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour {
    
    private void OnCollisionEnter2D(Collision2D collision) {
       
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.tag=="Player") {

            playerController.score += 5;
            gameObject.SetActive(false);
           
        }
    }
}
