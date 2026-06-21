using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currenthealth;
    public int maxHealth = 3;

    public void ChangeHealth(int amount)
    {
        currenthealth += amount;

        if (currenthealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
