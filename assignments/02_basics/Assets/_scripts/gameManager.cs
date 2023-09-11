using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class gameManager : MonoBehaviour
{
    public GameObject cubePrefab;
    private float cubeVolum = 2f;
    //public float x = -9;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
