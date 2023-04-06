namespace ToDoLIst
{
    public class Form1 : Form
    {
        FlowLayoutPanel flowLayoutPanel1;
        Button create;
        CheckBox checkbox1;
        TodoItem item1;
        TextBox textBox1;
        TextBox textBox2;
        TextBox textBox3;
        List<TodoItem> Items = new List<TodoItem>();
        DataGridView toDoListView;
        //IBindableComponent component;

        struct TodoItem
        {
            public string name;
            public DateTime due;
            public string extraInfo;

            public TodoItem(string name, DateTime due)
            {
                this.name = name;
                this.due = due;
                this.extraInfo = "";
                
            }
            public TodoItem(string name, DateTime due, string extraInfo)
            {
                this.name = name;
                this.due = due;
                this.extraInfo = extraInfo;
            }
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            this.create = new Button();
            this.checkbox1 = new CheckBox();


            //Create item button
            this.create.Text = "Create";
            this.create.Size = new System.Drawing.Size(80, 30);
            this.create.Padding = new Padding(10);
            this.create.TabIndex = 0;
            this.create.Click += CreateNewItem;

            //TodoItemManual
            item1 = new TodoItem("Economics Essay", new DateTime(2022, 10, 21, 23, 59, 0),"L bozo");

            //Textbox1
            this.textBox1 = new TextBox();
            this.textBox1.ReadOnly = true;
            this.textBox1.Multiline = true;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.textBox1.Text = item1.name;
            this.textBox1.Margin = new Padding(10);
            this.textBox1.Size = new System.Drawing.Size(120, 50);
            this.textBox1.Location = new System.Drawing.Point(100, 50);

            //Textbox2
            this.textBox2 = new TextBox();
            this.textBox2.ReadOnly = true;
            this.textBox2.Multiline = true;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.textBox2.Text = item1.due.ToString("dddd, dd MMMM yyyy");
            this.textBox2.Margin = new Padding(10);
            this.textBox2.Size = new System.Drawing.Size(120, 50);
            this.textBox2.Location = new System.Drawing.Point(250, 50);

            //Tectbox3
            this.textBox3 = new TextBox();
            this.textBox3.ReadOnly = true;
            this.textBox3.Multiline = true;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.textBox3.Text = item1.extraInfo;
            this.textBox3.Margin = new Padding(10);
            this.textBox3.Size = new System.Drawing.Size(120, 50);
            this.textBox3.Location = new System.Drawing.Point(400, 50);

            //DataGridView
            toDoListView.Coll


            //Controls Add
            Controls.Add(this.create);
            Controls.Add(this.textBox1);
            Controls.Add(this.textBox2);
            Controls.Add(this.textBox3);
            
            
            
            
        }

        private void CreateNewItem(Object sender, EventArgs e)
        {
            

        }

    }
}