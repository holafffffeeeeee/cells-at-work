using UnityEngine;

public class powerUp : MonoBehaviour
{
    public AudioSource Audioplayer;
    public AudioClip PickupHealth;
    public PowerupEffect powerUpEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D other)
    {
        Audioplayer.PlayOneShot(PickupHealth);
        if ( other.gameObject.tag == "Player")
        {
            Destroy(gameObject,PickupHealth.length);
            powerUpEffect.apply(other.gameObject);
        }
    }
}
