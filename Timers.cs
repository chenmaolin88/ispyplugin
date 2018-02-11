using System;
using System.Windows.Forms;
namespace Plugins
{
    class Timers
    {
         public static int currentCount = 0;
         //定义Timer类
        System.Timers.Timer timer;
        //int interval = 10
        public Timers(int interval)
        {
             InitTimer(interval);
        }
         /// <summary>
         /// 初始化Timer控件
         private void InitTimer(int interval){
             //设置定时间隔(毫秒为单位)
             //设置执行一次（false）还是一直执行(true)
             timer = new System.Timers.Timer(interval);
             timer.AutoReset = true;
             //设置是否执行System.Timers.Timer.Elapsed事件
             timer.Enabled = true;
             //绑定Elapsed事件
             timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);
         }

        /// <summary>
        /// Timer类执行定时到点事件
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void TimerUp(object sender, System.Timers.ElapsedEventArgs e)
         {
             try
             {
                 currentCount += 1;
                 if (currentCount >= 999999) {
                     currentCount = 0;
                 }
            }
             catch (Exception ex)
             {
                 MessageBox.Show("执行定时到点事件失败:" + ex.Message);
             }
         }

    }
}
