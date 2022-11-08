using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class PlatfromController : MonoBehaviour
{
    public UnityEngine.Transform max, min;
    public float speed;
    Vector2 target;

    private void Start() {
        target= min.position;
    }

    private void Update() {
        if (Vector2.Distance(transform.position, max.position) < .1) target = min.position;
        if (Vector2.Distance(transform.position, min.position) < .1) target = max.position;
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) { 
            collision.transform.SetParent(null);
        }
           
    }


}
