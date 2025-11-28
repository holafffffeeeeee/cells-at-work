using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject health1,heath2;
    public Image healthBar;
    public float healthAmount = 100f;

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
        health1.SetActive(true);
        heath2.SetActive(true);
        heath2.GetComponent<HealthManager>().isDead = false;
     heath2.GetComponent<HealthManager>(). healthAmount += 100f;
            heath2.GetComponent<HealthManager>().healthBar.fillAmount = 1f;
        heath2.GetComponent<HealthManager>().gameObject.SetActive(true);
    
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
        gameObject.SetActive(false);

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
