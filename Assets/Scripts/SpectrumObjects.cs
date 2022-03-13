using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SpectrumObjects : MonoBehaviour
{
    Mesh mesh;

    public Vector3[] vertices;
    public int[] triangles;
    //public Transform[] VertsPack;
    private Transform trans;
    public GameObject[] VertsPack;

    private void Start()
    {
        
        mesh = new Mesh();
        VertsPack = new GameObject[64];
        for (int i = 0; i < 64; i++)
        {
            VertsPack[i] = new GameObject();
            //VertsPack[i].
        }
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    

    private void CreateShape()
    {
        vertices = new Vector3[]
        {
            //[0-7]
            new Vector3 (1, 0, -0.125f), //0
            new Vector3 (0.980785f, 0.19509f, -0.125f),
            new Vector3(0.923879f, 0.382684f, -0.125f), //2
            new Vector3(0.83147f, 0.55557f, -0.125f),
            new Vector3(0.707107f, 0.707107f, -0.125f), //4
            new Vector3(0.55557f, 0.83147f, -0.125f),
            new Vector3(0.382683f, 0.92388f, -0.125f), //6
            new Vector3(0.19509f, 0.980785f, -0.125f),
            //[8-15]
            new Vector3(0, 1, -0.125f), //8
            new Vector3(-0.19509f, 0.980785f, -0.125f), 
            new Vector3(-0.382683f, 0.92388f, -0.125f), //10
            new Vector3(-0.55557f, 0.83147f, -0.125f), 
            new Vector3(-0.707107f, 0.707107f, -0.125f), //12
            new Vector3(-0.83147f, 0.55557f, -0.125f),
            new Vector3(-0.923879f, 0.382684f, -0.125f), //14
            new Vector3(-0.980785f, 0.19509f, -0.125f),
            //[16-23]
            new Vector3(-1, 0, -0.125f), //16
            new Vector3 (-0.980785f, -0.19509f, -0.125f),
            new Vector3(-0.923879f, -0.382684f, -0.125f), //18
            new Vector3(-0.83147f, -0.55557f, -0.125f),
            new Vector3(-0.707107f, -0.707107f, -0.125f), //20
            new Vector3(-0.55557f, -0.83147f, -0.125f),
            new Vector3(-0.382683f, -0.92388f, -0.125f), //22
            new Vector3(-0.19509f, -0.980785f, -0.125f),
            //[24-31]
            new Vector3(0, -1, -0.125f), //24
            new Vector3(0.19509f, -0.980785f, -0.125f), 
            new Vector3(0.382683f, -0.92388f, -0.125f), //26
            new Vector3(0.55557f, -0.83147f, -0.125f),
            new Vector3(0.707107f, -0.707107f, -0.125f), //28
            new Vector3(0.83147f, -0.55557f, -0.125f),
            new Vector3(0.923879f, -0.382684f, -0.125f), //30
            new Vector3(0.980785f, -0.19509f, -0.125f),
            
            
            //[32-39]
            new Vector3 (1, 0, 0.125f), //32
            new Vector3 (0.980785f, 0.19509f, 0.125f),
            new Vector3(0.923879f, 0.382684f, 0.125f), //34
            new Vector3(0.83147f, 0.55557f, 0.125f),
            new Vector3(0.707107f, 0.707107f, 0.125f), //36
            new Vector3(0.55557f, 0.83147f, 0.125f),
            new Vector3(0.382683f, 0.92388f, 0.125f), //38
            new Vector3(0.19509f, 0.980785f, 0.125f),
            //[40-47]
            new Vector3(0, 1, 0.125f), //40
            new Vector3(-0.19509f, 0.980785f, 0.125f),
            new Vector3(-0.382683f, 0.92388f, 0.125f), //42
            new Vector3(-0.55557f, 0.83147f, 0.125f),
            new Vector3(-0.707107f, 0.707107f, 0.125f), //44
            new Vector3(-0.83147f, 0.55557f, 0.125f),
            new Vector3(-0.923879f, 0.382684f, 0.125f), //46
            new Vector3(-0.980785f, 0.19509f, 0.125f),
            //[48-55]
            new Vector3(-1, 0, 0.125f), //48
            new Vector3 (-0.980785f, -0.19509f, 0.125f),
            new Vector3(-0.923879f, -0.382684f, 0.125f), //50
            new Vector3(-0.83147f, -0.55557f, 0.125f),
            new Vector3(-0.707107f, -0.707107f, 0.125f), //52
            new Vector3(-0.55557f, -0.83147f, 0.125f),
            new Vector3(-0.382683f, -0.92388f, 0.125f), //54
            new Vector3(-0.19509f, -0.980785f, 0.125f),
            //[56-63]
            new Vector3(0, -1, 0.125f), //56
            new Vector3(0.19509f, -0.980785f, 0.125f),
            new Vector3(0.382683f, -0.92388f, 0.125f), //58
            new Vector3(0.55557f, -0.83147f, 0.125f),
            new Vector3(0.707107f, -0.707107f, 0.125f), //60
            new Vector3(0.83147f, -0.55557f, 0.125f),
            new Vector3(0.923879f, -0.382684f, 0.125f), //62
            new Vector3(0.980785f, -0.19509f, 0.125f),
        };
        
        
        /*
        for(int i = 0; i<32;i++)
        {
            triangles[i] = i;
            triangles[i + 1] = i + 32;
            triangles[i + 2] = i + 33;
        }
/*
        for (int i = 32; i < 64; i++)
        {
            triangles[i] = i - 32;
            triangles[i + 1] = i - 31;
            triangles[i + 2] = i + 1;
        }*/

       /* for (int i = 0; i < 32; i++)
        {
            Debug.Log("triangles:" + triangles[i] + ", " + triangles[i+1] + ", " + triangles[i+2] + ", ");
        }
        */
        triangles = new int[]
        {
            0, 32, 33,
            33, 1, 0,
            
            1, 33, 34,
            34, 2, 1,
            
            2, 34, 35,
            35, 3, 2,
            
            3, 35, 36,
            36, 4, 3,
            
            4, 36, 37,
            37, 5, 4,
            
            5, 37, 38,
            38, 6, 5,
 
            6, 38, 39,
            39, 7, 6,
            
            7, 39, 40,
            40, 8, 7,

            8, 40, 41,
            41, 9, 8,

            9, 41, 42,
            42, 10, 9,

            10, 42, 43,
            43, 11, 10,

            11, 43, 44,
            44, 12, 11,

            12, 44, 45,
            45, 13, 12,

            13, 45, 46,
            46, 14, 13,

            14, 46, 47,
            47, 15, 14,

            15, 47, 48,
            48, 16, 15,
        
            16, 48, 49,
            49, 17, 16,
            
            17, 49, 50,
            50, 18, 17,

            18, 50, 51,
            51, 19, 18,

            19, 51, 52,
            52, 20, 19,

            20, 52, 53,
            53, 21, 20,

            21, 53, 54,
            54, 22, 21,

            22, 54, 55,
            55, 23, 22,

            23, 55, 56,
            56, 24, 23,

            24, 56, 57,
            57, 25, 24,

            25, 57, 58,
            58, 26, 25,

            26, 58, 59,
            59, 27, 26,

            27, 59, 60,
            60, 28, 27,

            28, 60, 61,
            61, 29, 28,

            29, 61, 62,
            62, 30, 29,

            30, 62, 63,
            63, 31, 30,
        };

        
    }
    
    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        for (int i = 0; i < 64; i++)
        {
            VertsPack[i].transform.position = vertices[i];
        }
    }
}
