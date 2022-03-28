using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Stats stats;
    public float speed;
    public Transform leftWall;
    public Transform rightWall;

    private float _horizontalAxis ;

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    private void Update()
    {

        
        _horizontalAxis = Input.GetAxis("Horizontal");
        float horizontalPosition = transform.position.x + _horizontalAxis * Time.deltaTime * speed;
        float playerSize = transform.localScale.x / 2 ;



        if ( horizontalPosition - playerSize < leftWall.position.x + leftWall.localScale.x/2 )
        {
            return;
        }
        if ( horizontalPosition + playerSize > rightWall.position.x - rightWall.localScale.x/2 )
        {
            return;
        }


        transform.position = new Vector3(
                                horizontalPosition,
                                3 ,
                                transform.position.z       
            );
        if (stats.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    public void RecieveDamage()
    {
        stats.UpdateHealth(-10);
        
    }
}
