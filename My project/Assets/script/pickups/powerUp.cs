using UnityEngine;

public class powerUp : MonoBehaviour
{
    public PowerupEffect powerUpEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            powerUpEffect.apply(other.gameObject);
        }
    }
}
