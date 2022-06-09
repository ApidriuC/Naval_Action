using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Entidades;
using System.Text;
using WMPLib;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naval_Action
{
    public partial class Form5 : Form
    {
        WindowsMediaPlayer sonido;
        private bool comienzoClic;
        bool turno;
        bool verdad;
        int contadorc;
        int posicionx;
        int posiciony;
        bool win;
        PictureBox[,] matriz;
        PictureBox[,] matriz2;
        //Posiciones iniciales de los barcos a poner en el tablero jugador 1
        Point inicialv1 = new Point(679, 572);
        Point inicialh1 = new Point(724, 602);
        //Posiciones iniciales de los barcos a poner en el tablero jugador 2
        Point inicialv2 = new Point(1082, 572);
        Point inicialh2 = new Point(1127, 602);
        Jugador jugador1 = new Jugador("",0);
        Jugador jugador2 = new Jugador("", 0);
        //Pequeñin (2 celdas) pictureBox5 y pictureBox6
        List<PictureBox> barco1 = new List<PictureBox>();
        //Promedio (3 celdas) pictureBox3 y pictureBox4
        List<PictureBox> barco2 = new List<PictureBox>();
        //Submarino (3 celdas) pictureBox1 y pictureBox2
        List<PictureBox> barco3 = new List<PictureBox>();
        //Nave de batalla (4 celdas) pictureBox7 y pictureBox8
        List<PictureBox> barco4 = new List<PictureBox>();
        //Nave nuclear (5 celdas) pictureBox9 y pictureBox10
        List<PictureBox> barco5 = new List<PictureBox>();
        //Lista de todos los barcos
        List<List<PictureBox>> barcosjugador1 = new List<List<PictureBox>>();
        //BARCOS JUGADOR2
        List<PictureBox> barco6 = new List<PictureBox>();
        List<PictureBox> barco7 = new List<PictureBox>();
        List<PictureBox> barco8 = new List<PictureBox>();
        List<PictureBox> barco9 = new List<PictureBox>();
        List<PictureBox> barco10 = new List<PictureBox>();
        //Lista de todos los barcos j2
        List<List<PictureBox>> barcosjugador2 = new List<List<PictureBox>>();
        
        public Form5()
        {
            InitializeComponent();
            CrearMatriz();
            CrearMatriz2();
            //Se asignan los metodos de clic y arrastrar a todos los PictureBox ya que el codigo no cambia
            pictureBox2.MouseDown += pictureBox1_MouseDown;
            pictureBox2.MouseMove += pictureBox1_MouseMove;
            pictureBox3.MouseDown += pictureBox1_MouseDown;
            pictureBox3.MouseMove += pictureBox1_MouseMove;
            pictureBox4.MouseDown += pictureBox1_MouseDown;
            pictureBox4.MouseMove += pictureBox1_MouseMove;
            pictureBox5.MouseDown += pictureBox1_MouseDown;
            pictureBox5.MouseMove += pictureBox1_MouseMove;
            pictureBox6.MouseDown += pictureBox1_MouseDown;
            pictureBox6.MouseMove += pictureBox1_MouseMove;
            pictureBox7.MouseDown += pictureBox1_MouseDown;
            pictureBox7.MouseMove += pictureBox1_MouseMove;
            pictureBox8.MouseDown += pictureBox1_MouseDown;
            pictureBox8.MouseMove += pictureBox1_MouseMove;
            pictureBox9.MouseDown += pictureBox1_MouseDown;
            pictureBox9.MouseMove += pictureBox1_MouseMove;
            pictureBox10.MouseDown += pictureBox1_MouseDown;
            pictureBox10.MouseMove += pictureBox1_MouseMove;
            pictureBox11.MouseDown += pictureBox1_MouseDown;
            pictureBox11.MouseMove += pictureBox1_MouseMove;
            pictureBox12.MouseDown += pictureBox1_MouseDown;
            pictureBox12.MouseMove += pictureBox1_MouseMove;
            pictureBox13.MouseDown += pictureBox1_MouseDown;
            pictureBox13.MouseMove += pictureBox1_MouseMove;
            pictureBox14.MouseDown += pictureBox1_MouseDown;
            pictureBox14.MouseMove += pictureBox1_MouseMove;
            pictureBox15.MouseDown += pictureBox1_MouseDown;
            pictureBox15.MouseMove += pictureBox1_MouseMove;
            pictureBox16.MouseDown += pictureBox1_MouseDown;
            pictureBox16.MouseMove += pictureBox1_MouseMove;
            pictureBox17.MouseDown += pictureBox1_MouseDown;
            pictureBox17.MouseMove += pictureBox1_MouseMove;
            pictureBox18.MouseDown += pictureBox1_MouseDown;
            pictureBox18.MouseMove += pictureBox1_MouseMove;
            pictureBox19.MouseDown += pictureBox1_MouseDown;
            pictureBox19.MouseMove += pictureBox1_MouseMove;
            pictureBox20.MouseDown += pictureBox1_MouseDown;
            pictureBox20.MouseMove += pictureBox1_MouseMove;
        }

        //Creación de las dos matrices

        public void CrearMatriz()
        {            
            matriz = new PictureBox[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PictureBox nuevo = new PictureBox();
                    nuevo.Size = new Size(29,29);
                    nuevo.Location = new Point((i * 31) + 595, (j * 31) +248);
                    matriz[i, j] = nuevo;
                    nuevo.Cursor = Cursors.Hand;                    
                    Controls.Add(nuevo);
                }
            }
        }

        public void CrearMatriz2()
        {            
            matriz2 = new PictureBox[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PictureBox nuevo2 = new PictureBox();
                    nuevo2.Size = new Size(29, 29);
                    nuevo2.Location = new Point((i * 31) + 975, (j * 31) + 248);
                    matriz2[i, j] = nuevo2;
                    nuevo2.Cursor = Cursors.Hand;
                    Controls.Add(nuevo2);
                }
            }
        }

        //Metodo reproductor de sonido

        private void reproducirsonido(string url, int volumen)
        {
            sonido = new WindowsMediaPlayer();
            sonido.URL = url;
            sonido.settings.setMode("loop", true);
            sonido.settings.volume = volumen;
            sonido.controls.play();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            int aaa = Form3.nivelvolumen;
            reproducirsonido(AppDomain.CurrentDomain.BaseDirectory + "\\Epic.mp3", aaa);
            //Cuando turno es true, es el turno del jugador 1, cuando es false es el turno del jugador 2
            turno = true;
            win = false;
            //Todos estos elementos se ocultan y se van mostrando en el codigo a lo largo del programa
            trackBarVolume.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            buttonConfirm1.Visible = false;
            buttonConfirm2.Visible = false;
        }
        
        public void ActualizarUI()
        {
            labelPuntaje1.Text = jugador1.ObtenerPuntaje().ToString();
            labelPuntaje2.Text = jugador2.ObtenerPuntaje().ToString();
            if (turno == true)
            {
                pictureTurn.Location = new Point(590, 72);
                labelTurno.Text = "Es el turno del jugador 1.";
            }
            else
            {
                pictureTurn.Location = new Point(968, 72);
                labelTurno.Text = "Es el turno del jugador 2.";
            }
        }

        //Se obtiene la posicíon x y la posicion y del mouse al hacer clic
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            comienzoClic = true;
            posicionx = e.X;
            posiciony = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        if (matriz[i, j].BackColor == Color.CornflowerBlue || matriz[i, j].BackColor == Color.IndianRed || matriz[i, j].BackColor == Color.Orange || matriz[i, j].BackColor == Color.BlueViolet || matriz[i, j].BackColor == Color.HotPink)
                        {
                            barco3.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialv1;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco3.Add(matriz[i, j]); 
                        }
                    }
                }
            }

            if (contadorc > 3 || contadorc < 3)
            {
                barco3.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv1;
                contadorc = 0;
            }
            else if (contadorc == 3)
            {
                barcosjugador1.Add(barco3);
                foreach (PictureBox x in barco3)
                {
                    x.BackColor = Color.BlueViolet;
                }
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Si se hizo clic...
            if (comienzoClic == true)
            {
                PictureBox clickeado = (PictureBox)sender;
                clickeado.Left += e.X - posicionx;
                clickeado.Top += e.Y - posiciony;
            }
        }

        //Al soltar el mouse
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            //Se esta haciendo clic = no
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            //Para cada casilla de la matriz se verifica si el barco la esta tocando
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        //Si la casilla ya esta ocupada...
                        if (matriz[i, j].BackColor == Color.CornflowerBlue || matriz[i, j].BackColor == Color.IndianRed || matriz[i, j].BackColor == Color.Orange || matriz[i, j].BackColor == Color.BlueViolet || matriz[i, j].BackColor == Color.HotPink)
                        {
                            barco3.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialh1;
                            contadorc = 0;
                            return;
                        }
                        //De lo contrario se cuentan las casillas que estan tocando el barco
                        else
                        {
                            contadorc = contadorc + 1;
                            barco3.Add(matriz[i, j]); 
                        }
                    }
                }
            }
            //El numero de casillas debe ser igual al largo del barco(si es un barco de 3 celdas, debe solo estar posicionado en 3 celdas)
            //Si el barco se puso en mas de 3 celdas...
            if (contadorc > 3 || contadorc < 3)
            {
                barco3.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh1;
                contadorc = 0;
            }
            //De lo contrario, si se puso correctamente...
            else if (contadorc == 3)
            {
                barcosjugador1.Add(barco3);
                foreach (PictureBox x in barco3)
                {
                    x.BackColor = Color.BlueViolet;
                }
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        if (matriz[i, j].BackColor == Color.CornflowerBlue || matriz[i, j].BackColor == Color.IndianRed || matriz[i, j].BackColor == Color.Orange || matriz[i, j].BackColor == Color.BlueViolet || matriz[i, j].BackColor == Color.HotPink)
                        {
                            barco2.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialv1;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco2.Add(matriz[i, j]); 
                        }
                    }
                }
            }

            if (contadorc > 3 || contadorc < 3)
            {
                barco2.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv1;
                contadorc = 0;
            }
            else if (contadorc == 3)
            {
                barcosjugador1.Add(barco2);
                foreach (PictureBox x in barco2)
                {
                    x.BackColor = Color.HotPink;
                }
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        if (matriz[i,j].BackColor == Color.CornflowerBlue || matriz[i,j].BackColor == Color.IndianRed || matriz[i,j].BackColor == Color.Orange || matriz[i,j].BackColor == Color.BlueViolet || matriz[i,j].BackColor == Color.HotPink)
                        {
                            barco2.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialh1;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco2.Add(matriz[i, j]); 
                        }
                    }
                }
            }

            if (contadorc > 3 || contadorc < 3)
            {
                barco2.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh1;
                contadorc = 0;
            }
            else if (contadorc == 3)
            {
                barcosjugador1.Add(barco2);
                foreach (PictureBox x in barco2)
                {
                    x.BackColor = Color.HotPink;
                }
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        contadorc = contadorc + 1;
                        barco1.Add(matriz[i, j]);
                    }
                }
            }

            if (contadorc > 2 || contadorc < 2)
            {
                barco1.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv1;
                contadorc = 0;
            }
            else if (contadorc == 2)
            {
                barcosjugador1.Add(barco1);
                foreach (PictureBox x in barco1)
                {
                    x.BackColor = Color.CornflowerBlue;
                }
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        contadorc = contadorc + 1;
                        barco1.Add(matriz[i, j]);
                    }
                }
            }

            if (contadorc > 2 || contadorc < 2)
            {
                barco1.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh1;
                contadorc = 0;
            }
            else if (contadorc == 2)
            {
                barcosjugador1.Add(barco1);
                foreach (PictureBox x in barco1)
                {
                    x.BackColor = Color.CornflowerBlue;
                }
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        if (matriz[i, j].BackColor == Color.CornflowerBlue || matriz[i, j].BackColor == Color.IndianRed || matriz[i, j].BackColor == Color.Orange || matriz[i, j].BackColor == Color.BlueViolet || matriz[i, j].BackColor == Color.HotPink)
                        {
                            barco4.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialv1;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco4.Add(matriz[i, j]); 
                        }
                    }
                }
            }

            if (contadorc > 4 || contadorc < 4)
            {
                barco4.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv1;
                contadorc = 0;
            }
            else if (contadorc == 4)
            {
                barcosjugador1.Add(barco4);
                foreach (PictureBox x in barco4)
                {
                    x.BackColor = Color.Orange;
                }
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = true;
                pictureBox10.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        if (matriz[i, j].BackColor == Color.CornflowerBlue || matriz[i, j].BackColor == Color.IndianRed || matriz[i, j].BackColor == Color.Orange || matriz[i, j].BackColor == Color.BlueViolet || matriz[i, j].BackColor == Color.HotPink)
                        {
                            barco4.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialh1;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco4.Add(matriz[i, j]); 
                        }
                    }
                }
            }

            if (contadorc > 4 || contadorc < 4)
            {
                barco4.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh1;
                contadorc = 0;
            }
            else if (contadorc == 4)
            {
                barcosjugador1.Add(barco4);
                foreach (PictureBox x in barco4)
                {
                    x.BackColor = Color.Orange;
                }
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = true;
                pictureBox10.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        if (matriz[i, j].BackColor == Color.CornflowerBlue || matriz[i, j].BackColor == Color.IndianRed || matriz[i, j].BackColor == Color.Orange || matriz[i, j].BackColor == Color.BlueViolet || matriz[i, j].BackColor == Color.HotPink)
                        {
                            barco5.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialv1;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco5.Add(matriz[i, j]); 
                        }
                    }
                }
            }

            if (contadorc > 5 || contadorc < 5)
            {
                barco5.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv1;
                contadorc = 0;
            }
            else if (contadorc == 5)
            {
                barcosjugador1.Add(barco5);
                foreach (PictureBox x in barco5)
                {
                    x.BackColor = Color.IndianRed;
                }
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                buttonConfirm1.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox10_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz[i, j].Bounds))
                    {
                        if (matriz[i, j].BackColor == Color.CornflowerBlue || matriz[i, j].BackColor == Color.IndianRed || matriz[i, j].BackColor == Color.Orange || matriz[i, j].BackColor == Color.BlueViolet || matriz[i, j].BackColor == Color.HotPink)
                        {
                            barco5.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialh1;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco5.Add(matriz[i, j]); 
                        }
                    }
                }
            }

            if (contadorc > 5 || contadorc < 5)
            {
                barco5.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh1;
                contadorc = 0;
            }
            else if (contadorc == 5)
            {
                barcosjugador1.Add(barco5);
                foreach (PictureBox x in barco5)
                {
                    x.BackColor = Color.IndianRed;
                }
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                buttonConfirm1.Visible = true;
                contadorc = 0;
            }
        }

        private void buttonConfirm1_Click(object sender, EventArgs e)
        {
            foreach (List<PictureBox> x in barcosjugador1)
            {
                foreach (PictureBox y in x)
                {
                    y.BackColor = default(Color);
                }
            }
            turno = false;
            ActualizarUI();
            buttonConfirm1.Visible = false;
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;
        }

        private void pictureBox11_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        contadorc = contadorc + 1;
                        barco6.Add(matriz2[i, j]);
                    }
                }
            }
            if (contadorc > 2 || contadorc < 2)
            {
                barco6.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv2;
                contadorc = 0;
            }
            else if (contadorc == 2)
            {
                barcosjugador2.Add(barco6);
                foreach (PictureBox x in barco6)
                {
                    x.BackColor = Color.CornflowerBlue;
                }
                pictureBox11.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = true;
                pictureBox14.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox12_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        contadorc = contadorc + 1;
                        barco6.Add(matriz2[i, j]);
                    }
                }
            }
            if (contadorc > 2 || contadorc < 2)
            {
                barco6.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh2;
                contadorc = 0;
            }
            else if (contadorc == 2)
            {
                barcosjugador2.Add(barco6);
                foreach (PictureBox x in barco6)
                {
                    x.BackColor = Color.CornflowerBlue;
                }
                pictureBox11.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = true;
                pictureBox14.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox14_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        if (matriz2[i, j].BackColor == Color.CornflowerBlue || matriz2[i, j].BackColor == Color.IndianRed || matriz2[i, j].BackColor == Color.Orange || matriz2[i, j].BackColor == Color.BlueViolet || matriz2[i, j].BackColor == Color.HotPink)
                        {
                            barco7.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialv2;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco7.Add(matriz2[i, j]); 
                        }
                    }
                }
            }
            if (contadorc > 3 || contadorc < 3)
            {
                barco7.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv2;
                contadorc = 0;
            }
            else if (contadorc == 3)
            {
                barcosjugador2.Add(barco7);
                foreach (PictureBox x in barco7)
                {
                    x.BackColor = Color.HotPink;
                }
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
                pictureBox15.Visible = true;
                pictureBox16.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        if (matriz2[i, j].BackColor == Color.CornflowerBlue || matriz2[i, j].BackColor == Color.IndianRed || matriz2[i, j].BackColor == Color.Orange || matriz2[i, j].BackColor == Color.BlueViolet || matriz2[i, j].BackColor == Color.HotPink)
                        {
                            barco7.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialh2;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco7.Add(matriz2[i, j]); 
                        }
                    }
                }
            }
            if (contadorc > 3 || contadorc < 3)
            {
                barco7.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh2;
                contadorc = 0;
            }
            else if (contadorc == 3)
            {
                barcosjugador2.Add(barco7);
                foreach (PictureBox x in barco7)
                {
                    x.BackColor = Color.HotPink;
                }
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
                pictureBox15.Visible = true;
                pictureBox16.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox15_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        if (matriz2[i, j].BackColor == Color.CornflowerBlue || matriz2[i, j].BackColor == Color.IndianRed || matriz2[i, j].BackColor == Color.Orange || matriz2[i, j].BackColor == Color.BlueViolet || matriz2[i, j].BackColor == Color.HotPink)
                        {
                            barco8.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialv2;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco8.Add(matriz2[i, j]); 
                        }
                    }
                }
            }
            if (contadorc > 3 || contadorc < 3)
            {
                barco8.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv2;
                contadorc = 0;
            }
            else if (contadorc == 3)
            {
                barcosjugador2.Add(barco8);
                foreach (PictureBox x in barco8)
                {
                    x.BackColor = Color.BlueViolet;
                }
                pictureBox15.Visible = false;
                pictureBox16.Visible = false;
                pictureBox17.Visible = true;
                pictureBox18.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox16_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        if (matriz2[i, j].BackColor == Color.CornflowerBlue || matriz2[i, j].BackColor == Color.IndianRed || matriz2[i, j].BackColor == Color.Orange || matriz2[i, j].BackColor == Color.BlueViolet || matriz2[i, j].BackColor == Color.HotPink)
                        {
                            barco8.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialh2;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco8.Add(matriz2[i, j]); 
                        }
                    }
                }
            }
            if (contadorc > 3 || contadorc < 3)
            {
                barco8.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh2;
                contadorc = 0;
            }
            else if (contadorc == 3)
            {
                barcosjugador2.Add(barco8);
                foreach (PictureBox x in barco8)
                {
                    x.BackColor = Color.BlueViolet;
                }
                pictureBox15.Visible = false;
                pictureBox16.Visible = false;
                pictureBox17.Visible = true;
                pictureBox18.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox17_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        if (matriz2[i, j].BackColor == Color.CornflowerBlue || matriz2[i, j].BackColor == Color.IndianRed || matriz2[i, j].BackColor == Color.Orange || matriz2[i, j].BackColor == Color.BlueViolet || matriz2[i, j].BackColor == Color.HotPink)
                        {
                            barco9.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialv2;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco9.Add(matriz2[i, j]); 
                        }
                    }
                }
            }
            if (contadorc > 4 || contadorc < 4)
            {
                barco9.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv2;
                contadorc = 0;
            }
            else if (contadorc == 4)
            {
                barcosjugador2.Add(barco9);
                foreach (PictureBox x in barco9)
                {
                    x.BackColor = Color.Orange;
                }
                pictureBox17.Visible = false;
                pictureBox18.Visible = false;
                pictureBox19.Visible = true;
                pictureBox20.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox18_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        if (matriz2[i, j].BackColor == Color.CornflowerBlue || matriz2[i, j].BackColor == Color.IndianRed || matriz2[i, j].BackColor == Color.Orange || matriz2[i, j].BackColor == Color.BlueViolet || matriz2[i, j].BackColor == Color.HotPink)
                        {
                            barco9.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialh2;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco9.Add(matriz2[i, j]); 
                        }
                    }
                }
            }
            if (contadorc > 4 || contadorc < 4)
            {
                barco9.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh2;
                contadorc = 0;
            }
            else if (contadorc == 4)
            {
                barcosjugador2.Add(barco9);
                foreach (PictureBox x in barco9)
                {
                    x.BackColor = Color.Orange;
                }
                pictureBox17.Visible = false;
                pictureBox18.Visible = false;
                pictureBox19.Visible = true;
                pictureBox20.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox19_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        if (matriz2[i, j].BackColor == Color.CornflowerBlue || matriz2[i, j].BackColor == Color.IndianRed || matriz2[i, j].BackColor == Color.Orange || matriz2[i, j].BackColor == Color.BlueViolet || matriz2[i, j].BackColor == Color.HotPink)
                        {
                            barco10.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialv2;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco10.Add(matriz2[i, j]); 
                        }
                    }
                }
            }
            if (contadorc > 5 || contadorc < 5)
            {
                barco10.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialv2;
                contadorc = 0;
            }
            else if (contadorc == 5)
            {
                barcosjugador2.Add(barco10);
                foreach (PictureBox x in barco10)
                {
                    x.BackColor = Color.IndianRed;
                }
                pictureBox19.Visible = false;
                pictureBox20.Visible = false;
                buttonConfirm2.Visible = true;
                contadorc = 0;
            }
        }

        private void pictureBox20_MouseUp(object sender, MouseEventArgs e)
        {
            comienzoClic = false;
            PictureBox clickeado = (PictureBox)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (clickeado.Bounds.IntersectsWith(matriz2[i, j].Bounds))
                    {
                        if (matriz2[i, j].BackColor == Color.CornflowerBlue || matriz2[i, j].BackColor == Color.IndianRed || matriz2[i, j].BackColor == Color.Orange || matriz2[i, j].BackColor == Color.BlueViolet || matriz2[i, j].BackColor == Color.HotPink)
                        {
                            barco10.Clear();
                            MessageBox.Show("Ya hay un barco en esta posicion. Por favor ubiquelo en otra parte.");
                            clickeado.Location = inicialh2;
                            contadorc = 0;
                            return;
                        }
                        else
                        {
                            contadorc = contadorc + 1;
                            barco10.Add(matriz2[i, j]); 
                        }
                    }
                }
            }
            if (contadorc > 5 || contadorc < 5)
            {
                barco10.Clear();
                MessageBox.Show("Error ubicando el barco. Por favor ubiquelo correctamente e intente otra vez.");
                clickeado.Location = inicialh2;
                contadorc = 0;
            }
            else if (contadorc == 5)
            {
                barcosjugador2.Add(barco10);
                foreach (PictureBox x in barco10)
                {
                    x.BackColor = Color.IndianRed;
                }
                pictureBox19.Visible = false;
                pictureBox20.Visible = false;
                buttonConfirm2.Visible = true;
                contadorc = 0;
            }
        }

        private void buttonConfirm2_Click(object sender, EventArgs e)
        {
            foreach (List<PictureBox> x in barcosjugador2)
            {
                foreach (PictureBox y in x)
                {
                    y.BackColor = default(Color);
                }
            }
            buttonConfirm2.Visible = false;
            //Se inicia el juego
            InicioJuego();            
        }

        //Metodo para que inicie la partida. Se recorre la matriz asignandole a cada casilla el metodo de clic
        private void InicioJuego()
        {
            MessageBox.Show("Inicia la partida.");
            turno = true;
            ActualizarUI();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    matriz2[i, j].Click += pictureBoxClick_Click;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    matriz[i, j].Click += pictureBoxClick2_Click;
                }
            }
        }

        //Metodo de clic en la matriz 2 (el jugador 1 juega aqui)
        private void pictureBoxClick_Click(object sender, EventArgs e)
        {
            //Si no es su turno no se ejecuta
            if (turno == false)
            { return; }
            PictureBox clickeado = (PictureBox)sender;
            if (clickeado.BackColor == Color.Red || clickeado.BackColor == Color.Black)
            { return; }
            foreach (List<PictureBox> x in barcosjugador2.ToList())
            {
                if (x.Contains(clickeado))
                {
                    verdad = true;
                    x.Remove(clickeado);
                    if (x.Count <= 0)
                    {
                        barcosjugador2.Remove(x);
                    }
                }
            }
            if (verdad==true)
            {
                clickeado.BackColor = Color.Red;
                clickeado.BackgroundImage = Properties.Resources.bomb;
                jugador1.AsignarPuntaje(jugador1.ObtenerPuntaje() + 10);
            }
            else
            {
                clickeado.BackColor = Color.Black;
                turno = !turno;
            }
            verdad = false;
            ActualizarUI();
            if (barcosjugador2.Count == 0)
            {
                win = true;
                MessageBox.Show("La partida ha terminado. El jugador 1 es el ganador.");
                Application.Exit();
            }
        }

        //Metodo de clic en la matriz 1 (el jugador 2 juega aqui)
        private void pictureBoxClick2_Click(object sender, EventArgs e)
        {
            //Si no es su turno no se ejecuta
            if (turno == true)
            { return; }
            PictureBox clickeado = (PictureBox)sender;
            if (clickeado.BackColor == Color.Red || clickeado.BackColor == Color.Black)
            { return; }
            foreach (List<PictureBox> x in barcosjugador1.ToList())
            {
                if (x.Contains(clickeado))
                {
                    verdad = true;
                    x.Remove(clickeado);
                    if (x.Count <= 0)
                    {
                        barcosjugador1.Remove(x);
                    }
                }
            }
            if (verdad == true)
            {
                clickeado.BackColor = Color.Red;
                clickeado.BackgroundImage = Properties.Resources.bomb;
                jugador2.AsignarPuntaje(jugador2.ObtenerPuntaje() + 10);
            }
            else
            {
                clickeado.BackColor = Color.Black;
                turno = !turno;
            }
            verdad = false;
            ActualizarUI();
            if (barcosjugador1.Count == 0)
            {
                win = true;
                MessageBox.Show("La partida ha terminado. El jugador 2 es el ganador.");
                Application.Exit();
            }
        }

        //Si el slider de volumen no es visible, se muestra. Si ya se esta mostrando, se oculta
        private void buttonVolume_Click(object sender, EventArgs e)
        {
            if (trackBarVolume.Visible == false)
            { trackBarVolume.Visible = true; }
            else
            { trackBarVolume.Visible = false; }
        }

        //El volumen del reproductor de sonido cambia de acuerdo al valor del slider
        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            sonido.settings.volume = trackBarVolume.Value;
        }

        //Confirmacion de si quiere cerrar el juego si nadie ha ganado
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (win == false)
            {
                DialogResult resultado = MessageBox.Show("¿Esta seguro de que quiere cerrar el juego?", "Cerrar programa", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                } 
            }
        }
    }
}