using UnityEngine;
using UnityEngine.UI;

public class InfectionTracker : MonoBehaviour
{
    public Text statusText;
    private HumanStatus[] humans;

    void Update()
    {
        humans = FindObjectsByType<HumanStatus>(FindObjectsSortMode.None);
        int healthy = 0, sick = 0, immune = 0, dead = 0;

        foreach (var human in humans)
        {
            switch (human.currentStatus)
            {
                case Status.Healthy: healthy++; break;
                case Status.Sick: sick++; break;
                case Status.Immune: immune++; break;
                case Status.Dead: dead++; break;
            }
        }

        statusText.text = $"Friska: {healthy}\nSjuka: {sick}\nImmuna: {immune}\nDöda: {dead}";
    }
}
