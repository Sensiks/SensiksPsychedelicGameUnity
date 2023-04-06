using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalOnShovel : MonoBehaviour
{
    [SerializeField]
    private GameObject coalsOnShovel;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.CompareTag("CoalsInCart"))
        {
            Debug.Log("coals on shovel trigger");
            coalsOnShovel.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.transform.tag == "CoalsInCart")
        {
            Debug.Log("coals on shovel collision");
            coalsOnShovel.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coalsOnShovel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
