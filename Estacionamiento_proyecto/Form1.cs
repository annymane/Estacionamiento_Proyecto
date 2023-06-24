using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Estacionamiento_proyecto
{
    public partial class Form1 : Form
    {
        private List<PictureBox> carrosEnMovimiento = new List<PictureBox>();

        //variables para el pictureBox
        private int direction = 1; // Dirección inicial del movimiento
        private int speed = 2; // Velocidad de movimiento
        private int limit = 333; // Límite del movimiento
        private bool stopMovement = false; // Variable para controlar la detención
        private Queue<PictureBox> carrosEspera = new Queue<PictureBox>();

        private PictureBox activeBar = null;



        public Form1()
        {
            InitializeComponent(); 
            Application.Idle += Movimiento_pic;

            // Agregar los dos primeros carros a la lista y hacerlos visibles
            carrosEnMovimiento.Add(pbxCarrito1);
            carrosEnMovimiento.Add(pbxCarrito2);


            pbxCarrito1.Visible = true;
            pbxCarrito2.Visible = true;
            carrosEspera.Enqueue(pbxCarrito3);
            carrosEspera.Enqueue(pbxCarrito4);
            carrosEspera.Enqueue(pbxCarrito5);
            carrosEspera.Enqueue(pbxCarrito6);
            carrosEspera.Enqueue(pbxCarrito7);
            carrosEspera.Enqueue(pbxCarrito8);

        }

        private async void Movimiento_pic(object sender, EventArgs e)
        {
            // Verificar si pbxBarra está fuera del if
            if ((pbxCarrito1.Visible && pbxCarrito2.Visible) || carrosEspera.Any(c => c.Visible))
            {
                pbxbarra.Visible = true;
                pbxbarra.BackColor = Color.Red;

                pbxbarra1.Visible = true;
                pbxbarra1.BackColor = Color.Red;
            }


            if (!stopMovement)
            {
                // Mover los PictureBox horizontalmente
                foreach (PictureBox carro in carrosEnMovimiento)
                {
                    carro.Left += direction * speed;

                    // Verificar si hay un PictureBox en frente
                    PictureBox carroEnFrente = carrosEnMovimiento.FirstOrDefault(c => c.Left == carro.Left + carro.Width);
                    if (carroEnFrente != null)
                    {
                        stopMovement = true; // Detener el movimiento si hay un PictureBox en frente
                        break;
                    }
                }


                // Comprobar límites
                bool reachLimit = carrosEnMovimiento.Any(carro =>
                    carro.Left <= 0 || carro.Left + carro.Width >= limit);


                // Comprobar límites1
                if (reachLimit)
                {
                    stopMovement = true;
                    // Cambiar la dirección cuando se alcanza un límite
                    direction *= -1;

                    // Detener el movimiento si se alcanza el límite deseado
                    foreach (PictureBox carro in carrosEnMovimiento)
                    {
                        if (carro.Left <= 0)
                            carro.Left = 0;
                        else if (carro.Left + carro.Width >= limit)
                            carro.Left = limit - carro.Width;
                    }

                    stopMovement = true;

                    Random random = new Random();

                    // Verificar si se oculta pbxCarrito1 o pbxCarrito2 primero
                    if (random.Next(2) == 0)
                    {
                        // Generar un número aleatorio entre 3000 y 5000 para el tiempo de espera de pbxCarrito1
                        int delayMilliseconds1 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds1);

                        pbxbarra.Visible = false;
                        pbxCarrito1.Visible = false; // Ocultar pbxCarrito1

                        // Generar un número aleatorio diferente entre 3000 y 5000 para el tiempo de espera de pbxCarrito2
                        int delayMilliseconds2 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds2);

                        pbxbarra1.Visible = false;
                        pbxCarrito2.Visible = false; // Ocultar pbxCarrito2
                    }
                    else
                    {
                        // Generar un número aleatorio entre 3000 y 5000 para el tiempo de espera de pbxCarrito2
                        int delayMilliseconds2 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds2);

                        pbxbarra1.Visible = false;
                        pbxCarrito2.Visible = false; // Ocultar pbxCarrito2

                        // Generar un número aleatorio diferente entre 3000 y 5000 para el tiempo de espera de pbxCarrito1
                        int delayMilliseconds1 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds1);

                        pbxbarra.Visible = false;
                        pbxCarrito1.Visible = false; // Ocultar pbxCarrito1
                    }

                    // Remover los carros de la lista y detener su movimiento
                    carrosEnMovimiento.Remove(pbxCarrito1);
                    carrosEnMovimiento.Remove(pbxCarrito2);
                    stopMovement = true;
                }
            }


            // Verificar si no hay carros en movimiento y aún hay carros en espera
            if (carrosEnMovimiento.Count == 0 && carrosEspera.Count > 0)
            {
                Random random = new Random();
                List<PictureBox> carrosEsperaLista = carrosEspera.ToList();

                // Obtener la cantidad de carros en espera antes del bucle
                int cantidadCarrosEspera = carrosEsperaLista.Count;

                // Recorrer la lista de carros en espera
                for (int i = 0; i < cantidadCarrosEspera; i++)
                {
                    // Generar un tiempo de espera aleatorio entre 4 y 8 segundos
                    int delayMilliseconds = random.Next(4000, 8001);
                    await Task.Delay(delayMilliseconds);

                    // Obtener un índice aleatorio dentro del rango de la lista de carros en espera
                    int index = random.Next(carrosEsperaLista.Count);

                    // Obtener el PictureBox aleatoriamente
                    PictureBox carro = carrosEsperaLista[index];

                    // Obtener el número del carro seleccionado
                    int numeroCarro = int.Parse(carro.Name.Replace("pbxCarrito", ""));

                    // Hacer el PictureBox visible
                    carro.Visible = true;

                    // Cambiar la dirección del movimiento hacia la derecha
                    direction = 1;

                    // Agregar el carro a la lista de carros en movimiento
                    carrosEnMovimiento.Add(carro);

                    // Remover el carro de la lista de carros en espera
                    carrosEsperaLista.Remove(carro);

                    // Mover el carro individualmente hacia la derecha
                    while (carro.Left > 0 && carro.Left + carro.Width < limit)
                    {
                        carro.Left += direction * speed;

                        // Esperar un intervalo de tiempo antes de mover el carro nuevamente
                        await Task.Delay(10);
                    }

                    // Generar un tiempo de espera aleatorio entre 4 y 8 segundos antes de ocultar el carro
                    int delayMilliseconds1 = random.Next(4000, 8001);
                    await Task.Delay(delayMilliseconds1);

                    carro.Visible = false;

                    // Verificar si el número del carro es par o impar
                    if (numeroCarro % 2 == 0)
                    {

                        if (!pbxCarrito4.Visible || !pbxCarrito6.Visible || !pbxCarrito8.Visible)
                        {
                            pbxbarra1.Visible = false;
                        }

                    }
                    else
                    {
                        if (!pbxCarrito3.Visible || !pbxCarrito5.Visible || !pbxCarrito7.Visible)
                        {
                            pbxbarra.Visible = false;
                        }

                    }
                }
            }
        }
    }
}
