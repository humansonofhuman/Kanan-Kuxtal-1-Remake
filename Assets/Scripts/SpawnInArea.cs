using UnityEngine;

public class SpawnInArea : MonoBehaviour
{
    [SerializeField] Vector2 spawnArea;
    [Tooltip("Can't spawn here")]
    [SerializeField] Vector2 excludedInnerArea;
    [SerializeField] GameObject objectToSpawn;

    public void Spawn()
    {
        Vector2 origin = transform.position;
        Vector2 randomRange = GetRandomRange();
        Vector2 randomCoordinate = origin + randomRange;

        Instantiate(objectToSpawn, randomCoordinate, transform.rotation);
    }

    Vector2 GetRandomRange()
    {
        Vector2 range = spawnArea / 2.0f;
        float x;
        float y;
        do
        {
            x = Random.Range(-range.x, range.x);
            y = Random.Range(-range.y, range.y);
        } while (isRangeInvalid(x, y));

        return new Vector2(x, y);
    }

    bool isRangeInvalid(float x, float y)
    {
        Vector2 excludedRange = excludedInnerArea / 2.0f;
        return (x < excludedRange.x && x > -excludedRange.x)
            && (y < excludedRange.y && y > -excludedRange.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnArea);
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(transform.position, excludedInnerArea);
    }
}
