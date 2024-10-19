using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace s10p21
{
    public partial class Form1 : Form
    {

        ArbolBinario arbol;

        Nodo raiz;

        Point pa;
        Point pb;

        List<Point> la;
        List<Point> lb;

        List<string> ha;
        List<string> hb;

        int n;
        string n1;
        string n2;

        SolidBrush brush1;
        SolidBrush brush2;

        FontFamily fontFamily = new FontFamily("Consolas");
        Font font;
        Pen pincel;

        Random rnd;

        bool ind;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Inicializar();
        }


        private void Inicializar()
        {

            font = new Font(fontFamily, 14, FontStyle.Regular, GraphicsUnit.Pixel);
            brush1 = new SolidBrush(Color.Blue);
            brush2 = new SolidBrush(Color.White);
            pincel = new Pen(Color.Red);
            pincel.Width = 2;

            rnd = new Random();

            ind = false;

            n = 0;

            la = new List<Point>();
            lb = new List<Point>();

            ha = new List<string>();
            hb = new List<string>();

            pa = new Point(0, 0);
            pb = new Point(this.Width / 2, 50);

            la.Add(pa);
            lb.Add(pb);

            int p0 = rnd.Next(1000, 9999);
            string m1 = p0.ToString("0000");

            arbol = new ArbolBinario();
            raiz = new Nodo();
            raiz.dato = p0;
            arbol.raiz = raiz;

            ha.Add("0000");
            hb.Add(m1);

            AgregarPaneles();
            lienzo.Invalidate();

        }


        private void AgregarPaneles()
        {

            lienzo.Controls.Clear();

            for (int i = 0; i < lb.Count; i++)
            {
                Point p1 = new Point(lb[i].X - 20, lb[i].Y - 20);
                Panel pn = new Panel();
                pn.Location = p1;
                pn.Name = "p_" + hb[i];
                //pn.BorderStyle = BorderStyle.FixedSingle;
                pn.Size = new Size(40, 40);
                pn.BackColor = Color.FromArgb(0, 0, 0, 0);
                pn.Click += new System.EventHandler(this.panel_Click);
                lienzo.Controls.Add(pn);
            }
        }


        object aux;

        private void panel_Click(object sender, EventArgs e)
        {
            AgregarNodo(sender);
            //Panel p1 = (sender as Panel);
            //aux = p1;
            //Point ptLowerLeft = new Point(0, p1.Height);
            //ptLowerLeft = p1.PointToScreen(ptLowerLeft);
            //contextMenuStrip1.Show(ptLowerLeft);
        }


        private void AgregarNodo(object sender)
        {
            ind = true;
            Panel pn1 = (sender as Panel);
            Point p = lienzo.PointToClient(Cursor.Position);

            n1 = pn1.Name.Split('_')[1];

            if (Validar(n1)) {
                return;
            }

            pa = new Point(pn1.Location.X + 20, pn1.Location.Y + 20);
            n = n + 1;

            double ar = rnd.Next(40,80);

            double b1 = (Math.PI / 180) * (270 - (ar / 2));
            double b2 = (Math.PI / 180) * (270 + (ar / 2));

            int rp1 = rnd.Next(80, 140);
            int rp2 = rnd.Next(80, 140);
            Size v1 = new Size(Convert.ToInt32(rp1 * Math.Cos(b1)), -1 * Convert.ToInt32(rp1 * Math.Sin(b1)));
            Size v2 = new Size(Convert.ToInt32(rp2 * Math.Cos(b2)), -1 * Convert.ToInt32(rp2 * Math.Sin(b2)));

            Point p1 = Point.Add(pa, v1);
            Point p2 = Point.Add(pa, v2);

            la.Add(pa);
            lb.Add(p1);

            la.Add(pa);
            lb.Add(p2);


            int q0 = Convert.ToInt32(n1);
            int q1 = 0;
            int q2 = 0;

            while (true) {

                q1 = rnd.Next(0, 9999);
                q2 = q0 - q1;

                if (q2 >= 0) {
                    break;
                }
            }




            arbol.Insertar(q0, q1, q2);

            string m1 = q1.ToString("0000");
            string m2 = q2.ToString("0000");

            ha.Add(n1);
            hb.Add(m1);

            n = n + 1;

            ha.Add(n1);
            hb.Add(m2);

            lienzo.Invalidate();
            AgregarPaneles();

        }

        private Boolean Validar(string n0) {
            Boolean res = false;
            for (int i = 1; i < ha.Count; i++)
            {
                if (n0 == ha[i])
                {
                    res = true;
                }
            }
            return res;
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            if (lb.Count > 1)
            {
                for (int i = 1; i < lb.Count; i++)
                    e.Graphics.DrawLine(pincel, la[i], lb[i]);
            }

            for (int i = 0; i < lb.Count; i++)
            {
                e.Graphics.FillEllipse(brush1, lb[i].X - 20, lb[i].Y - 20, 40, 40);
                e.Graphics.DrawEllipse(pincel, lb[i].X - 20, lb[i].Y - 20, 40, 40);
                Point tp = new Point(lb[i].X - 18, lb[i].Y - 8);
                e.Graphics.DrawString(hb[i], font, brush2, tp);
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //if (ind) {
            //    la.Add(pa);
            //    lb.Add(pb);

            //    lienzo.Invalidate();
            //    AgregarPaneles();
            //    ind = false;
            //}
                
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Inicializar();
            }
            if (e.KeyData == Keys.F5)
            {
                lienzo.Invalidate();
            }
            if (e.KeyData == Keys.F4)
            {
                Listar();
            }
            if (e.KeyData == Keys.F3)
            {
                Save();
            }
        }

        private void Listar() {
            //Console.WriteLine("========================================");
            //for (int i = 0; i < lb.Count; i++)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}",i,la[i],lb[i]);
            //}
            //Console.WriteLine("========================================");
            //for (int i = 0; i < hb.Count; i++)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", i, ha[i], hb[i]);
            //}
            //Console.WriteLine("========================================");


            Console.WriteLine("========================================");
            arbol.Transversa(arbol.raiz);
        }

        private void Save() {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            sf.ShowDialog();
            var path = sf.FileName;

            MemoryStream ms = new MemoryStream();
            Bitmap bmp = new Bitmap(lienzo.Width, lienzo.Height);
            bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] Pic_arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(Pic_arr, 0, Pic_arr.Length);
            ms.Close();


            //bmp.Save(@"D:\TestDrawToBitmap.bmp", ImageFormat.Bmp);
        }
    }
}
