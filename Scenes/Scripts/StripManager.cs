using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StripManager : MonoBehaviour
{
    public float speed;
    private GameObject playerGo;

    private void Awake()
    {
        playerGo = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
                            transform.position.x,
                            transform.position.y,
                            transform.position.z - Time.deltaTime * speed
            );

        if (playerGo.transform.position.z -10 >= transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
