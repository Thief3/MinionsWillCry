using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class makeMap : MonoBehaviour {
    public string mapToMake;
    public int width, height;
    public mapPieces[] objectList;
    public float tileSize;

    private Dictionary<string, GameObject> idDict;
	// Use this for initialization
	void Start () {

        for(int i = 0; i < objectList.Length; i++) {
            idDict.Add(objectList[i].ID, objectList[i].prefab);
        }

        GameObject[,] array = new GameObject[width, height];

        string[] f = File.ReadAllLines(mapToMake);

        for(int line = 0; line < f.Length; line++) {
            string[] blocks = f[line].Split(',');

            for(int blockInt = 0; blockInt < blocks.Length; blockInt++) {
                string blockCode = blocks[blockInt];

                if(blockCode.Length == 1 && idDict.ContainsKey(blockCode) && idDict[blockCode] != null) {
                    Vector2 blockPos = new Vector2((- width/2 + blockInt), (height/2 - line)) * tileSize;
                    Instantiate(idDict[blockCode], blockPos, Quaternion.identity);
                }
            } 

        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
