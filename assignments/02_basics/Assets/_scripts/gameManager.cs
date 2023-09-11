using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public GameObject cubePrefab;
    

    //public NavMeshSurface surface;

    // Start is called before the first frame update
    void Start()
    {
        
        generateCube();

        
    }

    

    void generateCube()
    {
        float y = 1f;
        float x = 0f;
        float z = 0;
       
        for (int i = 0; i<24; i++)
        {
            
            if (i % 4 == 0)
            {
                //create a cube with x = i, z=i
                x = i;
                for(int m = 0; m<28; m++)
                {
                    if(m%4 == 0)
                    {
                        z = -m;
                        Vector3 cubePos = new Vector3(x, y, z);
                        GameObject cubeObj = Instantiate(cubePrefab, cubePos, Quaternion.identity);
                    }
                }
                
            }
            
            
        }    
    }

    public void ResetGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Scene01");
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
