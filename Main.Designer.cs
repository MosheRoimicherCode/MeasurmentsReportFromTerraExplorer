namespace MeasurmentsReportFromTerraExplorer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Line_btn = new Button();
            Area_btn = new Button();
            report_btn = new Button();
            Measurment_tbox = new TextBox();
            group_tbox = new TextBox();
            measure_lbl = new Label();
            groupName_lbl = new Label();
            createGroup_btn = new Button();
            point_btn = new Button();
            group_ComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            lang_comBom = new ComboBox();
            SuspendLayout();
            // 
            // Line_btn
            // 
            Line_btn.Location = new Point(12, 56);
            Line_btn.Name = "Line_btn";
            Line_btn.Size = new Size(83, 35);
            Line_btn.TabIndex = 0;
            Line_btn.Text = "Line";
            Line_btn.UseVisualStyleBackColor = true;
            Line_btn.Click += Line_btn_Click;
            // 
            // Area_btn
            // 
            Area_btn.Location = new Point(101, 56);
            Area_btn.Name = "Area_btn";
            Area_btn.Size = new Size(88, 35);
            Area_btn.TabIndex = 1;
            Area_btn.Text = "Area";
            Area_btn.UseVisualStyleBackColor = true;
            Area_btn.Click += Area_btn_Click;
            // 
            // report_btn
            // 
            report_btn.Location = new Point(12, 264);
            report_btn.Name = "report_btn";
            report_btn.Size = new Size(264, 42);
            report_btn.TabIndex = 3;
            report_btn.Text = "Generate Report";
            report_btn.UseVisualStyleBackColor = true;
            report_btn.Click += report_btn_Click;
            // 
            // Measurment_tbox
            // 
            Measurment_tbox.Location = new Point(12, 27);
            Measurment_tbox.Name = "Measurment_tbox";
            Measurment_tbox.Size = new Size(163, 23);
            Measurment_tbox.TabIndex = 4;
            // 
            // group_tbox
            // 
            group_tbox.Location = new Point(12, 131);
            group_tbox.Name = "group_tbox";
            group_tbox.Size = new Size(100, 23);
            group_tbox.TabIndex = 5;
            // 
            // measure_lbl
            // 
            measure_lbl.AutoSize = true;
            measure_lbl.Location = new Point(12, 9);
            measure_lbl.Name = "measure_lbl";
            measure_lbl.Size = new Size(115, 15);
            measure_lbl.TabIndex = 6;
            measure_lbl.Text = "Measurement Name";
            // 
            // groupName_lbl
            // 
            groupName_lbl.AutoSize = true;
            groupName_lbl.Location = new Point(12, 113);
            groupName_lbl.Name = "groupName_lbl";
            groupName_lbl.Size = new Size(75, 15);
            groupName_lbl.TabIndex = 7;
            groupName_lbl.Text = "Group Name";
            // 
            // createGroup_btn
            // 
            createGroup_btn.Location = new Point(12, 160);
            createGroup_btn.Name = "createGroup_btn";
            createGroup_btn.Size = new Size(102, 34);
            createGroup_btn.TabIndex = 8;
            createGroup_btn.Text = "Create Group";
            createGroup_btn.UseVisualStyleBackColor = true;
            createGroup_btn.Click += createGroup_btn_Click;
            // 
            // point_btn
            // 
            point_btn.Location = new Point(195, 56);
            point_btn.Name = "point_btn";
            point_btn.Size = new Size(82, 35);
            point_btn.TabIndex = 2;
            point_btn.Text = "Point";
            point_btn.UseVisualStyleBackColor = true;
            point_btn.Click += point_btn_Click;
            // 
            // group_ComboBox
            // 
            group_ComboBox.FormattingEnabled = true;
            group_ComboBox.Location = new Point(12, 235);
            group_ComboBox.Name = "group_ComboBox";
            group_ComboBox.Size = new Size(135, 23);
            group_ComboBox.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 217);
            label1.Name = "label1";
            label1.Size = new Size(135, 15);
            label1.TabIndex = 11;
            label1.Text = "Select a Group To Export";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(153, 217);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 12;
            label2.Text = "Language";
            // 
            // lang_comBom
            // 
            lang_comBom.FormattingEnabled = true;
            lang_comBom.Items.AddRange(new object[] { "HE", "EN" });
            lang_comBom.Location = new Point(156, 235);
            lang_comBom.Name = "lang_comBom";
            lang_comBom.Size = new Size(56, 23);
            lang_comBom.TabIndex = 13;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 318);
            Controls.Add(lang_comBom);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(group_ComboBox);
            Controls.Add(createGroup_btn);
            Controls.Add(groupName_lbl);
            Controls.Add(measure_lbl);
            Controls.Add(group_tbox);
            Controls.Add(Measurment_tbox);
            Controls.Add(report_btn);
            Controls.Add(point_btn);
            Controls.Add(Area_btn);
            Controls.Add(Line_btn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "Main";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Line_btn;
        private Button Area_btn;
        private Button report_btn;
        private TextBox Measurment_tbox;
        private TextBox group_tbox;
        private Label measure_lbl;
        private Label groupName_lbl;
        private Button createGroup_btn;
        private Button point_btn;
        private ComboBox group_ComboBox;
        private Label label1;
        private Label label2;
        private ComboBox lang_comBom;
    }
}