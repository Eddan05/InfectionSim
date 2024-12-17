using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject humanPrefab;
    public int humanCount = 50;
    public float sickPercentage = 10f; // 10% av människorna startar som sjuka

    public Vector2 spawnArea = new Vector2(10, 10);

    void Start()
    {
        for (int i = 0; i < humanCount; i++)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(-spawnArea.y, spawnArea.y)
            );
            GameObject newHuman = Instantiate(humanPrefab, spawnPosition, Quaternion.identity);

            // Tilldela initial status
            InfectionHandler infectionHandler = newHuman.GetComponent<InfectionHandler>();
            if (infectionHandler != null)
            {
                float roll = Random.Range(0f, 100f);
                if (roll < sickPercentage)
                {
                    infectionHandler.currentStatus = Status.Sick;
                }
                else
                {
                    infectionHandler.currentStatus = Status.Healthy;
                }

                // Uppdatera färg baserat på status
                infectionHandler.UpdateColor();
            }
        }
    }
}
