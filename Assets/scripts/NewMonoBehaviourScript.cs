using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int Haelth = 100;
    public float timer = 1.0f
    void Start()
    {
        Haelth = Haelth + 100;
    }
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1.0f;
            Haelth = Haelth - 20;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Haelth = Haelth + 2;
        }
        if(Haelth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
