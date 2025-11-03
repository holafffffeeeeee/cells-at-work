using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class inv2Iteminfo : MonoBehaviour
{
    [SerializeField]
    public Item item; // Reference to the item data
    [SerializeField]
    public int quantity; // Number of items to add to the inventory






    void Update()
    {
        // You can add any additional logic here, if needed
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with the item
        if (collision.gameObject.tag == "Player")
        {
            // Attempt to add the item to the inventory
            Destroy(collision.gameObject);
        }
    }
}
