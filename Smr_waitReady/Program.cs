using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smr_waitReady {
    class Program {
        static void Main(string[] args) {
            Wait wait = new Wait();

            wait.getHead();
            wait.SendAtk();

            if(wait.head == Define.head1) {
                wait.CheckFile2();
            } else {
                wait.CheckFile1();
            }

            wait.SendEnd();
        }

        public class Wait {
            public string head { get; set; }

            public void getHead() {
                while (true) {
                    try {
                        head = File.ReadAllText(Path.head);
                        break;
                    } catch { Thread.Sleep(50); }
                }
                File.Delete(Path.head);
            }
            public void SendAtk() {
                File.WriteAllText(Path.atk, string.Empty);
            }
            public void CheckFile1() {
                while (true) {
                    try {
                        File.ReadAllText(Path.file1);
                        Thread.Sleep(250);

                    } catch {
                        break;
                    }
                }
            }
            public void CheckFile2() {
                while (true) {
                    try {
                        File.ReadAllText(Path.file2);
                        Thread.Sleep(250);

                    } catch {
                        break;
                    }
                }
            }
            public void SendEnd() {
                File.WriteAllText(Path.result1 + head + Path.result2, Define.resultPass);
            }
        }
        public static class Path {
            public static readonly string head = "../../config/head.txt";
            public static readonly string atk = "call_exe_tric.txt";
            public static readonly string file1 = "SmrWaitReady1.txt";
            public static readonly string file2 = "SmrWaitReady2.txt";
            public static readonly string result1 = "test_head_";
            public static readonly string result2 = "_result.txt";
        }
        public static class Define {
            public static readonly string head1 = "1";
            public static readonly string resultPass = "PASS\r\nPASS";
        }
    }
}
