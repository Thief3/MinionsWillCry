using UnityEngine;
using System.Collections;

public class wallBuilder : MonoBehaviour {
    public float width, height;
    public GameObject wall;
    public float wallWidth, wallHeight;

	// Use this for initialization
	void Start () {
	    
    }

    void BuildFloor() {
        for (int i = 0; i < width; i++){
            for (int j = 0; j < height; j++) {
                Vector3 pos = new Vector3(-wallWidth * width / 2 + width * i, -wallHeight * height * j, 0f);
                Instantiate(wall, pos, Quaternion.identity);
            }
        }
    }
	
    void BuildWall() {
        for (float i = 0; i < width / 2; i++) {
            float x = (-width * wallWidth / 2) + wallWidth * i;
            float y = (wallHeight * height / 2 / 2);
            Vector3 pos = new Vector3(x, y, 0f);
            Instantiate(wall, pos, Quaternion.identity);
        }

        for (float i = 0; i < width / 2; i++) {
            float x = (-width * wallWidth / 2) + wallWidth * i;
            float y = (-wallHeight * height / 2 / 2);
            Vector3 pos = new Vector3(x, y, 0f);
            Instantiate(wall, pos, Quaternion.identity);
        }
        for (float i = ((height)); i > 0; i--) {
            float x = (-width * wallWidth / 2);
            float y = (wallHeight * height / 2 / 2) - wallHeight / 2 * i;
            Vector3 pos = new Vector3(x, y, 0f);
            Instantiate(wall, pos, Quaternion.identity);
        }
        for (float i = ((height)); i > 0; i--) {
            float x = (width * wallWidth / 2);
            float y = (wallHeight * height / 2 / 2) - wallHeight / 2 * i;
            Vector3 pos = new Vector3(x, y, 0f);
            Instantiate(wall, pos, Quaternion.identity);
        }
    }
	// Update is called once per frame
	void Update () {
        BuildWall();
	}
}
