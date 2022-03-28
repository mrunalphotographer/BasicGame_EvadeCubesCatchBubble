using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private PlayerController m_Pc;
    public enum EnemyType { 
        Evader,
        Catcher
    }

    public EnemyType enemyType;
    
    private void Start()
    {
        m_Pc =  GameObject.Find("Player").GetComponent<PlayerController>();
        
        
    }
    private void Update()
    {
        transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z - (Time.deltaTime * speed)
            );

        //Debug.Log("Red Enemy " + transform.position.z);
        
        if (Vector3.Distance(m_Pc.transform.position, transform.position) < 3.0f)
        {
            if (enemyType == EnemyType.Evader)
            {
                m_Pc.RecieveDamage();
            }
            Destroy(gameObject);
        }
        else if (enemyType == EnemyType.Catcher && transform.position.z <= m_Pc.transform.position.z - 5)
        {
            //Debug.Log("Enemy Type " + enemyType + " Missed");
            m_Pc.RecieveDamage();
            Destroy(gameObject);
        }else if(transform.position.z <= m_Pc.transform.position.z - 20)
        {
            Destroy(gameObject);
        }


        
    }

}
