using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int shooterID;
    public float damage = 1f;
    float lifeTime = 1f;

    public void Awake() 
    { 
        
        Destroy(gameObject, lifeTime); 
    }
}
