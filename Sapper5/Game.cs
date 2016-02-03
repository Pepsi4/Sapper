using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Sapper5
{
   public partial class game : Form
   {
      public static int siz = 32, field = 36;
      public int x = 90, y = 0, r = 0, bom = 0, num = 0, bmcount = 0;
      ArrayList a = new ArrayList();   //y
      ArrayList b = new ArrayList();   //x
      ArrayList c = new ArrayList();   // bomb
      ArrayList d = new ArrayList();   //pict box (bu)
      ArrayList e = new ArrayList();   // Pustue kletki
      bool[] f = new bool[36];
      int[] flg = new int[36];
      Point po = new Point();
      PictureBox pb = new PictureBox();
      PictureBox pb2 = new PictureBox();
      public game()
      {
         InitializeComponent();
      }

      bool rand = true;
      bool rand2 = true;
      bool rand3 = true;
      bool rand4 = true;
      bool rand5 = true;
      bool rand6 = true;
      bool gam = true;


      public void butt(bool test = false, int t = 0)
      {

         r = 0;
         if (t >= 0 && t < 6)
         {
            if (rand == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand = false;
            }
         }
         if (t >= 6 && t < 12)
         {
            if (rand2 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand2 = false;
            }
         }

         if (t >= 12 && t < 18)
         {
            if (rand3 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand3 = false;
            }
         }
         if (t >= 18 && t < 24)
         {
            if (rand4 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand4 = false;
            }
         }
         if (t >= 24 && t < 30)
         {
            if (rand5 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand5 = false;
            }
         }
         if (t >= 30 && t < 36)
         {
            if (rand6 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand6 = false;
            }
         }


         PictureBox bu = new PictureBox();
         if (r == 1 && test == true) //BOM BOM
         {
            bu.BackgroundImage = Properties.Resources.bomb;
         }
         else
         {
            bu.BackgroundImage = Properties.Resources._0;
         }
         bu.Size = new Size(32, 32);
         bu.Location = new Point(x, y);
         b.Add(x);
         a.Add(y);
         c.Add(r);
         d.Add(bu);
         this.Controls.Add(bu);
         bu.MouseDown += button1_MouseDown;
         //bu.Click +=

      }

      private void Form1_Load(object sender, EventArgs e)
      {
         load();
      }

      // 8: лево, право, вверх, вниз, левверх, левниз, правверх, правниз

      public void left(int o)
      {
         if ((int)c[o - 6] == 1)
         {
            bom++;
         }
      }

      public void right(int o)
      {
         if ((int)c[o + 6] == 1)
         {
            bom++;
         }
      }

      public void up(int o)
      {
         if ((int)c[o - 1] == 1)
         {
            bom++;
         }
      }

      public void down(int o)
      {
         if ((int)c[o + 1] == 1)
         {
            bom++;
         }
      }

      public void leftdown(int o)
      {
         if ((int)c[o - 5] == 1)
         {
            bom++;
         }
      }

      private void button1_Click(object sender, EventArgs e)
      {
         if (num == bmcount)
         {
            MessageBox.Show("U win");
         }
         else
         {
            gam = false;
            MessageBox.Show("U lose");
         }
      }

      private void button1_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left && gam == true)  //levo
         {
            bom = 0;
            pb = sender as PictureBox;
            for (int p = 0; p < field; p++)
            {
               po = new Point((int)b[p], (int)a[p]);
               if (pb.Location == po)
               {

                  if ((int)c[p] == 1) // NAZATIE NA BOMBU  & c - bombu, a - y, b -x;
                  {
                     MessageBox.Show("Game Over");
                     gam = false;
                     for (int u = 0; u < field; u++)
                     {
                        if ((int)c[u] == 1) // POKAZ VSEH BOMB PRI NAZATII NA BOMBU
                        {
                           PictureBox pe = (PictureBox)d[u];
                           pe.BackgroundImage = Properties.Resources.bomb;
                        }
                     }
                  }
                  else
                  {
                     
                     if (p >= 6 && p % 6 == 0 && p < 30)
                     { //verh seredina

                        right(p);
                        down(p);
                        left(p);
                        leftdown(p);
                        rightdown(p);
                        
                        swit();
                        swit2();
                     }
                     else if (p == 0)
                     { //levo verh krai
                        down(p);
                        right(p);
                        rightdown(p);
                        
                        swit();
                        swit2();
                     }
                     else if (p == 30) //prav verh
                     {
                        down(p);
                        left(p);
                        leftdown(p);
                        
                        swit();
                        swit2();

                     }
                     else if (p >= 1 && p <= 4) // lev seredina
                     {
                        right(p);
                        up(p);
                        down(p);
                        rightup(p);
                        rightdown(p);
                        
                        swit();
                        swit2();
                     }
                     else if (p == 5) // lev niz
                     {
                        up(p);
                        right(p);
                        rightup(p);
                        
                        swit();
                        swit2();
                     }
                     else if (p == 35) //prav niz
                     {
                        left(p);
                        up(p);
                        leftup(p);
                        
                        swit();
                        swit2();
                     }
                     else if (p % 6 == 5 && p != 5 && p != 35) //niz seredina
                     {
                        right(p);
                        up(p);
                        rightup(p);
                        leftup(p);
                        left(p);
                        
                        swit();
                        swit2();
                     }
                     else if (p <= 34 && p >= 31)
                     {
                        left(p);
                        leftup(p);
                        up(p);
                        leftdown(p);
                        down(p);
                        
                        swit();
                        swit2();
                     }
                     else
                     {
                        left(p);
                        leftup(p);
                        right(p);
                        rightup(p);
                        rightdown(p);
                        up(p);
                        leftdown(p);
                        down(p);
                        
                        swit();
                        swit2();
                     }
                     

                  }
                  //MessageBox.Show(c[p].ToString() + "bomb");
                  //MessageBox.Show(p.ToString());
               }
            }
         }
         else if (e.Button == MouseButtons.Right && gam == true)  //Pravo
         {
            bool test1 = false, test2 = false;
            for (int i = 0; i < field; i++)
            {
               pb2 = sender as PictureBox;
               Point po2 = new Point((int)b[i], (int)a[i]);
               if (po2 == pb2.Location)
               {
                  if ((int)flg[i] % 2 == 0 && Convert.ToInt32(label2.Text) > 0) // stavim flag
                  {
                     test1 = true;
                     f[i] = false;
                     pb2.BackgroundImage = Properties.Resources.flag;
                     if ((int)c[i] == 1)
                     {
                        bmcount++;

                     }
                     label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                  }
                  if ((int)flg[i] % 2 == 1) // ubiraem flag
                  {
                     test2 = true;
                     f[i] = true;
                     pb2.BackgroundImage = Properties.Resources._0;
                     if ((int)c[i] == 1)
                     {
                        bmcount--;

                     }
                     label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                  }
                  if (test1 == true || test2 == true)
                  {
                     flg[i] = flg[i] + 1;
                  }


               }
            }

         }

      }




      public void check()
      {

         for (int i = 0; i < field; i++)
         {
            bom = 0;
            if (i >= 6 && i % 6 == 0 && i < 30)
            { //verh seredina

               right(i);
               down(i);
               left(i);
               leftdown(i);
               rightdown(i);
            }
            else if (i == 0)
            { //levo verh krai
               down(i);
               right(i);
               rightdown(i);
            }
            else if (i == 30) //prav verh
            {
               down(i);
               left(i);
               leftdown(i);
            }
            else if (i >= 1 && i <= 4) // lev seredina
            {
               right(i);
               up(i);
               down(i);
               rightup(i);
               rightdown(i);
            }
            else if (i == 5) // lev niz
            {
               up(i);
               right(i);
               rightup(i);
            }
            else if (i == 35) //prav niz
            {
               left(i);
               up(i);
               leftup(i);
            }
            else if (i % 6 == 5 && i != 5 && i != 35) //niz seredina
            {
               right(i);
               up(i);
               rightup(i);
               leftup(i);
               left(i);
            }
            else if (i <= 34 && i >= 31)
            {
               left(i);
               leftup(i);
               up(i);
               leftdown(i);
               down(i);
            }
            else
            {
               left(i);
               leftup(i);
               right(i);
               rightup(i);
               rightdown(i);
               up(i);
               leftdown(i);
               down(i);
            }
            e.Add(bom);
            //MessageBox.Show(e[i].ToString());

         }
      }
      int tim = 0;
      private void timer1_Tick(object sender, EventArgs e)
      {
         tim++;
         label4.Text = tim.ToString();
      }

      public void leftup(int o)
      {
         if ((int)c[o - 7] == 1)
         {
            bom++;
         }
      }

      public void rightup(int o)
      {
         if ((int)c[o + 5] == 1)
         {
            bom++;
         }
      }

      public void rightdown(int o)
      {
         if ((int)c[o + 7] == 1)
         {
            bom++;
         }
      }

      public void swit()
      {
         switch (bom)
         {
            case 0:
               pb.BackgroundImage = Properties.Resources._null;
               break;
            case 1:
               pb.BackgroundImage = Properties.Resources._1;
               break;
            case 2:
               pb.BackgroundImage = Properties.Resources._2;
               break;
            case 3:
               pb.BackgroundImage = Properties.Resources._3;
               break;
         }
      } //Tam znacheni9 bg i test na "bom"

      public void swit2() //pokaz vseh pustuh kletok
      {
         check();
         for (int t = 0; t < field; t++)
         {
            if ((int)c[t] != 1 && (int)e[t] == 0)
            {

               PictureBox pe2 = (PictureBox)d[t];
               pe2.Location = new Point((int)b[t], (int)a[t]);
               pe2.BackgroundImage = Properties.Resources._null;

            }

         }
      }

      public void load()
      {
         for (int i = 0; i < field; i++)
         {

            if (y != 6 * siz)
            {
               y += siz;
            }
            else
            {
               y = siz;
               x += siz;
            }
            butt(false, i);
         }

         for (int t = 0; t < field; t++)
         {
            if ((int)c[t] == 1)
            {
               num++;
               label2.Text = num.ToString();
            }
         }

      }
   }
}

