using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class PersistableSO : MonoBehaviour
{
    public CustomWalllsCount wallsList;

    private void Start()
    {
        LoadCustomWallsList();
    }
    public void SaveNewLevel(string wallName, Transform level)
    {
        SaveWall(wallName, level);
    }

    public List<Handle> LoadNewLevel(string wallName)
    {
        
        return LoadWall(wallName);
    }

    public void SaveWall(string wallName, Transform level)
    {
        wallsList.customWalls.Add(wallName);
        BinaryFormatter bf2 = new BinaryFormatter();
        FileStream file2 = File.Create(Application.persistentDataPath + string.Format("/{0}.pso", "CustomWallsList22190941"));
        var json2 = JsonUtility.ToJson(wallsList);
        bf2.Serialize(file2, json2);
        file2.Close();


        BinaryFormatter bf = new BinaryFormatter();
        for(int i = 1; i < level.childCount; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}{1}.pso", wallName, i));

            Handle h = new Handle(level.GetChild(i).GetComponent<HandleDifficulty>().ScriptableHandle, level.GetChild(i).GetComponentInChildren<Renderer>().material.color,
                level.GetChild(i).transform.position, level.GetChild(i).transform.localScale, level.GetChild(i).transform.rotation);

            var json = JsonUtility.ToJson(h);
            bf.Serialize(file, json);
            file.Close();
            Debug.Log(Application.persistentDataPath);
        }
        
    }

    private List<Handle> LoadWall(string wallName)
    {
        if (File.Exists(Application.persistentDataPath + string.Format("/{0}{1}.pso", wallName, 0)))
        {
            List<Handle> handlesList = new List<Handle>();
            for (int i = 0; i < 1000; i++)
            {
                if (File.Exists(Application.persistentDataPath + string.Format("/{0}{1}.pso", wallName, i)))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}{1}.pso", wallName, i), FileMode.Open);
                    Handle h = JsonUtility.FromJson<Handle>((string)bf.Deserialize(file));
                    handlesList.Add(h);
                    file.Close();
                }
                else break;
            }
            return handlesList;
        }
        else
        {
            Debug.Log("File not found");
        }
        return null;
    }

    public void LoadCustomWallsList()
    {
        if (File.Exists(Application.persistentDataPath + string.Format("/{0}.pso", "CustomWallsList22190941"))){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.pso", "CustomWallsList22190941"), FileMode.Open);
            CustomWalllsCount custom = JsonUtility.FromJson<CustomWalllsCount>((string)bf.Deserialize(file));
            wallsList = custom;
            file.Close();
        }

    }
}
