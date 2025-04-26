using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetIP : MonoBehaviour

{
    public TextMeshProUGUI IPfield;
public void SetAddress(){
    ClientManager.serverIpAddress = IPfield.text;
}

}
