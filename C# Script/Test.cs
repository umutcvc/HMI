using System.Collections;
using UnityEngine;
using System.IO.Ports;
public class Test : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM4", 9600); //Transfer data from COM4 port
    public string receivedstring;
    public float sensitivity = 0.001f;
    public Transform CC, DD, XX; //Name of the componenets created on Unity
    public string[] datas;

    void Start()
    {
        data_stream.Open();
    }

    void Update()
    {
        receivedstring = data_stream.ReadLine(); //Read the sensor values line by line
        string[] datas = receivedstring.Split(','); //Sensor values are seperated by comma on arduino script
        int received_angle = Mathf.RoundToInt(float.Parse(datas[1])); //1st index sensor value
        int received_angle2 = Mathf.RoundToInt(float.Parse(datas[0]));

      CC.transform.eulerAngles = new Vector3(0,0,received_angle*0.01f); //Rotation of the spheres on Unity (hidden mode)

      DD.transform.eulerAngles = new Vector3(0,0,received_angle2*0.01f);

      XX.transform.eulerAngles = new Vector3(0,received_angle2*0.01f,0);
    }
}