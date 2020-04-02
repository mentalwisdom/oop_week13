/*
 * Created by SharpDevelop.
 * User: iot
 * Date: 3/31/2020
 * Time: 1:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace week13
{
	/// <summary>
	/// Description of Product.
	/// </summary>
	public class Product
	{
		public int no;
		public string name;
		public int qty;
		public double price;
		public string image;
		public Product()
		{
		}
		public Product(int no, string name, int qty, double price, string image)
		{
			this.no = no;
			this.name = name;
			this.qty = qty;
			this.price = price;
			this.image = image;
		}
		
	}
}
