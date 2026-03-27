namespace Warehouse_cosmetics_shope
{
    partial class OtgruzkaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Остаток = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelLogin = new System.Windows.Forms.Label();
            this.Название = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.textBoxArtikul = new System.Windows.Forms.TextBox();
            this.textBoxUnits = new System.Windows.Forms.TextBox();
            this.textBoxClient = new System.Windows.Forms.TextBox();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonGenerateList = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 380);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnType,
            this.ColumnArt,
            this.Остаток,
            this.ColumnNumber,
            this.ColumnClients});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(411, 380);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Название";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 80;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Категория";
            this.ColumnType.MinimumWidth = 6;
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Width = 75;
            // 
            // ColumnArt
            // 
            this.ColumnArt.HeaderText = "Артикул";
            this.ColumnArt.MinimumWidth = 6;
            this.ColumnArt.Name = "ColumnArt";
            this.ColumnArt.Width = 70;
            // 
            // Остаток
            // 
            this.Остаток.HeaderText = "Остаток";
            this.Остаток.MinimumWidth = 6;
            this.Остаток.Name = "Остаток";
            this.Остаток.Width = 60;
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.HeaderText = "Кол-во:";
            this.ColumnNumber.MinimumWidth = 6;
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.Width = 55;
            // 
            // ColumnClients
            // 
            this.ColumnClients.HeaderText = "Клиент";
            this.ColumnClients.MinimumWidth = 6;
            this.ColumnClients.Name = "ColumnClients";
            this.ColumnClients.Width = 70;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(490, 31);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(247, 29);
            this.labelLogin.TabIndex = 7;
            this.labelLogin.Text = "Товары к отгрузке";
            // 
            // Название
            // 
            this.Название.AutoSize = true;
            this.Название.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Название.Location = new System.Drawing.Point(452, 99);
            this.Название.Name = "Название";
            this.Название.Size = new System.Drawing.Size(83, 18);
            this.Название.TabIndex = 8;
            this.Название.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(464, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Артикул";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(449, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Количество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(447, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Тип клиента";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(487, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Клиент";
            // 
            // comboBoxName
            // 
            this.comboBoxName.BackColor = System.Drawing.Color.White;
            this.comboBoxName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxName.ForeColor = System.Drawing.Color.White;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(557, 99);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(197, 24);
            this.comboBoxName.TabIndex = 13;
            // 
            // textBoxArtikul
            // 
            this.textBoxArtikul.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxArtikul.Location = new System.Drawing.Point(557, 134);
            this.textBoxArtikul.Name = "textBoxArtikul";
            this.textBoxArtikul.Size = new System.Drawing.Size(197, 15);
            this.textBoxArtikul.TabIndex = 30;
            // 
            // textBoxUnits
            // 
            this.textBoxUnits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUnits.Location = new System.Drawing.Point(557, 167);
            this.textBoxUnits.Name = "textBoxUnits";
            this.textBoxUnits.Size = new System.Drawing.Size(197, 15);
            this.textBoxUnits.TabIndex = 16;
            // 
            // textBoxClient
            // 
            this.textBoxClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxClient.Location = new System.Drawing.Point(557, 238);
            this.textBoxClient.Name = "textBoxClient";
            this.textBoxClient.Size = new System.Drawing.Size(197, 15);
            this.textBoxClient.TabIndex = 17;
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonAddProduct.FlatAppearance.BorderSize = 0;
            this.buttonAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddProduct.ForeColor = System.Drawing.Color.Black;
            this.buttonAddProduct.Location = new System.Drawing.Point(542, 280);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(172, 36);
            this.buttonAddProduct.TabIndex = 18;
            this.buttonAddProduct.Text = "Добавить  товар";
            this.buttonAddProduct.UseVisualStyleBackColor = false;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.BackColor = System.Drawing.Color.White;
            this.comboBoxType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxType.ForeColor = System.Drawing.Color.White;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(557, 199);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(197, 24);
            this.comboBoxType.TabIndex = 19;
            // 
            // buttonGenerateList
            // 
            this.buttonGenerateList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonGenerateList.FlatAppearance.BorderSize = 0;
            this.buttonGenerateList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateList.ForeColor = System.Drawing.Color.Black;
            this.buttonGenerateList.Location = new System.Drawing.Point(542, 322);
            this.buttonGenerateList.Name = "buttonGenerateList";
            this.buttonGenerateList.Size = new System.Drawing.Size(172, 34);
            this.buttonGenerateList.TabIndex = 20;
            this.buttonGenerateList.Text = "Сформировать список";
            this.buttonGenerateList.UseVisualStyleBackColor = false;
            this.buttonGenerateList.Click += new System.EventHandler(this.buttonGenerateList_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(196)))), ((int)(((byte)(209)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(576, 377);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(110, 23);
            this.buttonBack.TabIndex = 21;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // OtgruzkaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonGenerateList);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.textBoxClient);
            this.Controls.Add(this.textBoxUnits);
            this.Controls.Add(this.textBoxArtikul);
            this.Controls.Add(this.comboBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Название);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "OtgruzkaForm";
            this.Text = "Отгрузка";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Остаток;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClients;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label Название;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.TextBox textBoxArtikul;
        private System.Windows.Forms.TextBox textBoxUnits;
        private System.Windows.Forms.TextBox textBoxClient;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Button buttonGenerateList;
        private System.Windows.Forms.Button buttonBack;
    }
}