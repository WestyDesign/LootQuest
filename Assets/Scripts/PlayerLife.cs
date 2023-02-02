#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion

public class PlayerLife : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Death"); // plays the death animation via a 'trigger' in the animator
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // allows manual restarts whenever
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reloads the current level after a death
    }
}
