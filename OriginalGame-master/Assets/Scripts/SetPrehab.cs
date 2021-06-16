using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPrehab : MonoBehaviour
{
    public GameObject gameMaster;
    public CreateObjectController coc;

    // Start is called before the first frame update
    void Start()
    {
        coc = gameMaster.GetComponent<CreateObjectController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        coc.OnClickAble();
    }
}
