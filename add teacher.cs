using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace RFIDProject
{
    public partial class add_teacher : Form
    {
        public add_teacher()
        {
            InitializeComponent();
            addnewteacher();
            //LabelText(this.label3, Globals.iniVar.sResult1 + "..... Please Wait");
      

        }










        private void button1_Click(object sender, EventArgs e)
        {
            // label4.TextChanged += Globals.iniVar.sResult1;


            MySqlConnection con = null;
            MySqlDataReader reader = null;
         //   MySqlDataReader reader2 = null;
            string MyconnectionString = "Server=localhost;Database=mysql;username=adil1;password=adilrocks;";
            con = new MySqlConnection(MyconnectionString);
            con.Open();
            
            String cmdText1 = "INSERT INTO  `mysql`.`teacher` (`name` ,`rfid` ,`totalcr` ,`subject`)VALUES ('" + textBox2.Text + "', '" +Globals.iniVar.teacher_name+ "' , '0',  '" + textBox3.Text + "')";

            MySqlCommand cmd1 = new MySqlCommand(cmdText1, con);

           reader = cmd1.ExecuteReader();
            MessageBox.Show("teacher added successfully");
         
            this.Hide();


            FormDispose(this);

        }

            
               void addnewteacher()
            {

                Thread t1 = new Thread(() =>
                  {
                      MySqlConnection con = null;
                     // MySqlDataReader reader = null;
                      string MyconnectionString = "Server=localhost;Database=mysql;username=adil1;password=adilrocks;";
                      con = new MySqlConnection(MyconnectionString);
                      con.Open();
                      // while loop reading rfid
                      bool found = false;

                      //AskTeacher frm= new AskTeacher(techer_rfid);

                    
                      while (!found)
                      {

                        

                          
                          {


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


                              // Display the data
                              //Console.WriteLine("\n  Received {0} bytes", bytes);
                             // Console.WriteLine(messege);
                           

                      // teacher_rfid = "5510965";
                               // Globals.iniVar.sResult1 = teacher_rfid;
                                //MessageBox.Show(Globals.iniVar.sResult1);
                              //MessageBox.Show("In try");
                              LabelText(this.label4, teacher_rfid);
                             

                                  found = true;


                              
                          }
                       
                      }
                     
                    
                      Thread.Sleep(3000);




                  });
              



               
                t1.Start();
               


          

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
            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void MainForm_Load(object sender, EventArgs e)
            {

            }
        }
            
        }
       
    
       

       
    
