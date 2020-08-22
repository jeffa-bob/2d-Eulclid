using System;
using System.ComponentModel;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;

namespace _2dEulclid.Canvas
{
  public interface LineCircle {
    void Draw();
  }

  public struct Point
  {
    public double? x { get; set; }
    public double? y { get; set; }

    public Point(double? @x = null, double? @y = null)
    {
      this.x = @x;
      this.y = @y;
    }
  }

  public struct Line_equ
  {
    //y = m * x + b 
    public readonly double y;
    public readonly double x;

    public readonly double m;
    public readonly double b;

    public Line_equ(Line line)
    {
      y = (double)line.b.y;
      x = (double)line.b.x;

      m = (double)((line.b.y - line.a.y) / (line.b.x - line.a.x));
      b = (double)(line.a.y - (line.a.x * m));
    }
  }

  public struct Line : LineCircle
  {
    void LineCircle.Draw(object canvas)
    {
      var line = new Windows.UI.Xaml.Shapes.Line()
    }

    public Point a { get; set; }
    public Point b { get; set; }

    public readonly Line_equ? slopeequation;

    public Line(Point @a = new Point(), Point @b = new Point())
    {
      this.a = @a;
      this.b = @b;
      slopeequation = null;
      slopeequation = new Line_equ(this);
    }

    private double det(Point a, Point b)
    {
      return (double)(a.x * b.y - a.y * b.x);
    }

    //returns where two lines intersect
    //null if parallel
    public Point? Lineintersection(Line line1, Line line2)
    {

      Point xdiff = new Point(line1.a.x-line1.b.x, line2.a.x-line2.b.x);
      Point ydiff = new Point(line1.a.y-line1.b.y, line2.a.y-line2.b.y);

      double div = det(xdiff, ydiff);
      if (div == 0)
      {
        return null;
      }

      Point d = new Point(det(line1.a, line1.b), det(line2.a, line2.b));

      double x = det(d, xdiff) / div;
      double y = det(d, ydiff) / div;

      return new Point(x, y);
    }
  }

  public struct Circle : LineCircle
  {
    public Point Center { get; set; }
    public double? radius { get; set; }

    public Circle(Point @center = new Point(), double? @radius = null)
    {
      this.Center = @center;
      this.radius = @radius;
    }
  }

  public class CurCanvas
  {
    object canvas;

    List<LineCircle> Canvas = new List<LineCircle>();
  }
}
