/*
 * Created by SharpDevelop.
 * User: andy
 * Date: 4/20/2011
 * Time: 3:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
 using System;

 using System.Collections.Generic;
// using System.Data;
 using System.Windows.Forms;
 using System.Data;
 //using MySql.Data;
using MySql.Data.MySqlClient;

namespace week13
{
	/// <summary>
	/// Description of Manager.
	/// </summary>
	public class DataManager{
		//declaration
		public string dbConnection;
		public DataManager()
		{
			//Create connection string here
			dbConnection = "";
		}
		
		public DataManager(string hostName,string db,string user,string pass){
        	
			dbConnection = String.Format("Server={0};Database={1};uid={2};password={3};Port=3306;",hostName,db,user,pass);
		}
		
		public DataManager(Dictionary<String, String> connectionOpts){
			string str = "";
			foreach (KeyValuePair<String, String> row in connectionOpts){
				str += String.Format("{0}={1}; ", row.Key, row.Value);
			}//end foreach
			 str = str.Trim().Substring(0, str.Length - 1);
			 dbConnection = str;
		}
		
		//GetDataTable
		public DataTable GetDataTable(string sql){
			DataTable dt = new DataTable();
			try{
    	
				MySqlConnection cnn = new MySqlConnection(dbConnection); 	//create connection
				cnn.Open();													//opne connection
				MySqlCommand mycommand = new MySqlCommand();			//create command
				mycommand.Connection = cnn;
				mycommand.CommandText = sql;								//set command
				MySqlDataReader reader = mycommand.ExecuteReader();		//ExecuteReader
				dt.Load(reader);											//load result into table
				reader.Close();												//close command
				cnn.Close();												//close connection
			}
			catch(Exception ex){
 
				throw new Exception(ex.Message);
			}
			return dt;
		}//end GetDataTable
		
		//ExecuteNonQuery
		public int ExecuteNonQuery(string sql){
			MySqlConnection cnn = new MySqlConnection(dbConnection);
			cnn.Open();
			MySqlCommand mycommand = new MySqlCommand();
			mycommand.Connection = cnn;
			mycommand.CommandText = sql;
			int rowsUpdated = mycommand.ExecuteNonQuery();
			cnn.Close();
			return rowsUpdated;
		}//end ExecuteNonQuery
		
		//ExecuteScalar
		public string ExecuteScalar(string sql){
			MySqlConnection cnn = new MySqlConnection(dbConnection);
			
			try{
			 
			cnn.Open();
			MySqlCommand mycommand = new MySqlCommand();
			mycommand.Connection = cnn;
			mycommand.CommandText = sql;
			 
			object value = mycommand.ExecuteScalar();
			if (value != null){
				return value.ToString();
			}
			}catch(Exception ex){
				MessageBox.Show(ex.Message);
			}
			cnn.Close();
			 
			return "";
				
		}//end ExecuteScalar
		
		public MySqlDataReader ExecuteQuery(string sql){
			MySqlDataReader reader;
			MySqlConnection cnn = new MySqlConnection(dbConnection);
			cnn.Open();
			if( cnn.State== ConnectionState.Open){
			
			MySqlCommand mycommand = new MySqlCommand();
			mycommand.Connection = cnn;
			mycommand.CommandText = sql;
			 
			  reader = mycommand.ExecuteReader();
				
			cnn.Close();
			}
			else{
				MessageBox.Show("connection is not open");
				return null;
			}
			 
			return reader;
				
		}//end ExecuteScalar
		//Update
		public bool Update(string tableName, Dictionary<string, string> data, string col,string match){
			String vals = "update " + tableName + " SET  ";
			Boolean returnCode = true;
			if (data.Count >= 1){
				foreach (KeyValuePair<String, String> val in data){
					vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
				}//end foreach
				
				vals = vals.Substring(0, vals.Length - 1);
				
			}//end if
			vals += String.Format(" where {0} = '{1}'",col,match);
			MessageBox.Show(vals);
			try{
				this.ExecuteNonQuery(vals);
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message);
				returnCode = false;
			}
			return returnCode;
		}//end update
			
		//Delete
		public bool Delete(String tableName, String where){
			Boolean returnCode = true;
			try{
				this.ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where));
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message);
				returnCode = false;
			}
			return returnCode;
		}//end delete
		
		//Insert
		public bool InsertMultiple(string tableName,string columns,List<string> value){
			 
			
			string qr;
			Boolean returnCode =true;
			qr = String.Format("insert into {0} ({1}) values ",tableName,columns);
			
			foreach(string v in value){
				qr += String.Format("({0}),",v);
			}
			qr = qr.Substring(0, qr.Length - 1);
			qr +=";";
			MessageBox.Show(qr);
			 try{
			 	 
				this.ExecuteNonQuery(qr);
			 	
			 }catch(Exception ex){
			 	MessageBox.Show(ex.Message);
			 	returnCode= false;
			 }
			  return returnCode;
		}//end Insert
		public bool Insert(string qr){
			 
			
			Boolean returnCode =true;
			MessageBox.Show(qr);
			 try{
			 	 
				this.ExecuteNonQuery(qr);
			 	
			 }catch(Exception ex){
			 	MessageBox.Show(ex.Message);
			 	returnCode= false;
			 }
			  return returnCode;
		}//end Insert
		
				public bool Insert(String tableName, Dictionary<String, String> data){
			 String columns = "";
			 String values = "";
			 Boolean returnCode = true;
			 foreach (KeyValuePair<String, String> val in data){
			 	columns += String.Format(" {0},", val.Key.ToString());
			 	values += String.Format(" '{0}',", val.Value);
			 }
			 
			 columns = columns.Substring(0, columns.Length - 1);
			 values = values.Substring(0, values.Length - 1);
			 MessageBox.Show(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
			 try{
			 	 
			 	this.ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
			 	
			 }catch(Exception ex){
			 	MessageBox.Show(ex.Message);
			 	returnCode = false;
			 }
			  return returnCode;
		}//end Insert
		
		//ClearDb
		public bool ClearDB(){
			DataTable tables;
			try{
				tables = this.GetDataTable("select NAME from SQLITE_MASTER where type='table' order by NAME;");
				foreach (DataRow table in tables.Rows){
					this.ClearTable(table["NAME"].ToString());
				}
				return true;
			}catch{
				return false;
			}
		}//end ClearDB
		
		//ClearTable
		public bool ClearTable(String table){
			try{
				this.ExecuteNonQuery(String.Format("delete from {0};", table));
				return true;
			}catch{
				return false;
			}
		}
		
	}//end class
}//end namespace
