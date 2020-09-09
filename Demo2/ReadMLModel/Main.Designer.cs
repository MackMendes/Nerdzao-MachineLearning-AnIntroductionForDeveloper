namespace NumberSage
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
            this.textUrl = new System.Windows.Forms.TextBox();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelPrediction = new System.Windows.Forms.Label();
            this.textResponse = new System.Windows.Forms.RichTextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.hostCanvas = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // textUrl
            // 
            this.textUrl.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUrl.Location = new System.Drawing.Point(13, 12);
            this.textUrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(423, 42);
            this.textUrl.TabIndex = 1;
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Location = new System.Drawing.Point(81, 478);
            this.buttonRecognize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(87, 43);
            this.buttonRecognize.TabIndex = 3;
            this.buttonRecognize.Text = "Recognize";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(172, 479);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(117, 44);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear Result";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelPrediction
            // 
            this.labelPrediction.Font = new System.Drawing.Font("Segoe UI Light", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrediction.ForeColor = System.Drawing.Color.Maroon;
            this.labelPrediction.Location = new System.Drawing.Point(11, 525);
            this.labelPrediction.Name = "labelPrediction";
            this.labelPrediction.Size = new System.Drawing.Size(419, 101);
            this.labelPrediction.TabIndex = 5;
            this.labelPrediction.Text = "0";
            this.labelPrediction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textResponse
            // 
            this.textResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textResponse.Font = new System.Drawing.Font("Segoe UI Light", 15.75F);
            this.textResponse.Location = new System.Drawing.Point(441, 12);
            this.textResponse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textResponse.Name = "textResponse";
            this.textResponse.Size = new System.Drawing.Size(428, 615);
            this.textResponse.TabIndex = 7;
            this.textResponse.Text = "";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(293, 478);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(119, 44);
            this.buttonLoad.TabIndex = 8;
            this.buttonLoad.Text = "Load Model";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "model";
            this.openFile.Filter = "ONNX Files|*.onnx|All Files|*.*";
            // 
            // hostCanvas
            // 
            this.hostCanvas.Location = new System.Drawing.Point(13, 57);
            this.hostCanvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hostCanvas.Name = "hostCanvas";
            this.hostCanvas.Size = new System.Drawing.Size(422, 417);
            this.hostCanvas.TabIndex = 9;
            this.hostCanvas.Text = "elementHost1";
            this.hostCanvas.Child = null;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(878, 636);
            this.Controls.Add(this.hostCanvas);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textResponse);
            this.Controls.Add(this.labelPrediction);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonRecognize);
            this.Controls.Add(this.textUrl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(806, 464);
            this.Name = "Main";
            this.Text = "Demonstration 2 - Sharing Cluster Sessions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textUrl;
        private System.Windows.Forms.Button buttonRecognize;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelPrediction;
        private System.Windows.Forms.RichTextBox textResponse;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Integration.ElementHost hostCanvas;
    }
}

