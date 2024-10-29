using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows.Forms;
using NailWarehouse.Helpers;
using NailWarehouse.Models;
using NailWarehouse.ValidatableModels;

namespace NailWarehouse.Forms
{
    /// <summary>
    /// Форма работы с товаром
    /// </summary>
    public partial class NailDataEditForm : Form
    {
        public const int ComboboxPadding = 3;
        private readonly ValidatableNail currNail;

        /// <summary>
        /// Товар, с которым работает эта форма
        /// </summary>
        public ValidatableNail CurrNail => currNail;

        /// <summary>
        /// Конструктор формы работы с товаром
        /// </summary>
        public NailDataEditForm(ValidatableNail outNail = null)
        {
            InitializeComponent();

            currNail = outNail == null ?
                 new ValidatableNail()
                 {
                     Id = Guid.NewGuid(),
                     Name = "Без названия",
                     Length = 1.0M,
                     Material = Material.Copper,
                     Count = 10,
                     MinCount = 1,
                     Price = 100.0M
                 }
                 : new ValidatableNail()
                 {
                     Id = outNail.Id,
                     Name = outNail.Name,
                     Length = outNail.Length,
                     Material = outNail.Material,
                     Count = outNail.Count,
                     MinCount = outNail.MinCount,
                     Price = outNail.Price,
                 };

            materialCB.DataSource = Enum.GetValues(typeof(Material));

            nameTb.AddBinding(target => target.Text, currNail, nail => nail.Name, errorProvider);
            lengthNUD.AddBinding(target => target.Value, currNail, nail => nail.Length);
            materialCB.AddBinding(target => target.SelectedItem, currNail, nail => nail.Material);
            countNUD.AddBinding(target => target.Value, currNail, nail => nail.Count);
            minCountNUD.AddBinding(target => target.Value, currNail, nail => nail.MinCount);
            priceNUD.AddBinding(target => target.Value, currNail, nail => nail.Price);
        }

        private void materialCB_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            var value = (Material)(sender as ComboBox).Items[e.Index];

            e.Graphics.DrawString(value.GetDescription(),
                e.Font,
                new SolidBrush(e.ForeColor),
                e.Bounds.X,
                e.Bounds.Y + ComboboxPadding);

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (currNail.ValidateNail())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

    }
}
