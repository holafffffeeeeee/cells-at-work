using System.Threading;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
     public shooting shooting;
    public AudioSource Audioplayer;
    public AudioClip PickupWeapon;
    [SerializeField] private WeaponData weaponData;


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
                    weaponData.bulletSpeed);
                   if(gameObject.tag == "Shotgun")
                   {
                    shooting.ShotgunState = true;
                    Debug.Log("hi");
                         if(shooting.ShotgunState == true )
                         {
                        playerShooting.SetWeaponStats(
                         weaponData.fireRate,
                        weaponData.damage,
                        weaponData.bulletSpeed);
                    Debug.Log("hi");    
                         }
                   }

               
                



            Destroy (gameObject,PickupWeapon.length);

                
            }
        }
    }
}
