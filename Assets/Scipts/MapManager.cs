using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;
    public static MapManager instance { get { return _instance; } }

    public OverlayTile overlayTilePrefab;
    public GameObject overlayContainer;

    public Dictionary<Vector2Int, OverlayTile> map;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var tileMap = gameObject.GetComponentInChildren<Tilemap>();
        map = new Dictionary<Vector2Int, OverlayTile>();
        BoundsInt bounds = tileMap.cellBounds;

        //loop through all tiles
        for (int z = bounds.max.z; z > bounds.min.z; z--)
        {
            for (int y = bounds.max.y; y > bounds.min.y; y--)
            {
                for (int x = bounds.max.x; x > bounds.min.x; x--)
                {
                    var tileLocation = new Vector3Int(x, y, z);
                    var tileKey = new Vector2Int(x, y);
                    //Debug.Log("created");
                    //if (tileMap.HasTile(tileLocation) && !map.ContainsKey(tileKey))
                    //{
                        //Debug.Log("created");
                        var overlayTile = Instantiate(overlayTilePrefab, overlayContainer.transform);
                        var cellWorldPosition = tileMap.GetCellCenterWorld(tileLocation);

                        overlayTile.transform.position = new Vector3(cellWorldPosition.x-1, cellWorldPosition.y-1, cellWorldPosition.z);
                        overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder + 1;
                        overlayTile.gridLocation = tileLocation;
                        map.Add(tileKey, overlayTile);
                    //}
                }
            }
        }
    }
}
