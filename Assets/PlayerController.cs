using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //resources:
    //https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
    //https://www.youtube.com/watch?v=NgV6iJC_F3s

    float speed = 10;
    float jumpVelocity = 2;
    public Vector3 startPos = new Vector3(0, 5, 0);
    private bool canJump = true;

    int health = 100;

    //public AudioClip damageSoundClip;
    public AudioSource damageSoundSource;
    public AudioClip damageSoundClip;

    Rigidbody body;

    public int getHealth(){
        return health;
    }

    void Start()
    {
        if (GetComponent<Rigidbody>() != null) //init ridigbody
            body = GetComponent<Rigidbody>();
        else
            Debug.LogError("no rigidbody attached");

        transform.position = startPos;

 
        damageSoundSource = GameObject.Find("PlayerHit").GetComponent<AudioSource>();
        //damageSoundClip = damageSoundSource.GetComponent<AudioClip>();
       
        updateHealth();

        string headStr = transform.GetChild(1).name;
        string bodyStr = transform.GetChild(0).name;
        applyPowers(headStr);
        applyPowers(bodyStr);
    }

    private void applyPowers(string str){
        
        if(str.ToLower().Contains("sphere")){
            GetComponent<Shoot>().bulletCooldown = 0;
        }else if(str.ToLower().Contains("cylinder")){
            speed = 14;
        }else if(str.ToLower().Contains("cube")){
            jumpVelocity = 5;
        }else{
            Debug.LogError("No power found.");
        }

    }

    void OnCollisionEnter(Collision col)//called when collision occurs
    {
        //Debug.Log(col.collider is SphereCollider);
        if (col.gameObject.tag.Equals("Zombie"))
        {
            health -= 5;
            
            damageSoundSource.Play(); //plays damage taken sound
            updateHealth();
        }
    }

    void updateHealth()
    {
        var healthText = GameObject.Find("Health_Text").GetComponent<UnityEngine.UI.Text>();
        healthText.color = new Color(1, 0, 0);
        healthText.text = "Health: " + health;
    }

    // FixedUpdate is called once per physics-frame
    void FixedUpdate()
    {
        //Source: https://answers.unity.com/questions/1386777/get-origin-of-plane-in-world-coordinates.htmla
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();
        int layerMask = 1 << 8;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.gameObject.tag.Equals("WorldMesh"))
            {
                Vector3 mousePos = hit.point; //mouse position in world coordinates
                Vector3 playerPos = transform.position;
                float deltaX = mousePos.x - playerPos.x;
                float deltaZ = mousePos.z - playerPos.z;

                //Debug.Log(mousePos.x + " " + mousePos.z);

                Vector3 direction = new Vector3(deltaX, 0, deltaZ);

                transform.forward = direction;
                //transform.rotation = new Quaternion(0, 0, Mathf.Tan(deltaX / deltaZ), 0);
                //Debug.Log(transform.rotation);
            }
        }

        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        body.velocity = new Vector3(0, body.velocity.y, 0);
        body.velocity += transform.forward * Input.GetAxis("Vertical") * speed;
        body.velocity += transform.right * Input.GetAxis("Horizontal") * speed;
    }

    private void HandleJump()
    {

        canJump = false;

        if (IsGrounded())
        {
            canJump = true;
        }

        if (canJump == true)
        {


            if (Input.GetKey("space"))
            {
                body.velocity += new Vector3(0, jumpVelocity, 0);
                canJump = false;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, transform.GetChild(0).GetComponent<Collider>().bounds.extents.y + 0.1f);
    }
}
