using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Graficar;
using OpenTK.GLControl;
using OpenTK.Mathematics;

namespace Interfaz
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            game = new Game(glControl1);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            glControl1.MakeCurrent();
            game.OnPaint();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {

            glControl1.Resize += glControl1_Resize;
            glControl1.Paint += glControl1_Paint;
            game.OnLoad();

        }

        private void glControl1_Resize(object sender, EventArgs e)
        {

            glControl1.MakeCurrent();
            game.OnResize();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graficar.Metodo.Tiempo();
            game.OnPaint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graficar.Metodo.reiniciar();
            game.OnPaint();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vector3 translacion = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 escalacion = new Vector3(1.0f, 1.0f, 1.0f);
            Vector3 rotacion = new Vector3(0.0f, 0.0f, 0.0f);
            

            if (checkBox1.Checked)
                translacion = new Vector3(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            if (checkBox2.Checked)
                escalacion = new Vector3(float.Parse(textBox4.Text), float.Parse(textBox5.Text), float.Parse(textBox6.Text));
            if (checkBox3.Checked)
                rotacion = new Vector3(float.Parse(textBox7.Text), float.Parse(textBox8.Text), float.Parse(textBox9.Text));

            if (checkBox4.Checked)
            {
                game.trasnformacionparte(translacion, escalacion, rotacion,textBox13.Text);
            }
            else
            {
                game.trasnformacion(translacion, escalacion, rotacion);
            }
            
            game.OnPaint();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vector centro = new Vector(float.Parse(textBox10.Text), float.Parse(textBox11.Text), float.Parse(textBox12.Text));
            game.Nuevocentro(centro);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
