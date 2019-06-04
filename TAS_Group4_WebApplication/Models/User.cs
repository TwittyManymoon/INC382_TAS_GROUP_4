using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TAS_Group4_WebApplication.Models
{
    public class User
    {
        // :: Agent ID
        public int AgentID { get; set; }
        // :: Agent Username
        public string AgentUsername { get; set; }
        // :: Agent Password
        public string AgentPassword { get; set; }
        // :: Agent Firstname
        public string AgentFirstName { get; set; }
        // :: Agent Lastname
        public string AgentLastname { get; set; }
        // :: Agent Type
        public string AgentType { get; set; }
        // :: Agent Operator Shift Start
        public string OperatorShiftStart{ get; set; }
        // :: Agent Operator Shift End
        public string OperatorShiftEnd { get; set; }
        // :: Agent Salary
        public string OperatorSalary { get; set; }

    }

    public class Login
    {
        // :: Agent Username
        public string AgentUsername { get; set; }
        // :: Agent Password
        public string AgentPassword { get; set; }
        // :: Agent Status
        public int AgentStatus { get; set; }
    }

    public class getData
    {    
        // :: Value
        public string Value { get; set; }
    }

    public class searchTruck
    {
        public string License_Plate { get; set; }
        public string Petrol_Type { get; set; }
        public string Date_CheckIn { get; set; }

        public string Sale_Office_Arrived_Time { get; set; }
        public string Sale_Office_Departed_Time { get; set; }
        public string Sale_Office_Cycle_Time { get; set; }

        public string Weigh_In_Arrived_Time { get; set; }
        public string Weigh_In_Departed_Time { get; set; }
        public string Weigh_In_Cycle_Time { get; set; }

        public string Weigh_Out_Arrived_Time { get; set; }
        public string Weigh_Out_Departed_Time { get; set; }
        public string Weigh_Out_Cycle_Time { get; set; }

        public string Bay_Number { get; set; }
        public string Bay_Loading_Arrived_Time { get; set; }
        public string Bay_Loading_Departed_Time { get; set; }
        public string Bay_Loading_Cycle_Time { get; set; }
        public string Exit_Time { get; set; }
    }

    public class getJournal
    {
        public string Transaction_ID { get; set; }
        public string Date { get; set; }
        public string Explanation { get; set; }
        public string Price_Amount { get; set; }
        public string Cost_Amount { get; set; }
       
    }

}