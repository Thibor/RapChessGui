using System;
using System.Drawing;

namespace NSRapColor
{
	public static class CRapColor
	{
		public static int R = 0;
		public static int G = 0;
		public static int B = 0;
		public static double H = 0;
		public static double L = 0;
		public static double S = 0;
		public static Color color = Color.Black;

		public static void RgbToHsl(int r, int g, int b,
			out double h, out double s, out double l)
		{
			double double_r = r / 255.0;
			double double_g = g / 255.0;
			double double_b = b / 255.0;
			double max = double_r;
			if (max < double_g) max = double_g;
			if (max < double_b) max = double_b;

			double min = double_r;
			if (min > double_g) min = double_g;
			if (min > double_b) min = double_b;

			double diff = max - min;
			l = (max + min) / 2;
			if (Math.Abs(diff) < 0.00001)
			{
				s = 0;
				h = 0;
			}
			else
			{
				if (l <= 0.5) s = diff / (max + min);
				else s = diff / (2 - max - min);
				double r_dist = (max - double_r) / diff;
				double g_dist = (max - double_g) / diff;
				double b_dist = (max - double_b) / diff;
				if (double_r == max) h = b_dist - g_dist;
				else if (double_g == max) h = 2 + r_dist - b_dist;
				else h = 4 + g_dist - r_dist;
				h *= 60;
				if (h < 0) h += 360;
			}
		}

		public static void HslToRgb(double h, double s, double l,
			out int r, out int g, out int b)
		{
			double p2;
			if (l <= 0.5) p2 = l * (1 + s);
			else p2 = l + s - l * s;

			double p1 = 2 * l - p2;
			double double_r, double_g, double_b;
			if (s == 0)
			{
				double_r = l;
				double_g = l;
				double_b = l;
			}
			else
			{
				double_r = QqhToRgb(p1, p2, h + 120);
				double_g = QqhToRgb(p1, p2, h);
				double_b = QqhToRgb(p1, p2, h - 120);
			}
			r = (int)(double_r * 255.0);
			g = (int)(double_g * 255.0);
			b = (int)(double_b * 255.0);
		}

		private static double QqhToRgb(double q1, double q2, double hue)
		{
			if (hue > 360) hue -= 360;
			else if (hue < 0) hue += 360;
			if (hue < 60) return q1 + (q2 - q1) * hue / 60;
			if (hue < 180) return q2;
			if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
			return q1;
		}

		public static void SetColor(Color c)
		{
			color = c;
			R = color.R;
			G = color.G;
			B = color.B;
			RgbToHsl(R, G, B, out H, out S, out L);
		}

		public static Color GetColor(double h, double s, double l)
		{
			HslToRgb(h, s, l, out int r, out int g, out int b);
			return Color.FromArgb(r, g, b);
		}

	}
}
