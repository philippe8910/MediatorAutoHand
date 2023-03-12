using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabPack", menuName = "prefabPack", order = 0)]
public class GamePool : ScriptableObject
{ 
    public List<GameObject> Prefab = new List<GameObject>();
    
    public GameObject Catch(string prefabName)
    { 
        GameObject targetObject = null;
        
        Prefab.ForEach(delegate(GameObject o)
        {
            if (o.name == prefabName)
            {
                targetObject = o;
            }
        });

        return targetObject;
    }
    
    

    public GameObject Catch(int index) => Prefab[index];

    
    public void PrefabCreate(string name , Vector3 targetPos , Quaternion targetQuaternion)
    {
        var targetObject = Catch(name);

        Instantiate(targetObject, targetPos, targetQuaternion);
    }
    
    public void PrefabCreate(string name , Vector3 targetPos , Quaternion targetQuaternion , float destroyTime)
    {
        var targetObject = Catch(name);
        var prefab = Instantiate(targetObject, targetPos, targetQuaternion);
        
        Destroy(prefab , destroyTime);
    }
    
    public void PrefabCreate(int index , Vector3 targetPos , Quaternion targetQuaternion)
    {
        var targetObject = Catch(index);
        
        Instantiate(targetObject, targetPos, targetQuaternion);
    }
    
    public void PrefabCreate(int index , Vector3 targetPos , Quaternion targetQuaternion , float destroyTime)
    {
        var targetObject = Catch(index);
        var prefab = Instantiate(targetObject, targetPos, targetQuaternion);
        
        Destroy(prefab , destroyTime);
    }
}

public static class AssetExtension
{
    public static T[] FindAllAssets<T>() where T : Object
    {
        return AssetDatabase.FindAssets($"t:{typeof(T).Name}")
            .Select(x => AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(x)))
            .ToArray();
    }
}

