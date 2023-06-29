using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveToPlayer : MonoBehaviour
{
    [Header("Effects: 0 = Health, 1 = Stamina, \n3 = Ammo")]
    public int value = 0;
    [Header("Enter the effect magnitude: ")]
    public float amount = 10;
	//[SerializeField] private Material myMaterial;
	public Material healthMaterial;
	public Material staminaMaterial;

	public MeshRenderer meshRenderer;
	//public Material healthMaterial;
	
	//void Start()
	//{
	//	rend = GetComponent<Renderer>();
	//	rend.enabled = true;
	//	rend.sharedMaterial = material["Materials/Gold"];
	//}
	void Update()
	{
		if (value == 0) meshRenderer.material = healthMaterial;
		if (value == 1) meshRenderer.material = staminaMaterial;
		//rend.sharedMaterial = material["Materials/Gold"];
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            switch (value)
            {
                case 0:
                    Debug.Log("Contact with Health Pickup");
                    Health.instance.RestoreHealth(amount);
                    Destroy(gameObject);
                    break;
                case 1:
                    Debug.Log("Contact with Stamina Pickup");
                    Stamina.instance.RestoreStamina(amount);
                    Destroy(gameObject);
                    break;
                case 2:
                    Debug.Log("Special Power!");
                    PlayerMovement.instance.BoostSprint(amount);
                    Destroy(gameObject);
                    break;
                case 3:
                    projectileGun.instance.getBulletsLeft(-5);
                    Destroy(gameObject);
                    break;
                default:
                    Debug.Log("Effect not found");
                    break;
            }
        }
    }
}
