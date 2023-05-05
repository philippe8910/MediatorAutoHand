using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

public class XRCubeUDP : MonoBehaviour
{
   
    private int port = 8001;
    Socket socket;
    EndPoint clientEnd; 
    IPEndPoint ipEnd; 
    string recvStr; 
    string sendStr;
    byte[] recvData; 
    byte[] sendData; 
    int recvLen; 
    Thread connectThread;
    Quaternion Qua;
    Quaternion QuaInverse;
    public GameObject XRCam;
    public GameObject XRGroup;
   
   
    [HideInInspector]
    public bool[] KeyDownPos = new bool[] { false, false, false, false, false, false, false, false, false, false };
    [HideInInspector]
    public bool[] KeyDownCtr = new bool[] { false, false, false, false, false, false, false, false, false, false };
    [HideInInspector]
    public bool[] KeyDownCustom_1 = new bool[] { false, false, false, false, false, false, false, false, false, false };
    [HideInInspector]
    public bool[] KeyDownCustom_2 = new bool[] { false, false, false, false, false, false, false, false, false, false };
    public float XRGroupRotation = 0;
    public float XRGroupHight = 1.5f;
    private GameObject[] display;
    bool KeyDown_DPAD_CENTER;
    bool KeyDown_VOLUME_UP;
    bool KeyDown_VOLUME_DOWN;
    bool KeyDown_Init;
    bool KeyDown_Copy;
    bool KeyDown_Del;
    bool KeyDown_mode;
    float PosSpeed = 1;
    float time = 0;

    public bool is4Screen = true;

    string[][] myUrl = new string[10][];
    void InitSocket()
    {

        ipEnd = new IPEndPoint(IPAddress.Any, port);
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(ipEnd);
        socket.ReceiveBufferSize = 2000000;
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        clientEnd = (EndPoint)sender;
       // print("waiting for UDP dgram");
        connectThread = new Thread(new ThreadStart(SocketReceive));
        connectThread.Start();
    }
    void Start()
    {
        KeyDown_mode = true;

        if(this.transform.parent.transform.GetComponent<Camera>())
        {
            display = new GameObject[6];
            for (int i = 0; i < 6; i++)
            {
                display[i] = this.transform.GetChild(0).transform.GetChild(i).gameObject;

            }
            string[] txt = File.ReadAllLines(Application.streamingAssetsPath + "/DisplaySettings.txt");
            string inp_ln = "";
            for (int i = 0; i < 6; i++)
            {
                inp_ln = txt[i];
                string[] words = inp_ln.Split(',');
                myUrl[i] = words;
            }
            //  print( myUrl[0][0] + "_" + myUrl[0][1] );
            //   print( myUrl[1][0] + "_" + myUrl[1][1] );
            //  print( myUrl[2][0] + "_" + myUrl[2][1] );
            // print( myUrl[3][0] + "_" + myUrl[3][1]);
            // print(myUrl[4][0] + "_" + myUrl[4][1] );
            for (int i = 0; i < 6; i++)
            {
                if (myUrl[i][0] == "Show")
                {
                    if (myUrl[i][1] == "1")
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            display[j].transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            display[j].transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);

                        }

                    }
                }
                if (myUrl[i][0] == "is4Screen")
                {
                    if (myUrl[i][1] == "1")
                    {
                        is4Screen = true;
                    }
                    else if(myUrl[i][1] == "-1")
                       {
                        is4Screen = false;
                    }
                }

                        if (myUrl[i][0] == "L")
                {
                    display[0].GetComponent<Camera>().targetDisplay = int.Parse(myUrl[i][1]) - 1;
                }
                if (myUrl[i][0] == "F")
                {
                    display[1].GetComponent<Camera>().targetDisplay = int.Parse(myUrl[i][1]) - 1;
                }
                if (myUrl[i][0] == "R")
                {
                    display[2].GetComponent<Camera>().targetDisplay = int.Parse(myUrl[i][1]) - 1;
                }
                if (myUrl[i][0] == "D")
                {
                    display[3].GetComponent<Camera>().targetDisplay = int.Parse(myUrl[i][1]) - 1;
                }
            }
            if (is4Screen)
            {
                this.transform.parent.transform.GetComponent<Camera>().targetDisplay = 1;
                this.transform.parent.transform.GetComponent<Camera>().depth = -2;
                GameObject.Find("XRCubeCamera_F").GetComponent<Camera>().clearFlags = this.transform.parent.transform.GetComponent<Camera>().clearFlags;
                GameObject.Find("XRCubeCamera_F").GetComponent<Camera>().cullingMask = this.transform.parent.transform.GetComponent<Camera>().cullingMask;
                GameObject.Find("XRCubeCamera_D").GetComponent<Camera>().clearFlags = this.transform.parent.transform.GetComponent<Camera>().clearFlags;
                GameObject.Find("XRCubeCamera_D").GetComponent<Camera>().cullingMask = this.transform.parent.transform.GetComponent<Camera>().cullingMask;
                GameObject.Find("XRCubeCamera_R").GetComponent<Camera>().clearFlags = this.transform.parent.transform.GetComponent<Camera>().clearFlags;
                GameObject.Find("XRCubeCamera_R").GetComponent<Camera>().cullingMask = this.transform.parent.transform.GetComponent<Camera>().cullingMask;
                GameObject.Find("XRCubeCamera_L").GetComponent<Camera>().clearFlags = this.transform.parent.transform.GetComponent<Camera>().clearFlags;
                GameObject.Find("XRCubeCamera_L").GetComponent<Camera>().cullingMask = this.transform.parent.transform.GetComponent<Camera>().cullingMask;
                GameObject.Find("XRCubeCamera_F").GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                GameObject.Find("XRCubeCamera_D").GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                GameObject.Find("XRCubeCamera_R").GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                GameObject.Find("XRCubeCamera_L").GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                for (int i = 1; i < Display.displays.Length; i++)
                {
                    Display.displays[i].Activate();
                }
                display[0].GetComponent<Camera>().depth = 90;
                display[1].GetComponent<Camera>().depth = 90;
                display[2].GetComponent<Camera>().depth = 90;
                display[3].GetComponent<Camera>().depth = 90;
                display[0].GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                display[1].GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                display[2].GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                display[3].GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                display[4].GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
            }
            else  //not 4 screen
            {

                display = new GameObject[6];
                for (int i = 0; i < 6; i++)
                {
                    display[i] = this.transform.GetChild(0).transform.GetChild(i).gameObject;

                }
                this.transform.parent.transform.GetComponent<Camera>().depth = -2;
                GameObject.Find("XRCubeCamera_F").GetComponent<Camera>().clearFlags = this.transform.parent.transform.GetComponent<Camera>().clearFlags;
                GameObject.Find("XRCubeCamera_F").GetComponent<Camera>().cullingMask = this.transform.parent.transform.GetComponent<Camera>().cullingMask;
                GameObject.Find("XRCubeCamera_F").GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                display[1].GetComponent<Camera>().depth = 90;
                display[1].GetComponent<Camera>().targetDisplay = 0;
                display[1].GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
                display[0].SetActive(false);
                display[2].SetActive(false);
                display[3].SetActive(false);
                GameObject.Find("XRCubeCamera_D").transform.gameObject.SetActive(false);
                GameObject.Find("XRCubeCamera_R").transform.gameObject.SetActive(false);
                GameObject.Find("XRCubeCamera_L").transform.gameObject.SetActive(false);


            }
        }
        else
        {
            Debug.LogError("Please put XRCubeDisplayManager as the child of your camera.");
        }

        if (XRGroup != null && XRCam != null)
        {
            XRGroup.transform.position = new Vector3(XRCam.transform.position.x, XRCam.transform.position.y - XRGroupHight, XRCam.transform.position.z);
            XRGroup.transform.rotation = Quaternion.Euler(0, XRCam.transform.rotation.eulerAngles.y + XRGroupRotation, 0);
        }

        SocketQuit();
        KeyDown_DPAD_CENTER = false;
        KeyDown_VOLUME_UP = false;
        KeyDown_VOLUME_DOWN = false;
        InitSocket(); 
        QuaInverse = Quaternion.identity;
       
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Quaternion _Qua = Qua * QuaInverse;
        if(XRGroup!=null && XRCam!= null)
        {
            if (KeyDown_DPAD_CENTER && time > 0.1f)
            {
                KeyDown_DPAD_CENTER = false;
                XRGroup.transform.position = new Vector3(XRCam.transform.position.x, XRCam.transform.position.y - XRGroupHight, XRCam.transform.position.z);
                XRGroup.transform.rotation = Quaternion.Euler(0, XRCam.transform.rotation.eulerAngles.y + XRGroupRotation, 0);
                time = 0;
            }
            if (KeyDown_VOLUME_UP && time > 0.1f)
            {
                KeyDown_VOLUME_UP = false;

                XRGroup.transform.position = new Vector3(XRGroup.transform.position.x, XRGroup.transform.position.y + 0.05f * PosSpeed, XRGroup.transform.position.z);
                time = 0;
            }
            if (KeyDown_VOLUME_DOWN && time > 0.1f)
            {
                KeyDown_VOLUME_DOWN = false;

                XRGroup.transform.position = new Vector3(XRGroup.transform.position.x, XRGroup.transform.position.y - 0.05f * PosSpeed, XRGroup.transform.position.z);
                time = 0;
            }
        }
         

        if (KeyDown_Del && time > 0.1f)
        {
            KeyDown_Del = false;
            //this.transform.GetChild(0).gameObject.active = !this.transform.GetChild(0).gameObject.active;

            if(GameObject.Find("BG_960_1152_1").transform.GetChild(0).gameObject.active)
            {
                GameObject.Find("BG_960_1152_1").transform.GetChild(0).gameObject.active = false;
                GameObject.Find("BG_960_1152_2").transform.GetChild(0).gameObject.active = false;
                GameObject.Find("BG_1728_960_3").transform.GetChild(0).gameObject.active = false;
                GameObject.Find("XRCubePanoramaCam").transform.GetChild(1).gameObject.active = true;
            }
            else
            {
                GameObject.Find("BG_960_1152_1").transform.GetChild(0).gameObject.active = true;
                GameObject.Find("BG_960_1152_2").transform.GetChild(0).gameObject.active = true;
                GameObject.Find("BG_1728_960_3").transform.GetChild(0).gameObject.active = true;
                GameObject.Find("XRCubePanoramaCam").transform.GetChild(1).gameObject.active = false;
            }
            time = 0;
        }
        if (KeyDown_Copy && time > 0.1f)
        {
            KeyDown_Copy = false;
            for (int j = 0; j < 5; j++)
            {
                display[j].transform.GetChild(0).transform.GetChild(1).gameObject.active = !display[j].transform.GetChild(0).transform.GetChild(1).gameObject.active;

            }
            time = 0;

        }
        if(KeyDownCustom_1[1] && time > 0.1f)
        {
            KeyDownCustom_1[1] = false;
            this.transform.GetChild(0).localPosition = new Vector3(this.transform.GetChild(0).localPosition.x-0.1f, this.transform.GetChild(0).localPosition.y, this.transform.GetChild(0).localPosition.z);
            time = 0;
        }
        if (KeyDownCustom_1[2] && time > 0.1f)
        {
            KeyDownCustom_1[2] = false;
            this.transform.GetChild(0).localPosition = new Vector3(this.transform.GetChild(0).localPosition.x + 0.1f, this.transform.GetChild(0).localPosition.y, this.transform.GetChild(0).localPosition.z);
            time = 0;
        }
        if (KeyDownCustom_1[6] && time > 0.1f)
        {
            KeyDownCustom_1[6] = false;
            if (KeyDown_mode)
            {
                this.transform.GetChild(0).localPosition = new Vector3(this.transform.GetChild(0).localPosition.x, this.transform.GetChild(0).localPosition.y, this.transform.GetChild(0).localPosition.z + 0.1f);
            }
            else
            {
                this.transform.GetChild(0).localRotation = Quaternion.Euler(this.transform.GetChild(0).localRotation.eulerAngles.x-2f, this.transform.GetChild(0).localRotation.eulerAngles.y, this.transform.GetChild(0).localRotation.eulerAngles.z);
            }

            time = 0;
        }
        if (KeyDownCustom_1[5] && time > 0.1f)
        {
            KeyDownCustom_1[5] = false;
            if (KeyDown_mode)
            {
                this.transform.GetChild(0).localPosition = new Vector3(this.transform.GetChild(0).localPosition.x, this.transform.GetChild(0).localPosition.y, this.transform.GetChild(0).localPosition.z - 0.1f);
            }
            else
            {
                this.transform.GetChild(0).localRotation = Quaternion.Euler(this.transform.GetChild(0).localRotation.eulerAngles.x+2f, this.transform.GetChild(0).localRotation.eulerAngles.y , this.transform.GetChild(0).localRotation.eulerAngles.z);
            }
                time = 0;
        }
        if (KeyDownCustom_1[3] && time > 0.1f)
        {
            KeyDownCustom_1[3] = false;
            if (KeyDown_mode)
            {
                this.transform.GetChild(0).localPosition = new Vector3(this.transform.GetChild(0).localPosition.x, this.transform.GetChild(0).localPosition.y + 0.1f, this.transform.GetChild(0).localPosition.z);
            }
            else
            {
                this.transform.GetChild(0).localRotation = Quaternion.Euler(this.transform.GetChild(0).localRotation.eulerAngles.x, this.transform.GetChild(0).localRotation.eulerAngles.y + 2f, this.transform.GetChild(0).localRotation.eulerAngles.z);
            }
                time = 0;
        }
        if (KeyDownCustom_1[4] && time > 0.1f)
        {
            KeyDownCustom_1[4] = false;
            if (KeyDown_mode)
            {
                this.transform.GetChild(0).localPosition = new Vector3(this.transform.GetChild(0).localPosition.x, this.transform.GetChild(0).localPosition.y - 0.1f, this.transform.GetChild(0).localPosition.z);
            }
            else
            {
                this.transform.GetChild(0).localRotation = Quaternion.Euler(this.transform.GetChild(0).localRotation.eulerAngles.x, this.transform.GetChild(0).localRotation.eulerAngles.y-2f, this.transform.GetChild(0).localRotation.eulerAngles.z);
            }
                time = 0;
        }

        if (KeyDown_Init && time > 0.1f)
        {
            KeyDown_Init = false;
            this.transform.GetChild(0).localPosition = Vector3.zero;
            this.transform.GetChild(0).localRotation = Quaternion.identity;
            time = 0;
        }

    }

    void SocketReceive()
    {
        while (true)
        {
            recvData = new byte[2000000];         
            recvLen = socket.ReceiveFrom(recvData, ref clientEnd);
            recvStr = Encoding.ASCII.GetString(recvData, 0, recvLen);
           // Debug.Log(recvStr);
            string[] head = recvStr.Split(',');
            if (head[0] == "Ctr")
            {
             //   KeyDownCtr[int.Parse(head[1])] = true;
            }
            else if (head[0] == "Cus1")
            {
                KeyDownCustom_1[int.Parse(head[1])] = true;
            }
            else if (head[0] == "Cus2")
            {
           //     KeyDownCustom_2[int.Parse(head[1])] = true;
            }
            else if (head[0] == "Pos")
            {
                KeyDown_mode = true;
            //    KeyDownPos[int.Parse(head[1])] = true;
            }
            else if (head[0] == "KeyDown" && head[1] == "23")  //MR GOGGLE KEYCODE_DPAD_CENTER
            {
                KeyDown_DPAD_CENTER = true;
            }
            else if (head[0] == "KeyDown" && head[1] == "24")  //MR GOGGLE KEYCODE_VOLUME_UP
            {
                KeyDown_VOLUME_UP = true;
            }
            else if (head[0] == "KeyDown" && head[1] == "25")  //MR GOGGLE KEYCODE_VOLUME_DOWN
            {
                KeyDown_VOLUME_DOWN = true;
            }
            else if (head[0] == "Init")  //MR GOGGLE KEYCODE_VOLUME_DOWN
            {
                KeyDown_Init = true;
            }
            else if (head[0] == "Copy")  //MR GOGGLE KEYCODE_VOLUME_DOWN
            {
                KeyDown_Copy = true;
            }
            else if (head[0] == "Del")  //MR GOGGLE KEYCODE_VOLUME_DOWN
            {
                KeyDown_Del= true;
            }
            if (head[0] == "Rot")
            {
                KeyDown_mode = false;
                /*Qua.w = float.Parse(head[1]);
                Qua.x = float.Parse(head[2]);
                Qua.y = float.Parse(head[4]);
                Qua.z = float.Parse(head[3]);*/

            }
         
        }

    }
    void OnDestroy()
    {
        
        SocketQuit();
    }
    void SocketQuit()
    {
        if (connectThread != null)
        {
            connectThread.Interrupt();
            connectThread.Abort();
        }
        if (socket != null)
            socket.Close();
       // print("disconnect");
    }
    void OnApplicationQuit()
    {
        SocketQuit();
    }
}
