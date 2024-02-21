using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float liftingForce;

    public bool jumped;
    public bool doubleJumped;

    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private float timestamp;

    // Start is called before the first frame update
    void Start()
    {
        // Zaczynamy od pobrania Rigidbody oraz BoxCollider2D - pierwszy będzie służył
        // do wykonywania skoku, drugi służy to do pobrania wymiarów BoxCollidera naszego gracza do
        // metody IsGrounded
        Debug.Log("kot w butach");
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Najpierw sprawdzamy czy gracz jest na ziemi - za pomocą metody IsGrounded()
        // (opisanej dokładniej dalej) jeśli tak to ustawiamy flagi jumped i doubleJumped na false,
        // robimy jeszcze sprawdzenie czasu, aby nie zmienić za szybko flag i postać
        // zdążyła opaść(Update() jest wywoływany co klatkę, na różnych komputerach jest różny czas
        // odświeżenia klatki)

        if (IsGrounded() && Time.time >= timestamp )
        {
            if(jumped || doubleJumped)
            {
                jumped = false;
                doubleJumped = false;
            }

            timestamp = Time.time + 1f;
        }

        // Pobieramy input przyciśnięcie przycisku myszy w Unity jest równoznaczne z
        // dotknięciem ekranu.
        if (Input.GetMouseButtonDown(0))
        {
            // Jeśli gracz chce skoczyć (dotknął ekranu) i jeszcze nie skakał
            // nadajemy mu prędkość skierowaną w górę równą polu jumpForce i ustawiamy odpowiednią flagę
            if (!jumped)
            {
                rb.velocity = (new Vector2(0f, jumpForce));
                jumped = true;
            }
            else if (!doubleJumped)
            {
                // Analogicznie jeżeli jesteśmy już po pierwszym skoku, ale
                // nadal możemy zrobić drugi
                rb.velocity = (new Vector2(0f, jumpForce));
                doubleJumped = true;
            }

            // Jeśli gracz cały czas przytrzymuje palec na ekranie to co klatkę dodajemy
            // siłę liftingForce przemnożoną przez czas od ostatniej klatki(Żeby zniwelować wpływ wahania
            // framerate na grę). Powoduje to powolniejsze opadanie. Drugi warunek zapobiega działaniu siły
            // w trakcie unoszenia się.

            if (Input.GetMouseButton(0) && rb.velocity.y <= 0 )
            {
                rb.AddForce(new Vector2(0f, liftingForce * Time.deltaTime ));
            }
        }
    }

    // Metoda IsGrounded wykorzystuje Physics2D.BoxCast sprawdzając czy jakiś Collider
    // obiektu znajdującego się w warstwie określanej jako podłoże znajduje się w prostokącie o
    // wymiarach gracza(boxCollider2D.bounds.size), tylko że 0.1f jednostki w dół(Vector2.down)

    private bool IsGrounded()
    {

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, whatIsGround);
        return hit.collider != null;
    }
}
