using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public List<Vector3> newVals;
    public GameObject BoundsEnable;
    public GameObject BoundsDisable;
    public GameObject ResetButton;
    void Start()
    {
        foreach (Transform tr in transform) {
            Debug.Log(tr.gameObject.transform.position);  newVals.Add(tr.position); 
        };
        if (this.GetComponent<BoxCollider>() != null) this.GetComponent<BoxCollider>().enabled = false;
        BoundsEnable.SetActive(false);
        BoundsDisable.SetActive(false);
    }
    public void initVal()
    {
        newVals.Clear();
        foreach (Transform tr in transform)
        {
            newVals.Add(tr.position);
        }
        if (this.GetComponent<BoxCollider>()!=null) this.GetComponent<BoxCollider>().enabled = false;
    }
    public void clicked()
    {
        int ii = 0;
        foreach(Transform tt in transform)
        {
            tt.position= newVals[ii];
            Debug.Log(newVals[ii]);
            ii++;
        }
        if (this.GetComponent<BoxCollider>() != null) this.GetComponent<BoxCollider>().enabled = false;
    }
    public void boxEnable()
    {
        if (this.GetComponent<BoxCollider>() != null) this.GetComponent<BoxCollider>().enabled = true;
    }
    public void CheckSelected()
    {
        int ii = 0;
        foreach (Transform tt in transform)
        {
            if (tt.GetComponent<BoxCollider>() != null)
                tt.GetComponent<BoxCollider>().enabled = false;
            tt.position = newVals[ii];
            Debug.Log(newVals[ii]);
            ii++;
        }
        BoundsEnable.SetActive(true);
        BoundsDisable.SetActive(true);
        ResetButton.SetActive(false);
    }
    public void CheckDeselected()
    {
        Debug.Log("Start Deselect");
        int ii = 0;
        foreach (Transform tt in transform)
        {
            if (tt.GetComponent<BoxCollider>() != null)
                tt.GetComponent<BoxCollider>().enabled = true;
            if(tt!=null)
                tt.position = newVals[ii];
            Debug.Log(newVals[ii]+ tt.position);
            ii++;
            if (ii >= newVals.Count)
            {
                break;
            }
        }
        BoundsEnable.SetActive(false);
        BoundsDisable.SetActive(false);
        ResetButton.SetActive(true);
        if (this.GetComponent<BoxCollider>() != null) this.GetComponent<BoxCollider>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
