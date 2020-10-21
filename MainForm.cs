using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using System.IO;
  
namespace RFIDProject
{
    
   



        public partial class MainForm : Form
        {
            static MySqlConnection con = null;

            static MySqlDataReader reader = null;
            
            public MainForm()
            {

                InitializeComponent();
                StartWork();
            }

            void StartWork()
            {

                Thread t1 = new Thread(() =>
                  {
                     // MySqlConnection con = null;
                      
                      // while loop reading rfid
                      bool found = false;

                      //AskTeacher frm= new AskTeacher(techer_rfid);

                      String st = "";
                      while (!found)
                      {
                          /*

                          TcpClient tcpc = new TcpClient();
                          Byte[] read = new Byte[32];   // read buffer

                          // Try to connect to the server
                          tcpc.Connect("192.168.16.254", 8080);

                          // Get a NetworkStream object
                          Stream s;
                          s = tcpc.GetStream();

                          // Read the stream and convert it to ASII
                          int bytes = s.Read(read, 0, read.Length);
                          String teacher_rfid = Encoding.ASCII.GetString(read);
                          tcpc.Close();
                          */
                          string teacher_rfid = "5510965";
                          //MessageBox.Show(teacher_rfid);
                          try
                          {
                             
                              string MyconnectionString = "Server=localhost;Database=mysql;username=adil1;password=adilrocks;";
                              con = new MySqlConnection(MyconnectionString);
                              con.Open();
                              //MessageBox.Show("In try");

                              String cmdText = "SELECT name FROM  teacher WHERE rfid =  '" + teacher_rfid + "'";
                             // MessageBox.Show("send query");
                              MySqlCommand cmd = new MySqlCommand(cmdText, con);

                              //MessageBox.Show("After Read");
                              reader = cmd.ExecuteReader();
                             // MessageBox.Show("execute reader");

                              if (reader.Read())
                              {
                                  st = reader.GetString(0);
                                  //MessageBox.Show("Result:" + reader.GetString(0));
                                  found = true;
                                  con.Close();


                              }
                              else
                                  con.Close();
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.Message);
                              MessageBox.Show("end Read");
                          }
                      }
                      LabelText(this.label3, st + "..... Please Wait");
                    //  MessageBox.Show("how many times");
                      Globals.iniVar.teacher_name = st;
                     
                      Thread.Sleep(3000);




                      Application.Run(new AskTeacher());

                     FormDispose(this);

                  });
                AskTeacher f1 = new AskTeacher();



             //   this.Hide();
                t1.Start();
              //  FormDispose(this);


                //  this.Hide();


            }
            delegate void LabelTextCallback(Label bt, String text);
            void LabelText(Label bt, String text)
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (bt.InvokeRequired)
                {
                    LabelTextCallback d = new LabelTextCallback(LabelText);
                    this.Invoke(d, new object[] { bt, text });
                }
                else
                {
                    bt.Text = text;
                }
            }




            delegate void FormDisposeCallback(Form bt);
            void FormDispose(Form bt)
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (bt.InvokeRequired)
                {
                    FormDisposeCallback d = new FormDisposeCallback(FormDispose);
                    this.Invoke(d, new object[] { bt });
                }
                else
                {
                    bt.Hide();
                    
                }
            }

            public delegate void delPassData(string x);





            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void MainForm_Load(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }
        }
    }

class Globals
{

    internal static class iniVar
    {

        public static string teacher_name;
        public static string inc_cr;
        public static string bagde;
     
        public static string teacher_subject;
    }
}