
namespace Steganography_Tutorial
{
    partial class Form1
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
            this.rTBSecretText = new System.Windows.Forms.RichTextBox();
            this.tBSourcePath = new System.Windows.Forms.TextBox();
            this.btSource = new System.Windows.Forms.Button();
            this.btEmbed = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblSecretMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rTBSecretText
            // 
            this.rTBSecretText.Location = new System.Drawing.Point(12, 12);
            this.rTBSecretText.Name = "rTBSecretText";
            this.rTBSecretText.Size = new System.Drawing.Size(443, 284);
            this.rTBSecretText.TabIndex = 0;
            this.rTBSecretText.Text = "Dies ist eine versteckte und geheime Nachricht.";
            // 
            // tBSourcePath
            // 
            this.tBSourcePath.Location = new System.Drawing.Point(461, 53);
            this.tBSourcePath.Name = "tBSourcePath";
            this.tBSourcePath.Size = new System.Drawing.Size(197, 20);
            this.tBSourcePath.TabIndex = 1;
            this.tBSourcePath.Text = "D:\\Schule\\3_Semester\\ALG\\Steganographie\\Einfaches Beispiel\\Rotterdam.jpg";
            this.tBSourcePath.TextChanged += new System.EventHandler(this.tBSourcePath_TextChanged);
            // 
            // btSource
            // 
            this.btSource.Location = new System.Drawing.Point(664, 52);
            this.btSource.Name = "btSource";
            this.btSource.Size = new System.Drawing.Size(124, 20);
            this.btSource.TabIndex = 2;
            this.btSource.Text = "Select Source File";
            this.btSource.UseVisualStyleBackColor = true;
            this.btSource.Click += new System.EventHandler(this.btSource_Click);
            // 
            // btEmbed
            // 
            this.btEmbed.Location = new System.Drawing.Point(664, 245);
            this.btEmbed.Name = "btEmbed";
            this.btEmbed.Size = new System.Drawing.Size(124, 20);
            this.btEmbed.TabIndex = 3;
            this.btEmbed.Text = "Einbetten";
            this.btEmbed.UseVisualStyleBackColor = true;
            this.btEmbed.Click += new System.EventHandler(this.btEmbed_Click);
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(664, 276);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(124, 20);
            this.btnExtract.TabIndex = 4;
            this.btnExtract.Text = "Extrahieren";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(461, 90);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(110, 13);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "Versteckte Nachricht:";
            // 
            // lblSecretMessage
            // 
            this.lblSecretMessage.AutoSize = true;
            this.lblSecretMessage.Location = new System.Drawing.Point(461, 112);
            this.lblSecretMessage.Name = "lblSecretMessage";
            this.lblSecretMessage.Size = new System.Drawing.Size(0, 13);
            this.lblSecretMessage.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 308);
            this.Controls.Add(this.lblSecretMessage);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btEmbed);
            this.Controls.Add(this.btSource);
            this.Controls.Add(this.tBSourcePath);
            this.Controls.Add(this.rTBSecretText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTBSecretText;
        private System.Windows.Forms.TextBox tBSourcePath;
        private System.Windows.Forms.Button btSource;
        private System.Windows.Forms.Button btEmbed;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblSecretMessage;
    }
}

