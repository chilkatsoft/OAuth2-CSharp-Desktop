namespace OAuth2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnFacebook = new System.Windows.Forms.Button();
            this.btnGoogle = new System.Windows.Forms.Button();
            this.btnLinkedIn = new System.Windows.Forms.Button();
            this.btnSalesForce = new System.Windows.Forms.Button();
            this.btnGitHub = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.txtRefreshToken = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtListenPort = new System.Windows.Forms.TextBox();
            this.btnMsGraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnFacebook
            // 
            this.btnFacebook.Location = new System.Drawing.Point(20, 81);
            this.btnFacebook.Name = "btnFacebook";
            this.btnFacebook.Size = new System.Drawing.Size(100, 35);
            this.btnFacebook.TabIndex = 1;
            this.btnFacebook.Text = "Facebook";
            this.btnFacebook.UseVisualStyleBackColor = true;
            this.btnFacebook.Click += new System.EventHandler(this.btnFacebook_Click);
            // 
            // btnGoogle
            // 
            this.btnGoogle.Location = new System.Drawing.Point(151, 81);
            this.btnGoogle.Name = "btnGoogle";
            this.btnGoogle.Size = new System.Drawing.Size(100, 35);
            this.btnGoogle.TabIndex = 2;
            this.btnGoogle.Text = "Google";
            this.btnGoogle.UseVisualStyleBackColor = true;
            this.btnGoogle.Click += new System.EventHandler(this.btnGoogle_Click);
            // 
            // btnLinkedIn
            // 
            this.btnLinkedIn.Location = new System.Drawing.Point(282, 81);
            this.btnLinkedIn.Name = "btnLinkedIn";
            this.btnLinkedIn.Size = new System.Drawing.Size(100, 35);
            this.btnLinkedIn.TabIndex = 3;
            this.btnLinkedIn.Text = "LinkedIn";
            this.btnLinkedIn.UseVisualStyleBackColor = true;
            this.btnLinkedIn.Click += new System.EventHandler(this.btnLinkedIn_Click);
            // 
            // btnSalesForce
            // 
            this.btnSalesForce.Location = new System.Drawing.Point(413, 81);
            this.btnSalesForce.Name = "btnSalesForce";
            this.btnSalesForce.Size = new System.Drawing.Size(100, 35);
            this.btnSalesForce.TabIndex = 4;
            this.btnSalesForce.Text = "SalesForce";
            this.btnSalesForce.UseVisualStyleBackColor = true;
            this.btnSalesForce.Click += new System.EventHandler(this.btnSalesForce_Click);
            // 
            // btnGitHub
            // 
            this.btnGitHub.Location = new System.Drawing.Point(544, 81);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new System.Drawing.Size(100, 35);
            this.btnGitHub.TabIndex = 5;
            this.btnGitHub.Text = "GitHub";
            this.btnGitHub.UseVisualStyleBackColor = true;
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Access Token:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Refresh Token:";
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(106, 137);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(465, 20);
            this.txtAccessToken.TabIndex = 9;
            // 
            // txtRefreshToken
            // 
            this.txtRefreshToken.Location = new System.Drawing.Point(106, 173);
            this.txtRefreshToken.Name = "txtRefreshToken";
            this.txtRefreshToken.Size = new System.Drawing.Size(465, 20);
            this.txtRefreshToken.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "* Some providers to not give refresh tokens.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 237);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(978, 303);
            this.textBox1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Error / Info Log";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(784, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Listen Port: ";
            // 
            // txtListenPort
            // 
            this.txtListenPort.Location = new System.Drawing.Point(853, 89);
            this.txtListenPort.Name = "txtListenPort";
            this.txtListenPort.Size = new System.Drawing.Size(51, 20);
            this.txtListenPort.TabIndex = 15;
            this.txtListenPort.Text = "3017";
            // 
            // btnMsGraph
            // 
            this.btnMsGraph.Location = new System.Drawing.Point(668, 81);
            this.btnMsGraph.Name = "btnMsGraph";
            this.btnMsGraph.Size = new System.Drawing.Size(100, 35);
            this.btnMsGraph.TabIndex = 16;
            this.btnMsGraph.Text = "Microsoft Graph";
            this.btnMsGraph.UseVisualStyleBackColor = true;
            this.btnMsGraph.Click += new System.EventHandler(this.btnMsGraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 564);
            this.Controls.Add(this.btnMsGraph);
            this.Controls.Add(this.txtListenPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRefreshToken);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGitHub);
            this.Controls.Add(this.btnSalesForce);
            this.Controls.Add(this.btnLinkedIn);
            this.Controls.Add(this.btnGoogle);
            this.Controls.Add(this.btnFacebook);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "OAuth2 ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFacebook;
        private System.Windows.Forms.Button btnGoogle;
        private System.Windows.Forms.Button btnLinkedIn;
        private System.Windows.Forms.Button btnSalesForce;
        private System.Windows.Forms.Button btnGitHub;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.TextBox txtRefreshToken;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtListenPort;
        private System.Windows.Forms.Button btnMsGraph;
        }
    }

