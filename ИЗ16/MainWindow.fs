module MainWindow
open System
open System.Data
open System.Windows.Forms
open MySql.Data.MySqlClient

module firstWindow =
    let mainForm = new Form()
    let dataGridView1 = new System.Windows.Forms.DataGridView();
    let Add = new System.Windows.Forms.Button();
    let Edit = new System.Windows.Forms.Button();
    let Delete = new System.Windows.Forms.Button();
    let id = new System.Windows.Forms.DataGridViewTextBoxColumn();
    let BulletName = new System.Windows.Forms.DataGridViewTextBoxColumn();
    let BulletWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
    let BulletSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
    let On100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
    let On200 = new System.Windows.Forms.DataGridViewTextBoxColumn();
    let On300 = new System.Windows.Forms.DataGridViewTextBoxColumn();
    let panel1 = new System.Windows.Forms.Panel();
    //
    // dataGridView1
    //
    dataGridView1.AllowUserToAddRows <- false;
    dataGridView1.AllowUserToDeleteRows <- false;
    dataGridView1.Anchor <- (System.Windows.Forms.AnchorStyles.Top ||| System.Windows.Forms.AnchorStyles.Bottom ||| System.Windows.Forms.AnchorStyles.Left ||| System.Windows.Forms.AnchorStyles.Right);
    dataGridView1.ColumnHeadersHeightSizeMode <- System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridView1.Location <- new System.Drawing.Point(12, 12);
    dataGridView1.MultiSelect <- false;
    dataGridView1.Name <- "dataGridView1";
    dataGridView1.ReadOnly <- true;
    dataGridView1.SelectionMode <- System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
    dataGridView1.Size <- new System.Drawing.Size(760, 478);
    dataGridView1.TabIndex <- 0;
    dataGridView1.Columns.Add("id","id")
    dataGridView1.Columns.Add("BulletName","Bullet Name")
    dataGridView1.Columns.Add("BulletWeight","Bullet Weight") 
    dataGridView1.Columns.Add("BulletSpeed","Bullet Speed"); 
    dataGridView1.Columns.Add("On100","On100")
    dataGridView1.Columns.Add("On200","On200")
    dataGridView1.Columns.Add("On300","On300")

    // 
    // Add
    // 
    Add.Location <- new System.Drawing.Point(5, 3);
    Add.Name <- "Add";
    Add.Size <- new System.Drawing.Size(226, 86);
    Add.TabIndex <- 1;
    Add.Text <- "Add";
    Add.UseVisualStyleBackColor <- true;
    // 
    // Edit
    // 
    Edit.Location <- new System.Drawing.Point(5, 95);
    Edit.Name <- "Edit";
    Edit.Size <- new System.Drawing.Size(226, 86);
    Edit.TabIndex <- 2;
    Edit.Text <- "Edit";
    Edit.UseVisualStyleBackColor <- true;
    // 
    // Delete
    // 
    Delete.Location <- new System.Drawing.Point(5, 187);
    Delete.Name <- "Delete";
    Delete.Size <- new System.Drawing.Size(226, 86);
    Delete.TabIndex <- 3;
    Delete.Text <- "Delete";
    Delete.UseVisualStyleBackColor <- true;
    // 
    // id
    // 
    id.HeaderText <- "id";
    id.Name <- "id";
    id.ReadOnly <- true;
    // 
    // BulletName
    // 
    BulletName.HeaderText <- "Name";
    BulletName.Name <- "BulletName";
    BulletName.ReadOnly <- true;
    // 
    // BulletWeight
    // 
    BulletWeight.HeaderText <- "Weight";
    BulletWeight.Name <- "BulletWeight";
    BulletWeight.ReadOnly <- true;
    // 
    // BulletSpeed
    // 
    BulletSpeed.HeaderText <- "Speed";
    BulletSpeed.Name <- "BulletSpeed";
    BulletSpeed.ReadOnly <- true;
    // 
    // On100
    // 
    On100.HeaderText <- "On 100m";
    On100.Name <- "On100";
    On100.ReadOnly <- true;
    // 
    // On200
    // 
    On200.HeaderText <- "On 200m";
    On200.Name <- "On200";
    On200.ReadOnly <- true;
    // 
    // On300
    // 
    On300.HeaderText <- "On 300m";
    On300.Name <- "On300";
    On300.ReadOnly <- true;
    // 
    // panel1
    // 
    panel1.Anchor <- (System.Windows.Forms.AnchorStyles.Top ||| System.Windows.Forms.AnchorStyles.Right);
    panel1.Location <- new System.Drawing.Point(779, 12);
    panel1.Name <- "panel1";
    panel1.Size <- new System.Drawing.Size(233, 281);
    panel1.TabIndex <- 4;
    // 
    // Form1
    //
    mainForm.AutoScaleDimensions <- new System.Drawing.SizeF(6.0F, 13.0F);
    mainForm.AutoScaleMode <- System.Windows.Forms.AutoScaleMode.Font;
    mainForm.ClientSize <- new System.Drawing.Size(1028, 502);
    mainForm.FormBorderStyle <- System.Windows.Forms.FormBorderStyle.FixedSingle;
    mainForm.Name <- "Form1";
    mainForm.Text <- "ИЗ №16(BulletCalc)";

    mainForm.Controls.Add(panel1);
    mainForm.Controls.Add(dataGridView1);
    panel1.Controls.Add(Add);
    panel1.Controls.Add(Delete);
    panel1.Controls.Add(Edit);

    let connectionStr = new MySqlConnection "server=localhost;port=3306;username=root;password=;database=IZ161"

    //let ExecuteSql (query:string) (connectionStr:string) =
    //    use rawSqlConnection = new MySqlConnection(connectionStr)
    //    rawSqlConnection.Open()
    //    use command = new MySqlCommand(query, rawSqlConnection)
    //    command.ExecuteNonQuery() |> ignore
    //    ()

    let formLoad(e:EventArgs) =
        //let rec DGVFill reader:MySqlDataReader=
        //    if(reader.Read()) then
        try
            let str = "CREATE DATABASE IF NOT EXISTS `IZ161`"
            let conn = "server=localhost;port=3306;username=root;password=;"
            let tempConnection = new MySqlConnection(conn)
            tempConnection.Open()
            let command = new MySqlCommand(str,tempConnection)
            command.ExecuteNonQuery |> ignore
            let str1 = "CREATE TABLE IF NOT EXISTS `BulletCalc` (`id` INT(11) NOT NULL primary key AUTO_INCREMENT UNIQUE, `BulletName` VARCHAR(150) NOT NULL, `Weight` INT(11), `Speed` INT(11), `On100` INT(11), `On200` INT(11), `On300` INT(11))"
            command.CommandText <- str1
            command.Connection <- connectionStr
            connectionStr.Open()
            command.ExecuteNonQuery |> ignore
        with
            | :? Exception -> ()
        //command.CommandText <- "SELECT * FROM `MainTable`"
        //let reader:MySqlDataReader = command.ExecuteReader()        
        ()
    
    mainForm.Load.Add(formLoad)

    let AddClick(e:EventArgs) = 
        if(dataGridView1.SelectedRows.Count=0) then
            Add_Edit.testForm(-1) |> ignore
        else
             Add_Edit.testForm(Convert.ToInt32(dataGridView1.SelectedRows.[0].Cells.[0].Value)) |> ignore
        ()

    Add.Click.Add(AddClick)
