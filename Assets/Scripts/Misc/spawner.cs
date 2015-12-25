using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    public float radius; // If you change the camera zoom you must change this;
    public float spawnEveryXSecs;
    private float deltaTime;
    private float timer;
    public float tileWidth, tileHeight;
    public float width, height;
    private randomGen randomMinion;
    private randomPrefab minionsPrefab;

	// Use this for initialization
	void Start () {
        randomMinion = GetComponent<randomGen>();
        deltaTime = 0;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        deltaTime += Time.deltaTime;
        timer += Time.deltaTime;

        if(deltaTime >= spawnEveryXSecs) {
            deltaTime -= spawnEveryXSecs;

            Vector2 spawnPos = new Vector2(
                   transform.position.x + Random.Range(-radius, radius),
                   transform.position.y + Random.Range(-radius, radius));

            while (
                (!(Camera.main.WorldToViewportPoint(spawnPos).x > 1)
                || !(Camera.main.WorldToViewportPoint(spawnPos).x < 0))

                && (!(Camera.main.WorldToViewportPoint(spawnPos).y > 1)
                || !(Camera.main.WorldToViewportPoint(spawnPos).y < 0))

                && !((spawnPos.x > -tileWidth * (width + 2) / 2 / 2  && spawnPos.x < tileWidth * (width - 2) / 2 / 2)
                && (spawnPos.y > -tileHeight * (height + 2) / 2 / 2 && spawnPos.y < tileHeight * (height - 2)/ 2 / 2))) {

                spawnPos = new Vector2(
                    transform.position.x + Random.Range(-radius, radius),
                    transform.position.y + Random.Range(-radius, radius));

            }

            minionsPrefab = randomMinion.GetRandom();
            Debug.Log(minionsPrefab);

            GameObject minion = Instantiate(minionsPrefab.prefab, spawnPos, Quaternion.identity) as GameObject;
            minion.GetComponent<minionStats>().gru = transform.parent.gameObject;
        }
    }
}
