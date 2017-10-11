using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace udpmeasure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        private const string connectionstring = "Server=tcp:mstempagain.database.windows.net,1433;Initial Catalog=mstempagagin;Persist Security Info=False;User ID=harmans;Password=barcam10@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    public int mesure(int temp, int pot, int analog, int light)
        {
            const string insertmeasure = "insert into [Table] (TEMP , LIGHT, ANALOG , POT) values (@TEMP, @LIGHT , @ANALOG , @POT)";
            using (SqlConnection databaseConnection = new SqlConnection(connectionstring))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertmeasure, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@TEMP", temp);
                    insertCommand.Parameters.AddWithValue("@ANALOG", analog);
                    insertCommand.Parameters.AddWithValue("@LIGHT", light);
                    insertCommand.Parameters.AddWithValue("@POT", pot);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
