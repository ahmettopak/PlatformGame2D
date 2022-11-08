using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    public float moveSpeed;
    public float jumpSpeed;
    public int score;
    Animator animator; 
    public GameObject gameOverScene;
    public GameObject panel;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        
        rgb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
        score = 0;
    }
  
    void Update() {
        if (transform.position.y<-7) {
            GameOver();
        }
        scoreText.text = "Score: "+score.ToString();
        Move(); 
        Jump();     
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Spikes") {
            GameOver();
        }
        if (collision.gameObject.tag == "PortalOn") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.tag == "PortalOff") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    void GameOver() {
        Time.timeScale = 0;
        gameOverScene.SetActive(true);
        panel.SetActive(true);
    }
    void Jump() 
        {
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0f)) {
            animator.SetBool("IsJump", true);
            rgb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);


        }

        if (animator.GetBool("IsJump") && Mathf.Approximately(rgb.velocity.y, 0)) {
            animator.SetBool("IsJump", false);

        }
    }
    void Move() {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        animator.SetFloat("Speed", math.abs(Input.GetAxisRaw("Horizontal")));

        if (Input.GetAxisRaw("Horizontal") == -1 && Time.timeScale > 0) {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        if (Input.GetAxisRaw("Horizontal") == 1 && Time.timeScale > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        transform.position += velocity * moveSpeed * Time.deltaTime;
    }
}
