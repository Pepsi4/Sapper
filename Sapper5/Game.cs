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
      public int x = 90, y = 0, r = 0, bom = 0, num = 0;
      ArrayList a = new ArrayList();   //y
      ArrayList b = new ArrayList();   //x
      ArrayList c = new ArrayList();   // bomb
      ArrayList d = new ArrayList();   //pict box (bu)
      ArrayList e = new ArrayList();   //
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

      private void button1_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)  //levo
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
                     }
                     else if (p == 0)
                     { //levo verh krai
                        down(p);
                        right(p);
                        rightdown(p);
                        swit();
                     }
                     else if (p == 30) //prav verh
                     {
                        down(p);
                        left(p);
                        leftdown(p);
                        swit();
                     }
                     else if (p >= 1 && p <= 4) // lev seredina
                     {
                        right(p);
                        up(p);
                        down(p);
                        rightup(p);
                        rightdown(p);
                        swit();
                     }
                     else if (p == 5) // lev niz
                     {
                        up(p);
                        right(p);
                        rightup(p);
                        swit();
                     }
                     else if (p == 35) //prav niz
                     {
                        left(p);
                        up(p);
                        leftup(p);
                        swit();
                     }
                     else if (p % 6 == 5 && p != 5 && p != 35) //niz seredina
                     {
                        right(p);
                        up(p);
                        rightup(p);
                        leftup(p);
                        left(p);
                        swit();
                     }
                     else if (p <= 34 && p >= 31)
                     {
                        left(p);
                        leftup(p);
                        up(p);
                        leftdown(p);
                        down(p);
                        swit();
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
                     }

                  }
                  //MessageBox.Show(c[p].ToString() + "bomb");
                  //MessageBox.Show(p.ToString());
               }
            }
         }
         else if (e.Button == MouseButtons.Right)  //Pravo
         {

         }

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
         //for (int i = 0; i < field; i++)
         //{
         //   //pb2 = sender as PictureBox;
         //   left(i);
         //   leftup(i);
         //   right(i);
         //   rightup(i);
         //   rightdown(i);
         //   up(i);
         //   leftdown(i);
         //   down(i);
         //}

         if (bom == 0)
         {
            for (int i = 0; i < field; i++)
            {

            }
         }

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
               textBox1.Text = num.ToString();
            }
         }

      }
   }
}

