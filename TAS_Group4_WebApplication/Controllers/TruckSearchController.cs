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
    public class TruckSearchController : Controller
    {
        [HttpGet]
        // GET: TruckSearch
        public ActionResult Index(int id)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //                                    LOG-IN SESSION                                     ::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Session["status"] = id;
            ViewData["status"] = Session["status"];

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
            IList<getData> poNo = new List<getData>();
            IList<getData> licensePlate = new List<getData>();
            IList<getData> petrolType = new List<getData>();
            IList<getData> saleOfficeArrived = new List<getData>();
            IList<getData> saleOfficeDeparted = new List<getData>();
            IList<getData> saleOfficeCycle = new List<getData>();
            IList<getData> WeighInArrived = new List<getData>();
            IList<getData> WeighInDeparted = new List<getData>();
            IList<getData> WeighInCycle = new List<getData>();
            IList<getData> WeighOutArrived = new List<getData>();
            IList<getData> WeighOutDeparted = new List<getData>();
            IList<getData> WeighOutCycle = new List<getData>();
            IList<getData> LoadingArrived = new List<getData>();
            IList<getData> LoadingDeparted = new List<getData>();
            IList<getData> LoadingCycle = new List<getData>();
            IList<getData> ptExit = new List<getData>();

            // get value from tag
            var pt_Po_No = PIPoint.FindPIPoint(piServer, "G4-A004-48-0000-006");
            var pt_License_Plate = PIPoint.FindPIPoint(piServer, "G4-A004-48-0000-001");
            var pt_Petrol_Type = PIPoint.FindPIPoint(piServer, "G4-A004-48-0000-023");
            var pt_Sale_Office_Arrived = PIPoint.FindPIPoint(piServer, "G4-A004-38-0000-010");
            var pt_Sale_Office_Departed = PIPoint.FindPIPoint(piServer, "G4-A004-38-0000-014");
            var pt_Sale_Office_Cycle = PIPoint.FindPIPoint(piServer, "G4-A004-49-0000-001");
            var pt_Weigh_In_Arrived = PIPoint.FindPIPoint(piServer, "G4-A004-38-0300-011");
            var pt_Weigh_In_Departed = PIPoint.FindPIPoint(piServer, "G4-A004-38-0300-015");
            var pt_Weigh_In_Cycle = PIPoint.FindPIPoint(piServer, "G4-A004-49-0300-002");
            var pt_Weigh_Out_Arrived = PIPoint.FindPIPoint(piServer, "G4-A004-38-0300-013");
            var pt_Weigh_Out_Departed = PIPoint.FindPIPoint(piServer, "G4-A004-38-0300-017");
            var pt_Weigh_Out_Cycle = PIPoint.FindPIPoint(piServer, "G4-A004-49-0300-005");
            var pt_Bay_Loading_Arrived = PIPoint.FindPIPoint(piServer, "G4-A004-38-0100-012");
            var pt_Bay_Loading_Departed = PIPoint.FindPIPoint(piServer, "G4-A004-38-0100-016");
            var pt_Bay_Loading_Cycle = PIPoint.FindPIPoint(piServer, "G4-A004-49-0100-019"); //
            var pt_Exit = PIPoint.FindPIPoint(piServer, "G4-A004-38-0000-024"); // _2 = time

            // get historical data
            var plotPoNo = pt_Po_No.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotLicensePlate = pt_License_Plate.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotPetrolType = pt_Petrol_Type.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotSaleOfficeArrived = pt_Sale_Office_Arrived.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotSaleOfficeDeparted = pt_Sale_Office_Departed.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotSaleOfficeCycle = pt_Sale_Office_Cycle.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotWeighInArrived = pt_Weigh_In_Arrived.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotWeighInDeparted = pt_Weigh_In_Departed.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotWeighInCycle = pt_Weigh_In_Cycle.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotWeighOutArrived = pt_Weigh_Out_Arrived.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotWeighOutDeparted = pt_Weigh_Out_Departed.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotWeighOutCycle = pt_Weigh_Out_Cycle.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotBayLoadingArrived = pt_Bay_Loading_Arrived.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotBayLoadingDeparted = pt_Bay_Loading_Departed.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotBayLoadingCycle = pt_Bay_Loading_Cycle.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);
            var plotExit = pt_Exit.PlotValues(new AFTimeRange("*-3y", "*"), 2147483647);


            foreach (var pValue in plotPoNo) { if (pValue.Value.ToString() != "No Data") { poNo.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotLicensePlate) { if (pValue.Value.ToString() != "No Data") { licensePlate.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotPetrolType) { if (pValue.Value.ToString() != "No Data") { petrolType.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotSaleOfficeArrived) { if (pValue.Value.ToString() != "No Data") { saleOfficeArrived.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotSaleOfficeDeparted) { if (pValue.Value.ToString() != "No Data") { saleOfficeDeparted.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotSaleOfficeCycle) { if (pValue.Value.ToString() != "No Data") { saleOfficeCycle.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotWeighInArrived) { if (pValue.Value.ToString() != "No Data") { WeighInArrived.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotWeighInDeparted) { if (pValue.Value.ToString() != "No Data") { WeighInDeparted.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotWeighInCycle) { if (pValue.Value.ToString() != "No Data") { WeighInCycle.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotWeighOutArrived) { if (pValue.Value.ToString() != "No Data") { WeighOutArrived.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotWeighOutDeparted) { if (pValue.Value.ToString() != "No Data") { WeighOutDeparted.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotWeighOutCycle) { if (pValue.Value.ToString() != "No Data") { WeighOutCycle.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotBayLoadingArrived) { if (pValue.Value.ToString() != "No Data") { LoadingArrived.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotBayLoadingDeparted) { if (pValue.Value.ToString() != "No Data") { LoadingDeparted.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotBayLoadingCycle) { if (pValue.Value.ToString() != "No Data") { LoadingCycle.Add(new getData() { Value = pValue.Value.ToString() }); } }
            foreach (var pValue in plotExit) { if (pValue.Value.ToString() != "No Data") { ptExit.Add(new getData() { Value = pValue.Value.ToString() }); } }

            // debug
            for (var i = 0; i < 3082; i++)
            {
                //Debug.WriteLine(truckSearch[i].License_Plate);
                //Debug.WriteLine(i);
                Session["Po_No_" + i] = poNo[i].Value;
                Session["License_Plate_" + i] = licensePlate[i].Value;
                Session["Petrol_Type_" + i] = petrolType[i].Value;
                Session["Sale_Office_Arrived_Time_" + i] = saleOfficeArrived[i].Value;
                Session["Sale_Office_Departed_Time_" + i] = saleOfficeDeparted[i].Value;
                Session["Sale_Office_Cycle_Time_" + i] = Math.Round((Convert.ToDouble(saleOfficeCycle[i].Value)), 2);
                Session["Weigh_In_Arrived_Time_" + i] = WeighInArrived[i].Value;
                Session["Weigh_In_Departed_Time_" + i] = WeighInDeparted[i].Value;
                Session["Weigh_In_Cycle_Time_" + i] = Math.Round((Convert.ToDouble(WeighInCycle[i].Value)), 2);
                Session["Weigh_Out_Arrived_Time_" + i] = WeighOutArrived[i].Value;
                Session["Weigh_Out_Departed_Time_" + i] = WeighOutDeparted[i].Value;
                Session["Weigh_Out_Cycle_Time_" + i] = Math.Round((Convert.ToDouble(WeighOutCycle[i].Value)), 2);
                Session["Bay_Loading_Arrived_Time_" + i] = LoadingArrived[i].Value;
                Session["Bay_Loading_Departed_Time_" + i] = LoadingDeparted[i].Value;
                Session["Bay_Loading_Cycle_Time_" + i] = Math.Round((Convert.ToDouble(LoadingCycle[i].Value)), 2);
                Session["Exit_" + i] = ptExit[i].Value;

                ViewData["PO_NO_" + i] = Session["Po_No_" + i].ToString();
                ViewData["LICENSE_PLATE_" + i] = Session["License_Plate_" + i].ToString();
                ViewData["PETROL_TYPE_" + i] = Session["Petrol_Type_" + i].ToString();
                ViewData["SALE_OFFICE_ARRIVED_TIME_" + i] = Session["Sale_Office_Arrived_Time_" + i].ToString();
                ViewData["SALE_OFFICE_DEPARTED_TIME_" + i] = Session["Sale_Office_Departed_Time_" + i].ToString();
                ViewData["SALE_OFFICE_CYCLE_TIME_" + i] = Session["Sale_Office_Cycle_Time_" + i].ToString();
                ViewData["WEIGH_IN_ARRIVED_TIME_" + i] = Session["Weigh_In_Arrived_Time_" + i].ToString();
                ViewData["WEIGH_IN_DEPARTED_TIME_" + i] = Session["Weigh_In_Departed_Time_" + i].ToString();
                ViewData["WEIGH_IN_CYCLE_TIME_" + i] = Session["Weigh_In_Cycle_Time_" + i].ToString();
                ViewData["WEIGH_OUT_ARRIVED_TIME_" + i] = Session["Weigh_Out_Arrived_Time_" + i].ToString();
                ViewData["WEIGH_OUT_DEPARTED_TIME_" + i] = Session["Weigh_Out_Departed_Time_" + i].ToString();
                ViewData["WEIGH_OUT_CYCLE_TIME_" + i] = Session["Weigh_Out_Cycle_Time_" + i].ToString();
                ViewData["BAY_LOADING_ARRIVED_TIME_" + i] = Session["Bay_Loading_Arrived_Time_" + i].ToString();
                ViewData["BAY_LOADING_DEPARTED_TIME_" + i] = Session["Bay_Loading_Departed_Time_" + i].ToString();
                ViewData["BAY_LOADING_CYCLE_TIME_" + i] = Session["Bay_Loading_Cycle_Time_" + i].ToString();
                ViewData["EXIT_" + i] = Session["Exit_" + i].ToString();

                // Debug


                // Debug.WriteLine(licensePlate[i].Value);


            }





            return View();
        }
    }
}