using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Powerups/healthBuff")]
public class HealthBuff : PowerupEffect
{
    Health hm;

    public float amount ;
    public override void apply(GameObject taget)
    {
        Health hm = taget.GetComponent<Health>();
        if (hm != null)
        {
            hm.Heal(amount);
        }

    }
}
