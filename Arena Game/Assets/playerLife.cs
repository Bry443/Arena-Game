using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{

    void Update(){
        if (transform.position.y < -4f){
            Die();
        }
    }
    [SerializeField] AudioSource deathSound;
    private void OnCollisionEnter(Collision collision) {
        while (collision.gameObject.CompareTag("Lava"))
        {
            Health.instance.TakeDamage(1);
        }
        
    }

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
