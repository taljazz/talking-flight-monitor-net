using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class frmNearbyAircraft : Form
    {
        List<AIPlaneInfo> groundTraffic;
        List<AIPlaneInfo> airbornTraffic;
        public frmNearbyAircraft(List<AIPlaneInfo> groundTraffic, List<AIPlaneInfo> airbornTraffic)
        {
            InitializeComponent();
            this.groundTraffic = groundTraffic;
            this.airbornTraffic = airbornTraffic;
        }

        private void frmNearbyAircraft_Load(object sender, EventArgs e)
        {
            if (Aircraft.OnGround.Value == 0)
            {
                tcTraffic.SelectedTab = tabAirborn;
            }
            else
            {
                tcTraffic.SelectedTab = tabGround;
            }
            foreach (AIPlaneInfo plane in groundTraffic)
            {
                addToGroundList(plane);
            }
            
            foreach (AIPlaneInfo plane in airbornTraffic)
            {
                addToAirbornList(plane);
            }

        }

        private void addToGroundList(AIPlaneInfo plane)
        {
            var database = FSUIPCConnection.AirportsDatabase;
            // Add this plane to the list
            // Create a new list item
            ListViewItem newItem = new ListViewItem();
            // ATC Callsign
            newItem.Text = $"{plane.Airline} {plane.FlightNumber}";
            // status
            newItem.SubItems.Add(plane.State.ToString());
            if (plane.State.ToString() == "TaxiingIn")
            {
                newItem.SubItems[1].Text = $"Taxiing in to {plane.GateInfo.ID}";
            }
            if (plane.State.ToString() == "TaxiingOut")
            {
                newItem.SubItems[1].Text = $"Taxiing out to {plane.RunwayAssigned.ToString()}";
            }
            
            // aircraft type
            newItem.SubItems.Add($"{plane.AircraftType} {plane.AircraftModel}");
            newItem.SubItems.Add(plane.DistanceFeet.ToString("F0"));
            // from ICAO
            newItem.SubItems.Add(plane.DepartureICAO);
            // to ICAO
            newItem.SubItems.Add(plane.ArrivalICAO);    
            if (plane.IsAtGate == true)
            {
                newItem.SubItems.Add(plane.GateInfo.ID);
            }
            else if (plane.IsOnRunway == true)
            {
                newItem.SubItems.Add(plane.RunwayAssigned.ToString());
            }
            else
            {
                foreach (FsAirport airport in database.Airports)
                {
                    foreach (FsTaxiway taxiway in airport.Taxiways)
                    {
                        foreach (FsTaxiwaySegment segment in taxiway.Segments)
                        {
                            if (segment.Bounds.ContainsPoint(plane.Location))
                            {
                                newItem.SubItems.Add($" taxi way {taxiway.Name}");

                            }
                        }
                    } // Loop through taxiways.
                }


            }
            // Add to the list
            this.lvGround.Items.Add(newItem);
        }
        private void addToAirbornList(AIPlaneInfo plane)
        {
            // Add this plane to the list
            // Create a new list item
            ListViewItem newItem = new ListViewItem();
            // ATC Callsign
            newItem.Text = $"{plane.Airline} {plane.FlightNumber}";
            // status
            newItem.SubItems.Add(plane.State.ToString());
            // distance in Nautical Miles
            newItem.SubItems.Add(plane.DistanceNM.ToString("F0"));
            // from ICAO
            // newItem.SubItems.Add(plane.DepartureICAO);
            // to ICAO
            // newItem.SubItems.Add(plane.ArrivalICAO);    
            // altitude
            newItem.SubItems.Add(plane.AltitudeFeet.ToString("F0"));

            // Add to the list
            this.lvAirborn.Items.Add(newItem);
        }

    }
}
