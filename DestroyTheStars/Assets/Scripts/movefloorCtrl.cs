using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefloorCtrl : MonoBehaviour
{
    public  float speed =3;
    private Rigidbody2D rbody;
    public bool isVertical;
    private Vector2 moveDirec;
    public float changeDirec = 2f;
    public float changeTimer;

    // Start is called before the first frame update
    void Start()//initialize all move things
    {
        rbody = GetComponent<Rigidbody2D>();
        moveDirec = isVertical ? Vector2.up : Vector2.right;
        changeTimer = changeDirec;
    }

    // Update is called once per frame
    void Update()//change position
    {
        Vector2 position = rbody.position;
        changeTimer -= Time.deltaTime;
        if(changeTimer<0)
        {
            moveDirec *= -1;
            changeTimer = changeDirec;
        }
       
        position.x += moveDirec.x * speed * Time.deltaTime;
        position.y += moveDirec.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
    }
}
