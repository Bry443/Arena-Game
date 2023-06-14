using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{

    void Update(){
        if (transform.position.y < -4f){
            Die();
            Health.instance.TakeDamage(20);
        }

        if(transform.position.y < 1)
        {
            Health.instance.TakeDamage(.5f);
        }
        
    }
    // private void OnCollisionEnter(Collision collision) {
    //     if (collision.gameObject.CompareTag("Lava"))
    //     {
    //         Health.instance.TakeDamage(10);
    //     }
    // }
    [SerializeField] AudioSource deathSound;

    void Die(){
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(ReloadLevel), 2f);
    }

    void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
