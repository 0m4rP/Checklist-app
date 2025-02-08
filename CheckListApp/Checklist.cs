using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace CheckListApp
{
    public partial class Checklist : Form
    {
        public Checklist()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
        }

        public void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font ("Arial", 16);
            Font fontTitulo = new Font("Arial", 24);
            Font fontEquipos = new Font("Arial", 12);
            int ancho = 800;
            int ancho2 = 2000;
            int y = 20;

            //variables para la distribución de 2
            float ladoIzquierdoX = 0;
            float ladoDerechox = ancho / 2;

            //variables para la distribución de 3
            float columna1X = 0;
            float columna2X = ancho / 3;
            float columna3X = (ancho / 3) * 2;
            float alturaFila = 30; // Altura de cada fila


            // Variables para linea y titulo
            int margenInferior = 5; // Espacio entre título y la línea

            //datos del colaborador
            e.Graphics.DrawString("CHECKLIST", fontTitulo, Brushes.Black, new RectangleF(20, y += 20, ancho, 40), new StringFormat() { Alignment = StringAlignment.Center });
            //división de la linea
            e.Graphics.DrawLine(Pens.Black, ladoIzquierdoX, y += 60, ladoIzquierdoX + ancho2, y);

            e.Graphics.DrawString("     1. Fecha: " + dt_Fecha.Text, font, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 50, ancho, alturaFila));
            e.Graphics.DrawString("     1. Área: " + txt_Area.Text, font, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 60, ancho / 2, alturaFila));
            e.Graphics.DrawString("     2. Cargo: " + txt_Cargo.Text, font, Brushes.Black, new RectangleF(ladoDerechox, y, ancho / 2, alturaFila));
            e.Graphics.DrawString("     4. Nombre colaborador: " + txt_Colaborador.Text, font, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 60, ancho, alturaFila));
            //datos del equipo 
            e.Graphics.DrawString("     5. Hostname: " + txt_Hostname.Text, font, Brushes.Black, new RectangleF(columna1X, y += 60, ancho / 3, alturaFila));
            e.Graphics.DrawString("     6. Marca: " + cb_Marca.Text, font, Brushes.Black, new RectangleF(columna2X, y, ancho / 3, alturaFila));
            e.Graphics.DrawString("     7. Modelo: " + txt_Modelo.Text, font, Brushes.Black, new RectangleF(columna3X, y, ancho / 3, alturaFila));
            e.Graphics.DrawString("     8. Placa: " + txt_Placa.Text, font, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 60, ancho / 2, alturaFila));
            e.Graphics.DrawString("     9. Seial: " + txt_Serial.Text, font, Brushes.Black, new RectangleF(ladoDerechox, y, ancho / 2, alturaFila));
            //datos de componentes
            e.Graphics.DrawString("     20. Almacenamiento: " + txt_Almacenamiento.Text, font, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 60, ancho, alturaFila));
            e.Graphics.DrawString("     11. Memoria RAM: " + txt_MemoriaRam.Text, font, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 60, ancho / 2, alturaFila));
            e.Graphics.DrawString("     12. Procesador: " + txt_Procesador.Text, font, Brushes.Black, new RectangleF(ladoDerechox, y, ancho / 2, alturaFila));


            //división de la validación entrega el equipo 

            //división de la linea
            e.Graphics.DrawLine(Pens.Black, ladoIzquierdoX, y += 60, ladoIzquierdoX + ancho2, y);

            //titulo centrado
            e.Graphics.DrawString("VALIDACIÓN DEL EQUIPO", fontTitulo, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 30, ancho, alturaFila), new StringFormat() { Alignment = StringAlignment.Center }); //

            //división de la linea
            e.Graphics.DrawLine(Pens.Black, ladoIzquierdoX, y += 70, ladoIzquierdoX + ancho2, y);


            //incremento para seguir escribiendo debajo de la linea

            y += margenInferior;

            //validación del equipo

            e.Graphics.DrawString("     - Usuario dentro de dominio: " + UsuarioCheck(check_Uno), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Validar estado del disco: " + UsuarioCheck(check_Dos), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Validar estado de la batería: " + UsuarioCheck(check_Tres), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Depuración de software sin licencia o desconocidos: " + UsuarioCheck(check_Cuatro), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Configuración de rendimiento: " + UsuarioCheck(check_Cinco), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Limpieza de caché y Temp: " + UsuarioCheck(check_Seis), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Comprobar puertos activos: " + UsuarioCheck(check_Siete), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Comprobar Antivirus: " + UsuarioCheck(check_Ocho), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Drivers y actualizaciones: " + UsuarioCheck(check_Nueve), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Licenciamiento de office: " + UsuarioCheck(check_Diez), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Validar funcionamiento de Outlook y teams: " + UsuarioCheck(check_Once), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Validar acceso a aplicativos web (Odoo, intranet, etc...): " + UsuarioCheck(check_Doce), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Bitlocker activado: " + UsuarioCheck(check_Trece), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Programas instalados (Logmein, OCS, estandar): " + UsuarioCheck(check_Catorce), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Biometrico ingreso: " + UsuarioCheck(check_Quince), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
            e.Graphics.DrawString("     - Realización de BackUp: " + UsuarioCheck(check_Dieciseis), fontEquipos, Brushes.Black, new RectangleF(ladoIzquierdoX, y += 20, ancho, alturaFila));
        }

        public string UsuarioCheck (CheckBox checkBox)
        {
            return checkBox.Checked ? "Si" : "No";
        }
    }
}
