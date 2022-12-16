using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Numerics;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Transformacao_Triangulo_Estrela
{
    public partial class Form1 : Form
    {
        float Za, Zb, Zc, Zab, Zbc, Zca;
        float ja, jb, jc, jab, jbc, jca;
        Complex ra = new Complex();
        Complex rb = new Complex();
        Complex rc = new Complex();
        Complex rab = new Complex();
        Complex rbc = new Complex();
        Complex rca = new Complex();
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                textBox1.Text = "";
                textBox1.Enabled = false;
                textBox2.Text = "";
                textBox2.Enabled = false;
                textBox3.Text = "";
                textBox3.Enabled = false;
                textBox7.Text = "";
                textBox7.Enabled = false;
                textBox8.Text = "";
                textBox8.Enabled = false;
                textBox9.Text = "";
                textBox9.Enabled = false;

                textBox4.Text = "";
                textBox4.Enabled = true;
                textBox5.Text = "";
                textBox5.Enabled = true;
                textBox6.Text = "";
                textBox6.Enabled = true;
                textBox10.Text = "";
                textBox10.Enabled = true;
                textBox11.Text = "";
                textBox11.Enabled = true;
                textBox12.Text = "";
                textBox12.Enabled = true;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                textBox4.Text = "";
                textBox4.Enabled = false;
                textBox5.Text = "";
                textBox5.Enabled = false;
                textBox6.Text = "";
                textBox6.Enabled = false;
                textBox10.Text = "";
                textBox10.Enabled = false;
                textBox11.Text = "";
                textBox11.Enabled = false;
                textBox12.Text = "";
                textBox12.Enabled = false;

                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox2.Text = "";
                textBox2.Enabled = true;
                textBox3.Text = "";
                textBox3.Enabled = true;
                textBox7.Text = "";
                textBox7.Enabled = true;
                textBox8.Text = "";
                textBox8.Enabled = true;
                textBox9.Text = "";
                textBox9.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                Zab = Single.Parse(textBox5.Text);
                Zbc = Single.Parse(textBox4.Text);
                Zca = Single.Parse(textBox6.Text);
                jab = String.IsNullOrEmpty(textBox7.Text) ? jab = 0 : jab = Single.Parse(textBox10.Text);
                jbc = String.IsNullOrEmpty(textBox7.Text) ? jbc = 0 : jbc = Single.Parse(textBox11.Text);
                jca = String.IsNullOrEmpty(textBox7.Text) ? jca = 0 : jca = Single.Parse(textBox12.Text);
                Complex cab = Complex.FromPolarCoordinates(Zab, jab * Math.PI/180);
                Complex cbc = Complex.FromPolarCoordinates(Zbc, jbc * Math.PI/180);
                Complex cca = Complex.FromPolarCoordinates(Zca, jca * Math.PI/180);
                // Conversão Triângulo-Estrela
                ra = (cab * cca) / (cab + cbc + cca);
                rb = (cbc * cab) / (cab + cbc + cca);
                rc = (cca * cbc) / (cab + cbc + cca);
                textBox1.Text = Complex.Abs(ra).ToString();
                textBox3.Text = Complex.Abs(rb).ToString();
                textBox2.Text = Complex.Abs(rc).ToString();
                textBox7.Text = (ra.Phase * 180 / Math.PI).ToString();
                textBox8.Text = (rb.Phase * 180 / Math.PI).ToString();
                textBox9.Text = (rc.Phase * 180 / Math.PI).ToString();
            }
            if(radioButton2.Checked == true)
            {
                Za = Single.Parse(textBox1.Text);
                Zb = Single.Parse(textBox3.Text);
                Zc = Single.Parse(textBox2.Text);
                ja = String.IsNullOrEmpty(textBox7.Text) ? ja = 0 : ja = Single.Parse(textBox7.Text);
                jb = String.IsNullOrEmpty(textBox7.Text) ? jb = 0 : jb = Single.Parse(textBox8.Text);
                jc = String.IsNullOrEmpty(textBox7.Text) ? jc = 0 : jc = Single.Parse(textBox9.Text);
                Complex ca = Complex.FromPolarCoordinates(Za, ja * Math.PI / 180);
                Complex cb = Complex.FromPolarCoordinates(Zb, jb * Math.PI / 180);
                Complex cc = Complex.FromPolarCoordinates(Zc, jc * Math.PI / 180);
                // Conversão Estrela-Triângulo
                rab = ((ca * cb) + (cb * cc) + (cc * ca)) / cc;
                rbc = ((ca * cb) + (cb * cc) + (cc * ca)) / ca;
                rca = ((ca * cb) + (cb * cc) + (cc * ca)) / cb;
                textBox5.Text = Complex.Abs(rab).ToString();
                textBox4.Text = Complex.Abs(rbc).ToString();
                textBox6.Text = Complex.Abs(rca).ToString();
                
                textBox10.Text = (rab.Phase*180/Math.PI).ToString();
                textBox11.Text = (rbc.Phase*180/Math.PI).ToString();
                textBox12.Text = (rca.Phase*180/Math.PI).ToString();
            }
        }
    }
}
