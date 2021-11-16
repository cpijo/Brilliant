using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace School.Services.CreateDatabase
{
    public class Video
    {
        public string Title { get; set; }
    }
    public class VideoEncoder
    {
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video ......");
            Thread.Sleep(3000);
        }
    }

    public class video_Caller
    {
        public void  Main_Run(){
            var video = new Video() { Title = "video 1" };
            var videoEncoder = new VideoEncoder();
            videoEncoder.Encode(video);

        }
    }
}

/*
https://www.c-sharpcorner.com/article/user-specific-notifications-using-asp-net-mvc-and-signalr/
if (progressBar.InvokeRequired)
               {

                   void Invoker()
                   {
                       progressBar.Properties.Maximum = count;


                       progressBar.PerformStep();
                       progressBar.Update();
                   }
                   progressBar.Invoke((MethodInvoker)Invoker);
               }
               else
               {
                   progressBar.PerformStep();
                   progressBar.Update();
               }
               
               
               
 //////////////////////// or
 //Update progress bar in separate task
progressBarControl.Invoke((Action) (() =>
progressBarControl.EditValue = 100));

*/
