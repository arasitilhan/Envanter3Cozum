using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Envanter3Deneme
{
    class Program
    {
        static void Main(string[] args)
        {
            int musterinum = 15;
            calistirmaMotoru.KomutCalistir("MuhasebeModulu","MaasYatir", musterinum);
            calistirmaMotoru.KomutCalistir("MuhasebeModulu","YillikUcretTahsilEt",musterinum);
            musterinum++;
            calistirmaMotoru.KomutCalistir("MuhasebeModulu","YillikUcretTahsilEt",musterinum);
            calistirmaMotoru.KomutCalistir("MuhasebeModulu", "MaasYatir", musterinum);

            calistirmaMotoru.BekleyenIslerGerceklestir();
            Console.ReadLine();
        }
    }
    class calistirmaMotoru
    {
        static List<Thread> threads = new List<Thread>();

        public static void KomutCalistir(string modulSinifAdi,string methodAdi,int inputs)
        {
            MyThread obj = new MyThread();
            Thread thr1 = new Thread(new ThreadStart(obj.thread));
            thr1.Name = inputs.ToString();
            thr1.Start();
            if (methodAdi == "MaasYatir") {
                thr1.Suspend();
                Console.Write("{1} : Suspend Thread Name: {0} -", thr1.Name, methodAdi);
                Console.WriteLine("Thread Durumu: {0}", thr1.ThreadState);
                threads.Add(thr1);
            }else{
                Console.Write("{1} : Resume Thread Name : {0} -", thr1.Name, methodAdi);
                Console.WriteLine("Thread Durumu: {0}", thr1.ThreadState);
            }
            
        }
        public static void BekleyenIslerGerceklestir()
        {
            foreach (Thread thr1 in threads.ToList())
            {
                if ((thr1.ThreadState.ToString().Trim() == "Suspended" || thr1.ThreadState.ToString().Trim() == "SuspendedRequested"))
                {
                    thr1.Resume();
                    Console.Write("Bekleyen Işler - Resume Thread Name: {0} -", thr1.Name);
                    Console.WriteLine("Thread Durumu: {0}", thr1.ThreadState);
                    threads.Remove(thr1);
                }
            }
            //threads.Clear();
        }
    }
    public class MyThread
    {
        public void thread()
        {
        }
    }
}
