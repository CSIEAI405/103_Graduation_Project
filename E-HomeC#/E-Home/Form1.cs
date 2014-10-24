using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSocket.SocketBase;
using SuperWebSocket;
using System.IO.Ports;
using System.Net;
using System.IO;

using System.Runtime.InteropServices;
using System.Threading;
namespace E_Home
{
    public partial class Form1 : Form
    {
        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand,
        string lpstrReturnString, uint uReturnLength, uint hWndCallback);   
       
        [DllImport("Kernel32", CharSet = CharSet.Auto)]
        static extern Int32 GetShortPathName(String path, StringBuilder shortPath, Int32 shortPathLength);

        static string urlHakkaTTS = "http://120.105.129.133/ttstest/tts/tts.php";
        static string urlGoogleTTS = " http://translate.google.com/translate_tts?ie=utf-8&tl=zh&q=";
        string[] myParamsNames = {"txt", "language"};
        WebSocketServer appServer = new WebSocketServer();
        bool isRunning = false;
        int stream = 0;
        SerialPort controlSerialPort;
        SerialPort sensorSerialPort;
        public Form1()
        {
            InitializeComponent();
            controlSerialPort = new SerialPort();
            controlSerialPort.BaudRate = 9600;
            controlSerialPort.DataBits = 8;
            controlSerialPort.StopBits = StopBits.One;

            sensorSerialPort = new SerialPort();
            sensorSerialPort.BaudRate = 115200;
            sensorSerialPort.DataBits = 8;
            sensorSerialPort.StopBits = StopBits.One;
            sensorSerialPort.DataReceived+=sensorSerialPort_DataReceived;
           
        }

        private void sensorSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = ((SerialPort)sender);
            String sensorValue =serialPort.ReadLine();
            foreach (WebSocketSession webSocketSession in appServer.GetAllSessions())
            {
                if (sensorValue!=null)
                    webSocketSession.Send(sensorValue);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                appServer.NewMessageReceived += new SessionHandler<WebSocketSession, string>(appServer_NewMessageReceived);

                if (!appServer.Start())
                {
                    MessageBox.Show("Failed to start!");
                
                    return;
                }
                MessageBox.Show("Started!");
                isRunning = true;
            }
           
        }

            

        private void Form1_Load(object sender, EventArgs e)
        {
         
            appServer = new WebSocketServer();
            comboControlSerialPort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboControlSerialPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboControlSerialPort.Items.Count!=0)
                comboControlSerialPort.SelectedIndex = 0;

            comboSensorSerialPort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSensorSerialPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboSensorSerialPort.Items.Count != 0)
                comboSensorSerialPort.SelectedIndex = 0;

            if (!appServer.Setup(1104)) //Setup with listening port
            {
                MessageBox.Show("Failed to setup!");
                
            }
            
           

        }

        private void appServer_NewMessageReceived(WebSocketSession session, string message)
        {
            //Send the received message back
            
            
            string[] splitedMessage = message.Split(',');
            string nickName = splitedMessage[0];
            string intstuction = splitedMessage[1];

            myUI(nickName, intstuction, controlSerialPort);
            

        

        }

        private delegate void myUICallBack(string nickName,string instruction, SerialPort serialPort);

        private void myUI(string nickName, string instruction, SerialPort serialPort)
        {

            if (this.InvokeRequired)
            {

                myUICallBack myUpdate = new myUICallBack(myUI);

                this.Invoke(myUpdate, nickName, instruction, serialPort);

            }

            else
            {
                if (serialPort.IsOpen)
                    serialPort.Write(instruction);
                else
                    MessageBox.Show("SerialPort isn't opened!");
                List<Entity> list = new List<Entity>();
                string date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                list.Clear();
                switch (Int32.Parse(instruction))
                {
                    case 1:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "fan"));
                        list.Add(new Entity("action", "power mode change"));
                        list.Add(new Entity("date", date));
                        mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "電風扇電源開關,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "電風扇電源開關");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                    case 2:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "fan"));
                        list.Add(new Entity("action", "flow mode change"));
                        list.Add(new Entity("date", date));
                        mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "電風扇風速改變,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "電風扇風速改變");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                    case 3:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "fan"));
                        list.Add(new Entity("action", "swing mode change"));
                        list.Add(new Entity("date", date));
                        mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "電風扇旋轉模式改變,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "電風扇旋轉模式改變");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                    case 4:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "radio"));
                        list.Add(new Entity("action", "power mode change"));
                        list.Add(new Entity("date", date));
                       mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "音響電源開關,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "音響電源開關");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                    case 5:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "radio"));
                        list.Add(new Entity("action", "volume+"));
                        list.Add(new Entity("date", date));
                        mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "音響大聲,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "音響大聲");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                    case 6:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "radio"));
                        list.Add(new Entity("action", "volume-"));
                        list.Add(new Entity("date", date));
                        mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "音響小聲,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "音響小聲");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                    case 7:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "air-conditioning"));
                        list.Add(new Entity("action", "on"));
                        list.Add(new Entity("date", date));
                        mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "冷氣機開,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "冷氣機開");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                    case 8:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "air-conditioning"));
                        list.Add(new Entity("action", "off"));
                        list.Add(new Entity("date", date));
                        mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "冷氣機關,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "冷氣機關");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                    case 9:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "air-conditioning"));
                        list.Add(new Entity("action", "temperature+"));
                        list.Add(new Entity("date", date));
                        mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "冷氣機溫度上升,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "冷氣機溫度上升");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                    case 10:
                        list.Add(new Entity("name", nickName));
                        list.Add(new Entity("appliance", "Air-conditioning"));
                        list.Add(new Entity("action", "temperature-"));
                        list.Add(new Entity("date", date));
                        mciSendString(@"stop D:\HakkaVoice.mp3", null, 0, 0);
                        mciSendString(@"stop D:\ChineseVoice.mp3", null, 0, 0);
                        HakkaTTS(urlHakkaTTS, "冷氣機溫度下降,1");
                        playMP3(@"D:\HakkaVoice.mp3");
                        Thread.Sleep(2000);
                        ChineseTTS(urlGoogleTTS, "冷氣機溫度下降");
                        playMP3(@"D:\ChineseVoice.mp3");
                        break;
                }
                myHttpPostWithParams("http://ehomecontroller2014.appspot.com/record.do", list);

              
               
             
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            appServer.Stop();
            isRunning = false;
        }

        private void btnOpenControlSerialPort_Click(object sender, EventArgs e)
        {
            if (!controlSerialPort.IsOpen)
            {
                if ((string)comboControlSerialPort.SelectedItem!= null)
                {
                    controlSerialPort.PortName = (string)comboControlSerialPort.SelectedItem;
                    controlSerialPort.Open();
                    MessageBox.Show("Open SerialPort!");
                }
                else
                {
                    MessageBox.Show("Can't open SerialPort!");
                }
            }
            else
                MessageBox.Show("SerialPort is opened!");
     
            
        }

        private void btnCloseControlSerialPort_Click(object sender, EventArgs e)
        {
            if (controlSerialPort.IsOpen)
                controlSerialPort.Close();
            else
                MessageBox.Show("SerialPort isn't opened!");
            
        }



       

        private WebResponse myHttpPostWithParams(string requestUrl,List<Entity> myParams)
        {

            HttpWebRequest request = HttpWebRequest.Create(requestUrl) as HttpWebRequest;
            string paramsString = getParamsString(myParams);
           
            byte[] bs = Encoding.UTF8.GetBytes(paramsString);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bs.Length;
            WebResponse wr = null;
            try
            {
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    wr = request.GetResponse();
                }
            }
            catch (SystemException e)
            {
            }
            return wr;
        }

        private WebResponse myHttpPost(string requestUrl)
        {
            HttpWebRequest request = HttpWebRequest.Create(requestUrl) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            WebResponse wr = null;
            wr = request.GetResponse();
            return wr;
        }

        private WebResponse myHttpGet(string requestUrl)
        {
            HttpWebRequest request = HttpWebRequest.Create(requestUrl) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            WebResponse wr = request.GetResponse();    
            return wr;
        }

        public string getParamsString(List<Entity> myParams)
        {
            string paramsString = "";
            int count = 0;
            foreach(Entity entity in myParams){
                paramsString+=(entity.paramName+"="+entity.paramValue);
                count++;
                if (count != myParams.Count)
                    paramsString += "&";

            }
            return paramsString;
        }
        public void playMP3(string fileName)
        {
            mciSendString(@"play "+fileName, null, 0, 0);
        }

        private void HakkaTTS(string url, string text)
        {
            string[] myParamsValues = text.Split(',');
            List<Entity> list = new List<Entity>();
            list.Add(new Entity(myParamsNames[0], myParamsValues[0]));
            list.Add(new Entity(myParamsNames[1], myParamsValues[1]));
            WebResponse wrFromPost = myHttpPostWithParams(url, list);
            string requestPath = "";
            using (Stream repStream = wrFromPost.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(repStream))
                {
                    string responseContent;
                    responseContent = myStreamReader.ReadToEnd();
                    UTF8Encoding enc = new UTF8Encoding();
                    byte[] filePathInUTF8Bytes = Encoding.UTF8.GetBytes(responseContent);
                    var preamble = new UTF8Encoding(true).GetPreamble();

                    string filePathWithOutBOM = enc.GetString(filePathInUTF8Bytes.Skip(preamble.Length).ToArray());
                    requestPath = "http://120.105.129.133/ttstest/" + filePathWithOutBOM;

                }
            }

          //  mciSendString(@"close temp_alias", null, 0, 0);
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.ASCII;
            try
            {
                webClient.DownloadFile(new Uri(requestPath), @"D:\HakkaVoice.mp3");
            }catch(SystemException e){
            }

        }
        private void ChineseTTS(string url,string text)
        {
            //mciSendString(@"close temp_alias", null, 0, 0);
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            webClient.DownloadFile(new Uri(url+text), @"D:\ChineseVoice.mp3");

        }

        private void btnOpenSensorSerialPort_Click(object sender, EventArgs e)
        {
            if (!sensorSerialPort.IsOpen)
            {
                if ((string)comboControlSerialPort.SelectedItem != null)
                {
                    sensorSerialPort.PortName = (string)comboSensorSerialPort.SelectedItem;
                    sensorSerialPort.Open();
                    MessageBox.Show("Open SerialPort!");
                }
                else
                {
                    MessageBox.Show("Can't open SerialPort!");
                }
            }
            else
                MessageBox.Show("SerialPort is opened!");
        }

        private void btnCloseSensorSerialPort_Click(object sender, EventArgs e)
        {
            if (sensorSerialPort.IsOpen)
                sensorSerialPort.Close();
            else
                MessageBox.Show("SerialPort isn't opened!");
        }


    }
}
