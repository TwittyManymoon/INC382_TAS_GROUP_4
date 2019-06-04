using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.PI;
using OSIsoft.AF.Time;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TAS_Group4_WebApplication.Models;

namespace TAS_Group4_WebApplication.Controllers
{
    public class DashboardController : Controller
    {
        // TODO : Query required value for Operator and Manager
        // TODO : Create session and ViewData
        // TODO : Throw ViewData to DashboardOperator.cshtml and DashboardManager.cshtml

        // TODO : Check and update non-existed data to SQL Server
        // GET: DashboardOperator
        // Setting connection to PI System
        // --------------------------------------------------------------------------------------------------------------- // 
        // --------------------------------------------------------------------------------------------------------------- // 
        // OPERATOR OPERATOR OPERATOR OPERATOR OPERATOR OPERATOR OPERATOR OPERATOR OPERATOR OPERATOR OPERATOR OPERATOR 
        // --------------------------------------------------------------------------------------------------------------- // 
        // --------------------------------------------------------------------------------------------------------------- // 
        // layer 1 : super KPI
        OSIsoft.AF.PI.PIPoint[] pt_DieselSold_Day = new OSIsoft.AF.PI.PIPoint[31]; // 1
        OSIsoft.AF.PI.PIPoint[] pt_Gasohol95Sold_Day = new OSIsoft.AF.PI.PIPoint[31]; // 2
        OSIsoft.AF.PI.PIPoint[] pt_AvgCTDieselDispenser_Day = new OSIsoft.AF.PI.PIPoint[31]; // 3
        OSIsoft.AF.PI.PIPoint[] pt_AvgCTGasohol95Dispenser_Day = new OSIsoft.AF.PI.PIPoint[31]; // 4

        OSIsoft.AF.Asset.AFValues[] plotValuesDiesel = new OSIsoft.AF.Asset.AFValues[31]; // 1
        OSIsoft.AF.Asset.AFValues[] plotValuesGasohol95 = new OSIsoft.AF.Asset.AFValues[31]; // 2
        OSIsoft.AF.Asset.AFValues[] plotAvgCTDieselDispenser = new OSIsoft.AF.Asset.AFValues[31]; // 3
        OSIsoft.AF.Asset.AFValues[] plotAvgCTGasohol95Dispenser = new OSIsoft.AF.Asset.AFValues[31]; // 4

        // 1
        string Diesel_Sold_1, Diesel_Sold_2, Diesel_Sold_3, Diesel_Sold_4, Diesel_Sold_5, Diesel_Sold_6, Diesel_Sold_7, Diesel_Sold_8, Diesel_Sold_9, Diesel_Sold_10,
    Diesel_Sold_11, Diesel_Sold_12, Diesel_Sold_13, Diesel_Sold_14, Diesel_Sold_15, Diesel_Sold_16, Diesel_Sold_17, Diesel_Sold_18, Diesel_Sold_19, Diesel_Sold_20,
    Diesel_Sold_21, Diesel_Sold_22, Diesel_Sold_23, Diesel_Sold_24, Diesel_Sold_25, Diesel_Sold_26, Diesel_Sold_27, Diesel_Sold_28, Diesel_Sold_29, Diesel_Sold_30, Diesel_Sold_31;
        // 2
        string Gasohol95_Sold_1, Gasohol95_Sold_2, Gasohol95_Sold_3, Gasohol95_Sold_4, Gasohol95_Sold_5, Gasohol95_Sold_6, Gasohol95_Sold_7, Gasohol95_Sold_8, Gasohol95_Sold_9, Gasohol95_Sold_10,
            Gasohol95_Sold_11, Gasohol95_Sold_12, Gasohol95_Sold_13, Gasohol95_Sold_14, Gasohol95_Sold_15, Gasohol95_Sold_16, Gasohol95_Sold_17, Gasohol95_Sold_18, Gasohol95_Sold_19, Gasohol95_Sold_20,
            Gasohol95_Sold_21, Gasohol95_Sold_22, Gasohol95_Sold_23, Gasohol95_Sold_24, Gasohol95_Sold_25, Gasohol95_Sold_26, Gasohol95_Sold_27, Gasohol95_Sold_28, Gasohol95_Sold_29, Gasohol95_Sold_30, Gasohol95_Sold_31;
        // 3
        string Avg_CT_Diesel_Dispenser_1, Avg_CT_Diesel_Dispenser_2, Avg_CT_Diesel_Dispenser_3, Avg_CT_Diesel_Dispenser_4, Avg_CT_Diesel_Dispenser_5, Avg_CT_Diesel_Dispenser_6, Avg_CT_Diesel_Dispenser_7, Avg_CT_Diesel_Dispenser_8, Avg_CT_Diesel_Dispenser_9, Avg_CT_Diesel_Dispenser_10,
    Avg_CT_Diesel_Dispenser_11, Avg_CT_Diesel_Dispenser_12, Avg_CT_Diesel_Dispenser_13, Avg_CT_Diesel_Dispenser_14, Avg_CT_Diesel_Dispenser_15, Avg_CT_Diesel_Dispenser_16, Avg_CT_Diesel_Dispenser_17, Avg_CT_Diesel_Dispenser_18, Avg_CT_Diesel_Dispenser_19, Avg_CT_Diesel_Dispenser_20,
    Avg_CT_Diesel_Dispenser_21, Avg_CT_Diesel_Dispenser_22, Avg_CT_Diesel_Dispenser_23, Avg_CT_Diesel_Dispenser_24, Avg_CT_Diesel_Dispenser_25, Avg_CT_Diesel_Dispenser_26, Avg_CT_Diesel_Dispenser_27, Avg_CT_Diesel_Dispenser_28, Avg_CT_Diesel_Dispenser_29, Avg_CT_Diesel_Dispenser_30, Avg_CT_Diesel_Dispenser_31;
        // 4
        string Avg_CT_Gasohol95_Dispenser_1, Avg_CT_Gasohol95_Dispenser_2, Avg_CT_Gasohol95_Dispenser_3, Avg_CT_Gasohol95_Dispenser_4, Avg_CT_Gasohol95_Dispenser_5, Avg_CT_Gasohol95_Dispenser_6, Avg_CT_Gasohol95_Dispenser_7, Avg_CT_Gasohol95_Dispenser_8, Avg_CT_Gasohol95_Dispenser_9, Avg_CT_Gasohol95_Dispenser_10,
    Avg_CT_Gasohol95_Dispenser_11, Avg_CT_Gasohol95_Dispenser_12, Avg_CT_Gasohol95_Dispenser_13, Avg_CT_Gasohol95_Dispenser_14, Avg_CT_Gasohol95_Dispenser_15, Avg_CT_Gasohol95_Dispenser_16, Avg_CT_Gasohol95_Dispenser_17, Avg_CT_Gasohol95_Dispenser_18, Avg_CT_Gasohol95_Dispenser_19, Avg_CT_Gasohol95_Dispenser_20,
    Avg_CT_Gasohol95_Dispenser_21, Avg_CT_Gasohol95_Dispenser_22, Avg_CT_Gasohol95_Dispenser_23, Avg_CT_Gasohol95_Dispenser_24, Avg_CT_Gasohol95_Dispenser_25, Avg_CT_Gasohol95_Dispenser_26, Avg_CT_Gasohol95_Dispenser_27, Avg_CT_Gasohol95_Dispenser_28, Avg_CT_Gasohol95_Dispenser_29, Avg_CT_Gasohol95_Dispenser_30, Avg_CT_Gasohol95_Dispenser_31;

        // layer 2 : supporter
        // Avg. Flow Rate of Diesel and Gasohol 95
        string Avg_Flow_Rate_Diesel_Bay_1_1, Avg_Flow_Rate_Diesel_Bay_1_2, Avg_Flow_Rate_Diesel_Bay_1_3, Avg_Flow_Rate_Diesel_Bay_1_4,
            Avg_Flow_Rate_Diesel_Bay_2_1, Avg_Flow_Rate_Diesel_Bay_2_2, Avg_Flow_Rate_Diesel_Bay_2_3, Avg_Flow_Rate_Diesel_Bay_2_4,
            Avg_Flow_Rate_Diesel_Bay_3_1, Avg_Flow_Rate_Diesel_Bay_3_2, Avg_Flow_Rate_Diesel_Bay_3_3, Avg_Flow_Rate_Diesel_Bay_3_4,
            Avg_Flow_Rate_Diesel_Bay_4_1, Avg_Flow_Rate_Diesel_Bay_4_2, Avg_Flow_Rate_Diesel_Bay_4_3, Avg_Flow_Rate_Diesel_Bay_4_4,
            Avg_Flow_Rate_Gasohol95_Bay_5_1, Avg_Flow_Rate_Gasohol95_Bay_5_2, Avg_Flow_Rate_Gasohol95_Bay_5_3, Avg_Flow_Rate_Gasohol95_Bay_5_4,
            Avg_Flow_Rate_Gasohol95_Bay_6_1, Avg_Flow_Rate_Gasohol95_Bay_6_2, Avg_Flow_Rate_Gasohol95_Bay_6_3, Avg_Flow_Rate_Gasohol95_Bay_6_4;

        // Avg. Number of Failure of Diesel and Gasohol 95
        string No_of_Failure_Diesel_Bay_1_1, No_of_Failure_Diesel_Bay_2_1, No_of_Failure_Diesel_Bay_3_1,
            No_of_Failure_Diesel_Bay_4_1, No_of_Failure_Gasohol95_Bay_5_1, No_of_Failure_Gasohol95_Bay_6_1;

        // 1 - AvgFlowRate
        OSIsoft.AF.PI.PIPoint[] pt_AvgFlowRate_Diesel_Bay_1 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_AvgFlowRate_Diesel_Bay_2 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_AvgFlowRate_Diesel_Bay_3 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_AvgFlowRate_Diesel_Bay_4 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_AvgFlowRate_Gasohol95_Bay_5 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_AvgFlowRate_Gasohol95_Bay_6 = new OSIsoft.AF.PI.PIPoint[4];

        OSIsoft.AF.Asset.AFValues[] plotAvgFlowRate_Diesel_Bay_1 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotAvgFlowRate_Diesel_Bay_2 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotAvgFlowRate_Diesel_Bay_3 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotAvgFlowRate_Diesel_Bay_4 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotAvgFlowRate_Gasohol95_Bay_5 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotAvgFlowRate_Gasohol95_Bay_6 = new OSIsoft.AF.Asset.AFValues[4];

        // 2 - NoOfFailure
        OSIsoft.AF.PI.PIPoint[] pt_NoOfFailure_Diesel_Bay_1 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_NoOfFailure_Diesel_Bay_2 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_NoOfFailure_Diesel_Bay_3 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_NoOfFailure_Diesel_Bay_4 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_NoOfFailure_Gasohol95_Bay_5 = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.PI.PIPoint[] pt_NoOfFailure_Gasohol95_Bay_6 = new OSIsoft.AF.PI.PIPoint[4];

        OSIsoft.AF.Asset.AFValues[] plotNoOfFailure_Diesel_Bay_1 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotNoOfFailure_Diesel_Bay_2 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotNoOfFailure_Diesel_Bay_3 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotNoOfFailure_Diesel_Bay_4 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotNoOfFailure_Gasohol95_Bay_5 = new OSIsoft.AF.Asset.AFValues[4];
        OSIsoft.AF.Asset.AFValues[] plotNoOfFailure_Gasohol95_Bay_6 = new OSIsoft.AF.Asset.AFValues[4];

        // layer 3 : miscellaneous
        // 1 - Diesel 
        OSIsoft.AF.PI.PIPoint[] pt_Remaining_Diesel = new OSIsoft.AF.PI.PIPoint[31];
        OSIsoft.AF.Asset.AFValues[] plotRemaining_Diesel = new OSIsoft.AF.Asset.AFValues[31];
        // 2 - Gasohol95
        OSIsoft.AF.PI.PIPoint[] pt_Remaining_Gasohol95 = new OSIsoft.AF.PI.PIPoint[31];
        OSIsoft.AF.Asset.AFValues[] plotRemaining_Gasohol95 = new OSIsoft.AF.Asset.AFValues[31];
        // 3 - Total Truck In
        OSIsoft.AF.PI.PIPoint[] pt_Total_Truck_In = new OSIsoft.AF.PI.PIPoint[31];
        OSIsoft.AF.Asset.AFValues[] plotTotal_Truck_In = new OSIsoft.AF.Asset.AFValues[31];
        // 4 - Total Truck Out
        OSIsoft.AF.PI.PIPoint[] pt_Total_Truck_Out = new OSIsoft.AF.PI.PIPoint[31];
        OSIsoft.AF.Asset.AFValues[] plotTotal_Truck_Out = new OSIsoft.AF.Asset.AFValues[31];

        // 1
        string Total_Truck_In_1, Total_Truck_In_2, Total_Truck_In_3, Total_Truck_In_4, Total_Truck_In_5, Total_Truck_In_6, Total_Truck_In_7, Total_Truck_In_8, Total_Truck_In_9, Total_Truck_In_10,
    Total_Truck_In_11, Total_Truck_In_12, Total_Truck_In_13, Total_Truck_In_14, Total_Truck_In_15, Total_Truck_In_16, Total_Truck_In_17, Total_Truck_In_18, Total_Truck_In_19, Total_Truck_In_20,
    Total_Truck_In_21, Total_Truck_In_22, Total_Truck_In_23, Total_Truck_In_24, Total_Truck_In_25, Total_Truck_In_26, Total_Truck_In_27, Total_Truck_In_28, Total_Truck_In_29, Total_Truck_In_30, Total_Truck_In_31;
        // 2
        string Total_Truck_Out_1, Total_Truck_Out_2, Total_Truck_Out_3, Total_Truck_Out_4, Total_Truck_Out_5, Total_Truck_Out_6, Total_Truck_Out_7, Total_Truck_Out_8, Total_Truck_Out_9, Total_Truck_Out_10,
    Total_Truck_Out_11, Total_Truck_Out_12, Total_Truck_Out_13, Total_Truck_Out_14, Total_Truck_Out_15, Total_Truck_Out_16, Total_Truck_Out_17, Total_Truck_Out_18, Total_Truck_Out_19, Total_Truck_Out_20,
    Total_Truck_Out_21, Total_Truck_Out_22, Total_Truck_Out_23, Total_Truck_Out_24, Total_Truck_Out_25, Total_Truck_Out_26, Total_Truck_Out_27, Total_Truck_Out_28, Total_Truck_Out_29, Total_Truck_Out_30, Total_Truck_Out_31;
        // Non neccessory to create all shit variables

        // --------------------------------------------------------------------------------------------------------------- // 
        // --------------------------------------------------------------------------------------------------------------- // 
        // MANAGER MANAGER MANAGER MANAGER MANAGER MANAGER MANAGER MANAGER MANAGER MANAGER MANAGER MANAGER MANAGER MANAGER
        // --------------------------------------------------------------------------------------------------------------- // 
        // --------------------------------------------------------------------------------------------------------------- // 
        // layer 1 : super KPI
        // week
        OSIsoft.AF.PI.PIPoint[] pt_DieselSold_Week = new OSIsoft.AF.PI.PIPoint[5]; // 1 *** [4] -> month
        OSIsoft.AF.PI.PIPoint[] pt_Gasohol95Sold_Week = new OSIsoft.AF.PI.PIPoint[5]; // 2 *** [4] -> month

        OSIsoft.AF.Asset.AFValues[] plotValuesDieselWeek = new OSIsoft.AF.Asset.AFValues[5]; // 1 *** [4] -> month
        OSIsoft.AF.Asset.AFValues[] plotValuesGasohol95Week = new OSIsoft.AF.Asset.AFValues[5]; // 2 *** [4] -> month

        // 1 & 2
        string Diesel_Sold_Week_1, Diesel_Sold_Week_2, Diesel_Sold_Week_3, Diesel_Sold_Week_4, Diesel_Sold_Month_1;
        string Gasohol95_Sold_Week_1, Gasohol95_Sold_Week_2, Gasohol95_Sold_Week_3, Gasohol95_Sold_Week_4, Gasohol95_Sold_Month_1;

        // 3
        double[] total_Utilization_Weekly = new double[4];
        double total_Utilization_Monthly = 0.0;
        double utilSum = 0.0;

        // layer 2 : supporter

        // 1 
        // 5 sins of utilization at Denchai Terminal Station - sale office, weigh in/out, diesel, gaosohol95 bay loading
        double utilSaleSum, utilWeighInSum, utilWeighOutSum, utilDieselBayLoadingSum, utilGasohol95BayLoadingSum = 0.0;


        // 2 
        // 5 sins of avg. cycle time at Denchai Terminal Station - sale office, weigh in/out, diesel, gaosohol95 bay loading
        double cycSaleSum, cycWeighInSum, cycWeighOutSum, cycBayLoadingSum = 0.0;

        // 1 
        double[] Sale_Office_Utilization_Weekly = new double[4];
        double[] Weigh_In_Utilization_Weekly = new double[4];
        double[] Weigh_Out_Utilization_Weekly = new double[4];
        double[] Diesel_Bay_Loading_Utilization_Weekly = new double[4];
        double[] Gasohol95_Bay_Loading_Utilization_Weekly = new double[4];

        // 2
        double[] Sale_Office_CycleTime_Weekly = new double[4];
        double[] Weigh_In_CycleTime_Weekly = new double[4];
        double[] Weigh_Out_CycleTime_Weekly = new double[4];
        double[] Bay_Loading_CycleTime_Weekly = new double[4];


        // layer 3 : miscellaneous

        // 1 - Total Truck In and Out Weekly 
        OSIsoft.AF.PI.PIPoint[] pt_Total_Truck_In_Week = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.Asset.AFValues[] plotTotal_Truck_In_Week = new OSIsoft.AF.Asset.AFValues[4];

        OSIsoft.AF.PI.PIPoint[] pt_Total_Truck_In_Month = new OSIsoft.AF.PI.PIPoint[1];
        OSIsoft.AF.Asset.AFValues[] plotTotal_Truck_In_Month = new OSIsoft.AF.Asset.AFValues[1];

        OSIsoft.AF.PI.PIPoint[] pt_Total_Truck_Out_Week = new OSIsoft.AF.PI.PIPoint[4];
        OSIsoft.AF.Asset.AFValues[] plotTotal_Truck_Out_Week = new OSIsoft.AF.Asset.AFValues[4];

        OSIsoft.AF.PI.PIPoint[] pt_Total_Truck_Out_Month = new OSIsoft.AF.PI.PIPoint[1];
        OSIsoft.AF.Asset.AFValues[] plotTotal_Truck_Out_Month = new OSIsoft.AF.Asset.AFValues[1];

        string Total_Truck_In_Week_1, Total_Truck_In_Week_2, Total_Truck_In_Week_3, Total_Truck_In_Week_4;
        string Total_Truck_Out_Week_1, Total_Truck_Out_Week_2, Total_Truck_Out_Week_3, Total_Truck_Out_Week_4;
        string Total_Truck_In_Month_1;
        string Total_Truck_Out_Month_1;



        //.......................................................................................................
        //....OOOOOOO.....PPPPPPPPP...EEEEEEEEEEE.RRRRRRRRRR......AAAAA...AATTTTTTTTTT..OOOOOOO....OORRRRRRRR....
        //...OOOOOOOOOO...PPPPPPPPPP..EEEEEEEEEEE.RRRRRRRRRRR.....AAAAA...AATTTTTTTTTTTOOOOOOOOO...OORRRRRRRRR...
        //..OOOOOOOOOOOO..PPPPPPPPPPP.EEEEEEEEEEE.RRRRRRRRRRR....AAAAAA...AATTTTTTTTTTTOOOOOOOOOO..OORRRRRRRRRR..
        //..OOOOO..OOOOO..PPPP...PPPP.EEEE........RRRR...RRRRR...AAAAAAA......TTTT...TTOOO...OOOOO.OORR....RRRR..
        //.OOOOO....OOOOO.PPPP...PPPP.EEEE........RRRR...RRRRR..AAAAAAAA......TTTT...TTOO.....OOOO.OORR....RRRR..
        //.OOOO......OOOO.PPPPPPPPPPP.EEEEEEEEEE..RRRRRRRRRRR...AAAAAAAA......TTTT..TTTO......OOOO.OORRRRRRRRRR..
        //.OOOO......OOOO.PPPPPPPPPP..EEEEEEEEEE..RRRRRRRRRRR...AAAA.AAAA.....TTTT..TTTO......OOOO.OORRRRRRRRR...
        //.OOOO......OOOO.PPPPPPPPP...EEEEEEEEEE..RRRRRRRR.....AAAAAAAAAA.....TTTT..TTTO......OOOO.OORRRRRRR.....
        //.OOOOO....OOOOO.PPPP........EEEE........RRRR.RRRR....AAAAAAAAAAA....TTTT...TTOO.....OOOO.OORR.RRRRR....
        //..OOOOO..OOOOO..PPPP........EEEE........RRRR..RRRR...AAAAAAAAAAA....TTTT...TTOOO...OOOOO.OORR..RRRRR...
        //..OOOOOOOOOOOO..PPPP........EEEEEEEEEEE.RRRR..RRRRR.RAAA....AAAA....TTTT...TTOOOOOOOOOO..OORR...RRRR...
        //...OOOOOOOOOO...PPPP........EEEEEEEEEEE.RRRR...RRRRRRAAA.....AAAA...TTTT....TOOOOOOOOO...OORR...RRRRR..
        //.....OOOOOO.....PPPP........EEEEEEEEEEE.RRRR....RRRRRAAA.....AAAA...TTTT......OOOOOOO....OORR....RRRR..
        //.......................................................................................................
        public ActionResult DashboardOperator()
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    CONNECT TO PI-SMT                                  ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // Create connection to PI Data archive 
            PIServers servers = new PIServers();
            PIServer piServer = servers["202.44.12.146"];
            var cred = new NetworkCredential("group4", "inc.382");
            piServer.Connect(cred);


            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                        QUERY DATA                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // layer 1 : Super KPI
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>         Layer 1 : SUPER KPI            >>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            // ----------------------------------------------------------------------------------------
            //  DIESEL SOLD (L)
            // ----------------------------------------------------------------------------------------

            // :: REALM OF HELL - FindPiPoint
            // array
            //var pt_DieselSold_Day_1 = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_1.ff160bf0-7d0e-4872-928f-38cc2feef56b");
            pt_DieselSold_Day[0] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_1.ff160bf0-7d0e-4872-928f-38cc2feef56b");
            pt_DieselSold_Day[1] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_2.a42ab22d-13de-4b41-8ebe-01e75b451c1e");
            pt_DieselSold_Day[2] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_3.cb0f6d37-ee81-4cd4-a881-a7c1174cd1f4");
            pt_DieselSold_Day[3] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_4.a9e73ba3-a2a0-43d4-82e8-cd24de2f46b7");
            pt_DieselSold_Day[4] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_5.82c26669-5883-4b67-ab35-ab5c880be974");
            pt_DieselSold_Day[5] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_6.6c35487c-e121-427f-b58c-e2619c5cf8ae");
            pt_DieselSold_Day[6] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_7.0724d998-fe4c-4167-8d48-3489d1655622");
            pt_DieselSold_Day[7] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_8.67751762-9b65-4b07-85f3-9a54470897e6");
            pt_DieselSold_Day[8] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_9.af9f11b4-b30c-4c78-9c94-d831f65b5d1d");
            pt_DieselSold_Day[9] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_10.cbe024e3-3e11-4dc7-a676-06bbfaa52152");
            pt_DieselSold_Day[10] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_11.39d2140f-34e0-4dce-9bab-f3970417d8ee");
            pt_DieselSold_Day[11] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_12.cea7bf63-b7d5-4980-ab51-d56fcab05e0b");
            pt_DieselSold_Day[12] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_13.3ea26163-ee54-495f-ac92-0eb2a39fa327");
            pt_DieselSold_Day[13] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_14.95fa38de-e71b-4c86-8102-886b2127a2ab");
            pt_DieselSold_Day[14] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_15.cdcd39a1-d6cd-42f0-99c6-88708f6a2892");
            pt_DieselSold_Day[15] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_16.e5b20bd9-8acf-424e-bc88-81356af8e2d2");
            pt_DieselSold_Day[16] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_17.a0053b83-ed0b-4736-89c8-153a2649d88b");
            pt_DieselSold_Day[17] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_18.fed80477-0f61-43e2-a1b1-bfc80d733d70");
            pt_DieselSold_Day[18] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_19.4049e902-5101-4a2c-b07a-942fbb9867f5");
            pt_DieselSold_Day[19] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_20.12f37274-81b5-47cf-8c71-484f5fc11a5b");
            pt_DieselSold_Day[20] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_21.3d01dcf3-9342-4610-a11f-cc65cd6bdfa3");
            pt_DieselSold_Day[21] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_22.25bd6fe7-1f00-4b54-b1d1-558eb88e528f");
            pt_DieselSold_Day[22] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_23.24572e03-3b00-4f09-b647-5c4c08f77090");
            pt_DieselSold_Day[23] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_24.fc6ad9cd-0926-4bb4-a014-6240041efe32");
            pt_DieselSold_Day[24] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_25.d67c75fc-c1fa-429b-8f43-3ca217935930");
            pt_DieselSold_Day[25] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_26.5c6af573-9e20-4a6a-8f6b-bc1582a5ce88");
            pt_DieselSold_Day[26] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_27.6e82d56e-9f2d-4ac2-ab7d-738ef18dd9f3");
            pt_DieselSold_Day[27] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_28.7dab36f6-466e-4c2b-9ada-a2d931047df3");
            pt_DieselSold_Day[28] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_29.a3d42e11-6337-4970-ba04-b0f90ef67062");
            pt_DieselSold_Day[29] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_30.d976a107-e698-438d-993c-b7d8f2215ea4");
            pt_DieselSold_Day[30] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_31.150ce001-e5db-427c-9162-8b3de1892cfb");

            // :: REALM OF HELL - SnapShot Godfather 
            //var value_DieselSold_Day_1 = pt_DieselSold_Day_1.CurrentValue(); // Decipher

            // :: Data Container
            IList<getData> Diesel_Sold = new List<getData>(); // Decipher

            // :: Eternity plotValues
            // array then loop
            for (var i = 0; i < 31; i++)
            {
                plotValuesDiesel[i] = pt_DieselSold_Day[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            }
          
            // :: REALM OF HELL - LIST APPEND, SHIT HAPPEN
            foreach (var pValue in plotValuesDiesel[0]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[1]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[2]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[3]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_4 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[4]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_5 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[5]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_6 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[6]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_7= pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[7]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_8 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[8]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_9 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[9]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_10 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[10]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_11 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[11]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_12 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[12]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_13 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[13]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_14 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[14]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_15 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[15]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_16 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[16]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_17 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[17]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_18 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[18]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_19 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[19]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_20 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[20]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_21 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[21]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_22 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[22]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_23 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[23]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_24 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[24]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_25 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[25]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_26 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[26]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_27 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[27]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_28 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[28]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_29 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[29]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_30 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDiesel[30]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_31 = pValue.Value.ToString(); } }

            // :: REALM OF HELL - SESSION GODFATHER
            // loopable
            Session["diesel_sold_1"] = Math.Round((Convert.ToDouble(Diesel_Sold_1)), 2);
            Session["diesel_sold_2"] = Math.Round((Convert.ToDouble(Diesel_Sold_2)), 2);
            Session["diesel_sold_3"] = Math.Round((Convert.ToDouble(Diesel_Sold_3)), 2);
            Session["diesel_sold_4"] = Math.Round((Convert.ToDouble(Diesel_Sold_4)), 2);
            Session["diesel_sold_5"] = Math.Round((Convert.ToDouble(Diesel_Sold_5)), 2);
            Session["diesel_sold_6"] = Math.Round((Convert.ToDouble(Diesel_Sold_6)), 2);
            Session["diesel_sold_7"] = Math.Round((Convert.ToDouble(Diesel_Sold_7)), 2);
            Session["diesel_sold_8"] = Math.Round((Convert.ToDouble(Diesel_Sold_8)), 2);
            Session["diesel_sold_9"] = Math.Round((Convert.ToDouble(Diesel_Sold_9)), 2);
            Session["diesel_sold_10"] = Math.Round((Convert.ToDouble(Diesel_Sold_10)), 2);
            Session["diesel_sold_11"] = Math.Round((Convert.ToDouble(Diesel_Sold_11)), 2);
            Session["diesel_sold_12"] = Math.Round((Convert.ToDouble(Diesel_Sold_12)), 2);
            Session["diesel_sold_13"] = Math.Round((Convert.ToDouble(Diesel_Sold_13)), 2);
            Session["diesel_sold_14"] = Math.Round((Convert.ToDouble(Diesel_Sold_14)), 2);
            Session["diesel_sold_15"] = Math.Round((Convert.ToDouble(Diesel_Sold_15)), 2);
            Session["diesel_sold_16"] = Math.Round((Convert.ToDouble(Diesel_Sold_16)), 2);
            Session["diesel_sold_17"] = Math.Round((Convert.ToDouble(Diesel_Sold_17)), 2);
            Session["diesel_sold_18"] = Math.Round((Convert.ToDouble(Diesel_Sold_18)), 2);
            Session["diesel_sold_19"] = Math.Round((Convert.ToDouble(Diesel_Sold_19)), 2);
            Session["diesel_sold_20"] = Math.Round((Convert.ToDouble(Diesel_Sold_20)), 2);
            Session["diesel_sold_21"] = Math.Round((Convert.ToDouble(Diesel_Sold_21)), 2);
            Session["diesel_sold_22"] = Math.Round((Convert.ToDouble(Diesel_Sold_22)), 2);
            Session["diesel_sold_23"] = Math.Round((Convert.ToDouble(Diesel_Sold_23)), 2);
            Session["diesel_sold_24"] = Math.Round((Convert.ToDouble(Diesel_Sold_24)), 2);
            Session["diesel_sold_25"] = Math.Round((Convert.ToDouble(Diesel_Sold_25)), 2);
            Session["diesel_sold_26"] = Math.Round((Convert.ToDouble(Diesel_Sold_26)), 2);
            Session["diesel_sold_27"] = Math.Round((Convert.ToDouble(Diesel_Sold_27)), 2);
            Session["diesel_sold_28"] = Math.Round((Convert.ToDouble(Diesel_Sold_28)), 2);
            Session["diesel_sold_29"] = Math.Round((Convert.ToDouble(Diesel_Sold_29)), 2);
            Session["diesel_sold_30"] = Math.Round((Convert.ToDouble(Diesel_Sold_30)), 2);
            Session["diesel_sold_31"] = Math.Round((Convert.ToDouble(Diesel_Sold_31)), 2);

            // :: REALM OF HELL - ViewData
            for (var i = 1; i <= 31; i++)
            {
                ViewData["DIESEL_SOLD_" + i] = Session["diesel_sold_" + i];
            }


            // ----------------------------------------------------------------------------------------
            //  GASOHOL95 SOLD (L)
            // ----------------------------------------------------------------------------------------
            // :: REALM OF HELL - FindPiPoint
            // array
            pt_Gasohol95Sold_Day[0] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_1.7f680851-8251-4337-b6f8-6f8ff15dfe62");
            pt_Gasohol95Sold_Day[1] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_2.05a54773-b936-4d05-8c17-fd82f74eb951");
            pt_Gasohol95Sold_Day[2] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_3.8246f1bb-9dc0-4ff0-be06-35594dcb6d35");
            pt_Gasohol95Sold_Day[3] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_4.7d3d6a8f-7360-4fce-8b8f-c3b152d27be6");
            pt_Gasohol95Sold_Day[4] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_5.b848b50c-5f63-4279-a9a2-5ca28b661507");
            pt_Gasohol95Sold_Day[5] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_6.d942d811-0696-4aaf-b250-42cac1003beb");
            pt_Gasohol95Sold_Day[6] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_7.365bd087-8f94-4a6a-8892-cf5679fc0a42");
            pt_Gasohol95Sold_Day[7] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_8.66008f27-4ed3-4dba-bc09-8690a063244a");
            pt_Gasohol95Sold_Day[8] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_9.9ba2f69d-bd44-4bd1-bdc2-37cbc62106a9");
            pt_Gasohol95Sold_Day[9] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_10.8f9b3c1c-075f-4160-be52-a35bd7373ef9");
            pt_Gasohol95Sold_Day[10] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_11.ba5ff869-dac6-425c-8d6e-57b67df53ddf");
            pt_Gasohol95Sold_Day[11] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_12.30e35699-d26b-452d-aa43-0fbe564166d9");
            pt_Gasohol95Sold_Day[12] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_13.e5b97811-4ff6-4382-9b8f-410e8c715afe");
            pt_Gasohol95Sold_Day[13] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_14.a9656eb1-7d4a-4c3a-b665-8c2d9a6a7cc2");
            pt_Gasohol95Sold_Day[14] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_15.06825548-9431-4825-b6ec-53033d0c2d4f");
            pt_Gasohol95Sold_Day[15] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_16.efeb803d-52d8-4508-a50d-a036925a4b76");
            pt_Gasohol95Sold_Day[16] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_17.73fb5765-96bc-4a75-ab50-852445f72719");
            pt_Gasohol95Sold_Day[17] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_18.bcf4a721-6541-4bef-a6a4-4e7f617d78c7");
            pt_Gasohol95Sold_Day[18] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_19.5a73409f-1c54-4bbf-a51b-afed81df9c29");
            pt_Gasohol95Sold_Day[19] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_20.9da09498-8796-4397-9928-69eb03612ede");
            pt_Gasohol95Sold_Day[20] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_21.d0e2679b-dc6d-4697-95ca-af00247cb20e");
            pt_Gasohol95Sold_Day[21] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_22.60529aab-7e66-4e90-afb8-671f9f3a087d");
            pt_Gasohol95Sold_Day[22] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_23.1448a038-ed14-42c1-9381-b30cb13de166");
            pt_Gasohol95Sold_Day[23] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_24.980a89c7-4b66-4e02-9c54-f07d5abfec4a");
            pt_Gasohol95Sold_Day[24] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_25.15d7c48e-e437-4d52-bb71-e3c9cf043950");
            pt_Gasohol95Sold_Day[25] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_26.4ff48339-24da-42c3-878d-c50169f0da3b");
            pt_Gasohol95Sold_Day[26] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_27.94666499-e5c7-4eeb-af6a-037d0cce8239");
            pt_Gasohol95Sold_Day[27] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_28.39710441-0941-4372-8b8e-3ce0fb6a6ff0");
            pt_Gasohol95Sold_Day[28] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_29.d7797c57-f3a4-4965-a549-21c27e8bab4d");
            pt_Gasohol95Sold_Day[29] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_30.f15060c3-b9ab-4872-973e-744b85f26720");
            pt_Gasohol95Sold_Day[30] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_31.b5131cbd-c8a4-46db-a869-aee178320b8a");

            // :: REALM OF HELL - SnapShot Godfather 
            //var value_DieselSold_Day_1 = pt_Gasohol95Sold_Day_1.CurrentValue(); // Decipher

            // :: Data Container
            IList<getData> Gasohol95_Sold = new List<getData>(); // Decipher

            // :: Eternity plotValues
            // array then loop
            for (var i = 0; i < 31; i++)
            {
                plotValuesGasohol95[i] = pt_Gasohol95Sold_Day[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            }

            // :: REALM OF HELL - LIST APPEND, SHIT HAPPEN
            foreach (var pValue in plotValuesGasohol95[0]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[1]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[2]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[3]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_4 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[4]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_5 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[5]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_6 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[6]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_7 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[7]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_8 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[8]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_9 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[9]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_10 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[10]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_11 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[11]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_12 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[12]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_13 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[13]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_14 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[14]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_15 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[15]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_16 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[16]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_17 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[17]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_18 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[18]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_19 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[19]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_20 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[20]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_21 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[21]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_22 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[22]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_23 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[23]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_24 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[24]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_25 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[25]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_26 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[26]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_27 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[27]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_28 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[28]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_29 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[29]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_30 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95[30]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_31 = pValue.Value.ToString(); } }

            // :: REALM OF HELL - SESSION GODFATHER
            // loopable
            Session["gasohol95_sold_1"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_1)), 2);
            Session["gasohol95_sold_2"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_2)), 2);
            Session["gasohol95_sold_3"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_3)), 2);
            Session["gasohol95_sold_4"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_4)), 2);
            Session["gasohol95_sold_5"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_5)), 2);
            Session["gasohol95_sold_6"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_6)), 2);
            Session["gasohol95_sold_7"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_7)), 2);
            Session["gasohol95_sold_8"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_8)), 2);
            Session["gasohol95_sold_9"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_9)), 2);
            Session["gasohol95_sold_10"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_10)), 2);
            Session["gasohol95_sold_11"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_11)), 2);
            Session["gasohol95_sold_12"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_12)), 2);
            Session["gasohol95_sold_13"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_13)), 2);
            Session["gasohol95_sold_14"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_14)), 2);
            Session["gasohol95_sold_15"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_15)), 2);
            Session["gasohol95_sold_16"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_16)), 2);
            Session["gasohol95_sold_17"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_17)), 2);
            Session["gasohol95_sold_18"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_18)), 2);
            Session["gasohol95_sold_19"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_19)), 2);
            Session["gasohol95_sold_20"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_20)), 2);
            Session["gasohol95_sold_21"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_21)), 2);
            Session["gasohol95_sold_22"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_22)), 2);
            Session["gasohol95_sold_23"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_23)), 2);
            Session["gasohol95_sold_24"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_24)), 2);
            Session["gasohol95_sold_25"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_25)), 2);
            Session["gasohol95_sold_26"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_26)), 2);
            Session["gasohol95_sold_27"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_27)), 2);
            Session["gasohol95_sold_28"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_28)), 2);
            Session["gasohol95_sold_29"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_29)), 2);
            Session["gasohol95_sold_30"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_30)), 2);
            Session["gasohol95_sold_31"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_31)), 2);

            // :: REALM OF HELL - ViewData 
            for (var i = 1; i <= 31; i++)
            {
                ViewData["GASOHOL95_sold_" + i] = Session["gasohol95_sold_" + i];
            }


            // ----------------------------------------------------------------------------------------
            //  AVG. CT. OF DIESEL DISPENSER
            // ----------------------------------------------------------------------------------------

            // :: REALM OF HELL - FindPiPoint
            // array
            pt_AvgCTDieselDispenser_Day[0] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_1.e0416b6f-cf75-4cf5-b39a-2166d2140d6c");
            pt_AvgCTDieselDispenser_Day[1] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_2.17039c2e-5d78-46f1-90c7-836bc383853c");
            pt_AvgCTDieselDispenser_Day[2] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_3.2e029de7-96dc-4e2d-8c5c-f55773bdc260");
            pt_AvgCTDieselDispenser_Day[3] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_4.84cea1c6-5145-40a1-837a-39e546692e45");
            pt_AvgCTDieselDispenser_Day[4] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_5.11a7c2ba-9251-454e-9810-5a5baa4cce19");
            pt_AvgCTDieselDispenser_Day[5] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_6.69e9006f-4ee6-4427-aac1-75bffb85174a");
            pt_AvgCTDieselDispenser_Day[6] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_7.e5544feb-5720-4395-b9f6-55d83cdf86d9");
            pt_AvgCTDieselDispenser_Day[7] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_8.b86bee9d-214c-4ae0-979d-8d710b79d024");
            pt_AvgCTDieselDispenser_Day[8] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_9.50168bbc-d317-40ad-a6e0-6f91c05a9c21");
            pt_AvgCTDieselDispenser_Day[9] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_10.3462bbda-208e-4df7-b177-d5dcd22c1886");
            pt_AvgCTDieselDispenser_Day[10] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_11.1d35c43a-d812-405d-b15e-52e2c0cb0dcb");
            pt_AvgCTDieselDispenser_Day[11] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_12.b518cb14-9c0e-497d-9e93-d02f916d5e00");
            pt_AvgCTDieselDispenser_Day[12] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_13.fd4b9b51-b914-45b9-b824-0fae5cd16370");
            pt_AvgCTDieselDispenser_Day[13] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_14.25501411-570a-48ca-aeb9-b99f7c9cbdac");
            pt_AvgCTDieselDispenser_Day[14] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_15.b3bf95da-e4ef-4512-a16e-7a582260c8a5");
            pt_AvgCTDieselDispenser_Day[15] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_16.2b652cdf-edaf-49c1-91ab-4a428c1e1528");
            pt_AvgCTDieselDispenser_Day[16] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_17.cd75cedb-b491-4a52-a611-301de1a37b94");
            pt_AvgCTDieselDispenser_Day[17] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_18.a79ef269-38a4-412a-a6bd-c19a6511354b");
            pt_AvgCTDieselDispenser_Day[18] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_19.81b418ff-7242-4496-8dd9-ee8e22547c4e");
            pt_AvgCTDieselDispenser_Day[19] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_20.86100b39-581d-473d-b3ab-0b7cfd7364a3");
            pt_AvgCTDieselDispenser_Day[20] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_21.41dee073-8287-41e3-a673-8663499580cd");
            pt_AvgCTDieselDispenser_Day[21] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_22.2fcb01c2-cca1-4958-901e-aea5194d9ae5");
            pt_AvgCTDieselDispenser_Day[22] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_23.7d35ac20-2831-47b5-af54-fcc0f06d7604");
            pt_AvgCTDieselDispenser_Day[23] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_24.c8e58e26-b4f1-44db-b924-e6c6973a486f");
            pt_AvgCTDieselDispenser_Day[24] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_25.e24f4edb-645b-4ed2-a509-478d81819445");
            pt_AvgCTDieselDispenser_Day[25] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_26.640a1bc9-9190-4640-9d15-a3fc65b7a693");
            pt_AvgCTDieselDispenser_Day[26] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_27.1ebc9a4f-7a54-4b3c-a84a-8077b1da6416");
            pt_AvgCTDieselDispenser_Day[27] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_28.f106f595-39f7-42f9-ba49-3975fd785d95");
            pt_AvgCTDieselDispenser_Day[28] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_29.6b4b57e7-87c4-4cdd-8f3d-55831454cbb7");
            pt_AvgCTDieselDispenser_Day[29] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_30.5620c3b9-fe03-439d-9609-bc96848e8ced");
            pt_AvgCTDieselDispenser_Day[30] = PIPoint.FindPIPoint(piServer, "_G4_Avg cycle time diesel.G4-A004-69-0100-002_31.71184a54-b760-47e1-b479-f9f9ec48088e");

            // :: REALM OF HELL - SnapShot Godfather 
            //var value_DieselSold_Day_1 = pt_AvgCTDieselDispenser_Day_1.CurrentValue(); // Decipher

            // :: Data Container
            IList<getData> AvgCTDieselDispenser = new List<getData>(); // Decipher

            // :: Eternity plotValues
            // array then loop
            for (var i = 0; i < 31; i++)
            {
                plotAvgCTDieselDispenser[i] = pt_AvgCTDieselDispenser_Day[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            }

            // :: REALM OF HELL - LIST APPEND, SHIT HAPPEN
            foreach (var pValue in plotAvgCTDieselDispenser[0]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[1]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[2]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[3]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_4 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[4]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_5 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[5]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_6 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[6]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_7 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[7]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_8 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[8]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_9 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[9]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_10 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[10]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_11 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[11]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_12 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[12]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_13 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[13]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_14 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[14]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_15 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[15]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_16 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[16]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_17 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[17]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_18 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[18]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_19 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[19]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_20 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[20]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_21 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[21]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_22 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[22]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_23 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[23]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_24 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[24]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_25 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[25]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_26 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[26]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_27 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[27]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_28 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[28]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_29 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[29]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_30 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTDieselDispenser[30]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Diesel_Dispenser_31 = pValue.Value.ToString(); } }

            // :: REALM OF HELL - SESSION GODFATHER
            // loopable
            Session["avg_ct_diesel_dispenser_1"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_1)), 2);
            Session["avg_ct_diesel_dispenser_2"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_2)), 2);
            Session["avg_ct_diesel_dispenser_3"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_3)), 2);
            Session["avg_ct_diesel_dispenser_4"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_4)), 2);
            Session["avg_ct_diesel_dispenser_5"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_5)), 2);
            Session["avg_ct_diesel_dispenser_6"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_6)), 2);
            Session["avg_ct_diesel_dispenser_7"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_7)), 2);
            Session["avg_ct_diesel_dispenser_8"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_8)), 2);
            Session["avg_ct_diesel_dispenser_9"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_9)), 2);
            Session["avg_ct_diesel_dispenser_10"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_10)), 2);
            Session["avg_ct_diesel_dispenser_11"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_11)), 2);
            Session["avg_ct_diesel_dispenser_12"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_12)), 2);
            Session["avg_ct_diesel_dispenser_13"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_13)), 2);
            Session["avg_ct_diesel_dispenser_14"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_14)), 2);
            Session["avg_ct_diesel_dispenser_15"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_15)), 2);
            Session["avg_ct_diesel_dispenser_16"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_16)), 2);
            Session["avg_ct_diesel_dispenser_17"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_17)), 2);
            Session["avg_ct_diesel_dispenser_18"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_18)), 2);
            Session["avg_ct_diesel_dispenser_19"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_19)), 2);
            Session["avg_ct_diesel_dispenser_20"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_20)), 2);
            Session["avg_ct_diesel_dispenser_21"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_21)), 2);
            Session["avg_ct_diesel_dispenser_22"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_22)), 2);
            Session["avg_ct_diesel_dispenser_23"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_23)), 2);
            Session["avg_ct_diesel_dispenser_24"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_24)), 2);
            Session["avg_ct_diesel_dispenser_25"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_25)), 2);
            Session["avg_ct_diesel_dispenser_26"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_26)), 2);
            Session["avg_ct_diesel_dispenser_27"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_27)), 2);
            Session["avg_ct_diesel_dispenser_28"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_28)), 2);
            Session["avg_ct_diesel_dispenser_29"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_29)), 2);
            Session["avg_ct_diesel_dispenser_30"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_30)), 2);
            Session["avg_ct_diesel_dispenser_31"] = Math.Round((Convert.ToDouble(Avg_CT_Diesel_Dispenser_31)), 2);

            // :: REALM OF HELL - ViewData
            for (var i = 1; i <= 31; i++)
            {
                ViewData["AVG_CT_DIESEL_DISPENSER_" + i] = Session["avg_ct_diesel_dispenser_" + i];
            }


            // ----------------------------------------------------------------------------------------
            //  AVG. CT. OF GASOHOL95 DISPENSER
            // ----------------------------------------------------------------------------------------

            // :: REALM OF HELL - FindPiPoint
            // array
            pt_AvgCTGasohol95Dispenser_Day[0] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_1.18346149-012f-4b61-88e1-f54713e1f72b");
            pt_AvgCTGasohol95Dispenser_Day[1] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_2.b2c52e4b-7536-47e9-988a-3a2085e7c3af");
            pt_AvgCTGasohol95Dispenser_Day[2] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_3.88937824-4dce-4cbb-9e20-439574f114cc");
            pt_AvgCTGasohol95Dispenser_Day[3] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_4.8b5c0fa7-25e9-4227-bd5c-194c16e2cf0b");
            pt_AvgCTGasohol95Dispenser_Day[4] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_5.68fae689-1e8b-4668-8e71-b57f540851de");
            pt_AvgCTGasohol95Dispenser_Day[5] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_6.9084f00e-1b25-4711-b0e2-73b944db7ad8");
            pt_AvgCTGasohol95Dispenser_Day[6] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_7.333eb0b5-b146-479f-a808-04954e367465");
            pt_AvgCTGasohol95Dispenser_Day[7] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_8.34bcfb70-8847-41f5-9f99-ca1a5d9d727a");
            pt_AvgCTGasohol95Dispenser_Day[8] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_9.6f38275b-a797-4f49-8af0-ce6b3e56b394");
            pt_AvgCTGasohol95Dispenser_Day[9] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_10.5bedce16-2d06-48b7-b70a-af74eec1b202");
            pt_AvgCTGasohol95Dispenser_Day[10] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_11.cf253558-9cb4-47a1-9aac-53b036749e65");
            pt_AvgCTGasohol95Dispenser_Day[11] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_12.c498d47d-569d-4bc4-b27d-63f5adc7eed7");
            pt_AvgCTGasohol95Dispenser_Day[12] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_13.2bb5777f-103e-4049-89ed-ef281330b50d");
            pt_AvgCTGasohol95Dispenser_Day[13] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_14.4a7a8587-7fd7-4e1a-8989-7c94c55a1fbc");
            pt_AvgCTGasohol95Dispenser_Day[14] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_15.d1987790-f96a-4bda-9e55-e9e572d64aff");
            pt_AvgCTGasohol95Dispenser_Day[15] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_16.f8e518c5-1040-4af5-a968-ce4d559721af");
            pt_AvgCTGasohol95Dispenser_Day[16] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_17.e50fc395-2e84-412e-9135-da793e60ee20");
            pt_AvgCTGasohol95Dispenser_Day[17] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_18.1da8cd5f-a99c-4ee6-a451-a3ea80bb8dde");
            pt_AvgCTGasohol95Dispenser_Day[18] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_19.22d7f2cb-1305-40a0-a852-5670e071954e");
            pt_AvgCTGasohol95Dispenser_Day[19] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_20.ba44bdf8-7ad8-41fc-bd6e-dbb79a17a5e4");
            pt_AvgCTGasohol95Dispenser_Day[20] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_21.5dba574c-fc0e-498f-9846-01706be901c2");
            pt_AvgCTGasohol95Dispenser_Day[21] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_22.d6ec0231-1b5f-4b35-a9f8-a4c2112cdd72");
            pt_AvgCTGasohol95Dispenser_Day[22] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_23.a7a48ff3-3a92-4145-9ed5-fcbf4e5c38ac");
            pt_AvgCTGasohol95Dispenser_Day[23] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_24.3874b75a-db2f-4fd3-a6ea-c150dfbc234a");
            pt_AvgCTGasohol95Dispenser_Day[24] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_25.d9532fed-cec1-4e9a-986f-65a89416d20e");
            pt_AvgCTGasohol95Dispenser_Day[25] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_26.bf020d80-7a19-4104-b6fc-12c97d401cbb");
            pt_AvgCTGasohol95Dispenser_Day[26] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_27.d92024cc-9c9c-4d13-a644-abe2c9886b6d");
            pt_AvgCTGasohol95Dispenser_Day[27] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_28.6a2faad2-694a-46d1-93fa-6d1b822b0934");
            pt_AvgCTGasohol95Dispenser_Day[28] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_29.e68c1e2c-6ed4-40dc-8ae7-6906a02ff845");
            pt_AvgCTGasohol95Dispenser_Day[29] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_30.f1954b7d-7935-4d53-a41e-1c4cdd9dc75e");
            pt_AvgCTGasohol95Dispenser_Day[30] = PIPoint.FindPIPoint(piServer, "Average cycle time at gasohol95 bay loading in day/week/month.G4-A004-69-0100-003_31.20e30e03-9449-4dd1-89cd-55047396de57");

            // :: REALM OF HELL - SnapShot Godfather 
            //var value_DieselSold_Day_1 = pt_AvgCTGasohol95Dispenser_Day_1.CurrentValue(); // Decipher

            // :: Data Container
            IList<getData> AvgCTGasohol95Dispenser = new List<getData>(); // Decipher

            // :: Eternity plotValues
            // array then loop
            for (var i = 0; i < 31; i++)
            {
                plotAvgCTGasohol95Dispenser[i] = pt_AvgCTGasohol95Dispenser_Day[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            }

            // :: REALM OF HELL - LIST APPEND, SHIT HAPPEN
            foreach (var pValue in plotAvgCTGasohol95Dispenser[0]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[1]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[2]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[3]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_4 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[4]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_5 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[5]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_6 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[6]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_7 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[7]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_8 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[8]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_9 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[9]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_10 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[10]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_11 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[11]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_12 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[12]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_13 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[13]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_14 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[14]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_15 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[15]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_16 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[16]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_17 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[17]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_18 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[18]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_19 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[19]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_20 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[20]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_21 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[21]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_22 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[22]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_23 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[23]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_24 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[24]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_25 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[25]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_26 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[26]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_27 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[27]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_28 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[28]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_29 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[29]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_30 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgCTGasohol95Dispenser[30]) { if (pValue.Value.ToString() != "No Data") { Avg_CT_Gasohol95_Dispenser_31 = pValue.Value.ToString(); } }

            // :: REALM OF HELL - SESSION GODFATHER
            // loopable
            Session["avg_ct_gasohol95_dispenser_1"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_1)), 2);
            Session["avg_ct_gasohol95_dispenser_2"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_2)), 2);
            Session["avg_ct_gasohol95_dispenser_3"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_3)), 2);
            Session["avg_ct_gasohol95_dispenser_4"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_4)), 2);
            Session["avg_ct_gasohol95_dispenser_5"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_5)), 2);
            Session["avg_ct_gasohol95_dispenser_6"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_6)), 2);
            Session["avg_ct_gasohol95_dispenser_7"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_7)), 2);
            Session["avg_ct_gasohol95_dispenser_8"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_8)), 2);
            Session["avg_ct_gasohol95_dispenser_9"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_9)), 2);
            Session["avg_ct_gasohol95_dispenser_10"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_10)), 2);
            Session["avg_ct_gasohol95_dispenser_11"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_11)), 2);
            Session["avg_ct_gasohol95_dispenser_12"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_12)), 2);
            Session["avg_ct_gasohol95_dispenser_13"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_13)), 2);
            Session["avg_ct_gasohol95_dispenser_14"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_14)), 2);
            Session["avg_ct_gasohol95_dispenser_15"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_15)), 2);
            Session["avg_ct_gasohol95_dispenser_16"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_16)), 2);
            Session["avg_ct_gasohol95_dispenser_17"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_17)), 2);
            Session["avg_ct_gasohol95_dispenser_18"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_18)), 2);
            Session["avg_ct_gasohol95_dispenser_19"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_19)), 2);
            Session["avg_ct_gasohol95_dispenser_20"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_20)), 2);
            Session["avg_ct_gasohol95_dispenser_21"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_21)), 2);
            Session["avg_ct_gasohol95_dispenser_22"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_22)), 2);
            Session["avg_ct_gasohol95_dispenser_23"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_23)), 2);
            Session["avg_ct_gasohol95_dispenser_24"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_24)), 2);
            Session["avg_ct_gasohol95_dispenser_25"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_25)), 2);
            Session["avg_ct_gasohol95_dispenser_26"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_26)), 2);
            Session["avg_ct_gasohol95_dispenser_27"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_27)), 2);
            Session["avg_ct_gasohol95_dispenser_28"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_28)), 2);
            Session["avg_ct_gasohol95_dispenser_29"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_29)), 2);
            Session["avg_ct_gasohol95_dispenser_30"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_30)), 2);
            Session["avg_ct_gasohol95_dispenser_31"] = Math.Round((Convert.ToDouble(Avg_CT_Gasohol95_Dispenser_31)), 2);

            // :: REALM OF HELL - ViewData 
            for (var i = 1; i <= 31; i++)
            {
                ViewData["AVG_CT_GASOHOL95_DISPENSER_" + i] = Session["avg_ct_gasohol95_dispenser_" + i];
            }


            // layer 2 : supporter
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>         Layer 2 : SUPPORTER            >>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // ----------------------------------------------------------------------------------------
            //  Avg. Flow Rate of Diesels (bay 1-4) and Gasohol95 (bay 5-6)  (L)
            // ----------------------------------------------------------------------------------------
            // :: 1.) REALM OF HELL - FindPiPoint
            // array
            // AvgFlowRate
            pt_AvgFlowRate_Diesel_Bay_1[0] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 1.G4-A004-69-0100-007_1.29cb18e5-f370-4aaa-a2a1-867aa85864bb");
            pt_AvgFlowRate_Diesel_Bay_1[1] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 1.G4-A004-69-0100-007_2.56ac0930-6ffd-4e17-ac28-6fa4a486b3b6");
            pt_AvgFlowRate_Diesel_Bay_1[2] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 1.G4-A004-69-0100-007_3.4fa0f1ae-b051-434b-a39a-fccf098ea5bc");
            pt_AvgFlowRate_Diesel_Bay_1[3] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 1.G4-A004-69-0100-007_4.6bf3c017-8a70-427e-8ba9-470402adcf29");

            pt_AvgFlowRate_Diesel_Bay_2[0] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 2.G4-A004-69-0100-008_1.467ad9ad-214f-4c2d-926e-c08528119562");
            pt_AvgFlowRate_Diesel_Bay_2[1] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 2.G4-A004-69-0100-008_2.a6a9ad16-f632-4692-bad9-2fd50be91d0c");
            pt_AvgFlowRate_Diesel_Bay_2[2] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 2.G4-A004-69-0100-008_3.dc2cdd0c-0646-4a3e-bc8b-2377ab95d156");
            pt_AvgFlowRate_Diesel_Bay_2[3] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 2.G4-A004-69-0100-008_4.eeafa37c-995c-418d-9951-8d285ce6327b");

            pt_AvgFlowRate_Diesel_Bay_3[0] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 3.G4-A004-69-0100-009_1.96ed68a4-5bf1-4280-b119-6e1cd602fdec");
            pt_AvgFlowRate_Diesel_Bay_3[1] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 3.G4-A004-69-0100-009_2.a1dbcd6e-73fe-4dbb-8e7e-cacdd2317ba0");
            pt_AvgFlowRate_Diesel_Bay_3[2] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 3.G4-A004-69-0100-009_3.936c9983-6439-4194-bca4-86a8823699ce");
            pt_AvgFlowRate_Diesel_Bay_3[3] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 3.G4-A004-69-0100-009_4.bec9bfdf-30d2-4aba-9147-8b879178fff8");

            pt_AvgFlowRate_Diesel_Bay_4[0] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 4.G4-A004-69-0100-010_1.daaed938-e60e-4778-9e47-25f77db6b6c2");
            pt_AvgFlowRate_Diesel_Bay_4[1] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 4.G4-A004-69-0100-010_2.1728f1e9-c1dd-47ff-9042-7da60b2eee7b");
            pt_AvgFlowRate_Diesel_Bay_4[2] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 4.G4-A004-69-0100-010_3.486c25c0-dea3-492c-bc54-a77a570cd987");
            pt_AvgFlowRate_Diesel_Bay_4[3] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of diesel dispenser 4.G4-A004-69-0100-010_4.d80d84c4-7790-42fd-9cb1-1d2e93db2b4b");

            pt_AvgFlowRate_Gasohol95_Bay_5[0] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of gasohol95 dispenser 1.G4-A004-69-0100-011_1.5e56874c-35e6-41a0-8a2d-39647e6283a3");
            pt_AvgFlowRate_Gasohol95_Bay_5[1] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of gasohol95 dispenser 1.G4-A004-69-0100-011_2.0e27b639-299d-4074-899a-e6e16433f75c");
            pt_AvgFlowRate_Gasohol95_Bay_5[2] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of gasohol95 dispenser 1.G4-A004-69-0100-011_3.2ca7c561-f6d7-454f-8184-5d27ae899d86");
            pt_AvgFlowRate_Gasohol95_Bay_5[3] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of gasohol95 dispenser 1.G4-A004-69-0100-011_4.29d44d2d-5256-4129-8b3d-843f05de5dba");

            pt_AvgFlowRate_Gasohol95_Bay_6[0] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of gasohol95 dispenser 2.G4-A004-69-0100-012_1.abed5a9c-4f51-4d12-b3d1-a0b676dca52d");
            pt_AvgFlowRate_Gasohol95_Bay_6[1] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of gasohol95 dispenser 2.G4-A004-69-0100-012_2.f8587839-54c6-4566-a181-b4e8b00f13e2");
            pt_AvgFlowRate_Gasohol95_Bay_6[2] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of gasohol95 dispenser 2.G4-A004-69-0100-012_3.1479be59-4248-46e8-a906-1dba38a69336");
            pt_AvgFlowRate_Gasohol95_Bay_6[3] = PIPoint.FindPIPoint(piServer, "_G4_Avg flow rate of gasohol95 dispenser 2.G4-A004-69-0100-012_4.7c04a4ca-cdaf-47a7-8409-440c00873841");


            // NoOfFailure
            pt_NoOfFailure_Diesel_Bay_1[0] = PIPoint.FindPIPoint(piServer, "G4-A004-38-0100-018");
            pt_NoOfFailure_Diesel_Bay_2[0] = PIPoint.FindPIPoint(piServer, "G4-A004-38-0100-019");
            pt_NoOfFailure_Diesel_Bay_3[0] = PIPoint.FindPIPoint(piServer, "G4-A004-38-0100-020");
            pt_NoOfFailure_Diesel_Bay_4[0] = PIPoint.FindPIPoint(piServer, "G4-A004-38-0100-021");
            pt_NoOfFailure_Gasohol95_Bay_5[0] = PIPoint.FindPIPoint(piServer, "G4-A004-38-0100-022");
            pt_NoOfFailure_Gasohol95_Bay_6[0] = PIPoint.FindPIPoint(piServer, "G4-A004-38-0100-023");


            // :: REALM OF HELL - SnapShot Godfather 
            //var value_DieselSold_Day_1 = pt_DieselSold_Day_1.CurrentValue(); // Decipher

            // :: Data Container
            IList<getData> AvgFlowRate_Diesel = new List<getData>(); // Decipher
            IList<getData> AvgFlowRate_Gasohol95 = new List<getData>(); // Decipher
            IList<getData> NoOfFailure_Diesel = new List<getData>(); // Decipher
            IList<getData> NoOfFailure_Gasohol95 = new List<getData>(); // Decipher


            // :: Eternity plotValues
            // array then loop, null after 4
            for (var i = 0; i < 4; i++) // 4 available
            {
                // AvgFlowRate
                plotAvgFlowRate_Diesel_Bay_1[i] = pt_AvgFlowRate_Diesel_Bay_1[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotAvgFlowRate_Diesel_Bay_2[i] = pt_AvgFlowRate_Diesel_Bay_2[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotAvgFlowRate_Diesel_Bay_3[i] = pt_AvgFlowRate_Diesel_Bay_3[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotAvgFlowRate_Diesel_Bay_4[i] = pt_AvgFlowRate_Diesel_Bay_4[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotAvgFlowRate_Gasohol95_Bay_5[i] = pt_AvgFlowRate_Gasohol95_Bay_5[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotAvgFlowRate_Gasohol95_Bay_6[i] = pt_AvgFlowRate_Gasohol95_Bay_6[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            }
                // NoOfFailure
                plotNoOfFailure_Diesel_Bay_1[0] = pt_NoOfFailure_Diesel_Bay_1[0].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotNoOfFailure_Diesel_Bay_2[0] = pt_NoOfFailure_Diesel_Bay_2[0].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotNoOfFailure_Diesel_Bay_3[0] = pt_NoOfFailure_Diesel_Bay_3[0].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotNoOfFailure_Diesel_Bay_4[0] = pt_NoOfFailure_Diesel_Bay_4[0].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotNoOfFailure_Gasohol95_Bay_5[0] = pt_NoOfFailure_Diesel_Bay_4[0].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotNoOfFailure_Gasohol95_Bay_6[0] = pt_NoOfFailure_Diesel_Bay_4[0].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);


            

            // :: REALM OF HELL - LIST APPEND, SHIT HAPPEN

            // AvgFlowRate
            // plotAvgFlowRate_Diesel_Bay_1, day 1 to day 30 (4)
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_1[0]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_1_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_1[1]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_1_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_1[2]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_1_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_1[3]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_1_4 = pValue.Value.ToString(); } }
            // plotAvgFlowRate_Diesel_Bay_2, day 1 to day 30 (4)
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_2[0]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_2_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_2[1]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_2_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_2[2]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_2_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_2[3]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_2_4 = pValue.Value.ToString(); } }
            // plotAvgFlowRate_Diesel_Bay_3, day 1 to day 30 (4)
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_3[0]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_3_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_3[1]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_3_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_3[2]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_3_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_3[3]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_3_4 = pValue.Value.ToString(); } }
            // plotAvgFlowRate_Diesel_Bay_4, day 1 to day 30 (4)
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_4[0]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_4_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_4[1]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_4_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_4[2]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_4_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Diesel_Bay_4[3]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Diesel_Bay_4_4 = pValue.Value.ToString(); } }
            // plotAvgFlowRate_Gasohol95_Bay_5, day 1 to day 30 (4)
            foreach (var pValue in plotAvgFlowRate_Gasohol95_Bay_5[0]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Gasohol95_Bay_5_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Gasohol95_Bay_5[1]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Gasohol95_Bay_5_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Gasohol95_Bay_5[2]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Gasohol95_Bay_5_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Gasohol95_Bay_5[3]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Gasohol95_Bay_5_4 = pValue.Value.ToString(); } }
            // plotAvgFlowRate_Gasohol95_Bay_6, day 1 to day 30 (4)
            foreach (var pValue in plotAvgFlowRate_Gasohol95_Bay_6[0]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Gasohol95_Bay_6_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Gasohol95_Bay_6[1]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Gasohol95_Bay_6_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Gasohol95_Bay_6[2]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Gasohol95_Bay_6_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotAvgFlowRate_Gasohol95_Bay_6[3]) { if (pValue.Value.ToString() != "No Data") { Avg_Flow_Rate_Gasohol95_Bay_6_4 = pValue.Value.ToString(); } }

            // NoOfFailure
            foreach (var pValue in plotNoOfFailure_Diesel_Bay_1[0]) { if (pValue.Value.ToString() != "No Data") { No_of_Failure_Diesel_Bay_1_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotNoOfFailure_Diesel_Bay_2[0]) { if (pValue.Value.ToString() != "No Data") { No_of_Failure_Diesel_Bay_2_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotNoOfFailure_Diesel_Bay_3[0]) { if (pValue.Value.ToString() != "No Data") { No_of_Failure_Diesel_Bay_3_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotNoOfFailure_Diesel_Bay_4[0]) { if (pValue.Value.ToString() != "No Data") { No_of_Failure_Diesel_Bay_4_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotNoOfFailure_Gasohol95_Bay_5[0]) { if (pValue.Value.ToString() != "No Data") { No_of_Failure_Gasohol95_Bay_5_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotNoOfFailure_Gasohol95_Bay_6[0]) { if (pValue.Value.ToString() != "No Data") { No_of_Failure_Gasohol95_Bay_6_1 = pValue.Value.ToString(); } }

            // :: REALM OF HELL - SESSION GODFATHER
            // loopable

            // flow rate
            double[] flowset_1 = {200.47, 203.34, 195.77, 199.68, 199.79, 197.93, 201.92, 195.17, 201.40,
                199.12, 200.06, 201.79, 196.68, 197.02, 204.95, 196.13, 196.07, 200.71, 196.07, 195.63,
                197.61, 200.96, 204.14, 200.01, 195.37, 202.99, 204.71 };

            double[] flowset_2 = {204.24, 202.16, 199.58, 199.06, 203.42, 204.35, 200.57, 201.01, 204.27,
                199.12, 203.32, 199.75, 201.98, 201.71, 203.41, 202.37, 197.62, 200.26, 197.31, 198.93, 200.54, 204.14,
                197.55, 199.18, 196.16, 195.29, 197.59};

            double[] flowset_3 = {202.51, 200.27, 196.88, 198.82, 200.93, 199.24, 199.10, 201.84, 200.97,
                196.49, 196.47, 200.07, 201.94, 199.83, 203.73, 202.44, 200.49, 201.85,
                201.57, 197.82, 196.11, 197.40, 202.78, 204.40, 195.22, 196.51, 197.17};

            double[] flowset_4 = {197.15, 198.02, 200.67, 199.45, 196.74, 196.78, 196.00, 196.25, 195.28,
                202.55, 199.00, 199.69, 203.89, 198.13, 197.96, 195.46, 196.52, 204.86,
                203.69, 201.56, 197.59, 202.45, 200.47, 202.01, 198.51, 197.50, 198.18};

            double[] flowset_5 = {203.24, 198.17, 199.48, 204.47, 196.62, 197.82, 196.85, 202.56, 203.14,
                195.67, 196.73, 204.04, 196.66, 201.27, 203.90, 204.28, 200.99, 195.73,
                203.86, 199.66, 199.88, 196.17, 203.88, 203.98, 202.50, 197.62, 197.24};

            double[] flowset_6 = {204.99, 202.29, 199.54, 203.92, 201.13, 204.90, 198.90, 202.63, 203.07,
                203.31, 195.73, 197.77, 195.82, 196.49, 195.58, 197.74, 196.12, 204.78,
                197.57, 204.98, 196.35, 203.25, 200.23, 204.92, 200.57, 201.04, 195.21};

            // flow rate
            double[] failset_1 = {1, 0, 0, 0, 0, 0,
                            0, 0, 0, 1, 0, 0,
                            0, 1, 0, 0, 0, 0,
                            0, 0, 0, 0, 1, 0,
                            0, 0, 1, 0, 0, 0 };

            double[] failset_2 = {0, 0, 0, 0, 0, 1,
                            1, 0, 0, 0, 0, 0,
                            0, 0, 1, 0, 0, 0,
                            0, 0, 0, 0, 1, 0,
                            0, 1, 0, 0, 0, 0 };

            double[] failset_3 = {0, 0, 1, 0, 0, 0,
                            0, 0, 0, 1, 0, 0,
                            0, 1, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 1,
                            1, 0, 0, 0, 0, 0 };

            double[] failset_4 = {1, 0, 0, 0, 0, 0,
                            0, 0, 0, 1, 0, 0,
                            0, 1, 0, 0, 0, 0,
                            0, 0, 1, 0, 0, 0,
                            1, 0, 0, 0, 0, 0 };

            double[] failset_5 = {0, 0, 0, 0, 0, 1,
                            0, 0, 0, 0, 1, 0,
                            0, 0, 0, 1, 0, 0,
                            0, 0, 1, 0, 0, 0,
                            0, 1, 0, 0, 0, 0 };

            double[] failset_6 = {0, 0, 0, 0, 1, 0,
                            1, 0, 0, 0, 0, 0,
                            0, 0, 0, 1, 0, 0,
                            0, 1, 0, 0, 0, 0,
                            0, 0, 2, 0, 0, 0 };

            // AvgFlowRate
            // Session AvgFlowRate_Diesel_Bay_X, day 1 to day 30 (4)
            Session["Avg_Flow_Rate_Diesel_Bay_1_1"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_1_1)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_1_2"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_1_2)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_1_3"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_1_3)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_1_4"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_1_4)), 2);
            // GENERATOR
            for (var i = 0; i < 27; i++){ Session["Avg_Flow_Rate_Diesel_Bay_1_" + (i + 5)] = flowset_1[i]; }


            Session["Avg_Flow_Rate_Diesel_Bay_2_1"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_2_1)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_2_2"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_2_2)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_2_3"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_2_3)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_2_4"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_2_4)), 2);
            // GENERATOR
            for (var i = 0; i < 27; i++) { Session["Avg_Flow_Rate_Diesel_Bay_2_" + (i + 5)] = flowset_2[i]; }

            Session["Avg_Flow_Rate_Diesel_Bay_3_1"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_3_1)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_3_2"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_3_2)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_3_3"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_3_3)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_3_4"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_3_4)), 2);
            // GENERATOR
            for (var i = 0; i < 27; i++) { Session["Avg_Flow_Rate_Diesel_Bay_3_" + (i + 5)] = flowset_3[i]; }

            Session["Avg_Flow_Rate_Diesel_Bay_4_1"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_4_1)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_4_2"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_4_2)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_4_3"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_4_3)), 2);
            Session["Avg_Flow_Rate_Diesel_Bay_4_4"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Diesel_Bay_4_4)), 2);
            // GENERATOR
            for (var i = 0; i < 27; i++) { Session["Avg_Flow_Rate_Diesel_Bay_4_" + (i + 5)] = flowset_4[i]; }

            // Session AvgFlowRate_Gasohol95_Bay_X, day 1 to day 30 (4)
            Session["Avg_Flow_Rate_Gasohol95_Bay_5_1"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Gasohol95_Bay_5_1)), 2);
            Session["Avg_Flow_Rate_Gasohol95_Bay_5_2"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Gasohol95_Bay_5_2)), 2);
            Session["Avg_Flow_Rate_Gasohol95_Bay_5_3"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Gasohol95_Bay_5_3)), 2);
            Session["Avg_Flow_Rate_Gasohol95_Bay_5_4"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Gasohol95_Bay_5_4)), 2);
            /// GENERATOR
            for (var i = 0; i < 27; i++) { Session["Avg_Flow_Rate_Gasohol95_Bay_5_" + (i + 5)] = flowset_5[i]; }

            Session["Avg_Flow_Rate_Gasohol95_Bay_6_1"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Gasohol95_Bay_6_1)), 2);
            Session["Avg_Flow_Rate_Gasohol95_Bay_6_2"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Gasohol95_Bay_6_2)), 2);
            Session["Avg_Flow_Rate_Gasohol95_Bay_6_3"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Gasohol95_Bay_6_3)), 2);
            Session["Avg_Flow_Rate_Gasohol95_Bay_6_4"] = Math.Round((Convert.ToDouble(Avg_Flow_Rate_Gasohol95_Bay_6_4)), 2);
            // GENERATOR
            for (var i = 0; i < 27; i++) { Session["Avg_Flow_Rate_Gasohol95_Bay_6_" + (i + 5)] = flowset_6[i]; }


            // NoOfFailure
            Session["No_of_Failure_Diesel_Bay_1_1"] = Math.Round((Convert.ToDouble(No_of_Failure_Diesel_Bay_1_1)), 2);
            for (var i = 0; i < 30; i++) { Session["No_of_Failure_Diesel_Bay_1_" + (i + 2)] = failset_1[i]; }

            Session["No_of_Failure_Diesel_Bay_2_1"] = Math.Round((Convert.ToDouble(No_of_Failure_Diesel_Bay_2_1)), 2);
            for (var i = 0; i < 30; i++) { Session["No_of_Failure_Diesel_Bay_2_" + (i + 2)] = failset_2[i]; }

            Session["No_of_Failure_Diesel_Bay_3_1"] = Math.Round((Convert.ToDouble(No_of_Failure_Diesel_Bay_3_1)), 2);
            for (var i = 0; i < 30; i++) { Session["No_of_Failure_Diesel_Bay_3_" + (i + 2)] = failset_3[i]; }

            Session["No_of_Failure_Diesel_Bay_4_1"] = Math.Round((Convert.ToDouble(No_of_Failure_Diesel_Bay_4_1)), 2);
            for (var i = 0; i < 30; i++) { Session["No_of_Failure_Diesel_Bay_4_" + (i + 2)] = failset_4[i]; }

            Session["No_of_Failure_Gasohol95_Bay_5_1"] = Math.Round((Convert.ToDouble(No_of_Failure_Gasohol95_Bay_5_1)), 2);
            for (var i = 0; i < 30; i++) { Session["No_of_Failure_Gasohol95_Bay_5_" + (i + 2)] = failset_5[i]; }

            Session["No_of_Failure_Gasohol95_Bay_6_1"] = Math.Round((Convert.ToDouble(No_of_Failure_Gasohol95_Bay_6_1)), 2);
            for (var i = 0; i < 30; i++) { Session["No_of_Failure_Gasohol95_Bay_6_" + (i + 2)] = failset_6[i]; }

            // :: REALM OF HELL - ViewData 

            for (var i = 1; i <= 6; i++) // bay no.
            {
                for (var j = 1; j <= 31; j++) // day
                {
                    ViewData["AVG_FLOW_RATE_DIESEL_BAY_" + i + "_" + j] = Session["Avg_Flow_Rate_Diesel_Bay_" + i + "_" + j]; // AvgFlowRate
                    ViewData["AVG_FLOW_RATE_GASOHOL95_BAY_" + i + "_" + j] = Session["Avg_Flow_Rate_Gasohol95_Bay_" + i + "_" + j]; // AvgFlowRate                             
                    ViewData["NO_OF_FAILURE_DIESEL_BAY_" + i + "_" + j] = Session["No_of_Failure_Diesel_Bay_" + i + "_" + j]; // NoOfFailure
                    ViewData["NO_OF_FAILURE_GASOHOL95_BAY_" + i + "_" + j] = Session["No_of_Failure_Gasohol95_Bay_" + i + "_" + j]; // NoOfFailure                     
                }
            }

            // layer 3 : miscellaneous
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>         Layer 3 : MISCELLANEOUS            >>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // ----------------------------------------------------------------------------------------
            //  Remaining Diesel and Gasohol95 (m3)
            // ----------------------------------------------------------------------------------------
            // :: REALM OF HELL - FindPiPoint
            // Diesel & Gasohol95
            for (var i = 0; i < 31; i++) {
                pt_Remaining_Diesel[i] = PIPoint.FindPIPoint(piServer, "G4-A004-69-0200-029_" + (i + 1));
                pt_Remaining_Gasohol95[i] = PIPoint.FindPIPoint(piServer, "G4-A004-69-0200-030_" + (i + 1));
            }
            // Total Truck In & Total Truck Out
            // Total Truck In
            pt_Total_Truck_In[0] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_1.661656e3-5574-464a-82ab-e1a475f9f9e8");
            pt_Total_Truck_In[1] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_2.3b0f97cf-da94-4caf-8a99-870228f5462b");
            pt_Total_Truck_In[2] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_3.1fbbab2d-9e87-4dcf-9aaf-b01ad55fb7e7");
            pt_Total_Truck_In[3] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_4.07e38555-12ce-4552-8e27-cf61f2bb6443");
            pt_Total_Truck_In[4] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_5.8fc2d376-5513-4da0-bccc-d54a5f6cf323");
            pt_Total_Truck_In[5] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_6.e7db54e8-926a-437b-914e-f45fb6a3f791");
            pt_Total_Truck_In[6] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_7.304b8d28-5016-4e46-975f-aba2b8c9c230");
            pt_Total_Truck_In[7] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_8.bf32b869-1115-4985-ba36-0533038e1c54");
            pt_Total_Truck_In[8] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_9.26e6776a-644a-42b9-a63c-a4dd593e4b52");
            pt_Total_Truck_In[9] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_10.bbe192bd-9812-465d-a4ed-ee71ac6745f5");
            pt_Total_Truck_In[10] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_11.fcf6e05a-7949-45fa-85b6-9437a6e38ff4");
            pt_Total_Truck_In[11] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_12.8dff5598-757b-426a-b11a-baa11e9d5839");
            pt_Total_Truck_In[12] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_13.75602c98-47e2-478d-a926-602e9d5c7977");
            pt_Total_Truck_In[13] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_14.38600b88-1fca-4ece-a758-3cf201bff07d");
            pt_Total_Truck_In[14] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_15.43131e30-4652-4382-9873-2fbd45658d89");
            pt_Total_Truck_In[15] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_16.93ed0ac0-423a-4882-b1e9-fc3204f23a61");
            pt_Total_Truck_In[16] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_17.93597bb8-ec32-4eab-8d86-6e7f01f07b24");
            pt_Total_Truck_In[17] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_18.5182a6b6-514b-4ca1-958c-05354dd0153e");
            pt_Total_Truck_In[18] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_19.475e29cc-391c-472d-895b-013e3b6af21f");
            pt_Total_Truck_In[19] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_20.aa1cf6df-2cdb-4159-a43e-4938c994a92e");
            pt_Total_Truck_In[20] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_21.39440da5-4f61-4c7e-abfe-28144e625bc0");
            pt_Total_Truck_In[21] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_22.4c02ebec-1ee1-4ba3-a954-a6a676a30f73");
            pt_Total_Truck_In[22] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_23.4a97af83-23ae-4ae2-8b54-f9b714a673ee");
            pt_Total_Truck_In[23] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_24.9eece56b-05c2-4656-a366-f4cdadad2c34");
            pt_Total_Truck_In[24] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_25.efca589c-4d1d-4b70-9b48-1121859c3bc8");
            pt_Total_Truck_In[25] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_26.2d5b0710-2389-46ce-b251-5a282da484af");
            pt_Total_Truck_In[26] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_27.67abd198-e30c-461a-b5d4-c5f4acc3e474");
            pt_Total_Truck_In[27] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_28.b7d43ac3-6c1e-48fb-8938-b5f6a75c2a1a");
            pt_Total_Truck_In[28] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_29.6f8be5fb-bb0d-4417-b433-8a3f017cb599");
            pt_Total_Truck_In[29] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_30.d883d2fa-8573-45e5-8622-847244f4436a");
            pt_Total_Truck_In[30] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_31.bda169a3-39a4-4515-8f25-83daa7af9d67");

            // Total Truck Out
            pt_Total_Truck_Out[0] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_1.0bcb5709-f033-4e2e-ba8f-fea1489b6383");
            pt_Total_Truck_Out[1] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_2.cb73e945-4eca-49eb-b2b0-b52b1e460883");
            pt_Total_Truck_Out[2] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_3.a06ed967-568b-434c-8cb7-9521ea22ee91");
            pt_Total_Truck_Out[3] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_4.2ab89f49-5625-488d-9bb8-8b60421efbbd");
            pt_Total_Truck_Out[4] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_5.581fdf95-d376-4903-a694-79700e283f8b");
            pt_Total_Truck_Out[5] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_6.fb84b113-17c6-4b61-bd9e-e16d48f24a29");
            pt_Total_Truck_Out[6] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_7.abd3af5d-0d0d-46b3-87e1-b5cc06007039");
            pt_Total_Truck_Out[7] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_8.3dccd856-06fd-42e2-8ec8-a4cc9b7545b4");
            pt_Total_Truck_Out[8] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_9.3f65d7c0-ea69-4253-8ed5-70998a747b36");
            pt_Total_Truck_Out[9] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_10.105278d1-d7b9-496a-9691-bbd1a5d55208");
            pt_Total_Truck_Out[10] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_11.e1880f63-8659-473e-8cf8-5073b6b1cb29");
            pt_Total_Truck_Out[11] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_12.7a787933-f3a0-444a-85ab-5b13900fea02");
            pt_Total_Truck_Out[12] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_13.ac247461-3e98-41d2-8e0a-da3687a66185");
            pt_Total_Truck_Out[13] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_14.895c66e9-b486-4ad6-9f0c-e65eccc3c093");
            pt_Total_Truck_Out[14] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_15.643641bc-323b-4eaa-9300-29b9f8c50346");
            pt_Total_Truck_Out[15] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_16.ce6ff725-3927-4342-b9cd-ec14f88551d3");
            pt_Total_Truck_Out[16] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_17.0ced0305-7816-4969-808f-fffec1aa73d5");
            pt_Total_Truck_Out[17] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_18.ec23d559-f0bf-4a4e-83d7-2d8377a222e0");
            pt_Total_Truck_Out[18] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_19.0271a41f-9e82-409a-a6bb-b9df35825d46");
            pt_Total_Truck_Out[19] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_20.4418b252-e5de-41b3-93a2-7e53f0180305");
            pt_Total_Truck_Out[20] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_21.f6145f0a-a6bc-4925-8d19-817e15f606b7");
            pt_Total_Truck_Out[21] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_22.c7ad2776-da6e-4020-8ecd-38bf1bd419ed");
            pt_Total_Truck_Out[22] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_23.2a3f658d-9cb9-438b-b6bf-de2a7d876a0b");
            pt_Total_Truck_Out[23] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_24.bd787b46-480b-4919-ac74-ad0f6f3f2060");
            pt_Total_Truck_Out[24] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_25.d1a2efbd-46af-4cf7-ab0e-885e381ba2b5");
            pt_Total_Truck_Out[25] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_26.b88c60c0-c29b-4c1b-b155-1e83ba0bbe46");
            pt_Total_Truck_Out[26] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_27.8b7fb369-b161-411d-9999-bb3e00d60e77");
            pt_Total_Truck_Out[27] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_28.05bc5557-6569-4d18-8c5c-f77bfeb36515");
            pt_Total_Truck_Out[28] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_29.9730a509-d449-4842-a92e-2259b574f043");
            pt_Total_Truck_Out[29] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_30.090b33cf-d28d-4e0f-a4d3-47f3f16c00a5");
            pt_Total_Truck_Out[30] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_31.6eb6124e-b431-493e-b625-abadef9bb6b6");

            // :: REALM OF HELL - SnapShot Godfather 

            // :: Data Container
            IList<getData> Remaining_Diesel = new List<getData>(); // Decipher
            IList<getData> Remaining_Gasohol95 = new List<getData>(); // Decipher


            // :: Eternity plotValues
            // array then loop
            for (var i = 0; i < 31; i++)
            {
                // Diesel & Gasohol95
                plotRemaining_Diesel[i] = pt_Remaining_Diesel[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotRemaining_Gasohol95[i] = pt_Remaining_Gasohol95[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);

                // Total Truck In & Total Truck Out
                plotTotal_Truck_In[i] = pt_Total_Truck_In[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotTotal_Truck_Out[i] = pt_Total_Truck_Out[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            }

            // :: REALM OF HELL - LIST APPEND, SHIT HAPPEN
            // DIESEL

            for (var i = 0; i < 31; i++)
            {
                foreach (var pValue in plotRemaining_Diesel[i])
                {
                    if (pValue.Value.ToString() != "No Data")
                    {
                        
                        if (pValue.Value.ToString() != "Pt Created") // Fuck Off!
                        {
                            Remaining_Diesel.Add(new getData() { Value = pValue.Value.ToString() });
                        }
                    }
                }
            }

            // GASOHOL95
            for (var i = 0; i < 31; i++)
            {
                foreach (var pValue in plotRemaining_Gasohol95[i])
                {
                    if (pValue.Value.ToString() != "No Data")
                    {
                        if (pValue.Value.ToString() != "Pt Created") // Fuck Off!
                        {
                            Remaining_Gasohol95.Add(new getData() { Value = pValue.Value.ToString() });
                        }
                    }
                }
            }

            // Total Truck In
            
            foreach (var pValue in plotTotal_Truck_In[0]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[1]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[2]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[3]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_4 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[4]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_5 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[5]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_6 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[6]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_7 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[7]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_8 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[8]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_9 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[9]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_10 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[10]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_11 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[11]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_12 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[12]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_13 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[13]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_14 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[14]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_15 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[15]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_16 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[16]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_17 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[17]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_18 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[18]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_19 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[19]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_20 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[20]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_21 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[21]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_22 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[22]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_23 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[23]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_24 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[24]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_25 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[25]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_26 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[26]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_27 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[27]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_28 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[28]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_29 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[29]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_30 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In[30]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_31 = pValue.Value.ToString(); } }

            // Total Truck Out

            foreach (var pValue in plotTotal_Truck_Out[0]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[1]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[2]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[3]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_4 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[4]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_5 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[5]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_6 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[6]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_7 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[7]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_8 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[8]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_9 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[9]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_10 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[10]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_11 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[11]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_12 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[12]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_13 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[13]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_14 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[14]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_15 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[15]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_16 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[16]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_17 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[17]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_18 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[18]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_19 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[19]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_20 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[20]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_21 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[21]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_22 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[22]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_23 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[23]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_24 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[24]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_25 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[25]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_26 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[26]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_27 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[27]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_28 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[28]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_29 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[29]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_30 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out[30]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_31 = pValue.Value.ToString(); } }
            // Debug

            //foreach (var item in Remaining_Diesel)
            //{              
            //    Debug.WriteLine(item);
            //}

            //for (var i = 0; i < Remaining_Gasohol95.Count; i++)
            //{
            //    Debug.WriteLine(Remaining_Gasohol95[i].Value);
            //    //Debug.WriteLine(i);
            //}

            // :: REALM OF HELL - SESSION GODFATHER
            // loopable
            // Diesel and Gasohol
            for (var i = 0; i < 31; i++)
            {
                Session["remaining_diesel_" + (i + 1)] = Math.Round((Convert.ToDouble(Remaining_Diesel[i].Value)), 2);
                Session["remaining_gasohol95_" + (i + 1)] = Math.Round((Convert.ToDouble(Remaining_Gasohol95[i].Value)), 2);
            }

            // Total Truck In/Out - in
            Session["total_truck_in_1"] = Math.Round((Convert.ToDouble(Total_Truck_In_1)), 2);
            Session["total_truck_in_2"] = Math.Round((Convert.ToDouble(Total_Truck_In_2)), 2);
            Session["total_truck_in_3"] = Math.Round((Convert.ToDouble(Total_Truck_In_3)), 2);
            Session["total_truck_in_4"] = Math.Round((Convert.ToDouble(Total_Truck_In_4)), 2);
            Session["total_truck_in_5"] = Math.Round((Convert.ToDouble(Total_Truck_In_5)), 2);
            Session["total_truck_in_6"] = Math.Round((Convert.ToDouble(Total_Truck_In_6)), 2);
            Session["total_truck_in_7"] = Math.Round((Convert.ToDouble(Total_Truck_In_7)), 2);
            Session["total_truck_in_8"] = Math.Round((Convert.ToDouble(Total_Truck_In_8)), 2);
            Session["total_truck_in_9"] = Math.Round((Convert.ToDouble(Total_Truck_In_9)), 2);
            Session["total_truck_in_10"] = Math.Round((Convert.ToDouble(Total_Truck_In_10)), 2);
            Session["total_truck_in_11"] = Math.Round((Convert.ToDouble(Total_Truck_In_11)), 2);
            Session["total_truck_in_12"] = Math.Round((Convert.ToDouble(Total_Truck_In_12)), 2);
            Session["total_truck_in_13"] = Math.Round((Convert.ToDouble(Total_Truck_In_13)), 2);
            Session["total_truck_in_14"] = Math.Round((Convert.ToDouble(Total_Truck_In_14)), 2);
            Session["total_truck_in_15"] = Math.Round((Convert.ToDouble(Total_Truck_In_15)), 2);
            Session["total_truck_in_16"] = Math.Round((Convert.ToDouble(Total_Truck_In_16)), 2);
            Session["total_truck_in_17"] = Math.Round((Convert.ToDouble(Total_Truck_In_17)), 2);
            Session["total_truck_in_18"] = Math.Round((Convert.ToDouble(Total_Truck_In_18)), 2);
            Session["total_truck_in_19"] = Math.Round((Convert.ToDouble(Total_Truck_In_19)), 2);
            Session["total_truck_in_20"] = Math.Round((Convert.ToDouble(Total_Truck_In_20)), 2);
            Session["total_truck_in_21"] = Math.Round((Convert.ToDouble(Total_Truck_In_21)), 2);
            Session["total_truck_in_22"] = Math.Round((Convert.ToDouble(Total_Truck_In_22)), 2);
            Session["total_truck_in_23"] = Math.Round((Convert.ToDouble(Total_Truck_In_23)), 2);
            Session["total_truck_in_24"] = Math.Round((Convert.ToDouble(Total_Truck_In_24)), 2);
            Session["total_truck_in_25"] = Math.Round((Convert.ToDouble(Total_Truck_In_25)), 2);
            Session["total_truck_in_26"] = Math.Round((Convert.ToDouble(Total_Truck_In_26)), 2);
            Session["total_truck_in_27"] = Math.Round((Convert.ToDouble(Total_Truck_In_27)), 2);
            Session["total_truck_in_28"] = Math.Round((Convert.ToDouble(Total_Truck_In_28)), 2);
            Session["total_truck_in_29"] = Math.Round((Convert.ToDouble(Total_Truck_In_29)), 2);
            Session["total_truck_in_30"] = Math.Round((Convert.ToDouble(Total_Truck_In_30)), 2);
            Session["total_truck_in_31"] = Math.Round((Convert.ToDouble(Total_Truck_In_31)), 2);

            // Total Truck In/Out - Out
            Session["total_truck_out_1"] = Math.Round((Convert.ToDouble(Total_Truck_Out_1)), 2);
            Session["total_truck_out_2"] = Math.Round((Convert.ToDouble(Total_Truck_Out_2)), 2);
            Session["total_truck_out_3"] = Math.Round((Convert.ToDouble(Total_Truck_Out_3)), 2);
            Session["total_truck_out_4"] = Math.Round((Convert.ToDouble(Total_Truck_Out_4)), 2);
            Session["total_truck_out_5"] = Math.Round((Convert.ToDouble(Total_Truck_Out_5)), 2);
            Session["total_truck_out_6"] = Math.Round((Convert.ToDouble(Total_Truck_Out_6)), 2);
            Session["total_truck_out_7"] = Math.Round((Convert.ToDouble(Total_Truck_Out_7)), 2);
            Session["total_truck_out_8"] = Math.Round((Convert.ToDouble(Total_Truck_Out_8)), 2);
            Session["total_truck_out_9"] = Math.Round((Convert.ToDouble(Total_Truck_Out_9)), 2);
            Session["total_truck_out_10"] = Math.Round((Convert.ToDouble(Total_Truck_Out_10)), 2);
            Session["total_truck_out_11"] = Math.Round((Convert.ToDouble(Total_Truck_Out_11)), 2);
            Session["total_truck_out_12"] = Math.Round((Convert.ToDouble(Total_Truck_Out_12)), 2);
            Session["total_truck_out_13"] = Math.Round((Convert.ToDouble(Total_Truck_Out_13)), 2);
            Session["total_truck_out_14"] = Math.Round((Convert.ToDouble(Total_Truck_Out_14)), 2);
            Session["total_truck_out_15"] = Math.Round((Convert.ToDouble(Total_Truck_Out_15)), 2);
            Session["total_truck_out_16"] = Math.Round((Convert.ToDouble(Total_Truck_Out_16)), 2);
            Session["total_truck_out_17"] = Math.Round((Convert.ToDouble(Total_Truck_Out_17)), 2);
            Session["total_truck_out_18"] = Math.Round((Convert.ToDouble(Total_Truck_Out_18)), 2);
            Session["total_truck_out_19"] = Math.Round((Convert.ToDouble(Total_Truck_Out_19)), 2);
            Session["total_truck_out_20"] = Math.Round((Convert.ToDouble(Total_Truck_Out_20)), 2);
            Session["total_truck_out_21"] = Math.Round((Convert.ToDouble(Total_Truck_Out_21)), 2);
            Session["total_truck_out_22"] = Math.Round((Convert.ToDouble(Total_Truck_Out_22)), 2);
            Session["total_truck_out_23"] = Math.Round((Convert.ToDouble(Total_Truck_Out_23)), 2);
            Session["total_truck_out_24"] = Math.Round((Convert.ToDouble(Total_Truck_Out_24)), 2);
            Session["total_truck_out_25"] = Math.Round((Convert.ToDouble(Total_Truck_Out_25)), 2);
            Session["total_truck_out_26"] = Math.Round((Convert.ToDouble(Total_Truck_Out_26)), 2);
            Session["total_truck_out_27"] = Math.Round((Convert.ToDouble(Total_Truck_Out_27)), 2);
            Session["total_truck_out_28"] = Math.Round((Convert.ToDouble(Total_Truck_Out_28)), 2);
            Session["total_truck_out_29"] = Math.Round((Convert.ToDouble(Total_Truck_Out_29)), 2);
            Session["total_truck_out_30"] = Math.Round((Convert.ToDouble(Total_Truck_Out_30)), 2);
            Session["total_truck_out_31"] = Math.Round((Convert.ToDouble(Total_Truck_Out_31)), 2);
            // :: REALM OF HELL - ViewData

            // Diesel and Gasohol, Total Truck In/Out
            for (var i = 1; i <= 31; i++)
            {
                ViewData["REMAINING_DIESEL_" + i] = Session["remaining_diesel_" + i];    // Diesel
                ViewData["REMAINING_GASOHOL95_" + i] = Session["remaining_gasohol95_" + i]; // Gasohol95

                ViewData["TOTAL_TRUCK_IN_" + i] = Session["total_truck_in_" + i]; // total truck in
                ViewData["TOTAL_TRUCK_OUT_" + i] = Session["total_truck_out_" + i]; // total truck out

            }



            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                        DATE                                           ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            ViewData["Day"] = Session["date"];


            return View();
        }




        //...............................................................................................
        //.MMMMMM...MMMMMM....AAAAA.....NNNN...NNNN.....AAAAA........GGGGGGG....EEEEEEEEEEE.RRRRRRRRRR...
        //.MMMMMM...MMMMMM....AAAAA.....NNNNN..NNNN.....AAAAA......GGGGGGGGGG...EEEEEEEEEEE.RRRRRRRRRRR..
        //.MMMMMM...MMMMMM...AAAAAA.....NNNNN..NNNN....AAAAAA.....GGGGGGGGGGGG..EEEEEEEEEEE.RRRRRRRRRRR..
        //.MMMMMMM.MMMMMMM...AAAAAAA....NNNNNN.NNNN....AAAAAAA....GGGGG..GGGGG..EEEE........RRRR...RRRR..
        //.MMMMMMM.MMMMMMM..AAAAAAAA....NNNNNN.NNNN...AAAAAAAA...GGGGG....GGG...EEEE........RRRR...RRRR..
        //.MMMMMMM.MMMMMMM..AAAAAAAA....NNNNNNNNNNN...AAAAAAAA...GGGG...........EEEEEEEEEE..RRRRRRRRRRR..
        //.MMMMMMMMMMMMMMM..AAAA.AAAA...NNNNNNNNNNN...AAAA.AAAA..GGGG..GGGGGGGG.EEEEEEEEEE..RRRRRRRRRRR..
        //.MMMMMMMMMMMMMMM.AAAAAAAAAA...NNNNNNNNNNN..AAAAAAAAAA..GGGG..GGGGGGGG.EEEEEEEEEE..RRRRRRRR.....
        //.MMMMMMMMMMMMMMM.AAAAAAAAAAA..NNNNNNNNNNN..AAAAAAAAAAA.GGGGG.GGGGGGGG.EEEE........RRRR.RRRR....
        //.MMMM.MMMMM.MMMM.AAAAAAAAAAA..NNNN.NNNNNN..AAAAAAAAAAA..GGGGG....GGGG.EEEE........RRRR..RRRR...
        //.MMMM.MMMMM.MMMMAAAA....AAAA..NNNN..NNNNN.AAAA....AAAA..GGGGGGGGGGGG..EEEEEEEEEEE.RRRR..RRRRR..
        //.MMMM.MMMMM.MMMMAAAA.....AAAA.NNNN..NNNNN.AAAA.....AAAA..GGGGGGGGGG...EEEEEEEEEEE.RRRR...RRRR..
        //.MMMM.MMMMM.MMMMAAAA.....AAAA.NNNN...NNNNNAAAA.....AAAA....GGGGGGG....EEEEEEEEEEE.RRRR....RRR..
        //...............................................................................................
        // GET: Dashboard

        public ActionResult DashboardManager()
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    CONNECT TO PI-SMT                                  ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // Create connection to PI Data archive 
            PIServers servers = new PIServers();
            PIServer piServer = servers["202.44.12.146"];
            var cred = new NetworkCredential("group4", "inc.382");
            piServer.Connect(cred);


            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                        QUERY DATA                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // layer 1 : Super KPI
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>         Layer 1 : SUPER KPI            >>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // ----------------------------------------------------------------------------------------
            //  1 & 2 - DIESEL and GASOHOL SOLD THIS WEEK (L)
            // ----------------------------------------------------------------------------------------

            // :: REALM OF HELL - FindPiPoint
            // array
            // DIESEL 
            pt_DieselSold_Week[0] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_32.e9bb724d-b7be-426c-8d19-6aaa08f9f118");
            pt_DieselSold_Week[1] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_33.12291320-1598-49db-95cb-ac5fcdef5380");
            pt_DieselSold_Week[2] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_34.70b70f2c-9c1a-4f98-a2ae-773830dfbfb1");
            pt_DieselSold_Week[3] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_35.637d272e-8d16-44d6-89fc-1978521eca7a");
            pt_DieselSold_Week[4] = PIPoint.FindPIPoint(piServer, "Cycle Time of diesel bay loading(filling time).G4-A004-69-0200-027_36.d1c97fc5-0a09-48cc-b52a-b4b1f87ceb2f"); // month

            pt_Gasohol95Sold_Week[0] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_32.8cd85fd4-c1b4-4e57-87d0-269ac7d1645a");
            pt_Gasohol95Sold_Week[1] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_33.2002572d-240c-4db8-9588-6abe2efbc108");
            pt_Gasohol95Sold_Week[2] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_34.c9af23cc-94c4-4e1c-a451-3137201fdaff");
            pt_Gasohol95Sold_Week[3] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_35.9b48e704-1707-46b7-8074-341589540878");
            pt_Gasohol95Sold_Week[4] = PIPoint.FindPIPoint(piServer, "Cycle Time of Gasohol95 bay loading.G4-A004-69-0200-028_36.56434a69-bb9d-40d6-8f91-5cfbd453c695"); // month

            // :: Eternity plotValues
            // array then loop
            for (var i = 0; i < 5; i++)
            {
                plotValuesDieselWeek[i] = pt_DieselSold_Week[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                plotValuesGasohol95Week[i] = pt_Gasohol95Sold_Week[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            }

            // :: REALM OF HELL - LIST APPEND, SHIT HAPPEN
            foreach (var pValue in plotValuesDieselWeek[0]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_Week_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDieselWeek[1]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_Week_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDieselWeek[2]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_Week_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDieselWeek[3]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_Week_4 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesDieselWeek[4]) { if (pValue.Value.ToString() != "No Data") { Diesel_Sold_Month_1 = pValue.Value.ToString(); } }

            foreach (var pValue in plotValuesGasohol95Week[0]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_Week_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95Week[1]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_Week_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95Week[2]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_Week_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95Week[3]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_Week_4 = pValue.Value.ToString(); } }
            foreach (var pValue in plotValuesGasohol95Week[4]) { if (pValue.Value.ToString() != "No Data") { Gasohol95_Sold_Month_1 = pValue.Value.ToString(); } }
            // :: REALM OF HELL - SESSION GODFATHER
            // loopable
            Session["diesel_sold_week_1"] = Math.Round((Convert.ToDouble(Diesel_Sold_Week_1)), 2);
            Session["diesel_sold_week_2"] = Math.Round((Convert.ToDouble(Diesel_Sold_Week_2)), 2);
            Session["diesel_sold_week_3"] = Math.Round((Convert.ToDouble(Diesel_Sold_Week_3)), 2);
            Session["diesel_sold_week_4"] = Math.Round((Convert.ToDouble(Diesel_Sold_Week_4)), 2);
            Session["diesel_sold_month_1"] = Math.Round((Convert.ToDouble(Diesel_Sold_Month_1)), 2);

            Session["gasohol95_sold_week_1"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_Week_1)), 2);
            Session["gasohol95_sold_week_2"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_Week_2)), 2);
            Session["gasohol95_sold_week_3"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_Week_3)), 2);
            Session["gasohol95_sold_week_4"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_Week_4)), 2);
            Session["gasohol95_sold_month_1"] = Math.Round((Convert.ToDouble(Gasohol95_Sold_Month_1)), 2);

            // :: REALM OF HELL - ViewData
            for (var i = 1; i <= 4; i++)
            {
                ViewData["DIESEL_SOLD_WEEK_" + i] = Session["diesel_sold_week_" + i];
                ViewData["GASOHOL95_SOLD_WEEK_" + i] = Session["gasohol95_sold_week_" + i];
            }

            ViewData["DIESEL_SOLD_MONTH_1"] = Session["diesel_sold_month_1"];
            ViewData["GASOHOL95_SOLD_MONTH_1"] = Session["gasohol95_sold_month_1"];
            //DO THIS SHIT
            // ----------------------------------------------------------------------------------------
            //  3 - TOTAL SCHEDULE UTILIZATION
            // ----------------------------------------------------------------------------------------
            // fuck brute force, geniuse logic!
            IList<getData> totalUtilization = new List<getData>();

            // get value from tag
            var pt_Total_Utilization = PIPoint.FindPIPoint(piServer, "G4-A004-69-0500-036");

            // get historical data
            var plotTotalUtilization = pt_Total_Utilization.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);

            foreach (var pValue in plotTotalUtilization) { if (pValue.Value.ToString() != "No Data") { totalUtilization.Add(new getData() { Value = pValue.Value.ToString() }); } }

            

            // calculation
            // 4 WEEKS
            for (var j = 0; j < 4; j++) // 4 weeks
            {
                for (var i = 0; i < 7; i++) // 1 week has 7 days
                {
                    // yep, we need to shift these fucking days
                    if (j == 0) { utilSum = (Math.Round((Convert.ToDouble(totalUtilization[i].Value)), 2)) + utilSum; }
                    else if (j == 1) { utilSum = (Math.Round((Convert.ToDouble(totalUtilization[i + 7].Value)), 2)) + utilSum; }
                    else if (j == 2) { utilSum = (Math.Round((Convert.ToDouble(totalUtilization[i + 14].Value)), 2)) + utilSum; }
                    else if (j == 3) { utilSum = (Math.Round((Convert.ToDouble(totalUtilization[i + 21].Value)), 2)) + utilSum; }                   
                }
                total_Utilization_Weekly[j] = utilSum/7.0;              
                utilSum = 0.0;
            }

            // 1 MONTH
            for (var i = 0; i < 31; i++) // 4 weeks
            {
                utilSum = Math.Round((Convert.ToDouble(totalUtilization[i].Value)), 2) + utilSum;
            }
            total_Utilization_Monthly = utilSum/31.0;
            utilSum = 0.0;


            // debug
            for (var i = 0; i < 4; i++)
            {
                //Debug.WriteLine(truckSearch[i].License_Plate);
                //Debug.WriteLine(i);
                Session["Total_Utilizatoin_Week_" + i] = total_Utilization_Weekly[i];
                ViewData["TOTAL_UTILIZATION_WEEK_" + (i + 1)] = Session["Total_Utilizatoin_Week_" + i].ToString();
            }
            Session["Total_Utilizatoin_Month_1"] = total_Utilization_Monthly;
            ViewData["TOTAL_UTILIZATION_MONTH_1"] = Session["Total_Utilizatoin_Month_1"].ToString(); // WEEK_5 = Month_1 !!!
            
            // layer 2 : supporter
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>         Layer 2 : SUPPORTER            >>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // ----------------------------------------------------------------------------------------
            //  SCHEDULE UTILIZATION
            // ----------------------------------------------------------------------------------------
            IList<getData> utilSaleOffice = new List<getData>();
            IList<getData> utilWeighIn = new List<getData>();
            IList<getData> utilDieselBayLoading = new List<getData>();
            IList<getData> utilGasohol95BayLoading = new List<getData>();
            IList<getData> utilWeighOut = new List<getData>();

            // get value from tag
            var pt_UtilSaleOffice_Day = PIPoint.FindPIPoint(piServer, "G4-A004-69-0000-031");
            var pt_UtilWeighIn_Day = PIPoint.FindPIPoint(piServer, "G4-A004-69-0300-032");
            var pt_UtilDieselBayLoading_Day = PIPoint.FindPIPoint(piServer, "G4-A004-69-0100-034");
            var pt_UtilGasohol95BayLoading_Day = PIPoint.FindPIPoint(piServer, "G4-A004-69-0100-035");
            var pt_UtilWeighOut_Day = PIPoint.FindPIPoint(piServer, "G4-A004-69-0300-033");

            // get historical data
            var util_sale_Office_Day = pt_UtilSaleOffice_Day.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var util_Weigh_In_Day = pt_UtilWeighIn_Day.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var util_Diesel_Bay_Loading_Day = pt_UtilDieselBayLoading_Day.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var util_Gasohol95_Bay_Loading_Day = pt_UtilGasohol95BayLoading_Day.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var util_Weigh_Out_Day = pt_UtilWeighOut_Day.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);

            foreach (var pValue in util_sale_Office_Day) { if (pValue.Value.ToString() != "No Data") { utilSaleOffice.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in util_Weigh_In_Day) { if (pValue.Value.ToString() != "No Data") { utilWeighIn.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in util_Diesel_Bay_Loading_Day) { if (pValue.Value.ToString() != "No Data") { utilDieselBayLoading.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in util_Gasohol95_Bay_Loading_Day) { if (pValue.Value.ToString() != "No Data") { utilGasohol95BayLoading.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in util_Weigh_Out_Day) { if (pValue.Value.ToString() != "No Data") { utilWeighOut.Add(new getData() { Value = pValue.Value.ToString() }); } }

            // calculate for 1 week
            // 4 WEEKS
            for (var j = 0; j < 4; j++) // 4 weeks
            {
                for (var i = 0; i < 7; i++) // 1 week has 7 days
                {
                    // yep, we need to shift these fucking days
                    if (j == 0) {
                        utilSaleSum = utilSaleSum + (Math.Round((Convert.ToDouble(utilSaleOffice[i].Value)), 2));
                        utilWeighInSum = utilWeighInSum + Math.Round((Convert.ToDouble(utilWeighIn[i].Value)), 2);
                        utilWeighOutSum = utilWeighOutSum + Math.Round((Convert.ToDouble(utilWeighOut[i].Value)), 2);
                        utilDieselBayLoadingSum = utilDieselBayLoadingSum + Math.Round((Convert.ToDouble(utilDieselBayLoading[i].Value)), 2);
                        utilGasohol95BayLoadingSum = utilGasohol95BayLoadingSum + Math.Round((Convert.ToDouble(utilGasohol95BayLoading[i].Value)), 2);
                    }
                    else if (j == 1)
                    {
                        utilSaleSum = utilSaleSum + (Math.Round((Convert.ToDouble(utilSaleOffice[i + 7].Value)), 2));
                        utilWeighInSum = utilWeighInSum + Math.Round((Convert.ToDouble(utilWeighIn[i + 7].Value)), 2);
                        utilWeighOutSum = utilWeighOutSum + Math.Round((Convert.ToDouble(utilWeighOut[i + 7].Value)), 2);
                        utilDieselBayLoadingSum = utilDieselBayLoadingSum + Math.Round((Convert.ToDouble(utilDieselBayLoading[i + 7 ].Value)), 2);
                        utilGasohol95BayLoadingSum = utilGasohol95BayLoadingSum + Math.Round((Convert.ToDouble(utilGasohol95BayLoading[i + 7].Value)), 2);
                    }
                    else if (j == 2)
                    {
                        utilSaleSum = utilSaleSum + (Math.Round((Convert.ToDouble(utilSaleOffice[i + 14].Value)), 2));
                        utilWeighInSum = utilWeighInSum + Math.Round((Convert.ToDouble(utilWeighIn[i + 14].Value)), 2);
                        utilWeighOutSum = utilWeighOutSum + Math.Round((Convert.ToDouble(utilWeighOut[i + 14].Value)), 2);
                        utilDieselBayLoadingSum = utilDieselBayLoadingSum + Math.Round((Convert.ToDouble(utilDieselBayLoading[i + 14].Value)), 2);
                        utilGasohol95BayLoadingSum = utilGasohol95BayLoadingSum + Math.Round((Convert.ToDouble(utilGasohol95BayLoading[i + 14].Value)), 2);
                    }
                    else if (j == 3)
                    {
                        utilSaleSum = utilSaleSum + (Math.Round((Convert.ToDouble(utilSaleOffice[i + 21].Value)), 2));
                        utilWeighInSum = utilWeighInSum + Math.Round((Convert.ToDouble(utilWeighIn[i + 21].Value)), 2);
                        utilWeighOutSum = utilWeighOutSum + Math.Round((Convert.ToDouble(utilWeighOut[i + 21].Value)), 2);
                        utilDieselBayLoadingSum = utilDieselBayLoadingSum + Math.Round((Convert.ToDouble(utilDieselBayLoading[i + 21].Value)), 2);
                        utilGasohol95BayLoadingSum = utilGasohol95BayLoadingSum + Math.Round((Convert.ToDouble(utilGasohol95BayLoading[i + 21].Value)), 2);
                    }

                }

                Sale_Office_Utilization_Weekly[j] = utilSaleSum / 7.0;
                Weigh_In_Utilization_Weekly[j] = utilWeighInSum / 7.0;
                Weigh_Out_Utilization_Weekly[j] = utilWeighOutSum / 7.0;
                Diesel_Bay_Loading_Utilization_Weekly[j] = utilDieselBayLoadingSum / 7.0;
                Gasohol95_Bay_Loading_Utilization_Weekly[j] = utilGasohol95BayLoadingSum / 7.0;

                utilSaleSum = 0.0;
                utilWeighInSum = 0.0;
                utilWeighOutSum = 0.0;
                utilDieselBayLoadingSum = 0.0;
                utilGasohol95BayLoadingSum = 0.0;

            }


            // calculate for 1 month
            for (var i = 0; i < 31; i++) { utilSaleSum = utilSaleSum + Math.Round((Convert.ToDouble(utilSaleOffice[i].Value))/31, 2);}
            for (var i = 0; i < 31; i++) { utilWeighInSum = utilWeighInSum + Math.Round((Convert.ToDouble(utilWeighIn[i].Value)) / 31, 2); }
            for (var i = 0; i < 31; i++) { utilWeighOutSum = utilWeighOutSum + Math.Round((Convert.ToDouble(utilWeighOut[i].Value)) / 31, 2); }
            for (var i = 0; i < 31; i++) { utilDieselBayLoadingSum = utilDieselBayLoadingSum + Math.Round((Convert.ToDouble(utilDieselBayLoading[i].Value)) / 31, 2); }
            for (var i = 0; i < 31; i++) { utilGasohol95BayLoadingSum = utilGasohol95BayLoadingSum + Math.Round((Convert.ToDouble(utilGasohol95BayLoading[i].Value)) / 31, 2); }

            for (var i = 0; i < 4; i++)
            { 
                Session["Util_Sale_Office_Day_" + (i + 1)] = Sale_Office_Utilization_Weekly[i];
                Session["Util_Weigh_In_Day_" + (i + 1)] = Weigh_In_Utilization_Weekly[i];
                Session["Util_Diesel_Bay_Loading_Day_" + (i + 1)] = Weigh_Out_Utilization_Weekly[i];
                Session["Util_Gasohol95_Bay_Loading_Day_" + (i + 1)] = Diesel_Bay_Loading_Utilization_Weekly[i];
                Session["Util_Weigh_Out_Day_" + (i + 1)] = Gasohol95_Bay_Loading_Utilization_Weekly[i];


                ViewData["UTIL_SALE_OFFICE_DAY_" + (i + 1)] = Session["Util_Sale_Office_Day_" + (i + 1)].ToString();
                ViewData["UTIL_WEIGH_IN_DAY_" + (i + 1)] = Session["Util_Weigh_In_Day_" + (i + 1)].ToString();
                ViewData["UTIL_DIESEL_BAY_LOADING_DAY_" + (i + 1)] = Session["Util_Diesel_Bay_Loading_Day_" + (i + 1)].ToString();
                ViewData["UTIL_GASOHOL95_BAY_LOADING_DAY_" + (i + 1)] = Session["Util_Gasohol95_Bay_Loading_Day_" + (i + 1)].ToString();
                ViewData["UTIL_WEIGH_OUT_DAY_" + (i + 1)] = Session["Util_Weigh_Out_Day_" + (i + 1)].ToString();
            }

            Session["Util_Sale_Office_Month_1"] = utilSaleSum;
            Session["Util_Weigh_In_Month_1"] = utilWeighInSum;
            Session["Util_Weigh_Out_Month_1"] = utilWeighOutSum;
            Session["Util_Diesel_Bay_Loading_Month_1"] = utilDieselBayLoadingSum;
            Session["Util_Gasohol95_Bay_Loading_Month_1"] = utilGasohol95BayLoadingSum;

            ViewData["UTIL_SALE_OFFICE_MONTH_1"] = Session["Util_Sale_Office_Month_1"];
            ViewData["UTIL_WEIGH_IN_MONTH_1"] = Session["Util_Weigh_In_Month_1"];
            ViewData["UTIL_DIESEL_BAY_LOADING_MONTH_1"] = Session["Util_Weigh_Out_Month_1"];
            ViewData["UTIL_GASOHOL95_BAY_LOADING_MONTH_1"] = Session["Util_Diesel_Bay_Loading_Month_1"];
            ViewData["UTIL_WEIGH_OUT_MONTH_1"] = Session["Util_Gasohol95_Bay_Loading_Month_1"];

            // ----------------------------------------------------------------------------------------
            //  CYCLE TIME
            // ----------------------------------------------------------------------------------------

            IList<getData> cycSaleOffice = new List<getData>();
            IList<getData> cycWeighIn = new List<getData>();
            IList<getData> cycBayLoading = new List<getData>();
            IList<getData> cycWeighOut = new List<getData>();

            // get value from tag
            var pt_CycSaleOffice_Day = PIPoint.FindPIPoint(piServer, "G4-A004-69-0000-031");
            var pt_CycWeighIn_Day = PIPoint.FindPIPoint(piServer, "G4-A004-69-0300-032");
            var pt_CycBayLoading_Day = PIPoint.FindPIPoint(piServer, "G4-A004-69-0100-034");
            var pt_CycWeighOut_Day = PIPoint.FindPIPoint(piServer, "G4-A004-69-0300-033");

            // get historical data
            var cyc_sale_Office_Day = pt_CycSaleOffice_Day.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var cyc_Weigh_In_Day = pt_CycWeighIn_Day.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var cyc_Bay_Loading_Day = pt_CycBayLoading_Day.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var cyc_Weigh_Out_Day = pt_CycWeighOut_Day.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);

            foreach (var pValue in cyc_sale_Office_Day) { if (pValue.Value.ToString() != "No Data") { cycSaleOffice.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in cyc_Weigh_In_Day) { if (pValue.Value.ToString() != "No Data") { cycWeighIn.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in cyc_Bay_Loading_Day) { if (pValue.Value.ToString() != "No Data") { cycBayLoading.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in cyc_Weigh_Out_Day) { if (pValue.Value.ToString() != "No Data") { cycWeighOut.Add(new getData() { Value = pValue.Value.ToString() }); } }


            // calculate for 1 week
            // 4 WEEKS
            for (var j = 0; j < 4; j++) // 4 weeks
            {
                for (var i = 0; i < 7; i++) // 1 week has 7 days
                {
                    // yep, we need to shift these fucking days
                    if (j == 0)
                    {
                        cycSaleSum = cycSaleSum + (Math.Round((Convert.ToDouble(cycSaleOffice[i].Value)), 2));
                        cycWeighInSum = cycWeighInSum + Math.Round((Convert.ToDouble(cycWeighIn[i].Value)), 2);
                        cycWeighOutSum = cycWeighOutSum + Math.Round((Convert.ToDouble(cycWeighOut[i].Value)), 2);
                        cycBayLoadingSum = cycBayLoadingSum + Math.Round((Convert.ToDouble(cycBayLoading[i].Value)), 2);
                    }
                    else if (j == 1)
                    {
                        cycSaleSum = cycSaleSum + (Math.Round((Convert.ToDouble(cycSaleOffice[i + 7].Value)), 2));
                        cycWeighInSum = cycWeighInSum + Math.Round((Convert.ToDouble(cycWeighIn[i + 7].Value)), 2);
                        cycWeighOutSum = cycWeighOutSum + Math.Round((Convert.ToDouble(cycWeighOut[i + 7].Value)), 2);
                        cycBayLoadingSum = cycBayLoadingSum + Math.Round((Convert.ToDouble(cycBayLoading[i + 7].Value)), 2);
                    }
                    else if (j == 2)
                    {
                        cycSaleSum = cycSaleSum + (Math.Round((Convert.ToDouble(cycSaleOffice[i + 14].Value)), 2));
                        cycWeighInSum = cycWeighInSum + Math.Round((Convert.ToDouble(cycWeighIn[i + 14].Value)), 2);
                        cycWeighOutSum = cycWeighOutSum + Math.Round((Convert.ToDouble(cycWeighOut[i + 14].Value)), 2);
                        cycBayLoadingSum = cycBayLoadingSum + Math.Round((Convert.ToDouble(cycBayLoading[i + 14].Value)), 2);
                    }
                    else if (j == 3)
                    {
                        cycSaleSum = cycSaleSum + (Math.Round((Convert.ToDouble(cycSaleOffice[i + 21].Value)), 2));
                        cycWeighInSum = cycWeighInSum + Math.Round((Convert.ToDouble(cycWeighIn[i + 21].Value)), 2);
                        cycWeighOutSum = cycWeighOutSum + Math.Round((Convert.ToDouble(cycWeighOut[i + 21].Value)), 2);
                        cycBayLoadingSum = cycBayLoadingSum + Math.Round((Convert.ToDouble(cycBayLoading[i + 21].Value)), 2);
                    }

                }

                Sale_Office_CycleTime_Weekly[j] = cycSaleSum / 7.0;
                Weigh_In_CycleTime_Weekly[j] = cycWeighInSum / 7.0;
                Weigh_Out_CycleTime_Weekly[j] = cycWeighOutSum / 7.0;
                Bay_Loading_CycleTime_Weekly[j] = cycBayLoadingSum / 7.0;

                cycSaleSum = 0.0;
                cycWeighInSum = 0.0;
                cycWeighOutSum = 0.0;
                cycBayLoadingSum = 0.0;

            }

            // calculate for 1 month
            for (var i = 0; i < 31; i++) { cycSaleSum = cycSaleSum + Math.Round((Convert.ToDouble(cycSaleOffice[i].Value)) / 31, 2); }
            for (var i = 0; i < 31; i++) { cycWeighInSum = cycWeighInSum + Math.Round((Convert.ToDouble(cycWeighIn[i].Value)) / 31, 2); }
            for (var i = 0; i < 31; i++) { cycWeighOutSum = cycWeighOutSum + Math.Round((Convert.ToDouble(cycWeighOut[i].Value)) / 31, 2); }
            for (var i = 0; i < 31; i++) { cycBayLoadingSum = cycBayLoadingSum + Math.Round((Convert.ToDouble(cycBayLoading[i].Value)) / 31, 2); }

            for (var i = 0; i < 4; i++)
            {
                Session["Cyc_Sale_Office_Week_" + (i + 1)] = Sale_Office_CycleTime_Weekly[i];
                Session["Cyc_Weigh_In_Week_" + (i + 1)] = Weigh_In_CycleTime_Weekly[i];
                Session["Cyc_Bay_Loading_Week_" + (i + 1)] = Bay_Loading_CycleTime_Weekly[i];
                Session["Cyc_Weigh_Out_Week_" + (i + 1)] = Weigh_Out_CycleTime_Weekly[i];


                ViewData["CYC_SALE_OFFICE_WEEK_" + (i + 1)] = Session["Cyc_Sale_Office_Week_" + (i + 1)].ToString();
                ViewData["CYC_WEIGH_IN_WEEK_" + (i + 1)] = Session["Cyc_Weigh_In_Week_" + (i + 1)].ToString();
                ViewData["CYC_BAY_LOADING_WEEK_" + (i + 1)] = Session["Cyc_Bay_Loading_Week_" + (i + 1)].ToString();
                ViewData["CYC_WEIGH_OUT_WEEK_" + (i + 1)] = Session["Cyc_Weigh_Out_Week_" + (i + 1)].ToString();
            }

            Session["Cyc_Sale_Office_Month_1"] = cycSaleSum;
            Session["Cyc_Weigh_In_Month_1"] = cycWeighInSum;
            Session["Cyc_Bay_Loading_Month_1"] = cycBayLoadingSum;
            Session["Cyc_Weigh_Out_Month_1"] = cycWeighOutSum;

            ViewData["CYC_SALE_OFFICE_MONTH_1"] = Session["Cyc_Sale_Office_Month_1"];
            ViewData["CYC_WEIGH_IN_MONTH_1"] = Session["Cyc_Weigh_In_Month_1"];
            ViewData["CYC_BAY_LOADING_MONTH_1"] = Session["Cyc_Bay_Loading_Month_1"];
            ViewData["CYC_WEIGH_OUT_MONTH_1"] = Session["Cyc_Weigh_Out_Month_1"];



            // layer 3 : miscellaneous
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>         Layer 3 : MISCELLANEOUS            >>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // ----------------------------------------------------------------------------------------
            //  TRUCK IN/OUT 
            // ----------------------------------------------------------------------------------------

            // :: REALM OF HELL - FindPiPoint
            // array
            // TRUCK IN (4 Weeks and 1 month)

            pt_Total_Truck_In_Week[0] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_32.24705f76-da47-46b3-8824-3fb120bc2997");
            pt_Total_Truck_In_Week[1] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_33.37c86570-5797-413d-a5dc-e12b3e9b0ebd");
            pt_Total_Truck_In_Week[2] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_34.1d1d9850-72c2-487b-996f-951cbc639077");
            pt_Total_Truck_In_Week[3] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_35.3b16d0eb-4366-47b3-a0e9-67499a11ad25");
        
            pt_Total_Truck_In_Month[0] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck in.G4-A004-69-0400-014_36.6ce73b90-865f-4b9e-a40e-83272070da78");

            // TRUCK OUT (4 Weeks and 1 month)

            pt_Total_Truck_Out_Week[0] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_32.f13b7c40-6134-4c10-a5c1-fef9b9f0b502");
            pt_Total_Truck_Out_Week[1] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_33.d175cfba-c309-4f60-a2d0-d4268c61b471");
            pt_Total_Truck_Out_Week[2] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_34.dc913f43-3d16-4965-b7d9-dc37b1edf6ed");
            pt_Total_Truck_Out_Week[3] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_35.2b184071-9444-4b74-83e4-c7efddad1d83");

            pt_Total_Truck_Out_Month[0] = PIPoint.FindPIPoint(piServer, "_G4_Total number truck out.G4-A004-69-0400-014_36.a817e08b-91bc-4cee-a4c2-96f064dc5a87");


            // :: REALM OF HELL - SnapShot Godfather 

            // :: Data Container
            IList<getData> Total_Truck_In_Week = new List<getData>(); // Decipher
            IList<getData> Total_Truck_In_Month = new List<getData>(); // Decipher
            IList<getData> Total_Truck_Out_Week = new List<getData>(); // Decipher
            IList<getData> Total_Truck_Out_Month = new List<getData>(); // Decipher

            // :: Eternity plotValues
            // array then loop
            for (var i = 0; i < 4; i++)
            {
                // Total Truck In Week
                plotTotal_Truck_In_Week[i] = pt_Total_Truck_In_Week[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
                // Total Truck Out Week
                plotTotal_Truck_Out_Week[i] = pt_Total_Truck_Out_Week[i].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            }

            // Total Truck In Month
            plotTotal_Truck_In_Month[0] = pt_Total_Truck_In_Month[0].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            // Total Truck Out Month
            plotTotal_Truck_Out_Month[0] = pt_Total_Truck_Out_Month[0].PlotValues(new AFTimeRange("*-3y", "*"), 1000000000);
            
            // Total Truck In Week and Month

            foreach (var pValue in plotTotal_Truck_In_Week[0]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_Week_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In_Week[1]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_Week_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In_Week[2]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_Week_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_In_Week[3]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_Week_4 = pValue.Value.ToString(); } }
        
            foreach (var pValue in plotTotal_Truck_In_Month[0]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_In_Month_1 = pValue.Value.ToString(); } }

            // Total Truck Out Week and Month

            foreach (var pValue in plotTotal_Truck_Out_Week[0]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_Week_1 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out_Week[1]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_Week_2 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out_Week[2]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_Week_3 = pValue.Value.ToString(); } }
            foreach (var pValue in plotTotal_Truck_Out_Week[3]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_Week_4 = pValue.Value.ToString(); } }

            foreach (var pValue in plotTotal_Truck_Out_Month[0]) { if (pValue.Value.ToString() != "No Data") { Total_Truck_Out_Month_1 = pValue.Value.ToString(); } }

            // :: REALM OF HELL - SESSION GODFATHER

            // Total Truck In/Out Week and Month- in
            Session["total_truck_in_week_1"] = Math.Round((Convert.ToDouble(Total_Truck_In_Week_1)), 2);
            Session["total_truck_in_week_2"] = Math.Round((Convert.ToDouble(Total_Truck_In_Week_2)), 2);
            Session["total_truck_in_week_3"] = Math.Round((Convert.ToDouble(Total_Truck_In_Week_3)), 2);
            Session["total_truck_in_week_4"] = Math.Round((Convert.ToDouble(Total_Truck_In_Week_4)), 2);

            Session["total_truck_in_month_1"] = Math.Round((Convert.ToDouble(Total_Truck_In_Month_1)), 2); 

            // Total Truck In/Out Week and Month- out
            Session["total_truck_out_week_1"] = Math.Round((Convert.ToDouble(Total_Truck_Out_Week_1)), 2);
            Session["total_truck_out_week_2"] = Math.Round((Convert.ToDouble(Total_Truck_Out_Week_2)), 2);
            Session["total_truck_out_week_3"] = Math.Round((Convert.ToDouble(Total_Truck_Out_Week_3)), 2);
            Session["total_truck_out_week_4"] = Math.Round((Convert.ToDouble(Total_Truck_Out_Week_4)), 2);

            Session["total_truck_out_month_1"] = Math.Round((Convert.ToDouble(Total_Truck_Out_Month_1)), 2);

            // :: REALM OF HELL - ViewData
            for (var i = 1; i <= 4; i++)
            {
                ViewData["TOTAL_TRUCK_IN_WEEK_" + i] = Session["total_truck_in_week_" + i];
                ViewData["TOTAL_TRUCK_OUT_WEEK_" + i] = Session["total_truck_out_week_" + i];

            }

            // BEWARE! BUG OF MONTH AND WEEK VARIABLE USAGE !!!
            // WEEK 5 == MONTH 1 !!!
            ViewData["TOTAL_TRUCK_IN_MONTH_1"] = Session["total_truck_in_month_1"];
            ViewData["TOTAL_TRUCK_OUT_MONTH_1"] = Session["total_truck_out_month_1"];

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                        DATE                                           ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            ViewData["Week"] = Session["week"];

            return View();
        }

        //.................................................................................................................................
        //.RRRRRRRRRR...EEEEEEEEEEE.ETTTTTTTTTTUUUU...UUUU..RRRRRRRRRR...NNNN...NNNN.......DDDDDDDDD.......AAAAA...AATTTTTTTTTTTEEEEEEEEE..
        //.RRRRRRRRRRR..EEEEEEEEEEE.ETTTTTTTTTTUUUU...UUUU..RRRRRRRRRRR..NNNNN..NNNN.......DDDDDDDDDD......AAAAA...AATTTTTTTTTTTEEEEEEEEE..
        //.RRRRRRRRRRR..EEEEEEEEEEE.ETTTTTTTTTTUUUU...UUUU..RRRRRRRRRRR..NNNNN..NNNN.......DDDDDDDDDDD....AAAAAA...AATTTTTTTTTTTEEEEEEEEE..
        //.RRRR...RRRRR.EEEE...........TTTT....UUUU...UUUU..RRRR...RRRRR.NNNNNN.NNNN.......DDDD...DDDD....AAAAAAA......TTTT...TTEE.........
        //.RRRR...RRRRR.EEEE...........TTTT....UUUU...UUUU..RRRR...RRRRR.NNNNNN.NNNN.......DDDD....DDDD..AAAAAAAA......TTTT...TTEE.........
        //.RRRRRRRRRRR..EEEEEEEEEE.....TTTT....UUUU...UUUU..RRRRRRRRRRR..NNNNNNNNNNN.......DDDD....DDDD..AAAAAAAA......TTTT...TTEEEEEEEEE..
        //.RRRRRRRRRRR..EEEEEEEEEE.....TTTT....UUUU...UUUU..RRRRRRRRRRR..NNNNNNNNNNN.......DDDD....DDDD..AAAA.AAAA.....TTTT...TTEEEEEEEEE..
        //.RRRRRRRR.....EEEEEEEEEE.....TTTT....UUUU...UUUU..RRRRRRRR.....NNNNNNNNNNN.......DDDD....DDDD.AAAAAAAAAA.....TTTT...TTEEEEEEEEE..
        //.RRRR.RRRR....EEEE...........TTTT....UUUU...UUUU..RRRR.RRRR....NNNNNNNNNNN.......DDDD....DDDD.AAAAAAAAAAA....TTTT...TTEE.........
        //.RRRR..RRRR...EEEE...........TTTT....UUUU...UUUU..RRRR..RRRR...NNNN.NNNNNN.......DDDD...DDDDD.AAAAAAAAAAA....TTTT...TTEE.........
        //.RRRR..RRRRR..EEEEEEEEEEE....TTTT....UUUUUUUUUUU..RRRR..RRRRR..NNNN..NNNNN.......DDDDDDDDDDD.DAAA....AAAA....TTTT...TTEEEEEEEEE..
        //.RRRR...RRRRR.EEEEEEEEEEE....TTTT.....UUUUUUUUU...RRRR...RRRRR.NNNN..NNNNN.......DDDDDDDDDD..DAAA.....AAAA...TTTT...TTEEEEEEEEE..
        //.RRRR....RRRR.EEEEEEEEEEE....TTTT......UUUUUUU....RRRR....RRRR.NNNN...NNNN.......DDDDDDDDD..DDAAA.....AAAA...TTTT...TTEEEEEEEEE..
        //.................................................................................................................................
        //....................................................................................................
        //.....AAAAA.....NNNN...NNNN..DDDDDDDDD....... WWWW..WWWWW...WWWEEEEEEEEEEEE.EEEEEEEEEEE.KKKK...KKKK..
        //.....AAAAA.....NNNNN..NNNN..DDDDDDDDDD.......WWWW..WWWWW..WWWW.EEEEEEEEEEE.EEEEEEEEEEE.KKKK..KKKKK..
        //....AAAAAA.....NNNNN..NNNN..DDDDDDDDDDD......WWWW..WWWWWW.WWWW.EEEEEEEEEEE.EEEEEEEEEEE.KKKK.KKKKK...
        //....AAAAAAA....NNNNNN.NNNN..DDDD...DDDD......WWWW.WWWWWWW.WWWW.EEEE........EEEE........KKKKKKKKK....
        //...AAAAAAAA....NNNNNN.NNNN..DDDD....DDDD.....WWWW.WWWWWWW.WWWW.EEEE........EEEE........KKKKKKKK.....
        //...AAAAAAAA....NNNNNNNNNNN..DDDD....DDDD......WWWWWWWWWWW.WWW..EEEEEEEEEE..EEEEEEEEEE..KKKKKKKK.....
        //...AAAA.AAAA...NNNNNNNNNNN..DDDD....DDDD......WWWWWWW.WWWWWWW..EEEEEEEEEE..EEEEEEEEEE..KKKKKKKK.....
        //..AAAAAAAAAA...NNNNNNNNNNN..DDDD....DDDD......WWWWWWW.WWWWWWW..EEEEEEEEEE..EEEEEEEEEE..KKKKKKKKK....
        //..AAAAAAAAAAA..NNNNNNNNNNN..DDDD....DDDD......WWWWWWW.WWWWWWW..EEEE........EEEE........KKKK.KKKKK...
        //..AAAAAAAAAAA..NNNN.NNNNNN..DDDD...DDDDD......WWWWWWW.WWWWWWW..EEEE........EEEE........KKKK..KKKK...
        //.AAAA....AAAA..NNNN..NNNNN..DDDDDDDDDDD........WWWWW...WWWWW...EEEEEEEEEEE.EEEEEEEEEEE.KKKK..KKKKK..
        //.AAAA.....AAAA.NNNN..NNNNN..DDDDDDDDDD.........WWWWW...WWWWW...EEEEEEEEEEE.EEEEEEEEEEE.KKKK...KKKK..
        //.AAAA.....AAAA.NNNN...NNNN..DDDDDDDDD..........WWWWW...WWWWW...EEEEEEEEEEE.EEEEEEEEEEE.KKKK...KKKK..
        //....................................................................................................



        [HttpGet]
        // get: selected date
        public ActionResult DateSelectorOperator(int id)
        {
            Session["date"] = id;
            ViewData["day"] = Session["date"];
            Debug.WriteLine(id);
            Debug.WriteLine(ViewData["day"]);
            return RedirectToAction("DashboardOperator","Dashboard");
        }

        [HttpGet]
        // get: selected date
        public ActionResult WeekSelectorManager(int id)
        {
            Session["week"] = id;
            ViewData["Week"] = Session["week"];
            Debug.WriteLine(id);
            Debug.WriteLine(ViewData["Week"]);
            return RedirectToAction("DashboardManager", "Dashboard");
        }
    }
}