using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private float speed;
    private Rigidbody2D myRB;
    private float limitSuperior;
    private float limitInferior;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), playerManager);
        }

        if(other.tag == "Enemy"){
            EnemyGenerator.instance.ManageEnemy(other.gameObject.GetComponent<EnemyController>(), playerManager);
        }
    }

    public void OnMovement(InputAction.CallbackContext context){
        float currentSpeed = speed * context.ReadValue<float>();
        myRB.velocity = new Vector2(0f, currentSpeed);
    }
}
