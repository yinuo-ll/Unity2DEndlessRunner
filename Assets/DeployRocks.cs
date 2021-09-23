using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployRocks : MonoBehaviour {
    [SerializeField] GameObject rockSmallPrefab;
    [SerializeField] GameObject rockBigPrefab;

    Vector2 screenBounds;

    // Start is called before the first frame update
    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)) * -1;
        StartCoroutine(rockGroup());
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void spawnRock(){
        int i = Random.Range(0, 2);
        GameObject a;
        if(i == 0) {
            a = Instantiate(rockSmallPrefab) as GameObject;
        } else {
            a = Instantiate(rockBigPrefab) as GameObject;
        }
        a.transform.position = new Vector3(screenBounds.x * -2, Random.Range(-2.4f, -3.5f), -1.0f);
    }

    IEnumerator rockGroup() {
        while(true){
            float respawnTime = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(respawnTime);
            spawnRock();
        }
    }
}
