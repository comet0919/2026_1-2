using UnityEngine;

public class myball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "와 충돌");

        if(collision.gameObject.tag == "ground")
        {
            Debug.Log("땅과 충돌");
        }
    }
}
