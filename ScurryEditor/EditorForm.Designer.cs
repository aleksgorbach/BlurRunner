namespace ScurryEditor {
    partial class EditorForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.levelsTab = new System.Windows.Forms.TabPage();
            this.pages = new System.Windows.Forms.TabControl();
            this.pages.SuspendLayout();
            this.SuspendLayout();
            // 
            // levelsTab
            // 
            this.levelsTab.Location = new System.Drawing.Point(4, 22);
            this.levelsTab.Name = "levelsTab";
            this.levelsTab.Padding = new System.Windows.Forms.Padding(3);
            this.levelsTab.Size = new System.Drawing.Size(700, 412);
            this.levelsTab.TabIndex = 0;
            this.levelsTab.Text = "Levels";
            this.levelsTab.UseVisualStyleBackColor = true;
            // 
            // pages
            // 
            this.pages.Controls.Add(this.levelsTab);
            this.pages.Location = new System.Drawing.Point(12, 12);
            this.pages.Name = "pages";
            this.pages.SelectedIndex = 0;
            this.pages.Size = new System.Drawing.Size(708, 438);
            this.pages.TabIndex = 0;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 462);
            this.Controls.Add(this.pages);
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.pages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage levelsTab;
        private System.Windows.Forms.TabControl pages;
    }
}

