using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public Button btn0;
    public Button btnClear;

    public Button defaultBtn1;

    // Start is called before the first frame update
    void Start()
    {
        btn0.BindCommand(new TestCommand0()
        {
            OnExecute = () =>
            {
                var btn = Instantiate<Button>(defaultBtn1, defaultBtn1.transform.parent);
                btn.BindCommand(new TestCommand1());
                btn.gameObject.SetActive(true);
            }
        });

        btnClear.BindCommand(new TestCommand0()
        {
            OnExecute = () =>
            {
                foreach(var button in defaultBtn1.transform.parent.GetComponentsInChildren<Button>())
                {
                    Destroy(button.gameObject);
                }
            }
        });

        defaultBtn1.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
