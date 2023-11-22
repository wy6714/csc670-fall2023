using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject normalBlock; 

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
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
}
