using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RFIDProject
{
    public partial class addstudent : Form
    {
        




        public addstudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectbagde = "not slected";
            if (radioButton3.Checked)
            {

                selectbagde = "electrical2k11";



           

            }
            if (radioButton4.Checked)
            {

                selectbagde = "electrical2k12";
                MessageBox.Show(selectbagde);
            }
            if (radioButton5.Checked)
            {

                selectbagde = "electrical2k13";
                MessageBox.Show(selectbagde);

            }
            if (radioButton6.Checked)
            {

                selectbagde = "electrical2k14";

            }
            if (radioButton7.Checked)
            {

                selectbagde = "mechanical2k11";

            }
            if (radioButton8.Checked)
            {

                selectbagde = "mechanical2k12";

            } if (radioButton9.Checked)
            {

                selectbagde = "mechanical2k13";

            } if (radioButton10.Checked)
            {

                selectbagde = "mechanical 2k14";

            }
            if (radioButton11.Checked)
            {

                selectbagde = "cs2k12";

            }
            if (radioButton12.Checked)
            {

                selectbagde = "cs2k13";

            }
            if (radioButton13.Checked)
            {

                selectbagde = "cs2k14";

            }

            Globals.iniVar.bagde = selectbagde;
            addstudent2 f2 = new addstudent2();
            f2.Show();
            this.Dispose();
        }
    }
}
