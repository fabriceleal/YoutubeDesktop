namespace YoutubeDesktop
{
    partial class FeedControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedControl));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btTopFirst = new System.Windows.Forms.ToolStripButton();
            this.btTopPrev = new System.Windows.Forms.ToolStripButton();
            this.btTopNext = new System.Windows.Forms.ToolStripButton();
            this.btTopLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbTopPageNbr = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lbTopPageTot = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(489, 385);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btTopFirst,
            this.btTopPrev,
            this.btTopNext,
            this.btTopLast,
            this.toolStripSeparator1,
            this.lbTopPageNbr,
            this.toolStripLabel2,
            this.lbTopPageTot});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(489, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btTopFirst
            // 
            this.btTopFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btTopFirst.Image = ((System.Drawing.Image)(resources.GetObject("btTopFirst.Image")));
            this.btTopFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTopFirst.Name = "btTopFirst";
            this.btTopFirst.Size = new System.Drawing.Size(27, 22);
            this.btTopFirst.Text = "<<";
            this.btTopFirst.Click += new System.EventHandler(this.btTopFirst_Click);
            // 
            // btTopPrev
            // 
            this.btTopPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btTopPrev.Image = ((System.Drawing.Image)(resources.GetObject("btTopPrev.Image")));
            this.btTopPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTopPrev.Name = "btTopPrev";
            this.btTopPrev.Size = new System.Drawing.Size(23, 22);
            this.btTopPrev.Text = "<";
            this.btTopPrev.Click += new System.EventHandler(this.btTopPrev_Click);
            // 
            // btTopNext
            // 
            this.btTopNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btTopNext.Image = ((System.Drawing.Image)(resources.GetObject("btTopNext.Image")));
            this.btTopNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTopNext.Name = "btTopNext";
            this.btTopNext.Size = new System.Drawing.Size(23, 22);
            this.btTopNext.Text = ">";
            this.btTopNext.Click += new System.EventHandler(this.btTopNext_Click);
            // 
            // btTopLast
            // 
            this.btTopLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btTopLast.Image = ((System.Drawing.Image)(resources.GetObject("btTopLast.Image")));
            this.btTopLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTopLast.Name = "btTopLast";
            this.btTopLast.Size = new System.Drawing.Size(27, 22);
            this.btTopLast.Text = ">>";
            this.btTopLast.Click += new System.EventHandler(this.btTopLast_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lbTopPageNbr
            // 
            this.lbTopPageNbr.Name = "lbTopPageNbr";
            this.lbTopPageNbr.Size = new System.Drawing.Size(13, 22);
            this.lbTopPageNbr.Text = "0";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(18, 22);
            this.toolStripLabel2.Text = "of";
            // 
            // lbTopPageTot
            // 
            this.lbTopPageTot.Name = "lbTopPageTot";
            this.lbTopPageTot.Size = new System.Drawing.Size(13, 22);
            this.lbTopPageTot.Text = "1";
            // 
            // FeedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "FeedControl";
            this.Size = new System.Drawing.Size(489, 410);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btTopFirst;
        private System.Windows.Forms.ToolStripButton btTopPrev;
        private System.Windows.Forms.ToolStripButton btTopNext;
        private System.Windows.Forms.ToolStripButton btTopLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbTopPageNbr;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel lbTopPageTot;
    }
}
