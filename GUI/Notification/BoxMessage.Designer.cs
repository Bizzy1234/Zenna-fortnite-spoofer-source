namespace spoofer.pro.GUI.Notification
{
    partial class BoxMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoxMessage));
            this.panel2 = new System.Windows.Forms.Panel();
            this.messageLbl = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLbl = new System.Windows.Forms.Label();
            this.siticoneShadowPanel2 = new Siticone.UI.WinForms.SiticoneShadowPanel();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.siticoneShadowPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel2.Location = new System.Drawing.Point(33, 226);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 100);
            this.panel2.TabIndex = 12;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // messageLbl
            // 
            this.messageLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.messageLbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageLbl.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLbl.ForeColor = System.Drawing.Color.Silver;
            this.messageLbl.Location = new System.Drawing.Point(50, 80);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.ReadOnly = true;
            this.messageLbl.Size = new System.Drawing.Size(329, 140);
            this.messageLbl.TabIndex = 10;
            this.messageLbl.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel1.Location = new System.Drawing.Point(33, -28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 100);
            this.panel1.TabIndex = 11;
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.titleLbl.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.ForeColor = System.Drawing.Color.Silver;
            this.titleLbl.Location = new System.Drawing.Point(47, 37);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(54, 34);
            this.titleLbl.TabIndex = 9;
            this.titleLbl.Text = "Title";
            // 
            // siticoneShadowPanel2
            // 
            this.siticoneShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneShadowPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("siticoneShadowPanel2.BackgroundImage")));
            this.siticoneShadowPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.siticoneShadowPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.siticoneShadowPanel2.Controls.Add(this.messageLbl);
            this.siticoneShadowPanel2.Controls.Add(this.titleLbl);
            this.siticoneShadowPanel2.Controls.Add(this.materialButton3);
            this.siticoneShadowPanel2.Controls.Add(this.panel1);
            this.siticoneShadowPanel2.Controls.Add(this.panel2);
            this.siticoneShadowPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.siticoneShadowPanel2.Location = new System.Drawing.Point(-35, -28);
            this.siticoneShadowPanel2.Name = "siticoneShadowPanel2";
            this.siticoneShadowPanel2.ShadowColor = System.Drawing.Color.Black;
            this.siticoneShadowPanel2.ShadowShift = 7;
            this.siticoneShadowPanel2.Size = new System.Drawing.Size(462, 302);
            this.siticoneShadowPanel2.TabIndex = 5;
            this.siticoneShadowPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.siticoneShadowPanel2_Paint);
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSize = false;
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.materialButton3.Depth = 0;
            this.materialButton3.DrawShadows = false;
            this.materialButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(101, 233);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.Size = new System.Drawing.Size(236, 36);
            this.materialButton3.TabIndex = 5;
            this.materialButton3.Text = "Close";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = false;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // BoxMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 246);
            this.Controls.Add(this.siticoneShadowPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoxMessage";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoxMessage";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BoxMessage_Load);
            this.siticoneShadowPanel2.ResumeLayout(false);
            this.siticoneShadowPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox messageLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLbl;
        private Siticone.UI.WinForms.SiticoneShadowPanel siticoneShadowPanel2;
        private MaterialSkin.Controls.MaterialButton materialButton3;
    }
}