using UnityEngine;
using System.Collections;

public class randomGen : MonoBehaviour {
    public randomPrefab[] prefabsToSpawn;
    public randomPrefab chosenPrefab;

    private int[] cumulativeProbalities;

    void Start() {
        cumulativeProbalities = new int[prefabsToSpawn.Length];

        cumulativeProbalities[0] = prefabsToSpawn[0].probabilityOfSpawn;

        for(int i = 1; i < prefabsToSpawn.Length; i++) {
            cumulativeProbalities[i] = cumulativeProbalities[i - 1] + prefabsToSpawn[i].probabilityOfSpawn;
        }

    }

    public randomPrefab GetRandom() {
        int randNum = Random.Range(0, cumulativeProbalities[cumulativeProbalities.Length - 1]);
        Debug.Log(randNum);
        randomPrefab selected = null;
        for (int i = 0; i < cumulativeProbalities.Length; i++) {
            if (randNum < cumulativeProbalities[i]) {
                selected = prefabsToSpawn[i];

                break;
            }
        }

        return selected;
    }

}
