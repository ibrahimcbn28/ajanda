using System;
using System.Windows.Forms;

namespace AgendaApp
{
    public partial class Form1 : Form
    {
        private MonthCalendar monthCalendar1;
        private Label lblSelectedDate;
        private DataGridView dataGridViewEvents;
        private Button btnAddEvent;
        private Button btnEditEvent;
        private Button btnDeleteEvent;

        public Form1()
        {
          
        }

        private void InitializeComponent()
        {
            this.monthCalendar1 = new MonthCalendar();
            this.lblSelectedDate = new Label();
            this.dataGridViewEvents = new DataGridView();
            this.btnAddEvent = new Button();
            this.btnEditEvent = new Button();
            this.btnDeleteEvent = new Button();

            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(10, 20);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.DateChanged += new DateRangeEventHandler(this.monthCalendar1_DateChanged);

            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.AutoSize = true;
            this.lblSelectedDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSelectedDate.Location = new System.Drawing.Point(250, 20);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(150, 21);
            this.lblSelectedDate.Text = "Seçilen Tarih: [Bugün]";

            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Location = new System.Drawing.Point(250, 60);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.Size = new System.Drawing.Size(520, 300);
            this.dataGridViewEvents.Columns.Add("Title", "Başlık");
            this.dataGridViewEvents.Columns.Add("Date", "Tarih");
            this.dataGridViewEvents.Columns.Add("Time", "Saat");
            this.dataGridViewEvents.Columns.Add("Description", "Açıklama");

            // Kolonları sadece okunur hale getirelim
            this.dataGridViewEvents.Columns[0].ReadOnly = true;
            this.dataGridViewEvents.Columns[1].ReadOnly = true;
            this.dataGridViewEvents.Columns[2].ReadOnly = true;
            this.dataGridViewEvents.Columns[3].ReadOnly = true;

            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(250, 380);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(120, 40);
            this.btnAddEvent.Text = "Etkinlik Ekle";
            this.btnAddEvent.Click += new EventHandler(this.btnAddEvent_Click);

            // 
            // btnEditEvent
            // 
            this.btnEditEvent.Location = new System.Drawing.Point(380, 380);
            this.btnEditEvent.Name = "btnEditEvent";
            this.btnEditEvent.Size = new System.Drawing.Size(120, 40);
            this.btnEditEvent.Text = "Etkinlik Düzenle";
            this.btnEditEvent.Click += new EventHandler(this.btnEditEvent_Click);

            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Location = new System.Drawing.Point(510, 380);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(120, 40);
            this.btnDeleteEvent.Text = "Etkinlik Sil";
            this.btnDeleteEvent.Click += new EventHandler(this.btnDeleteEvent_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.lblSelectedDate);
            this.Controls.Add(this.dataGridViewEvents);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.btnEditEvent);
            this.Controls.Add(this.btnDeleteEvent);
            this.Name = "Form1";
            this.Text = "Ajanda Uygulaması";
            this.Load += new EventHandler(this.Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblSelectedDate.Text = $"Seçilen Tarih: {monthCalendar1.SelectionStart.ToShortDateString()}";
            LoadEvents();
        }

        private void LoadEvents()
        {
            dataGridViewEvents.Rows.Clear();
            dataGridViewEvents.Rows.Add("Toplantı", "12/12/2024", "14:00", "Yıllık planlama toplantısı");
            dataGridViewEvents.Rows.Add("Seminer", "15/12/2024", "09:00", "Yeni yazılım teknolojileri semineri");
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblSelectedDate.Text = $"Seçilen Tarih: {e.Start.ToShortDateString()}";
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Etkinlik ekleme ekranı açılacak.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Etkinlik düzenleme ekranı açılacak.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewEvents.SelectedRows)
                {
                    dataGridViewEvents.Rows.RemoveAt(row.Index);
                }
            }
            else
            {
                MessageBox.Show("Silmek için bir etkinlik seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
