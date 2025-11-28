using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public shooting Shooting;
    public Image healthBar;
    public float healthAmount = 100f;
    public Collider2D PlayerCollider;

   public bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void Revive()
    {
      healthAmount = 100f;
    healthBar.fillAmount = 1f;
      isDead = false;
      spriteRenderer.enabled = true;
        Shooting.enabled = true;
        PlayerCollider.enabled = true;
        healthBar.gameObject.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        healthAmount -= damage;
        healthAmount = Mathf.Max(0, healthAmount);
        healthBar.fillAmount = healthAmount / 100f;

        if (healthAmount <= 0)
        {
            Die();
        }
        Debug.Log("yo");
    }


    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        healthBar.gameObject.SetActive(false);
        Shooting.enabled = false;
        PlayerCollider.enabled = false;
        spriteRenderer.enabled = false;
        

        if (LevelManager.manager != null)
        {
            LevelManager.manager.OnPlayerDeath();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemey")
        {
            TakeDamage(5);
        }
    }

}
