using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour

{
    //seta as viarvel

    public float velocidade = 0.0f ;
    public float entradaHorizontal ;
    public float entradaVertical ;
    public GameObject tiro1;
    public float tempoDeDisparo = 0.3f ;
    public float podeDisparar = 0.0f ;
    public bool possoDarDisparoTriplo = false ;
    public GameObject disparoTriplo ;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start de "+this.name);
        velocidade = 5.0f ;
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
           
        Movimento();
 
         

        if (Input.GetKeyDown(KeyCode.Space)){

            if ( Time.time > podeDisparar ){
               
               if (possoDarDisparoTriplo == true ){

                   Instantiate(disparoTriplo,transform.position + new Vector3(0,0,0),Quaternion.identity);

               } else {   

                   Instantiate(tiro1,transform.position + new Vector3(0,0,0),Quaternion.identity);
               }
               
                




                podeDisparar = Time.time + tempoDeDisparo ;
            }
 
        }
       
   }


    private void Movimento()
    {
       entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime*velocidade*entradaHorizontal);

        if ( transform.position.x  > 1.13f) {
            transform.position = new Vector3(1.13f,transform.position.y,0);
        }

        if ( transform.position.x  < -8.27f ) {
            transform.position = new Vector3(-8.27f,transform.position.y,0);
        
        }

        entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up*Time.deltaTime*velocidade*entradaVertical);

        if ( transform.position.y  < -4.39f ) {
            transform.position = new Vector3(transform.position.x,-4.39f,0);
        }

        if ( transform.position.y > 4.49f  ) {
            transform.position = new Vector3(transform.position.x,4.49f,0);
        }


    }
}
