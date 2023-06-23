using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamiento_proyecto
{
    public partial class Form1 : Form
    {
        private List<PictureBox> carrosEnMovimiento = new List<PictureBox>();

        //variables para el pictureBox
        private int direction = 1; // Dirección inicial del movimiento
        private int speed = 2; // Velocidad de movimiento
        private int limit = 140; // Límite del movimiento
        private bool stopMovement = false; // Variable para controlar la detención
        private Queue<PictureBox> carrosEspera = new Queue<PictureBox>();


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

        }

        private async void Movimiento_pic(object sender, EventArgs e)
        {
            if (!stopMovement)
            {
                // Mover el PictureBox horizontalmente
                pbxCarrito1.Left += direction * speed;
                pbxCarrito2.Left += direction * speed;

                // Comprobar límites1
                if (pbxCarrito1.Left <= 0 || pbxCarrito1.Left + pbxCarrito1.Width >= limit || pbxCarrito2.Left <= 0 || pbxCarrito2.Left + pbxCarrito2.Width >= limit)
                {
                    // Cambiar la dirección cuando se alcanza un límite
                    direction *= -1;

                    // Detener el movimiento si se alcanza el límite deseado
                    if (pbxCarrito1.Left <= 0)
                        pbxCarrito1.Left = 0;
                    else if (pbxCarrito1.Left + pbxCarrito1.Width >= limit)
                        pbxCarrito1.Left = limit - pbxCarrito1.Width;

                    if (pbxCarrito2.Left <= 0)
                        pbxCarrito2.Left = 0;
                    else if (pbxCarrito2.Left + pbxCarrito2.Width >= limit)
                        pbxCarrito2.Left = limit - pbxCarrito2.Width;

                    stopMovement = true;

                    Random random = new Random();

                    // Verificar si se oculta pbxCarrito1 o pbxCarrito2 primero
                    if (random.Next(2) == 0)
                    {
                        // Generar un número aleatorio entre 3000 y 5000 para el tiempo de espera de pbxCarrito1
                        int delayMilliseconds1 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds1);

                        pbxCarrito1.Visible = false; // Ocultar pbxCarrito1

                        // Generar un número aleatorio diferente entre 3000 y 5000 para el tiempo de espera de pbxCarrito2
                        int delayMilliseconds2 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds2);

                        pbxCarrito2.Visible = false; // Ocultar pbxCarrito2
                    }
                    else
                    {
                        // Generar un número aleatorio entre 3000 y 5000 para el tiempo de espera de pbxCarrito2
                        int delayMilliseconds2 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds2);

                        pbxCarrito2.Visible = false; // Ocultar pbxCarrito2

                        // Generar un número aleatorio diferente entre 3000 y 5000 para el tiempo de espera de pbxCarrito1
                        int delayMilliseconds1 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds1);

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
                // Seleccionar el primer carro en espera y hacerlo visible
                PictureBox nuevoCarro = carrosEspera.Dequeue();
                nuevoCarro.Visible = true;

                // Agregar el carro a la lista de carros en movimiento
                carrosEnMovimiento.Add(nuevoCarro);

                // Reiniciar el movimiento
                stopMovement = false;
            }

        }
    }
}
