using UnityEngine;

public class CientificoTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion faceToProta = Quaternion.LookRotation(GameObject.Find("prota").transform.position - transform.position,Vector3.up);
        transform.rotation = faceToProta;
    }
}
