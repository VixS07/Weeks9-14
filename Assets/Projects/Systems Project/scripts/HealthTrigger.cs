using UnityEngine;

public class HealthTrigger : MonoBehaviour
{
    bool isTakingDamage = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealPlayer()
    {
        Debug.Log("Player has been healed");
    }

    public void DamagePlayer()
    {
        if (!isTakingDamage)
        {
            Debug.Log("Player has been damaged");
        }
        isTakingDamage=true;
    }

    public void LeftSpike()
    {
        isTakingDamage = false;
    }
}
