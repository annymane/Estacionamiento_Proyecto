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
        //variables para el pictureBox
        private int direction = 1; // Dirección inicial del movimiento
        private int speed = 2; // Velocidad de movimiento
        private int limit = 140; // Límite del movimiento
        private bool stopMovement = false; // Variable para controlar la detención

        public Form1()
        {
            InitializeComponent(); 
            Application.Idle += Movimiento_pic;
        }

        private async void Movimiento_pic(object sender, EventArgs e)
        {
            if (!stopMovement)
            {
                // Mover el PictureBox horizontalmente
                pbxCarrito.Left += direction * speed;
                pbxCarrito2.Left += direction * speed;

                // Comprobar límites
                if (pbxCarrito.Left <= 0 || pbxCarrito.Left + pbxCarrito.Width >= limit || pbxCarrito2.Left <= 0 || pbxCarrito2.Left + pbxCarrito2.Width >= limit)
                {
                    // Cambiar la dirección cuando se alcanza un límite
                    direction *= -1;

                    // Detener el movimiento si se alcanza el límite deseado
                    if (pbxCarrito.Left <= 0)
                        pbxCarrito.Left = 0;
                    else if (pbxCarrito.Left + pbxCarrito.Width >= limit)
                        pbxCarrito.Left = limit - pbxCarrito.Width;

                    if (pbxCarrito2.Left <= 0)
                        pbxCarrito2.Left = 0;
                    else if (pbxCarrito2.Left + pbxCarrito2.Width >= limit)
                        pbxCarrito2.Left = limit - pbxCarrito2.Width;

                    stopMovement = true;


                    Random random = new Random();
                    int selectedPictureBox = random.Next(1, 3); // Generar un número aleatorio entre 1 y 2

                    if (selectedPictureBox == 1)
                    {
                        // Generar un número aleatorio entre 3000 y 5000 para pbxCarrito
                        int delayMilliseconds1 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds1);

                        pbxCarrito.Visible = false; // Ocultar el pbxCarrito

                        // Generar un número aleatorio diferente entre 3000 y 5000 para pbxCarrito2
                        int delayMilliseconds2 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds2);

                        pbxCarrito2.Visible = false; // Ocultar el pbxCarrito2
                    }
                    else
                    {
                        int delayMilliseconds2 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds2);

                        pbxCarrito2.Visible = false; // Ocultar el pbxCarrito2

                        int delayMilliseconds1 = random.Next(3000, 5001);
                        await Task.Delay(delayMilliseconds1);

                        pbxCarrito.Visible = false; // Ocultar el pbxCarrito
                    }
                }
            }
        }
    }
}
