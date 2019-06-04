using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TAS_Group4_WebApplication.Models;

namespace TAS_Group4_WebApplication.Controllers
{
    public class ReportController : Controller
    {
       
        

        // *******************************************************
        // *******************************************************
        //  GLOBAL GODFATHER
        // *******************************************************
        // *******************************************************

    

        string[] Ref = new string[] { "101", "102", "201", "401", "501", "502", "503", "504", "505" };

        // Reference Godfather
        // *******************************************************
        //101 = Account Receivable
        //102 = Assets (Inventory & Cash)
        //201 = Account Payable
        //401 = Revenue
        //501 = COGS
        //502 = Depreciation Expense of Gas Dispenser Machines
        //503 = Accumulated Depreciation of Gas Dispenser Machines
        //504 = Salaries and Wages Expense
        //505 = Utilities Expense
        // *******************************************************


        [HttpGet]
        // GET: Journal Transaction
        // Fix Please
        public ActionResult JournalTransaction(int id)
        {
            IList<getData> Journal_Transaction_ID = new List<getData>();
            IList<getData> Journal_Date = new List<getData>();
            IList<getData> Journal_Explanation = new List<getData>();
            IList<getData> Journal_CustomerID = new List<getData>();
            IList<getData> Journal_Price_Amount = new List<getData>();
            IList<getData> Journal_Cost_Amount = new List<getData>();
            IList<getData> Journal_Type = new List<getData>();
            IList<getData> Journal_Ref = new List<getData>();

            IList<getData> Depre_Explanation = new List<getData>();
            IList<getData> Depre_Expense = new List<getData>();

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    LOG-IN SESSION                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Session["status"] = id;
            ViewData["status"] = Session["status"];

            var i = 0; // Ref. counter

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #1                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 1 
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "inc382.database.windows.net";
            builder.UserID = "inc382";
            builder.Password = "INC@kmutt";
            builder.InitialCatalog = "inc382_group_4";

            using (SqlConnection connection = new
                SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM dbo.journal_info");

                String sql = sb.ToString();

                SqlCommand command = new SqlCommand(sql, connection);

                // Query Godfather
                command.CommandText = "SELECT transaction_id, date, explanation, price_amount, cost_amount, type " +
                                        "FROM dbo.journal_info  ";


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    

                    Journal_Transaction_ID.Add(new getData() { Value = Convert.ToString(reader.GetValue(0)) });
                    Journal_Date.Add(new getData() { Value = Convert.ToString(reader.GetValue(1)) });
                    Journal_Explanation.Add(new getData() { Value = Convert.ToString(reader.GetValue(2)) });
                    Journal_Price_Amount.Add(new getData() { Value = Convert.ToString(reader.GetValue(3)) });
                    Journal_Cost_Amount.Add(new getData() { Value = Convert.ToString(reader.GetValue(4)) });
                    Journal_Type.Add(new getData() { Value = Convert.ToString(reader.GetValue(5)) });

                    if(Journal_Explanation[i].Value.Contains("Account receiveable") == true){Journal_Ref.Add(new getData() { Value = Ref[0] });}
                    else if (Journal_Explanation[i].Value.Contains("Inventory") || Journal_Explanation[i].Value.Contains("Cash")  == true) { Journal_Ref.Add(new getData() { Value = Ref[1] }); }
                    else if (Journal_Explanation[i].Value.Contains("Account payable") == true) { Journal_Ref.Add(new getData() { Value = Ref[2] }); }
                    else if (Journal_Explanation[i].Value.Contains("Revenue") == true) { Journal_Ref.Add(new getData() { Value = Ref[3] }); }
                    else if (Journal_Explanation[i].Value.Contains("COGS") == true) { Journal_Ref.Add(new getData() { Value = Ref[4] }); }
                    else if (Journal_Explanation[i].Value.Contains("Depreciation Expense") == true) { Journal_Ref.Add(new getData() { Value = Ref[5] }); }
                    else if (Journal_Explanation[i].Value.Contains("Accumulated Depreciation") == true) { Journal_Ref.Add(new getData() { Value = Ref[6] }); }
                    else if (Journal_Explanation[i].Value.Contains("Saleries and Wages") == true) { Journal_Ref.Add(new getData() { Value = Ref[7] }); }
                    else if (Journal_Explanation[i].Value.Contains("Utilities Expense") == true) { Journal_Ref.Add(new getData() { Value = Ref[8] }); }

                    //Debug.WriteLine(Journal_Explanation[i].Value.ToString());

                    i++;

                }
                i = 0; // clear

                ViewData["JOURNAL_TRANSACTION_ID"] = Journal_Transaction_ID;
                ViewData["JOURNAL_DATE"] = Journal_Date;
                ViewData["JOURNAL_EXPLANATION"] = Journal_Explanation;
                ViewData["JOURNAL_REF"] = Journal_Ref;
                ViewData["JOURNAL_PRICE_AMOUNT"] = Journal_Price_Amount;
                ViewData["JOURNAL_COST_AMOUNT"] = Journal_Cost_Amount;
                ViewData["JOURNAL_TYPE"] = Journal_Type;


                connection.Close();
            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #2                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 2 
            SqlConnectionStringBuilder builder2 = new SqlConnectionStringBuilder();
            builder2.DataSource = "inc382.database.windows.net";
            builder2.UserID = "inc382";
            builder2.Password = "INC@kmutt";
            builder2.InitialCatalog = "inc382_group_4";

            using (SqlConnection connection2 = new
                SqlConnection(builder2.ConnectionString))
            {
                connection2.Open();
                StringBuilder sb2 = new StringBuilder();
                //StringBuilder sb_2 = new StringBuilder();


                sb2.Append("SELECT * FROM dbo.purchase_order_info");


                String sql2 = sb2.ToString();
                //String sql_2 = sb_2.ToString();

                SqlCommand command2 = new SqlCommand(sql2, connection2);


                // Query Godfather
                command2.CommandText = "SELECT customer_id " +
                                        "FROM dbo.purchase_order_info  ";


                SqlDataReader reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    Journal_CustomerID.Add(new getData() { Value = Convert.ToString(reader2.GetValue(0)) });
                }

                ViewData["JOURNAL_CUSTOMER_ID"] = Journal_CustomerID;

                connection2.Close();

            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #3                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 3 
            SqlConnectionStringBuilder builder3 = new SqlConnectionStringBuilder();
            builder3.DataSource = "inc382.database.windows.net";
            builder3.UserID = "inc382";
            builder3.Password = "INC@kmutt";
            builder3.InitialCatalog = "inc382_group_4";

            using (SqlConnection connection3 = new
                SqlConnection(builder3.ConnectionString))
            {
                connection3.Open();
                StringBuilder sb3 = new StringBuilder();
                //StringBuilder sb_3 = new StringBuilder();


                sb3.Append("SELECT * FROM dbo.depre_info");


                String sql3 = sb3.ToString();
                //String sql_3 = sb_3.ToString();

                SqlCommand command3 = new SqlCommand(sql3, connection3);


                // Query Godfather
                command3.CommandText = "SELECT explanation, expense " +
                                        "FROM dbo.depre_info  ";


                SqlDataReader reader3 = command3.ExecuteReader();

                while (reader3.Read())
                {
                    Depre_Explanation.Add(new getData() { Value = Convert.ToString(reader3.GetValue(0)) });
                    Depre_Expense.Add(new getData() { Value = Convert.ToString(reader3.GetValue(1)) });
                }

                ViewData["DEPRE_EXPLANATION"] = Depre_Explanation;
                ViewData["DEPRE_EXPENSE"] = Depre_Expense;

                foreach (var item in Depre_Explanation)
                {
                    Debug.WriteLine(item.Value);
                }

                connection3.Close();

            }


            return View();

        }
        [HttpGet]
        // GET: General Ledger
        public ActionResult GeneralLedger(int id)
        {
            IList<getData> Journal_Transaction_ID = new List<getData>();
            IList<getData> Journal_Date = new List<getData>();
            IList<getData> Journal_Explanation = new List<getData>();
            IList<getData> Journal_CustomerID = new List<getData>();
            IList<getData> Journal_Price_Amount = new List<getData>();
            IList<getData> Journal_Cost_Amount = new List<getData>();
            IList<getData> Journal_Type = new List<getData>();

            IList<getData> Depre_Explanation = new List<getData>();
            IList<getData> Depre_Expense = new List<getData>();

            // Debit

            IList<getData> Ledger_Account_Receivable = new List<getData>();
            IList<getData> Ledger_Account_Receivable_Date = new List<getData>();
            IList<getData> Ledger_Account_Receivable_Amount = new List<getData>();

            IList<getData> Ledger_COGS = new List<getData>();
            IList<getData> Ledger_COGS_Date = new List<getData>();
            IList<getData> Ledger_COGS_Amount = new List<getData>();

            // beware Inventory vs Inventory Cash
            IList<getData> Ledger_Inventory = new List<getData>();
            IList<getData> Ledger_Inventory_Date = new List<getData>();
            IList<getData> Ledger_Inventory_Amount = new List<getData>();           

            IList<getData> Ledger_Depreciation_Expenses = new List<getData>();
            IList<getData> Ledger_Depreciation_Expenses_Date = new List<getData>();
            IList<getData> Ledger_Depreciation_Expenses_Amount = new List<getData>();

            IList<getData> Ledger_Salary_Wages_Expenses = new List<getData>();
            IList<getData> Ledger_Salary_Wages_Expenses_Date = new List<getData>();
            IList<getData> Ledger_Salary_Wages_Expenses_Amount = new List<getData>();

            IList<getData> Ledger_Utilities_Expenses = new List<getData>();
            IList<getData> Ledger_Utilities_Expenses_Date = new List<getData>();
            IList<getData> Ledger_Utilities_Expenses_Amount = new List<getData>();


            // Credit
            IList<getData> Ledger_Account_Payable = new List<getData>();
            IList<getData> Ledger_Account_Payable_Date = new List<getData>();
            IList<getData> Ledger_Account_Payable_Amount = new List<getData>();

            IList<getData> Ledger_Revenue = new List<getData>();
            IList<getData> Ledger_Revenue_Date = new List<getData>();
            IList<getData> Ledger_Revenue_Amount = new List<getData>();

            IList<getData> Ledger_Inventory_Cash = new List<getData>();
            IList<getData> Ledger_Inventory_Cash_Date = new List<getData>();
            IList<getData> Ledger_Inventory_Cash_Amount = new List<getData>();

            IList<getData> Ledger_Accumulated_Depreciation = new List<getData>();
            IList<getData> Ledger_Accumulated_Depreciation_Date = new List<getData>();
            IList<getData> Ledger_Accumulated_Depreciation_Amount = new List<getData>();


            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    LOG-IN SESSION                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Session["status"] = id;
            ViewData["status"] = Session["status"];

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #1                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 4 
            SqlConnectionStringBuilder builder4 = new SqlConnectionStringBuilder();
            builder4.DataSource = "inc382.database.windows.net";
            builder4.UserID = "inc382";
            builder4.Password = "INC@kmutt";
            builder4.InitialCatalog = "inc382_group_4";

            using (SqlConnection connection4 = new
                SqlConnection(builder4.ConnectionString))
            {
                connection4.Open();
                StringBuilder sb4 = new StringBuilder();


                sb4.Append("SELECT * FROM dbo.purchase_order_info");


                String sql4 = sb4.ToString();
                //String sql_2 = sb_2.ToString();

                SqlCommand command4 = new SqlCommand(sql4, connection4);


                // Query Godfather
                command4.CommandText = "SELECT customer_id " +
                                        "FROM dbo.purchase_order_info  ";


                SqlDataReader reader4 = command4.ExecuteReader();

                while (reader4.Read())
                {
                    Journal_CustomerID.Add(new getData() { Value = Convert.ToString(reader4.GetValue(0)) });
                }

                //ViewData["JOURNAL_CUSTOMER_ID"] = Journal_CustomerID;

                connection4.Close();

            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #2                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 3 
            SqlConnectionStringBuilder builder6 = new SqlConnectionStringBuilder();
            builder6.DataSource = "inc382.database.windows.net";
            builder6.UserID = "inc382";
            builder6.Password = "INC@kmutt";
            builder6.InitialCatalog = "inc382_group_4";

            using (SqlConnection connection6 = new
                SqlConnection(builder6.ConnectionString))
            {
                connection6.Open();
                StringBuilder sb6 = new StringBuilder();


                sb6.Append("SELECT * FROM dbo.depre_info");


                String sql6 = sb6.ToString();
                //String sql_3 = sb_3.ToString();

                SqlCommand command6 = new SqlCommand(sql6, connection6);


                // Query Godfather
                command6.CommandText = "SELECT explanation, expense " +
                                        "FROM dbo.depre_info  ";

                var i = 0;


                SqlDataReader reader6 = command6.ExecuteReader();

                while (reader6.Read())
                {
                    Depre_Explanation.Add(new getData() { Value = Convert.ToString(reader6.GetValue(0)) });
                    Depre_Expense.Add(new getData() { Value = Convert.ToString(reader6.GetValue(1)) });

                    if (Depre_Explanation[i].Value.Contains("Depreciation") == true)
                    {

                        Ledger_Depreciation_Expenses.Add(new getData() { Value = Convert.ToString(reader6.GetValue(0)) });
                        Ledger_Depreciation_Expenses_Date.Add(new getData() { Value = "5/31/2019" });
                        Ledger_Depreciation_Expenses_Amount.Add(new getData() { Value = Convert.ToString(reader6.GetValue(1)) });

                        Ledger_Accumulated_Depreciation.Add(new getData() { Value = "Accumulated Depreciation of Gas Dispenser Machine " });
                        Ledger_Accumulated_Depreciation_Date.Add(new getData() { Value = "03/31/2019 11:05:26 PM" });
                        Ledger_Accumulated_Depreciation_Amount.Add(new getData() { Value = Convert.ToString(reader6.GetValue(1)) });

                    }

                    else if (Depre_Explanation[i].Value.Contains("Saleries") == true) // fuck...
                    {
                        // debit
                        Ledger_Salary_Wages_Expenses.Add(new getData() { Value = "Saleries and Wages Expense" });
                        Ledger_Salary_Wages_Expenses_Date.Add(new getData() { Value = "03/31/2019 11:05:26 PM" });
                        Ledger_Salary_Wages_Expenses_Amount.Add(new getData() { Value = Convert.ToString(reader6.GetValue(1)) });

                        // credit
                        Ledger_Inventory_Cash.Add(new getData() { Value = "Cash" });
                        Ledger_Inventory_Cash_Date.Add(new getData() { Value = "03/31/2019 11:05:26 PM" });
                        Ledger_Inventory_Cash_Amount.Add(new getData() { Value = Convert.ToString(reader6.GetValue(1)) });

                    }

                    else if (Depre_Explanation[i].Value.Contains("Utilities") == true) 
                    {
                        // debit
                        Ledger_Utilities_Expenses.Add(new getData() { Value = "Utilities Expenses" });
                        Ledger_Utilities_Expenses_Date.Add(new getData() { Value = "03/31/2019 11:05:26 PM" });
                        Ledger_Utilities_Expenses_Amount.Add(new getData() { Value = Convert.ToString(reader6.GetValue(1)) });

                        // credit
                        Ledger_Inventory_Cash.Add(new getData() { Value = "Cash" });
                        Ledger_Inventory_Cash_Date.Add(new getData() { Value = "03/31/2019 11:05:26 PM" });
                        Ledger_Inventory_Cash_Amount.Add(new getData() { Value = Convert.ToString(reader6.GetValue(1)) });
                    }
                    i++;
                }
                i = 0; // clear

                //ViewData["DEPRE_EXPLANATION"] = Depre_Explanation;
                //ViewData["DEPRE_EXPENSE"] = Depre_Expense;

                ViewData["LEDGER_DEPRECIATION_EXPENSE"] = Ledger_Depreciation_Expenses;
                ViewData["LEDGER_DEPRECIATION_EXPENSE_DATE"] = Ledger_Depreciation_Expenses_Date;
                ViewData["LEDGER_DEPRECIATION_EXPENSE_AMOUNT"] = Ledger_Depreciation_Expenses_Amount;

                ViewData["LEDGER_ACCUMULATED_DEPRECIATION"] = Ledger_Accumulated_Depreciation;
                ViewData["LEDGER_ACCUMULATED_DEPRECIATION_DATE"] = Ledger_Accumulated_Depreciation_Date;
                ViewData["LEDGER_ACCUMULATED_DEPRECIATION_AMOUNT"] = Ledger_Accumulated_Depreciation_Amount;

                ViewData["LEDGER_SALARY_WAGES_EXPENSES"] = Ledger_Salary_Wages_Expenses;
                ViewData["LEDGER_SALARY_WAGES_EXPENSES_DATE"] = Ledger_Salary_Wages_Expenses_Date;
                ViewData["LEDGER_SALARY_WAGES_EXPENSES_AMOUNT"] = Ledger_Salary_Wages_Expenses_Amount;

                ViewData["LEDGER_UTILITIES_EXPENSES"] = Ledger_Utilities_Expenses;
                ViewData["LEDGER_UTILITIES_EXPENSES_DATE"] = Ledger_Utilities_Expenses_Date;
                ViewData["LEDGER_UTILITIES_EXPENSES_AMOUNT"] = Ledger_Utilities_Expenses_Amount;



                foreach (var item in Depre_Explanation)
                {
                    Debug.WriteLine(item.Value);
                }

                connection6.Close();

            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #3                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 1 
            SqlConnectionStringBuilder builder5 = new SqlConnectionStringBuilder();
            builder5.DataSource = "inc382.database.windows.net";
            builder5.UserID = "inc382";
            builder5.Password = "INC@kmutt";
            builder5.InitialCatalog = "inc382_group_4";

            

            using (SqlConnection connection5 = new
                SqlConnection(builder5.ConnectionString))
            {
                connection5.Open();
                StringBuilder sb5 = new StringBuilder();

                sb5.Append("SELECT * FROM dbo.journal_info");

                String sql5 = sb5.ToString();

                SqlCommand command5 = new SqlCommand(sql5, connection5);

                // Query Godfather
                command5.CommandText = "SELECT transaction_id, date, explanation, price_amount, cost_amount, type " +
                                        "FROM dbo.journal_info  ";


                SqlDataReader reader5 = command5.ExecuteReader();
                var i = 0;
                while (reader5.Read())
                {
                    // GET DATA
                    Journal_Transaction_ID.Add(new getData() { Value = Convert.ToString(reader5.GetValue(0)) });
                    Journal_Date.Add(new getData() { Value = Convert.ToString(reader5.GetValue(1)) });
                    Journal_Explanation.Add(new getData() { Value = Convert.ToString(reader5.GetValue(2)) });
                    Journal_Price_Amount.Add(new getData() { Value = Convert.ToString(reader5.GetValue(3)) });
                    Journal_Cost_Amount.Add(new getData() { Value = Convert.ToString(reader5.GetValue(4)) });
                    Journal_Type.Add(new getData() { Value = Convert.ToString(reader5.GetValue(5)) });

                    if (Journal_Explanation[i].Value.Contains("Account receiveable") == true) {

                        Ledger_Account_Receivable.Add(new getData() { Value = "Account Receivable " });
                        Ledger_Account_Receivable_Date.Add(new getData() { Value = Journal_Date[i].Value });
                        Ledger_Account_Receivable_Amount.Add(new getData() { Value = Journal_Price_Amount[i].Value });
                        // Generate 3 muskeeteers

                        // Revenue
                        Ledger_Revenue.Add(new getData() { Value = "Revenue" });
                        Ledger_Revenue_Date.Add(new getData() { Value = Journal_Date[i].Value });
                        Ledger_Revenue_Amount.Add(new getData() { Value = Journal_Price_Amount[i].Value });

                        Ledger_COGS.Add(new getData() { Value = "COGS" });
                        Ledger_COGS_Date.Add(new getData() { Value = Journal_Date[i].Value });
                        Ledger_COGS_Amount.Add(new getData() { Value = Journal_Cost_Amount[i].Value });

                        // Inventory (Credit)
                        Ledger_Inventory_Cash.Add(new getData() { Value = "Inventory" });
                        Ledger_Inventory_Cash_Date.Add(new getData() { Value = Journal_Date[i].Value });
                        Ledger_Inventory_Cash_Amount.Add(new getData() { Value = Journal_Cost_Amount[i].Value });

                    }
                    else if (Journal_Explanation[i].Value.Contains("Account payable") == true)
                    {
                        Ledger_Account_Payable.Add(new getData() { Value = "Account Payable " });
                        Ledger_Account_Payable_Date.Add(new getData() { Value = Journal_Date[i].Value });
                        Ledger_Account_Payable_Amount.Add(new getData() { Value = Journal_Cost_Amount[i].Value });

                        // Inventory (Debit)
                        Ledger_Inventory.Add(new getData() { Value = "Inventory " + "(" + Journal_Type[i].Value + ")"});
                        Ledger_Inventory_Date.Add(new getData() { Value = Journal_Date[i].Value });
                        Ledger_Inventory_Amount.Add(new getData() { Value = Journal_Cost_Amount[i].Value });
                    }
                        i++;
                }
                i = 0; // clear



                //ViewData["JOURNAL_TRANSACTION_ID"] = Journal_Transaction_ID;

                ViewData["LEDGER_ACCOUNT_RECEIVABLE"] = Ledger_Account_Receivable;
                ViewData["LEDGER_ACCOUNT_RECEIVABLE_DATE"] = Ledger_Account_Receivable_Date;
                ViewData["LEDGER_ACCOUNT_RECEIVABLE_AMOUNT"] = Ledger_Account_Receivable_Amount;

                ViewData["LEDGER_REVENUE"] = Ledger_Revenue;
                ViewData["LEDGER_REVENUE_DATE"] = Ledger_Revenue_Date;
                ViewData["LEDGER_REVENUE_AMOUNT"] = Ledger_Revenue_Amount;

                ViewData["LEDGER_COGS"] = Ledger_COGS;
                ViewData["LEDGER_COGS_DATE"] = Ledger_COGS_Date;
                ViewData["LEDGER_COGS_AMOUNT"] = Ledger_COGS_Amount;

                ViewData["LEDGER_INVENTORY_CASH"] = Ledger_Inventory_Cash;
                ViewData["LEDGER_INVENTORY_CASH_DATE"] = Ledger_Inventory_Cash_Date;
                ViewData["LEDGER_INVENTORY_CASH_AMOUNT"] = Ledger_Inventory_Cash_Amount;

                ViewData["LEDGER_INVENTORY_CASH"] = Ledger_Inventory_Cash;
                ViewData["LEDGER_INVENTORY_CASH_DATE"] = Ledger_Inventory_Cash_Date;
                ViewData["LEDGER_INVENTORY_CASH_AMOUNT"] = Ledger_Inventory_Cash_Amount;

                ViewData["LEDGER_ACCOUNT_PAYABLE"] = Ledger_Account_Payable;
                ViewData["LEDGER_ACCOUNT_PAYABLE_DATE"] = Ledger_Account_Payable_Date;
                ViewData["LEDGER_ACCOUNT_PAYABLE_AMOUNT"] = Ledger_Account_Payable_Amount;

                ViewData["LEDGER_INVENTORY"] = Ledger_Inventory;
                ViewData["LEDGER_INVENTORY_DATE"] = Ledger_Inventory_Date;
                ViewData["LEDGER_INVENTORY_AMOUNT"] = Ledger_Inventory_Amount;

                connection5.Close();
            }


                return View();
        }
        [HttpGet]
        // GET: Income Statement
        public ActionResult IncomeStatement(int id)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    LOG-IN SESSION                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Session["status"] = id;
            ViewData["status"] = Session["status"];
            

            IList<getData> Journal_Transaction_ID = new List<getData>();
            IList<getData> Journal_Explanation = new List<getData>();
            IList<getData> Journal_Price_Amount = new List<getData>();
            IList<getData> Journal_Cost_Amount = new List<getData>();
            IList<getData> Journal_Type = new List<getData>();

            IList<getData> Ledger_Account_Receivable_Diesel_Amount = new List<getData>();
            IList<getData> Ledger_Account_Receivable_Gasohol95_Amount = new List<getData>();

            IList<getData> Ledger_COGS_Diesel_Amount = new List<getData>();
            IList<getData> Ledger_COGS_Gasohol95_Amount = new List<getData>();

            IList<getData> Depre_Explanation = new List<getData>();
            IList<getData> Ledger_Depreciation_Expenses_Amount = new List<getData>();
            IList<getData> Ledger_Salary_Wages_Expenses_Amount = new List<getData>();
            IList<getData> Ledger_Utilities_Expenses_Amount = new List<getData>();
            IList<getData> Ledger_Account_Payable_Amount = new List<getData>();

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #2                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::



            // Connect to SQL Server # 3 
            SqlConnectionStringBuilder builder7 = new SqlConnectionStringBuilder();
            builder7.DataSource = "inc382.database.windows.net";
            builder7.UserID = "inc382";
            builder7.Password = "INC@kmutt";
            builder7.InitialCatalog = "inc382_group_4";

            using (SqlConnection connection7 = new
                SqlConnection(builder7.ConnectionString))
            {
                connection7.Open();
                StringBuilder sb7 = new StringBuilder();

                sb7.Append("SELECT * FROM dbo.depre_info");
                String sql7 = sb7.ToString();

                SqlCommand command7 = new SqlCommand(sql7, connection7);


                // Query Godfather
                command7.CommandText = "SELECT explanation, expense " +
                                        "FROM dbo.depre_info  ";

                var i = 0;


                SqlDataReader reader7 = command7 .ExecuteReader();

                while (reader7.Read())
                {
                    Depre_Explanation.Add(new getData() { Value = Convert.ToString(reader7.GetValue(0)) });

                    if (Depre_Explanation[i].Value.Contains("Depreciation") == true)
                    {
                        Ledger_Depreciation_Expenses_Amount.Add(new getData() { Value = Convert.ToString(reader7.GetValue(1)) });
                    }

                    else if (Depre_Explanation[i].Value.Contains("Saleries") == true) // fuck...
                    {                    
                        Ledger_Salary_Wages_Expenses_Amount.Add(new getData() { Value = Convert.ToString(reader7.GetValue(1)) });
                    }

                    else if (Depre_Explanation[i].Value.Contains("Utilities") == true)
                    {
                        Ledger_Utilities_Expenses_Amount.Add(new getData() { Value = Convert.ToString(reader7.GetValue(1)) });
                    }
                    i++;
                }
                i = 0; // clear

                // Calculation - Less: Selling and Admin Expenses
                double Depreciation_Expenses_Amount = Ledger_Depreciation_Expenses_Amount.Sum(item =>  double.Parse(item.Value)); // Depre
                double Utilities_Expenses_Amount = Ledger_Utilities_Expenses_Amount.Sum(item => double.Parse(item.Value)); // Depre

                // Calculation - Tier 2
                double Total_Selling_and_Admin_Expense = Math.Round((double.Parse(Ledger_Salary_Wages_Expenses_Amount[0].Value) + 
                                                                                Depreciation_Expenses_Amount + 
                                                                                Utilities_Expenses_Amount), 2);

                ViewData["LEDGER_SALARY_WAGES_EXPENSES_AMOUNT"] = Ledger_Salary_Wages_Expenses_Amount[0].Value; // Salary
                ViewData["LEDGER_DEPRECIATION_EXPENSE_AMOUNT"] = Depreciation_Expenses_Amount; // Depreciation
                ViewData["LEDGER_UTILITIES_EXPENSES_AMOUNT"] = Utilities_Expenses_Amount; // Utility Expense
                ViewData["TOTAL_ADMIN_EXPENSE"] = Total_Selling_and_Admin_Expense;


                connection7.Close();

            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #3                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 1 
            SqlConnectionStringBuilder builder8 = new SqlConnectionStringBuilder();
            builder8.DataSource = "inc382.database.windows.net";
            builder8.UserID = "inc382";
            builder8.Password = "INC@kmutt";
            builder8.InitialCatalog = "inc382_group_4";



            using (SqlConnection connection8 = new
                SqlConnection(builder8.ConnectionString))
            {
                connection8.Open();
                StringBuilder sb8 = new StringBuilder();

                sb8.Append("SELECT * FROM dbo.journal_info");

                String sql8 = sb8.ToString();

                SqlCommand command8 = new SqlCommand(sql8, connection8);

                // Query Godfather
                command8.CommandText = "SELECT transaction_id, date, explanation, price_amount, cost_amount, type " +
                                        "FROM dbo.journal_info  ";


                SqlDataReader reader8 = command8.ExecuteReader();
                var i = 0;
                while (reader8.Read())
                {
                    // GET DATA
                    Journal_Transaction_ID.Add(new getData() { Value = Convert.ToString(reader8.GetValue(0)) });
                    Journal_Explanation.Add(new getData() { Value = Convert.ToString(reader8.GetValue(2)) });
                    Journal_Price_Amount.Add(new getData() { Value = Convert.ToString(reader8.GetValue(3)) });
                    Journal_Cost_Amount.Add(new getData() { Value = Convert.ToString(reader8.GetValue(4)) });
                    Journal_Type.Add(new getData() { Value = Convert.ToString(reader8.GetValue(5)) });

                    if ((Journal_Explanation[i].Value.Contains("Account receiveable") == true) && (Journal_Type[i].Value == "DIESEL"))
                    {
                        Ledger_Account_Receivable_Diesel_Amount.Add(new getData() { Value = Journal_Price_Amount[i].Value });
                        Ledger_COGS_Diesel_Amount.Add(new getData() { Value = Journal_Cost_Amount[i].Value });
                    }
                    else if ((Journal_Explanation[i].Value.Contains("Account receiveable") == true) && (Journal_Type[i].Value == "GASOHOL95"))
                    {
                        Ledger_Account_Receivable_Gasohol95_Amount.Add(new getData() { Value = Journal_Price_Amount[i].Value });
                        Ledger_COGS_Gasohol95_Amount.Add(new getData() { Value = Journal_Cost_Amount[i].Value });
                    }
                    i++;
                }
                i = 0; // clear

                // Calculation - Less: Selling and Admin Expenses
                double Account_Receivable_Diesel_Amount = Ledger_Account_Receivable_Diesel_Amount.Sum(item => double.Parse(item.Value)); // AR Diesel
                double Account_Receivable_Gasohol95_Amount = Ledger_Account_Receivable_Gasohol95_Amount.Sum(item => double.Parse(item.Value)); // AR Gasohol95
                double COGS_Diesel_Amount = Ledger_COGS_Diesel_Amount.Sum(item => double.Parse(item.Value)); // COGS Diesel
                double COGS_Gasohol95_Amount = Ledger_COGS_Gasohol95_Amount.Sum(item => double.Parse(item.Value)); //COGS Gasohol95

                // Calculation - Tier 2
                double Total_Sale = Math.Round((Account_Receivable_Diesel_Amount + Account_Receivable_Gasohol95_Amount), 2);
                double Total_COGS = Math.Round((COGS_Diesel_Amount + COGS_Gasohol95_Amount), 2);
                double Gross_Profit = Math.Round((Total_Sale - Total_COGS), 2);
            

                ViewData["LEDGER_ACCOUNT_RECEIVABLE_DIESEL_AMOUNT"] = Account_Receivable_Diesel_Amount;
                ViewData["LEDGER_ACCOUNT_RECEIVABLE_GASOHOL95_AMOUNT"] = Account_Receivable_Gasohol95_Amount;
                ViewData["LEDGER_COGS_DIESEL_AMOUNT"] = COGS_Diesel_Amount;
                ViewData["LEDGER_COGS_GASOHOL95_AMOUNT"] = COGS_Gasohol95_Amount;
                ViewData["TOTAL_SALE"] = Total_Sale;
                ViewData["TOTAL_COGS"] = Total_COGS;
                ViewData["GROSS_PROFIT"] = Gross_Profit;


                connection8.Close();
            }

            return View();
        }
        [HttpGet]
        // GET: Reconcilation Sheet
        public ActionResult ReconcilationSheet(int id)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    LOG-IN SESSION                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Session["status"] = id;
            ViewData["status"] = Session["status"];
            return View();
        }
        [HttpGet]
        // GET: Reconcilation Sheet
        public ActionResult InventoryStockCard(int id)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    LOG-IN SESSION                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Session["status"] = id;
            ViewData["status"] = Session["status"];

            double Beginning_Stock_Diesel = 30000;
            double Beginning_Stock_Gasohol95 = 40000;

            IList<getData> Journal_Explanation = new List<getData>();
            IList<getData> Journal_Price_Amount = new List<getData>();
            IList<getData> Journal_Cost_Amount = new List<getData>();
            IList<getData> Journal_Type = new List<getData>();

            IList<getData> Ledger_Account_Receivable_Diesel_Amount = new List<getData>(); // Sold
            IList<getData> Ledger_Account_Receivable_Gasohol95_Amount = new List<getData>(); // Sold
            IList<getData> Ledger_Account_Payable_Diesel_Amount = new List<getData>();  // Purchased
            IList<getData> Ledger_Account_Payable_Gasohol95_Amount = new List<getData>(); // Purchased

            IList<getData> Inv_Ending_Stock_Diesel = new List<getData>(); // Ending Stock
            IList<getData> Inv_Ending_Stock_Gasohol95 = new List<getData>(); // Ending Stock



            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #1                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 1 
            SqlConnectionStringBuilder builder9 = new SqlConnectionStringBuilder();
            builder9.DataSource = "inc382.database.windows.net";
            builder9.UserID = "inc382";
            builder9.Password = "INC@kmutt";
            builder9.InitialCatalog = "inc382_group_4";



            using (SqlConnection connection9 = new
                SqlConnection(builder9.ConnectionString))
            {
                connection9.Open();
                StringBuilder sb9 = new StringBuilder();

                sb9.Append("SELECT * FROM dbo.journal_info");

                String sql9 = sb9.ToString();

                SqlCommand command9 = new SqlCommand(sql9, connection9);

                // Query Godfather
                command9.CommandText = "SELECT explanation, price_amount, cost_amount, type " +
                                        "FROM dbo.journal_info  ";


                SqlDataReader reader9 = command9.ExecuteReader();
                var i = 0;
                while (reader9.Read())
                {
                    // GET DATA
                    Journal_Explanation.Add(new getData() { Value = Convert.ToString(reader9.GetValue(0)) });
                    Journal_Price_Amount.Add(new getData() { Value = Convert.ToString(reader9.GetValue(1)) });
                    Journal_Cost_Amount.Add(new getData() { Value = Convert.ToString(reader9.GetValue(2)) });
                    Journal_Type.Add(new getData() { Value = Convert.ToString(reader9.GetValue(3)) });

                    if ((Journal_Explanation[i].Value.Contains("Account receiveable") == true) && (Journal_Type[i].Value == "DIESEL"))
                    {
                        Ledger_Account_Receivable_Diesel_Amount.Add(new getData() { Value = Journal_Price_Amount[i].Value });
                    }
                    else if ((Journal_Explanation[i].Value.Contains("Account receiveable") == true) && (Journal_Type[i].Value == "GASOHOL95"))
                    {
                        Ledger_Account_Receivable_Gasohol95_Amount.Add(new getData() { Value = Journal_Price_Amount[i].Value });
                    }
                    else if ((Journal_Explanation[i].Value.Contains("Account payable") == true) && (Journal_Type[i].Value == "DIESEL"))
                    {
                        Ledger_Account_Payable_Diesel_Amount.Add(new getData() { Value = Journal_Cost_Amount[i].Value });
                    }
                    else if ((Journal_Explanation[i].Value.Contains("Account payable") == true) && (Journal_Type[i].Value == "GASOHOL95"))
                    {
                        Ledger_Account_Payable_Gasohol95_Amount.Add(new getData() { Value = Journal_Cost_Amount[i].Value });
                    }

                    i++;
                }
                i = 0; // clear

                // Calculation - Less: Selling and Admin Expenses
                double Account_Receivable_Diesel_Amount = Ledger_Account_Receivable_Diesel_Amount.Sum(item => double.Parse(item.Value)); // AR Diesel
                double Account_Receivable_Gasohol95_Amount = Ledger_Account_Receivable_Gasohol95_Amount.Sum(item => double.Parse(item.Value)); // AR Gasohol95
                double Account_Payable_Diesel_Amount = Ledger_Account_Payable_Diesel_Amount.Sum(item => double.Parse(item.Value)); // AR Diesel
                double Account_Payable_Gasohol95_Amount = Ledger_Account_Payable_Gasohol95_Amount.Sum(item => double.Parse(item.Value)); // AR Gasohol95

                ViewData["BEGINING_STOCK_GASOHOL95"] = Beginning_Stock_Gasohol95;
                ViewData["BEGINING_STOCK_DIESEL"] = Beginning_Stock_Diesel;
                ViewData["PURCHASED_GASOHOL95"] = Account_Payable_Gasohol95_Amount;
                ViewData["PURCHASED_DIESEL"] = Account_Payable_Diesel_Amount;
                ViewData["SOLD_GASOHOL95"] = Account_Receivable_Gasohol95_Amount;
                ViewData["SOLD_DIESEL"] = Account_Receivable_Diesel_Amount;


                connection9.Close();
            }
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #2                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 1 
            SqlConnectionStringBuilder builder10 = new SqlConnectionStringBuilder();
            builder10.DataSource = "inc382.database.windows.net";
            builder10.UserID = "inc382";
            builder10.Password = "INC@kmutt";
            builder10.InitialCatalog = "inc382_group_4";



            using (SqlConnection connection10 = new
                SqlConnection(builder10.ConnectionString))
            {
                connection10.Open();
                StringBuilder sb10 = new StringBuilder();

                sb10.Append("SELECT * FROM dbo.diesel_tank_info");

                String sql10 = sb10.ToString();

                SqlCommand command10 = new SqlCommand(sql10, connection10);

                // Query Godfather
                command10.CommandText = "SELECT diesel_remain_volume " +
                                        "FROM dbo.diesel_tank_info  ";


                SqlDataReader reader10 = command10.ExecuteReader();
                while (reader10.Read())
                {
                    // GET DATA
                    Inv_Ending_Stock_Diesel.Add(new getData() { Value = Convert.ToString(reader10.GetValue(0)) });                   
                }


                // Calculation - Less: Selling and Admin Expenses
                ViewData["ENDING_STOCK_DIESEL"] = Inv_Ending_Stock_Diesel[0].Value;
                
                connection10.Close();
            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #3                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 1 
            SqlConnectionStringBuilder builder11 = new SqlConnectionStringBuilder();
            builder11.DataSource = "inc382.database.windows.net";
            builder11.UserID = "inc382";
            builder11.Password = "INC@kmutt";
            builder11.InitialCatalog = "inc382_group_4";



            using (SqlConnection connection11 = new
                SqlConnection(builder11.ConnectionString))
            {
                connection11.Open();
                StringBuilder sb11 = new StringBuilder();

                sb11.Append("SELECT * FROM dbo.gasohol95_tank_info");

                String sql11 = sb11.ToString();

                SqlCommand command11 = new SqlCommand(sql11, connection11);

                // Query Godfather
                command11.CommandText = "SELECT gasohol95_remain_volume " +
                                        "FROM dbo.gasohol95_tank_info  ";


                SqlDataReader reader11 = command11.ExecuteReader();
                while (reader11.Read())
                {
                    // GET DATA
                    Inv_Ending_Stock_Gasohol95.Add(new getData() { Value = Convert.ToString(reader11.GetValue(0)) });
                }

                // Calculation - Less: Selling and Admin Expenses
                ViewData["ENDING_STOCK_GASOHOL95"] = Inv_Ending_Stock_Gasohol95[0].Value;

                connection11.Close();
            }




            return View();
        }
        [HttpGet]
        // GET: Purchase Order
        public ActionResult PurchaseOrder(int id, string PO)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    LOG-IN SESSION                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Session["status"] = id;
            ViewData["status"] = Session["status"];

            //string poNum = "7007392288";
            string poNum = PO;

            IList<getData> po_Number = new List<getData>();
            IList<getData> shipment_number = new List<getData>();
            IList<getData> date_time = new List<getData>();
            IList<getData> customer_ID = new List<getData>();
            IList<getData> tax_payer_id = new List<getData>();
            IList<getData> gas_type = new List<getData>();
            IList<getData> gas_price = new List<getData>();
            IList<getData> volume_filled = new List<getData>();
            IList<getData> gas_amount = new List<getData>();

            // Connect to SQL Server # 1 
            SqlConnectionStringBuilder builder12 = new SqlConnectionStringBuilder();
            builder12.DataSource = "inc382.database.windows.net";
            builder12.UserID = "inc382";
            builder12.Password = "INC@kmutt";
            builder12.InitialCatalog = "inc382_group_4";



            using (SqlConnection connection12 = new
                SqlConnection(builder12.ConnectionString))
            {
                connection12.Open();
                StringBuilder sb12 = new StringBuilder();

                sb12.Append("SELECT * FROM dbo.purchase_order_info");

                String sql12 = sb12.ToString();

                SqlCommand command12 = new SqlCommand(sql12, connection12);

                // Query Godfather
                command12.CommandText = "SELECT po_number, shipment_number, date_time, customer_id, tax_prayer_id, gas_type,  gas_price, volume_filled, gas_amount " +
                                        "FROM dbo.purchase_order_info WHERE CONVERT(VARCHAR(50), po_number) = '" + poNum + "'";



                SqlDataReader reader12 = command12.ExecuteReader();

                while (reader12.Read())
                {
                    // GET DATA
                    po_Number.Add(new getData() { Value = Convert.ToString(reader12.GetValue(0)) });
                    shipment_number.Add(new getData() { Value = Convert.ToString(reader12.GetValue(1)) });
                    date_time.Add(new getData() { Value = Convert.ToString(reader12.GetValue(2)) });
                    customer_ID.Add(new getData() { Value = Convert.ToString(reader12.GetValue(3)) });
                    tax_payer_id.Add(new getData() { Value = Convert.ToString(reader12.GetValue(4)) });
                    gas_type.Add(new getData() { Value = Convert.ToString(reader12.GetValue(5)) });
                    gas_price.Add(new getData() { Value = Convert.ToString(reader12.GetValue(6)) });
                    volume_filled.Add(new getData() { Value = Convert.ToString(reader12.GetValue(7)) });
                    gas_amount.Add(new getData() { Value = Convert.ToString(reader12.GetValue(8)) });

                    // Calculation - Less: Selling and Admin Expenses
                    ViewData["PO"] = po_Number[0].Value;
                    ViewData["SHIPMENT_NUMBER"] = shipment_number[0].Value;
                    ViewData["DATE_TIME"] = date_time[0].Value;
                    ViewData["CUSTOMER_ID"] = customer_ID[0].Value;
                    ViewData["TAX_PAYER_ID"] = tax_payer_id[0].Value;
                    ViewData["GAS_TYPE"] = gas_type[0].Value;
                    ViewData["GAS_PRICE"] = gas_price[0].Value;
                    ViewData["VOLUME_FILLED"] = volume_filled[0].Value;
                    ViewData["GAS_AMOUNT"] = gas_amount[0].Value;

                }

                //foreach (var item in shipment_number)
                //{
                //    Debug.WriteLine(item.Value);
                //        }




       

                connection12.Close();
            }






            return View();
        }
        [HttpGet]
        // GET: Purchase Order
        public ActionResult Invoice (int id, string invoice)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    LOG-IN SESSION                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Session["status"] = id;
            ViewData["status"] = Session["status"];

            string _poNumber = "7007392288";
            string _customerID = "10003964";
            string ivNum = invoice;

            IList<getData> petrol_ID = new List<getData>();
            IList<getData> iv_Number = new List<getData>();
            IList<getData> po_Number = new List<getData>();
            IList<getData> shipment_number = new List<getData>();
            IList<getData> date_time = new List<getData>();
            IList<getData> customer_ID = new List<getData>();
            IList<getData> tax_payer_id = new List<getData>();
            IList<getData> gas_type = new List<getData>();
            IList<getData> gas_price = new List<getData>();
            IList<getData> time_filled = new List<getData>();
            IList<getData> volume_filled = new List<getData>();
            IList<getData> gas_amount = new List<getData>();

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #1                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 1 
            SqlConnectionStringBuilder builder13 = new SqlConnectionStringBuilder();
            builder13.DataSource = "inc382.database.windows.net";
            builder13.UserID = "inc382";
            builder13.Password = "INC@kmutt";
            builder13.InitialCatalog = "inc382_group_4";



            using (SqlConnection connection13 = new
                SqlConnection(builder13.ConnectionString))
            {
                connection13.Open();
                StringBuilder sb13 = new StringBuilder();

                sb13.Append("SELECT * FROM dbo.purchase_order_info");

                String sql13 = sb13.ToString();

                SqlCommand command13 = new SqlCommand(sql13, connection13);

                // Query Godfather
                command13.CommandText = "SELECT po_number, shipment_number, date_time, customer_id, tax_prayer_id, gas_type,  gas_price, time_filled, volume_filled, gas_amount " +
                                        "FROM dbo.purchase_order_info WHERE CONVERT(VARCHAR(50), po_number) = '" + invoice + "'";



                SqlDataReader reader13 = command13.ExecuteReader();

                while (reader13.Read())
                {
                    // GET DATA
                    po_Number.Add(new getData() { Value = Convert.ToString(reader13.GetValue(0)) });
                    shipment_number.Add(new getData() { Value = Convert.ToString(reader13.GetValue(1)) });
                    date_time.Add(new getData() { Value = Convert.ToString(reader13.GetValue(2)) });
                    customer_ID.Add(new getData() { Value = Convert.ToString(reader13.GetValue(3)) });
                    tax_payer_id.Add(new getData() { Value = Convert.ToString(reader13.GetValue(4)) });
                    gas_type.Add(new getData() { Value = Convert.ToString(reader13.GetValue(5)) });
                    gas_price.Add(new getData() { Value = Convert.ToString(reader13.GetValue(6)) });
                    time_filled.Add(new getData() { Value = Convert.ToString(reader13.GetValue(7)) });
                    volume_filled.Add(new getData() { Value = Convert.ToString(reader13.GetValue(8)) });
                    gas_amount.Add(new getData() { Value = Convert.ToString(reader13.GetValue(9)) });

                    // Calculation - Less: Selling and Admin Expenses
                    ViewData["PO"] = po_Number[0].Value;
                    ViewData["SHIPMENT_NUMBER"] = shipment_number[0].Value;
                    ViewData["DATE_TIME"] = date_time[0].Value;
                    ViewData["CUSTOMER_ID"] = customer_ID[0].Value;
                    ViewData["TAX_PAYER_ID"] = tax_payer_id[0].Value;
                    ViewData["GAS_TYPE"] = gas_type[0].Value;
                    ViewData["GAS_PRICE"] = gas_price[0].Value;
                    ViewData["TIME_FILLED"] = volume_filled[0].Value;
                    ViewData["VOLUME_FILLED"] = volume_filled[0].Value;
                    ViewData["GAS_AMOUNT"] = gas_amount[0].Value;

                    _poNumber = ViewData["PO"].ToString();
                    _customerID = ViewData["CUSTOMER_ID"].ToString();

                }

                connection13.Close();
            }

           

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                      QUERY DATA #3                                    ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Connect to SQL Server # 3
            SqlConnectionStringBuilder builder15 = new SqlConnectionStringBuilder();
            builder15.DataSource = "inc382.database.windows.net";
            builder15.UserID = "inc382";
            builder15.Password = "INC@kmutt";
            builder15.InitialCatalog = "inc382_group_4";



            using (SqlConnection connection15 = new
                SqlConnection(builder15.ConnectionString))
            {
                connection15.Open();
                StringBuilder sb15 = new StringBuilder();

                sb15.Append("SELECT * FROM dbo.invoice_info");

                String sql15 = sb15.ToString();

                SqlCommand command15 = new SqlCommand(sql15, connection15);

                // Query Godfather
                command15.CommandText = "SELECT invoice_id " +
                                        "FROM dbo.invoice_info WHERE CONVERT(VARCHAR(50), purchase_order_number) = '" + ivNum + "'";



                SqlDataReader reader15 = command15.ExecuteReader();

                while (reader15.Read())
                {
                    // GET DATA
                    iv_Number.Add(new getData() { Value = Convert.ToString(reader15.GetValue(0)) });


                    // Calculation - Less: Selling and Admin Expenses
                    ViewData["INVOICE_NUMBER"] = iv_Number[0].Value;


                }

                connection15.Close();

                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                //                                      QUERY DATA #2                                    ::
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                // Connect to SQL Server # 2
                SqlConnectionStringBuilder builder14 = new SqlConnectionStringBuilder();
                builder14.DataSource = "inc382.database.windows.net";
                builder14.UserID = "inc382";
                builder14.Password = "INC@kmutt";
                builder14.InitialCatalog = "inc382_group_4";



                using (SqlConnection connection14 = new
                    SqlConnection(builder14.ConnectionString))
                {
                    connection14.Open();
                    StringBuilder sb14 = new StringBuilder();

                    sb14.Append("SELECT * FROM dbo.petrol_station_info");

                    String sql14 = sb14.ToString();

                    SqlCommand command14 = new SqlCommand(sql14, connection14);

                    // Query Godfather
                    command14.CommandText = "SELECT petrol_id " +
                                            "FROM dbo.petrol_station_info WHERE CONVERT(VARCHAR(50), customer_id) = '" + _customerID + "'";



                    SqlDataReader reader14 = command14.ExecuteReader();

                    Random rnd = new Random();


                    while (reader14.Read())
                    {
                        // GET DATA
                        petrol_ID.Add(new getData() { Value = Convert.ToString(reader14.GetValue(0)) });

                        // Calculation - Less: Selling and Admin Expenses

                        ViewData["PETROL_ID"] = petrol_ID[0].Value;


                    }

                    connection14.Close();
                }

            }


            return View();
        }


    }
}