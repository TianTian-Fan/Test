using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyLab : MonoBehaviour
{
    public abstract string Name {get;}
    public abstract GameObject Create(GameObject prefab);

}

public class Crab : EnemyLab
{
    public override string Name => "crab";
    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        Debug.Log("Crab is created");
        return enemy;
    }
}

public class Monster : EnemyLab
{
    public override string Name => "monster";
    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        Debug.Log("monster is created");
        return enemy;
    }
}
