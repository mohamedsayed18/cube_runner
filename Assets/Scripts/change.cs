using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TechTweaking.Bluetooth; //include the library

//change the color on command
//TODO ADD GUI BUTTONS to display messeges
public class change : MonoBehaviour
{
    //define some variables
    private BluetoothDevice device; //creating an object(instance)
    Renderer thisRend; //renderer of our cube


    //this is called before the start
    void Awake()
    {
        BluetoothAdapter.enableBluetooth();//Force Enabling Bluetooth
        device = new BluetoothDevice(); //initialize the object with value
        device.MacAddress = "20:16:03:07:13:26"; // the mac address of of the bluetooth
        device.setEndByte(255);
        device.ReadingCoroutine = null;
        device.connect(); //will be in a separate function and called when a button is pressed
    }

    // Start is called before the first frame update
    void Start()
    {
        //statusText.text = "Ready";
        thisRend = GetComponent<Renderer>(); // grab the renderer component on our sphere
    }

    // Update is called once per frame

    void Update()
    {
        /*
        if (device.IsDataAvailable)
        {

            byte[] msg = device.read();//because we called setEndByte(10)..read will always return a packet excluding the last byte 10.
            if (msg != null && msg.Length > 0)
            {
                string content = System.Text.ASCIIEncoding.ASCII.GetString(msg);
                if (content == "world")
                {
                    //statusText.text = "Reading= " + content;
                    thisRend.material.SetColor("_Color", Color.green);
                }
                else
                    thisRend.material.SetColor("_Color", Color.black);
            }
        }
        else
        {
            thisRend.material.SetColor("_Color", Color.red);
            //statusText.text = "Nothing";
        }
        */
        if (device.IsConnected && device.IsReading)
        {
            BtPackets packets = device.readAllPackets();
            if (packets != null)
            {
                int N = packets.Count - 1;
                int indx = packets.get_packet_offset_index(N);
                int size = packets.get_packet_size(N);

                if (packets.Buffer[indx] == 0)
                    thisRend.material.SetColor("_Color", Color.green);
                else
                    thisRend.material.SetColor("_Color", Color.black);
            }

        }
    }
}