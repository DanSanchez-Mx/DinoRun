using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public Animator anim;
    Vector3 startPosition;

    // Variables del movimiento del personaje
    public float runningSpeed;
    public float jumpForce;
    private bool spJump;
    private bool isGrounded;
    private bool die;

    // Variables para el Sist. de Particulas
    [SerializeField] private ParticleSystem particulas;


    private void Awake()
    {
        // Si no declaras aqui los componentes que se utilizaran en la progrmacion, habra errores
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    public void StartGame()
    {
        this.playerRigidBody.velocity = Vector2.zero;

        Invoke("RestartPosition", .1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("Estroy brincando");
            Jump();
        }


        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("Estoy Agachado");
            Slide();
        }
        else
        {
            anim.SetTrigger("GetUp");
        }


        Die();
    }

    // Funcion FixedUpdate para correr
    private void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            // Este proceso sirve para el movimiento del personaje
            if (playerRigidBody.velocity.x < runningSpeed)
            {
                playerRigidBody.velocity = new Vector2(runningSpeed, playerRigidBody.velocity.y);
                runningSpeed = (float)(runningSpeed + .01);
            }
        }
        else
        {
            playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
        }
    }

    // Funciones para saber si esta tocando el piso o no
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            particulas.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            particulas.Stop();
        }
    }

    // Funcion para saltar
    public void Jump()
    {
        if (isGrounded)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            spJump = true;
            
        }
        else if (spJump)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            spJump = false;
        }
    }

    public void Slide()
    {
        anim.SetTrigger("Slide");
    }

    // Funicion para morir
    void Die()
    {
        float travelledDistance = GetTravelDistance();

        if (die == true)
        {
            //animator.SetBool(STATE_ALIVE, false);
            //SoundManager.Instance.EjecutarSonido(dead);
            GameManager.sharedInstance.gameOver();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            die = true;

        }
        else
        {
            die = false;
        }
    }

    // Sirve para el Score
    public float GetTravelDistance()
    {
        return this.transform.position.x - startPosition.x;
    }
}

