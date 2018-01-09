using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direct
{
    up,
    down,
    none
}
public enum PlaneType
{
    player1,
    enemy1,
    enemy2,
    enemy3,
    none,
}
public enum BulletType
{
    bullet1,
    bullet2,
    bullet3,
    bullet4,
    none,
}
public enum WeaponType
{
    weapon1,
    weapon2,
    weapon3,

    weapon_enemy1,
    weapon_enemy2,
    none,
}
public enum WeaponPos //装备挂节点 不同挂接点的装备不会相互覆盖 相同挂节点的则会替换掉
{
    pos1,
    pos2,
    pos3,
    none,
}