using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;

    shooting bu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shooting playerShooting = other.GetComponent<shooting>();

            if (playerShooting != null)
            {
                playerShooting.SetWeaponStats(
                    weaponData.fireRate,
                    weaponData.damage,
                    weaponData.bulletSpeed
                );

                Destroy(gameObject);
            }
        }
    }
}
