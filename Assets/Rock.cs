using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour{
    public float speed = 10.0f;

    Rigidbody2D rb;
    Vector2 screenBounds;

    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)) * -1;

    }

    // Update is called once per frame
    void Update() {
        if(transform.position.x < screenBounds.x * 2){
            Destroy(this.gameObject);
        }
    }
}
