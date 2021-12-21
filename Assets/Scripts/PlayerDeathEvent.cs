using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathEvent : MonoBehaviour
{
    [SerializeField]private AudioSource Death;
    
    void Start()
    {
        
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
        }
        
    }
    private void Die()
    {
        PlayerMovement.anim.SetTrigger("death");
        PlayerMovement.rb.bodyType = RigidbodyType2D.Static;
        Death.Play();

    }
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
