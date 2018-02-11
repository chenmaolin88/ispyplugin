using System;
using System.Windows.Forms;

namespace Plugins
{
    public partial class Configure : Form
    {
        public string Configuration;
        private readonly Main _owner;

        public Configure(Main owner)
        {
            InitializeComponent();
            _owner = owner;
        }

        private void Configure_Load(object sender, EventArgs e)
        {
            //numWidth.Value = _owner.LineWidth;
            this.Connect.Checked = this._owner.Connect;
            this.tcpDisconnect.Checked = this._owner.tcpDisconnect;
            this.interverSet.Value = this._owner.interval;
            this.ip.Text = this._owner.ip;
            this.port.Text = this._owner.port;
            this.alertSet.Text = this._owner.alertSet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  _owner.LineWidth = (int) numWidth.Value;
           // DialogResult = DialogResult.OK;
           // Close();
            this._owner.Connect = this.Connect.Checked;
            this._owner.tcpDisconnect = this.tcpDisconnect.Checked;
            this._owner.interval = (int)this.interverSet.Value;
            this._owner.ip = this.ip.Text;
            this._owner.port = this.port.Text;
            this._owner.alertSet = this.alertSet.Text;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }
    }
}
