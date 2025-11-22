using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Powerups/healthBuff")]
public class HealthBuff : PowerupEffect
{
    HealthManager hm;

    public float amount ;
    public override void apply(GameObject taget)
    {
        HealthManager hm = taget.GetComponent<HealthManager>();
        if (hm != null)
        {
            hm.Heal(amount);
        }

    }
}
