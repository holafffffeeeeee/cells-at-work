using System.Threading;
using UnityEngine;

public class ShotGunPickup : MonoBehaviour
{
    public AudioSource Audioplayer;
    public AudioClip PickupShotGun;
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;

    shooting bu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            shooting playerShooting = other.GetComponent<shooting>();

            Audioplayer.PlayOneShot(PickupShotGun);
            
            if (playerShooting != null)
            {
               
                playerShooting.SetWeaponStats(
                    weaponData.fireRate,
                    weaponData.damage,
                    weaponData.bulletSpeed
                );



            Destroy (gameObject,PickupShotGun.length);

                
            }
        }
    }
}
