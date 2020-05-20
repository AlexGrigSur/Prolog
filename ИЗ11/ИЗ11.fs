open System
open System.IO
open System.Windows.Forms

let form = new Form()
form.Visible <-true
form.AutoScaleDimensions <- new System.Drawing.SizeF(6.0F, 13.0F);
form.AutoScaleMode <- System.Windows.Forms.AutoScaleMode.Font;
form.ClientSize <- new System.Drawing.Size(502, 228);
form.FormBorderStyle <- System.Windows.Forms.FormBorderStyle.FixedSingle;
form.Name <- "Form1";
form.Text <- "Quadratic equation";
form.ResumeLayout(false);
form.PerformLayout();

let Calculate = new System.Windows.Forms.Button();
Calculate.Location <- new System.Drawing.Point(16, 156);
Calculate.Name <- "Calculate";
Calculate.Size <- new System.Drawing.Size(110, 60);
Calculate.TabIndex <- 3;
Calculate.Text <- "Рассчитать";
Calculate.UseVisualStyleBackColor <- true;

let textBox1 = new System.Windows.Forms.TextBox();
textBox1.Location <- new System.Drawing.Point(33, 95);
textBox1.Name <- "textBox1";
textBox1.Size <- new System.Drawing.Size(73, 20);
textBox1.TabIndex <- 0;

let textBox2 = new System.Windows.Forms.TextBox();
textBox2.Location <- new System.Drawing.Point(179, 96);
textBox2.Name <- "textBox2";
textBox2.Size <- new System.Drawing.Size(79, 20);
textBox2.TabIndex <- 1;

let textBox3 = new System.Windows.Forms.TextBox();
textBox3.Location <- new System.Drawing.Point(301, 97);
textBox3.Name <- "textBox3";
textBox3.Size <- new System.Drawing.Size(82, 20);
textBox3.TabIndex <- 2;

let label1 = new System.Windows.Forms.Label();
label1.AutoSize <- true;
label1.Font <- new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
label1.Location <- new System.Drawing.Point(31, 9);
label1.Name <- "label1";
label1.Size <- new System.Drawing.Size(351, 20);
label1.TabIndex <- 4;
label1.Text <- "Программа решения квадратного уравнения";

let label2 = new System.Windows.Forms.Label();
label2.AutoSize <- true;
label2.Font <- new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
label2.Location <- new System.Drawing.Point(29, 29);
label2.Name <- "label2";
label2.Size <- new System.Drawing.Size(207, 20);
label2.TabIndex <- 5;
label2.Text <- "Введите входные данные";

let label3 = new System.Windows.Forms.Label();
label3.AutoSize <- true;
label3.Font <- new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
label3.Location <- new System.Drawing.Point(12, 96);
label3.Name <- "label3";
label3.Size <- new System.Drawing.Size(20, 20);
label3.TabIndex <- 6;
label3.Text <- "A";

let label4 = new System.Windows.Forms.Label();
label4.AutoSize <- true;
label4.Font <- new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
label4.Location <- new System.Drawing.Point(109, 97);
label4.Name <- "label4";
label4.Size <- new System.Drawing.Size(64, 20);
label4.TabIndex <- 7;
label4.Text <- "X^2 + B";

let label5 = new System.Windows.Forms.Label();
label5.AutoSize <- true;
label5.Font <- new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
label5.Location <- new System.Drawing.Point(264, 99);
label5.Name <- "label5";
label5.Size <- new System.Drawing.Size(31, 18);
label5.TabIndex <- 8;
label5.Text <- "X +";

let label6 = new System.Windows.Forms.Label();
label6.AutoSize <- true;
label6.Font <- new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
label6.Location <- new System.Drawing.Point(389, 97);
label6.Name <- "label6";
label6.Size <- new System.Drawing.Size(46, 20);
label6.TabIndex <- 9;
label6.Text <- "C = 0";

let richTextBox1 = new System.Windows.Forms.RichTextBox();
richTextBox1.Location <- new System.Drawing.Point(179, 156);
richTextBox1.Name <- "richTextBox1";
richTextBox1.ReadOnly <- true;
richTextBox1.Size <- new System.Drawing.Size(204, 60);
richTextBox1.TabIndex <- 4;
richTextBox1.Text <- "";

let label7 = new System.Windows.Forms.Label();
label7.AutoSize <- true;
label7.Location <- new System.Drawing.Point(176, 140);
label7.Name <- "label7";
label7.Size <- new System.Drawing.Size(59, 13);
label7.TabIndex <- 11;
label7.Text <- "Результат";

form.Controls.Add(Calculate)
form.Controls.Add(textBox1)
form.Controls.Add(textBox2)
form.Controls.Add(textBox3)
form.Controls.Add(label1)
form.Controls.Add(label2)
form.Controls.Add(label3)
form.Controls.Add(label4)
form.Controls.Add(label5)
form.Controls.Add(label6)
form.Controls.Add(richTextBox1)
form.Controls.Add(label7)

[<EntryPoint>]
let main argv =
    do Application.Run(form)
    0
