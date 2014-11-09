namespace LightweightHtmlWidgets
{
    partial class Window
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.Control = new Awesomium.Windows.Forms.WebControl(this.components);
            this.ContextMenu = new Awesomium.Windows.Forms.WebControlContextMenu(this.components);
            this.SuspendLayout();
            // 
            // Control
            // 
            this.Control.ContextMenuStrip = this.ContextMenu;
            this.Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Control.Location = new System.Drawing.Point(0, 0);
            this.Control.Size = new System.Drawing.Size(284, 261);
            this.Control.TabIndex = 0;
            // 
            // ContextMenu
            // 
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ContextMenu.Size = new System.Drawing.Size(206, 126);
            this.ContextMenu.View = null;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Control);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Window";
            this.ResumeLayout(false);

        }

        #endregion

        private Awesomium.Windows.Forms.WebControl Control;
        private Awesomium.Windows.Forms.WebControlContextMenu ContextMenu;
    }
}

