namespace YoutubeDesktop
{
    partial class FormMain
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
            this.Label1 = new System.Windows.Forms.Label();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txToken = new System.Windows.Forms.TextBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.WebBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Button1 = new System.Windows.Forms.Button();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.userControl11 = new YoutubeDesktop.UriBuilder();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.query1 = new YoutubeDesktop.QueryBuilder();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.navigator1 = new YoutubeDesktop.Navigator();
            this.queryBuilder1 = new YoutubeDesktop.QueryBuilder();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.TabPage1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(99, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Paste \'ur code here";
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.Panel1);
            this.TabPage1.Controls.Add(this.WebBrowser1);
            this.TabPage1.Controls.Add(this.Button1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(879, 579);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Login";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.txToken);
            this.Panel1.Controls.Add(this.Button2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 270);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(873, 306);
            this.Panel1.TabIndex = 3;
            // 
            // txToken
            // 
            this.txToken.Location = new System.Drawing.Point(113, 7);
            this.txToken.Name = "txToken";
            this.txToken.Size = new System.Drawing.Size(159, 20);
            this.txToken.TabIndex = 1;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(372, 5);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 0;
            this.Button2.Text = "Do Auth ...";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // WebBrowser1
            // 
            this.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WebBrowser1.Location = new System.Drawing.Point(3, 26);
            this.WebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser1.Name = "WebBrowser1";
            this.WebBrowser1.Size = new System.Drawing.Size(873, 244);
            this.WebBrowser1.TabIndex = 2;
            this.WebBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1_DocumentCompleted);
            // 
            // Button1
            // 
            this.Button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button1.Location = new System.Drawing.Point(3, 3);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(873, 23);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Ask Auth";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.button3);
            this.TabPage2.Controls.Add(this.textBox1);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(879, 579);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Quick Test";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(398, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Call API";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox1.Location = new System.Drawing.Point(401, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(475, 573);
            this.textBox1.TabIndex = 1;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.tabPage3);
            this.TabControl1.Controls.Add(this.tabPage4);
            this.TabControl1.Controls.Add(this.tabPage5);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(887, 605);
            this.TabControl1.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.userControl11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(879, 579);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Url Builder";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // userControl11
            // 
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(879, 579);
            this.userControl11.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.query1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(879, 579);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Query Builder";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // query1
            // 
            this.query1.Debug = true;
            this.query1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.query1.Location = new System.Drawing.Point(3, 3);
            this.query1.Name = "query1";
            this.query1.Size = new System.Drawing.Size(186, 68);
            this.query1.TabIndex = 0;
            this.query1.Load += new System.EventHandler(this.query1_Load);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.navigator1);
            this.tabPage5.Controls.Add(this.queryBuilder1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(879, 579);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Navigation";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // navigator1
            // 
            this.navigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigator1.Location = new System.Drawing.Point(0, 216);
            this.navigator1.Name = "navigator1";
            this.navigator1.Size = new System.Drawing.Size(192, 0);
            this.navigator1.TabIndex = 1;
            // 
            // queryBuilder1
            // 
            this.queryBuilder1.Debug = false;
            this.queryBuilder1.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryBuilder1.Location = new System.Drawing.Point(0, 0);
            this.queryBuilder1.Name = "queryBuilder1";
            this.queryBuilder1.Size = new System.Drawing.Size(192, 216);
            this.queryBuilder1.TabIndex = 0;
            this.queryBuilder1.QueryAsked += new YoutubeDesktop.QueryBuilder.DelegateQueryAsked(this.queryBuilder1_QueryAsked);
            // 
            // ListBox1
            // 
            this.ListBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(0, 605);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(887, 121);
            this.ListBox1.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 726);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.ListBox1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabPage1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox txToken;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.WebBrowser WebBrowser1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private UriBuilder userControl11;
        private System.Windows.Forms.TabPage tabPage4;
        private QueryBuilder query1;
        private System.Windows.Forms.TabPage tabPage5;
        private QueryBuilder queryBuilder1;
        private Navigator navigator1;
    }
}

