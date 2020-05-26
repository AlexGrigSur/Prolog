module MainWindow
open System
open System.Data
open System.Windows.Forms
open MySql.Data.MySqlClient

let mainForm = new Form()
let dataGridView1 = new System.Windows.Forms.DataGridView();
let Add = new System.Windows.Forms.Button();
let Edit = new System.Windows.Forms.Button();
let Delete = new System.Windows.Forms.Button();
let id = new System.Windows.Forms.DataGridViewTextBoxColumn();
let BulletName = new System.Windows.Forms.DataGridViewTextBoxColumn();
let BulletWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
let BulletSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
let On0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
dataGridView1.Columns.Add("On0","Energy\nOn 0 meters")
dataGridView1.Columns.Add("On100","Energy\nOn 100 meters")
dataGridView1.Columns.Add("On200","Energy\nOn 200 meters")
dataGridView1.Columns.Add("On300","Energy\nOn 300 meters")

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
// On0
//
On0.HeaderText <- "On 100m";
On0.Name <- "On100";
On0.ReadOnly <- true;
// 
// On100
// 
On100.HeaderText <- "On 100m";
On100.Name <- "On100";
On100.ReadOnly <- true;
// 
// On200
// 
//On200.HeaderText <- "On 200m";
//On200.Name <- "On200";
On200.ReadOnly <- true;
// 
// On300
// 
//On300.HeaderText <- "On 300m";
//On300.Name <- "On300";
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
mainForm.FormBorderStyle <- System.Windows.Forms.FormBorderStyle.Sizable;
mainForm.Name <- "Form1";
mainForm.Text <- "ИЗ №16(BulletCalc)";

mainForm.Controls.Add(panel1);
mainForm.Controls.Add(dataGridView1);
panel1.Controls.Add(Add);
panel1.Controls.Add(Delete);
panel1.Controls.Add(Edit);

let connectionStrGlobal = "server=localhost;port=3306;username=root;password=;database=IZ16"

let ExecuteReader (commandStr:string) (connectionStr:string) = 
    use connection = new MySqlConnection(connectionStr)
    connection.Open()
    use command = new MySqlCommand(commandStr,connection)
    let reader = command.ExecuteReader()
    while (reader.Read()) do
        dataGridView1.Rows.Add(reader.GetString(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetString(7))
    ()

let ExecuteCommand (commandStr:string) (connectionStr:string) = 
    use connection = new MySqlConnection(connectionStr)
    connection.Open()
    use command = new MySqlCommand(commandStr,connection)
    command.ExecuteNonQuery() |> ignore
    ()
    
let DataGridViewRefresh = 
    dataGridView1.Rows.Clear()
    ExecuteReader "SELECT * FROM `IZ16`.`BulletCalc`" connectionStrGlobal
    dataGridView1.ClearSelection()
    ()

let formLoad(e:EventArgs) =
    DataGridViewRefresh
    dataGridView1.ClearSelection()
    
let AddClick(e:EventArgs) = 
    Add_Edit.testForm(-1)
    //DataGridViewRefresh
    dataGridView1.Rows.Clear()
    ExecuteReader "SELECT * FROM `IZ16`.`BulletCalc`" connectionStrGlobal
    dataGridView1.ClearSelection()

let EditClick(e:EventArgs) = 
    if(dataGridView1.RowCount=0) then
        MessageBox.Show "DataBase is empty" |> ignore
        else
            if(dataGridView1.SelectedRows.Count<>0) then
                Add_Edit.testForm(Convert.ToInt32(dataGridView1.SelectedRows.[0].Cells.[0].Value))
                //DataGridViewRefresh
                dataGridView1.Rows.Clear()
                ExecuteReader "SELECT * FROM `IZ16`.`BulletCalc`" connectionStrGlobal
                dataGridView1.ClearSelection()
            else
                MessageBox.Show "Choose any record to Edit" |> ignore

let DeleteClick(e:EventArgs) =  
    if(dataGridView1.RowCount=0) then
        MessageBox.Show "DataBase is empty"
        ()
        else
            if(dataGridView1.SelectedRows.Count<>0) then
                ExecuteCommand ("DELETE FROM `IZ16`.`BulletCalc` WHERE `id`="+Convert.ToString(dataGridView1.SelectedRows.[0].Cells.[0].Value)) connectionStrGlobal
                //DataGridViewRefresh
                dataGridView1.Rows.Clear()
                ExecuteReader "SELECT * FROM `IZ16`.`BulletCalc`" connectionStrGlobal
                dataGridView1.ClearSelection()
            else
                MessageBox.Show "Choose any record to Edit" |> ignore

    
let DGVClearSelection(e:EventArgs)=
    dataGridView1.ClearSelection()

Delete.Click.Add(DeleteClick)
mainForm.Load.Add(formLoad)         
Add.Click.Add(AddClick)
Edit.Click.Add(EditClick)
dataGridView1.DoubleClick.Add(DGVClearSelection)
