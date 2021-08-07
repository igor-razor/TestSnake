using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGen : MonoBehaviour
{
    private List<GameObject> Lglobal = new List<GameObject>();
    public GameObject main_camera;

    public GameObject GOroad;
    public GameObject GOsnake;
    private GameObject GOSnakeHead;

    private int W = 7;
    private int L = 400;

    private int H = 1;

    private float speed_foward = 5.0f;
    private float speed_side = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartNew();
    }
    //public Transform target;
    // Update is called once per frame

    private void ClearList()
    {
        foreach(GameObject go in Lglobal) { Destroy(go); }
        Lglobal = new List<GameObject>();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartNew()
    {
        //ClearList();
        GenSnake();
        GenRoad(W, L);
        GenEat();
        //main_camera.transform.position = new Vector3(main_camera.transform.position.x, main_camera.transform.position.y, GOSnakeHead.transform.position.z);
        //next_color = 0;
    }

    void Update()
    {

    }//void Update()


    private int snake_start_count = 5;
    private int snake_delta = 1;

    void GenSnake()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Lglobal.Add(cube);
        cube.name = "SnakeHead";
        cube.transform.SetParent(GOsnake.transform);
        cube.GetComponent<Renderer>().material.color = Colors[0];

        cube.transform.position = new Vector3(0, H, 0);

        cube.AddComponent<SnakeHead>().H = H;
        cube.GetComponent<SnakeHead>().COLOR = Colors[next_color];
        cube.GetComponent<SnakeHead>().SPEED_SIDE = speed_side;

        cube.AddComponent<MoveFoward>().SPEED_FOWARD = speed_foward;
        cube.GetComponent<MoveFoward>().BORDER = L;
        cube.GetComponent<MoveFoward>().START();

        cube.GetComponent<MoveFoward>().Gomain = gameObject;

        //cube.AddComponent<SwipeController>();

        main_camera.AddComponent<MoveFoward>().SPEED_FOWARD = speed_foward;
        main_camera.GetComponent<MoveFoward>().BORDER = L;
        main_camera.GetComponent<MoveFoward>().START();

        main_camera.transform.position = new Vector3(W/2, main_camera.transform.position.y, main_camera.transform.position.z);

        GOSnakeHead = cube;
        GOSnakeHead.GetComponent<SnakeHead>().Lsnake.Add(GOSnakeHead);

        //target = GOSnakeHead.transform;
        float tec_speed_side = speed_side;
        float tec_scale = 1;

        GameObject cube_front = GOSnakeHead;

        for (byte i = 1; i < snake_start_count; i++)
        {
            GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Lglobal.Add(cube1);
            cube1.GetComponent<Renderer>().material.color = Colors[0];
            cube1.name = "SnakeBox_" + i.ToString();
            cube1.transform.SetParent(GOsnake.transform);
            cube1.transform.position = new Vector3(cube_front.transform.position.x, H, cube_front.transform.position.z - snake_delta);

            cube1.AddComponent<SnakeBox>().GOFRONT = cube_front;
            tec_speed_side = tec_speed_side * 4 / 5;
            cube1.GetComponent<SnakeBox>().SPEED_SIDE = tec_speed_side;
            cube1.GetComponent<SnakeBox>().START();

            cube1.AddComponent<MoveFoward>().SPEED_FOWARD = speed_foward;
            cube1.GetComponent<MoveFoward>().BORDER = L;
            cube1.GetComponent<MoveFoward>().START();

            tec_scale = 0.75f * tec_scale;
            cube1.transform.localScale = new Vector3(tec_scale, cube1.transform.localScale.y, cube1.transform.localScale.z);

            cube_front = cube1;
            GOSnakeHead.GetComponent<SnakeHead>().Lsnake.Add(cube1);
        }

        //main_camera.transform.SetParent(GOSnakeHead.transform);

    }//void GenSnake()


    void GenRoad(int xmax, int zmax)
    {
        int x = 0;
        int z = 0;

        for (int i = 0; i < xmax; i++)
        {
            for (int j = 0; j < zmax; j++)
            {

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //Lglobal.Add(cube);
                cube.name = "RoadCube" + x.ToString() + "_" + z.ToString();
                cube.transform.SetParent(GOroad.transform);
                cube.AddComponent<RoadCube>().GOsnakeHead = GOSnakeHead;

                cube.GetComponent<Renderer>().material.color = Color.white;
                //cube.AddComponent<Rigidbody>().useGravity = false;

                //Debug.Log(x.ToString() + " " + z.ToString());
                cube.transform.position = new Vector3(x, 0, z);

                z++;
            }//for (int j = 0; j < ymax; j++)

            x++;
            z = 0;

        }//for (int i = 0; i < xmax; i++)
    }//void GenRoad(int xmax, int zmax)

    private int procent_gen = 7;
    private int procent_color = 5;

    private int next_change = 60;

    private Color[] Colors = { Color.green, Color.red, Color.blue, Color.magenta, Color.yellow, Color.cyan, Color.black, Color.white };
    private int next_color = 0;

    void GenEat()
    {
        for (int i = 10; i < L; i++ )
        {
            if (i % next_change != 0)
                if (UnityEngine.Random.Range(1, 10) > procent_gen)
                {
                    Color tec_color = Color.gray;

                    if (UnityEngine.Random.Range(1, 10) > procent_color)
                    { tec_color = Colors[next_color]; }
                    else { tec_color = Colors[next_color + 1]; }

                    int xx = UnityEngine.Random.Range(0, 6);
                    GameObject eat = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    Lglobal.Add(eat);

                    eat.GetComponent<Renderer>().material.color = tec_color;

                    eat.AddComponent<Eat>().COLOR = tec_color;
                    eat.GetComponent<Eat>().GOsnakeHead = GOSnakeHead;
                    eat.GetComponent<Eat>().Gomain = gameObject;

                    eat.GetComponent<CapsuleCollider>().isTrigger = true;
                    eat.AddComponent<Rigidbody>().useGravity = false;

                    eat.transform.position = new Vector3(xx, H, i);
                    eat.transform.localScale = new Vector3(eat.transform.localScale.x * 0.8f, eat.transform.localScale.y * 0.8f, eat.transform.localScale.z * 0.8f);

                    eat.transform.SetParent(GOroad.transform);
                }
                            


            if (i%next_change == 0)
            {
                //Debug.Log(i);
                next_color++;
                for (int j = 0; j<W; j++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Lglobal.Add(cube);
                    cube.GetComponent<Renderer>().material.color = Colors[next_color];
                    cube.transform.SetParent(GOroad.transform);

                    cube.transform.position = new Vector3((float)j, ((float)H)/2, (float)i);

                    cube.AddComponent<ChangerColor>().COLOR = Colors[next_color];
                    cube.GetComponent<ChangerColor>().GOsnakeHead = GOSnakeHead;

                    cube.GetComponent<BoxCollider>().isTrigger = true;
                    cube.AddComponent<Rigidbody>().useGravity = false;
                }

            }

        }

    }//void GenEat()

}//public class MainGen : MonoBehaviour
