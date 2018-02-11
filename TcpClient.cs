using System;
using System.Windows.Forms;
using System.Net.Sockets;
//使用到TcpListen类
using System.Net;

namespace Plugins
{
 class TcpClient
    {

        public  Socket stSend;
        private object _sync = new object();

        public  bool connectServer(String ip ,int port)
        {
            //以下代码是判断是否和远程终结点成功连接
            try
            {
                stSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //初始化一个Socket实例
                IPEndPoint tempRemoteIP = new IPEndPoint(IPAddress.Parse(ip), port);
                // 11.240.96.30 11.240.98.222
                //根据IP地址和端口号创建远程终结点
                EndPoint epTemp = (EndPoint)tempRemoteIP;
                stSend.Connect(epTemp);
                //连接远程主机的8000端口号
                MessageBox.Show("成功连接远程计算机！");
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("目标计算机拒绝连接请求！");
                //statusBar1.Text = "目标计算机拒绝连接请求！";
            }
              return false;
        }
        public  bool disConnect() {
            try { 
            Byte[] bySend = new byte[4];
            //根据字符串“STOP”长度来定义Byte数组
            bySend = System.Text.Encoding.Default.GetBytes("STOP");
            int i = stSend.Send(bySend);
            //发送控制码
            stSend.Close();
            //关闭套接字
            MessageBox.Show("目标计算机断开连接！");
            return true;
            }
            catch (Exception)
            {
                MessageBox.Show("目标计算机拒绝断开连接请求！");
            }
            return false;
        }
        public  String sendData(byte[] bt) {
            String str = "";
            try
            {
             int i  = stSend.Send(bt);
             lock (_sync) {

                    str = getReceiveData();

                }

            }
            catch (Exception)
            {
                MessageBox.Show("数据发送或接收失败！");
            }
            return str;
        }
        public  String getReceiveData()
          {

            string recvpic = "";
            try
            {
                byte[] recvdata = this.Receive();
                recvpic = System.Text.Encoding.Default.GetString(recvdata);
                Console.WriteLine(recvpic);
            }
            catch
            {
            }
         return recvpic;
     }

        private  byte[] Receive()
        {
            try { 
                int recv;
                byte[] datasize = new byte[1024];
                recv = stSend.Receive(datasize, 0, 1024, SocketFlags.None);
                if (recv > 0)
                {
                    return datasize;
                }
            }
            catch
            {
                MessageBox.Show("数据接收异常！");
            }
            return null;
          
        }
        static void Recive(object o)
        {
            var send = o as Socket;
            while (true)
            {
                //获取发送过来的消息
                byte[] buffer = new byte[1024 * 1024 * 2];
                var effective = send.Receive(buffer);
                if (effective == 0)
                {
                    break;
                }
                var str = System.Text.Encoding.UTF8.GetString(buffer, 0, effective);
                Console.WriteLine(str);
            }
        }

    }

}
