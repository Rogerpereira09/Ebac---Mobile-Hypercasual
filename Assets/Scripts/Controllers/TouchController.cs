using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    public Vector2 pastPosition;
    public float velocity = 1f;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // para fazer os testes corretamente, estamos usando "GetMouseButton" ao invés de "GetTouch";
            // a conta que precisa ser feita dentro deste método é igual a: mousePOSITION Agora - MousePositionPassado (para futuro usar +)
            Move(Input.mousePosition.x - pastPosition.x);
        }

        pastPosition = Input.mousePosition;

    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
}
