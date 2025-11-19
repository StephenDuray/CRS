using CarRentalsSystem.WindowsForm;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.Database
{
    public class dbQuery
    {
        private static MySqlConnection Connection => dbConnection.Instance.Connection;

        public static bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";
            using (var cmd = new MySqlCommand(query, Connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        // Add Customer
        public static int AddCustomer(string name, DateTime dob, string gender, string address, string licenseNo)

        {
            // IMPORTANT: Ensure 'customers' table in MySQL has 'licenseNo' as VARCHAR and 'id' as AUTO_INCREMENT.
            string addCustomerQuery = "INSERT INTO customer (name, dob, gender, address, licenseNo) " +
                                      "VALUES (@name, @dob, @gender, @address, @licenseNo); " +
                                      "SELECT LAST_INSERT_ID();"; // Get the ID of the newly inserted row

            using (MySqlCommand cmd = new MySqlCommand(addCustomerQuery, Connection)) // Use 'Connection' or Instance.Connection
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@licenseNo", licenseNo); // Pass the string licenseNo

                try
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result); // Return the newly generated customer ID
                    }
                    return -1; // Indicate failure (or throw specific exception)
                }
                catch (MySqlException mex)
                {
                    // Handle specific database errors, e.g., duplicate license number if that's unique
                    // if (mex.Number == 1062) { throw new Exception("A customer with this license number already exists.", mex); }
                    throw new Exception("Database error while adding customer: " + mex.Message, mex);
                }
            }
        }
        // Add Vehicle
        public static bool AddVehicle(string brand, string model, string vehicleType, string status, string color, double dailyRate, int currentMileage, byte[] vehicleImage, string plateNo)
        {
            string query = @" INSERT INTO vehicle (brand, model, vehicleType,status, color, dailyRate, currentMileage, vehicleImage,plateNo)VALUES (@brand, @model, @vehicleType,@status, @color, @dailyRate, @currentMileage, @vehicleImage,@plateNo);
    ";

            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                cmd.Parameters.Add("@brand", MySqlDbType.VarChar).Value = brand;
                cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = model;
                cmd.Parameters.Add("@vehicleType", MySqlDbType.VarChar).Value = vehicleType;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@color", MySqlDbType.VarChar).Value = color;
                cmd.Parameters.Add("@dailyRate", MySqlDbType.Double).Value = dailyRate;
                cmd.Parameters.Add("@currentMileage", MySqlDbType.Int32).Value = currentMileage;

                // IMAGE
                cmd.Parameters.Add("@vehicleImage", MySqlDbType.LongBlob).Value = (object)vehicleImage ?? DBNull.Value;
                cmd.Parameters.Add("@plateNo", MySqlDbType.VarChar).Value = plateNo;

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //Get Contact
        public static bool AddContact(string contactNo, string email, int? customerId)
        {
            string addContact = "INSERT INTO contact (contactNo, email, customerId) " +
                                "VALUES (@contactNo, @email, @customerId)";
            using (MySqlCommand cmd = new MySqlCommand(addContact, Connection))
            {
                cmd.Parameters.AddWithValue("@contactNo", string.IsNullOrEmpty(contactNo) ? (object)DBNull.Value : contactNo);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@customerId", customerId.HasValue ? (object)customerId.Value : DBNull.Value);
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException mex)
                {
                    throw new Exception("Database error: " + mex.Message, mex);
                }
            }
        }
        //Get total Vehicle
        public static int GetTotalVehicles()
        {
            string query = "SELECT COUNT(*) FROM vehicle";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                try
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
                catch (MySqlException mex)
                {
                    throw new Exception("Database error while getting total vehicles: " + mex.Message, mex);
                }
            }
        }

        // Get total customers
        public static int GetTotalCustomers()
        {
            string query = "SELECT COUNT(*) FROM customer";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                try
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
                catch (MySqlException mex)
                {
                    throw new Exception("Database error while getting total customers: " + mex.Message, mex);
                }
            }
        }

        // Get available vehicles (status = 'Available')
        public static int GetAvailableVehicles()
        {
            string query = "SELECT COUNT(*) FROM vehicle WHERE status = 'Available'";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                try
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
                catch (MySqlException mex)
                {
                    throw new Exception("Database error while getting available vehicles: " + mex.Message, mex);
                }
            }
        }
        public static DataTable GetAllVehiclesForGallery()
        {
            string sql = @"
                SELECT vehicleID, brand, model, vehicleImage
                FROM vehicle";
            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
            {
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        // Get rented vehicles (status = 'Rented')
        public static int GetRentedVehicles()
        {
            string query = "SELECT COUNT(*) FROM vehicle WHERE status = 'Rented'";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                try
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
                catch (MySqlException mex)
                {
                    throw new Exception("Database error while getting rented vehicles: " + mex.Message, mex);
                }
            }
        }
        //checker for license
        public static bool LicenseExists(string licenseNo)
        {
            string query = "SELECT COUNT(*) FROM customer WHERE licenseNo = @licenseNo";

            using (var cmd = new MySqlCommand(query, dbConnection.Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@licenseNo", licenseNo);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        //Search Customer
        public static DataTable SearchCustomers(string keyword)
        {
            string sql = @"
                    SELECT customerID, name, dob, gender, address, licenseNo
                    FROM customer
                    WHERE name LIKE @kw
                       OR licenseNo LIKE @kw
                       OR address LIKE @kw
                    ORDER BY customerID DESC;";


            using (var cmd = new MySqlCommand(sql, Connection))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //Update Customer 
        public static bool UpdateCustomer(int customerId, string name, DateTime dob, string gender, string address, string licenseNo)
        {
            const string sql = @"
                UPDATE customer
                SET    name      = @name,
                       dob       = @dob,
                       gender    = @gender,
                       address   = @address,
                       licenseNo = @licenseNo
                WHERE  customerID = @id";

            using (var cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.AddWithValue("@id", customerId);
                cmd.Parameters.AddWithValue("@name", name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@gender", gender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@address", address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@licenseNo", licenseNo ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() == 1;
            }
        }
        //UpdateContract
        public static bool UpdateContractDates(
               int contractId,
               DateTime bookingDate,
               DateTime expectedReturnDate,
               DateTime? actualReturnDate)
        {
            string sql = @"
                    UPDATE contracts
                       SET bookingDate       = @booking,
                           expectedReturnDate = @expected,
                           actualReturnDate   = @actual
                     WHERE contractID        = @id;";

            using (var cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.AddWithValue("@booking", bookingDate);
                cmd.Parameters.AddWithValue("@expected", expectedReturnDate);
                cmd.Parameters.AddWithValue("@id", contractId);

                if (actualReturnDate.HasValue)
                    cmd.Parameters.AddWithValue("@actual", actualReturnDate.Value);
                else
                    cmd.Parameters.AddWithValue("@actual", DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //GetCustomerNameByID
        public static string GetCustomerNameById(int customerId)
        {
            string query = "SELECT name FROM customer WHERE customerID = @id LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                cmd.Parameters.AddWithValue("@id", customerId);

                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
        }
        //GetCustoemrIdBynName
        public static int GetCustomerIdByName(string name)
        {
            string query = "SELECT customerID FROM customer WHERE name = @name LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                cmd.Parameters.AddWithValue("@name", name);

                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : -1;
            }
        }
        //Rental Policies for ComboxBox
        //public static DataTable GetRentalPolicies()
        //{
        //    string query = "SELECT rentalpolicyID, policyName FROM rentalpolicy ORDER BY policyName";

        //    using (var da = new MySqlDataAdapter(query, Connection))
        //    {
        //        var dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}

        // ---- Users for ComboBox2 ----
        public static DataTable GetUsers()
        {
            // column name 'username' is from your login query
            string query = "SELECT userID, name FROM user ORDER BY name";

            using (var da = new MySqlDataAdapter(query, Connection))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //Add Contract
        public static bool AddContract(int customerID, int userID, int policyID, DateTime bookingDate, DateTime expectedReturnDate, DateTime? actualReturnDate)
        {
            string query = @"INSERT INTO contracts(customerID, userID, policyID, bookingDate, expectedReturnDate, actualReturnDate)VALUES(@customerID, @userID, @policyID, @bookingDate, @expectedReturnDate, @actualReturnDate)";

            using (var cmd = new MySqlCommand(query, dbConnection.Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@customerID", customerID);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@policyID", policyID);
                cmd.Parameters.AddWithValue("@bookingDate", bookingDate);
                cmd.Parameters.AddWithValue("@expectedReturnDate", expectedReturnDate);

                // ❗ IMPORTANT: send DBNull.Value when it's null
                if (actualReturnDate.HasValue)
                    cmd.Parameters.AddWithValue("@actualReturnDate", actualReturnDate.Value);
                else
                    cmd.Parameters.AddWithValue("@actualReturnDate", DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static DataTable GetContracts()
        {
            string sql = @"
                SELECT 
                    c.contractID,
                    c.customerID,
                    cu.name AS CustomerName,
                    c.bookingDate,
                    c.expectedReturnDate,
                    c.actualReturnDate,

                    c.policyID,
                    rp.policyname AS PolicyName,

                    u.name AS User
                FROM contracts c
                JOIN customer cu           ON cu.customerID = c.customerID
                JOIN rentalpolicy rp       ON rp.rentalpolicyID = c.policyID
                JOIN `user` u              ON u.userID = c.userID
                ORDER BY c.contractID DESC;
            ";


            using (var cmd = new MySqlCommand(sql, Connection))
            using (var da = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool UpdateContractPolicy(int contractId, int policyId)
        {
            string sql = @"UPDATE contracts 
                   SET policyID = @policyID 
                   WHERE contractID = @contractID";

            using (var cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.AddWithValue("@policyID", policyId);
                cmd.Parameters.AddWithValue("@contractID", contractId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static DataTable GetRentalPolicies()
        {
            string sql = "SELECT rentalpolicyID, policyname FROM rentalpolicy";

            using (var cmd = new MySqlCommand(sql, Connection))
            using (var da = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static DataRow GetContractBasicInfo(int contractId)
        {
            string sql = @"
            SELECT 
                c.contractID,
                cu.name       AS CustomerName,
                rp.policyname AS PolicyName
            FROM contracts c
            JOIN customer       cu ON cu.customerID      = c.customerID
            JOIN rentalpolicy rp ON rp.rentalpolicyID  = c.policyID
            WHERE c.contractID = @contractID;
        ";

            using (var cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.AddWithValue("@contractID", contractId);

                using (var da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                        return null;          // no such contract

                    return dt.Rows[0];        // first (and only) row
                }
            }
        }
        public static DataTable GetAvailableVehiclesForGallery()
        {
            string sql = @"
        SELECT 
            vehicleID,
            brand,
            model,
            vehicleType,
            plateNo,
            color,
            dailyRate,
            currentMileage,
            status,
            vehicleImage   -- BLOB, can be NULL
        FROM vehicle
        WHERE status = 'Available';";

            using (var cmd = new MySqlCommand(sql, Connection))
            using (var da = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static bool AddRentedVehicle(
                int contractId,
                int vehicleId,
                int? odometerStart,
                int? mileageAllowance)
        {
            // Adjust table/column names if different in your DB
            string sql = @"
                INSERT INTO RentedVehicles
                    (contractID, vehicleID, odometerStart, odometerEnd, mileageAllowance, totalCost)
                VALUES
                    (@contractID, @vehicleID, @odometerStart, NULL, @mileageAllowance, NULL);
            ";

            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.Add("@contractID", MySqlDbType.Int32).Value = contractId;
                cmd.Parameters.Add("@vehicleID", MySqlDbType.Int32).Value = vehicleId;

                cmd.Parameters.Add("@odometerStart", MySqlDbType.Int32).Value =
                    (object)odometerStart ?? DBNull.Value;

                cmd.Parameters.Add("@mileageAllowance", MySqlDbType.Int32).Value =
                    (object)mileageAllowance ?? DBNull.Value;

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool RentedVehicleExists(int contractId, int vehicleId)
        {
            string sql = @"SELECT COUNT(*) FROM RentedVehicles
                   WHERE contractID = @contractID AND vehicleID = @vehicleID";

            using (var cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.Add("@contractID", MySqlDbType.Int32).Value = contractId;
                cmd.Parameters.Add("@vehicleID", MySqlDbType.Int32).Value = vehicleId;

                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
       public static bool AddPayment(int contractId, double amount, DateTime paymentDate, string paymentMethod)
{
    string query = @"INSERT INTO payment(contractID, amount, paymentDate, paymentMethod) 
                     VALUES(@contractID, @amount, @paymentDate, @paymentMethod)";

    using (MySqlCommand cmd = new MySqlCommand(query, Connection))
    {
        cmd.Parameters.Add("@contractID", MySqlDbType.Int32).Value = contractId;   // match name
        cmd.Parameters.Add("@amount", MySqlDbType.Double).Value = amount;
        cmd.Parameters.Add("@paymentDate", MySqlDbType.Date).Value = paymentDate;
        cmd.Parameters.Add("@paymentMethod", MySqlDbType.VarChar).Value = paymentMethod; // correct value

        return cmd.ExecuteNonQuery() > 0;
    }
}

        //public static double GetFullToFullTotal(int contractId)
        //{
        //    const string sql = @"
        //            SELECT 
        //                v.dailyRate,
        //                DATEDIFF(
        //                    COALESCE(c.actualReturnDate, c.expectedReturnDate),
        //                    c.bookingDate
        //                ) + 1 AS daysCount
        //            FROM contracts c
        //            JOIN rentedvehicles rv ON rv.contractID = c.contractID
        //            JOIN vehicle v         ON v.vehicleID = rv.vehicleID
        //            JOIN rentalpolicy rp   ON rp.rentalpolicyID = c.policyID
        //            WHERE c.contractID = @contractID
        //              AND rp.policyName = 'Full to Full'
        //            LIMIT 1;
        //        ";

        //    using (var cmd = new MySqlCommand(sql, Connection))
        //    {
        //        cmd.Parameters.Add("@contractID", MySqlDbType.Int32).Value = contractId;

        //        using (var rdr = cmd.ExecuteReader())
        //        {
        //            if (!rdr.Read())
        //            {
        //                // not a Full to Full contract or no row found
        //                return 0;
        //            }

        //            double dailyRate = rdr.GetDouble(rdr.GetOrdinal("dailyRate"));
        //            int days = rdr.GetInt32(rdr.GetOrdinal("daysCount"));

        //            return dailyRate * days;
        //        }
        //    }
        //}
        public static double GetFullToFullTotal(int contractId)
        {
            const string sql = @"
        SELECT 
            SUM(
                v.dailyRate * 
                (DATEDIFF(
                    COALESCE(c.actualReturnDate, c.expectedReturnDate),
                    c.bookingDate
                ) + 1)
            ) AS totalAmount
        FROM contracts c
        JOIN rentedvehicles rv ON rv.contractID = c.contractID
        JOIN vehicle v         ON v.vehicleID   = rv.vehicleID
        JOIN rentalpolicy rp   ON rp.rentalpolicyID = c.policyID
        WHERE c.contractID = @contractID
          AND rp.policyname = 'Full to Full';";

            using (var cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.Add("@contractID", MySqlDbType.Int32).Value = contractId;

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToDouble(result);
            }
        }

        public static bool ContractHasAssignedVehicle(int contractId)
        {
            // Use your real table name - here I used RentedVehicles like in AddRentedVehicle
            string sql = @"
        SELECT COUNT(*) 
        FROM RentedVehicles
        WHERE contractID = @contractID";

            using (var cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.Add("@contractID", MySqlDbType.Int32).Value = contractId;

                object result = cmd.ExecuteScalar();
                int count = (result != null && result != DBNull.Value)
                            ? Convert.ToInt32(result)
                            : 0;

                return count > 0;
            }
        }
        public static bool ContractHasPayment(int contractId)
        {
            string sql = @"SELECT COUNT(*) 
                   FROM payment
                   WHERE contractID = @contractID";

            using (var cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.Add("@contractID", MySqlDbType.Int32).Value = contractId;

                object result = cmd.ExecuteScalar();
                int count = (result != null && result != DBNull.Value)
                            ? Convert.ToInt32(result)
                            : 0;

                return count > 0;   // true = already has at least one payment
            }
        }
        public static bool UpdateVehicleStatus(int vehicleId, string newStatus)
        {
            string sql = @"UPDATE vehicle
                   SET status = @status
                   WHERE vehicleID = @vehicleID";

            using (var cmd = new MySqlCommand(sql, Connection))
            {
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = newStatus;
                cmd.Parameters.Add("@vehicleID", MySqlDbType.Int32).Value = vehicleId;

                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
