using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveToPlayer : MonoBehaviour
{
    [SerializeField] AudioSource pickupSound;
    [Header("Effects: 0 = Health, 1 = Stamina, \n2 = SpeedBoost, 3 = Ammo, \n4 = Bonus Points")]
    public int value = 0;
    [Header("Enter the effect magnitude: ")]
    public float amount = 10;

	public Material healthMaterial;
	public Material staminaMaterial;
	public Material boostMaterial;
	public Material ammoMaterial;
    public Material pointsMaterial;

	public MeshRenderer meshRenderer;
	//}
	void Update()
	{
		switch (value)
            {
                case 0:
                    meshRenderer.material = healthMaterial;
                    break;
                case 1:
                    meshRenderer.material = staminaMaterial;
                    break;
                case 2:
                    meshRenderer.material = boostMaterial;
                    break;
                case 3:
                    meshRenderer.material = ammoMaterial;
                    break;
                default:
                    meshRenderer.material = pointsMaterial;
                    break;
            }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            pickupSound.Play();
            Debug.Log("Contact with Pickup");
            switch (value)
            {
                case 0:
                    Health.instance.RestoreHealth(amount);
                    //PlayerScore.instance.UpdateScore(amount);
                    Destroy(gameObject);
                    break;
                case 1:
                    Stamina.instance.RestoreStamina(amount);
                    Destroy(gameObject);
                    break;
                case 2:
                    PlayerMovement.instance.BoostSprint(amount);
                    Destroy(gameObject);
                    break;
                case 3:
                    projectileGun.instance.getBulletsLeft(-5);
                    Destroy(gameObject);
                    break;
                default:
                    Debug.Log("You've been awarded " + amount + " points!");
                    //PlayerScore.instance.UpdateScore(amount);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
