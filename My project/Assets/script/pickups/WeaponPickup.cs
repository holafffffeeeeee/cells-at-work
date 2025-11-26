using System.Threading;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public AudioSource Audioplayer;
    public AudioClip PickupWeapon;
    [SerializeField] private WeaponData weaponData;

    shooting bu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            shooting playerShooting = other.GetComponent<shooting>();

            Audioplayer.PlayOneShot(PickupWeapon);
            
            if (playerShooting != null)
            {
               
                playerShooting.SetWeaponStats(
                    weaponData.fireRate,
                    weaponData.damage,
                    weaponData.bulletSpeed
                );



            Destroy (gameObject,PickupWeapon.length);

                
            }
        }
    }
}
