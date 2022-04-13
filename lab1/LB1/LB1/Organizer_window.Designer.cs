namespace LB1
{
    partial class Organizer_window
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
            this.components = new System.ComponentModel.Container();
            this.Operations = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Find = new System.Windows.Forms.Button();
            this.Filter = new System.Windows.Forms.Button();
            this.View = new System.Windows.Forms.GroupBox();
            this.events = new System.Windows.Forms.RadioButton();
            this.category = new System.Windows.Forms.RadioButton();
            this.TypeMode = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DataEvents = new System.Windows.Forms.DataGridView();
            this.imeg = new System.Windows.Forms.DataGridViewImageColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Addrevresh = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Operations.SuspendLayout();
            this.View.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataEvents)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Operations
            // 
            this.Operations.Controls.Add(this.tableLayoutPanel1);
            this.Operations.Controls.Add(this.Find);
            this.Operations.Controls.Add(this.Filter);
            this.Operations.Font = new System.Drawing.Font("Open Sans ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Operations.ForeColor = System.Drawing.Color.White;
            this.Operations.Location = new System.Drawing.Point(2, 458);
            this.Operations.Margin = new System.Windows.Forms.Padding(2);
            this.Operations.Name = "Operations";
            this.Operations.Padding = new System.Windows.Forms.Padding(2);
            this.Operations.Size = new System.Drawing.Size(474, 100);
            this.Operations.TabIndex = 0;
            this.Operations.TabStop = false;
            this.Operations.Text = "Menu";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(324, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(145, 62);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Find
            // 
            this.Find.BackColor = System.Drawing.Color.White;
            this.Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Find.Font = new System.Drawing.Font("Open Sans ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Find.ForeColor = System.Drawing.Color.MediumPurple;
            this.Find.Location = new System.Drawing.Point(167, 28);
            this.Find.Margin = new System.Windows.Forms.Padding(2);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(152, 54);
            this.Find.TabIndex = 1;
            this.Find.Text = "Find";
            this.Find.UseVisualStyleBackColor = false;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // Filter
            // 
            this.Filter.BackColor = System.Drawing.Color.White;
            this.Filter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Filter.Cursor = System.Windows.Forms.Cursors.Default;
            this.Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Filter.Font = new System.Drawing.Font("Open Sans ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Filter.ForeColor = System.Drawing.Color.MediumPurple;
            this.Filter.Location = new System.Drawing.Point(4, 28);
            this.Filter.Margin = new System.Windows.Forms.Padding(2);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(152, 54);
            this.Filter.TabIndex = 0;
            this.Filter.Text = "Filter";
            this.Filter.UseVisualStyleBackColor = false;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // View
            // 
            this.View.Controls.Add(this.events);
            this.View.Controls.Add(this.category);
            this.View.Controls.Add(this.TypeMode);
            this.View.Font = new System.Drawing.Font("Open Sans ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.View.ForeColor = System.Drawing.Color.White;
            this.View.Location = new System.Drawing.Point(2, 2);
            this.View.Margin = new System.Windows.Forms.Padding(2);
            this.View.Name = "View";
            this.View.Padding = new System.Windows.Forms.Padding(2);
            this.View.Size = new System.Drawing.Size(474, 130);
            this.View.TabIndex = 1;
            this.View.TabStop = false;
            this.View.Text = "View";
            // 
            // events
            // 
            this.events.AutoSize = true;
            this.events.Font = new System.Drawing.Font("Open Sans ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.events.ForeColor = System.Drawing.Color.White;
            this.events.Location = new System.Drawing.Point(5, 28);
            this.events.Margin = new System.Windows.Forms.Padding(2);
            this.events.Name = "events";
            this.events.Size = new System.Drawing.Size(129, 31);
            this.events.TabIndex = 2;
            this.events.TabStop = true;
            this.events.Text = "All events";
            this.events.UseVisualStyleBackColor = true;
            this.events.CheckedChanged += new System.EventHandler(this.events_CheckedChanged);
            // 
            // category
            // 
            this.category.AutoSize = true;
            this.category.Font = new System.Drawing.Font("Open Sans ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.category.ForeColor = System.Drawing.Color.White;
            this.category.Location = new System.Drawing.Point(4, 61);
            this.category.Margin = new System.Windows.Forms.Padding(2);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(178, 31);
            this.category.TabIndex = 1;
            this.category.TabStop = true;
            this.category.Text = "All by category";
            this.category.UseVisualStyleBackColor = true;
            this.category.CheckedChanged += new System.EventHandler(this.category_CheckedChanged);
            // 
            // TypeMode
            // 
            this.TypeMode.FormattingEnabled = true;
            this.TypeMode.Items.AddRange(new object[] {
            "Памятка",
            "Встреча",
            "Задание"});
            this.TypeMode.Location = new System.Drawing.Point(318, 61);
            this.TypeMode.Margin = new System.Windows.Forms.Padding(2);
            this.TypeMode.Name = "TypeMode";
            this.TypeMode.Size = new System.Drawing.Size(148, 35);
            this.TypeMode.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.View);
            this.flowLayoutPanel1.Controls.Add(this.DataEvents);
            this.flowLayoutPanel1.Controls.Add(this.Operations);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(482, 564);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // DataEvents
            // 
            this.DataEvents.AllowUserToAddRows = false;
            this.DataEvents.AllowUserToDeleteRows = false;
            this.DataEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imeg,
            this.Data,
            this.Time,
            this.Event,
            this.Type});
            this.DataEvents.Location = new System.Drawing.Point(2, 136);
            this.DataEvents.Margin = new System.Windows.Forms.Padding(2);
            this.DataEvents.Name = "DataEvents";
            this.DataEvents.ReadOnly = true;
            this.DataEvents.RowHeadersWidth = 51;
            this.DataEvents.RowTemplate.Height = 24;
            this.DataEvents.Size = new System.Drawing.Size(474, 318);
            this.DataEvents.TabIndex = 2;
            this.DataEvents.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataEvents_CellEnter);
            this.DataEvents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataEvents_MouseClick);
            // 
            // imeg
            // 
            this.imeg.FillWeight = 42.78075F;
            this.imeg.HeaderText = "";
            this.imeg.MinimumWidth = 6;
            this.imeg.Name = "imeg";
            this.imeg.ReadOnly = true;
            this.imeg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imeg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Data
            // 
            this.Data.FillWeight = 119.0731F;
            this.Data.HeaderText = "Date";
            this.Data.MinimumWidth = 6;
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Time
            // 
            this.Time.FillWeight = 119.0731F;
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Event
            // 
            this.Event.FillWeight = 119.0731F;
            this.Event.HeaderText = "Events";
            this.Event.MinimumWidth = 6;
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Visible = false;
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Addrevresh,
            this.Delete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(129, 48);
            // 
            // Addrevresh
            // 
            this.Addrevresh.Name = "Addrevresh";
            this.Addrevresh.Size = new System.Drawing.Size(128, 22);
            this.Addrevresh.Text = "Изменить";
            this.Addrevresh.Click += new System.EventHandler(this.Addrevresh_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(128, 22);
            this.Delete.Text = "Удалить";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Organizer_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(482, 564);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Organizer_window";
            this.Text = "Organizer_window";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Organizer_window_FormClosed);
            this.Load += new System.EventHandler(this.Organizer_window_Load);
            this.Operations.ResumeLayout(false);
            this.View.ResumeLayout(false);
            this.View.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataEvents)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Operations;
        private System.Windows.Forms.GroupBox View;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.RadioButton events;
        private System.Windows.Forms.RadioButton category;
        private System.Windows.Forms.ComboBox TypeMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem Addrevresh;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DataEvents;
        private System.Windows.Forms.DataGridViewImageColumn imeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}