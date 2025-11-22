using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Weapon Properties")]
    public string weaponName;
    public Sprite weaponIcon;

    [Header("Combat Stats")]
    public float damage = 1f;
    public float fireRate = 0.5f;
    public float bulletSpeed = 20f;

    [Header("Visuals")]
    public GameObject bulletPrefab;
    public Color bulletColor = Color.white;
}
