/*
 * Created by SharpDevelop.
 * User: iot
 * Date: 3/31/2020
 * Time: 1:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace week13
{
	/// <summary>
	/// Description of OrderItem.
	/// </summary>
	public class OrderItem
	{
		public int product_no;
		public string product_name;
		public int qty;
		public double price;
		public OrderItem()
		{
		}
		public OrderItem(int product_no, string product_name, int qty, double price)
		{
			this.product_no = product_no;
			this.product_name = product_name;
			this.qty = qty;
			this.price = price;
		}
		
	}
}
