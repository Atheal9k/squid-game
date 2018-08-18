using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    class PoolObject
    {
        public Transform transform;
        public bool inUse;
        public PoolObject(Transform t) { transform = t; }
        public void Use() { inUse = true; }
        public void Dispose() { inUse = false; }
    }

    [System.Serializable]
    public struct YSpawnRange
    {
        public float min;
        public float max;
    }

    [System.Serializable]
    public struct XSpawnRange
    {
        public float min;
        public float max;
    }

    public GameObject Prefab;
    public int poolSize;
    public float shiftSpeed;
    public float spawnRate;

    public YSpawnRange ySpawnRange;
    public XSpawnRange xSpawnRange;
    public Vector3 defaultSpawnPos;
    public bool spawnImmediate; //particle prewarm
    public Vector3 immediateSpawnPos;
    public Vector2 targetAspectRatio;
    public Camera cam;
    public GameObject[] colliders;
    public Vector3 waypoint;
    public Vector2 whereToSpawn;

    float spawnTimer;
    float targetAspect;
    PoolObject[] poolObjects;
    GameManager game;

    void Awake()
    {
        Configure();
    }

     void Start()
     {
        //game = GameManager.Instance;
        colliders = GameObject.FindGameObjectsWithTag("hazard");
    }

    /*
     void OnEnable()
     {
         GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
     }

     void OnDisable()
     {
         GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
     }  */

    /*  void OnGameOverConfirmed()
      {
          for (int i = 0; i < poolObjects.Length; i++)
          {
              poolObjects[i].Dispose();
              poolObjects[i].transform.position = Vector3.one * 1000;

          }
          if (spawnImmediate)
          {
              SpawnImmediate();
          }
      } */


    void Update()
    {
        //if (game.GameOver) return;
        waypoint = this.gameObject.transform.position;
        CheckNewWaypoint();
        //Shift();
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate)
        {
            Spawn();
            spawnTimer = 0;
        }
    }

    void Configure()
    {
        targetAspect = targetAspectRatio.x / targetAspectRatio.y;
        poolObjects = new PoolObject[poolSize];
        for (int i = 0; i < poolObjects.Length; i++)
        {
            GameObject go = Instantiate(Prefab) as GameObject;  //go = short for gameobject
            Transform t = go.transform;
            t.SetParent(transform);
            t.position = Vector3.one * 5;  
            poolObjects[i] = new PoolObject(t);
        }

        if (spawnImmediate)
        {
            SpawnImmediate();
        }
    }

    void Spawn()
    {
        Transform t = GetPoolOjbect();
        if (t == null) return;
        //if true, this indicates pool size is too small 
         Vector3 pos = Vector3.zero;
         pos.x = Random.Range(xSpawnRange.min, xSpawnRange.max);
        //(defaultSpawnPos.x * Camera.main.aspect) / targetAspect;
        
       pos.y = Camera.main.transform.position.y + Random.Range(Camera.main.orthographicSize, Camera.main.orthographicSize+2)  ;

        // pos.y = Random.Range(0, Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight)).y);
        //float spawnY =  
        // Vector2 spawnPosition = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.Width, 0)).x, spawnY);
        //Random.Range(ySpawnRange.min, ySpawnRange.max); 


        // Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        t.position = pos;
    }


    


    void SpawnImmediate()
    {
        Transform t = GetPoolOjbect();
        if (t == null) return; //if true, this indicates pool size is too small 
                                Vector3 pos = Vector3.zero;
        pos.x = Random.Range(xSpawnRange.min, xSpawnRange.max);
        //(immediateSpawnPos.x * Camera.main.aspect) / targetAspect;
        pos.y = Camera.main.transform.position.y + Random.Range(Camera.main.orthographicSize, Camera.main.orthographicSize+2);



        //pos.y = Random.Range(0, Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight)).y);
        //float spawnY = 
        // Vector2 spawnPosition = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.Width, 0)).x, spawnY);
        // Random.Range(ySpawnRange.min, ySpawnRange.max); 

        // Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));



        t.position = pos;
        Spawn();
    }

    /*void Shift()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            poolObjects[i].transform.position += -Vector3.right * shiftSpeed * Time.deltaTime;
            CheckDisposedObject(poolObjects[i]);
        }

    } */

    void CheckDisposedObject(PoolObject poolObject)
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
            
         
            print("dispose");
            poolObject.Dispose();
            poolObject.transform.position = Vector3.one * 1000;
        
        
        //if (screenPosition.y > Screen.height || screenPosition.y < 0)
            //poolObject.Dispose();
        //poolObject.transform.position = Vector3.one * 1000;
       
    }
    //  poolObject.transform.position.y <  -defaultSpawnPos.x* Camera.main.aspect) / targetAspect
    Transform GetPoolOjbect()
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            if (!poolObjects[i].inUse)
            {
                poolObjects[i].Use();
                return poolObjects[i].transform;
            }
        }
        return null;
    }

   

    void CheckNewWaypoint()
    {
        foreach (GameObject collider in colliders)
        {
            Renderer renderer = collider.GetComponent<Renderer>();
            Bounds bounds = renderer.bounds;
            if (bounds.Contains(waypoint))
            {
                print("faggoti");
                Debug.Log("IM INSIDE SOMETHING");
            }
        }
    }

 
}
