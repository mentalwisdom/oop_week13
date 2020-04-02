/*
 * Created by SharpDevelop.
 * User: iot
 * Date: 3/31/2020
 * Time: 12:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace week13
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdOrder = new System.Windows.Forms.Button();
			this.lblGrandTotal = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdOrder);
			this.groupBox1.Controls.Add(this.lblGrandTotal);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.listView1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(375, 388);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Order Information";
			// 
			// cmdOrder
			// 
			this.cmdOrder.Location = new System.Drawing.Point(26, 327);
			this.cmdOrder.Name = "cmdOrder";
			this.cmdOrder.Size = new System.Drawing.Size(97, 34);
			this.cmdOrder.TabIndex = 3;
			this.cmdOrder.Text = "order";
			this.cmdOrder.UseVisualStyleBackColor = true;
			// 
			// lblGrandTotal
			// 
			this.lblGrandTotal.ForeColor = System.Drawing.Color.Blue;
			this.lblGrandTotal.Location = new System.Drawing.Point(251, 333);
			this.lblGrandTotal.Name = "lblGrandTotal";
			this.lblGrandTotal.Size = new System.Drawing.Size(87, 29);
			this.lblGrandTotal.TabIndex = 2;
			this.lblGrandTotal.Text = "0";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(133, 333);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Grand total:";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.listView1.Location = new System.Drawing.Point(26, 46);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(331, 261);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "no";
			this.columnHeader1.Width = 38;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "description";
			this.columnHeader2.Width = 218;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "total";
			this.columnHeader3.Width = 210;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Location = new System.Drawing.Point(405, 21);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(480, 379);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Product Information";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(18, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(462, 310);
			this.panel1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(916, 484);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "MainForm";
			this.Text = "week13";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblGrandTotal;
		private System.Windows.Forms.FlowLayoutPanel panel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdOrder;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
