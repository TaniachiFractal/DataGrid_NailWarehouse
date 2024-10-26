using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using NailWarehouse.Helpers;
using NailWarehouse.Models;
using NailWarehouse.Models.Interfaces;

namespace NailWarehouse.Forms
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {

        private readonly INailManager nailManager;
        private readonly BindingSource nailBindingSource;

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm(INailManager manager)
        {
            InitializeComponent();

            nailManager = manager;
            nailBindingSource = new BindingSource();

            nailsDGV.DataSource = nailBindingSource;
            nailsDGV.AutoGenerateColumns = false;

            UpdateData();
        }

        private async Task SetStats()
        {
            var result = await nailManager.GetStatsAsync();
            lbCount.Text = $"Позиций: {result.FullCount}";
            lbSumWTax.Text = $"Общ. сумма с НДС: {result.FullSummaryWithTax:n2} руб";
            lbSumNoTax.Text = $"Общ. сумма без НДС: {result.FullSummaryNoTax:n2} руб";
        }

        private async void UpdateData()
        {
            nailBindingSource.ResetBindings(false);
            await SetStats();
        }

        private Nail GetSelectedNail()
        {
            return (Nail)nailsDGV.Rows[nailsDGV.SelectedRows[0].Index].DataBoundItem;
        }

        #region control events

        private void nailsDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (nailsDGV.Columns[e.ColumnIndex].Name == nameof(MaterialColumn))
            {
                var row = (Nail)nailsDGV.Rows[e.RowIndex].DataBoundItem;
                e.Value = row.Material.GetDescription();
            }
            else if (nailsDGV.Columns[e.ColumnIndex].Name == nameof(SummaryColumn))
            {
                var row = (Nail)nailsDGV.Rows[e.RowIndex].DataBoundItem;
                e.Value = row.Count * row.Price;
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            nailBindingSource.DataSource = await nailManager.GetAllAsync();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InfoForm().ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            var nailDataEditForm = new NailDataEditForm();
            if (nailDataEditForm.ShowDialog(this) == DialogResult.OK)
            {
                await nailManager.AddAsync(Converters.ToNail(nailDataEditForm.CurrNail));
                UpdateData();
            }
        }

        private async void editButton_Click(object sender, EventArgs e)
        {
            if (nailsDGV.SelectedRows.Count > 0)
            {
                var nail = GetSelectedNail();
                var nailDataEditForm = new NailDataEditForm(Converters.ToValidatableNail(nail));
                if (nailDataEditForm.ShowDialog(this) == DialogResult.OK)
                {
                    await nailManager.EditAsync(Converters.ToNail(nailDataEditForm.CurrNail));
                    UpdateData();
                }
            }
        }

        private async void removeButton_Click(object sender, EventArgs e)
        {
            if (nailsDGV.SelectedRows.Count > 0)
            {
                var nail = GetSelectedNail();
                if (MessageBox.Show(
                    $"Точно удалить товар \"{nail.Name}\"?",
                    "ВНИМАНИЕ",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                    ) == DialogResult.OK)
                {
                    await nailManager.DeleteAsync(nail.Id);
                    UpdateData();
                }
            }
        }

        #endregion

    }
}
