using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject normalBlock;

    public Sprite hoverSprite;
    public Sprite normalSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //mouse click place block
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 10f);
                Instantiate(normalBlock, spawnPosition, Quaternion.identity);
                Debug.Log("collide");
            }
        }
    }

    private void OnMouseOver()//mouse hover -> hoverSprite
    {
        spriteRenderer.sprite = hoverSprite;
    }

    private void OnMouseExit()//mouse exit -> back normal
    {
        spriteRenderer.sprite = normalSprite;
    }
}
