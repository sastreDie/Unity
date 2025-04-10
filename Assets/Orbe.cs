using UnityEngine;

public class Orbe : MonoBehaviour
{
    public float oscilationFrequency;
    public float oscilationAmplitude;
    public float oscilationOffset = 1;

    //si debe hacer el efecto de rotar
    public bool MustRotate;
    public float angularSpeed;

    public bool MustThrob;
    public float ThrobbingFrequency = 2;
    public float ThrobbingScale = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //    y = c Sin(kx)
        float ypos = Mathf.Sin( Time.time * oscilationFrequency) * oscilationAmplitude ;  
        transform.localPosition = 
            new Vector3( transform.localPosition.x , oscilationOffset+ ypos, transform.localPosition.z );

        if(MustRotate)
        {
            //para rotar un objeto en angulos de Euler
            // VEctor3.up esta definido como (0,1,0)
            transform.Rotate(  Vector3.up , angularSpeed * Time.deltaTime  );
        }

        if(MustThrob)
        {
            float scale = 5 + Mathf.Sin( ThrobbingFrequency * Time.time ) * (ThrobbingScale-1);
            transform.localScale = new Vector3 (  scale,scale,scale  );
        }
    }
}
