using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static Dcoder.Printer;
/*[Author]: Cambo2015
/* Liscense : MIT
/*[Double Check Equation Here] https://www.chilimath.com/lessons/intermediate-algebra/solving-quadratic-equations-quadratic-formula/*/
 namespace MathFormulas
 {
 	public class Program
 	{
 		public static void Main(string[] args)
 		{
 			
 			var quad = new QuadradicFormula(1,5,-14);
 			var q = quad.Calculate();
 			p(q.a);
 			p(q.b);
 			var calc = new Calculator();
 			calc.AddCalculation((IThreeInput)quad);
 			calc.Calculate();
 		}
 	}
 	
 	public class Calculator
 	{
 		List<IThreeInput> formulas = new List<IThreeInput>();
 		public void AddCalculation(IThreeInput calc)
 		{
 			formulas.Add(calc);
 		}
 		
 		public void Calculate()
 		{
 			foreach(var c in formulas  )
 			{
 				//double v;
 				//var temp = c ;
 				double d = GetAns(c);
 			}
 		}
 		
 		private double GetAns(IThreeInput c)
 		{
 			if(c is ITwoResult)
 			{
 				return ((ITwoResult)c).Calculate().a;
 			}
 			return ((IOneResult)c).Calculate();
 		}
 	}
 	
 	public class QuadradicFormula :IThreeInput,ITwoResult
 	{
 		private float a,b,c;
 		public float A{get{return a;}}
 		public float B{get{return b;}}
 		public float C{
 			get{
 				return a;
 			}
 		}
 		
 		public QuadradicFormula(float a,float b,float c)
 		{
 			this.a = a;
 			this.b = b;
 			this.c = c;
 		}
 		
 		public (double a,double b) Calculate()
 		{
 			return ((-b+Math.Sqrt(b*b-4*a*c))/(2*a), (-b-Math.Sqrt(b*b-4*a*c))/(2*a));
 		}
 	}
 	
 	public class Normalize : ITwoInput, ITwoResult
 	{
 		private float a,b;
 		public float A
 		{
 			get{return a;}
 		}
 		public float B
 		{
 			get{
 				return b;
 			}
 		}
 		
 		public (double a,double b) Calculate()
 		{
 			var mag = new PagTheorm(a,b);
 			a /= mag.Calculate();
 			b/= mag.Calculate();
 			return (a,b);
 		}
 	}
 	
 	public class PagTheorm :IOneResult,IThreeInput
 	{
 		
 		private float a,b,c;
 		public float A{get{return a;}}
 		public float B{get{return b;}}
 		public float C{get{return a;}}
 		
 		public PagTheorm(float a,float b,float c)
 		{
 			this.a = a;
 			this.b = b;
 			this.c = c;
 		}
 		public double Calculate()
 		{
 			return Math.Sqrt(a*a+b*b+c*c);
 		}
 	}
 	
 	public static class Printer
 	{
 		public static void p<T>(T n)
 		{
 			Console.WriteLine( n);
 		}
 	}
 	
 	public interface IOneResult
 	{
 		double Calculate();
 	}
 	
 	public interface ITwoResult
 	{
 		(double a,double b) Calculate();
 	}
 	
 	public interface IThreeInput
 	{
 		float A{
 			get;
 		}
 		float B{
 			 get;
 		}
 		float C{
 			 get;
 		}
 	}
 	
 	public interface ITwoInput
 	{
 		float A{
 			get;
 		}
 		float B{
 			 get;
 		}
 	}
 }
