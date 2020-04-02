/*
 * Created by SharpDevelop.
 * User: iot
 * Date: 3/31/2020
 * Time: 12:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
namespace week13
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		DataManager m1 = new DataManager("localhost","week13","root","");
		
		List<Product> products = new List<Product>();
		List<OrderItem> orderItems = new List<OrderItem>();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			//get product information from the database server using m1
			string sql = "select * from product";
			DataTable table1= m1.GetDataTable(sql);
			foreach(DataRow r in table1.Rows){
				int no 			= int.Parse(r[0].ToString());
				string name 	=	r[1].ToString();
				int qty 		= int.Parse(r[2].ToString());
				double price 	= double.Parse(r[3].ToString());
				string image 	= 	r[4].ToString();
					
				products.Add(new Product(no,name,qty,price,image));
				
				//special ui = text title + button with image
				Panel m = menu(name,image,200,150);
				panel1.Controls.Add(m);
			}
			
		}//ef
		
		private string getPath(){
			return Path.GetDirectoryName(Application.ExecutablePath)+"\\images\\";
		}
		
		
		//a special function to create a button + title
		private Panel menu(string name,string image,int width,int height){
			FlowLayoutPanel p = new FlowLayoutPanel();
			//p.FlowDirection = FlowDirection.TopDown;
			p.Height = height+25+5;
			p.Width = width;
			Label l1 = new Label();
			
			l1.Text = name;
			l1.Width= width;
			l1.Height = 25;
			
			p.Controls.Add(l1);
			Button b1 = new Button();
			b1.Tag = name;
			b1.ForeColor = Color.White;
			b1.BackgroundImage = System.Drawing.Image.FromFile(getPath()+image);
			b1.BackgroundImageLayout = ImageLayout.Stretch;
			b1.Width=width;
			b1.Height=height;
			b1.Margin= new Padding(10);
			p.Controls.Add(b1);
			b1.Click += new EventHandler(this.MenuClick);
			
			return p;
		}
		private void MenuClick(Object sender,EventArgs arg){
			Button b = (Button)sender;
			
			var search_name = b.Tag.ToString();
		    //use the searchname to search product object from products collecion
		    Product found = products.Find(x=>x.name== search_name);
		 	
		    //search the name in orderitems as well
		    OrderItem found2 = orderItems.Find(x=>x.product_name == search_name);
		    if(found2 == null){
		    	 OrderItem new_order_item = new OrderItem(found.no,
		                                             found.name,
		                                             1,
		                                             found.price);
		   		 orderItems.Add(new_order_item);
		    	
		    }
		    else{
		    	found2.qty +=1;
		    }
		    
		    updateListView();
		}//ef
		
		private void updateListView(){
			//loop through order items in the orderitems list
			//and then populate/fill the listview 
			int count = 1;
			listView1.Items.Clear();//clear all rows in the listview
			double grand_total = 0;
			foreach(OrderItem o in orderItems){
				//create a new row in the listview
				string description = o.product_name + " (" +
					o.qty.ToString() + "x" + o.price.ToString() + ")";
				double total = o.price*o.qty;
				grand_total += total;
				//create a new row
				ListViewItem row = new ListViewItem(count.ToString());
				row.SubItems.Add(description);
				row.SubItems.Add(total.ToString());
				//add the new row into listview
				listView1.Items.Add(row);
			}//eloop
			lblGrandTotal.Text = grand_total.ToString();
		}//ef
	}//ec
}//en
