using System;

namespace ConsoleApp2
{
    interface IPlayable 
    {
        void Play();
        void Pause();
        void Stop();
    }
    interface IRecodable
    {
        void Record();
        void Pause();
        void Stop();
    }
    class Player : IPlayable, IRecodable
    {
        bool isPlay = false;
        bool isRecord = false;
        bool isPause = false;

        public void Play()
        {            
            if (!this.isPlay && !this.isRecord && !this.isPause)
            {
                Console.WriteLine("Play");
                this.isPlay = true;
            }
            if (!this.isPlay && !this.isRecord)
            {                
                this.isPlay = true; 
            }
        }

        public void Record()
        {
            if (!this.isPlay && !this.isRecord && !this.isPause)
            {
                Console.WriteLine("Record");
                this.isRecord = true;
            }
            if (!this.isPlay && !this.isRecord)
            {
                this.isRecord = true;
            }
        }
        public void Pause() 
        {
            this.isPause = this.isPause == true ? false : true;
            if (this.isPause) Console.WriteLine("Pause");
            if (!this.isPause && this.isPlay) Console.WriteLine("Play");
            if (!this.isPause && this.isRecord) Console.WriteLine("Record");
        }
        public void Stop() 
        {
            this.isPlay = this.isPlay == true ? false : false;
            this.isRecord = this.isRecord == true ? false : false;
            Console.WriteLine("Stop");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Play();
            player.Pause();
            player.Pause();
            player.Record();
            player.Stop();
            player.Record();
            player.Pause();
            player.Record();
            player.Pause();
            
            Console.ReadLine();
        }
    }
}
