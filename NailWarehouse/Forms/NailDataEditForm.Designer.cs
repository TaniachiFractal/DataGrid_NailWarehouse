namespace NailWarehouse.Forms
{
    partial class NailDataEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NailDataEditForm));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.CancelBt = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.pictureNail = new System.Windows.Forms.PictureBox();
            this.priceLb = new System.Windows.Forms.Label();
            this.minCountLb = new System.Windows.Forms.Label();
            this.CountLb = new System.Windows.Forms.Label();
            this.MaterialLb = new System.Windows.Forms.Label();
            this.LengthLb = new System.Windows.Forms.Label();
            this.countNUD = new System.Windows.Forms.NumericUpDown();
            this.bottomTextLabel = new System.Windows.Forms.Label();
            this.priceNUD = new System.Windows.Forms.NumericUpDown();
            this.materialCB = new System.Windows.Forms.ComboBox();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.NameLb = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lengthNUD = new System.Windows.Forms.NumericUpDown();
            this.minCountNUD = new System.Windows.Forms.NumericUpDown();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNUD)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minCountNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelBottom.Controls.Add(this.CancelBt);
            this.panelBottom.Controls.Add(this.OkButton);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 395);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(492, 66);
            this.panelBottom.TabIndex = 31;
            // 
            // CancelBt
            // 
            this.CancelBt.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelBt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBt.Location = new System.Drawing.Point(366, 14);
            this.CancelBt.Name = "CancelBt";
            this.CancelBt.Size = new System.Drawing.Size(104, 40);
            this.CancelBt.TabIndex = 1;
            this.CancelBt.Text = "Отмена";
            this.CancelBt.UseVisualStyleBackColor = false;
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.AliceBlue;
            this.OkButton.Location = new System.Drawing.Point(255, 14);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(105, 40);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // pictureNail
            // 
            this.pictureNail.Image = global::task3_DataGrid_v1NailWarehouse.Properties.Resources.nailPng;
            this.pictureNail.Location = new System.Drawing.Point(12, 12);
            this.pictureNail.Name = "pictureNail";
            this.pictureNail.Size = new System.Drawing.Size(80, 80);
            this.pictureNail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureNail.TabIndex = 0;
            this.pictureNail.TabStop = false;
            // 
            // priceLb
            // 
            this.priceLb.AutoSize = true;
            this.priceLb.Location = new System.Drawing.Point(16, 327);
            this.priceLb.Name = "priceLb";
            this.priceLb.Size = new System.Drawing.Size(131, 25);
            this.priceLb.TabIndex = 41;
            this.priceLb.Text = "Цена без НДС:";
            // 
            // minCountLb
            // 
            this.minCountLb.AutoSize = true;
            this.minCountLb.Location = new System.Drawing.Point(16, 288);
            this.minCountLb.Name = "minCountLb";
            this.minCountLb.Size = new System.Drawing.Size(118, 25);
            this.minCountLb.TabIndex = 40;
            this.minCountLb.Text = "Мин. Кол-во:";
            // 
            // CountLb
            // 
            this.CountLb.AutoSize = true;
            this.CountLb.Location = new System.Drawing.Point(16, 249);
            this.CountLb.Name = "CountLb";
            this.CountLb.Size = new System.Drawing.Size(164, 25);
            this.CountLb.TabIndex = 39;
            this.CountLb.Text = "Кол-во на складе:";
            // 
            // MaterialLb
            // 
            this.MaterialLb.AutoSize = true;
            this.MaterialLb.Location = new System.Drawing.Point(16, 209);
            this.MaterialLb.Name = "MaterialLb";
            this.MaterialLb.Size = new System.Drawing.Size(97, 25);
            this.MaterialLb.TabIndex = 38;
            this.MaterialLb.Text = "Материал:";
            // 
            // LengthLb
            // 
            this.LengthLb.AutoSize = true;
            this.LengthLb.Location = new System.Drawing.Point(16, 169);
            this.LengthLb.Name = "LengthLb";
            this.LengthLb.Size = new System.Drawing.Size(106, 25);
            this.LengthLb.TabIndex = 37;
            this.LengthLb.Text = "Размер, мм:";
            // 
            // countNUD
            // 
            this.countNUD.Location = new System.Drawing.Point(186, 247);
            this.countNUD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.countNUD.Name = "countNUD";
            this.countNUD.Size = new System.Drawing.Size(273, 33);
            this.countNUD.TabIndex = 36;
            // 
            // bottomTextLabel
            // 
            this.bottomTextLabel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bottomTextLabel.Location = new System.Drawing.Point(110, 15);
            this.bottomTextLabel.Name = "bottomTextLabel";
            this.bottomTextLabel.Size = new System.Drawing.Size(371, 105);
            this.bottomTextLabel.TabIndex = 2;
            this.bottomTextLabel.Text = "Редактирование данных товара в реестре склада гвоздей";
            // 
            // priceNUD
            // 
            this.priceNUD.DecimalPlaces = 2;
            this.priceNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.priceNUD.Location = new System.Drawing.Point(186, 325);
            this.priceNUD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.priceNUD.Name = "priceNUD";
            this.priceNUD.Size = new System.Drawing.Size(273, 33);
            this.priceNUD.TabIndex = 35;
            // 
            // materialCB
            // 
            this.materialCB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.materialCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialCB.FormattingEnabled = true;
            this.materialCB.Location = new System.Drawing.Point(186, 206);
            this.materialCB.Name = "materialCB";
            this.materialCB.Size = new System.Drawing.Size(273, 34);
            this.materialCB.TabIndex = 33;
            this.materialCB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.materialCB_DrawItem);
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(186, 128);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(273, 33);
            this.nameTb.TabIndex = 30;
            // 
            // NameLb
            // 
            this.NameLb.AutoSize = true;
            this.NameLb.Location = new System.Drawing.Point(16, 131);
            this.NameLb.Name = "NameLb";
            this.NameLb.Size = new System.Drawing.Size(96, 25);
            this.NameLb.TabIndex = 29;
            this.NameLb.Text = "Название:";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelInfo.Controls.Add(this.bottomTextLabel);
            this.panelInfo.Controls.Add(this.pictureNail);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(492, 105);
            this.panelInfo.TabIndex = 28;
            // 
            // lengthNUD
            // 
            this.lengthNUD.DecimalPlaces = 1;
            this.lengthNUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.lengthNUD.Location = new System.Drawing.Point(186, 167);
            this.lengthNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.lengthNUD.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.lengthNUD.Name = "lengthNUD";
            this.lengthNUD.Size = new System.Drawing.Size(273, 33);
            this.lengthNUD.TabIndex = 32;
            this.lengthNUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // minCountNUD
            // 
            this.minCountNUD.Location = new System.Drawing.Point(186, 286);
            this.minCountNUD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.minCountNUD.Name = "minCountNUD";
            this.minCountNUD.Size = new System.Drawing.Size(273, 33);
            this.minCountNUD.TabIndex = 34;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // NailDataEditForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 461);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.priceLb);
            this.Controls.Add(this.minCountLb);
            this.Controls.Add(this.CountLb);
            this.Controls.Add(this.MaterialLb);
            this.Controls.Add(this.LengthLb);
            this.Controls.Add(this.countNUD);
            this.Controls.Add(this.priceNUD);
            this.Controls.Add(this.materialCB);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.NameLb);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.lengthNUD);
            this.Controls.Add(this.minCountNUD);
            this.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MinimizeBox = false;
            this.Name = "NailDataEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование данных товара в реестре";
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureNail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNUD)).EndInit();
            this.panelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lengthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minCountNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button CancelBt;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.PictureBox pictureNail;
        private System.Windows.Forms.Label priceLb;
        private System.Windows.Forms.Label minCountLb;
        private System.Windows.Forms.Label CountLb;
        private System.Windows.Forms.Label MaterialLb;
        private System.Windows.Forms.Label LengthLb;
        private System.Windows.Forms.NumericUpDown countNUD;
        private System.Windows.Forms.Label bottomTextLabel;
        private System.Windows.Forms.NumericUpDown priceNUD;
        private System.Windows.Forms.ComboBox materialCB;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label NameLb;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.NumericUpDown lengthNUD;
        private System.Windows.Forms.NumericUpDown minCountNUD;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
