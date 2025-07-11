using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Thrd_Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class playerConroller : MonoBehaviour
{

    public Thrd_Boundary boundary;

    public float speed;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float FireRate;
    private float nextFire;
    int count3;

    public Vector3 movement;
    float time_m;
    private float smoothInputVertical;
    public float sensitivity = 5;
    public float gravity = 3;
    RaycastHit hit;
    Ray ray;

    float previous;
    float velocity;

    private Vector3 screenPoint;
    private Vector3 offset;

    private bool isSensor;


    public int quick_count;

    private Rigidbody2D rb;


    void Start()
    {
        DesiderSensor();

        boundary.xMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x + 1f;
        boundary.xMax = -1 * Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x - 1f;
        boundary.zMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).z + 1f;
        boundary.zMax = -1 * Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).z - 1f;

    }

    void DesiderSensor()
    {
        //	print ("Input is Sensor : " + PlayerPrefs.GetInt(PPs.PPINPUT_TOGGLE));		
        //0 sensor
        //1 touch
        if (PlayerPrefs.GetInt(PPs.PPINPUT_TOGGLE) == 0)
        {
            isSensor = true;
        }
        else
        {
            isSensor = false;
        }
    }
   

   

    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quick_count++;

            if (quick_count == 1)
            {
                StartCoroutine(reset());
            }

            if (quick_count >= 2)
            {
                Application.Quit();
            }
        }



        if (!isSensor)
            MyTouch_();
        //if (Input.GetButton ("Fire1") && Time.time > nextFire)
        if (Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

    }
    public IEnumerator reset()
    {
        yield return new WaitForSeconds(0.6f);
        quick_count = 0;
        //CloseAllproductpanel();
        //Switch_panel(0);
    }

    void OnMouseDown()
    {
        //		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
        //		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        /*
			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);		
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);
			if (!isSensor) 
			{
				transform.position = curPosition;
			}
		*/
    }

    void MyTouch_() // need to keep player ahead of shuttle.
    {
        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)

            {
                Plane plane = new Plane(Vector3.up, transform.position);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float dist;
                //	float deltaTouch = (touch.position.x - previousTouch.position.x);
                //    if (plane.Raycast(ray, out dist))
                //    {
                //        Vector3 a = ray.GetPoint(dist);

                //Vector3 pos = new Vector3
                //(
                //        Mathf.Clamp(a.x, boundary.xMin - 1, boundary.xMax + 1),
                //        0.0f,
                //        Mathf.Clamp(a.z, boundary.zMin - 1, boundary.zMax + 1)
                //);


                //transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 7);

                if (plane.Raycast(ray, out dist))

                {
                    transform.position = Vector3.MoveTowards(transform.position, ray.GetPoint(dist), Time.deltaTime * 7);
                    transform.position = new Vector3
                        (
                        Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
                        0.0f,
                        Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
                        );

                }


                    //transform.position = Vector3.MoveTowards(transform.position, ray.GetPoint(dist), Time.deltaTime * 7);
                //}
            }
        }
    }

    void FixedUpdate()
    {
      //  return;

        GetComponent<Rigidbody>().velocity = movement * speed;
        if (isSensor)
        {
            float spd = Time.deltaTime * 25;
            transform.Translate(Input.acceleration.x * spd, 0, Input.acceleration.y * spd);
            //print ("ALL : " + Mathf.Clamp (Input.acceleration.y * spd, boundary.zMin, boundary.zMax));
            //print("Min : " + boundary.zMin + " MAx : "+ boundary.zMax + "Acc : " + Input.acceleration.y);



            GetComponent<Rigidbody>().position = new Vector3
            (
                    Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin - 1, boundary.xMax + 1),
                    0.0f,
                    Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin - 1, boundary.zMax + 1)
            );
        }

        //	velocity = (transform.position.x - previous) / Time.deltaTime; 
        //	transform.rotation = Quaternion.Euler(0f, 0.0f,velocity * 5);
        //	previous = transform.position.x; 				
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet" || other.tag == "Enemy" || other.tag == "haz1" || other.tag == "haz2")
        {
            lifeUpdate.life--;
        }
        if (count3 >= 4)
        {
            Destroy(gameObject);
        }
    }
}
