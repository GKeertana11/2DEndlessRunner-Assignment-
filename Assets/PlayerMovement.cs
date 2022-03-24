using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    SpriteRenderer sprite;
    public float jumpForce;
    Rigidbody2D rb;
    TileSpawnManager spawnTile;
    public GameObject temp;



    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        spawnTile = GameObject.Find("TileSpawnManager").GetComponent<TileSpawnManager>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement.x > 0)
        {
            sprite.flipX = false;
        }
        if (movement.x < 0)
        {
            sprite.flipX = true;
        }

        transform.Translate(-movement.x * speed * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }
     
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {

            TileSpawnManager.Instance.SpawnTile();



        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            //Destroy(collision.gameObject, 3f);
            TileSpawnManager.Instance.BackToPool(collider.gameObject.transform.parent.gameObject);
            temp = collider.gameObject;
           // StartCoroutine("Pool");
        }
    }

    
    /*IEnumerator Pool()
    {
        yield return new WaitForSeconds(1f);
        // TileSpawnManager.Instance.BackToRightPool(temp);
        TileSpawnManager.Instance.BackToPool(temp);


    }*/

   

}
