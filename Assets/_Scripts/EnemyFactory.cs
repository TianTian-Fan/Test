using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
using TMPro;

public class EnemyFactory : MonoBehaviour
{

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject buttonPanel;
    public GameObject buttonPrefab;
    List<EnemyLab> enemies;
    // Start is called before the first frame update
    void Start()
    {
        var enemyTypes = Assembly.GetAssembly(typeof(EnemyLab)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(EnemyLab)));

        enemies = new List<EnemyLab>();

        foreach(var type in enemyTypes)
        {
            var tempType = Activator.CreateInstance(type) as EnemyLab;
            enemies.Add(tempType);
        }

        ButtonPanel();
    }
    public EnemyLab GetEnemy(string enemyType)
    {
        foreach(EnemyLab enemy in enemies)
        {
            if(enemy.Name == enemyType)
            {
                Debug.Log("Enemy found!");
                var target = Activator.CreateInstance(enemy.GetType()) as EnemyLab;

                return target;
            }
        }
        return null;
    }

    void ButtonPanel()
    {
        foreach(EnemyLab enemy in enemies)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(buttonPanel.transform);
            button.gameObject.name = enemy.Name + " Button";
            button.GetComponentInChildren<TextMeshProUGUI>().text = enemy.Name;
        }
    }
}
