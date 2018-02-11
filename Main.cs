using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace Plugins
{
    public class Main : IDisposable
    {
        private string _config = "";
        private bool _disposed;
        //预警级别"0"-无异常，"1"-疑似异常，"2"-异常
        private String state = "0";
        internal String ip = "127.0.0.1";
        internal String port = "9988";
        internal String alertSet = "注意，有预警!";
        private Thread _processor;
        private object _sync = new object();
        public string Alert;
        private Bitmap currentFrame;
        internal bool tcpDisconnect = false;
        internal bool Connect = true;
        internal int interval = 100;
        TcpClient tcpClient = new TcpClient();
        //创建发送数据套接字
        private bool tcpConnect = false;
        private bool isReady = true;
        public delegate String BackDataHandler(byte[] bt);

        public string Configure()
        {
            Plugins.Configure configure = new Plugins.Configure(this);
            if (configure.ShowDialog() == DialogResult.OK)
            {
                this._config = this.Connect + "|" + this.tcpDisconnect+"|"+this.interval+"|" + this.ip + "|" + this.port + "|" + this.alertSet;
                this.InitConfig();
            }
            return this.Configuration;
        }

        private  void DetectFaces()
        {
            
            try
            {

                    if (tcpConnect&& isReady)
                    {
                        isReady = false;
                        byte[] picturebytes = BitmapToBytes(this.currentFrame);
                        string pic = Convert.ToBase64String(picturebytes) + "@@END@@";
                        byte[] bt = System.Text.Encoding.Default.GetBytes(pic);
                    //int num = TcpClient.sendData(bt);
                        Task task = new Task(() => {
                           String backData =tcpClient.sendData(bt);
                            if (backData.Contains("@@CRITICAL@@"))
                            {

                                this.state = "2";
                            }
                            else if (backData.Contains("@@WARNING@@"))
                            {
                                this.state = "1";
                            }
                            else
                            {
                                this.state = "0";
                            }
                            isReady = true;

                        });
                          task.Start();

                      // BackDataHandler handler = new BackDataHandler(tcpClient.sendData);
                        //IAsyncResult result = handler.BeginInvoke(bt,new AsyncCallback(CallbackFunc), null);
                        

                          
                    }
                    else {
                        this.state = "0";
                }     
                

            }
            catch 
            {  
                MessageBox.Show("请在配置中设置连接远程服务器！");
            }

            this.currentFrame = null;
        }
       public void CallbackFunc(IAsyncResult result)
        {
            BackDataHandler handler = (BackDataHandler)((AsyncResult)result).AsyncDelegate;
            //this.backData = handler.EndInvoke(result);
            
        }

        public byte[] BitmapToBytes(Bitmap Bitmap)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                Bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.GetBuffer();
                return byteImage;

            }
            catch (ArgumentNullException ex)
            {

                throw ex;
            }
           finally
            {
                Bitmap.Dispose();
                ms.Close();
            }


        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                this._disposed = true;
            }
        }

        ~Main()
        {
            this.Dispose(false);
        }

        private void InitConfig()
        {
            if (this._config != "")
            {
                string[] strArray = this._config.Split(new char[] { '|' });
                this.Connect = Convert.ToBoolean(strArray[0]);
                this.tcpDisconnect = Convert.ToBoolean(strArray[1]);
                this.interval = Convert.ToInt32(strArray[2]);
                this.ip = Convert.ToString(strArray[3]);
                this.port = Convert.ToString(strArray[4]);
                this.alertSet = Convert.ToString(strArray[5]);
                if (this.Connect.Equals(true) && this.interval > 0)
                {
                    this.tcpConnect = tcpClient.connectServer(this.ip, int.Parse(this.port));
                    Timers timer = new Timers(interval);
                }
                if (this.tcpDisconnect.Equals(true)) {
                    if (this.tcpConnect)
                    {
                       this.tcpConnect = tcpClient.disConnect();
                    }
                   
                }
            }
        }

        public Bitmap ProcessFrame(Bitmap frame)
        {
            
                this.currentFrame = new Bitmap(frame);
                this.DetectFaces();
            

             
                if (this.state.Equals("2"))
                {
                    this.Alert = "Object Detected";
                    frame = ImageDraw(frame);
                    return frame;
                }
                else if (this.state.Equals("1")) {
                    this.Alert = "";
                    frame = ImageDraw(frame);
                    return frame;

                }else
                    this.Alert = "";
            
            return frame;
        }

        public Bitmap ImageDraw(Bitmap frame) {

            Graphics graphics = Graphics.FromImage(frame);
            Font font = new Font("宋体", 26  );
            SolidBrush sbrush = new SolidBrush(Color.Red);
            graphics.DrawString(this.alertSet, font, sbrush, new PointF(10, 10));
            // MemoryStream ms = new MemoryStream();
            // frame.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return frame;


        }

        public string Configuration
        {
            get
            {
                return this._config;
            }
            set
            {
                this._config = value;
                this.InitConfig();
            }
        }
    }
}