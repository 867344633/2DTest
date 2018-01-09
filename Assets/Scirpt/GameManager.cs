using PathologicalGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    PlaneType[] vPlaneTypes;
    [SerializeField]
    int vRates;
    [SerializeField]
    float interval = 1;
   
    SpawnPool poolManager;
    public static GameManager instance;

    Dictionary<PlaneType, string> mapPlanePrefabPath = new Dictionary<PlaneType, string>();
    Dictionary<BulletType, string> mapBulletPrefabPath = new Dictionary<BulletType, string>();
    Dictionary<WeaponType, string> mapWeaponPrefabPath = new Dictionary<WeaponType, string>();
    // Use this for initialization
    void Awake () {
        instance = this;

        poolManager = PoolManager.Pools["Pool"];
    }
	void Start()
    {
        InvokeRepeating("CreateEnemy", interval, vRates);
    }
	// Update is called once per frame
	void Update () {
		
	}
    void CreateEnemy()
    {
       int planeTypeRange =  Random.Range(0, 100);
        BasePlane plane = null;
        if (planeTypeRange < 70)
       plane =   CreatePlane(PlaneType.enemy1);
        else if(planeTypeRange <80)
            plane = CreatePlane(PlaneType.enemy2);
        else
            plane = CreatePlane(PlaneType.enemy3);
        float x = Random.Range(-1.5f, 1.5f);
        plane.transform.position = new Vector2(x, transform.position.y);

    }
    public BaseWeapon CreateWeapon(WeaponType _type)
    {
        GameObject weapon = null;
        string name = _type.ToString();
        switch (_type)
        {
            case WeaponType.none:
                break;
            default:
                    GameObject prefab = Resources.Load<GameObject>(GetWeaponPrefabPath(_type));
                    weapon = GameObject.Instantiate(prefab);
                break;
         
        }
        if(weapon != null)
        {
            return weapon.GetComponent<BaseWeapon>();
        }
        return null;
    }
    public BaseBullent CreateBullet(BulletType _type)
    {
        GameObject bullet = null;
      
        switch (_type)
        {
            case BulletType.none:

                break;
            default:
                string name = _type.ToString();
                //   GameObject prefab = Resources.Load<GameObject>(GetBulletPrefabPath(_type));
                bullet = poolManager.Spawn(GetBulletPrefabPath(_type)).gameObject;// GameObject.Instantiate(prefab);
                break;
        }
        if (bullet != null)
        {
            return bullet.GetComponent<BaseBullent>();
        }
        return null;
    }

    public BasePlane CreatePlane(PlaneType _type)
    {
        GameObject obj = null;
        switch (_type)
        {

            case PlaneType.none:
                break;
            default  :
                {
                    GameObject prefab = Resources.Load<GameObject>(GetPlanePrefabPath(_type));
                    obj = GameObject.Instantiate(prefab);
                }

                break;
        }
        if (obj != null)
        {
            return obj.GetComponent<BasePlane>();
        }
        return null;
    }


    public void OnPlaneDead(BasePlane _plane)
    {
       // GameObject.Destroy(_plane.gameObject);
    }
    string GetWeaponPrefabPath(WeaponType _type)
    {
        if (mapWeaponPrefabPath.ContainsKey(_type) == false)
        {
            string name = "prefab/" +  _type.ToString();
            mapWeaponPrefabPath.Add(_type, name);
        }
            return mapWeaponPrefabPath[_type];
    }
    string GetBulletPrefabPath(BulletType _type)
    {
        if (mapBulletPrefabPath.ContainsKey(_type) == false)
        {
            string name = _type.ToString();
            mapBulletPrefabPath.Add(_type, name);
        }
        return mapBulletPrefabPath[_type];
    }
    string GetPlanePrefabPath(PlaneType _type)
    {
        if (mapPlanePrefabPath.ContainsKey(_type) == false)
        {
            string name = "prefab/" + _type.ToString();
            mapPlanePrefabPath.Add(_type, name);
        }
        return mapPlanePrefabPath[_type];
    }
}
