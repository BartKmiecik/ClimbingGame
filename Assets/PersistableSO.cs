using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class PersistableSO : MonoBehaviour
{
    [SerializeField] private Transform level;
    private void Start()
    {
        LoadLevel();
    }

    public void SaveNewLevel()
    {
        SavePosition();
    }

    public List<Handle> LoadNewLevel()
    {
        
        return LoadLevel();
    }

    private void SavePosition()
    {
        BinaryFormatter bf = new BinaryFormatter();
        for(int i = 1; i < level.childCount; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}{1}.pso", "Hole", i));

            Handle h = new Handle(level.GetChild(i).GetComponent<HandleDifficulty>().ScriptableHandle, level.GetChild(i).GetComponentInChildren<Renderer>().material.color,
                level.GetChild(i).transform.position, level.GetChild(i).transform.localScale, level.GetChild(i).transform.rotation);


            var json = JsonUtility.ToJson(h);
            bf.Serialize(file, json);
            file.Close();
            Debug.Log(h);
        }
    }

    private List<Handle> LoadLevel()
    {
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + string.Format("/{0}{1}.pso", "Hole", 1)))
        {
            List<Handle> handlesList = new List<Handle>();
            for (int i = 1; i < 1000; i++)
            {
                if (File.Exists(Application.persistentDataPath + string.Format("/{0}{1}.pso", "Hole", i)))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}{1}.pso", "Hole", i), FileMode.Open);
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
}
