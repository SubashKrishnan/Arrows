using System.Configuration;
namespace DataBaseClass
{
    public class Connection
	{
		#region Connection String
		public string GetConnection()
		{
			string strConnectionString = null;
			try
			{
				strConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;    
			}
			finally
			{
			}
			return strConnectionString;
		}
		#endregion
	}
}
