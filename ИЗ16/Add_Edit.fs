module Add_Edit
open System
open System.Data
open System.Windows.Forms
open MySql.Data.MySqlClient

let testForm (id:int)=
    let EditorForm = new Form()
    let textBox1 = new System.Windows.Forms.TextBox()
    let textBox2 = new System.Windows.Forms.TextBox()
    let textBox3 = new System.Windows.Forms.TextBox()
    let label1 = new System.Windows.Forms.Label()
    let label2 = new System.Windows.Forms.Label()
    let label3 = new System.Windows.Forms.Label()
    let Continue = new System.Windows.Forms.Button()
    let Cancel = new System.Windows.Forms.Button()
    // 
    // textBox1
    // 
    textBox1.Location <- new System.Drawing.Point(49, 62)
    textBox1.Name <- "textBox1"
    textBox1.Size <- new System.Drawing.Size(143, 20)
    textBox1.TabIndex <- 0
    // 
    // textBox2
    // 
    textBox2.Location <- new System.Drawing.Point(234, 62)
    textBox2.Name <- "textBox2"
    textBox2.Size <- new System.Drawing.Size(143, 20)
    textBox2.TabIndex <- 1
    // 
    // textBox3
    // 
    textBox3.Location <- new System.Drawing.Point(422, 62)
    textBox3.Name <- "textBox3"
    textBox3.Size <- new System.Drawing.Size(143, 20)
    textBox3.TabIndex <- 2
    // 
    // label1
    // 
    label1.AutoSize <- true
    label1.Location <- new System.Drawing.Point(46, 46)
    label1.Name <- "label1"
    label1.Size <- new System.Drawing.Size(90, 13)
    label1.TabIndex <- 3
    label1.Text <- "Input bullet Name"
    // 
    // label2
    // 
    label2.AutoSize <- true
    label2.Location <- new System.Drawing.Point(231, 46)
    label2.Name <- "label2"
    label2.Size <- new System.Drawing.Size(111, 13)
    label2.TabIndex <- 4
    label2.Text <- "Input bullet Weigth(gr)"
    // 
    // label3
    // 
    label3.AutoSize <- true
    label3.Location <- new System.Drawing.Point(419, 46)
    label3.Name <- "label3"
    label3.Size <- new System.Drawing.Size(170, 13)
    label3.TabIndex <- 5
    label3.Text <- "Input bullet Speed(meters/second)"
    // 
    // Continue
    // 
    Continue.Location <- new System.Drawing.Point(49, 110)
    Continue.Name <- "Continue"
    Continue.Size <- new System.Drawing.Size(236, 70)
    Continue.TabIndex <- 6
    Continue.Text <- "Continue"
    Continue.UseVisualStyleBackColor <- true
    // 
    // Cancel
    // 
    Cancel.Location <- new System.Drawing.Point(336, 110)
    Cancel.Name <- "Cancel"
    Cancel.Size <- new System.Drawing.Size(229, 70)
    Cancel.TabIndex <- 7
    Cancel.Text <- "Cancel"
    Cancel.UseVisualStyleBackColor <- true
    // 
    // add_edit
    // 
    EditorForm.AutoScaleDimensions <- new System.Drawing.SizeF(6.0F, 13.0F)
    EditorForm.AutoScaleMode <- System.Windows.Forms.AutoScaleMode.Font
    EditorForm.ClientSize <- new System.Drawing.Size(637, 235)
    EditorForm.FormBorderStyle <- System.Windows.Forms.FormBorderStyle.FixedSingle
    EditorForm.Name <- "add_edit"
    EditorForm.Text <- "DBEditor"

    EditorForm.Controls.Add(Cancel)
    EditorForm.Controls.Add(Continue)
    EditorForm.Controls.Add(label3)
    EditorForm.Controls.Add(label2)
    EditorForm.Controls.Add(label1)
    EditorForm.Controls.Add(textBox3)
    EditorForm.Controls.Add(textBox2)
    EditorForm.Controls.Add(textBox1)

    let connectionStr = "server=localhost;port=3306;username=root;password=;database=IZ16"

    //let ExecuteSql (query:string) (connectionStr:string) = 
    //    use rawSqlConnection = new MySqlConnection(connectionStr)
    //    rawSqlConnection.Open() |> ignore
    //    use command = new MySqlCommand(query, rawSqlConnection)
    //    command.ExecuteNonQuery() |> ignore
    //    ()
    let toDB (weight:double) (speed:double)=
        let on100:double = weight/1000.0 * (speed * 85.0 / 100.0) * (speed * 85.0 / 100.0) / 2.0
        let on200:double = weight/1000.0 * (speed * 70.0 / 100.0) * (speed * 70.0 / 100.0) / 2.0
        let on300:double = weight/1000.0 * (speed * 55.0 / 100.0) * (speed * 55.0 / 100.0) / 2.0
    
        if(id = -1) then
            let commandStr = "INSERT INTO `IZ16`.`BulletCalc` (`id`,`BulletName`,`Weight`,`Speed`,`On100`,`On200`,`On300`) VALUES (NULL,'"+textBox1.Text+"','"+weight.ToString()+"','"+speed.ToString()+"','"+on100.ToString()+"','"+on200.ToString()+"','"+on300.ToString()+"')"
            use connection = new MySqlConnection(connectionStr)
            connection.Open() |> ignore
            use command = new MySqlCommand(commandStr,connection)
            command.ExecuteNonQuery() |>ignore
        else
            let commandStr = "UPDATE INTO `IZ16`.`BulletCalc` (`id`,`BulletName`,`Weight`,`Speed`,`On100`,`On200`,`On300`) VALUES ('"+textBox1.Text+"','"+weight.ToString()+"','"+speed.ToString()+"','"+on100.ToString()+"','"+on200.ToString()+"','"+on300.ToString()+"')"
            use connection = new MySqlConnection(connectionStr)
            connection.Open() |> ignore
            use command = new MySqlCommand(commandStr,connection)
            command.ExecuteNonQuery() |>ignore
        ()

    let ContinueClick(e:EventArgs) =
        if(textBox1.TextLength=0 || textBox2.TextLength=0 || textBox3.TextLength=0) then
            MessageBox.Show "Fill all Fields" |> ignore
        try
            let weight = Convert.ToDouble(textBox2.Text)
            let speed = Convert.ToDouble(textBox3.Text)
            toDB weight speed
            ()
        with
            | :? Exception ->  MessageBox.Show "Error with Fields consist" |> ignore
        //finally

    
    let CancelClick(e:EventArgs) = 
        EditorForm.Close()
        ()
    Continue.Click.Add(ContinueClick)
    Cancel.Click.Add(CancelClick)
    EditorForm.ShowDialog()
    ()
