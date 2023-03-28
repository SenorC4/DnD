using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class MouseController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject playerPrefab;

    [Header("Attributes")]
    [SerializeField] private float speed;

    private PlayerBehavior player;

    private Pathfinder pathfinder;
    public bool isAttacking = false;
    [SerializeField] private List<OverlayTile> path = new List<OverlayTile>();
    [SerializeField] private CharacterCreate cc;

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = new Pathfinder();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bool justAttacked = false;
        var focusedTileHit = GetFocusedOnTile();

        if (focusedTileHit.HasValue)
        {
            OverlayTile overlayTile = focusedTileHit.Value.collider.gameObject.GetComponent<OverlayTile>();
            transform.position = overlayTile.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = overlayTile.GetComponent<SpriteRenderer>().sortingOrder + 2;

            TurnSystem ts = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TurnSystem>();

            if (Input.GetMouseButtonDown(0))
            {
                overlayTile.GetComponent<OverlayTile>().ShowTile();
                if (overlayTile.GetComponent<OverlayTile>().isAttackable)
                {
                    List<GameObject> list = cc.getEnemyList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        PlayerBehavior pb = list[i].GetComponent<PlayerBehavior>();
                        if (pb.activeTile == overlayTile)
                        {
                            Debug.Log(list[i].GetComponent<CharacterScript>().getHP());
                            list[i].GetComponent<CharacterScript>().takeDamage(player.gameObject.GetComponent<CharacterScript>().rollForMeleeDamage());
                            Debug.Log(player.gameObject.GetComponent<CharacterScript>().rollForMeleeDamage());
                            Debug.Log(list[i].GetComponent<CharacterScript>().getHP());
                            isAttacking = true;
                            justAttacked = true;
                        }
                    }
                    ts.attack--;
                }
                else if (player == null)
                {
                    //player = Instantiate(playerPrefab).GetComponent<PlayerBehavior>();
                    //PositionPlayerOnLine(overlayTile);
                }
                else
                {
                    Debug.Log("move: " + ts.move);
                    ts.move++;
                    if (ts.move <= 2)
                    {
                        path = pathfinder.findPath(player.activeTile, overlayTile);
                        Debug.Log(path.Count);
                        if (path.Count > player.gameObject.GetComponent<CharacterScript>().getMovement() / 5)
                        {
                            ts.move--;
                        }
                    }
                }
            }
        }

        if (path.Count > 0)
        {
            //isAttacking = true;
            if (!isAttacking)
                MoveAlongPath();
        }

        if (justAttacked)
        {
            isAttacking = false;
            justAttacked = false;
        }
    }

    public void setPlayer(PlayerBehavior play)
    {
        player = play;
    }

    public PlayerBehavior getPlayer()
    {
        return player;
    }

    private void MoveAlongPath()
    {
        var step = speed * Time.deltaTime;

        var zIndex = path[0].transform.position.z;
        player.transform.position = Vector2.MoveTowards(player.transform.position, path[0].transform.position, step);
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zIndex);

        if (Vector2.Distance(player.transform.position, path[0].transform.position) < 0.0001f)
        {
            PositionPlayerOnLine(path[0]);
            path.RemoveAt(0);
        }
    }

    public RaycastHit2D? GetFocusedOnTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

        if (hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }
        return null;
    }

    private void PositionPlayerOnLine(OverlayTile tile)
    {
        player.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z);
        player.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
        player.activeTile = tile;
    }
}
