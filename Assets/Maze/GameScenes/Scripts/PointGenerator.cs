using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGenerator : MonoBehaviour
{

    public GameObject StartPrefab;
    public GameObject Goal;
    public GameObject GoalStand;
    public GameObject Stamp;
    public GameObject Stand;
    public GameObject Sphere;
    public GameObject mainCamera;

    public float RoofPositiony, mainCameraPositiony, StandPositiony,SpherePositiony;
    int i = 0;
    int b = 0;
    readonly Position[] roof = new Position[HomeDirector.TotalStampNumber+3];
    int positionx, positionz;
    

    class Position
    {
        public int x, z;
    }

    Position newPoint(int x, int z)
    {
        Position a = new Position();
        a.x = x;
        a.z = z;
        return a;
    }


    void Position1(GameObject gameObject, float positiony)
    {
        i++;
        GameObject gen = Instantiate(gameObject) as GameObject;
        

        do
        {
            b = 0;
            positionx = Random.Range(0, HomeDirector.width / 2);
            positionz = Random.Range(0, HomeDirector.height / 2);
            roof[i] = newPoint(positionx, positionz);
            roof[i].x = roof[i].x * 2 + 1;
            roof[i].z = roof[i].z * 2 + 1;

            for (int j = 1; j < i; j++)
            {
                if (roof[i].x == roof[j].x && roof[i].z == roof[j].z)
                {
                    b = 1;
                }
            }
        } while (b == 1);
        
        gen.transform.position = new Vector3(roof[i].x, positiony, roof[i].z);

    }




    void Position2(GameObject gameObject1,GameObject gameObject2,float positiony1,float positiony2)
    {
        i++;
        GameObject gen1 = Instantiate(gameObject1) as GameObject;
        GameObject gen2 = Instantiate(gameObject2) as GameObject;

        do
        {
            b = 0;
            positionx = Random.Range(0, HomeDirector.width / 2);
            positionz = Random.Range(0, HomeDirector.height / 2);
            roof[i] = newPoint(positionx, positionz);
            roof[i].x = roof[i].x * 2 + 1;
            roof[i].z = roof[i].z * 2 + 1;

            for (int j = 1; j < i; j++)
            {
                if (roof[i].x == roof[j].x && roof[i].z == roof[j].z)
                {
                    b = 1;
                }
            }
        } while (b == 1);
        
        gen1.transform.position = new Vector3(roof[i].x, positiony1, roof[i].z);
        gen2.transform.position = new Vector3(roof[i].x, positiony2, roof[i].z);
    }

    void Position3(GameObject gameObject1, GameObject gameObject2, GameObject gameObject3,float positiony1, float positiony2,float positiony3)
    {
        i++;
        GameObject gen1 = Instantiate(gameObject1) as GameObject;
        GameObject gen2 = Instantiate(gameObject2) as GameObject;
        GameObject gen3 = Instantiate(gameObject3) as GameObject;

        do
        {
            b = 0;
            positionx = Random.Range(0, HomeDirector.width / 2);
            positionz = Random.Range(0, HomeDirector.height / 2);
            roof[i] = newPoint(positionx, positionz);
            roof[i].x = roof[i].x * 2 + 1;
            roof[i].z = roof[i].z * 2 + 1;

            for (int j = 1; j < i; j++)
            {
                if (roof[i].x == roof[j].x && roof[i].z == roof[j].z)
                {
                    b = 1;
                }
            }
        } while (b == 1);

        gen1.transform.position = new Vector3(roof[i].x, positiony1, roof[i].z);
        gen2.transform.position = new Vector3(roof[i].x, positiony2, roof[i].z);
        gen3.transform.position = new Vector3(roof[i].x, positiony3, roof[i].z);
    }

    // Start is called before the first frame update
    void Start()
    {

        //スタートとカメラをランダムに配置
        Position1(StartPrefab, RoofPositiony);
        mainCamera.transform.position = new Vector3(roof[i].x, mainCameraPositiony, roof[i].z);

        //ゴールをランダムに配置
        Position2(Goal,GoalStand, RoofPositiony,StandPositiony);


        //スタンプをランダムに配置
        for (int k = 0; k < HomeDirector.TotalStampNumber; k++)
        {
            Position3(Stamp, Stand,Sphere, RoofPositiony, StandPositiony,SpherePositiony);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
