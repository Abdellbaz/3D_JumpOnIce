using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject cube;
    public GameObject[,] objs = new GameObject[10, 10];
 


    private float CubeX, CubeY, CubeZ,distance;

    void Start()
    {
        distance = 1.1f;

        CubeX = cube.GetComponent<MeshRenderer>().bounds.size.x;
        CubeY = cube.GetComponent<MeshRenderer>().bounds.size.y;
        CubeZ = cube.GetComponent<MeshRenderer>().bounds.size.z;
  
       if (transform.name == "East") { transform.position = new Vector3(objs.GetLength(0) *CubeZ * distance , 0f,0f); }
       else if (transform.name == "South") { transform.position = new Vector3(0f, 0f, objs.GetLength(0) * CubeX * distance); }

        if (cube.name == "Wall_X"|| cube.name == "Wall_Z") { objs = new GameObject[11, 20]; } else { objs = new GameObject[10, 10]; }


            for (int row = 0; row < objs.GetLength(0); row++)
        { 
               

            for (int col = 0; col < objs.GetLength(1); col++)
            {
                if (cube.name == "Wall_X")
                {
                    objs[row, col] = Instantiate(cube, transform);
                    objs[row, col].transform.position += new Vector3(0f, CubeY * col, CubeZ * row);

                }
               else if (cube.name == "Wall_Z")
                {   
                    objs[row, col] = Instantiate(cube, transform);
                    objs[row, col].transform.position += new Vector3(CubeX * row, CubeY * col, 0f);



                }
        
                else {
                    objs[row, col] = Instantiate(cube, transform);
                    objs[row, col].transform.position += new Vector3(CubeX * row * distance, 0f, CubeZ * col * distance) ;
                }
            }
        }
       
    }








}
