using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RespawnSystem : MonoBehaviour
{
    [SerializeField] private Tilemap m_Platform;
    [SerializeField] private float m_SpawnRange = 5f;
    Vector3Int testPos;

    public Vector3 GetRespawnPosition(Vector3 currentPos)
    {
        Vector3Int tilePos;
        Vector3 SpawnPos = currentPos;
        Vector3 checkPos = new Vector3();

        for (int i = 0; i < 10; i++)
        {
            float offsetX = Random.Range(-m_SpawnRange, m_SpawnRange);
            checkPos = new Vector3(currentPos.x + offsetX, currentPos.y, currentPos.z);
            tilePos = m_Platform.WorldToCell(checkPos - Vector3.up * 0.7f);


            testPos = tilePos;

            var bounds = m_Platform.cellBounds;
            Debug.Log($"Min: {bounds.min}, Max: {bounds.max}");
            Debug.Log($"Tile at {tilePos}: {m_Platform.GetTile(tilePos)}");

            if (m_Platform.HasTile(tilePos))
            {
                SpawnPos = m_Platform.CellToWorld(tilePos) + new Vector3(0, 1f, 0);
                break;
            }
        }

        return SpawnPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(testPos, 1);
    }
}
