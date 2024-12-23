namespace ProjetoBitcoin
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;  // Grid para exibir os dados
        private System.Windows.Forms.Button buttonConsultarDados;  // Botão para consultar dados da API
        private System.Windows.Forms.Button buttonGravarDados;  // Botão para gravar dados no banco de dados
        private System.Windows.Forms.DataGridViewTextBoxColumn columnData;  // Coluna para exibir data
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPrecoAtual;  // Coluna para exibir preço atual
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPrecoAnterior;  // Coluna para exibir preço anterior
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVariacao;  // Coluna para exibir variação do preço
        private System.Windows.Forms.Label labelTitle;  // Título da aplicação

        /// <summary>
        /// Limpa os recursos utilizados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();  // Libera os componentes utilizados
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer do Windows Form

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            columnData = new DataGridViewTextBoxColumn();
            columnPrecoAtual = new DataGridViewTextBoxColumn();
            columnPrecoAnterior = new DataGridViewTextBoxColumn();
            columnVariacao = new DataGridViewTextBoxColumn();
            buttonConsultarDados = new Button();
            buttonGravarDados = new Button();
            labelTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { columnData, columnPrecoAtual, columnPrecoAnterior, columnVariacao });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = Color.LightSkyBlue;
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridView1.GridColor = Color.Silver;
            dataGridView1.Location = new Point(31, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Size = new Size(602, 200);
            dataGridView1.TabIndex = 1;
            // 
            // columnData
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnData.DefaultCellStyle = dataGridViewCellStyle3;
            columnData.HeaderText = "Data Atual";
            columnData.Name = "columnData";
            // 
            // columnPrecoAtual
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnPrecoAtual.DefaultCellStyle = dataGridViewCellStyle4;
            columnPrecoAtual.HeaderText = "Preço Atual";
            columnPrecoAtual.Name = "columnPrecoAtual";
            // 
            // columnPrecoAnterior
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnPrecoAnterior.DefaultCellStyle = dataGridViewCellStyle5;
            columnPrecoAnterior.HeaderText = "Preço Anterior";
            columnPrecoAnterior.Name = "columnPrecoAnterior";
            // 
            // columnVariacao
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnVariacao.DefaultCellStyle = dataGridViewCellStyle6;
            columnVariacao.HeaderText = "Variação";
            columnVariacao.Name = "columnVariacao";
            // 
            // buttonConsultarDados
            // 
            buttonConsultarDados.BackColor = Color.DodgerBlue;
            buttonConsultarDados.FlatAppearance.BorderSize = 0;
            buttonConsultarDados.FlatStyle = FlatStyle.Flat;
            buttonConsultarDados.Font = new Font("Segoe UI", 10F);
            buttonConsultarDados.ForeColor = Color.White;
            buttonConsultarDados.Location = new Point(373, 309);
            buttonConsultarDados.Name = "buttonConsultarDados";
            buttonConsultarDados.Size = new Size(120, 40);
            buttonConsultarDados.TabIndex = 2;
            buttonConsultarDados.Text = "Exibir Dados";
            buttonConsultarDados.UseVisualStyleBackColor = false;
            buttonConsultarDados.Click += buttonConsultarDados_Click;
            // 
            // buttonGravarDados
            // 
            buttonGravarDados.BackColor = Color.DodgerBlue;
            buttonGravarDados.FlatAppearance.BorderSize = 0;
            buttonGravarDados.FlatStyle = FlatStyle.Flat;
            buttonGravarDados.Font = new Font("Segoe UI", 10F);
            buttonGravarDados.ForeColor = Color.White;
            buttonGravarDados.Location = new Point(513, 309);
            buttonGravarDados.Name = "buttonGravarDados";
            buttonGravarDados.Size = new Size(120, 40);
            buttonGravarDados.TabIndex = 3;
            buttonGravarDados.Text = "Gravar Dados";
            buttonGravarDados.UseVisualStyleBackColor = false;
            buttonGravarDados.Click += buttonGravarDados_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.DodgerBlue;
            labelTitle.Location = new Point(265, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(157, 25);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Consulta Bitcoin";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(674, 381);
            Controls.Add(labelTitle);
            Controls.Add(buttonGravarDados);
            Controls.Add(buttonConsultarDados);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta Bitcoin";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
