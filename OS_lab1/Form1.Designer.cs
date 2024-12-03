namespace OS_lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox_buffer = new System.Windows.Forms.RichTextBox();
            this.richTextBox_reader = new System.Windows.Forms.RichTextBox();
            this.richTextBox_writers = new System.Windows.Forms.RichTextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_pause_reader = new System.Windows.Forms.Button();
            this.button_pause_writers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_buffer
            // 
            this.richTextBox_buffer.Location = new System.Drawing.Point(535, 71);
            this.richTextBox_buffer.Name = "richTextBox_buffer";
            this.richTextBox_buffer.ReadOnly = true;
            this.richTextBox_buffer.Size = new System.Drawing.Size(153, 316);
            this.richTextBox_buffer.TabIndex = 0;
            this.richTextBox_buffer.Text = "";
            // 
            // richTextBox_reader
            // 
            this.richTextBox_reader.Location = new System.Drawing.Point(12, 71);
            this.richTextBox_reader.Name = "richTextBox_reader";
            this.richTextBox_reader.ReadOnly = true;
            this.richTextBox_reader.Size = new System.Drawing.Size(517, 155);
            this.richTextBox_reader.TabIndex = 1;
            this.richTextBox_reader.Text = "";
            // 
            // richTextBox_writers
            // 
            this.richTextBox_writers.Location = new System.Drawing.Point(12, 232);
            this.richTextBox_writers.Name = "richTextBox_writers";
            this.richTextBox_writers.ReadOnly = true;
            this.richTextBox_writers.Size = new System.Drawing.Size(517, 155);
            this.richTextBox_writers.TabIndex = 2;
            this.richTextBox_writers.Text = "";
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(535, 8);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(152, 57);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_pause_reader
            // 
            this.button_pause_reader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_pause_reader.Location = new System.Drawing.Point(12, 8);
            this.button_pause_reader.Name = "button_pause_reader";
            this.button_pause_reader.Size = new System.Drawing.Size(152, 57);
            this.button_pause_reader.TabIndex = 4;
            this.button_pause_reader.Text = "Pause Reader";
            this.button_pause_reader.UseVisualStyleBackColor = true;
            this.button_pause_reader.Click += new System.EventHandler(this.button_reader_pause_Click);
            // 
            // button_pause_writers
            // 
            this.button_pause_writers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_pause_writers.Location = new System.Drawing.Point(170, 8);
            this.button_pause_writers.Name = "button_pause_writers";
            this.button_pause_writers.Size = new System.Drawing.Size(152, 57);
            this.button_pause_writers.TabIndex = 5;
            this.button_pause_writers.Text = "Pause Writers";
            this.button_pause_writers.UseVisualStyleBackColor = true;
            this.button_pause_writers.Click += new System.EventHandler(this.button_writers_pause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 398);
            this.Controls.Add(this.button_pause_writers);
            this.Controls.Add(this.button_pause_reader);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.richTextBox_writers);
            this.Controls.Add(this.richTextBox_reader);
            this.Controls.Add(this.richTextBox_buffer);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_buffer;
        private System.Windows.Forms.RichTextBox richTextBox_reader;
        private System.Windows.Forms.RichTextBox richTextBox_writers;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_pause_reader;
        private System.Windows.Forms.Button button_pause_writers;
    }
}

