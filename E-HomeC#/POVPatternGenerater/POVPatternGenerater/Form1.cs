using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
namespace POVPatternGenerater
{
    public partial class Form1 : Form
    {
       //FileInfo fileInfo = null;
        String filePath = null;
        String fileName = null;
       // int fileLenth = 0;

        int mode = 0;
        Socket socket = null;
        Socket transSocket = null;
        Thread connectedThread = null;
        int sPort = 0;
        string strRemoteIPAddress = null;
        IPAddress remoteIPAddress = null;

        bool isConnect = false;
        bool continueFlag = false;
       
        byte[] temp = new byte[1024*1024];
        int bytes;

       

        public Form1()
        {
            InitializeComponent();
            Closing += new CancelEventHandler(Form1_Closing);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            
            IPAddress localIPAddress = getLocalIPAddres();
         
        
            if (mode == 0)
            {
                if (localIPAddress != null)
                {
                    if (checkPort())
                    {
                        MessageBox.Show("Work in server mode!");
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        sPort = int.Parse(txtPort.Text);
                        socket.Bind(new IPEndPoint(localIPAddress, sPort));
                        socket.Listen(10);
                        continueFlag = true;
                        connectedThread = new Thread(new ThreadStart(connectedTask));
                        connectedThread.SetApartmentState(ApartmentState.STA);
                        connectedThread.Start();
                        btnStart.Enabled = false;    
                    }
                    else
                    {
                        MessageBox.Show("Port setting error!");
                    }
                }
                else
                {
                    MessageBox.Show("Local IP not found!");
                }

            }
            else
            {//
                if (checkRemoteIP())
                {
                    if (checkPort())
                    {
                        MessageBox.Show("Work in client mode!");
                        strRemoteIPAddress = txtRemoteIPPart1.Text + "." + txtRemoteIPPart2.Text + "." + txtRemoteIPPart3.Text + "." + txtRemoteIPPart4.Text;
                        remoteIPAddress = IPAddress.Parse(strRemoteIPAddress);
                        sPort = int.Parse(txtPort.Text);
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                        continueFlag = true;
                        connectedThread = new Thread(new ThreadStart(connectedTask));
                        connectedThread.SetApartmentState(ApartmentState.STA);
                        connectedThread.Start();
                        btnStart.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Port setting error!");
                        //return;
                    }


                }
                else
                {
                    MessageBox.Show("Remote IP error!");
                    
                }
               
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            comboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            
            comboMode.Items.Add("Server");
            comboMode.Items.Add("Client");
            comboMode.SelectedItem = "Server";
        }
        IPAddress  getLocalIPAddres()
        {
            string localHostName = Dns.GetHostName();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(localHostName);
            foreach (IPAddress ipaddress in ipHostEntry.AddressList)
            {
                if (ipaddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ipaddress;
                }
            }
            return null;
        }

        private void btnShowIP_Click(object sender, EventArgs e)
        {
            IPAddress localIPAddress = getLocalIPAddres();
            if (localIPAddress != null)
            {
                MessageBox.Show("LocalIP = " + localIPAddress.ToString());
            }
        }

        private void bntBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;
            FileInfo fi =new FileInfo(openFileDialog.FileName);

            fileName = fi.Name;
            if (filePath != null)
            {
                lblFileName.Text = filePath;
            }
        }

        private void comboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = ((ComboBox)sender).SelectedIndex;
        }
        bool checkRemoteIP()
        {  
            TextBox[] txtRemoteIPAddress = { txtRemoteIPPart1, txtRemoteIPPart2, txtRemoteIPPart3, txtRemoteIPPart4 };
            bool checkflag = true;
            byte temp ;
            foreach(TextBox txtbox in txtRemoteIPAddress) {
                checkflag &= byte.TryParse(txtbox.Text, out temp);
            }
            return checkflag;
        }
        bool checkPort()
        {
            int temp ;
            return int.TryParse(txtPort.Text, out temp);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (isConnect)
            {
                if (filePath!= null)
                {
                    FileInfo fi = new FileInfo(@filePath);
                    if (mode == 0)
                    {
                        

                        transSocket.Send(System.Text.Encoding.UTF8.GetBytes("Start\r\n"));
                        transSocket.Send(System.Text.Encoding.UTF8.GetBytes(fileName + "\r\n"));
                        transSocket.Send(System.Text.Encoding.UTF8.GetBytes(fi.Length.ToString() + "\r\n"));
                        transSocket.SendFile(@filePath);
                    }
                    else
                    {
                        socket.Send(System.Text.Encoding.UTF8.GetBytes("Start\r\n"));
                        socket.Send(System.Text.Encoding.UTF8.GetBytes(fileName + "\r\n"));
                        socket.Send(System.Text.Encoding.UTF8.GetBytes(fi.Length.ToString() + "\r\n"));
                        socket.SendFile(@filePath);
                    }
                }
            }
            else
            {
                MessageBox.Show("Disconnected!");
            }
        }
        
        private void connectedTask()
        {
            string command;

            string fileName;
            string fileLength;
            int fileSize;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            int count = 0;
            if (mode == 0)
            {
                transSocket = socket.Accept();
                isConnect = true;
                NetworkStream networkStream = new NetworkStream(transSocket);
                StreamReader streamReader = new StreamReader(networkStream);
                
                while(continueFlag) {
                    command =streamReader.ReadLine();
                    if (command.Equals("Start"))
                    {
                        fileName = streamReader.ReadLine();
                        fileLength = streamReader.ReadLine();
                        fileSize = int.Parse(fileLength);
                        saveFileDialog.FileName = fileName;
                        saveFileDialog.ShowDialog();
                        
                        MessageBox.Show("Size:" + fileLength +"  bytes");
                        Stream stream = saveFileDialog.OpenFile();
                       
                       count = 0;
                       while (count != fileSize)
                       {
                          bytes = networkStream.Read(temp,0,temp.Length);
                          stream.Write(temp, 0, bytes);
                          count+=bytes ;
                          ToolStripPrograss((int)(((float)count / fileSize) * 100));
                       }
                       stream.Close();
                       MessageBox.Show("Send completed!");
                    }

                    if (command.Equals("Stop"))
                    {
                        transSocket.Send(System.Text.Encoding.UTF8.GetBytes("Stop\r\n"));
                        continueFlag = false;
                        isConnect = false;
                        myUI(true, btnStart);
                    }
                }
                streamReader.Close();
                networkStream.Close();
                transSocket.Close();
                socket.Close();


            }
            else
            {
                socket.Connect(remoteIPAddress, sPort);
                if (socket.Connected == true)
                {
                    isConnect = true;
                    NetworkStream networkStream = new NetworkStream(socket);
                    StreamReader streamReader = new StreamReader(networkStream);
                    while (continueFlag)
                    {
                        command = streamReader.ReadLine();
                        if (command.Equals("Start"))
                        {
                            fileName = streamReader.ReadLine();
                            fileLength = streamReader.ReadLine();
                            fileSize = int.Parse(fileLength);
                            saveFileDialog.FileName = fileName;
                            saveFileDialog.ShowDialog();

                            MessageBox.Show("Size:" + fileLength + "  bytes");
                            Stream stream = saveFileDialog.OpenFile();

                            count = 0;
                            while (count != fileSize)
                            {
                                bytes = networkStream.Read(temp, 0, temp.Length);
                                stream.Write(temp, 0, bytes);
                                count += bytes;
                                ToolStripPrograss((int)(((float)count / fileSize) * 100));
                            }
                            stream.Close();
                            MessageBox.Show("Send completed!");
                        }

                        if (command.Equals("Stop"))
                        {
                            socket.Send(System.Text.Encoding.UTF8.GetBytes("Stop\r\n"));
                            continueFlag = false;
                            isConnect = false;
                            myUI(true, btnStart);
                        }
                      
                    }

                    streamReader.Close();
                    networkStream.Close();
                    socket.Close();
                }
                else
                {
                    MessageBox.Show("Connect unsuccesful!");
                }
            }

            connectedThread.Abort();

        }

        delegate void ToolStripPrograssDelegate(int value);
        private void ToolStripPrograss(int value)
        {
            if (statusStrip1.InvokeRequired)
            {
                ToolStripPrograssDelegate del = new ToolStripPrograssDelegate(ToolStripPrograss);
                statusStrip1.Invoke(del, new object[] { value });
            }
            else
            {
                toolStripProgressBarFileTransfer.Value = value; // Your thingy with the progress bar..
            }
        }

        private delegate void myUICallBack(bool enable, Control ctl);

        private void myUI(bool enable, Control ctl)
        {

            if (this.InvokeRequired)
            {

                myUICallBack myUpdate = new myUICallBack(myUI);

                this.Invoke(myUpdate, enable, ctl);

            }

            else
            {

                ctl.Enabled = enable;

            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isConnect)
            {
                if (mode == 0)
                {
                    transSocket.Send(System.Text.Encoding.UTF8.GetBytes("Stop\r\n"));

                }
                else
                {
                    socket.Send(System.Text.Encoding.UTF8.GetBytes("Stop\r\n"));
                }
            }

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isConnect)
            {
                if (mode == 0)
                {
                    transSocket.Send(System.Text.Encoding.UTF8.GetBytes("Stop\r\n"));

                }
                else
                {
                    socket.Send(System.Text.Encoding.UTF8.GetBytes("Stop\r\n"));
                }
            }
            
        }
        
    }

}
