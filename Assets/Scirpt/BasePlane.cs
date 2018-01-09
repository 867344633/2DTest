using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlane : MonoBehaviour {
    [SerializeField]
    WeaponType[] weaponType;
    [SerializeField]
    float hp = 10;
    [SerializeField]
    int atk = 1;
    [SerializeField]
    int speed = 10;
    List<BaseWeapon> lsWeapon = new List<BaseWeapon>();


    PlaneAnimal animal;
    bool bDead = false;
    public float Hp
    {
        get
        {
            return hp;
        }
        set{
            hp = value;
            if (hp <= 0) { hp = 0;bDead = true; }
        }
    }
    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
            if (speed <= 0) { hp = 0;  }
        }
    }
    public int Atk
    {
        get
        {
            return atk;
        }
        set
        {
            atk = value;
            if (atk <= 0) { hp = 0; }
        }
    }
    public bool IsDead
    {
        get
        {
            return bDead;
        }
    }
    void Start () {

        lsWeapon.Clear();
        for(int i = 0; i < weaponType.Length; ++i)
        {
            ChangeWeapon(weaponType[i]);
        }
        animal = GetComponent<PlaneAnimal>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void ChangeWeapon(WeaponType _type)
    {
        BaseWeapon weapon = GameManager.instance.CreateWeapon(_type);
        if(weapon != null)
        {
            weapon.transform.SetParent(this.transform);
            weapon.transform.localPosition = Vector3.zero;
            weapon.Owner = this;
            foreach (var element in lsWeapon)
            {
                if(element.GetPosType() == weapon.GetPosType())
                {
                    lsWeapon.Remove(element);
                    break;
                }
            }
            lsWeapon.Add(weapon);
        }
    }


    public void Shoot(bool _shoot)
    {
        foreach (var element in lsWeapon)
        {
            element.Shoot(_shoot);
        }

    }
    public void OnHit(float _value)
    {
        Hp -= _value;
        if (bDead)
        {

            GameManager.instance.OnPlaneDead(this);
            OnBomb();
        }
    }
    public void OnBomb()
    {
        this.GetComponent<Collider2D>().enabled = false;
        animal.ChangeAnimal(PlaneAnimaType.bomb);
        StartCoroutine(StartDestory());
    }
    IEnumerator StartDestory()
    {
         yield return new  WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
