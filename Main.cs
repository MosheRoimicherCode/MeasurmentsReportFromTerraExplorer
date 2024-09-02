using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeManagement;
using TerraExplorerX;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MeasurmentsReportFromTerraExplorer
{
    public partial class Main : Form
    {
        Measurments measurments = new Measurments();
        public Main()
        {
            InitializeComponent();
            resetMeasurmentName();
            measurments.atachStartEvents();
            populateListBox(group_ComboBox);
        }
        private void resetMeasurmentName()
        {
            Measurment_tbox.Text = "Measurment from: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }
        private void Line_btn_Click(object sender, EventArgs e)
        {
            measurments.CreateLineMeasurment(Measurment_tbox.Text);
        }

        private void Area_btn_Click(object sender, EventArgs e)
        {
            measurments.CreateAreaMeasurment(Measurment_tbox.Text);
        }

        private void point_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the text from the TextBox
                string measurementText = Measurment_tbox.Text;

                // Check if the input is not empty or null
                if (!string.IsNullOrWhiteSpace(measurementText))
                {
                    // Call the CreatePoint method with the user input
                    measurments.CreatePoint(measurementText);
                }
                else
                {
                    // Inform the user that the input is invalid
                    MessageBox.Show("Please enter a valid measurement.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle any potential errors that occur during the operation
                MessageBox.Show($"An error occurred while creating the point: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void createGroup_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the text from the TextBox
                string groupName = group_tbox.Text;

                // Check if the input is not empty or null
                if (!string.IsNullOrWhiteSpace(groupName))
                {
                    // Call the CreateGroup method with the user input
                    measurments.CreateGroup(groupName);
                    populateListBox(group_ComboBox);
                }
                else
                {
                    // Inform the user that the input is invalid
                    MessageBox.Show("Please enter a valid group name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle any potential errors that occur during the operation
                MessageBox.Show($"An error occurred while creating the group: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void report_btn_Click(object sender, EventArgs e)
        {
            if (group_ComboBox.SelectedItem != null)
            {
                // Cast SelectedItem to KeyValuePair<string, string>
                var selectedItem = (KeyValuePair<string, string>)group_ComboBox.SelectedItem;

                // Get the selected text and value
                string selectedText = selectedItem.Value; // The visible text in the ComboBox
                string selectedValue = selectedItem.Key;  // The hidden value (ID)

                measurments.GenerateReport(selectedText);
            }
        }

        private void populateListBox(System.Windows.Forms.ComboBox listBox)
        {  
            // Clear the current items in the select box (ComboBox or another ListBox)
            listBox.Items.Clear();  // Assuming `selectBox` is the name of your select box control

            // Set the display and value members
            listBox.DisplayMember = "Value"; // Display the name
            listBox.ValueMember = "Key";     // Store the ID

            // Add the new items to the select box
            foreach (var child in measurments.getGroupChields())
            {
                listBox.Items.Add(new KeyValuePair<string, string>(child.Id, child.Name));
            }
        }
    }
}
