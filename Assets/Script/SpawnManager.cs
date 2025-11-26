using UnityEngine;
using System.Collections.Generic;



public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoint;
    [SerializeField] GameObject [] preFeb;

    void Start()
    {
        List<int> indexSpawn = new List<int>();
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            indexSpawn.Add(i);
        }
        
        Shuffle(indexSpawn);

       
       for (int i = 0; i < spawnPoint.Length; i++)
        {
          int uniqueSpawnIndex = indexSpawn[i];

          GameObject selectedSpawnPoint = spawnPoint[uniqueSpawnIndex];
          GameObject selectedPrefab = preFeb[i];
          
          Instantiate(selectedPrefab, selectedSpawnPoint.transform.position, selectedSpawnPoint.transform.rotation);

        }

        
    }
        private void Shuffle(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            // สุ่ม Index k ในช่วงที่ยังไม่ได้ถูกสลับ
            int k = UnityEngine.Random.Range(0, n + 1); 
            // สลับค่าระหว่าง Index k และ Index n
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
