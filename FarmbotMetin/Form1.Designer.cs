namespace FarmbotMetin
{
    partial class Form1
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
            this.buttonCapture = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.buttonHitNextMetin = new System.Windows.Forms.Button();
            this.buttonCollectItems = new System.Windows.Forms.Button();
            this.buttonStartBotting = new System.Windows.Forms.Button();
            this.buttonStopBotting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(1198, 12);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(75, 23);
            this.buttonCapture.TabIndex = 1;
            this.buttonCapture.Text = "Capture";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1180, 582);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // buttonRecord
            // 
            this.buttonRecord.Location = new System.Drawing.Point(1198, 41);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonRecord.TabIndex = 3;
            this.buttonRecord.Text = "Record";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1198, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "End Recording";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(1198, 112);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(75, 23);
            this.buttonAnalyze.TabIndex = 5;
            this.buttonAnalyze.Text = "Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // buttonHitNextMetin
            // 
            this.buttonHitNextMetin.Location = new System.Drawing.Point(1198, 141);
            this.buttonHitNextMetin.Name = "buttonHitNextMetin";
            this.buttonHitNextMetin.Size = new System.Drawing.Size(75, 39);
            this.buttonHitNextMetin.TabIndex = 6;
            this.buttonHitNextMetin.Text = "Hit next metin";
            this.buttonHitNextMetin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonHitNextMetin.UseVisualStyleBackColor = true;
            this.buttonHitNextMetin.Click += new System.EventHandler(this.buttonHitNextMetin_Click);
            // 
            // buttonCollectItems
            // 
            this.buttonCollectItems.Location = new System.Drawing.Point(1198, 186);
            this.buttonCollectItems.Name = "buttonCollectItems";
            this.buttonCollectItems.Size = new System.Drawing.Size(75, 39);
            this.buttonCollectItems.TabIndex = 7;
            this.buttonCollectItems.Text = "Collect Items";
            this.buttonCollectItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCollectItems.UseVisualStyleBackColor = true;
            this.buttonCollectItems.Click += new System.EventHandler(this.buttonCollectItems_Click);
            // 
            // buttonStartBotting
            // 
            this.buttonStartBotting.Location = new System.Drawing.Point(1198, 231);
            this.buttonStartBotting.Name = "buttonStartBotting";
            this.buttonStartBotting.Size = new System.Drawing.Size(75, 39);
            this.buttonStartBotting.TabIndex = 8;
            this.buttonStartBotting.Text = "Start botting";
            this.buttonStartBotting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStartBotting.UseVisualStyleBackColor = true;
            this.buttonStartBotting.Click += new System.EventHandler(this.buttonStartBotting_Click);
            // 
            // buttonStopBotting
            // 
            this.buttonStopBotting.Location = new System.Drawing.Point(1198, 276);
            this.buttonStopBotting.Name = "buttonStopBotting";
            this.buttonStopBotting.Size = new System.Drawing.Size(75, 39);
            this.buttonStopBotting.TabIndex = 9;
            this.buttonStopBotting.Text = "Stop Botting";
            this.buttonStopBotting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStopBotting.UseVisualStyleBackColor = true;
            this.buttonStopBotting.Click += new System.EventHandler(this.buttonStopBotting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 606);
            this.Controls.Add(this.buttonStopBotting);
            this.Controls.Add(this.buttonStartBotting);
            this.Controls.Add(this.buttonCollectItems);
            this.Controls.Add(this.buttonHitNextMetin);
            this.Controls.Add(this.buttonAnalyze);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonCapture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.Button buttonHitNextMetin;
        private System.Windows.Forms.Button buttonCollectItems;
        private System.Windows.Forms.Button buttonStartBotting;
        private System.Windows.Forms.Button buttonStopBotting;
    }
}

