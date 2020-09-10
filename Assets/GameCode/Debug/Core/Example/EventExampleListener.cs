using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExampleListener : MonoBehaviour
{
    public Rigidbody2D tableRigid;

    public void Start()
    {
        GameEvents.current.onCallExample += () => 
        {
            tableRigid.bodyType = RigidbodyType2D.Dynamic;
            tableRigid.velocity = new Vector2(2, 1); 
        
        };
    }
}
