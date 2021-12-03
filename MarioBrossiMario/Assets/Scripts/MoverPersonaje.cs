using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public int velocidad;
    private int _velocidad;
    private Transform miTransform;
    public Vector2 fuerzaSalto; //La fuerza con la que saltara

    private Rigidbody2D miRigidBody;

    //varibales para aniamciones
    private bool isGrounded;
    private Animator miAnimator;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        miTransform = this.transform;
        miRigidBody = GetComponent<Rigidbody2D>();

        //Animaciones
        miAnimator = GetComponent<Animator>();
        isGrounded = true;
        miAnimator.SetBool("isGrounded", isGrounded);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Acciones();

        //Animaciones
        UpdateAnimaciones();
        _velocidad = 0;

    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            miRigidBody.AddForce(fuerzaSalto, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _velocidad = -velocidad;
            //Girar el personaje
            miTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _velocidad = velocidad;
            //Girar el personaje
            miTransform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Acciones()
    {
        miTransform.Translate(Vector3.right * _velocidad * Time.deltaTime);
    }

    private void UpdateAnimaciones()
    {
        if (_velocidad < 0 || _velocidad > 0)
            miAnimator.SetInteger("velocidad", 1);
        else
            miAnimator.SetInteger("velocidad", 0);

        miAnimator.SetBool("isGrounded", isGrounded);
    }

    //Colision con el suelo para que cambie a la animacion 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision personaje con cualquier suelo
        if (collision.transform.tag.Equals("suelo"))
        {
            isGrounded = true;
        }
        if (collision.transform.tag.Equals("tub_peq_arriba"))
        {
            isGrounded = true;
        }
        if (collision.transform.tag.Equals("tub_med_arriba"))
        {
            isGrounded = true;
        }
        if (collision.transform.tag.Equals("bloque?"))
        {
            isGrounded = true;
        }
        if (collision.transform.tag.Equals("ladrillo"))
        {
            isGrounded = true;
        }

        //colision personaje con parte de abajo de un bloque "?"
        if (collision.transform.tag.Equals("bloque?abajo"))
        {
            transform.position = new Vector3(1, 1, 1);
        }


        if (collision.transform.tag.Equals("coin"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
