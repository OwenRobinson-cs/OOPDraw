using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nakov.TurtleGraphics;
using System.Collections;

namespace OOPDraw
{
    public abstract class Shape
    {
        //properties 
        protected float XOrigin { get; set; }
        protected float YOrigin { get; set; }

        //The Constructor

        public Shape(float xOrigin, float yOrigin)
        {
            XOrigin = xOrigin;
            YOrigin = yOrigin;
        }

        //Abstract Methods
        public abstract void Draw();

        //Concrete Methods
        public void MoveTo(float x, float y)
        {
            XOrigin = x;
            YOrigin = y;
        }

        protected void ResetTurtle()
        {
            Turtle.ShowTurtle = false;
            Turtle.PenSize = 2;
            Turtle.Angle = 0;
            Turtle.X = XOrigin;
            Turtle.Y = YOrigin;
        }
    }

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private List<Shape> shapes = new List<Shape>();
        
        private Shape mostRecent;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            string selectedItem = (string)comboBox1.SelectedItem;
            float turtleX = e.X - Width / 2 + 8;
            float turtleY = Height / 2 - e.Y - 19;
            if (selectedItem == "Draw Triangle")
            {
                
                var tri = new EquilateralTriangle(turtleX, turtleY, 50);
                shapes.Add(tri);
                tri.Draw();
                mostRecent = tri;
            }
            else if (selectedItem == "Draw Rectangle")
            {
                
                var rec = new Rectangle(turtleX, turtleY, 100, 50);
                shapes.Add(rec);
                rec.Draw();
                mostRecent = rec;
            }
            else if (selectedItem == "Move Shape")
            {
                mostRecent.MoveTo(turtleX, turtleY);
            }
            DrawAll();
        }
        
        public void DrawAll()
        {
            Turtle.Dispose(); //First Clear all Turtle tracks to start afresh
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
        
    }
}


